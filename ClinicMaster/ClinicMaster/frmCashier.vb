
Option Strict On
Option Infer On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Enumerations
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona
Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmCashier

#Region " Fields "

    Private defaultVisitNo As String = String.Empty
    Private defaultVisitType As String = String.Empty
    Private cashierPrinterPaperSize As String = String.Empty

    Private currentCashAllSaved As Boolean = True
    Private currentCashVisitNo As String = String.Empty
    Private currentBillFormAllSaved As Boolean = True
    Private currentBillFormVisitNo As String = String.Empty
    Private cashReceiptSaved As Boolean = False
    Private billFormReceiptSaved As Boolean = False
    Private bPReceiptSaved As Boolean = False
    Private cBFPReceiptSaved As Boolean = False
    Private accountReceiptSaved As Boolean = False
    Private otherIncomeReceiptSaved As Boolean = False
    Private refundsReceiptSaved As Boolean = False
    Private expenditureReceiptSaved As Boolean = False
    Private oVariousOptions As New VariousOptions()
    Private Const EditText As String = "&Edit"
    Private Const UpdateText As String = "&Update"
    Private receiptNoPrefix As String = oVariousOptions.ReceiptNoPrefix + Today.Year.ToString().Substring(2)
    Private items As DataTable
    Private ipdItems As DataTable
    Private extraBillItems As DataTable
    Private billCustomers As DataTable
    Private insuranceCompanies As DataTable
    Private billCompanies As DataTable

    Private alertCheckPeriod As Integer
    Private alertsStartDateTime As Date = Now

    Private tipOutstandingBalanceWords As New ToolTip()
    Private tipCashAccountBalanceWords As New ToolTip()
    Private tipCoPayValueWords As New ToolTip()

    Private tipBFPOutstandingBalanceWords As New ToolTip()
    Private tipBFPCashAccountBalanceWords As New ToolTip()
    Private tipBFPCoPayValueWords As New ToolTip()

    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()

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
    Private cashParagraphs As Collection
    Private CashThermalReceiptParagraphs As Collection
    Private CashIPDThermalReceiptParagraphs As Collection
    Private billFormParagraphs As Collection
    Private bPParagraphs As Collection
    Private bPThermalParagraphs As Collection
    Private cBFPParagraphs As Collection
    Private CBFPThermalParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private PriorityID As String
    Private oExpenditureSourceType As New LookupDataID.ExpenditureSourceTypeID
    Private oReturnResaonType As New LookupDataID.ReturnReasonTypeID()
    Dim oPayModesID As New LookupDataID.PayModesID()
    Private bankNameID As String
    Private bankAccountNo As String
    Private oCurrenciesID As New LookupDataID.CurrenciesID
    Private oCollectionSourceTyPyID As New LookupDataID.CollectionSourceTypeID
    Private oItemCategoryID As New LookupDataID.ItemCategoryID()
    Private previousRefunded As Decimal

    Private oPayTypeID As New LookupDataID.PayTypeID()
    Private oVisitTypeID As New LookupDataID.VisitTypeID()
    Dim oItemStatusID As New LookupDataID.ItemStatusID

    Private visitTypeID As String = String.Empty
    Private oServicepointID As New LookupDataID.ServicePointID()
    Private oDocumentTypeID As New LookupDataID.DocumentTypeID()
    Dim oExtraItemCodes As New LookupDataID.ExtraItemCodes()
    Private oBillModesID As New LookupDataID.BillModesID()
    Private oReversalActionID As New LookupDataID.ReversalActionID()
    Private payNo As String
    Dim oEntryModeID As New LookupDataID.EntryModeID()
    Dim oObjectNames As New LookupDataID.AccessObjectNames()
    Dim oCopayTypeID As New LookupDataID.CoPayTypeID()
#End Region

#Region " Validations "
    Dim billModesID As String

    Private Sub dtpPayDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)

        Dim errorMSG As String = "Pay date can't be before visit date!"

        Try

            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
            Dim payDate As Date = DateMayBeEnteredIn(Me.dtpPayDate)

            If payDate = AppData.NullDateValue Then Return

            If payDate < visitDate Then
                ErrProvider.SetError(Me.dtpPayDate, errorMSG)
                Me.dtpPayDate.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpPayDate, "")
            End If

        Catch ex As Exception
            Return

        End Try

    End Sub

    Private Sub dtpBFPPayDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpBFPPayDate.Validating

        Dim errorMSG As String = "Pay date can't be before visit date!"

        Try

            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbBFPVisitDate)
            Dim payDate As Date = DateMayBeEnteredIn(Me.dtpBFPPayDate)

            If payDate = AppData.NullDateValue Then Return

            If payDate < visitDate Then
                ErrProvider.SetError(Me.dtpBFPPayDate, errorMSG)
                Me.dtpBFPPayDate.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpBFPPayDate, "")
            End If

        Catch ex As Exception
            Return

        End Try

    End Sub

    Private Sub dtpRefundDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)

        Dim errorMSG As String = "Refund date can't be before pay date!"

        Try

            Dim payDate As Date = DateMayBeEnteredIn(Me.stbRefundPayDate)
            Dim refundDate As Date = DateMayBeEnteredIn(Me.dtpRefundDate)

            If refundDate = AppData.NullDateValue Then Return

            If refundDate < payDate Then
                ErrProvider.SetError(Me.dtpRefundDate, errorMSG)
                Me.dtpRefundDate.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpRefundDate, "")
            End If

        Catch ex As Exception
            Return

        End Try

    End Sub


    Private Sub nbxAccountAmount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nbxAccountAmount.Validating

        Dim errorMSG As String = "Amount can’t be more than amount tendered in local currency!"

        Try

            Dim amount As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmount)
            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmountTendered)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountExchangeRate)

            If amount > (amountTendered * exchangeRate) Then
                ErrProvider.SetError(Me.nbxAccountAmount, errorMSG)
                Me.nbxAccountAmount.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.nbxAccountAmount, String.Empty)
            End If

        Catch ex As Exception
            Return

        End Try

    End Sub

#End Region

    Private Sub frmCashier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oVariousOptions As New VariousOptions()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.dtpPayDate.MaxDate = Today
        Me.dtpBFPPayDate.MaxDate = Today

        Me.dtpSpentDate.MaxDate = Today
        Me.dtpIncomeDate.MaxDate = Today
        Me.dtpTransactionDate.MaxDate = Today
        Me.dtpRefundDate.MaxDate = Today

        Me.dtpBPStartDate.MaxDate = Today
        Me.dtpBPEndDate.MaxDate = Today

        Me.dtpCBFPStartDate.MaxDate = Today
        Me.dtpCBFPEndDate.MaxDate = Today

        Me.dtpBFPPayDate.Value = Today
        Me.dtpRefundDate.Value = Today
        Me.dtpTransactionDate.Value = Today
        Me.dtpBPStartDate.Value = Today.AddDays(-1)
        Me.dtpBPEndDate.Value = Today

        Me.dtpCBFPStartDate.Value = Today.AddDays(-1)
        Me.dtpCBFPEndDate.Value = Today
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.SetDefaultPrinter()
        LoadLookupDataCombo(colRefundReason, LookupObjects.ReturnReasonTypeID, False)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With InitOptions
                Me.stbReceiptNo.ReadOnly = .ReceiptNoLocked
                Me.stbBFPReceiptNo.ReadOnly = .ReceiptNoLocked
                Me.stbBPReceiptNo.ReadOnly = .ReceiptNoLocked
                Me.stbCBFPReceiptNo.ReadOnly = .ReceiptNoLocked
                Me.stbAccountTranNo.ReadOnly = .TranNoLocked
                Me.stbIncomeNo.ReadOnly = .IncomeNoLocked
                Me.stbRefundNo.ReadOnly = .RefundNoLocked
                Me.stbExpenditureNo.ReadOnly = .ExpenditureNoLocked
                Me.stbInvoiceNo.ReadOnly = .InvoiceNoLocked
                Me.stbBFPInvoiceNo.ReadOnly = .InvoiceNoLocked
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboPayModesID, LookupObjects.PayModes)
            LoadLookupDataCombo(Me.cboBFPPayModesID, LookupObjects.PayModes)
            LoadLookupDataCombo(Me.cboBPPayModesID, LookupObjects.PayModes)
            LoadLookupDataCombo(Me.cboCBFPPayModesID, LookupObjects.PayModes)
            LoadLookupDataCombo(Me.cboBillModesID, LookupObjects.BillModes, False)
            LoadLookupDataCombo(Me.cboBPBillModesID, LookupObjects.BillModes, False)
            LoadLookupDataCombo(Me.cboCBFPBillModesID, LookupObjects.BillModes, False)
            LoadLookupDataCombo(Me.cboAccountActionID, LookupObjects.AccountAction, False)
            LoadLookupDataCombo(Me.cboAccountPayModesID, LookupObjects.PayModes)
            LoadLookupDataCombo(Me.cboOIPayModesID, LookupObjects.PayModes)
            LoadLookupDataCombo(Me.cboCurrenciesID, LookupObjects.Currencies)
            LoadLookupDataCombo(Me.cboBFPCurrenciesID, LookupObjects.Currencies)
            LoadLookupDataCombo(Me.cboBPCurrenciesID, LookupObjects.Currencies)
            LoadLookupDataCombo(Me.cboCBFPCurrenciesID, LookupObjects.Currencies)
            LoadLookupDataCombo(Me.cboAccountCurrenciesID, LookupObjects.Currencies)
            LoadLookupDataCombo(Me.cboAccountGroupID, LookupObjects.AccountGroup, False)
            LoadLookupDataCombo(Me.cboOICurrenciesID, LookupObjects.Currencies)
            LoadLookupDataCombo(Me.cboIncomeSourcesID, LookupObjects.IncomeSources)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboBankID, LookupObjects.BankNamesID)
            LoadLookupDataCombo(Me.cboExpenditureSourceType, LookupObjects.ExpenditureSourceType)
            LoadLookupDataCombo(Me.cboExpenditureCategoryID, LookupObjects.ExpenditureCategory)
            LoadLookupDataCombo(Me.cboCurrency, LookupObjects.Currencies)
          ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ShowPendingRefundRequest()

            If defaultVisitType.Equals(oVisitTypeID.OutPatient) AndAlso Not String.IsNullOrEmpty(defaultVisitNo) Then

                Me.stbVisitNo.Text = FormatText(defaultVisitNo, "Visits", "VisitNo")
                Me.EnableDefaultControls(False)
                Me.ShowCashPaymentHeaderData()

            ElseIf defaultVisitType.Equals(oVisitTypeID.InPatient) AndAlso Not String.IsNullOrEmpty(defaultVisitNo) Then
                Me.tbcCashier.SelectTab(Me.tpgBillFormPayment)
                Me.BringToFront()
                Me.stbBFPVisitNo.Text = FormatText(defaultVisitNo, "Visits", "VisitNo")
                Me.EnableDefaultControls(False)
                Me.ShowBillFormPaymentHeaderData()

            Else : Me.EnableDefaultControls(True)
            End If


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.btnPrint.Enabled = oVariousOptions.AllowProvisionalPrinting

            If oVariousOptions.EnablePayDate Then
                Me.dtpPayDate.Enabled = True
            Else
                Me.dtpPayDate.Checked = True
                Me.dtpPayDate.Value = Today
                Me.dtpPayDate.Enabled = False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ApplySecurity()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowWaitingCashPayments()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If InitOptions.AlertCheckPeriod > 0 Then Me.tmrAlerts.Interval = 1000 * 60 * InitOptions.AlertCheckPeriod
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmCashier_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub frmCashier_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.ShowWaitingCashPayments()
        Me.ShowPendingRefundRequest()
    End Sub

    Private Sub frmCashier_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim message As String
        If Me.dgvPaymentDetails.RowCount = 1 Then
            message = "Current payment detail is not saved. " + ControlChars.NewLine + "Just close anyway?"
        Else : message = "Current payment details are not saved. " + ControlChars.NewLine + "Just close anyway?"
        End If

        If Not Me.CashRecordSaved(True) Then
            Me.tbcCashier.SelectTab(Me.tpgCashPayment.Name)
            If WarningMessage(message) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If
        End If

        If Me.dgvPaymentExtraBillItems.RowCount = 1 Then
            message = "Current bill form payment detail is not saved. " + ControlChars.NewLine + "Just close anyway?"
        Else : message = "Current bill form payment details are not saved. " + ControlChars.NewLine + "Just close anyway?"
        End If

        If Not Me.BillFormRecordSaved(True) Then
            Me.tbcCashier.SelectTab(Me.tpgBillFormPayment.Name)
            If WarningMessage(message) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If
        End If

    End Sub

    Private Sub SetDefaultPrinter()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(InitOptions.CashierPrinterPaperSize) Then
                Me.cashierPrinterPaperSize = GetLookupDataDes(GetLookupDataID(LookupObjects.PrinterPaperSize, InitOptions.CashierPrinterPaperSize))

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub EnableDefaultControls(state As Boolean)

        Me.btnFindVisitNo.Enabled = state
        Me.stbVisitNo.Enabled = state
        Me.btnLoadPendingCashPayment.Enabled = state
        Me.btnWaitingCashPayments.Enabled = state
        Me.btnPayingVisits.Enabled = state
        Me.btnFindByFingerprint.Enabled = state

        Me.btnBFPFindVisitNo.Enabled = state
        Me.stbBFPVisitNo.Enabled = state
        Me.btnLoadPendingBFPayment.Enabled = state
        Me.btnPayingExtraBills.Enabled = state

        Me.cboBPBillModesID.Enabled = state
        Me.cboCBFPBillModesID.Enabled = state
        Me.cboBillModesID.Enabled = state
        Me.cboIncomeSourcesID.Enabled = state
        Me.stbRefundReceiptNo.Enabled = state
        Me.cboExpenditureCategoryID.Enabled = state

    End Sub

    Private Sub stbVisitNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbVisitNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub stbBFPVisitNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbBFPVisitNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub cboBPBillAccountNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBPBillAccountNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub cboCBFPBillAccountNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCBFPBillAccountNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub stbAccountNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAccountNo.KeyDown
        If e.KeyCode = Keys.Enter Then ProcessTabKey(True)
    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.CashRecordSaved(False) Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowCashPaymentHeaderData()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnBFPFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBFPFindVisitNo.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.BillFormRecordSaved(False) Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbBFPVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowBillFormPaymentHeaderData()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnBPFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBPFindVisitNo.Click
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbBPVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)
        Me.stbBPVisitNo.Focus()
    End Sub

    Private Sub btnCBFPFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCBFPFindVisitNo.Click
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbCBFPVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)
        Me.stbCBFPVisitNo.Focus()
    End Sub

    Private Sub SetNextReceiptNo(ByVal sourceControl As TextBox)

        Dim yearL2 As String = Today.Year.ToString().Substring(2)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oPayments As New SyncSoft.SQLDb.Payments()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Payments", "ReceiptNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim nextreceiptNo As String = CStr(oPayments.GetNextReceiptID).PadLeft(paddingLEN, paddingCHAR)

            Dim receiptNo As String = ((receiptNoPrefix + nextreceiptNo).Trim())

            'Dim receiptNo As String = yearL2 + oPayments.GetNextReceiptID.ToString().PadLeft(paddingLEN, paddingCHAR)

            sourceControl.Text = FormatText(receiptNo, "Payments", "ReceiptNo")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetNextInvoiceNo(ByVal sourceControl As TextBox)

        Dim yearL2 As String = Today.Year.ToString().Substring(2)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oInvoices As New SyncSoft.SQLDb.Invoices()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Invoices", "InvoiceNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))
            Dim invoiceNo As String = yearL2 + oInvoices.GetNextInvoiceID.ToString().PadLeft(paddingLEN, paddingCHAR)

            sourceControl.Text = FormatText(invoiceNo, "Invoices", "InvoiceNo")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetNextTranNo(ByVal sourceControl As TextBox)

        Try
            Me.Cursor = Cursors.WaitCursor

            sourceControl.Text = FormatText(GetNextTranNo(), "Accounts", "TranNo")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Alerts "

    Private Function ShowWaitingCashPayments() As Integer

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDate As Date = Today.AddDays(-1)
            Dim endDate As Date = Today


            ' Load from Items

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim waitingNo As Integer = oItems.GetCountPeriodicNotCashPaidItems(startDate, endDate)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblAlertMessage.Text = "Waiting To Pay For Cash Items: " + waitingNo.ToString()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return waitingNo
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub btnWaitingCashPayments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWaitingCashPayments.Click

        Try

            Me.ShowWaitingCashPayments()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.CashRecordSaved(False) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fWaitingCashPayments As New frmWaitingCashPayments(Me.stbVisitNo)
            fWaitingCashPayments.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowCashPaymentHeaderData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub tmrAlerts_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAlerts.Tick

        Try

            Dim period As Long = DateDiff(DateInterval.Minute, alertsStartDateTime, Now)
            If period >= alertCheckPeriod Then If Me.ShowWaitingCashPayments() > 0 Then If InitOptions.AlertSoundOn Then Beep()
            ShowPendingRefundRequest()
        Catch eX As Exception
            Return

        End Try

    End Sub

#End Region

#Region " Fingerprint  "

    Private Sub btnFindByFingerprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindByFingerprint.Click

        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.CashRecordSaved(False) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitFingerprints As DataTable = GetVisitFingerprints()

            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then

                Dim fFingerprintCapture As New FingerprintCapture(CaptureType.Verify, visitFingerprints, "VisitNo")
                fFingerprintCapture.ShowDialog()

                Dim visitNo As String = Me.oCrossMatchTemplate.ID
                If Me.oCrossMatchTemplate.Fingerprint Is Nothing OrElse String.IsNullOrEmpty(visitNo) Then Return

                Me.LoadCashPaymentData(visitNo)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then

                Dim fVerification As New Verification(visitFingerprints, "VisitNo")
                fVerification.ShowDialog()

                If Not String.IsNullOrEmpty(Me.oDigitalPersonaTemplate.ID) Then Me.LoadCashPaymentData(Me.oDigitalPersonaTemplate.ID)

            End If

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

#End Region

    Private Sub btnPayingVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayingVisits.Click

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.CashRecordSaved(False) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPayingVisits As New frmPayingVisits(Me.stbVisitNo)
            fPayingVisits.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowCashPaymentHeaderData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub btnAddExtraBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddExtraBill.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim message As String
            Dim fExtraCharge As frmExtraCharge
            Select Case Me.tbcCashier.SelectedTab.Name

                Case Me.tpgCashPayment.Name

                    Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit Number!"))
                    Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxOutstandingBalance, True)
                    Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbTotalAmountPaid, True)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If outstandingBalance > totalBill Then
                        message = "The system has detected that this patient has outstanding balance." + ControlChars.NewLine +
                            "It’s recommended that you navigate to previous visits for unpaid for item(s) before adding extra charge." +
                            ControlChars.NewLine + "Just continue anyway?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    fExtraCharge = New frmExtraCharge(visitNo)
                    fExtraCharge.ShowDialog()
                    Me.LoadCashPaymentData(visitNo)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

              
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgBillsPayment.Name

                    message = "Would you like to Re-Load Bills Payment Details?"

                    If Me.dgvBillsPayment.RowCount <= 0 Then Return

                    Dim selectedRow As Integer = Me.dgvBillsPayment.CurrentCell.RowIndex
                    Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.dgvBillsPayment.Rows(selectedRow).Cells, Me.colBPVisitNo))

                    fExtraCharge = New frmExtraCharge(visitNo)
                    fExtraCharge.ShowDialog()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
                    Me.LoadBillItems()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnSelfRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelfRequests.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oCurrentPatient As New CurrentPatient()
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String
            If Me.dgvPaymentDetails.RowCount = 1 Then
                message = "Current payment detail is not saved. " + ControlChars.NewLine + "Continue anyway?"
            Else : message = "Current payment details are not saved. " + ControlChars.NewLine + "Continue anyway?"
            End If
            If Not Me.CashRecordSaved(True) Then If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxOutstandingBalance, True)
            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbTotalAmountPaid, True)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If outstandingBalance > totalBill Then
                message = "The system has detected that this patient has outstanding balance." + ControlChars.NewLine +
                    "It’s recommended that you navigate to previous visits for unpaid for item(s) before creating a self request." +
                    ControlChars.NewLine + "Just continue anyway?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelfRequests As New frmSelfRequests(True, patientNo)
            fSelfRequests.Save()
            fSelfRequests.ShowDialog()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(oCurrentPatient.VisitNo) Then Return
            Me.ShowCashPatientDetails(oCurrentPatient.VisitNo)
            Me.LoadCashPaymentData(oCurrentPatient.VisitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oCurrentPatient.PatientNo = String.Empty
            oCurrentPatient.VisitNo = String.Empty
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.btnEdit.Text = UpdateText Then

                Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

                If Me.dgvPaymentDetails.RowCount < 1 Then Throw New ArgumentException("Must have at least one entry for payment details!")

                For Each row As DataGridViewRow In Me.dgvPaymentDetails.Rows

                    If row.IsNewRow Then Exit For

                    StringEnteredIn(row.Cells, Me.colItemCode, "item code!")
                    IntegerEnteredIn(row.Cells, Me.colQuantity, "quantity!")
                    DecimalEnteredIn(row.Cells, Me.colUnitPrice, False, "unit price!")
                    DecimalEnteredIn(row.Cells, Me.colDiscount, True, "discount!")
                    DecimalEnteredIn(row.Cells, Me.colAmount, False, "amount!")
                    StringEnteredIn(row.Cells, Me.colItemStatus, "item status!")
                Next

                Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
                Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

                For rowNo As Integer = 0 To Me.dgvPaymentDetails.RowCount - 1

                    Dim lItems As New List(Of DBConnect)
                    Dim lItemsCASH As New List(Of DBConnect)
                    Dim transactions As New List(Of TransactionList(Of DBConnect))

                    Dim cells As DataGridViewCellCollection = Me.dgvPaymentDetails.Rows(rowNo).Cells
                    Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode)
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity)
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colUnitPrice, False)
                    Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100
                    Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID)

                    Try

                        Using oItems As New SyncSoft.SQLDb.Items()
                            With oItems
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .ItemDetails = StringMayBeEnteredIn(cells, Me.colItemDetails)
                                .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                                .ItemCategoryID = itemCategoryID
                                .ItemStatusID = StringEnteredIn(cells, Me.colItemStatusID)
                                .PayStatusID = oPayStatusID.NotPaid
                                .LoginID = CurrentUser.LoginID
                            End With
                            lItems.Add(oItems)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                            Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                                With oItemsCASH
                                    .VisitNo = visitNo
                                    .ItemCode = itemCode
                                    .ItemCategoryID = itemCategoryID
                                    .CashAmount = cashAmount
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End With
                                lItemsCASH.Add(oItemsCASH)
                            End Using
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(transactions)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Catch ex As Exception
                        ErrorMessage(ex)

                    End Try

                Next

                '''''''''''''''''''''''''''''''''''''''''''
                Me.LoadCashItems(visitNo)
                Me.EnableEditUnitPrice(False)
                '''''''''''''''''''''''''''''''''''''''''''

            Else : Me.EnableEditUnitPrice(True)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnManageAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManageAccounts.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim fManageAccounts As frmManageAccounts

            Select Case Me.tbcCashier.SelectedTab.Name

                Case Me.tpgCashPayment.Name

                    Dim oBillModesID As New LookupDataID.BillModesID()
                    Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

                    fManageAccounts = New frmManageAccounts(oBillModesID.Cash, patientNo)
                    fManageAccounts.ShowDialog()

                    Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
                    If String.IsNullOrEmpty(visitNo) Then Return

                    Me.ShowCashPatientDetails(visitNo)

                Case Me.tpgBillFormPayment.Name

                    Dim oBillModesID As New LookupDataID.BillModesID()
                    Dim patientNo As String = RevertText(StringEnteredIn(Me.stbBFPPatientNo, "Patient No!"))

                    fManageAccounts = New frmManageAccounts(oBillModesID.Cash, patientNo)
                    fManageAccounts.ShowDialog()

                    Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbBFPVisitNo))
                    If String.IsNullOrEmpty(visitNo) Then Return

                    Me.ShowBillFormPatientDetails(visitNo)

                Case Me.tpgBillsPayment.Name

                    Dim billModesID As String = StringValueEnteredIn(Me.cboBPBillModesID, "Account Category!")
                    Dim billNo As String = RevertText(SubstringRight(StringEnteredIn(Me.cboBPBillAccountNo, Me.lblBPBillAccountNo.Text)))

                    fManageAccounts = New frmManageAccounts(billModesID, billNo)
                    fManageAccounts.ShowDialog()

                    If String.IsNullOrEmpty(billModesID) OrElse String.IsNullOrEmpty(billNo) Then Return

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.LoadBillDetails(billModesID, billNo)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgCreditBillFormPayment.Name

                    Dim billModesID As String = StringValueEnteredIn(Me.cboCBFPBillModesID, "Account Category!")
                    Dim billNo As String = RevertText(SubstringRight(StringEnteredIn(Me.cboCBFPBillAccountNo, Me.lblCBFPBillAccountNo.Text)))

                    fManageAccounts = New frmManageAccounts(billModesID, billNo)
                    fManageAccounts.ShowDialog()

                    If String.IsNullOrEmpty(billModesID) OrElse String.IsNullOrEmpty(billNo) Then Return

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.LoadCBFPDetails(billModesID, billNo)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub EnableEditUnitPrice(ByVal state As Boolean)

        Dim editCellStyle As New System.Windows.Forms.DataGridViewCellStyle(Me.colUnitPrice.DefaultCellStyle)

        If state Then
            editCellStyle.BackColor = System.Drawing.SystemColors.Window
            Me.btnEdit.Text = UpdateText
        Else
            editCellStyle.BackColor = System.Drawing.SystemColors.Info
            Me.btnEdit.Text = EditText
        End If

        Me.colUnitPrice.ReadOnly = Not state
        Me.EnableEditControls(Not state)
        Me.colUnitPrice.DefaultCellStyle = editCellStyle

    End Sub

    Private Sub EnableEditControls(ByVal state As Boolean)

        Dim oVariousOptions As New VariousOptions()
        Me.btnSave.Enabled = state

        If state Then
            Me.btnPrint.Enabled = oVariousOptions.AllowProvisionalPrinting
        Else : Me.btnPrint.Enabled = state
        End If

    End Sub

#Region " Cash Payment "

    Private Sub ShowCashPatientDetails(ByVal visitNo As String)

        Dim outstandingBalanceErrorMSG As String = "Navigate patient visits to see offered/done service(s) with pending payment!"
        Dim debitBalanceErrorMSG As String = "Debit balance should be cleared first!"
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.tipOutstandingBalanceWords.RemoveAll()
            Me.tipCashAccountBalanceWords.RemoveAll()

            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            Me.stbPhoneNo.Text = StringMayBeEnteredIn(row, "Phone")
            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbTotalVisits.Text = StringEnteredIn(row, "TotalVisits")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(row, "OutstandingBalance")
            Me.nbxOutstandingBalance.Value = FormatNumber(outstandingBalance, AppData.DecimalPlaces)
            Me.tipOutstandingBalanceWords.SetToolTip(Me.nbxOutstandingBalance, NumberToWords(outstandingBalance))
            Dim cashAccountBalance As Decimal = DecimalMayBeEnteredIn(row, "CashAccountBalance")
            Me.nbxCashAccountBalance.Value = FormatNumber(cashAccountBalance, AppData.DecimalPlaces)
            Me.tipCashAccountBalanceWords.SetToolTip(Me.nbxCashAccountBalance, NumberToWords(cashAccountBalance))
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
            Me.PriorityID = GetLookupDataID(LookupObjects.Priority, StringEnteredIn(row, "PriorityID"))
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            Dim billCustomerName As String = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If outstandingBalance > 0 Then
                ErrProvider.SetError(Me.nbxOutstandingBalance, outstandingBalanceErrorMSG)
            Else : ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)
            End If

            If cashAccountBalance < 0 Then
                ErrProvider.SetError(Me.nbxCashAccountBalance, debitBalanceErrorMSG)
            Else : ErrProvider.SetError(Me.nbxCashAccountBalance, String.Empty)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oVariousOptions.EnablePayDate Then
                Dim visitDate As Date = DateEnteredIn(row, "VisitDate")
                Me.dtpPayDate.Value = visitDate
                Me.dtpPayDate.Checked = GetShortDate(visitDate) >= GetShortDate(Today)

                Me.dtpPayDate.Enabled = True
            Else
                Me.dtpPayDate.Checked = True
                Me.dtpPayDate.Value = Today
                Me.dtpPayDate.Enabled = False
            End If

            Me.btnAddExtraBill.Enabled = True
            Me.btnSelfRequests.Enabled = True
            Me.btnManageAccounts.Enabled = True

            Me.ApplySecurity()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub ResetCashAccountBalanceCTRL(cashAccountBalance As Decimal)

        Try

            If Not cashAccountBalance = DecimalMayBeEnteredIn(Me.nbxCashAccountBalance, True) Then

                Me.nbxCashAccountBalance.Value = FormatNumber(cashAccountBalance, AppData.DecimalPlaces)
                Me.tipCashAccountBalanceWords.SetToolTip(Me.nbxCashAccountBalance, NumberToWords(cashAccountBalance))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Me.chkUseAccountBalance.Checked AndAlso cashAccountBalance <= 0 Then
                    Me.ResetUseAccountBalanceCTRL(cashAccountBalance)
                Else : Me.CalculateCashChange()
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadCashItems(ByVal visitNo As String)

        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oServiceCodes As New LookupDataID.ServiceCodes()
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItems As New SyncSoft.SQLDb.Items()

            Me.dgvPaymentDetails.Rows.Clear()

            Dim cashBillModeID As String = GetLookupDataDes(oBillModesID.Cash)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)

            If billMode.ToUpper().Equals(cashBillModeID.ToUpper()) Then
                items = oItems.GetItems(visitNo, String.Empty, String.Empty, oPayStatusID.NotPaid, cashBillModeID).Tables("Items")
            Else : items = oItems.GetNotPaidItemsCASH(visitNo).Tables("Items")
            End If

            If items Is Nothing OrElse items.Rows.Count < 1 Then
                DisplayMessage("The Visit No: " + FormatText(visitNo, "Visits", "VisitNo") + " has no unpaid for items!")
                Return
            End If

            For rowNo As Integer = 0 To items.Rows.Count - 1

                Dim row As DataRow = items.Rows(rowNo)

                With Me.dgvPaymentDetails

                    .Rows.Add()

                    .Item(Me.colInclude.Name, rowNo).Value = True
                    .Item(Me.colItemCode.Name, rowNo).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colItemName.Name, rowNo).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colInvoiceNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "InvoiceNo")
                    .Item(Me.colCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "ItemCategory")
                    .Item(Me.colQuantity.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Quantity")
                    .Item(Me.colUnitPrice.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "UnitPrice"))
                    .Item(Me.colDiscount.Name, rowNo).Value = FormatNumber(0)
                    .Item(Me.colAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "Amount"))
                    .Item(Me.colCashAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "Amount"))
                    .Item(Me.colItemStatus.Name, rowNo).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colItemCategoryID.Name, rowNo).Value = StringMayBeEnteredIn(row, "ItemCategoryID")
                    .Item(Me.colItemStatusID.Name, rowNo).Value = StringMayBeEnteredIn(row, "ItemStatusID")
                    .Item(Me.colItemDetails.Name, rowNo).Value = StringMayBeEnteredIn(row, "ItemDetails")

                End With

                Me.CalculateCashAmount(rowNo)

            Next

            For Each row As DataGridViewRow In Me.dgvPaymentDetails.Rows
                If row.IsNewRow Then Exit For
             
                If Me.dgvPaymentDetails.Item(Me.colItemCode.Name, row.Index).Value.Equals(oServiceCodes.ServiceFee) Then
                    row.Cells(colInclude.Index).ReadOnly = True
                    row.Cells(colInclude.Index).Style.BackColor = Color.FromKnownColor(KnownColor.MistyRose)
                Else
                    row.Cells(colInclude.Index).ReadOnly = False
                End If
            Next

            Me.CalculateCashTotalBill()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoadPendingCashPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPendingCashPayment.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.CashRecordSaved(False) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPendingItems As New frmPendingItems(Me.stbVisitNo, AlertItemCategory.CashPayment)
            fPendingItems.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowCashPaymentHeaderData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboCurrenciesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCurrenciesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboCurrenciesID, "Currency!")
            If String.IsNullOrEmpty(currenciesID) Then Return

            Me.SetCashCurrencyControls(currenciesID)
            Me.CalculateCashChange()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetCashCurrencyControls(ByVal currenciesID As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim exchangeRate As Decimal = GetExchangeRateBuying(currenciesID)

            If currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                Me.nbxExchangeRate.Value = "1.00"
                Me.nbxExchangeRate.Enabled = False
                Me.btnExchangeRate.Enabled = False



            ElseIf exchangeRate > 0 Then
                If exchangeRate >= 1 Then
                    Me.nbxExchangeRate.Value = FormatNumber(exchangeRate, AppData.DecimalPlaces)

                    Me.nbxExchangeRate.Value = exchangeRate.ToString()

                End If
                Me.nbxExchangeRate.Enabled = False
                Me.btnExchangeRate.Enabled = True


            Else
                Me.nbxExchangeRate.Value = String.Empty
                Me.nbxExchangeRate.Enabled = True
                Me.btnExchangeRate.Enabled = True


            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.btnExchangeRate.Enabled Then Security.Apply(Me.btnExchangeRate, AccessRights.All)
            Me.stbChange.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetExCurrencyControls(ByVal currenciesID As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim exchangeRate As Decimal = GetExchangeRateBuying(currenciesID)

            If currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then


                Me.nbxExchange.Value = "1.00"
                Me.nbxExchange.Enabled = False
                Me.btnExRate.Enabled = False

            ElseIf exchangeRate > 0 Then
                If exchangeRate >= 1 Then
                    Me.nbxExchange.Value = FormatNumber(exchangeRate, AppData.DecimalPlaces)
                Else
                    Me.nbxExchange.Value = exchangeRate.ToString()
                End If


                Me.nbxExchange.Enabled = False
                Me.btnExRate.Enabled = True

            Else


                Me.nbxExchange.Value = String.Empty
                Me.nbxExchange.Enabled = True
                Me.btnExRate.Enabled = True
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If Me.btnExchangeRate.Enabled Then Security.Apply(Me.btnExchangeRate, AccessRights.All)
            'Me.stbChange.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub btnExchangeRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExchangeRate.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim fExchangeRates As New frmExchangeRates()
            fExchangeRates.ShowDialog()

            Me.cboCurrenciesID_SelectedIndexChanged(sender, EventArgs.Empty)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkUseAccountBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseAccountBalance.Click

        Try

            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxCashAccountBalance, True)

            If Me.chkUseAccountBalance.Checked AndAlso accountBalance <= 0 Then
                Me.ResetUseAccountBalanceCTRL(accountBalance)
            Else : Me.CalculateCashAmountTendered()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateCashChange()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub ResetUseAccountBalanceCTRL(accountBalance As Decimal)

        Try

            Dim message As String = "Patient's current balance of " + FormatNumber(accountBalance, AppData.DecimalPlaces) +
                                    " can’t be used to offset this bill"

            Me.chkUseAccountBalance.Checked = False
            Throw New ArgumentException(message)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateCashAmountTendered()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxAmountTendered.Value = String.Empty
            Me.ResetCashCurrencyControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbTotalAmountPaid, True)
            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxCashAccountBalance, True)
            Dim amountTendered As Decimal

            If Me.chkUseAccountBalance.Checked AndAlso accountBalance <= totalBill Then
                amountTendered = totalBill - accountBalance

            ElseIf Me.chkUseAccountBalance.Checked AndAlso accountBalance > totalBill Then
                amountTendered = 0

            Else : amountTendered = totalBill
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxAmountTendered.Value = FormatNumber(amountTendered, AppData.DecimalPlaces)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculateCashChange()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbChange.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbTotalAmountPaid, True)
            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxExchangeRate, False)
            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxCashAccountBalance, True)
            Dim change As Decimal

            If totalBill <= 0 OrElse amountTendered < 0 OrElse exchangeRate <= 0 Then Return

            If Me.chkUseAccountBalance.Checked AndAlso accountBalance <= totalBill Then
                change = amountTendered * exchangeRate - totalBill + accountBalance

            ElseIf Me.chkUseAccountBalance.Checked AndAlso accountBalance > totalBill Then
                change = amountTendered * exchangeRate

            Else : change = amountTendered * exchangeRate - totalBill
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbChange.Text = FormatNumber(change, AppData.DecimalPlaces)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub AmountTenderedChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxAmountTendered.Leave, nbxAmountTendered.TextChanged
        Me.CalculateCashChange()
    End Sub

    Private Sub ExchangeRateChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxExchangeRate.Leave, nbxExchangeRate.TextChanged
        Me.CalculateCashChange()
    End Sub

    Private Sub ResetCashCurrencyControls()

        Try

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Me.cboCurrenciesID.SelectedValue = oCurrenciesID.UgandaShillings

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub stbReceiptNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbReceiptNo.Enter
        Me.SetNextReceiptNo(Me.stbReceiptNo)
    End Sub

    Private Sub stbInvoiceNo_Enter(sender As System.Object, e As System.EventArgs) Handles stbInvoiceNo.Enter
        Me.SetNextInvoiceNo(Me.stbInvoiceNo)
    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.CashRecordSaved(False) AndAlso Not String.IsNullOrEmpty(currentCashVisitNo) Then
                Me.stbVisitNo.Text = currentCashVisitNo
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowCashPaymentHeaderData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)
            ResetControlsIn(Me.pnlNavigateVisits)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged
        Me.ClearCashPaymentControls()
    End Sub

    Private Sub stbVisitNo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.Enter

        Try
            currentCashAllSaved = Me.CashRecordSaved(False)
            If Not currentCashAllSaved Then
                currentCashVisitNo = StringMayBeEnteredIn(Me.stbVisitNo)
                ProcessTabKey(True)
            Else : currentCashVisitNo = String.Empty
            End If

        Catch ex As Exception
            currentCashVisitNo = String.Empty
        End Try

    End Sub

    Private Sub ShowCashPaymentHeaderData()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearCashPaymentControls()
            ResetControlsIn(Me.pnlNavigateVisits)

            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Me.LoadCashPaymentData(visitNo)
            Me.CalculateCashChange()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub LoadCashPaymentData(ByVal visitNo As String)

        Try

            Me.ShowCashPatientDetails(visitNo)
            Me.SetNextReceiptNo(Me.stbReceiptNo)
            Me.SetNextInvoiceNo(Me.stbInvoiceNo)
            Me.LoadCashItems(visitNo)

            Me.ApplySecurity()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub ClearCashPaymentControls()

        Me.stbFullName.Clear()
        Me.stbPatientNo.Clear()
        Me.stbVisitDate.Clear()
        Me.stbTotalVisits.Clear()
        Me.nbxOutstandingBalance.Value = String.Empty
        Me.tipOutstandingBalanceWords.RemoveAll()
        Me.nbxCashAccountBalance.Value = String.Empty
        ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)
        ErrProvider.SetError(Me.nbxCashAccountBalance, String.Empty)
        Me.tipCashAccountBalanceWords.RemoveAll()
        Me.stbBillMode.Clear()
        Me.stbCoPayType.Clear()
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        Me.stbReceiptNo.Clear()
        Me.dtpPayDate.Value = Today
        Me.dtpPayDate.Checked = False
        Me.stbDocumentNo.Clear()
        Me.stbNotes.Clear()
        Me.stbTotalAmountPaid.Clear()
        Me.stbAmountWords.Clear()
        Me.stbBillCustomerName.Clear()
        Me.nbxAmountTendered.Value = String.Empty
        Me.chkUseAccountBalance.Checked = False
        Me.chkSendBalanceToAccount.Checked = False
        Me.btnAddExtraBill.Enabled = False
        Me.btnManageAccounts.Enabled = False
        Me.dgvPaymentDetails.Rows.Clear()
        Me.EnableEditUnitPrice(False)
        Me.ResetCashCurrencyControls()

    End Sub

    Private Sub dgvPaymentDetails_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPaymentDetails.CellEndEdit

        If e.ColumnIndex.Equals(Me.colQuantity.Index) OrElse
            e.ColumnIndex.Equals(Me.colUnitPrice.Index) OrElse
            e.ColumnIndex.Equals(Me.colDiscount.Index) Then
            Me.CalculateCashAmount(e.RowIndex)
            Me.CalculateCashTotalBill()

        ElseIf e.ColumnIndex.Equals(Me.colInclude.Index) Then
            Me.CalculateCashTotalBill()
        End If

    End Sub

    Private Sub CalculateCashAmount(ByVal rowNo As Integer)

        Try

            Dim cells As DataGridViewCellCollection = Me.dgvPaymentDetails.Rows(rowNo).Cells

            Dim cashAmount As Decimal = DecimalMayBeEnteredIn(cells, Me.colCashAmount)
            Dim discount As Decimal = DecimalMayBeEnteredIn(cells, Me.colDiscount)

            Me.dgvPaymentDetails.Item(Me.colAmount.Name, rowNo).Value = FormatNumber(cashAmount - discount)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculateCashTotalBill()

        Dim totalBill As Decimal

        Me.stbTotalAmountPaid.Clear()
        Me.nbxAmountTendered.Value = String.Empty
        Me.chkUseAccountBalance.Checked = False
        Me.chkSendBalanceToAccount.Checked = False
        Me.ResetCashCurrencyControls()

        For rowNo As Integer = 0 To Me.dgvPaymentDetails.RowCount - 1
            If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, rowNo).Value) = True Then
                Dim cells As DataGridViewCellCollection = Me.dgvPaymentDetails.Rows(rowNo).Cells
                Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colAmount)
                totalBill += amount
            End If
        Next

        Me.stbTotalAmountPaid.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbAmountWords.Text = NumberToWords(totalBill)
        Me.nbxAmountTendered.Value = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.CalculateCashChange()

    End Sub

    Private Function CashRecordSaved(ByVal hideMessage As Boolean) As Boolean

        Try
            Dim message As String

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPaymentDetails.RowCount >= 1 Then
                If Me.dgvPaymentDetails.RowCount = 1 Then
                    message = "Please ensure that current payment detail is saved!"
                Else : message = "Please ensure that current payment details are saved!"
                End If
                If Not hideMessage Then DisplayMessage(message)
                Me.btnSave.Focus()
                Me.BringToFront()
                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                Return False
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True

        Catch ex As Exception
            Return True

        End Try

    End Function

#End Region

#Region " Bill Form Payment "

    Private Sub ShowBillFormPatientDetails(ByVal visitNo As String)

        Dim outstandingBalanceErrorMSG As String = "Navigate patient visits to see offered/done service(s) with pending payment!"
        Dim debitBalanceErrorMSG As String = "Debit balance should be cleared first!"
        Dim oVisits As New SyncSoft.SQLDb.Visits()


        Try

            Me.tipBFPOutstandingBalanceWords.RemoveAll()
            Me.tipBFPCashAccountBalanceWords.RemoveAll()

            Dim visits As DataTable = oVisits.GetAdmissionsDetails(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbBFPVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Me.stbBFPFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbBFPPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            Me.stbBFPVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbBFPPhoneNo.Text = StringMayBeEnteredIn(row, "Phone")
            Me.stbBFPBillMode.Text = StringEnteredIn(row, "BillMode")
            Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(row, "OutstandingBalance")
            Me.nbxBFPOutstandingBalance.Value = FormatNumber(outstandingBalance, AppData.DecimalPlaces)
            Me.tipBFPOutstandingBalanceWords.SetToolTip(Me.nbxBFPOutstandingBalance, NumberToWords(outstandingBalance))
            Dim cashAccountBalance As Decimal = DecimalMayBeEnteredIn(row, "CashAccountBalance")
            Me.nbxBFPCashAccountBalance.Value = FormatNumber(cashAccountBalance, AppData.DecimalPlaces)
            Me.tipBFPCashAccountBalanceWords.SetToolTip(Me.nbxBFPCashAccountBalance, NumberToWords(cashAccountBalance))
            Me.stbBFPCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.nbxBFPCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxBFPCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipBFPCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))

            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            Dim billCustomerName As String = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBFPCustomerName.Text = billCustomerName

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If outstandingBalance > 0 Then
                ErrProvider.SetError(Me.nbxBFPOutstandingBalance, outstandingBalanceErrorMSG)
            Else : ErrProvider.SetError(Me.nbxBFPOutstandingBalance, String.Empty)
            End If

            If cashAccountBalance < 0 Then
                ErrProvider.SetError(Me.nbxBFPCashAccountBalance, debitBalanceErrorMSG)
            Else : ErrProvider.SetError(Me.nbxBFPCashAccountBalance, String.Empty)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpBFPPayDate.Value = Today
            Me.dtpBFPPayDate.Checked = True
            Me.btnAddExtraBill.Enabled = True
            Me.btnManageAccounts.Enabled = True

            Me.ApplySecurity()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub ResetBFPCashAccountBalanceCTRL(cashAccountBalance As Decimal)

        Try

            If Not cashAccountBalance = DecimalMayBeEnteredIn(Me.nbxBFPCashAccountBalance, True) Then

                Me.nbxBFPCashAccountBalance.Value = FormatNumber(cashAccountBalance, AppData.DecimalPlaces)
                Me.tipBFPCashAccountBalanceWords.SetToolTip(Me.nbxBFPCashAccountBalance, NumberToWords(cashAccountBalance))

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Me.chkBFPUseAccountBalance.Checked AndAlso cashAccountBalance <= 0 Then
                    Me.ResetBFPUseAccountBalanceCTRL(cashAccountBalance)
                Else : Me.CalculateBillFormChange()
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadBillFormItems(ByVal visitNo As String)

        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

            Me.dgvPaymentExtraBillItems.Rows.Clear()

            Dim cashAccount As String = GetLookupDataDes(oBillModesID.Cash)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBFPBillMode)

            If billMode.ToUpper().Equals(cashAccount.ToUpper()) Then
                extraBillItems = oExtraBillItems.GetExtraBillItems(visitNo, oPayStatusID.NotPaid, cashAccount).Tables("ExtraBillItems")
            Else : extraBillItems = oExtraBillItems.GetNotPaidExtraBillItemsCASH(visitNo).Tables("ExtraBillItems")
            End If

            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then
                DisplayMessage("The Visit No: " + FormatText(visitNo, "Visits", "VisitNo") + " has no unpaid for bill form items!")
                Return
            End If

            For rowNo As Integer = 0 To extraBillItems.Rows.Count - 1

                Dim row As DataRow = extraBillItems.Rows(rowNo)

                With Me.dgvPaymentExtraBillItems

                    .Rows.Add()
                    '
                    .Item(Me.colBFPInclude.Name, rowNo).Value = True
                    .Item(Me.colBFPItemCode.Name, rowNo).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colBFPExtraBillNo.Name, rowNo).Value = StringEnteredIn(row, "ExtraBillNo")
                    .Item(Me.colBFPExtraBillDate.Name, rowNo).Value = FormatDate(DateEnteredIn(row, "ExtraBillDate"))
                    .Item(Me.colBFPItemName.Name, rowNo).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colBFPInvoiceNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "InvoiceNo")
                    .Item(Me.colBFPCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "ItemCategory")
                    .Item(Me.colBFPQuantity.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Quantity")
                    .Item(Me.colBFPUnitPrice.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "UnitPrice"))
                    .Item(Me.colBFPDiscount.Name, rowNo).Value = FormatNumber(0)
                    .Item(Me.colBFPAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "Amount"))
                    .Item(Me.colBFPCashAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "Amount"))
                    .Item(Me.colBFPRoundNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "RoundNo")
                    .Item(Me.colBFPEntryMode.Name, rowNo).Value = StringMayBeEnteredIn(row, "EntryMode")
                    .Item(Me.colBFPItemCategoryID.Name, rowNo).Value = StringMayBeEnteredIn(row, "ItemCategoryID")


                End With

                Me.CalculateBillFormAmount(rowNo)

            Next

            Me.CalculateBillFormTotalBill()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadPendingBillItems(ByVal visitNo As String)

        ' Dim oPayStatusID As New LookupDataID.PayStatusID()
        ' Dim oBillModesID As New LookupDataID.BillModesID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPendingBillItems As New SyncSoft.SQLDb.PendingBillItems

            Me.dgvPendingBillItems.Rows.Clear()

            Dim patientNo As String = StringEnteredIn(Me.stbBFPPatientNo)

            ipdItems = oPendingBillItems.GetNotPaidNotDoneOrOfferedPendingBillItems(visitNo).Tables("NotPaidNotDoneOrOfferedPendingBillItems")

          
            For rowNo As Integer = 0 To ipdItems.Rows.Count - 1

                Dim row As DataRow = ipdItems.Rows(rowNo)

                With Me.dgvPendingBillItems

                    .Rows.Add()
                   
                    .Item(Me.colPendingBillItemsInclude.Name, rowNo).Value = True
                    .Item(Me.colPendingBillItemsRoundNo.Name, rowNo).Value = StringEnteredIn(row, "RoundNo")
                    .Item(Me.ColExtraBillNo.Name, rowNo).Value = GetNextExtraBillNo(visitNo, patientNo)
                    .Item(Me.colPendingBillItemsRoundDateTime.Name, rowNo).Value = StringEnteredIn(row, "RoundDateTime")
                    .Item(Me.colPendingBillItemsItemName.Name, rowNo).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colPendingBillItemsItemCode.Name, rowNo).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colPendingBillItemsCategoryID.Name, rowNo).Value = StringMayBeEnteredIn(row, "ItemCategoryID")
                    .Item(Me.colPendingBillItemsCategory.Name, rowNo).Value = StringEnteredIn(row, "ItemCategory")
                    .Item(Me.colPendingBillItemsQuantity.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "Quantity"))
                    .Item(Me.colPendingBillItemsUnitPrice.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "UnitPrice"))
                    .Item(Me.colPendingBillItemsDiscount.Name, rowNo).Value = FormatNumber(0)
                    .Item(Me.colPendingBillItemsAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "Amount"))
                    .Item(Me.colPendingBillItemsPayStatus.Name, rowNo).Value = StringMayBeEnteredIn(row, "PayStatus")
                    .Item(Me.colPendingBillItemsItemStatus.Name, rowNo).Value = StringMayBeEnteredIn(row, "ItemStatus")

                End With

                Me.CalculatePendingBillAmount(rowNo)

            Next

            Me.CalculateBillFormTotalBill()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoadPendingBFPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPendingBFPayment.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.BillFormRecordSaved(False) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fInWardAdmissions As New frmInWardAdmissions(Me.stbBFPVisitNo, AutoNumber.VisitNo)
            fInWardAdmissions.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowBillFormPaymentHeaderData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnPayingExtraBills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayingExtraBills.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.BillFormRecordSaved(False) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicExtraBillItems As New frmPeriodicExtraBillItems(Me.stbBFPVisitNo)
            fPeriodicExtraBillItems.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowBillFormPaymentHeaderData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboBFPCurrenciesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBFPCurrenciesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboBFPCurrenciesID, "Currency!")
            If String.IsNullOrEmpty(currenciesID) Then Return

            Me.SetBillFormCurrencyControls(currenciesID)
            Me.CalculateBillFormChange()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetBillFormCurrencyControls(ByVal currenciesID As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim exchangeRate As Decimal = GetExchangeRateBuying(currenciesID)

            If currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                Me.nbxBFPExchangeRate.Value = "1.00"
                Me.nbxBFPExchangeRate.Enabled = False
                Me.btnBFPExchangeRate.Enabled = False

            ElseIf exchangeRate > 0 Then
                If exchangeRate >= 1 Then
                    Me.nbxBFPExchangeRate.Value = FormatNumber(exchangeRate, AppData.DecimalPlaces)
                Else : Me.nbxBFPExchangeRate.Value = exchangeRate.ToString()
                End If
                Me.nbxBFPExchangeRate.Enabled = False
                Me.btnBFPExchangeRate.Enabled = True

            Else
                Me.nbxBFPExchangeRate.Value = String.Empty
                Me.nbxBFPExchangeRate.Enabled = True
                Me.btnBFPExchangeRate.Enabled = True
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.btnBFPExchangeRate.Enabled Then Security.Apply(Me.btnBFPExchangeRate, AccessRights.All)
            Me.stbBFPChange.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnBFPExchangeRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBFPExchangeRate.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim fExchangeRates As New frmExchangeRates()
            fExchangeRates.ShowDialog()

            Me.cboBFPCurrenciesID_SelectedIndexChanged(sender, EventArgs.Empty)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkBFPUseAccountBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBFPUseAccountBalance.Click

        Try

            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxBFPCashAccountBalance, True)

            If Me.chkBFPUseAccountBalance.Checked AndAlso accountBalance <= 0 Then
                Me.ResetBFPUseAccountBalanceCTRL(accountBalance)
            Else : Me.CalculateBillFormAmountTendered()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillFormChange()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub ResetBFPUseAccountBalanceCTRL(accountBalance As Decimal)

        Try

            Dim message As String = "Patient's current balance of " + FormatNumber(accountBalance, AppData.DecimalPlaces) +
                                  " can’t be used to offset this bill"

            Me.chkBFPUseAccountBalance.Checked = False
            Throw New ArgumentException(message)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillFormAmountTendered()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxBFPAmountTendered.Value = String.Empty
            Me.ResetBillFormCurrencyControls()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbBFPTotalAmountPaid, True)
            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxBFPCashAccountBalance, True)
            Dim amountTendered As Decimal

            If Me.chkBFPUseAccountBalance.Checked AndAlso accountBalance <= totalBill Then
                amountTendered = totalBill - accountBalance

            ElseIf Me.chkBFPUseAccountBalance.Checked AndAlso accountBalance > totalBill Then
                amountTendered = 0

            Else : amountTendered = totalBill
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxBFPAmountTendered.Value = FormatNumber(amountTendered, AppData.DecimalPlaces)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculateBillFormChange()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbBFPChange.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbBFPTotalAmountPaid, True)
            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxBFPAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxBFPExchangeRate, False)
            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxBFPCashAccountBalance, True)
            Dim change As Decimal

            If totalBill <= 0 OrElse amountTendered < 0 OrElse exchangeRate <= 0 Then Return

            If Me.chkBFPUseAccountBalance.Checked AndAlso accountBalance <= totalBill Then
                change = amountTendered * exchangeRate - totalBill + accountBalance

            ElseIf Me.chkBFPUseAccountBalance.Checked AndAlso accountBalance > totalBill Then
                change = amountTendered * exchangeRate

            Else : change = amountTendered * exchangeRate - totalBill
            End If

            Me.stbBFPChange.Text = FormatNumber(change, AppData.DecimalPlaces)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub BFPAmountTenderedChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxBFPAmountTendered.Leave, nbxBFPAmountTendered.TextChanged
        Me.CalculateBillFormChange()
    End Sub

    Private Sub BFPExchangeRateChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxBFPExchangeRate.Leave, nbxBFPExchangeRate.TextChanged
        Me.CalculateBillFormChange()
    End Sub

    Private Sub ResetBillFormCurrencyControls()

        Try

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Me.cboBFPCurrenciesID.SelectedValue = oCurrenciesID.UgandaShillings

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub stbBFPReceiptNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbBFPReceiptNo.Enter
        Me.SetNextReceiptNo(Me.stbBFPReceiptNo)
    End Sub

    Private Sub stbBFPVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbBFPVisitNo.Leave

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.BillFormRecordSaved(False) AndAlso Not String.IsNullOrEmpty(currentBillFormVisitNo) Then
                Me.stbBFPVisitNo.Text = currentBillFormVisitNo
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowBillFormPaymentHeaderData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)
            ResetControlsIn(Me.pnlNavigateVisits)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbBFPVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbBFPVisitNo.TextChanged
        Me.ClearBillFormPaymentControls()
    End Sub

    Private Sub stbBFPVisitNo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbBFPVisitNo.Enter

        Try
            currentBillFormAllSaved = Me.BillFormRecordSaved(False)
            If Not currentBillFormAllSaved Then
                currentBillFormVisitNo = StringMayBeEnteredIn(Me.stbBFPVisitNo)
                ProcessTabKey(True)
            Else : currentBillFormVisitNo = String.Empty
            End If

        Catch ex As Exception
            currentBillFormVisitNo = String.Empty
        End Try

    End Sub

    Private Sub stbBFPInvoiceNo_Enter(sender As System.Object, e As System.EventArgs) Handles stbBFPInvoiceNo.Enter
        Me.SetNextInvoiceNo(Me.stbBFPInvoiceNo)
    End Sub

    Private Sub ShowBillFormPaymentHeaderData()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearBillFormPaymentControls()
            ResetControlsIn(Me.pnlNavigateVisits)

            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbBFPVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Me.LoadBillFormPaymentData(visitNo)
            Me.CalculateBillFormChange()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub LoadBillFormPaymentData(ByVal visitNo As String)

        Try
            Me.ShowBillFormPatientDetails(visitNo)
            Me.SetNextReceiptNo(Me.stbBFPReceiptNo)
            Me.LoadBillFormItems(visitNo)
            Me.LoadPendingBillItems(visitNo)
            Me.SetNextInvoiceNo(Me.stbBFPInvoiceNo)
            Me.ApplySecurity()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub ClearBillFormPaymentControls()

        Me.stbBFPFullName.Clear()
        Me.stbBFPPatientNo.Clear()
        Me.stbBFPVisitDate.Clear()
        Me.nbxBFPOutstandingBalance.Value = String.Empty
        Me.nbxBFPCashAccountBalance.Value = String.Empty
        Me.tipBFPOutstandingBalanceWords.RemoveAll()
        Me.tipBFPCashAccountBalanceWords.RemoveAll()
        ErrProvider.SetError(Me.nbxBFPOutstandingBalance, String.Empty)
        ErrProvider.SetError(Me.nbxBFPCashAccountBalance, String.Empty)
        Me.stbBFPBillMode.Clear()
        Me.stbBFPCoPayType.Clear()
        Me.nbxBFPCoPayPercent.Value = String.Empty
        Me.nbxBFPCoPayValue.Value = String.Empty
        Me.tipBFPCoPayValueWords.RemoveAll()
        Me.stbBFPReceiptNo.Clear()
        Me.dtpBFPPayDate.Value = Today
        Me.dtpBFPPayDate.Checked = True
        Me.stbBFPDocumentNo.Clear()
        Me.stbBFPNotes.Clear()
        Me.stbBFPTotalAmountPaid.Clear()
        Me.stbBFPAmountWords.Clear()
        Me.stbBFPCustomerName.Clear()
        Me.nbxBFPAmountTendered.Value = String.Empty
        Me.chkBFPUseAccountBalance.Checked = False
        Me.chkBFPSendBalanceToAccount.Checked = False

        Me.btnAddExtraBill.Enabled = False
        Me.btnManageAccounts.Enabled = False
        Me.dgvPaymentExtraBillItems.Rows.Clear()
        Me.ResetBillFormCurrencyControls()

    End Sub

    Private Sub dgvPaymentExtraBillItems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPaymentExtraBillItems.CellEndEdit

        If e.ColumnIndex.Equals(Me.colBFPQuantity.Index) OrElse
            e.ColumnIndex.Equals(Me.colBFPUnitPrice.Index) OrElse
            e.ColumnIndex.Equals(Me.colBFPDiscount.Index) Then
            Me.CalculateBillFormAmount(e.RowIndex)
            Me.CalculateBillFormTotalBill()

        ElseIf e.ColumnIndex.Equals(Me.colBFPInclude.Index) Then
            Me.CalculateBillFormTotalBill()

        End If

    End Sub

    Private Sub CalculateBillFormAmount(ByVal rowNo As Integer)

        Try

            Dim cells As DataGridViewCellCollection = Me.dgvPaymentExtraBillItems.Rows(rowNo).Cells

            Dim cashAmount As Decimal = DecimalMayBeEnteredIn(cells, Me.colBFPCashAmount)
            Dim discount As Decimal = DecimalMayBeEnteredIn(cells, Me.colBFPDiscount)

            Me.dgvPaymentExtraBillItems.Item(Me.colBFPAmount.Name, rowNo).Value = FormatNumber(cashAmount - discount)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculatePendingBillAmount(ByVal rowNo As Integer)

        Try

            Dim cells As DataGridViewCellCollection = Me.dgvPendingBillItems.Rows(rowNo).Cells

            Dim cashAmount As Decimal = DecimalMayBeEnteredIn(cells, Me.colPendingBillItemsAmount)
            Dim discount As Decimal = DecimalMayBeEnteredIn(cells, Me.colPendingBillItemsDiscount)

            Me.dgvPendingBillItems.Item(Me.colPendingBillItemsAmount.Name, rowNo).Value = FormatNumber(cashAmount - discount)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculateBillFormTotalBill()

        Dim totalBill As Decimal

        Me.stbBFPTotalAmountPaid.Clear()
        Me.nbxBFPAmountTendered.Value = String.Empty
        Me.chkBFPUseAccountBalance.Checked = False
        Me.chkBFPSendBalanceToAccount.Checked = False
        Me.ResetBillFormCurrencyControls()

        Select Case Me.tbcBillFormPayment.SelectedTab.Name

            Case Me.tpgBillingForm.Name

                For rowNo As Integer = 0 To Me.dgvPaymentExtraBillItems.RowCount - 1
                    If CBool(Me.dgvPaymentExtraBillItems.Item(Me.colBFPInclude.Name, rowNo).Value) = True Then
                        Dim cells As DataGridViewCellCollection = Me.dgvPaymentExtraBillItems.Rows(rowNo).Cells
                        Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colBFPAmount)
                        totalBill += amount
                    End If
                Next

            Case Me.tpgPendingBill.Name

                For rowNo As Integer = 0 To Me.dgvPendingBillItems.RowCount - 1
                    If CBool(Me.dgvPendingBillItems.Item(Me.colPendingBillItemsInclude.Name, rowNo).Value) = True Then
                        Dim cells As DataGridViewCellCollection = Me.dgvPendingBillItems.Rows(rowNo).Cells
                        Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colPendingBillItemsAmount)
                        totalBill += amount

                    End If

                Next

        End Select
        Me.stbBFPTotalAmountPaid.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBFPAmountWords.Text = NumberToWords(totalBill)
        Me.nbxBFPAmountTendered.Value = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.CalculateBillFormChange()

    End Sub

    Private Function BillFormRecordSaved(ByVal hideMessage As Boolean) As Boolean

        Try
            Dim message As String

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPaymentExtraBillItems.RowCount >= 1 Then
                If Me.dgvPaymentExtraBillItems.RowCount = 1 Then
                    message = "Please ensure that current bill form payment is saved!"
                Else : message = "Please ensure that current bill form payments are saved!"
                End If
                If Not hideMessage Then DisplayMessage(message)
                Me.btnSave.Focus()
                Me.BringToFront()
                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                Return False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True

        Catch ex As Exception
            Return True

        End Try

    End Function

#End Region

#Region " Bills Payment "

    Private Sub ResetBPAccountBalanceCTRL(accountBalance As Decimal)

        Try

            If Not accountBalance = DecimalMayBeEnteredIn(Me.stbBPAccountBalance, True) Then

                Me.stbBPAccountBalance.Text = FormatNumber(accountBalance, AppData.DecimalPlaces)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Me.chkBPUseAccountBalance.Checked AndAlso accountBalance <= 0 Then
                    Me.ResetBPUseAccountBalanceCTRL(accountBalance)
                Else : Me.CalculateBillsChange()
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadBillItems()

        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim message As String = "Unknown Error Occured!"
            Dim cashAccount As String = GetLookupDataDes(oBillModesID.Cash)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim billModesID As String = StringValueEnteredIn(Me.cboBPBillModesID, "Account Category!")
            Dim billNo As String = RevertText(SubstringRight(StringEnteredIn(Me.cboBPBillAccountNo, "To-Bill Number!")))
            Dim companyNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboBPCompanyNo)))
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbBPVisitNo))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dgvBillsPayment.Rows.Clear()
            Me.lblBPRecordsNo.Text = String.Empty
            Me.fbnExportTo.Enabled = False
            Me.btnSave.Enabled = False
            Me.btnAddExtraBill.Enabled = False
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If billModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) Then Throw New ArgumentException("Invalid Account Category (CASH)!")
            If billNo.ToUpper().Equals(cashAccount.ToUpper()) Then Throw New ArgumentException("Invalid entry (CASH) for an account!")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case True

                Case Me.rdoBPGetPeriod.Checked

                    Dim startDate As Date = DateEnteredIn(Me.dtpBPStartDate, "Start Date")
                    Dim endDate As Date = DateEnteredIn(Me.dtpBPEndDate, "End Date")

                    If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

                    If chkExcludeNotInvoicedItem.Checked Then

                        items = oItems.GetInvoicedNotPaidItems(billModesID, billNo, startDate, endDate, companyNo).Tables("Items")
                    Else
                        items = oItems.GetNotPaidItems(billModesID, billNo, startDate, endDate, companyNo).Tables("Items")
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If billModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) Then
                        If String.IsNullOrEmpty(companyNo) Then
                            message = "The Account No: " + FormatText(billNo, "BillCustomers", "AccountNo") + " has no unpaid for items for period between " +
                                FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
                        Else : message = "The Company with Account No: " + FormatText(companyNo, "BillCustomers", "AccountNo") +
                                     " under Insurance with Account No: " + FormatText(billNo, "BillCustomers", "AccountNo") +
                                     " has no unpaid for items for period between " + FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
                        End If

                    ElseIf billModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then
                        If String.IsNullOrEmpty(companyNo) Then
                            message = "The Insurance No: " + FormatText(billNo, "Insurances", "InsuranceNo") + " has no unpaid for items for period between " +
                                FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
                        Else : message = "The Company No: " + FormatText(companyNo, "Companies", "CompanyNo") + " under Insurance No: " +
                            FormatText(billNo, "Insurances", "InsuranceNo") + " has no unpaid for items for period between " +
                            FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
                        End If

                    End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.rdoBPGetAll.Checked

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    message = "This action may take awhile to complete if you have many " + Me.stbBPBillCustomerName.Text +
                        " un paid for items. " + ControlChars.NewLine + "Are you sure you want to load all?"

                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    items = oItems.GetNotPaidItems(billModesID, billNo, companyNo).Tables("Items")



                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If billModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) Then

                        If String.IsNullOrEmpty(companyNo) Then
                            message = "The Account No: " + FormatText(billNo, "BillCustomers", "AccountNo") + " has no unpaid for items for all period!"
                        Else : message = "The Company with Account No: " + FormatText(companyNo, "BillCustomers", "AccountNo") +
                            " under Insurance with Account No: " + FormatText(billNo, "BillCustomers", "AccountNo") + " has no unpaid for items for all period!"
                        End If

                    ElseIf billModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then
                        If String.IsNullOrEmpty(companyNo) Then
                            message = "The Insurance No: " + FormatText(billNo, "Insurances", "InsuranceNo") + " has no unpaid for items for all period!"
                        Else : message = "The Company No: " + FormatText(companyNo, "Companies", "CompanyNo") + " under Insurance No: " +
                            FormatText(billNo, "Insurances", "InsuranceNo") + " has no unpaid for items for all period!"
                        End If
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If items Is Nothing OrElse items.Rows.Count < 1 Then Throw New ArgumentException(message)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If String.IsNullOrEmpty(visitNo) Then

                For rowNo As Integer = 0 To items.Rows.Count - 1

                    Dim row As DataRow = items.Rows(rowNo)

                    With Me.dgvBillsPayment

                        .Rows.Add()

                        .Item(Me.colBPInclude.Name, rowNo).Value = True
                        .Item(Me.colBPVisitNo.Name, rowNo).Value = FormatText(StringEnteredIn(row, "VisitNo"), "Visits", "VisitNo")
                        .Item(Me.colBPInvoiceNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "InvoiceNo")
                        .Item(Me.colBPVisitDate.Name, rowNo).Value = FormatDate(DateEnteredIn(row, "VisitDate"))
                        .Item(Me.colBPPatientNo.Name, rowNo).Value = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
                        .Item(Me.colBPFullName.Name, rowNo).Value = StringEnteredIn(row, "FullName")
                        .Item(Me.colBPItemCode.Name, rowNo).Value = StringEnteredIn(row, "ItemCode")
                        .Item(Me.colBPItemName.Name, rowNo).Value = StringEnteredIn(row, "ItemName")
                        .Item(Me.colBPCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "ItemCategory")
                        .Item(Me.colBPQuantity.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Quantity")
                        .Item(Me.colBPUnitPrice.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "UnitPrice"))
                        .Item(Me.colBPDiscount.Name, rowNo).Value = FormatNumber(0)
                        .Item(Me.colBPBillPrice.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "BillPrice"))
                        .Item(Me.colBPInvoiceAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "InvoiceAmount"))
                        .Item(Me.colBPItemStatus.Name, rowNo).Value = StringEnteredIn(row, "ItemStatus")
                        .Item(Me.colBPMemberCardNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "MemberCardNo")
                        .Item(Me.colBPBillCustomerName.Name, rowNo).Value = StringMayBeEnteredIn(row, "BillCustomerName")
                        .Item(Me.colBPCoPayType.Name, rowNo).Value = StringMayBeEnteredIn(row, "CoPayType")
                        .Item(Me.colBPCoPayPercent.Name, rowNo).Value = SingleMayBeEnteredIn(row, "CoPayPercent")
                        .Item(Me.colBPCoPayValue.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"))
                        .Item(Me.colBPItemCategoryID.Name, rowNo).Value = StringEnteredIn(row, "ItemCategoryID")

                    End With

                    Me.CalculateBillAmount(rowNo)

                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.lblBPRecordsNo.Text = " Returned Record(s): " + items.Rows.Count.ToString()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else

                Dim visitItems As EnumerableRowCollection(Of DataRow) = (From data In items.AsEnumerable() Where
                        data.Field(Of String)("VisitNo").ToUpper().Equals(FormatText(visitNo, "Visits", "VisitNo").ToUpper()) Or
                        data.Field(Of String)("VisitNo").ToUpper().Equals(visitNo.ToUpper()) Select data)

                For rowNo As Integer = 0 To visitItems.Count - 1

                    Dim row As DataRow = visitItems.ElementAt(rowNo)

                    With Me.dgvBillsPayment

                        .Rows.Add()

                        .Item(Me.colBPInclude.Name, rowNo).Value = True
                        .Item(Me.colBPVisitNo.Name, rowNo).Value = FormatText(StringEnteredIn(row, "VisitNo"), "Visits", "VisitNo")
                        .Item(Me.colBPVisitDate.Name, rowNo).Value = FormatDate(DateEnteredIn(row, "VisitDate"))
                        .Item(Me.colBPPatientNo.Name, rowNo).Value = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
                        .Item(Me.colBPInvoiceNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "InvoiceNo")
                        .Item(Me.colBPFullName.Name, rowNo).Value = StringEnteredIn(row, "FullName")
                        .Item(Me.colBPItemCode.Name, rowNo).Value = StringEnteredIn(row, "ItemCode")
                        .Item(Me.colBPItemName.Name, rowNo).Value = StringEnteredIn(row, "ItemName")
                        .Item(Me.colBPCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "ItemCategory")
                        .Item(Me.colBPQuantity.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Quantity")
                        .Item(Me.colBPUnitPrice.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "UnitPrice"))
                        .Item(Me.colBPBillPrice.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "BillPrice"))
                        .Item(Me.colBPDiscount.Name, rowNo).Value = FormatNumber(0)
                        .Item(Me.colBPInvoiceAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "InvoiceAmount"))
                        .Item(Me.colBPItemStatus.Name, rowNo).Value = StringEnteredIn(row, "ItemStatus")
                        .Item(Me.colBPMemberCardNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "MemberCardNo")
                        .Item(Me.colBPBillCustomerName.Name, rowNo).Value = StringMayBeEnteredIn(row, "BillCustomerName")
                        .Item(Me.colBPCoPayType.Name, rowNo).Value = StringMayBeEnteredIn(row, "CoPayType")
                        .Item(Me.colBPCoPayPercent.Name, rowNo).Value = SingleMayBeEnteredIn(row, "CoPayPercent")
                        .Item(Me.colBPCoPayValue.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"))
                        .Item(Me.colBPItemCategoryID.Name, rowNo).Value = StringEnteredIn(row, "ItemCategoryID")

                    End With

                    Me.CalculateBillAmount(rowNo)

                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.lblBPRecordsNo.Text = " Returned Record(s): " + visitItems.Count.ToString()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            Me.CalculateAccountTotalBill()
            Me.SetNextReceiptNo(Me.stbBPReceiptNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.fbnExportTo.Enabled = Me.dgvBillsPayment.RowCount > 0
            Me.btnSave.Enabled = Me.dgvBillsPayment.RowCount > 0
            Me.btnAddExtraBill.Enabled = Me.dgvBillsPayment.RowCount > 0
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ApplySecurity()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoadPendingBillsPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPendingBillsPayment.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.LoadBillItems()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboBPCurrenciesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBPCurrenciesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboBPCurrenciesID, "Currency!")
            If String.IsNullOrEmpty(currenciesID) Then Return

            Me.SetBillsCurrencyControls(currenciesID)
            Me.CalculateBillsChange()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetBillsCurrencyControls(ByVal currenciesID As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim exchangeRate As Decimal = GetExchangeRateBuying(currenciesID)

            If currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                Me.nbxBPExchangeRate.Value = "1.00"
                Me.nbxBPExchangeRate.Enabled = False
                Me.btnBPExchangeRate.Enabled = False

            ElseIf exchangeRate > 0 Then
                If exchangeRate >= 1 Then
                    Me.nbxBPExchangeRate.Value = FormatNumber(exchangeRate, AppData.DecimalPlaces)
                Else : Me.nbxBPExchangeRate.Value = exchangeRate.ToString()
                End If
                Me.nbxBPExchangeRate.Enabled = False
                Me.btnBPExchangeRate.Enabled = True

            Else
                Me.nbxBPExchangeRate.Value = String.Empty
                Me.nbxBPExchangeRate.Enabled = True
                Me.btnBPExchangeRate.Enabled = True
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.btnBPExchangeRate.Enabled Then Security.Apply(Me.btnBPExchangeRate, AccessRights.All)
            Me.stbBPChange.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnBPExchangeRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBPExchangeRate.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim fExchangeRates As New frmExchangeRates()
            fExchangeRates.ShowDialog()

            Me.cboBPCurrenciesID_SelectedIndexChanged(sender, EventArgs.Empty)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvBillsPayDetails_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillsPayment.CellEndEdit

        If e.ColumnIndex.Equals(Me.colBPDiscount.Index) Then
            Me.CalculateBillAmount(e.RowIndex)
            Me.CalculateAccountTotalBill()

        ElseIf e.ColumnIndex.Equals(Me.colBPInclude.Index) Then
            Me.CalculateAccountTotalBill()

        End If

    End Sub

    Private Sub chkBPUseAccountBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBPUseAccountBalance.Click

        Try

            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.stbBPAccountBalance, True)

            If Me.chkBPUseAccountBalance.Checked AndAlso accountBalance <= 0 Then
                Me.ResetBPUseAccountBalanceCTRL(accountBalance)
            Else : Me.CalculateBillsAmountTendered()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillsChange()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub ResetBPUseAccountBalanceCTRL(accountBalance As Decimal)

        Try

            Dim message As String = "Account current balance of " + FormatNumber(accountBalance, AppData.DecimalPlaces) +
                                    " can’t be used to offset this bill"

            Me.chkBPUseAccountBalance.Checked = False
            Throw New ArgumentException(message)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillsAmountTendered()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxBPAmountTendered.Value = String.Empty
            Me.ResetBillsCurrencyControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbBPTotalBill, True)
            Dim withholdingTax As Decimal = DecimalMayBeEnteredIn(Me.nbxBPWithholdingTax, True)
            Dim grandDiscount As Decimal = DecimalMayBeEnteredIn(Me.nbxBPGrandDiscount, True)

            Dim netBill As Decimal = totalBill - withholdingTax - grandDiscount
            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.stbBPAccountBalance, True)
            Dim amountTendered As Decimal

            If Me.chkBPUseAccountBalance.Checked AndAlso accountBalance <= netBill Then
                amountTendered = netBill - accountBalance

            ElseIf Me.chkBPUseAccountBalance.Checked AndAlso accountBalance > netBill Then
                amountTendered = 0

            Else : amountTendered = netBill
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxBPAmountTendered.Value = FormatNumber(amountTendered, AppData.DecimalPlaces)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculateBillsChange()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbBPChange.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbBPTotalBill, True)
            
            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxBPAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxBPExchangeRate, False)
            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.stbBPAccountBalance, True)
            Dim change As Decimal
           

            If totalBill <= 0 OrElse amountTendered < 0 OrElse exchangeRate <= 0 Then Return

            If Me.chkBPUseAccountBalance.Checked AndAlso accountBalance <= totalBill Then
                change = amountTendered * exchangeRate - totalBill + accountBalance

            ElseIf Me.chkBPUseAccountBalance.Checked AndAlso accountBalance > totalBill Then
                change = amountTendered * exchangeRate

            Else : change = amountTendered * exchangeRate - totalBill
            End If

            Me.stbBPChange.Text = FormatNumber(change, AppData.DecimalPlaces)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub BPAmountTenderedChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxBPAmountTendered.Leave, nbxBPAmountTendered.TextChanged
        Me.CalculateBillsChange()
    End Sub

    Private Sub BPExchangeRateChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxBPExchangeRate.Leave, nbxBPExchangeRate.TextChanged
        Me.CalculateBillsChange()
    End Sub

    Private Sub ResetBillsCurrencyControls()

        Try

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Me.cboBPCurrenciesID.SelectedValue = oCurrenciesID.UgandaShillings

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub rdoBPGetPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoBPGetPeriod.CheckedChanged
        If Me.rdoBPGetPeriod.Checked Then EnablePeriodCTLS(True)
    End Sub

    Private Sub rdoBPGetAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoBPGetAll.CheckedChanged
        If Me.rdoBPGetAll.Checked Then EnablePeriodCTLS(False)
    End Sub

    Private Sub EnablePeriodCTLS(ByVal state As Boolean)

        Me.pnlBPPeriod.Enabled = state
        If state Then
            Me.dtpBPStartDate.Value = Today.AddDays(-1)
            Me.dtpBPEndDate.Value = Today
            Me.dtpBPStartDate.Checked = True
            Me.dtpBPEndDate.Checked = True
        Else : ResetControlsIn(Me.pnlBPPeriod)
        End If

        Me.ResetBillsPayControls()

    End Sub

    Private Sub dtpBPStartDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpBPStartDate.ValueChanged
        Me.ResetBillsPayControls()
    End Sub

    Private Sub dtpBPEndDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpBPEndDate.ValueChanged
        Me.ResetBillsPayControls()
    End Sub

    Private Sub stbBPReceiptNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbBPReceiptNo.Enter
        Me.SetNextReceiptNo(Me.stbBPReceiptNo)
    End Sub

    Private Sub cboBPCompanyNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBPCompanyNo.SelectedIndexChanged
        Me.stbBPCompanyName.Clear()
    End Sub

    Private Sub cboBPCompanyNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBPCompanyNo.Leave

        Dim companyName As String
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try

            Dim companyNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboBPCompanyNo)))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBPBillModesID, "To-Bill Account Category!")

            If String.IsNullOrEmpty(billModesID) Then Return

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(companyNo) Then

                        Me.cboBPCompanyNo.Text = FormatText(companyNo, "BillCustomers", "AccountNo").ToUpper()

                        For Each row As DataRow In billCompanies.Select("AccountNo = '" + companyNo + "'")

                            If Not IsDBNull(row.Item("BillCustomerName")) Then
                                companyName = StringEnteredIn(row, "BillCustomerName")
                                companyNo = StringMayBeEnteredIn(row, "AccountNo")
                                Me.cboBPCompanyNo.Text = FormatText(companyNo, "BillCustomers", "AccountNo").ToUpper()
                            Else
                                companyName = String.Empty
                                companyNo = String.Empty
                            End If

                            Me.stbBPCompanyName.Text = companyName
                        Next

                    End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(companyNo) Then

                        Me.cboBPCompanyNo.Text = FormatText(companyNo, "Companies", "CompanyNo").ToUpper()

                        For Each row As DataRow In insuranceCompanies.Select("CompanyNo = '" + companyNo + "'")

                            If Not IsDBNull(row.Item("CompanyName")) Then
                                companyName = StringEnteredIn(row, "CompanyName")
                                companyNo = StringMayBeEnteredIn(row, "CompanyNo")
                                Me.cboBPCompanyNo.Text = FormatText(companyNo, "Companies", "CompanyNo").ToUpper()
                            Else
                                companyName = String.Empty
                                companyNo = String.Empty
                            End If

                            Me.stbBPCompanyName.Text = companyName
                        Next

                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ResetBillsPayControls()
            Me.LoadBillItems()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub stbBPVisitNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbBPVisitNo.Leave
        Me.btnLoadPendingBillsPayment.PerformClick()
    End Sub

    Private Sub CalculateBillAmount(ByVal rowNo As Integer)

        Dim cells As DataGridViewCellCollection = Me.dgvBillsPayment.Rows(rowNo).Cells

        Try

            Dim quantity As Integer = IntegerMayBeEnteredIn(cells, Me.colBPQuantity)
            Dim billPrice As Decimal = DecimalMayBeEnteredIn(cells, Me.colBPBillPrice)
            Dim discount As Decimal = DecimalMayBeEnteredIn(cells, Me.colBPDiscount)

            Dim amount As Decimal = quantity * billPrice - discount
            Me.dgvBillsPayment.Item(Me.colBPAmount.Name, rowNo).Value = FormatNumber(amount, AppData.DecimalPlaces)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculateAccountTotalBill()

        Dim totalBill As Decimal

        Me.stbBPTotalBill.Clear()
        Me.nbxBPAmountTendered.Value = String.Empty
        Me.chkBPUseAccountBalance.Checked = False
        Me.chkBPSendBalanceToAccount.Checked = False
        Me.ResetBillsCurrencyControls()

        For rowNo As Integer = 0 To Me.dgvBillsPayment.RowCount - 1
            If CBool(Me.dgvBillsPayment.Item(Me.colBPInclude.Name, rowNo).Value) = True Then
                Dim cells As DataGridViewCellCollection = Me.dgvBillsPayment.Rows(rowNo).Cells
                Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colBPAmount)
                totalBill += amount
            End If
        Next

        Dim withholdingTax As Decimal = DecimalMayBeEnteredIn(Me.nbxBPWithholdingTax, True)
        Dim grandDiscount As Decimal = DecimalMayBeEnteredIn(Me.nbxBPGrandDiscount, True)
        Dim netBill As Decimal = totalBill - withholdingTax - grandDiscount

        Me.stbBPTotalBill.Text = FormatNumber(netBill, AppData.DecimalPlaces)
        Me.stbBPAmountWords.Text = NumberToWords(netBill)
        Me.nbxBPAmountTendered.Value = FormatNumber(netBill, AppData.DecimalPlaces)
        Me.CalculateBillsChange()

    End Sub

    Private Sub cboBPBillAccountNo_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles cboBPBillAccountNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearBillsPayControls()

            Dim billNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboBPBillAccountNo)))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBPBillModesID, "Account Category!")

            If String.IsNullOrEmpty(billNo) OrElse String.IsNullOrEmpty(billModesID) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadBillDetails(billModesID, billNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadBillDetails(ByVal billModesID As String, ByVal billNo As String)

        Dim billCustomerName As String = String.Empty
        Dim accountBalance As Decimal
        Dim debitBalanceErrorMSG As String = "Debit balance should be cleared first!"

        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()

        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oBillCustomerTypeID As New LookupDataID.BillCustomerTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbBPBillCustomerName.Clear()
            Me.stbBPAccountBalance.Clear()
            ErrProvider.SetError(Me.stbBPAccountBalance, String.Empty)
            If String.IsNullOrEmpty(billNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oPatients.GetPatients(billNo).Tables("Patients").Rows(0)

                    Me.cboBPBillAccountNo.Text = FormatText(billNo, "Patients", "PatientNo")
                    billCustomerName = StringMayBeEnteredIn(row, "FullName")
                    accountBalance = GetAccountBalance(oBillModesID.Cash, billNo)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oBillCustomers.GetBillCustomers(billNo).Tables("BillCustomers").Rows(0)

                    Me.cboBPBillAccountNo.Text = FormatText(billNo, "BillCustomers", "AccountNo").ToUpper()
                    billCustomerName = StringMayBeEnteredIn(row, "BillCustomerName")
                    Dim billCustomerTypeID As String = StringMayBeEnteredIn(row, "BillCustomerTypeID")
                    accountBalance = GetAccountBalance(oBillModesID.Account, billNo)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If billCustomerTypeID.ToUpper().Equals(oBillCustomerTypeID.Insurance.ToUpper()) Then

                        Me.SetInsuranceCompanyCTRLS(True)

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        billCompanies = oBillCustomers.GetBillCustomersByInsuranceNo(billNo).Tables("BillCustomers")

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        LoadComboData(Me.cboBPCompanyNo, billCompanies, "BillCustomerFullName")
                        Me.cboBPCompanyNo.Items.Insert(0, String.Empty)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Else : Me.SetInsuranceCompanyCTRLS(False)
                    End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oInsurances.GetInsurances(billNo).Tables("Insurances").Rows(0)

                    Me.cboBPBillAccountNo.Text = FormatText(billNo, "Insurances", "InsuranceNo").ToUpper()
                    billCustomerName = StringMayBeEnteredIn(row, "InsuranceName")
                    accountBalance = GetAccountBalance(oBillModesID.Insurance, billNo)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbBPBillCustomerName.Text = billCustomerName
            Me.stbBPAccountBalance.Text = FormatNumber(accountBalance, AppData.DecimalPlaces)

            If accountBalance < 0 Then
                ErrProvider.SetError(Me.stbBPAccountBalance, debitBalanceErrorMSG)
            Else : ErrProvider.SetError(Me.stbBPAccountBalance, String.Empty)
            End If

            Me.btnManageAccounts.Enabled = True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.LoadBillItems()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboBPBillAccountNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBPBillAccountNo.SelectedIndexChanged
        Me.ClearBillsPayControls()
    End Sub

    Private Sub ClearBillsPayControls()

        Me.stbBPBillCustomerName.Clear()
        Me.stbBPAccountBalance.Clear()
        ErrProvider.SetError(Me.stbBPAccountBalance, String.Empty)
        Me.btnAddExtraBill.Enabled = False
        Me.btnManageAccounts.Enabled = False
        Me.ResetBillsPayControls()

    End Sub

    Private Sub ResetBillsPayControls()

        Me.stbBPReceiptNo.Clear()
        Me.stbBPDocumentNo.Clear()
        Me.stbBPTotalBill.Clear()
        Me.stbBPAmountWords.Clear()
        Me.stbBPNotes.Clear()
        Me.dgvBillsPayment.Rows.Clear()
        Me.lblBPRecordsNo.Text = String.Empty
        Me.nbxBPAmountTendered.Value = String.Empty
        Me.chkBPUseAccountBalance.Checked = False
        Me.chkBPSendBalanceToAccount.Checked = False
        Me.ResetBillsCurrencyControls()
        Me.btnAddExtraBill.Enabled = False
        Me.btnSave.Enabled = False
        Me.fbnExportTo.Enabled = False

    End Sub

    Private Sub cboBPBillModesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBPBillModesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearBillsPayControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim oBillModesID As New LookupDataID.BillModesID()
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBPBillModesID, "To-Bill Account Category!")
            If String.IsNullOrEmpty(billModesID) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
          
            Me.LoadBillClients(billModesID)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearBillsPaymentControls()
        Me.cboBPBillAccountNo.DataSource = Nothing
        Me.cboBPBillAccountNo.Items.Clear()
        Me.cboBPBillAccountNo.Text = String.Empty
        Me.btnAddExtraBill.Enabled = False
    End Sub

    Private Sub SetInsuranceCompanyCTRLS(ByVal state As Boolean)

        Me.cboBPCompanyNo.SelectedIndex = -1
        Me.cboBPCompanyNo.SelectedIndex = -1
        Me.stbBPCompanyName.Clear()
        Me.cboBPCompanyNo.Items.Clear()
        Me.cboBPCompanyNo.Text = String.Empty

        Me.lblBPCompanyNo.Enabled = state
        Me.lblBPCompanyName.Enabled = state
        Me.cboBPCompanyNo.Enabled = state
        Me.stbBPCompanyName.Enabled = state

    End Sub

    Private Sub LoadBillClients(ByVal billModesID As String)

        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()
        Dim oCompanies As New SyncSoft.SQLDb.Companies()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearBillsPaymentControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblBPBillAccountNo.Text = "To-Bill Patient No"
                    Me.lblBPBillCustomerName.Text = "To-Bill Patient Name"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetInsuranceCompanyCTRLS(False)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Load all from Bill Customers

                    If Not InitOptions.LoadBillCustomersAtStart Then
                        billCustomers = oBillCustomers.GetBillCustomers().Tables("BillCustomers")
                        oSetupData.BillCustomers = billCustomers
                    Else : billCustomers = oSetupData.BillCustomers
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.cboBPBillAccountNo, billCustomers, "BillCustomerFullName")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblBPBillAccountNo.Text = "To-Bill Account Number"
                    Me.lblBPBillCustomerName.Text = "To-Bill Customer Name"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetInsuranceCompanyCTRLS(False)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Load all from Insurances

                    Dim insurances As DataTable = oInsurances.GetInsurances().Tables("Insurances")
                    LoadComboData(Me.cboBPBillAccountNo, insurances, "InsuranceFullName")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblBPBillAccountNo.Text = "To-Bill Insurance No"
                    Me.lblBPBillCustomerName.Text = "To-Bill Insurance Name"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetInsuranceCompanyCTRLS(True)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    insuranceCompanies = oCompanies.GetCompanies().Tables("Companies")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.cboBPCompanyNo, insuranceCompanies, "companyFullName")
                    Me.cboBPCompanyNo.Items.Insert(0, String.Empty)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Credit Bill Form Payment "

    Private Sub ResetCBFPAccountBalanceCTRL(accountBalance As Decimal)

        Try

            If Not accountBalance = DecimalMayBeEnteredIn(Me.stbCBFPAccountBalance, True) Then

                Me.stbCBFPAccountBalance.Text = FormatNumber(accountBalance, AppData.DecimalPlaces)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Me.chkCBFPUseAccountBalance.Checked AndAlso accountBalance <= 0 Then
                    Me.ResetCBFPUseAccountBalanceCTRL(accountBalance)
                Else : Me.CalculateCBFPChange()
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadCBFPExtraBillItems()

        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
            Dim message As String = "Unknown Error Occured!"
            Dim cashAccount As String = GetLookupDataDes(oBillModesID.Cash)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim billModesID As String = StringValueEnteredIn(Me.cboCBFPBillModesID, "Account Category!")
            Dim billNo As String = RevertText(SubstringRight(StringEnteredIn(Me.cboCBFPBillAccountNo, "To-Bill Number!")))
            Dim companyNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboCBFPCompanyNo)))
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbCBFPVisitNo))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dgvCBFPExtraBillItems.Rows.Clear()
            Me.lblCBFPRecordsNo.Text = String.Empty
            Me.fbnCBFPExportTo.Enabled = False
            Me.btnSave.Enabled = False
            Me.btnAddExtraBill.Enabled = False
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If billModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) Then Throw New ArgumentException("Invalid Account Category (CASH)!")
            If billNo.ToUpper().Equals(cashAccount.ToUpper()) Then Throw New ArgumentException("Invalid entry (CASH) for an account!")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case True

                Case Me.rdoCBFPGetPeriod.Checked

                    Dim startDate As Date = DateEnteredIn(Me.dtpCBFPStartDate, "Start Date")
                    Dim endDate As Date = DateEnteredIn(Me.dtpCBFPEndDate, "End Date")

                    If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")


                    If chkCBFPExcludeNotInvoicedItem.Checked Then

                        extraBillItems = oExtraBillItems.GetInvoicedNotPaidExtraBillItems(billModesID, billNo, startDate, endDate, companyNo).Tables("ExtraBillItems")

                    Else
                        extraBillItems = oExtraBillItems.GetNotPaidExtraBillItems(billModesID, billNo, startDate, endDate, companyNo).Tables("ExtraBillItems")


                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If billModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) Then
                        If String.IsNullOrEmpty(companyNo) Then
                            message = "The Account No: " + FormatText(billNo, "BillCustomers", "AccountNo") + " has no unpaid for ExtraBillItems for period between " _
                                     + FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
                        Else : message = "The Company with Account No: " + FormatText(companyNo, "BillCustomers", "AccountNo") +
                                     " under Insurance with Account No: " + FormatText(billNo, "BillCustomers", "AccountNo") +
                                     " has no unpaid for ExtraBillItems for period between " + FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
                        End If

                    ElseIf billModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then
                        If String.IsNullOrEmpty(companyNo) Then
                            message = "The Insurance No: " + FormatText(billNo, "Insurances", "InsuranceNo") + " has no unpaid for ExtraBillItems for period between " _
                                                           + FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
                        Else : message = "The Company No: " + FormatText(companyNo, "Companies", "CompanyNo") + " under Insurance No: " + FormatText(billNo, "Insurances", "InsuranceNo") +
                                      " has no unpaid for ExtraBillItems for period between " + FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
                        End If

                    End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.rdoCBFPGetAll.Checked

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    message = "This action may take awhile to complete if you have many " + Me.stbCBFPBillCustomerName.Text _
                               + " un paid for ExtraBillItems. " + ControlChars.NewLine + "Are you sure you want to load all?"

                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If chkCBFPExcludeNotInvoicedItem.Checked Then

                        extraBillItems = oExtraBillItems.GetInvoicedNotPaidExtraBillItems(billModesID, billNo, companyNo).Tables("ExtraBillItems")

                    Else
                        extraBillItems = oExtraBillItems.GetNotPaidExtraBillItems(billModesID, billNo, companyNo).Tables("ExtraBillItems")


                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If billModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) Then

                        If String.IsNullOrEmpty(companyNo) Then
                            message = "The Account No: " + FormatText(billNo, "BillCustomers", "AccountNo") + " has no unpaid for ExtraBillItems for all period!"
                        Else : message = "The Company with Account No: " + FormatText(companyNo, "BillCustomers", "AccountNo") +
                            " under Insurance with Account No: " + FormatText(billNo, "BillCustomers", "AccountNo") + " has no unpaid for ExtraBillItems for all period!"
                        End If

                    ElseIf billModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then
                        If String.IsNullOrEmpty(companyNo) Then
                            message = "The Insurance No: " + FormatText(billNo, "Insurances", "InsuranceNo") + " has no unpaid for ExtraBillItems for all period!"
                        Else : message = "The Company No: " + FormatText(companyNo, "Companies", "CompanyNo") + " under Insurance No: " + FormatText(billNo, "Insurances", "InsuranceNo") +
                                                                 " has no unpaid for ExtraBillItems for all period!"
                        End If
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Throw New ArgumentException(message)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If String.IsNullOrEmpty(visitNo) Then

                For rowNo As Integer = 0 To extraBillItems.Rows.Count - 1

                    Dim row As DataRow = extraBillItems.Rows(rowNo)

                    With Me.dgvCBFPExtraBillItems

                        .Rows.Add()

                        .Item(Me.colCBFPInclude.Name, rowNo).Value = True
                        .Item(Me.colCBFPVisitNo.Name, rowNo).Value = FormatText(StringEnteredIn(row, "VisitNo"), "Visits", "VisitNo")
                        .Item(Me.colCBFPVisitDate.Name, rowNo).Value = FormatDate(DateEnteredIn(row, "VisitDate"))
                        .Item(Me.colCBFPInvoiceNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "InvoiceNo")
                        .Item(Me.colCBFPPatientNo.Name, rowNo).Value = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
                        .Item(Me.colCBFPFullName.Name, rowNo).Value = StringEnteredIn(row, "FullName")
                        .Item(Me.colCBFPExtraBillNo.Name, rowNo).Value = StringEnteredIn(row, "ExtraBillNo")
                        .Item(Me.colCBFPExtraBillDate.Name, rowNo).Value = FormatDate(DateEnteredIn(row, "ExtraBillDate"))
                        .Item(Me.colCBFPItemCode.Name, rowNo).Value = StringEnteredIn(row, "ItemCode")
                        .Item(Me.colCBFPItemName.Name, rowNo).Value = StringEnteredIn(row, "ItemName")
                        .Item(Me.colCBFPCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "ItemCategory")
                        .Item(Me.colCBFPQuantity.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Quantity")
                        .Item(Me.colCBFPUnitPrice.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "UnitPrice"))
                        .Item(Me.colCBFPBillPrice.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "BillPrice"))
                        .Item(Me.colCBFPDiscount.Name, rowNo).Value = FormatNumber(0)
                        .Item(Me.colCBFPInvoiceAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "InvoiceAmount"))
                        .Item(Me.colCBFPEntryMode.Name, rowNo).Value = StringMayBeEnteredIn(row, "EntryMode")
                        .Item(Me.colCBFPMemberCardNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "MemberCardNo")
                        .Item(Me.colCBFPBillCustomerName.Name, rowNo).Value = StringMayBeEnteredIn(row, "BillCustomerName")
                        .Item(Me.colCBFPCoPayType.Name, rowNo).Value = StringMayBeEnteredIn(row, "CoPayType")
                        .Item(Me.colCBFPCoPayPercent.Name, rowNo).Value = SingleMayBeEnteredIn(row, "CoPayPercent")
                        .Item(Me.colCBFPCoPayValue.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"))
                        .Item(Me.colCBFPItemCategoryID.Name, rowNo).Value = StringMayBeEnteredIn(row, "ItemCategoryID")
                        .Item(Me.colCBFPRoundNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "RoundNo")

                    End With

                    Me.CalculateCBFPAmount(rowNo)

                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.lblCBFPRecordsNo.Text = " Returned Record(s): " + extraBillItems.Rows.Count.ToString()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else

                Dim visitExtraBillItems As EnumerableRowCollection(Of DataRow) = (From data In extraBillItems.AsEnumerable()
                                                                                  Where data.Field(Of String)("VisitNo").ToUpper().Equals(FormatText(visitNo, "Visits", "VisitNo").ToUpper()) Or
                         data.Field(Of String)("VisitNo").ToUpper().Equals(visitNo.ToUpper()) Select data)

                For rowNo As Integer = 0 To visitExtraBillItems.Count - 1

                    Dim row As DataRow = visitExtraBillItems.ElementAt(rowNo)

                    With Me.dgvCBFPExtraBillItems

                        .Rows.Add()

                        .Item(Me.colCBFPInclude.Name, rowNo).Value = True
                        .Item(Me.colCBFPVisitNo.Name, rowNo).Value = FormatText(StringEnteredIn(row, "VisitNo"), "Visits", "VisitNo")
                        .Item(Me.colCBFPVisitDate.Name, rowNo).Value = FormatDate(DateEnteredIn(row, "VisitDate"))
                        .Item(Me.colCBFPPatientNo.Name, rowNo).Value = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
                        .Item(Me.colCBFPFullName.Name, rowNo).Value = StringEnteredIn(row, "FullName")
                        .Item(Me.colCBFPExtraBillNo.Name, rowNo).Value = StringEnteredIn(row, "ExtraBillNo")
                        .Item(Me.colCBFPInvoiceNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "InvoiceNo")
                        .Item(Me.colCBFPExtraBillDate.Name, rowNo).Value = FormatDate(DateEnteredIn(row, "ExtraBillDate"))
                        .Item(Me.colCBFPItemCode.Name, rowNo).Value = StringEnteredIn(row, "ItemCode")
                        .Item(Me.colCBFPItemName.Name, rowNo).Value = StringEnteredIn(row, "ItemName")
                        .Item(Me.colCBFPCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "ItemCategory")
                        .Item(Me.colCBFPQuantity.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Quantity")
                        .Item(Me.colCBFPUnitPrice.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "UnitPrice"))
                        .Item(Me.colCBFPBillPrice.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "BillPrice"))
                        .Item(Me.colCBFPDiscount.Name, rowNo).Value = FormatNumber(0)
                        .Item(Me.colCBFPEntryMode.Name, rowNo).Value = StringMayBeEnteredIn(row, "EntryMode")
                        .Item(Me.colCBFPMemberCardNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "MemberCardNo")
                        .Item(Me.colCBFPBillCustomerName.Name, rowNo).Value = StringMayBeEnteredIn(row, "BillCustomerName")
                        .Item(Me.colCBFPCoPayType.Name, rowNo).Value = StringMayBeEnteredIn(row, "CoPayType")
                        .Item(Me.colCBFPCoPayPercent.Name, rowNo).Value = SingleMayBeEnteredIn(row, "CoPayPercent")
                        .Item(Me.colCBFPCoPayValue.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"))
                        .Item(Me.colCBFPItemCategoryID.Name, rowNo).Value = StringMayBeEnteredIn(row, "ItemCategoryID")
                        .Item(Me.colCBFPRoundNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "RoundNo")

                    End With

                    Me.CalculateCBFPAmount(rowNo)

                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.lblCBFPRecordsNo.Text = " Returned Record(s): " + visitExtraBillItems.Count.ToString()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            Me.CalculateCBFPAccountTotalBill()
            Me.SetNextReceiptNo(Me.stbCBFPReceiptNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.fbnCBFPExportTo.Enabled = Me.dgvCBFPExtraBillItems.RowCount > 0
            Me.btnSave.Enabled = Me.dgvCBFPExtraBillItems.RowCount > 0
            Me.btnAddExtraBill.Enabled = Me.dgvCBFPExtraBillItems.RowCount > 0
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ApplySecurity()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnCBFPLoadPendingBillsPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCBFPLoadPendingBillsPayment.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.LoadCBFPExtraBillItems()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboCBFPCurrenciesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCBFPCurrenciesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboCBFPCurrenciesID, "Currency!")
            If String.IsNullOrEmpty(currenciesID) Then Return

            Me.SetCBFPCurrencyControls(currenciesID)
            Me.CalculateCBFPChange()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetCBFPCurrencyControls(ByVal currenciesID As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim exchangeRate As Decimal = GetExchangeRateBuying(currenciesID)

            If currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                Me.nbxCBFPExchangeRate.Value = "1.00"
                Me.nbxCBFPExchangeRate.Enabled = False
                Me.btnCBFPExchangeRate.Enabled = False

            ElseIf exchangeRate > 0 Then
                If exchangeRate >= 1 Then
                    Me.nbxCBFPExchangeRate.Value = FormatNumber(exchangeRate, AppData.DecimalPlaces)
                Else : Me.nbxCBFPExchangeRate.Value = exchangeRate.ToString()
                End If
                Me.nbxCBFPExchangeRate.Enabled = False
                Me.btnCBFPExchangeRate.Enabled = True

            Else
                Me.nbxCBFPExchangeRate.Value = String.Empty
                Me.nbxCBFPExchangeRate.Enabled = True
                Me.btnCBFPExchangeRate.Enabled = True
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.btnCBFPExchangeRate.Enabled Then Security.Apply(Me.btnCBFPExchangeRate, AccessRights.All)
            Me.stbCBFPChange.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnCBFPExchangeRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCBFPExchangeRate.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim fExchangeRates As New frmExchangeRates()
            fExchangeRates.ShowDialog()

            Me.cboCBFPCurrenciesID_SelectedIndexChanged(sender, EventArgs.Empty)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvCBFPExtraBillItems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCBFPExtraBillItems.CellEndEdit

        If e.ColumnIndex.Equals(Me.colCBFPDiscount.Index) Then
            Me.CalculateCBFPAmount(e.RowIndex)
            Me.CalculateCBFPAccountTotalBill()

        ElseIf e.ColumnIndex.Equals(Me.colCBFPInclude.Index) Then
            Me.CalculateCBFPAccountTotalBill()
        End If

    End Sub

    Private Sub chkCBFPUseAccountBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCBFPUseAccountBalance.Click

        Try

            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.stbCBFPAccountBalance, True)

            If Me.chkCBFPUseAccountBalance.Checked AndAlso accountBalance <= 0 Then
                Me.ResetCBFPUseAccountBalanceCTRL(accountBalance)
            Else : Me.CalculateCBFPAmountTendered()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateCBFPChange()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub ResetCBFPUseAccountBalanceCTRL(accountBalance As Decimal)

        Try

            Dim message As String = "Account current balance of " + FormatNumber(accountBalance, AppData.DecimalPlaces) +
                                   " can’t be used to offset this bill"

            Me.chkCBFPUseAccountBalance.Checked = False
            Throw New ArgumentException(message)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateCBFPAmountTendered()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxCBFPAmountTendered.Value = String.Empty
            Me.ResetCBFPCurrencyControls()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbCBFPTotalBill, True)
            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.stbCBFPAccountBalance, True)
            Dim amountTendered As Decimal

            If Me.chkCBFPUseAccountBalance.Checked AndAlso accountBalance <= totalBill Then
                amountTendered = totalBill - accountBalance

            ElseIf Me.chkCBFPUseAccountBalance.Checked AndAlso accountBalance > totalBill Then
                amountTendered = 0

            Else : amountTendered = totalBill
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxCBFPAmountTendered.Value = FormatNumber(amountTendered, AppData.DecimalPlaces)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculateCBFPChange()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbCBFPChange.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbCBFPTotalBill, True)
           
            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxCBFPAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxCBFPExchangeRate, False)
            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.stbCBFPAccountBalance, True)
            Dim change As Decimal

            If totalBill <= 0 OrElse amountTendered < 0 OrElse exchangeRate <= 0 Then Return

            If Me.chkCBFPUseAccountBalance.Checked AndAlso accountBalance <= totalBill Then
                change = amountTendered * exchangeRate - totalBill + accountBalance

            ElseIf Me.chkCBFPUseAccountBalance.Checked AndAlso accountBalance > totalBill Then
                change = amountTendered * exchangeRate

            Else : change = amountTendered * exchangeRate - totalBill
            End If

            Me.stbCBFPChange.Text = FormatNumber(change, AppData.DecimalPlaces)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CBFPAmountTenderedChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxCBFPAmountTendered.Leave, nbxCBFPAmountTendered.TextChanged
        Me.CalculateCBFPChange()
    End Sub

    Private Sub CBFPExchangeRateChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxCBFPExchangeRate.Leave, nbxCBFPExchangeRate.TextChanged
        Me.CalculateCBFPChange()
    End Sub

    Private Sub ResetCBFPCurrencyControls()

        Try

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Me.cboCBFPCurrenciesID.SelectedValue = oCurrenciesID.UgandaShillings

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub rdoCBFPGetPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCBFPGetPeriod.CheckedChanged
        If Me.rdoCBFPGetPeriod.Checked Then EnableCBFPPeriodCTLS(True)
    End Sub

    Private Sub rdoCBFPGetAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCBFPGetAll.CheckedChanged
        If Me.rdoCBFPGetAll.Checked Then EnableCBFPPeriodCTLS(False)
    End Sub

    Private Sub EnableCBFPPeriodCTLS(ByVal state As Boolean)

        Me.pnlCBFPPeriod.Enabled = state
        If state Then
            Me.dtpCBFPStartDate.Value = Today.AddDays(-1)
            Me.dtpCBFPEndDate.Value = Today
            Me.dtpCBFPStartDate.Checked = True
            Me.dtpCBFPEndDate.Checked = True
        Else : ResetControlsIn(Me.pnlCBFPPeriod)
        End If

        Me.ResetCBFPPayControls()

    End Sub

    Private Sub dtpCBFPStartDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCBFPStartDate.ValueChanged
        Me.ResetCBFPPayControls()
    End Sub

    Private Sub dtpCBFPEndDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCBFPEndDate.ValueChanged
        Me.ResetCBFPPayControls()
    End Sub

    Private Sub stbCBFPReceiptNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbCBFPReceiptNo.Enter
        Me.SetNextReceiptNo(Me.stbCBFPReceiptNo)
    End Sub

    Private Sub cboCBFPCompanyNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCBFPCompanyNo.SelectedIndexChanged
        Me.stbCBFPCompanyName.Clear()
    End Sub

    Private Sub cboCBFPCompanyNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCBFPCompanyNo.Leave

        Dim companyName As String
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try

            Dim companyNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboCBFPCompanyNo)))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboCBFPBillModesID, "To-Bill Account Category!")

            If String.IsNullOrEmpty(billModesID) Then Return

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(companyNo) Then

                        Me.cboCBFPCompanyNo.Text = FormatText(companyNo, "BillCustomers", "AccountNo").ToUpper()

                        For Each row As DataRow In billCompanies.Select("AccountNo = '" + companyNo + "'")

                            If Not IsDBNull(row.Item("BillCustomerName")) Then
                                companyName = StringEnteredIn(row, "BillCustomerName")
                                companyNo = StringMayBeEnteredIn(row, "AccountNo")
                                Me.cboCBFPCompanyNo.Text = FormatText(companyNo, "BillCustomers", "AccountNo").ToUpper()
                            Else
                                companyName = String.Empty
                                companyNo = String.Empty
                            End If

                            Me.stbCBFPCompanyName.Text = companyName
                        Next

                    End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(companyNo) Then

                        Me.cboCBFPCompanyNo.Text = FormatText(companyNo, "Companies", "CompanyNo").ToUpper()

                        For Each row As DataRow In insuranceCompanies.Select("CompanyNo = '" + companyNo + "'")

                            If Not IsDBNull(row.Item("CompanyName")) Then
                                companyName = StringEnteredIn(row, "CompanyName")
                                companyNo = StringMayBeEnteredIn(row, "CompanyNo")
                                Me.cboCBFPCompanyNo.Text = FormatText(companyNo, "Companies", "CompanyNo").ToUpper()
                            Else
                                companyName = String.Empty
                                companyNo = String.Empty
                            End If

                            Me.stbCBFPCompanyName.Text = companyName
                        Next

                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ResetCBFPPayControls()
            Me.LoadCBFPExtraBillItems()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub stbCBFPVisitNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbCBFPVisitNo.Leave
        Me.btnCBFPLoadPendingBillsPayment.PerformClick()
    End Sub

    Private Sub CalculateCBFPAmount(ByVal rowNo As Integer)

        Dim cells As DataGridViewCellCollection = Me.dgvCBFPExtraBillItems.Rows(rowNo).Cells

        Try

            Dim quantity As Integer = IntegerMayBeEnteredIn(cells, Me.colCBFPQuantity)
            Dim billPrice As Decimal = DecimalMayBeEnteredIn(cells, Me.colCBFPBillPrice)
            Dim discount As Decimal = DecimalMayBeEnteredIn(cells, Me.colCBFPDiscount)

            Dim amount As Decimal = quantity * billPrice - discount
            Me.dgvCBFPExtraBillItems.Item(Me.colCBFPAmount.Name, rowNo).Value = FormatNumber(amount, AppData.DecimalPlaces)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculateCBFPAccountTotalBill()

        Dim totalBill As Decimal


        Me.stbCBFPTotalBill.Clear()
        Me.nbxCBFPAmountTendered.Value = String.Empty
        Me.chkCBFPUseAccountBalance.Checked = False
        Me.chkCBFPSendBalanceToAccount.Checked = False
        Me.ResetCBFPCurrencyControls()

        For rowNo As Integer = 0 To Me.dgvCBFPExtraBillItems.RowCount - 1
            If CBool(Me.dgvCBFPExtraBillItems.Item(Me.colCBFPInclude.Name, rowNo).Value) = True Then
                Dim cells As DataGridViewCellCollection = Me.dgvCBFPExtraBillItems.Rows(rowNo).Cells
                Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colCBFPAmount)
                totalBill += amount
            End If
        Next

        Dim withholdingTax As Decimal = DecimalMayBeEnteredIn(Me.nbxCBFPWithholdingTax, True)
        Dim grandDiscount As Decimal = DecimalMayBeEnteredIn(Me.nbxCBFPGrandDiscount, True)
        Dim netBill As Decimal = totalBill - withholdingTax - grandDiscount

        Me.stbCBFPTotalBill.Text = FormatNumber(netBill, AppData.DecimalPlaces)
        Me.stbCBFPAmountWords.Text = NumberToWords(netBill)
        Me.nbxCBFPAmountTendered.Value = FormatNumber(netBill, AppData.DecimalPlaces)
        Me.CalculateCBFPChange()

    End Sub

    Private Sub cboCBFPBillAccountNo_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles cboCBFPBillAccountNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearCBFPPayControls()

            Dim billNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboCBFPBillAccountNo)))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboCBFPBillModesID, "Account Category!")

            If String.IsNullOrEmpty(billNo) OrElse String.IsNullOrEmpty(billModesID) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadCBFPDetails(billModesID, billNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadCBFPDetails(ByVal billModesID As String, ByVal billNo As String)

        Dim billCustomerName As String = String.Empty
        Dim accountBalance As Decimal
        Dim debitBalanceErrorMSG As String = "Debit balance should be cleared first!"

        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()

        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oBillCustomerTypeID As New LookupDataID.BillCustomerTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbCBFPBillCustomerName.Clear()
            Me.stbCBFPAccountBalance.Clear()
            ErrProvider.SetError(Me.stbCBFPAccountBalance, String.Empty)
            If String.IsNullOrEmpty(billNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oPatients.GetPatients(billNo).Tables("Patients").Rows(0)

                    Me.cboCBFPBillAccountNo.Text = FormatText(billNo, "Patients", "PatientNo")
                    billCustomerName = StringMayBeEnteredIn(row, "FullName")
                    accountBalance = GetAccountBalance(oBillModesID.Cash, billNo)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oBillCustomers.GetBillCustomers(billNo).Tables("BillCustomers").Rows(0)

                    Me.cboCBFPBillAccountNo.Text = FormatText(billNo, "BillCustomers", "AccountNo").ToUpper()
                    billCustomerName = StringMayBeEnteredIn(row, "BillCustomerName")
                    Dim billCustomerTypeID As String = StringMayBeEnteredIn(row, "BillCustomerTypeID")
                    accountBalance = GetAccountBalance(oBillModesID.Account, billNo)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If billCustomerTypeID.ToUpper().Equals(oBillCustomerTypeID.Insurance.ToUpper()) Then

                        Me.SetCBFPInsuranceCompanyCTRLS(True)

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        billCompanies = oBillCustomers.GetBillCustomersByInsuranceNo(billNo).Tables("BillCustomers")

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        LoadComboData(Me.cboCBFPCompanyNo, billCompanies, "BillCustomerFullName")
                        Me.cboCBFPCompanyNo.Items.Insert(0, String.Empty)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Else : Me.SetCBFPInsuranceCompanyCTRLS(False)
                    End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oInsurances.GetInsurances(billNo).Tables("Insurances").Rows(0)

                    Me.cboCBFPBillAccountNo.Text = FormatText(billNo, "Insurances", "InsuranceNo").ToUpper()
                    billCustomerName = StringMayBeEnteredIn(row, "InsuranceName")
                    accountBalance = GetAccountBalance(oBillModesID.Insurance, billNo)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbCBFPBillCustomerName.Text = billCustomerName
            Me.stbCBFPAccountBalance.Text = FormatNumber(accountBalance, AppData.DecimalPlaces)

            If accountBalance < 0 Then
                ErrProvider.SetError(Me.stbCBFPAccountBalance, debitBalanceErrorMSG)
            Else : ErrProvider.SetError(Me.stbCBFPAccountBalance, String.Empty)
            End If

            Me.btnManageAccounts.Enabled = True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.LoadCBFPExtraBillItems()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboCBFPBillAccountNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCBFPBillAccountNo.SelectedIndexChanged
        Me.ClearCBFPPayControls()
    End Sub

    Private Sub ClearCBFPPayControls()

        Me.stbCBFPBillCustomerName.Clear()
        Me.stbCBFPAccountBalance.Clear()
        ErrProvider.SetError(Me.stbCBFPAccountBalance, String.Empty)
        Me.btnAddExtraBill.Enabled = False
        Me.btnManageAccounts.Enabled = False
        Me.ResetCBFPPayControls()

    End Sub

    Private Sub ResetCBFPPayControls()

        Me.stbCBFPReceiptNo.Clear()
        Me.stbCBFPDocumentNo.Clear()
        Me.stbCBFPTotalBill.Clear()
        Me.stbCBFPAmountWords.Clear()
        Me.stbCBFPNotes.Clear()
        Me.dgvCBFPExtraBillItems.Rows.Clear()
        Me.lblCBFPRecordsNo.Text = String.Empty
        Me.nbxCBFPAmountTendered.Value = String.Empty
        Me.chkCBFPUseAccountBalance.Checked = False
        Me.chkCBFPSendBalanceToAccount.Checked = False
        Me.ResetCBFPCurrencyControls()
        Me.btnAddExtraBill.Enabled = False
        Me.btnSave.Enabled = False
        Me.fbnCBFPExportTo.Enabled = False

    End Sub

    Private Sub cboCBFPBillModesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCBFPBillModesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearCBFPPayControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim oBillModesID As New LookupDataID.BillModesID()
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboCBFPBillModesID, "To-Bill Account Category!")
            If String.IsNullOrEmpty(billModesID) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadCBFPClients(billModesID)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearCBFPControls()
        Me.cboCBFPBillAccountNo.DataSource = Nothing
        Me.cboCBFPBillAccountNo.Items.Clear()
        Me.cboCBFPBillAccountNo.Text = String.Empty
        Me.btnAddExtraBill.Enabled = False
    End Sub

    Private Sub SetCBFPInsuranceCompanyCTRLS(ByVal state As Boolean)

        Me.cboCBFPCompanyNo.SelectedIndex = -1
        Me.cboCBFPCompanyNo.SelectedIndex = -1
        Me.stbCBFPCompanyName.Clear()
        Me.cboCBFPCompanyNo.Items.Clear()
        Me.cboCBFPCompanyNo.Text = String.Empty

        Me.lblCBFPCompanyNo.Enabled = state
        Me.lblCBFPCompanyName.Enabled = state
        Me.cboCBFPCompanyNo.Enabled = state
        Me.stbCBFPCompanyName.Enabled = state

    End Sub

    Private Sub LoadCBFPClients(ByVal billModesID As String)

        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()
        Dim oCompanies As New SyncSoft.SQLDb.Companies()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearCBFPControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblCBFPBillAccountNo.Text = "To-Bill Patient No"
                    Me.lblCBFPBillCustomerName.Text = "To-Bill Patient Name"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetCBFPInsuranceCompanyCTRLS(False)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Load all from Bill Customers

                    If Not InitOptions.LoadBillCustomersAtStart Then
                        billCustomers = oBillCustomers.GetBillCustomers().Tables("BillCustomers")
                        oSetupData.BillCustomers = billCustomers
                    Else : billCustomers = oSetupData.BillCustomers
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.cboCBFPBillAccountNo, billCustomers, "BillCustomerFullName")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblCBFPBillAccountNo.Text = "To-Bill Account Number"
                    Me.lblCBFPBillCustomerName.Text = "To-Bill Customer Name"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetCBFPInsuranceCompanyCTRLS(False)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Load all from Insurances

                    Dim insurances As DataTable = oInsurances.GetInsurances().Tables("Insurances")
                    LoadComboData(Me.cboCBFPBillAccountNo, insurances, "InsuranceFullName")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblCBFPBillAccountNo.Text = "To-Bill Insurance No"
                    Me.lblCBFPBillCustomerName.Text = "To-Bill Insurance Name"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetCBFPInsuranceCompanyCTRLS(True)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    insuranceCompanies = oCompanies.GetCompanies().Tables("Companies")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.cboCBFPCompanyNo, insuranceCompanies, "companyFullName")
                    Me.cboCBFPCompanyNo.Items.Insert(0, String.Empty)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Manage Accounts "

    Private Sub stbAccountTranNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbAccountTranNo.Enter
        Me.SetNextTranNo(Me.stbAccountTranNo)
    End Sub

    Private Sub cboAccountNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccountNo.TextChanged
        Me.stbAccountName.Clear()
        Me.nbxAccountBalance.Clear()
    End Sub

 

    Private Sub cboAccountNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccountNo.Leave

        Try

            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Account Category!")
            Dim accountNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboAccountNo)))

            If String.IsNullOrEmpty(accountNo) OrElse String.IsNullOrEmpty(billModesID) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadAccountDetails(billModesID, accountNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadAccountDetails(ByVal billModesID As String, ByVal accountNo As String)

        Dim accountName As String = String.Empty
        Dim accountBalance As Decimal
        Dim accountPhone As String = String.Empty

        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()

        Dim oBillModesID As New LookupDataID.BillModesID()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbAccountName.Clear()
            Me.nbxAccountAmount.Clear()
            Me.nbxAccountBalance.Clear()
            Me.stbAccountPhone.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oPatients.GetPatients(accountNo).Tables("Patients").Rows(0)

                    Me.cboAccountNo.Text = FormatText(accountNo, "Patients", "PatientNo")
                    accountName = StringMayBeEnteredIn(row, "FullName")
                    accountPhone = StringMayBeEnteredIn(row, "Phone")
                    accountBalance = GetAccountBalance(oBillModesID.Cash, accountNo)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oBillCustomers.GetBillCustomers(accountNo).Tables("BillCustomers").Rows(0)

                    Me.cboAccountNo.Text = FormatText(accountNo, "BillCustomers", "AccountNo").ToUpper()
                    accountName = StringMayBeEnteredIn(row, "BillCustomerName")
                    accountPhone = StringMayBeEnteredIn(row, "Phone")
                    accountBalance = GetAccountBalance(oBillModesID.Account, accountNo)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oInsurances.GetInsurances(accountNo).Tables("Insurances").Rows(0)

                    Me.cboAccountNo.Text = FormatText(accountNo, "Insurances", "InsuranceNo")
                    accountName = StringMayBeEnteredIn(row, "InsuranceName")
                    accountPhone = StringMayBeEnteredIn(row, "Phone")
                    accountBalance = GetAccountBalance(oBillModesID.Insurance, accountNo)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbAccountName.Text = accountName
            Me.stbAccountPhone.Text = accountPhone
            Me.nbxAccountBalance.Value = FormatNumber(accountBalance, AppData.DecimalPlaces)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            Me.LoadAccountClients(billModesID)
            Me.NewBalance()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearAccountControls()
        Me.cboAccountNo.DataSource = Nothing
        Me.cboAccountNo.Items.Clear()
        Me.cboAccountNo.Text = String.Empty
    End Sub

    Private Sub LoadAccountClients(ByVal billModesID As String)

        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearAccountControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblAccountNo.Text = "Patient No"
                    Me.lblAccountName.Text = "Patient Name"
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Load all from Bill Customers

                    If Not InitOptions.LoadBillCustomersAtStart Then
                        billCustomers = oBillCustomers.GetBillCustomers().Tables("BillCustomers")
                        oSetupData.BillCustomers = billCustomers
                    Else : billCustomers = oSetupData.BillCustomers
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.cboAccountNo, billCustomers, "BillCustomerFullName")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblAccountNo.Text = "Account No"
                    Me.lblAccountName.Text = "Account Name"
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblAccountNo.Text = "Insurance No"
                    Me.lblAccountName.Text = "Insurance Name"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboAccountActionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccountActionID.SelectedIndexChanged
        Me.NewBalance()
    End Sub

    Private Sub nbxAccountAmount_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbxAccountAmount.Leave
        Me.CalculateAccountChange()
    End Sub

    Private Sub nbxAccountAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxAccountAmount.TextChanged
        Me.NewBalance()
    End Sub

    Private Sub NewBalance()

        Dim oAccounts As New SyncSoft.SQLDb.Accounts()
        Dim oAccountActionID As New LookupDataID.AccountActionID()

        Try

            Dim accountActionID As String = StringValueMayBeEnteredIn(Me.cboAccountActionID, "Account Action!")
            If String.IsNullOrEmpty(accountActionID) Then
                Me.nbxAccountBalance.Clear()
                Return
            End If

            Dim newBalance As Decimal
            Dim amount As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmount, False)

            If accountActionID.ToUpper().Equals(oAccountActionID.Credit.ToUpper()) Then
                newBalance = oAccounts.NewBalance(amount, 0)
            Else : newBalance = oAccounts.NewBalance(0, amount)
            End If

            Me.nbxAccountBalance.Value = FormatNumber(newBalance, AppData.DecimalPlaces)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub cboAccountCurrenciesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccountCurrenciesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboAccountCurrenciesID, "Currency!")
            If String.IsNullOrEmpty(currenciesID) Then Return

            Me.SetAccountCurrencyControls(currenciesID)
            Me.CalculateAccountChange()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetAccountCurrencyControls(ByVal currenciesID As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim exchangeRate As Decimal = GetExchangeRateBuying(currenciesID)

            If currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                Me.nbxAccountExchangeRate.Value = "1.00"
                Me.nbxAccountExchangeRate.Enabled = False
                Me.btnAccountExchangeRate.Enabled = False
                Me.nbxAccountAmount.Enabled = False
                Me.nbxAccountAmount.BackColor = SystemColors.Info

            ElseIf exchangeRate > 0 Then
                If exchangeRate >= 1 Then
                    Me.nbxAccountExchangeRate.Value = FormatNumber(exchangeRate, AppData.DecimalPlaces)
                Else : Me.nbxAccountExchangeRate.Value = exchangeRate.ToString()
                End If
                Me.nbxAccountExchangeRate.Enabled = False
                Me.btnAccountExchangeRate.Enabled = True
                Me.nbxAccountAmount.Enabled = False
                Me.nbxAccountAmount.BackColor = SystemColors.Info

            Else
                Me.nbxAccountExchangeRate.Value = String.Empty
                Me.nbxAccountExchangeRate.Enabled = True
                Me.btnAccountExchangeRate.Enabled = True
                Me.nbxAccountAmount.Enabled = True
                Me.nbxAccountAmount.BackColor = SystemColors.Window
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.btnAccountExchangeRate.Enabled Then Security.Apply(Me.btnAccountExchangeRate, AccessRights.All)
            Me.stbAccountChange.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnAccountExchangeRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountExchangeRate.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim fExchangeRates As New frmExchangeRates()
            fExchangeRates.ShowDialog()

            Me.cboAccountCurrenciesID_SelectedIndexChanged(sender, EventArgs.Empty)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub CalculateAccountAmount()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxAccountAmount.Clear()


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountExchangeRate, False)

            Dim amount As Decimal = amountTendered * exchangeRate
            Me.nbxAccountAmount.Text = FormatNumber(amount, AppData.DecimalPlaces)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub


    Private Sub CalculateAccountChange()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbAccountChange.Clear()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim amount As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmount, True)
            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountExchangeRate, False)

            Dim change As Decimal = amountTendered * exchangeRate - amount
            Me.stbAccountChange.Text = FormatNumber(change, AppData.DecimalPlaces)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub nbxAccountAmountTendered_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxAccountAmountTendered.TextChanged
        Me.CalculateAccountAmount()
    End Sub

    Private Sub nbxAccountAmountTendered_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxAccountAmountTendered.Leave
        Me.CalculateAccountChange()
    End Sub

    Private Sub nbxAccountExchangeRate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbxAccountExchangeRate.TextChanged
        Me.CalculateAccountAmount()
    End Sub

    Private Sub nbxAccountExchangeRate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxAccountExchangeRate.Leave
        Me.CalculateAccountChange()
    End Sub

#End Region


#Region " Other Income "

    Private Sub cboOICurrenciesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOICurrenciesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboOICurrenciesID, "Currency!")
            If String.IsNullOrEmpty(currenciesID) Then Return

            Me.SetOICurrencyControls(currenciesID)
            Me.CalculateOIChange()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetOICurrencyControls(ByVal currenciesID As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim exchangeRate As Decimal = GetExchangeRateBuying(currenciesID)

            If currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                Me.nbxOIExchangeRate.Value = "1.00"
                Me.nbxOIExchangeRate.Enabled = False
                Me.btnOIExchangeRate.Enabled = False
                Me.nbxOIAmount.Enabled = False
                Me.nbxOIAmount.BackColor = SystemColors.Info

            ElseIf exchangeRate > 0 Then
                If exchangeRate >= 1 Then
                    Me.nbxOIExchangeRate.Value = FormatNumber(exchangeRate, AppData.DecimalPlaces)
                Else : Me.nbxOIExchangeRate.Value = exchangeRate.ToString()
                End If
                Me.nbxOIExchangeRate.Enabled = False
                Me.btnOIExchangeRate.Enabled = True
                Me.nbxOIAmount.Enabled = False
                Me.nbxOIAmount.BackColor = SystemColors.Info

            Else
                Me.nbxOIExchangeRate.Value = String.Empty
                Me.nbxOIExchangeRate.Enabled = True
                Me.btnOIExchangeRate.Enabled = True
                Me.nbxOIAmount.Enabled = True
                Me.nbxOIAmount.BackColor = SystemColors.Window
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.btnOIExchangeRate.Enabled Then Security.Apply(Me.btnOIExchangeRate, AccessRights.All)
            Me.stbOIChange.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnOIExchangeRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOIExchangeRate.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim fExchangeRates As New frmExchangeRates()
            fExchangeRates.ShowDialog()

            Me.cboOICurrenciesID_SelectedIndexChanged(sender, EventArgs.Empty)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub CalculateOIAmount()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxOIAmount.Clear()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxOIAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxOIExchangeRate, False)

            Dim amount As Decimal = amountTendered * exchangeRate
            Me.nbxOIAmount.Text = FormatNumber(amount, AppData.DecimalPlaces)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculateOIChange()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbOIChange.Clear()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim amount As Decimal = DecimalMayBeEnteredIn(Me.nbxOIAmount, True)
            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxOIAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxOIExchangeRate, False)

            Dim change As Decimal = amountTendered * exchangeRate - amount
            Me.stbOIChange.Text = FormatNumber(change, AppData.DecimalPlaces)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub nbxOIAmountTendered_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxOIAmountTendered.TextChanged
        Me.CalculateOIAmount()
    End Sub

    Private Sub nbxOIAmountTendered_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxOIAmountTendered.Leave
        Me.CalculateOIChange()
    End Sub

    Private Sub nbxOIExchangeRate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbxOIExchangeRate.TextChanged
        Me.CalculateOIAmount()
    End Sub

    Private Sub nbxOIExchangeRate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxOIExchangeRate.Leave
        Me.CalculateOIChange()
    End Sub

    Private Sub SetNextIncomeNo()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oOtherIncome As New SyncSoft.SQLDb.OtherIncome()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("OtherIncome", "IncomeNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Me.stbIncomeNo.Text = oOtherIncome.GetNextIncomeID.ToString().PadLeft(paddingLEN, paddingCHAR)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub txtIncomeNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbIncomeNo.Enter
        Me.SetNextIncomeNo()
    End Sub

#End Region

#Region " Refunds "

    Private Sub SetNextRefundNo(ByVal receiptNo As String)

        Try

            Dim oRefunds As New SyncSoft.SQLDb.Refunds()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Refunds", "RefundNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim refundID As String = oRefunds.GetNextRefundID(receiptNo).ToString()
            refundID = refundID.PadLeft(paddingLEN, paddingCHAR)

            Me.stbRefundNo.Text = FormatText(receiptNo + refundID.Trim(), "Refunds", "RefundNo")

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub ClearRefundsControls()

        Me.stbPayeeName.Clear()
        Me.stbRefundPayDate.Clear()
        Me.stbRefundAmountPaid.Clear()
        Me.stbAmountRefunded.Clear()
        Me.nbxToRefundAmount.Clear()
        Me.nbxTotalRefundAmount.Clear()
        Me.stbRefundNotes.Clear()
        Me.nbxRefundOutstandingBalance.Value = String.Empty
        ErrProvider.SetError(Me.nbxRefundOutstandingBalance, String.Empty)
        Me.nbxRefundAccountBalance.Value = String.Empty
        ErrProvider.SetError(Me.nbxRefundAccountBalance, String.Empty)
        Me.stbRefundNo.Clear()
        Me.dtpRefundDate.Value = Today
        Me.dtpRefundDate.Checked = False
        dgvPaymentRefunds.Rows.Clear()
    End Sub

    Private Sub ShowPayments(ByVal receiptNo As String)

        Dim oPayments As New SyncSoft.SQLDb.Payments()
        Dim oPayTypeID As New LookupDataID.PayTypeID()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim outstandingBalanceErrorMSG As String = "This patient has offered/done service(s) with pending payment. " +
                                                      ControlChars.NewLine + "Please advice accordingly!"
            Dim debitBalanceErrorMSG As String = "Debit balance should be cleared first!"

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim payments As DataTable = oPayments.GetPayments(receiptNo).Tables("Payments")
            Dim row As DataRow = payments.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbRefundReceiptNo.Text = FormatText(receiptNo, "Payments", "ReceiptNo")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbPayeeName.Text = StringEnteredIn(row, "PayeeName")
            Me.stbRefundPayDate.Text = FormatDate(DateEnteredIn(row, "PayDate"))
            Me.stbRefundAmountPaid.Text = FormatNumber(DecimalMayBeEnteredIn(row, "AmountPaid"), AppData.DecimalPlaces)
            Me.stbAmountRefunded.Text = FormatNumber(DecimalMayBeEnteredIn(row, "AmountRefunded"), AppData.DecimalPlaces)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(row, "OutstandingBalance")
            Me.nbxRefundOutstandingBalance.Value = FormatNumber(outstandingBalance, AppData.DecimalPlaces)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If outstandingBalance > 0 Then
                ErrProvider.SetError(Me.nbxRefundOutstandingBalance, outstandingBalanceErrorMSG)
            Else : ErrProvider.SetError(Me.nbxRefundOutstandingBalance, String.Empty)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim payeeNo As String = StringEnteredIn(row, "PayeeNo")
            Dim payTypeID As String = StringEnteredIn(row, "PayTypeID")
            Me.visitTypeID = StringEnteredIn(row, "VisitTypeID")

            If payTypeID.ToUpper().Equals(oPayTypeID.VisitBill.ToUpper()) Then
                billModesID = oBillModesID.Cash

            ElseIf payTypeID.ToUpper().Equals(oPayTypeID.ExtraBill.ToUpper()) Then
                billModesID = oBillModesID.Cash

            ElseIf payTypeID.ToUpper().Equals(oPayTypeID.IPDRoundBill.ToUpper()) Then
                billModesID = oBillModesID.Cash

            ElseIf payTypeID.ToUpper().Equals(oPayTypeID.AccountBill.ToUpper()) Then
                billModesID = oBillModesID.Account

            ElseIf payTypeID.ToUpper().Equals(oPayTypeID.InsuranceBill.ToUpper()) Then
                billModesID = oBillModesID.Insurance

            Else : billModesID = String.Empty
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim accountBalance As Decimal = GetAccountBalance(billModesID, payeeNo)
            Me.nbxRefundAccountBalance.Value = FormatNumber(accountBalance, AppData.DecimalPlaces)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If accountBalance < 0 Then
                ErrProvider.SetError(Me.nbxRefundAccountBalance, debitBalanceErrorMSG)
            Else : ErrProvider.SetError(Me.nbxRefundAccountBalance, String.Empty)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetNextRefundNo(receiptNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim payDate As Date = DateEnteredIn(row, "PayDate")
            Me.dtpRefundDate.Value = payDate
            Me.dtpRefundDate.Checked = GetShortDate(payDate) >= GetShortDate(Today)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ApplySecurity()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub stbRefundNo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim receiptNo As String = RevertText(StringMayBeEnteredIn(Me.stbRefundReceiptNo))
            If String.IsNullOrEmpty(receiptNo) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetNextRefundNo(receiptNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub




   
#End Region

#Region " Expenditure "

    Private Sub SetNextExpenditureNo()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oExpenditure As New SyncSoft.SQLDb.Expenditure()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Expenditure", "ExpenditureNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Me.stbExpenditureNo.Text = oExpenditure.GetNextExpenditureID.ToString().PadLeft(paddingLEN, paddingCHAR)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub txtExpenditureNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbExpenditureNo.Enter
        Me.SetNextExpenditureNo()
    End Sub

#End Region

#Region " Save Methods "

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Select Case Me.tbcCashier.SelectedTab.Name

            Case Me.tpgCashPayment.Name
                Me.SaveCashPayment()

            Case Me.tpgBillFormPayment.Name

                Select Case Me.tbcBillFormPayment.SelectedTab.Name

                    Case tpgBillingForm.Name

                        Me.SaveBillFormPayment()

                    Case tpgPendingBill.Name

                End Select

            Case Me.tpgBillsPayment.Name
                Me.SaveBillsPayment()

            Case Me.tpgCreditBillFormPayment.Name
                Me.SaveCreditBillFormPayment()

            Case Me.tpgManageAccounts.Name
                Me.SaveAccounts()

            Case Me.tpgOtherIncome.Name
                Me.SaveOtherIncome()

            Case Me.tpgRefunds.Name
                Me.SaveRefunds()

            Case Me.tpgExpenditure.Name
                Me.SaveExpenditure()

        End Select

        If InitOptions.EnableOnlyPrescExtrasConsAtSelfRequest Then
            If Not String.IsNullOrEmpty(defaultVisitNo) Then Me.Close()
        End If

    End Sub

    Private Sub SaveCashPayment()

        Dim message As String
        Dim oPayments As New SyncSoft.SQLDb.Payments()
        Dim oVariousOptions As New VariousOptions()

        Dim oLookupData As New SyncSoft.Lookup.SQL.LookupData()
        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oCurrenciesID As New LookupDataID.CurrenciesID()
        Dim oAccountGroupID As New LookupDataID.AccountGroupID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oExtraItemCodes As New LookupDataID.ExtraItemCodes()
        Dim oInvoices As New SyncSoft.SQLDb.Invoices()
        Dim oReceiptInvoiceDetails As New SyncSoft.SQLDb.ReceiptInvoiceDetails()

        Dim lPayments As New List(Of DBConnect)
        Dim linvoices As New List(Of DBConnect)
        Dim lInvoiceDetails As New List(Of DBConnect)
        Dim lAccountBalance As New List(Of DBConnect)
        Dim lSendBalance As New List(Of DBConnect)
        Dim lPaymentDetails As New List(Of DBConnect)
        Dim lItems As New List(Of DBConnect)
        Dim lItemsCASH As New List(Of DBConnect)
        Dim lReceiptInvoiceDetails As New List(Of DBConnect)
        Dim transactions As New List(Of TransactionList(Of DBConnect))
       
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim receiptNo As String = RevertText(StringEnteredIn(Me.stbReceiptNo, "Receipt No!"))
            Dim payDate As Date = DateEnteredIn(Me.dtpPayDate, "Pay Date!")
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()
            Dim copayTypeID As String = GetLookupDataID(LookupObjects.CoPayType, coPayType)

            Dim cashAccount As String = GetLookupDataDes(oBillModesID.Cash)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim accountBalance As Decimal = GetAccountBalance(oBillModesID.Cash, patientNo)
            Me.ResetCashAccountBalanceCTRL(accountBalance)
            Dim change As Decimal = DecimalMayBeEnteredIn(Me.stbChange, True)
            Dim payMode As String = StringValueEnteredIn(Me.cboPayModesID, "Pay Modes!")
            Dim payCurrencyID As String = StringValueEnteredIn(Me.cboCurrenciesID, "Currency!")
            Dim amountTendered As Decimal = DecimalEnteredIn(Me.nbxAmountTendered, True, "Amount Tendered!")
            Dim exchangeRate As Decimal = Me.nbxExchangeRate.GetDecimal(False)
            Dim withholdingTax As Decimal = 0
            Dim grandDiscount As Decimal = 0
            Dim invoiceAmount As Decimal = 0
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvPaymentDetails.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If Me.dgvPaymentDetails.RowCount < 1 OrElse nonSelected Then Throw New ArgumentException("Must include at least one entry on payment details!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oVariousOptions.AllowAccessCashServices Then

                Dim hasPendingItems As Boolean = False
                For Each row As DataGridViewRow In Me.dgvPaymentDetails.Rows
                    If row.IsNewRow Then Exit For
                    If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, row.Index).Value) = True Then
                        Dim itemStatus As String = StringMayBeEnteredIn(row.Cells, Me.colItemStatus)
                        If itemStatus.ToUpper().Equals(GetLookupDataDes(oItemStatusID.Pending).ToUpper()) Then
                            hasPendingItems = True
                            Exit For
                        End If
                    End If
                    hasPendingItems = False
                Next

                If hasPendingItems Then
                    If oVariousOptions.AllowProcessingPendingItems Then
                        message = "You have chosen to receipt pending service(s), changes at service point will not be allowed after this action. " +
                             ControlChars.NewLine + "Are you sure you want to save?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
                    Else : message = "The system is set not to allow receipting pending service(s). Please contact your administrator!"
                        Throw New ArgumentException(message)
                    End If

                End If

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim hasNegativeAmount As Boolean = False

            For Each row As DataGridViewRow In Me.dgvPaymentDetails.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    Dim amount As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colAmount)
                    If amount < 0 Then
                        hasNegativeAmount = True
                        Exit For
                    End If
                End If
                hasNegativeAmount = False
            Next

            If hasNegativeAmount Then
                Dim count As Integer = 0
                For Each row As DataGridViewRow In Me.dgvPaymentDetails.Rows
                    If row.IsNewRow Then Exit For
                    If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, row.Index).Value) = True Then count += 1
                Next
                If count > 1 Then Throw New ArgumentException("Negative amount usually meant for a refund, cannot be receipted with other item(s)!")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If accountBalance < 0 Then
                message = "Cash Account has a debit balance. It is recommended to get this account credited before continuing. " +
                     ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            End If
            ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)
            ErrProvider.SetError(Me.nbxCashAccountBalance, String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If payMode.Equals(oPayModesID.Cheque()) OrElse payMode.Equals(oPayModesID.Visa()) OrElse
                payMode.Equals(oPayModesID.ElectronicFundTransfer()) Then

                Dim documentNo As String = StringEnteredIn(stbDocumentNo, "Documment No")
                If (String.IsNullOrEmpty(bankNameID) OrElse String.IsNullOrEmpty(bankAccountNo)) Then
                    MsgBox(GetLookupDataDes(payMode) + " Requires Bank Details to Continue. Please provide the bank Information")
                    Dim ofrmBankPaymentDetails As New frmBankPaymentDetails(payMode)
                    ofrmBankPaymentDetails.ShowDialog()
                    Me.bankNameID = ofrmBankPaymentDetails.BankName()
                    Me.bankAccountNo = ofrmBankPaymentDetails.AccountNo()

                    If String.IsNullOrEmpty(Me.bankNameID) OrElse String.IsNullOrEmpty(Me.bankAccountNo) Then Return
                    Dim registerID As String = RevertText(Me.GetNextRegisterNo())
                    transactions.Add(New TransactionList(Of DBConnect)(GetBankingDetails(receiptNo, documentNo, payMode), Action.Save))

                    If payMode.Equals(oPayModesID.Visa()) OrElse payMode.Equals(oPayModesID.ElectronicFundTransfer()) Then
                        transactions.Add(New TransactionList(Of DBConnect)(GetBankingRegisterList(registerID, Me.oCollectionSourceTyPyID.PatientPayments, amountTendered,
                                                                                              payCurrencyID, exchangeRate, payDate), Action.Save))
                        transactions.Add(New TransactionList(Of DBConnect)(GetBankingDetailList(registerID, amountTendered, payMode, documentNo), Action.Save))
                    End If
                End If
            End If
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oPayments
                .ReceiptNo = receiptNo
                If copayTypeID.ToUpper().Equals(oCopayTypeID.Percent().ToUpper()) OrElse copayTypeID.Equals(oCopayTypeID.Value().ToUpper()) Then
                    .PayTypeID = oPayTypeID.VisitBill()
                ElseIf copayTypeID.ToUpper().Equals(oCopayTypeID.NA().ToUpper()) Then
                    .PayTypeID = oPayTypeID.VisitBill()
                End If
                .PayNo = visitNo
                .ClientFullName = StringEnteredIn(Me.stbFullName)
                .PayDate = payDate
                .PayModesID = StringValueEnteredIn(Me.cboPayModesID, "Pay Modes!")
                .DocumentNo = StringMayBeEnteredIn(Me.stbDocumentNo)
                .AmountWords = StringMayBeEnteredIn(Me.stbAmountWords)
                .Notes = StringMayBeEnteredIn(Me.stbNotes)
                .CurrenciesID = StringValueEnteredIn(Me.cboCurrenciesID, "Currency!")
                .WithholdingTax = withholdingTax
                .GrandDiscount = grandDiscount
                .AmountTendered = DecimalEnteredIn(Me.nbxAmountTendered, True, "Amount Tendered!")
                .ExchangeRate = Me.nbxExchangeRate.GetDecimal(False)
                .Change = change
                .SendBalanceToAccount = Me.chkSendBalanceToAccount.Checked
                .UseAccountBalance = Me.chkUseAccountBalance.Checked
                .VisitTypeID = oVisitTypeID.OutPatient
                .FilterNo = String.Empty
                .LoginID = CurrentUser.LoginID
            End With

            ValidateEntriesIn(Me.tpgCashPayment)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lPayments.Add(oPayments)

            


            If change < 0 AndAlso Not Me.chkSendBalanceToAccount.Checked Then

                Me.nbxAmountTendered.Focus()
                Throw New ArgumentException("Amount tendered can’t be less than total bill!")

            ElseIf payDate < Today Then

                message = "You have selected a pay date that is before today, " +
                            "this will result in this receipt’s total bill not showing in today’s cash collections if searched via pay date." +
                            ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkUseAccountBalance.Checked Then

                Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbTotalAmountPaid, True)
                Dim creditBalance As Decimal = totalBill

                If accountBalance <= 0 Then

                    message = "Patient's current balance of " + FormatNumber(accountBalance, AppData.DecimalPlaces) +
                            " can’t be used to offset this bill"
                    Throw New ArgumentException(message)

                ElseIf totalBill > accountBalance AndAlso accountBalance > 0 Then

                    creditBalance = accountBalance

                    message = "Patient's current balance of " + FormatNumber(accountBalance, AppData.DecimalPlaces) +
                              " is insufficient to cater for this bill. " + ControlChars.NewLine +
                              "Would you like the system to use what’s on the patients’ account? "

                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    message = "You have chosen to receive part of this payment from the Patient's account that will eventually be debited by " +
                        FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"

                Else : message = "You have chosen to receive this payment from the Patient's account that will eventually be debited by " +
                    FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Using oAccounts As New SyncSoft.SQLDb.Accounts()

                    With oAccounts
                        .TranNo = GetNextTranNo()
                        .AccountBillModesID = oBillModesID.Cash
                        .AccountBillNo = patientNo
                        .ClientFullName = StringEnteredIn(Me.stbFullName)
                        .TranDate = payDate
                        .PayModesID = StringValueEnteredIn(Me.cboPayModesID, "Pay Modes!")
                        .AccountActionID = oAccountActionID.Debit
                        .Amount = creditBalance
                        .DocumentNo = StringMayBeEnteredIn(Me.stbDocumentNo)
                        .AmountWords = NumberToWords(.Amount)
                        .CurrenciesID = oCurrenciesID.UgandaShillings
                        .AmountTendered = .Amount
                        .ExchangeRate = 1
                        .Change = 0
                        .AccountGroupID = oAccountGroupID.BillClearance
                        .Notes = "Payment under receipt no: " + receiptNo
                        .EntryModeID = oEntryModeID.System
                        .ReferenceNo = receiptNo
                        .LoginID = CurrentUser.LoginID
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lAccountBalance.Add(oAccounts)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End With

                End Using

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                transactions.Add(New TransactionList(Of DBConnect)(lAccountBalance, Action.Save))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            If Me.chkSendBalanceToAccount.Checked Then

                Dim accountActionID As String
                Dim creditBalance As Decimal = change
                Dim accountGroupID As String = oAccountGroupID.NA

                If change < 0 Then

                    accountActionID = oAccountActionID.Debit
                    creditBalance = -change
                    accountGroupID = oAccountGroupID.BillClearance

                    If Not oVariousOptions.AllowPartialCashPayment Then
                        message = "The system is set not to allow partial payment!"
                        Throw New ArgumentException(message)

                    Else : message = "You have chosen to send balance to the Patient's account that will eventually be debited by " +
                        FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"
                    End If

                ElseIf change = 0 Then

                    message = "You have chosen to send balance to account. The system does not allow any account action with zero balance sent!"
                    Throw New ArgumentException(message)

                Else
                    accountActionID = oAccountActionID.Credit
                    creditBalance = change
                    accountGroupID = oAccountGroupID.LackofChange

                    message = "You have chosen to send balance to the Patient's account that will eventually be credited by " +
                        FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"

                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Using oAccounts As New SyncSoft.SQLDb.Accounts()

                    With oAccounts
                        If Me.chkUseAccountBalance.Checked Then
                            .TranNo = GetNextTranNo(1)
                        Else : .TranNo = GetNextTranNo()
                        End If
                        .ClientFullName = StringEnteredIn(Me.stbFullName)
                        .AccountBillModesID = oBillModesID.Cash
                        .AccountBillNo = patientNo
                        .TranDate = payDate
                        .PayModesID = StringValueEnteredIn(Me.cboPayModesID, "Pay Modes!")
                        .AccountActionID = accountActionID
                        .Amount = creditBalance
                        .DocumentNo = StringMayBeEnteredIn(Me.stbDocumentNo)
                        .AmountWords = NumberToWords(.Amount)
                        .CurrenciesID = oCurrenciesID.UgandaShillings
                        .AmountTendered = .Amount
                        .ExchangeRate = 1
                        .Change = 0
                        .AccountGroupID = accountGroupID
                        .Notes = "Payment under receipt no: " + receiptNo
                        .ReferenceNo = receiptNo
                        .EntryModeID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lSendBalance.Add(oAccounts)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End With

                End Using

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                transactions.Add(New TransactionList(Of DBConnect)(lSendBalance, Action.Save))
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

            If Not Me.chkUseAccountBalance.Checked AndAlso Not Me.chkSendBalanceToAccount.Checked Then

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                message = "You are about to perform an irreversible action please ensure that you have all the payment " +
                    "(Total Bill: " + Me.stbTotalAmountPaid.Text + ", Receipt No: " + Me.stbReceiptNo.Text + ") " +
                    "with you before continuing." + ControlChars.NewLine + "Are you sure you want to save?"

                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvPaymentDetails.RowCount - 1

                If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPaymentDetails.Rows(rowNo).Cells
                    Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode, "item!")
                    Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID)
                    Dim prevInvoiceNo As String = StringMayBeEnteredIn(cells, Me.colInvoiceNo)

                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity)

                    Using oPaymentDetails As New SyncSoft.SQLDb.PaymentDetails()
                        Me.CheckAvaliableToPayForDrugs(itemCode, itemCategoryID, quantity)
                        With oPaymentDetails
                            .ReceiptNo = receiptNo
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .Quantity = quantity
                            If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                                 (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                                .UnitPrice = Math.Abs(DecimalEnteredIn(cells, Me.colUnitPrice, True, "Unit Price!"))
                            Else : .UnitPrice = DecimalEnteredIn(cells, Me.colUnitPrice, False, "Unit Price!")
                            End If
                            .Discount = DecimalEnteredIn(cells, Me.colDiscount, True, "discount!")
                            If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                                 (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                                .Amount = DecimalEnteredIn(cells, Me.colAmount, True, "amount!")
                            Else : .Amount = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")
                            End If
                            If String.IsNullOrEmpty(prevInvoiceNo) Then invoiceAmount += .Amount
                        End With

                        lPaymentDetails.Add(oPaymentDetails)


                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Not oVariousOptions.AllowDirectDiscountCashPayment AndAlso oPaymentDetails.Discount > 0 Then
                            message = "The system is set not to allow a discount. Please contact your administrator!"
                            Throw New ArgumentException(message)

                        ElseIf oPaymentDetails.Discount > 0 Then
                            message = "You have chosen to give a discount that needs authorization. " +
                                ControlChars.NewLine + "Are you sure you want to save?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If billMode.ToUpper().Equals(cashAccount.ToUpper()) Then

                        Using oItems As New SyncSoft.SQLDb.Items()
                            With oItems
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = itemCategoryID
                                .LastUpdate = payDate
                                .PayStatusID = oPayStatusID.PaidFor
                                .LoginID = CurrentUser.LoginID
                                .ItemStatusID = String.Empty
                            End With
                            lItems.Add(oItems)
                        End Using

                    Else

                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = itemCategoryID
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using

                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Generate an Invoice for Cash Payments


            lInvoiceDetails = GetInvoiceDetails(visitNo, copayTypeID)

            If lInvoiceDetails.Count() > 0 Then



                With oInvoices

                    .InvoiceNo = RevertText(StringEnteredIn(Me.stbInvoiceNo, "Invoice No!"))
                    If copayTypeID.ToUpper().Equals(oCopayTypeID.Percent().ToUpper()) OrElse copayTypeID.Equals(oCopayTypeID.Value().ToUpper()) Then
                        .PayTypeID = oPayTypeID.VisitBillCASH()
                    ElseIf copayTypeID.ToUpper().Equals(oCopayTypeID.NA().ToUpper()) Then
                        .PayTypeID = oPayTypeID.VisitBill()
                    End If
                    .PayNo = visitNo
                    .InvoiceDate = payDate
                    .StartDate = payDate
                    .EndDate = payDate
                    .AmountWords = NumberToWords(invoiceAmount)
                    .VisitTypeID = oVisitTypeID.OutPatient
                    .Locked = True
                    .EntryModeID = oEntryModeID.System()
                    .LoginID = CurrentUser.LoginID

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ValidateEntriesIn(Me)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End With


                With oReceiptInvoiceDetails

                    .InvoiceNo = RevertText(StringEnteredIn(Me.stbInvoiceNo, "InvoiceNo!"))
                    .ReceiptNo = RevertText(StringEnteredIn(Me.stbReceiptNo, "ReceiptNo!"))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ValidateEntriesIn(Me)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End With
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                linvoices.Add(oInvoices)

                lReceiptInvoiceDetails.Add(oReceiptInvoiceDetails)


                transactions.Add(New TransactionList(Of DBConnect)(linvoices, Action.Save))
                transactions.Add(New TransactionList(Of DBConnect)(lInvoiceDetails, Action.Save))
                transactions.Add(New TransactionList(Of DBConnect)(lReceiptInvoiceDetails, Action.Save))
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me.tpgCashPayment, ErrProvider)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lPayments, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lPaymentDetails, Action.Save))

            If billMode.ToUpper().Equals(cashAccount.ToUpper()) Then
                transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Update))
            Else : transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Update))
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim lservicePoints As New List(Of String)
            Dim oServicePoint As New LookupDataID.ServicePointID()
            Dim lWaitingPatient As New List(Of DBConnect)

            ''''make queue
            lWaitingPatient = GetQueuesList(visitNo, oServicePoint.Cashier(), Me.PriorityID, lservicePoints)
            transactions.Add(New TransactionList(Of DBConnect)(lWaitingPatient, Action.Save))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            DoTransactions(transactions)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oVariousOptions.SMSNotificationAtCashPayment Then
                If stbPhoneNo.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(stbPhoneNo.Text) Then
                    Dim CPpatientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
                    Dim oPatient As New SyncSoft.SQLDb.Patients()
                    oPatient.GetPatient(CPpatientNo)
                    Dim productOwner As String = AppData.ProductOwner
                    Dim recipients As String = stbPhoneNo.Text
                    Dim txtmessage As String = ("Hi" + " " + oPatient.FirstName.ToString + " " + "payment of " + " " + stbTotalAmountPaid.Text + " " + "has been received by" + " " + productOwner + " " + "ReceiptNo " + " " + RevertText(stbReceiptNo.Text) + " " + "Thx for paying" + " " + "-Via ClinicMaster")
                    SaveTextMessage(txtmessage, recipients, Now, oVariousOptions.SMSLifeSpanCashier)
                End If
            End If


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.chkPrintReceiptOnSaving.Checked Then
                message = "You have not checked Print Receipt On Saving. " + ControlChars.NewLine + "Would you want a receipt printed?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintCashReceipt(True)
            Else : Me.PrintCashReceipt(True)
            End If


            If InitOptions.OpenPharmacyAfterCashier Then
                Dim oItems As New SyncSoft.SQLDb.Items()



                Dim drugsToIssue As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Drug, oItemStatusID.Pending).Tables("Items")
                Dim consumablesToIssue As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Consumable, oItemStatusID.Pending).Tables("Items")

                If drugsToIssue.Rows.Count < 1 And consumablesToIssue.Rows.Count > 0 Then
                    Dim fIssueConsumables As New frmIssueConsumables(visitNo)
                    fIssueConsumables.ShowDialog()

                ElseIf drugsToIssue.Rows.Count > 0 And consumablesToIssue.Rows.Count < 1 Then
                    Dim fPharmacy As New frmPharmacy(visitNo)
                    fPharmacy.ShowDialog()


                ElseIf drugsToIssue.Rows.Count > 0 And consumablesToIssue.Rows.Count > 0 Then
                    Dim fPharmacy As New frmPharmacy(visitNo)
                    fPharmacy.ShowDialog()


                End If

            End If


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim allSelected As Boolean = True

            For Each row As DataGridViewRow In Me.dgvPaymentDetails.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, row.Index).Value) = False Then
                    allSelected = False
                    Me.ShowCashPatientDetails(visitNo)
                    Me.LoadCashItems(visitNo)
                    Me.SetNextReceiptNo(Me.stbReceiptNo)
                    Me.SetNextInvoiceNo(Me.stbInvoiceNo)
                    Exit For
                End If
                allSelected = True
            Next

            If allSelected Then
                ResetControlsIn(Me.tpgCashPayment)
                ResetControlsIn(Me.pnlNavigateVisits)
                LoadLookupDataCombo(Me.cboPayModesID, LookupObjects.PayModes)
                LoadLookupDataCombo(Me.cboCurrenciesID, LookupObjects.Currencies)
                Me.cboPayModesID.SelectedValue = oPayModesID.Cash
                Me.cboCurrenciesID.SelectedValue = oCurrenciesID.UgandaShillings
                Me.dgvPaymentDetails.Rows.Clear()
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.chkUseAccountBalance.Checked = False
            Me.chkSendBalanceToAccount.Checked = False
            Me.chkPrintReceiptOnSaving.Checked = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowWaitingCashPayments()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            If ex.Message.Contains("The Receipt No:") Then
              
                Me.SetNextReceiptNo(Me.stbReceiptNo)
                Me.btnSave.PerformClick()


            ElseIf ex.Message.Contains("The Invoice No:") OrElse ex.Message.EndsWith("already exists") Then
                
                Me.SetNextInvoiceNo(Me.stbInvoiceNo)
                Me.btnSave.PerformClick()

            Else : ErrorMessage(ex)
            End If



        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveBillFormPayment()

        Dim message As String
        Dim oPayments As New SyncSoft.SQLDb.Payments()
        Dim oVariousOptions As New VariousOptions()

        Dim oLookupData As New SyncSoft.Lookup.SQL.LookupData()
        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oCurrenciesID As New LookupDataID.CurrenciesID()
        Dim oAccountGroupID As New LookupDataID.AccountGroupID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim oVisitTypeID As New LookupDataID.VisitTypeID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oExtraItemCodes As New LookupDataID.ExtraItemCodes()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim oInvoices As New SyncSoft.SQLDb.Invoices()
        Dim oReceiptInvoiceDetails As New SyncSoft.SQLDb.ReceiptInvoiceDetails()

        Dim linvoices As New List(Of DBConnect)
        Dim lInvoiceExtraBillItems As New List(Of DBConnect)


        Dim lPayments As New List(Of DBConnect)
        Dim lAccountBalance As New List(Of DBConnect)
        Dim lSendBalance As New List(Of DBConnect)
        Dim lIPDItems As New List(Of DBConnect)
        Dim lPaymentExtraBillItems As New List(Of DBConnect)
        Dim lExtraBillItems As New List(Of DBConnect)
        Dim lExtraBillItemsCASH As New List(Of DBConnect)
        Dim lReceiptInvoiceDetails As New List(Of DBConnect)
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbBFPVisitNo, "Visit Number!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbBFPPatientNo))
            Dim receiptNo As String = RevertText(StringEnteredIn(Me.stbBFPReceiptNo, "Receipt No!"))
            Dim payDate As Date = DateEnteredIn(Me.dtpBFPPayDate, "Pay Date!")
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbBFPCoPayType)
            Dim coPayPercent As Single = Me.nbxBFPCoPayPercent.GetSingle()
            Dim copayTypeID As String = GetLookupDataID(LookupObjects.CoPayType, coPayType)

            Dim cashAccount As String = GetLookupDataDes(oBillModesID.Cash)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBFPBillMode)
            Dim accountBalance As Decimal = GetAccountBalance(oBillModesID.Cash, patientNo)
            Me.ResetBFPCashAccountBalanceCTRL(accountBalance)
            Dim change As Decimal = DecimalMayBeEnteredIn(Me.stbBFPChange, True)
            Dim payMode As String = StringValueEnteredIn(Me.cboBFPPayModesID, "Pay Modes!")
            Dim payCurrencyID As String = StringValueEnteredIn(Me.cboBFPCurrenciesID, "Currency!")
            Dim amountTendered As Decimal = DecimalEnteredIn(Me.nbxBFPAmountTendered, True, "Amount Tendered!")
            Dim exchangeRate As Decimal = Me.nbxBFPExchangeRate.GetDecimal(False)
            Dim withholdingTax As Decimal = 0
            Dim grandDiscount As Decimal = 0
            Dim invoiceAmount As Decimal = 0
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvPaymentExtraBillItems.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPaymentExtraBillItems.Item(Me.colBFPInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If Me.dgvPaymentExtraBillItems.RowCount < 1 OrElse nonSelected Then Throw New ArgumentException("Must include at least one entry on bill form payments!")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If accountBalance < 0 Then
                message = "Cash Account has a debit balance. It is recommended to get this account credited before continuing. " +
                     ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            End If
            ErrProvider.SetError(Me.nbxBFPOutstandingBalance, String.Empty)
            ErrProvider.SetError(Me.nbxBFPCashAccountBalance, String.Empty)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If payMode.Equals(oPayModesID.Cheque()) OrElse payMode.Equals(oPayModesID.Visa()) OrElse
                payMode.Equals(oPayModesID.ElectronicFundTransfer()) Then

                Dim documentNo As String = StringEnteredIn(stbBFPDocumentNo, "Documment No")
                If (String.IsNullOrEmpty(bankNameID) OrElse String.IsNullOrEmpty(bankAccountNo)) Then
                    MsgBox(GetLookupDataDes(payMode) + " Requires Bank Details to Continue. Please provide the bank Information")
                    Dim ofrmBankPaymentDetails As New frmBankPaymentDetails(payMode)
                    ofrmBankPaymentDetails.ShowDialog()
                    Me.bankNameID = ofrmBankPaymentDetails.BankName()
                    Me.bankAccountNo = ofrmBankPaymentDetails.AccountNo()

                    If String.IsNullOrEmpty(Me.bankNameID) OrElse String.IsNullOrEmpty(Me.bankAccountNo) Then Return
                    Dim registerID As String = RevertText(Me.GetNextRegisterNo())
                    transactions.Add(New TransactionList(Of DBConnect)(GetBankingDetails(receiptNo, documentNo, payMode), Action.Save))

                    If payMode.Equals(oPayModesID.Visa()) OrElse payMode.Equals(oPayModesID.ElectronicFundTransfer()) Then
                        transactions.Add(New TransactionList(Of DBConnect)(GetBankingRegisterList(registerID, Me.oCollectionSourceTyPyID.PatientPayments, amountTendered,
                                                                                              payCurrencyID, exchangeRate, payDate), Action.Save))
                        transactions.Add(New TransactionList(Of DBConnect)(GetBankingDetailList(registerID, amountTendered, payMode, documentNo), Action.Save))
                    End If
                End If
            End If
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oPayments

                .ReceiptNo = receiptNo
                .PayTypeID = oPayTypeID.ExtraBill
                .PayNo = visitNo
                .ClientFullName = StringEnteredIn(Me.stbBFPFullName)
                .PayDate = payDate
                .PayModesID = StringValueEnteredIn(Me.cboBFPPayModesID, "Pay Modes!")
                .DocumentNo = StringMayBeEnteredIn(Me.stbBFPDocumentNo)
                .AmountWords = StringMayBeEnteredIn(Me.stbBFPAmountWords)
                .Notes = StringMayBeEnteredIn(Me.stbBFPNotes)
                .WithholdingTax = withholdingTax
                .GrandDiscount = grandDiscount
                .CurrenciesID = StringValueEnteredIn(Me.cboBFPCurrenciesID, "Currency!")
                .AmountTendered = DecimalEnteredIn(Me.nbxBFPAmountTendered, True, "Amount Tendered!")
                .ExchangeRate = Me.nbxBFPExchangeRate.GetDecimal(False)
                .Change = change
                .SendBalanceToAccount = Me.chkBFPSendBalanceToAccount.Checked
                .UseAccountBalance = Me.chkBFPUseAccountBalance.Checked
                .VisitTypeID = oVisitTypeID.InPatient
                .FilterNo = String.Empty
                .LoginID = CurrentUser.LoginID

            End With

            ValidateEntriesIn(Me.tpgBillFormPayment)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lPayments.Add(oPayments)

           


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If change < 0 AndAlso Not Me.chkBFPSendBalanceToAccount.Checked Then

                Me.nbxBFPAmountTendered.Focus()
                Throw New ArgumentException("Amount tendered can’t be less than total bill!")

            ElseIf payDate < Today Then

                message = "You have selected a pay date that is before today, " +
                            "this will result in this receipt’s total bill not showing in today’s cash collections if searched via pay date." +
                            ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Me.chkBFPUseAccountBalance.Checked Then

                Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbBFPTotalAmountPaid, True)
                Dim creditBalance As Decimal = totalBill

                If accountBalance <= 0 Then

                    message = "Patient's current balance of " + FormatNumber(accountBalance, AppData.DecimalPlaces) +
                            " can’t be used to offset this bill"
                    Throw New ArgumentException(message)

                ElseIf totalBill > accountBalance AndAlso accountBalance > 0 Then

                    creditBalance = accountBalance

                    message = "Patient's current balance of " + FormatNumber(accountBalance, AppData.DecimalPlaces) +
                              " is insufficient to cater for this bill. " + ControlChars.NewLine +
                              "Would you like the system to use what’s on the patients’ account? "

                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    message = "You have chosen to receive part of this payment from the Patient's account that will eventually be debited by " _
                          + FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"

                Else : message = "You have chosen to receive this payment from the Patient's account that will eventually be debited by " _
                          + FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Using oAccounts As New SyncSoft.SQLDb.Accounts()

                    With oAccounts
                        .TranNo = GetNextTranNo()
                        .AccountBillModesID = oBillModesID.Cash
                        .AccountBillNo = patientNo
                        .ClientFullName = StringEnteredIn(Me.stbBFPFullName)
                        .TranDate = payDate
                        .PayModesID = StringValueEnteredIn(Me.cboBFPPayModesID, "Pay Modes!")
                        .AccountActionID = oAccountActionID.Debit
                        .Amount = creditBalance
                        .DocumentNo = StringMayBeEnteredIn(Me.stbBFPDocumentNo)
                        .AmountWords = NumberToWords(.Amount)
                        .CurrenciesID = oCurrenciesID.UgandaShillings
                        .AmountTendered = .Amount
                        .ExchangeRate = 1
                        .Change = 0
                        .AccountGroupID = oAccountGroupID.BillClearance
                        .Notes = "Payment under receipt no: " + receiptNo
                        .ReferenceNo = receiptNo
                        .EntryModeID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lAccountBalance.Add(oAccounts)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End With

                End Using

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                transactions.Add(New TransactionList(Of DBConnect)(lAccountBalance, Action.Save))
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            If Me.chkBFPSendBalanceToAccount.Checked Then

                Dim accountActionID As String
                Dim creditBalance As Decimal = change
                Dim accountGroupID As String = oAccountGroupID.NA

                If change < 0 Then

                    accountActionID = oAccountActionID.Debit
                    creditBalance = -change
                    accountGroupID = oAccountGroupID.BillClearance

                    If Not oVariousOptions.AllowPartialCashPayment Then
                        message = "The system is set not to allow partial payment!"
                        Throw New ArgumentException(message)

                    Else : message = "You have chosen to send balance to the Patient's account that will eventually be debited by " +
                        FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"
                    End If

                ElseIf change = 0 Then

                    message = "You have chosen to send balance to account. The system does not allow any account action with zero balance sent!"
                    Throw New ArgumentException(message)

                Else
                    accountActionID = oAccountActionID.Credit
                    creditBalance = change
                    accountGroupID = oAccountGroupID.LackofChange

                    message = "You have chosen to send balance to the Patient's account that will eventually be credited by " +
                        FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Using oAccounts As New SyncSoft.SQLDb.Accounts()

                    With oAccounts
                        If Me.chkBFPUseAccountBalance.Checked Then
                            .TranNo = GetNextTranNo(1)
                        Else : .TranNo = GetNextTranNo()
                        End If
                        .AccountBillModesID = oBillModesID.Cash
                        .AccountBillNo = patientNo
                        .ClientFullName = StringEnteredIn(Me.stbBFPFullName)
                        .TranDate = payDate
                        .PayModesID = StringValueEnteredIn(Me.cboBFPPayModesID, "Pay Modes!")
                        .AccountActionID = accountActionID
                        .Amount = creditBalance
                        .DocumentNo = StringMayBeEnteredIn(Me.stbBFPDocumentNo)
                        .AmountWords = NumberToWords(.Amount)
                        .CurrenciesID = oCurrenciesID.UgandaShillings
                        .AmountTendered = .Amount
                        .ExchangeRate = 1
                        .Change = 0
                        .AccountGroupID = accountGroupID
                        .Notes = "Payment under receipt no: " + receiptNo
                        .EntryModeID = oEntryModeID.System
                        .ReferenceNo = receiptNo
                        .LoginID = CurrentUser.LoginID
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lSendBalance.Add(oAccounts)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End With

                End Using

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                transactions.Add(New TransactionList(Of DBConnect)(lSendBalance, Action.Save))
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

            If Not Me.chkBFPUseAccountBalance.Checked AndAlso Not Me.chkBFPSendBalanceToAccount.Checked Then

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                message = "You are about to perform an irreversible action please ensure that you have all the payment " +
                    "(Total Bill: " + Me.stbBFPTotalAmountPaid.Text + ", Receipt No: " + Me.stbBFPReceiptNo.Text + ") " +
                    "with you before continuing." + ControlChars.NewLine + "Are you sure you want to save?"

                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvPaymentExtraBillItems.RowCount - 1

                If CBool(Me.dgvPaymentExtraBillItems.Item(Me.colBFPInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPaymentExtraBillItems.Rows(rowNo).Cells
                    Dim extraBillNo As String = RevertText(StringEnteredIn(cells, Me.colBFPExtraBillNo, "bill no!"))
                    Dim itemCode As String = StringEnteredIn(cells, Me.colBFPItemCode, "bill form item!")
                    Dim prevInvoiceNo As String = StringMayBeEnteredIn(cells, Me.colBFPInvoiceNo)
                    Dim itemCategoryID As String = StringEnteredIn(cells, Me.colBFPItemCategoryID)
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colBFPQuantity)
                    Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colBFPEntryMode)
                    Dim roundNo As String = RevertText(StringMayBeEnteredIn(cells, Me.colBFPRoundNo))
                    Me.CheckAvaliableToPayForDrugs(itemCode, itemCategoryID, quantity)
                    Using oPaymentExtraBillItems As New SyncSoft.SQLDb.PaymentExtraBillItems()

                        With oPaymentExtraBillItems
                            .ReceiptNo = receiptNo
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .Quantity = quantity
                            If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                                  (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                                .UnitPrice = Math.Abs(DecimalEnteredIn(cells, Me.colBFPUnitPrice, True, "unit price!"))
                            Else : .UnitPrice = DecimalEnteredIn(cells, Me.colBFPUnitPrice, False, "unit price!")
                            End If
                            .Discount = DecimalEnteredIn(cells, Me.colBFPDiscount, True, "discount!")
                            If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                                  (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                                .Amount = DecimalEnteredIn(cells, Me.colBFPAmount, True, "amount!")
                            Else : .Amount = DecimalEnteredIn(cells, Me.colBFPAmount, False, "amount!")
                            End If
                            If String.IsNullOrEmpty(prevInvoiceNo) Then invoiceAmount += .Amount
                        End With
                        lPaymentExtraBillItems.Add(oPaymentExtraBillItems)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Not oVariousOptions.AllowDirectDiscountCashPayment AndAlso oPaymentExtraBillItems.Discount > 0 Then
                            message = "The system is set not to allow a discount. Please contact your administrator!"
                            Throw New ArgumentException(message)

                        ElseIf oPaymentExtraBillItems.Discount > 0 Then
                            message = "You have chosen to give a discount that needs authorization. " +
                                ControlChars.NewLine + "Are you sure you want to save?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If billMode.ToUpper().Equals(cashAccount.ToUpper()) Then

                        Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
                            With oExtraBillItems
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = itemCategoryID
                                .LastUpdate = payDate
                                .PayStatusID = oPayStatusID.PaidFor
                                .LoginID = CurrentUser.LoginID
                            End With
                            lExtraBillItems.Add(oExtraBillItems)
                        End Using

                        If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.System).ToUpper()) AndAlso
                            Not String.IsNullOrEmpty(roundNo) Then

                            Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                                With oIPDItems
                                    .RoundNo = roundNo
                                    .ItemCode = itemCode
                                    .ItemCategoryID = itemCategoryID
                                    .LastUpdate = payDate
                                    .PayStatusID = oPayStatusID.PaidFor
                                    .LoginID = CurrentUser.LoginID
                                    .ItemStatusID = String.Empty
                                End With
                                lIPDItems.Add(oIPDItems)
                            End Using

                        End If

                    Else

                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = itemCategoryID
                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using

                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If
            Next


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '' Save Invoice Extra Bill Items
            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim invoiceNo As String = RevertText(StringEnteredIn(Me.stbBFPInvoiceNo, "Invoice No!"))

            For rowNo As Integer = 0 To Me.dgvPaymentExtraBillItems.RowCount - 1

                If CBool(Me.dgvPaymentExtraBillItems.Item(Me.colBFPInclude.Name, rowNo).Value) = True Then
                    Dim cells As DataGridViewCellCollection = Me.dgvPaymentExtraBillItems.Rows(rowNo).Cells
                    Dim itemCode As String = StringEnteredIn(cells, Me.colBFPItemCode, "item!")
                    Dim itemCategoryID As String = StringEnteredIn(cells, Me.colBFPItemCategoryID)
                    Dim extraBillNo As String = RevertText(StringEnteredIn(cells, Me.colBFPExtraBillNo, "bill no!"))
                    Dim prevInvoiceNo As String = StringMayBeEnteredIn(cells, Me.colBFPInvoiceNo)
                    If String.IsNullOrEmpty(prevInvoiceNo) Then
                        Using oInvoiceExtraBillItems As New SyncSoft.SQLDb.InvoiceExtraBillItems

                            With oInvoiceExtraBillItems
                                .InvoiceNo = invoiceNo
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = itemCategoryID
                                If copayTypeID.ToUpper().Equals(oCopayTypeID.Percent().ToUpper()) OrElse copayTypeID.Equals(oCopayTypeID.Value().ToUpper()) Then
                                    .ObjectName = oObjectNames.ExtraBillItemsCASH()
                                ElseIf copayTypeID.ToUpper().Equals(oCopayTypeID.NA().ToUpper()) Then
                                    .ObjectName = oObjectNames.ExtraBillItems()
                                End If
                                .Quantity = IntegerEnteredIn(cells, Me.colBFPQuantity)

                                If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                                      (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                                    .UnitPrice = Math.Abs(DecimalEnteredIn(cells, Me.colBFPUnitPrice, True, "unit price!"))

                                Else : .UnitPrice = DecimalEnteredIn(cells, Me.colBFPUnitPrice, False, "unit price!")
                                End If
                                .Discount = DecimalEnteredIn(cells, Me.colBFPDiscount, True, "discount!")
                                If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                                      (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                                    .Amount = DecimalEnteredIn(cells, Me.colBFPAmount, True, "amount!")
                                Else : .Amount = DecimalEnteredIn(cells, Me.colBFPAmount, False, "amount!")
                                End If

                            End With
                            lInvoiceExtraBillItems.Add(oInvoiceExtraBillItems)

                        End Using

                    End If
                End If
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            
           
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me.tpgBillFormPayment, ErrProvider)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lPayments, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lPaymentExtraBillItems, Action.Save))


            If billMode.ToUpper().Equals(cashAccount.ToUpper()) Then
                transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Update))
                transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Update))
            Else : transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Update))
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Generate an Invoice for Cash Payments
            If lInvoiceExtraBillItems.Count > 0 Then
                With oInvoices

                    .InvoiceNo = RevertText(StringEnteredIn(Me.stbBFPInvoiceNo, "Invoice No!"))
                    .PayTypeID = oPayTypeID.VisitBill
                    If copayTypeID.ToUpper().Equals(oCopayTypeID.Percent().ToUpper()) OrElse copayTypeID.Equals(oCopayTypeID.Value().ToUpper()) Then
                        .PayTypeID = oPayTypeID.VisitBillCASH
                    ElseIf copayTypeID.ToUpper().Equals(oCopayTypeID.NA().ToUpper()) Then
                        .PayTypeID = oPayTypeID.VisitBill
                    End If
                    .PayNo = visitNo
                    .InvoiceDate = payDate
                    .StartDate = payDate
                    .EndDate = payDate
                    .AmountWords = NumberToWords(invoiceAmount)
                    .VisitTypeID = oVisitTypeID.InPatient
                    .EntryModeID = oEntryModeID.System()
                    .Locked = True
                    .LoginID = CurrentUser.LoginID

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ValidateEntriesIn(Me)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End With


                With oReceiptInvoiceDetails

                    .InvoiceNo = RevertText(StringEnteredIn(Me.stbBFPInvoiceNo, "InvoiceNo!"))
                    .ReceiptNo = RevertText(StringEnteredIn(Me.stbBFPReceiptNo, "ReceiptNo!"))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ValidateEntriesIn(Me)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End With
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                linvoices.Add(oInvoices)
                lReceiptInvoiceDetails.Add(oReceiptInvoiceDetails)
                transactions.Add(New TransactionList(Of DBConnect)(linvoices, Action.Save))
                transactions.Add(New TransactionList(Of DBConnect)(lInvoiceExtraBillItems, Action.Save))
                transactions.Add(New TransactionList(Of DBConnect)(lReceiptInvoiceDetails, Action.Save))
            End If

            If oVariousOptions.SMSNotificationAtBillFormPayment Then
                If stbBFPPhoneNo.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(stbBFPPhoneNo.Text) Then
                    Dim CPpatientNo As String = RevertText(StringMayBeEnteredIn(Me.stbBFPPatientNo))
                    Dim oPatient As New SyncSoft.SQLDb.Patients()
                    oPatient.GetPatient(CPpatientNo)
                    Dim productOwner As String = AppData.ProductOwner
                    Dim recipients As String = stbBFPPhoneNo.Text
                    Dim txtmessage As String = ("Hi" + " " + oPatient.FirstName.ToString + " " + "payment of " + " " + stbBFPTotalAmountPaid.Text + " " + "has been received by" + " " + productOwner + " " + "ReceiptNo " + " " + RevertText(stbBFPReceiptNo.Text) + " " + "Thanks for paying" + " " + "-Via ClinicMaster")
                    SaveTextMessage(txtmessage, recipients, Now, oVariousOptions.SMSLifeSpanCashier)
                End If
            End If


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            DoTransactions(transactions)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.chkPrintReceiptOnSaving.Checked Then
                message = "You have not checked Print Receipt On Saving. " + ControlChars.NewLine + "Would you want a receipt printed?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintBillFormReceipt(True)
            Else : Me.PrintBillFormReceipt(True)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim allSelected As Boolean = True

            For Each row As DataGridViewRow In Me.dgvPaymentExtraBillItems.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPaymentExtraBillItems.Item(Me.colBFPInclude.Name, row.Index).Value) = False Then
                    allSelected = False
                    Me.ShowBillFormPatientDetails(visitNo)
                    Me.LoadBillFormItems(visitNo)
                    Me.SetNextReceiptNo(Me.stbBFPReceiptNo)
                    Me.SetNextInvoiceNo(Me.stbBFPInvoiceNo)
                    Exit For
                End If
                allSelected = True
            Next

            If allSelected Then
                ResetControlsIn(Me.tpgBillFormPayment)
                ResetControlsIn(Me.pnlNavigateVisits)
                Dim oLookupObject As New LookupObjects
                LoadLookupDataCombo(Me.cboBFPPayModesID, LookupObjects.PayModes)
                LoadLookupDataCombo(Me.cboBFPCurrenciesID, LookupObjects.Currencies)
                Me.cboBFPPayModesID.SelectedValue = oPayModesID.Cash
                Me.cboBFPCurrenciesID.SelectedValue = oCurrenciesID.UgandaShillings
                Me.dgvPaymentExtraBillItems.Rows.Clear()
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpBFPPayDate.Value = Today
            Me.dtpBFPPayDate.Checked = True

            Me.chkBFPUseAccountBalance.Checked = False
            Me.chkBFPSendBalanceToAccount.Checked = False
            Me.chkPrintReceiptOnSaving.Checked = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Me.ShowWaitingBillFormPayments()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            If ex.Message.Contains("The Receipt No:") Then
                Me.SetNextReceiptNo(Me.stbBFPReceiptNo)
                Me.btnSave.PerformClick()

            ElseIf ex.Message.Contains("The Invoice No:") OrElse ex.Message.EndsWith("already exists") Then
                Me.SetNextInvoiceNo(Me.stbBFPInvoiceNo)
                Me.btnSave.PerformClick()
            Else : ErrorMessage(ex)
            End If

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveBillsPayment()

        Dim message As String
        Dim oPayments As New SyncSoft.SQLDb.Payments()
        Dim oVariousOptions As New VariousOptions()

        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oCurrenciesID As New LookupDataID.CurrenciesID()
        Dim oAccountGroupID As New LookupDataID.AccountGroupID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim oPayTypeID As New LookupDataID.PayTypeID()
        Dim oVisitTypeID As New LookupDataID.VisitTypeID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oExtraItemCodes As New LookupDataID.ExtraItemCodes()
        
        Dim lPayments As New List(Of DBConnect)

        Dim lAccountBalance As New List(Of DBConnect)
        Dim lSendBalance As New List(Of DBConnect)
        Dim lPaymentDetails As New List(Of DBConnect)
        Dim lItems As New List(Of DBConnect)

        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim payTypeID As String
            Dim billModesID As String = StringValueEnteredIn(Me.cboBPBillModesID, "To-Bill Account Category!")

            If billModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) Then
                payTypeID = oPayTypeID.AccountBill
            ElseIf billModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then
                payTypeID = oPayTypeID.InsuranceBill
            ElseIf billModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) Then
                payTypeID = oPayTypeID.VisitBill
            Else : payTypeID = String.Empty
            End If

            Dim billNo As String = RevertText(StringEnteredIn(Me.cboBPBillAccountNo, Me.lblBPBillAccountNo.Text + "!"))
            Dim receiptNo As String = RevertText(StringEnteredIn(Me.stbBPReceiptNo, "Receipt No!"))
            Dim payDate As Date = Today
            Dim accountBalance As Decimal = GetAccountBalance(billModesID, billNo)
            Me.ResetBPAccountBalanceCTRL(accountBalance)
            Dim change As Decimal = DecimalMayBeEnteredIn(Me.stbBPChange, True)
            Dim payMode As String = StringValueEnteredIn(Me.cboBPPayModesID, "Pay Modes!")
            Dim payCurrencyID As String = StringValueEnteredIn(Me.cboBPCurrenciesID, "Currency!")
            Dim amountTendered As Decimal = DecimalEnteredIn(Me.nbxBPAmountTendered, True, "Amount Tendered!")
            Dim exchangeRate As Decimal = Me.nbxBPExchangeRate.GetDecimal(False)
           
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvBillsPayment.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvBillsPayment.Item(Me.colBPInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If Me.dgvBillsPayment.RowCount < 1 OrElse nonSelected Then Throw New ArgumentException("Must include at least one entry on bills payment details!")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oVariousOptions.AllowAccessCashServices Then

                Dim hasPendingItems As Boolean = False
                For Each row As DataGridViewRow In Me.dgvBillsPayment.Rows
                    If row.IsNewRow Then Exit For
                    If CBool(Me.dgvBillsPayment.Item(Me.colBPInclude.Name, row.Index).Value) = True Then
                        Dim itemStatus As String = StringMayBeEnteredIn(row.Cells, Me.colBPItemStatus)
                        If itemStatus.ToUpper().Equals(GetLookupDataDes(oItemStatusID.Pending).ToUpper()) Then
                            hasPendingItems = True
                            Exit For
                        End If
                    End If
                    hasPendingItems = False
                Next

                If hasPendingItems Then
                    If oVariousOptions.AllowProcessingPendingItems Then
                        message = "You have chosen to receipt pending service(s), changes at service point will not be allowed after this action. " +
                             ControlChars.NewLine + "Are you sure you want to save?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
                    Else : message = "The system is set not to allow receipting pending service(s). Please contact your administrator!"
                        Throw New ArgumentException(message)
                    End If

                End If

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If accountBalance < 0 Then
                message = "Account has a debit balance. It is recommended to get this account credited before continuing. " +
                     ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            End If
            ErrProvider.SetError(Me.stbBPAccountBalance, String.Empty)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If payMode.Equals(oPayModesID.Cheque()) OrElse payMode.Equals(oPayModesID.Visa()) OrElse
                payMode.Equals(oPayModesID.ElectronicFundTransfer()) Then

                Dim documentNo As String = StringEnteredIn(stbBPDocumentNo, "Documment No")
                If (String.IsNullOrEmpty(bankNameID) OrElse String.IsNullOrEmpty(bankAccountNo)) Then
                    MsgBox(GetLookupDataDes(payMode) + " Requires Bank Details to Continue. Please provide the bank Information")
                    Dim ofrmBankPaymentDetails As New frmBankPaymentDetails(payMode)
                    ofrmBankPaymentDetails.ShowDialog()
                    Me.bankNameID = ofrmBankPaymentDetails.BankName()
                    Me.bankAccountNo = ofrmBankPaymentDetails.AccountNo()

                    If String.IsNullOrEmpty(Me.bankNameID) OrElse String.IsNullOrEmpty(Me.bankAccountNo) Then Return
                    Dim registerID As String = RevertText(Me.GetNextRegisterNo())
                    transactions.Add(New TransactionList(Of DBConnect)(GetBankingDetails(receiptNo, documentNo, payMode), Action.Save))

                    If payMode.Equals(oPayModesID.Visa()) OrElse payMode.Equals(oPayModesID.ElectronicFundTransfer()) Then
                        transactions.Add(New TransactionList(Of DBConnect)(GetBankingRegisterList(registerID, Me.oCollectionSourceTyPyID.PatientPayments, amountTendered,
                                                                                              payCurrencyID, exchangeRate, payDate), Action.Save))
                        transactions.Add(New TransactionList(Of DBConnect)(GetBankingDetailList(registerID, amountTendered, payMode, documentNo), Action.Save))
                    End If
                End If
            End If
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oPayments

                .ReceiptNo = receiptNo
                .PayTypeID = payTypeID
                .PayNo = billNo
                .ClientFullName = StringEnteredIn(Me.stbBPBillCustomerName)
                .PayDate = payDate
                .PayModesID = StringValueEnteredIn(Me.cboBPPayModesID, "Pay Modes!")
                .DocumentNo = StringMayBeEnteredIn(Me.stbBPDocumentNo)
                .AmountWords = StringMayBeEnteredIn(Me.stbBPAmountWords)
                .Notes = StringMayBeEnteredIn(Me.stbBPNotes)
                .CurrenciesID = StringValueEnteredIn(Me.cboBPCurrenciesID, "Currency!")
                .WithholdingTax = DecimalMayBeEnteredIn(Me.nbxBPWithholdingTax)
                .GrandDiscount = DecimalMayBeEnteredIn(Me.nbxBPGrandDiscount)
                .AmountTendered = DecimalEnteredIn(Me.nbxBPAmountTendered, True, "Amount Tendered!")
                .ExchangeRate = Me.nbxBPExchangeRate.GetDecimal(False)
                .Change = change
                .SendBalanceToAccount = Me.chkBPSendBalanceToAccount.Checked
                .UseAccountBalance = Me.chkBPUseAccountBalance.Checked
                .VisitTypeID = oVisitTypeID.OutPatient
                .FilterNo = RevertText(StringMayBeEnteredIn(Me.stbBPVisitNo))
                .LoginID = CurrentUser.LoginID

            End With

            ValidateEntriesIn(Me.tpgBillsPayment)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lPayments.Add(oPayments)

            

            If change < 0 AndAlso Not Me.chkBPSendBalanceToAccount.Checked Then

                Me.nbxBPAmountTendered.Focus()
                Throw New ArgumentException("Amount tendered can’t be less than total bill!")

            ElseIf payDate < Today Then

                message = "You have selected a pay date that is before today, " +
                            "this will result in this receipt’s total bill not showing in today’s cash collections if searched via pay date." +
                            ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Me.chkBPUseAccountBalance.Checked Then

                Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbBPTotalBill, True)
                Dim creditBalance As Decimal = totalBill

                If accountBalance <= 0 Then

                    message = Me.stbBPBillCustomerName.Text + "’s current balance of " + FormatNumber(accountBalance, AppData.DecimalPlaces) +
                            " can’t be used to offset this bill"
                    Throw New ArgumentException(message)

                ElseIf totalBill > accountBalance AndAlso accountBalance > 0 Then

                    creditBalance = accountBalance

                    message = Me.stbBPBillCustomerName.Text + "’s current balance of " + FormatNumber(accountBalance, AppData.DecimalPlaces) +
                              " is insufficient to cater for this bill. " + ControlChars.NewLine +
                              "Would you like the system to use only what’s available? "

                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    message = "You have chosen to receive part of this payment from " + Me.stbBPBillCustomerName.Text + "’s account that will eventually be debited by " +
                        FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"

                Else : message = "You have chosen to receive this payment from " + Me.stbBPBillCustomerName.Text + "’s account that will eventually be debited by " +
                    FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Using oAccounts As New SyncSoft.SQLDb.Accounts()

                    With oAccounts
                        .TranNo = GetNextTranNo()
                        .AccountBillModesID = billModesID
                        .AccountBillNo = billNo
                        .ClientFullName = StringEnteredIn(Me.stbBPBillCustomerName)
                        .TranDate = payDate
                        .PayModesID = StringValueEnteredIn(Me.cboBPPayModesID, "Pay Modes!")
                        .AccountActionID = oAccountActionID.Debit
                        .Amount = creditBalance
                        .DocumentNo = StringMayBeEnteredIn(Me.stbBPDocumentNo)
                        .AmountWords = NumberToWords(.Amount)
                        .CurrenciesID = oCurrenciesID.UgandaShillings
                        .AmountTendered = .Amount
                        .ExchangeRate = 1
                        .Change = 0
                        .AccountGroupID = oAccountGroupID.BillClearance
                        .Notes = "Payment under receipt no: " + receiptNo
                        .ReferenceNo = receiptNo
                        .EntryModeID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lAccountBalance.Add(oAccounts)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End With

                End Using

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                transactions.Add(New TransactionList(Of DBConnect)(lAccountBalance, Action.Save))
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            If Me.chkBPSendBalanceToAccount.Checked Then

                Dim accountActionID As String
                Dim creditBalance As Decimal = change
                Dim accountGroupID As String = oAccountGroupID.NA

                If change < 0 Then

                    accountActionID = oAccountActionID.Debit
                    creditBalance = -change
                    accountGroupID = oAccountGroupID.BillClearance

                    If Not oVariousOptions.AllowPartialCashPayment Then
                        message = "The system is set not to allow partial payment!"
                        Throw New ArgumentException(message)

                    Else : message = "You have chosen to send balance to " + Me.stbBPBillCustomerName.Text + "’s account that will eventually be debited by " +
                        FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"
                    End If

                ElseIf change = 0 Then

                    message = "You have chosen to send balance to account. The system does not allow any account action with zero balance sent!"
                    Throw New ArgumentException(message)

                Else
                    accountActionID = oAccountActionID.Credit
                    creditBalance = change
                    accountGroupID = oAccountGroupID.LackofChange

                    message = "You have chosen to send balance to " + Me.stbBPBillCustomerName.Text + "’s account that will eventually be credited by " +
                        FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"

                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Using oAccounts As New SyncSoft.SQLDb.Accounts()

                    With oAccounts
                        If Me.chkBPUseAccountBalance.Checked Then
                            .TranNo = GetNextTranNo(1)
                        Else : .TranNo = GetNextTranNo()
                        End If
                        .AccountBillModesID = billModesID
                        .AccountBillNo = billNo
                        .ClientFullName = StringEnteredIn(Me.stbBPBillCustomerName)
                        .TranDate = payDate
                        .PayModesID = StringValueEnteredIn(Me.cboBPPayModesID, "Pay Modes!")
                        .AccountActionID = accountActionID
                        .Amount = creditBalance
                        .DocumentNo = StringMayBeEnteredIn(Me.stbBPDocumentNo)
                        .AmountWords = NumberToWords(.Amount)
                        .CurrenciesID = oCurrenciesID.UgandaShillings
                        .AmountTendered = .Amount
                        .ExchangeRate = 1
                        .Change = 0
                        .AccountGroupID = accountGroupID
                        .Notes = "Payment under receipt no: " + receiptNo
                        .ReferenceNo = receiptNo
                        .EntryModeID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lSendBalance.Add(oAccounts)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End With

                End Using

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                transactions.Add(New TransactionList(Of DBConnect)(lSendBalance, Action.Save))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

            If Not Me.chkBPUseAccountBalance.Checked AndAlso Not Me.chkBPSendBalanceToAccount.Checked Then

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                message = "You are about to perform an irreversible action please ensure that you have all the payment " +
                    "(Total Bill: " + Me.stbBPTotalBill.Text + ", Receipt No: " + Me.stbBPReceiptNo.Text + ") " +
                    "with you before continuing." + ControlChars.NewLine + "Are you sure you want to save?"

                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvBillsPayment.RowCount - 1

                If CBool(Me.dgvBillsPayment.Item(Me.colBPInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvBillsPayment.Rows(rowNo).Cells
                    Dim visitNo As String = RevertText(StringEnteredIn(cells, Me.colBPVisitNo, "Visit Number!"))
                    Dim itemCode As String = StringEnteredIn(cells, Me.colBPItemCode, "item!")
                    Dim itemCategoryID As String = StringEnteredIn(cells, Me.colBPItemCategoryID)

                    Using oPaymentDetails As New SyncSoft.SQLDb.PaymentDetails()

                        With oPaymentDetails
                            .ReceiptNo = receiptNo
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .Quantity = IntegerEnteredIn(cells, Me.colBPQuantity)
                            If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                                  (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                                .UnitPrice = DecimalEnteredIn(cells, Me.colBPUnitPrice, True, "unit price!")
                            Else : .UnitPrice = DecimalEnteredIn(cells, Me.colBPUnitPrice, False, "unit price!")
                            End If
                            .Discount = DecimalEnteredIn(cells, Me.colBPDiscount, True, "discount!")
                            If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                                  (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                                .Amount = DecimalEnteredIn(cells, Me.colBPAmount, True, "amount!")
                            Else : .Amount = DecimalEnteredIn(cells, Me.colBPAmount, False, "amount!")
                            End If
                        End With

                        lPaymentDetails.Add(oPaymentDetails)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Not oVariousOptions.AllowDirectDiscountCashPayment AndAlso oPaymentDetails.Discount > 0 Then
                            message = "The system is set not to allow a discount. Please contact your administrator!"
                            Throw New ArgumentException(message)

                        ElseIf oPaymentDetails.Discount > 0 Then
                            message = "You have chosen to give a discount that needs authorization. " +
                                ControlChars.NewLine + "Are you sure you want to save?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .LastUpdate = payDate
                            .PayStatusID = oPayStatusID.PaidFor
                            .LoginID = CurrentUser.LoginID
                            .ItemStatusID = String.Empty
                        End With
                        lItems.Add(oItems)
                    End Using

                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me.tpgBillsPayment, ErrProvider)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lPayments, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lPaymentDetails, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Update))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            DoTransactions(transactions)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.chkPrintReceiptOnSaving.Checked Then
                message = "You have not checked Print Receipt On Saving. " +
                           ControlChars.NewLine + "Would you want a receipt printed?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintBPReceipt(True)
            Else : Me.PrintBPReceipt(True)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim allSelected As Boolean = True

            For Each row As DataGridViewRow In Me.dgvBillsPayment.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvBillsPayment.Item(Me.colBPInclude.Name, row.Index).Value) = False Then
                    allSelected = False
                    Me.ResetBPAccountBalanceCTRL(GetAccountBalance(billModesID, billNo))
                    Me.LoadBillItems()
                    Me.SetNextReceiptNo(Me.stbBPReceiptNo)
                    Exit For
                End If
                allSelected = True
            Next

            If allSelected Then
                ResetControlsIn(Me.tpgBillsPayment)
                Dim oLookupObject As New LookupObjects
                LoadLookupDataCombo(Me.cboBPPayModesID, LookupObjects.PayModes)
                LoadLookupDataCombo(Me.cboBPCurrenciesID, LookupObjects.Currencies)
                Me.cboBPPayModesID.SelectedValue = oPayModesID.Cash
                Me.cboBPCurrenciesID.SelectedValue = oCurrenciesID.UgandaShillings

                Me.dgvBillsPayment.Rows.Clear()
                Me.lblBPRecordsNo.Text = String.Empty
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.chkBPUseAccountBalance.Checked = False
            Me.chkBPSendBalanceToAccount.Checked = False
            Me.chkPrintReceiptOnSaving.Checked = True
            Me.SetNextReceiptNo(Me.stbBPReceiptNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            If ex.Message.Contains("The Receipt No:") Then
                Me.SetNextReceiptNo(Me.stbBPReceiptNo)
                Me.btnSave.PerformClick()
            Else : ErrorMessage(ex)
            End If

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveCreditBillFormPayment()

        Dim message As String
        Dim oPayments As New SyncSoft.SQLDb.Payments()
        Dim oVariousOptions As New VariousOptions()

        Dim oLookupData As New SyncSoft.Lookup.SQL.LookupData()
        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oCurrenciesID As New LookupDataID.CurrenciesID()
        Dim oAccountGroupID As New LookupDataID.AccountGroupID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim oPayTypeID As New LookupDataID.PayTypeID()
        Dim oVisitTypeID As New LookupDataID.VisitTypeID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oExtraItemCodes As New LookupDataID.ExtraItemCodes()
        Dim oEntryModeID As New LookupDataID.EntryModeID()

        Dim lPayments As New List(Of DBConnect)
        Dim lAccountBalance As New List(Of DBConnect)
        Dim lSendBalance As New List(Of DBConnect)
        Dim lIPDItems As New List(Of DBConnect)
        Dim lPaymentExtraBillItems As New List(Of DBConnect)
        Dim lExtraBillItems As New List(Of DBConnect)

        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim payTypeID As String
            Dim billModesID As String = StringValueEnteredIn(Me.cboCBFPBillModesID, "To-Bill Account Category!")

            If billModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) Then
                payTypeID = oPayTypeID.AccountBill
            ElseIf billModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then
                payTypeID = oPayTypeID.InsuranceBill
            ElseIf billModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) Then
                payTypeID = oPayTypeID.VisitBill
            Else : payTypeID = String.Empty
            End If

            Dim billNo As String = RevertText(StringEnteredIn(Me.cboCBFPBillAccountNo, Me.lblCBFPBillAccountNo.Text + "!"))
            Dim receiptNo As String = RevertText(StringEnteredIn(Me.stbCBFPReceiptNo, "Receipt No!"))
            Dim payDate As Date = Today
            Dim accountBalance As Decimal = GetAccountBalance(billModesID, billNo)
            Me.ResetCBFPAccountBalanceCTRL(accountBalance)
            Dim change As Decimal = DecimalMayBeEnteredIn(Me.stbCBFPChange, True)
            Dim payMode As String = StringValueEnteredIn(Me.cboCBFPPayModesID, "Pay Modes!")
            Dim payCurrencyID = StringValueEnteredIn(Me.cboCBFPCurrenciesID, "Currency!")
            Dim amountTendered = DecimalEnteredIn(Me.nbxCBFPAmountTendered, True, "Amount Tendered!")
            Dim exchangeRate = Me.nbxCBFPExchangeRate.GetDecimal(False)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvCBFPExtraBillItems.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvCBFPExtraBillItems.Item(Me.colCBFPInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If Me.dgvCBFPExtraBillItems.RowCount < 1 OrElse nonSelected Then Throw New ArgumentException("Must include at least one entry on credit bill form payment details!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If accountBalance < 0 Then
                message = "Account has a debit balance. It is recommended to get this account credited before continuing. " +
                     ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            End If
            ErrProvider.SetError(Me.stbCBFPAccountBalance, String.Empty)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If payMode.Equals(oPayModesID.Cheque()) OrElse payMode.Equals(oPayModesID.Visa()) OrElse
                payMode.Equals(oPayModesID.ElectronicFundTransfer()) Then

                Dim documentNo As String = StringEnteredIn(stbCBFPDocumentNo, "Documment No")
                If (String.IsNullOrEmpty(bankNameID) OrElse String.IsNullOrEmpty(bankAccountNo)) Then
                    MsgBox(GetLookupDataDes(payMode) + " Requires Bank Details to Continue. Please provide the bank Information")
                    Dim ofrmBankPaymentDetails As New frmBankPaymentDetails(payMode)
                    ofrmBankPaymentDetails.ShowDialog()
                    Me.bankNameID = ofrmBankPaymentDetails.BankName()
                    Me.bankAccountNo = ofrmBankPaymentDetails.AccountNo()

                    If String.IsNullOrEmpty(Me.bankNameID) OrElse String.IsNullOrEmpty(Me.bankAccountNo) Then Return
                    Dim registerID As String = RevertText(Me.GetNextRegisterNo())
                    transactions.Add(New TransactionList(Of DBConnect)(GetBankingDetails(receiptNo, documentNo, payMode), Action.Save))

                    If payMode.Equals(oPayModesID.Visa()) OrElse payMode.Equals(oPayModesID.ElectronicFundTransfer()) Then
                        transactions.Add(New TransactionList(Of DBConnect)(GetBankingRegisterList(registerID, Me.oCollectionSourceTyPyID.PatientPayments, amountTendered,
                                                                                              payCurrencyID, exchangeRate, payDate), Action.Save))
                        transactions.Add(New TransactionList(Of DBConnect)(GetBankingDetailList(registerID, amountTendered, payMode, documentNo), Action.Save))
                    End If
                End If
            End If
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With oPayments

                .ReceiptNo = receiptNo
                .PayTypeID = payTypeID
                .PayNo = billNo
                .ClientFullName = StringEnteredIn(Me.stbCBFPBillCustomerName)
                .PayDate = payDate
                .PayModesID = StringValueEnteredIn(Me.cboCBFPPayModesID, "Pay Modes!")
                .DocumentNo = StringMayBeEnteredIn(Me.stbCBFPDocumentNo)
                .AmountWords = StringMayBeEnteredIn(Me.stbCBFPAmountWords)
                .Notes = StringMayBeEnteredIn(Me.stbCBFPNotes)
                .CurrenciesID = StringValueEnteredIn(Me.cboCBFPCurrenciesID, "Currency!")
                .WithholdingTax = DecimalMayBeEnteredIn(Me.nbxCBFPWithholdingTax)
                .GrandDiscount = DecimalMayBeEnteredIn(Me.nbxCBFPGrandDiscount)
                .AmountTendered = DecimalEnteredIn(Me.nbxCBFPAmountTendered, True, "Amount Tendered!")
                .ExchangeRate = Me.nbxCBFPExchangeRate.GetDecimal(False)
                .Change = change
                .SendBalanceToAccount = Me.chkCBFPSendBalanceToAccount.Checked
                .UseAccountBalance = Me.chkCBFPUseAccountBalance.Checked
                .VisitTypeID = oVisitTypeID.InPatient
                .FilterNo = RevertText(StringMayBeEnteredIn(Me.stbCBFPVisitNo))
                .LoginID = CurrentUser.LoginID

            End With

            ValidateEntriesIn(Me.tpgCreditBillFormPayment)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lPayments.Add(oPayments)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If change < 0 AndAlso Not Me.chkCBFPSendBalanceToAccount.Checked Then

                Me.nbxCBFPAmountTendered.Focus()
                Throw New ArgumentException("Amount tendered can’t be less than total bill!")

            ElseIf payDate < Today Then

                message = "You have selected a pay date that is before today, " +
                            "this will result in this receipt’s total bill not showing in today’s cash collections if searched via pay date." +
                            ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Me.chkCBFPUseAccountBalance.Checked Then

                Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbCBFPTotalBill, True)
                Dim creditBalance As Decimal = totalBill

                If accountBalance <= 0 Then

                    message = Me.stbCBFPBillCustomerName.Text + "’s current balance of " + FormatNumber(accountBalance, AppData.DecimalPlaces) +
                            " can’t be used to offset this bill"
                    Throw New ArgumentException(message)

                ElseIf totalBill > accountBalance AndAlso accountBalance > 0 Then

                    creditBalance = accountBalance

                    message = Me.stbCBFPBillCustomerName.Text + "’s current balance of " + FormatNumber(accountBalance, AppData.DecimalPlaces) +
                              " is insufficient to cater for this bill. " + ControlChars.NewLine +
                              "Would you like the system to use only what’s available? "

                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    message = "You have chosen to receive part of this payment from " + Me.stbCBFPBillCustomerName.Text + "’s account that will eventually be debited by " +
                        FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"

                Else : message = "You have chosen to receive this payment from " + Me.stbCBFPBillCustomerName.Text + "’s account that will eventually be debited by " +
                    FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Using oAccounts As New SyncSoft.SQLDb.Accounts()

                    With oAccounts
                        .TranNo = GetNextTranNo()
                        .AccountBillModesID = billModesID
                        .AccountBillNo = billNo
                        .ClientFullName = StringEnteredIn(Me.stbCBFPBillCustomerName)
                        .TranDate = payDate
                        .PayModesID = StringValueEnteredIn(Me.cboCBFPPayModesID, "Pay Modes!")
                        .AccountActionID = oAccountActionID.Debit
                        .Amount = creditBalance
                        .DocumentNo = StringMayBeEnteredIn(Me.stbCBFPDocumentNo)
                        .AmountWords = NumberToWords(.Amount)
                        .CurrenciesID = oCurrenciesID.UgandaShillings
                        .AmountTendered = .Amount
                        .ExchangeRate = 1
                        .Change = 0
                        .AccountGroupID = oAccountGroupID.BillClearance
                        .Notes = "Payment under receipt no: " + receiptNo
                        .ReferenceNo = receiptNo
                        .EntryModeID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lAccountBalance.Add(oAccounts)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End With

                End Using

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                transactions.Add(New TransactionList(Of DBConnect)(lAccountBalance, Action.Save))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            If Me.chkCBFPSendBalanceToAccount.Checked Then

                Dim accountActionID As String
                Dim creditBalance As Decimal = change
                Dim accountGroupID As String = oAccountGroupID.NA

                If change < 0 Then

                    accountActionID = oAccountActionID.Debit
                    creditBalance = -change
                    accountGroupID = oAccountGroupID.BillClearance

                    If Not oVariousOptions.AllowPartialCashPayment Then
                        message = "The system is set not to allow partial payment!"
                        Throw New ArgumentException(message)

                    Else : message = "You have chosen to send balance to " + Me.stbCBFPBillCustomerName.Text + "’s account that will eventually be debited by " +
                        FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"
                    End If

                ElseIf change = 0 Then

                    message = "You have chosen to send balance to account. The system does not allow any account action with zero balance sent!"
                    Throw New ArgumentException(message)

                Else
                    accountActionID = oAccountActionID.Credit
                    creditBalance = change
                    accountGroupID = oAccountGroupID.LackofChange

                    message = "You have chosen to send balance to " + Me.stbCBFPBillCustomerName.Text + "’s account that will eventually be credited by " +
                        FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"

                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Using oAccounts As New SyncSoft.SQLDb.Accounts()

                    With oAccounts
                        If Me.chkCBFPUseAccountBalance.Checked Then
                            .TranNo = GetNextTranNo(1)
                        Else : .TranNo = GetNextTranNo()
                        End If
                        .AccountBillModesID = billModesID
                        .AccountBillNo = billNo
                        .ClientFullName = StringEnteredIn(Me.stbCBFPBillCustomerName)
                        .TranDate = payDate
                        .PayModesID = StringValueEnteredIn(Me.cboCBFPPayModesID, "Pay Modes!")
                        .AccountActionID = accountActionID
                        .Amount = creditBalance
                        .DocumentNo = StringMayBeEnteredIn(Me.stbCBFPDocumentNo)
                        .AmountWords = NumberToWords(.Amount)
                        .CurrenciesID = oCurrenciesID.UgandaShillings
                        .AmountTendered = .Amount
                        .ExchangeRate = 1
                        .Change = 0
                        .AccountGroupID = accountGroupID
                        .Notes = "Payment under receipt no: " + receiptNo
                        .ReferenceNo = receiptNo
                        .EntryModeID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lSendBalance.Add(oAccounts)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End With

                End Using

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                transactions.Add(New TransactionList(Of DBConnect)(lSendBalance, Action.Save))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

            If Not Me.chkCBFPUseAccountBalance.Checked AndAlso Not Me.chkCBFPSendBalanceToAccount.Checked Then

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                message = "You are about to perform an irreversible action please ensure that you have all the payment " +
                    "(Total Bill: " + Me.stbCBFPTotalBill.Text + ", Receipt No: " + Me.stbCBFPReceiptNo.Text + ") " +
                    "with you before continuing." + ControlChars.NewLine + "Are you sure you want to save?"

                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvCBFPExtraBillItems.RowCount - 1

                If CBool(Me.dgvCBFPExtraBillItems.Item(Me.colCBFPInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvCBFPExtraBillItems.Rows(rowNo).Cells
                    Dim extraBillNo As String = RevertText(StringEnteredIn(cells, Me.colCBFPExtraBillNo, "bill no!"))
                    Dim itemCode As String = StringEnteredIn(cells, Me.colCBFPItemCode, "item!")
                    Dim itemCategoryID As String = StringEnteredIn(cells, Me.colCBFPItemCategoryID)
                    Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colCBFPEntryMode)
                    Dim roundNo As String = RevertText(StringMayBeEnteredIn(cells, Me.colCBFPRoundNo))

                    Using oPaymentExtraBillItems As New SyncSoft.SQLDb.PaymentExtraBillItems()

                        With oPaymentExtraBillItems

                            .ReceiptNo = receiptNo
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .Quantity = IntegerEnteredIn(cells, Me.colCBFPQuantity)
                            If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                                  (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                                .UnitPrice = DecimalEnteredIn(cells, Me.colCBFPUnitPrice, True, "unit price!")
                            Else : .UnitPrice = DecimalEnteredIn(cells, Me.colCBFPUnitPrice, False, "unit price!")
                            End If
                            .Discount = DecimalEnteredIn(cells, Me.colCBFPDiscount, True, "discount!")
                            If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                                  (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                                .Amount = DecimalEnteredIn(cells, Me.colCBFPAmount, True, "amount!")
                            Else : .Amount = DecimalEnteredIn(cells, Me.colCBFPAmount, False, "amount!")
                            End If

                        End With

                        lPaymentExtraBillItems.Add(oPaymentExtraBillItems)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Not oVariousOptions.AllowDirectDiscountCashPayment AndAlso oPaymentExtraBillItems.Discount > 0 Then
                            message = "The system is set not to allow a discount. Please contact your administrator!"
                            Throw New ArgumentException(message)

                        ElseIf oPaymentExtraBillItems.Discount > 0 Then
                            message = "You have chosen to give a discount that needs authorization. " + ControlChars.NewLine + "Are you sure you want to save?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .LastUpdate = payDate
                            .PayStatusID = oPayStatusID.PaidFor
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.System).ToUpper()) AndAlso Not String.IsNullOrEmpty(roundNo) Then

                        Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                            With oIPDItems
                                .RoundNo = roundNo
                                .ItemCode = itemCode
                                .ItemCategoryID = itemCategoryID
                                .LastUpdate = payDate
                                .PayStatusID = oPayStatusID.PaidFor
                                .LoginID = CurrentUser.LoginID
                                .ItemStatusID = String.Empty
                            End With
                            lIPDItems.Add(oIPDItems)
                        End Using

                    End If

                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me.tpgCreditBillFormPayment, ErrProvider)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lPayments, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lPaymentExtraBillItems, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Update))
            transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Update))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            DoTransactions(transactions)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.chkPrintReceiptOnSaving.Checked Then
                message = "You have not checked Print Receipt On Saving. " + ControlChars.NewLine + "Would you want a receipt printed?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintCBFPReceipt(True)
            Else : Me.PrintCBFPReceipt(True)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim allSelected As Boolean = True

            For Each row As DataGridViewRow In Me.dgvCBFPExtraBillItems.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvCBFPExtraBillItems.Item(Me.colCBFPInclude.Name, row.Index).Value) = False Then
                    allSelected = False
                    Me.ResetCBFPAccountBalanceCTRL(GetAccountBalance(billModesID, billNo))
                    Me.LoadCBFPExtraBillItems()
                    Me.SetNextReceiptNo(Me.stbCBFPReceiptNo)
                    Exit For
                End If
                allSelected = True
            Next

            If allSelected Then
                ResetControlsIn(Me.tpgCreditBillFormPayment)
                Dim oLookupObject As New LookupObjects
                LoadLookupDataCombo(Me.cboCBFPPayModesID, LookupObjects.PayModes)
                LoadLookupDataCombo(Me.cboCBFPCurrenciesID, LookupObjects.Currencies)
                Me.cboCBFPPayModesID.SelectedValue = oPayModesID.Cash
                Me.cboCBFPCurrenciesID.SelectedValue = oCurrenciesID.UgandaShillings

                Me.dgvCBFPExtraBillItems.Rows.Clear()
                Me.lblCBFPRecordsNo.Text = String.Empty
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.chkCBFPUseAccountBalance.Checked = False
            Me.chkCBFPSendBalanceToAccount.Checked = False
            Me.chkPrintReceiptOnSaving.Checked = True
            Me.SetNextReceiptNo(Me.stbCBFPReceiptNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            If ex.Message.Contains("The Receipt No:") Then
                Me.SetNextReceiptNo(Me.stbCBFPReceiptNo)
                Me.btnSave.PerformClick()
            Else : ErrorMessage(ex)
            End If

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveAccounts()

        Dim message As String
        Dim oVariousOptions As New VariousOptions()
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oCurrenciesID As New LookupDataID.CurrenciesID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim payMode As String = StringValueEnteredIn(Me.cboAccountPayModesID, "Pay Modes!")
            Dim accountActionID As String = StringValueEnteredIn(Me.cboAccountActionID, "Account Action!")
            Dim payCurrencyID As String = StringValueEnteredIn(Me.cboAccountCurrenciesID, "Currency!")
            Dim amountTendered As Decimal = DecimalEnteredIn(Me.nbxAccountAmountTendered, False, "Amount Tendered!")
            Dim exchangeRate As Decimal = Me.nbxAccountExchangeRate.GetDecimal(False)
            Dim payDate As Date = DateTimeEnteredIn(Me.dtpTransactionDate, "Transaction Date!")
            Dim tranNo As String = RevertText(StringEnteredIn(Me.stbAccountTranNo, "Transaction No!"))
            Dim lAccounts As New List(Of DBConnect)


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If payMode.Equals(oPayModesID.Cheque()) OrElse payMode.Equals(oPayModesID.Visa()) OrElse
                payMode.Equals(oPayModesID.ElectronicFundTransfer()) Then

                Dim documentNo As String = StringEnteredIn(stbAccountDocumentNo, "Documment No")
                If (String.IsNullOrEmpty(bankNameID) OrElse String.IsNullOrEmpty(bankAccountNo)) Then
                    MsgBox(GetLookupDataDes(payMode) + " Requires Bank Details to Continue. Please provide the bank Information")
                    Dim ofrmBankPaymentDetails As New frmBankPaymentDetails(payMode)
                    ofrmBankPaymentDetails.ShowDialog()
                    Me.bankNameID = ofrmBankPaymentDetails.BankName()
                    Me.bankAccountNo = ofrmBankPaymentDetails.AccountNo()

                    If String.IsNullOrEmpty(Me.bankNameID) OrElse String.IsNullOrEmpty(Me.bankAccountNo) Then Return
                    Dim registerID As String = RevertText(Me.GetNextRegisterNo())
                    transactions.Add(New TransactionList(Of DBConnect)(GetBankingDetails(tranNo, documentNo, payMode), Action.Save))

                    If accountActionID.ToUpper().Equals(oAccountActionID.Credit.ToUpper()) Then
                        If payMode.Equals(oPayModesID.Visa()) OrElse payMode.Equals(oPayModesID.ElectronicFundTransfer()) Then
                            transactions.Add(New TransactionList(Of DBConnect)(GetBankingRegisterList(registerID, Me.oCollectionSourceTyPyID.Account(), amountTendered,
                                                                                              payCurrencyID, exchangeRate, payDate), Action.Save))
                            transactions.Add(New TransactionList(Of DBConnect)(GetBankingDetailList(registerID, amountTendered, payMode, documentNo), Action.Save))
                        End If
                    End If
                End If
            End If
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Using oAccounts As New SyncSoft.SQLDb.Accounts()

                With oAccounts

                    .TranNo = tranNo
                    .AccountBillModesID = StringValueEnteredIn(Me.cboBillModesID, "Account Category!")
                    .AccountBillNo = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))
                    .ClientFullName = StringEnteredIn(Me.stbAccountName, "Account Name!")
                    .TranDate = payDate
                    .PayModesID = payMode
                    .AccountActionID = accountActionID
                    .AmountWords = NumberToWords(.Amount)
                    .CurrenciesID = payCurrencyID
                    .AmountTendered = amountTendered
                    .ExchangeRate = exchangeRate
                    .Amount = Me.nbxAccountAmount.GetDecimal(False)
                    .Change = DecimalEnteredIn(Me.stbAccountChange, False, "Change!")
                    .DocumentNo = StringMayBeEnteredIn(Me.stbAccountDocumentNo)
                    .AccountGroupID = StringValueEnteredIn(Me.cboAccountGroupID, "Account Group!")
                    .Notes = StringMayBeEnteredIn(Me.stbAccountNotes)
                    .EntryModeID = oEntryModeID.Manual
                    .ReferenceNo = Nothing
                    .LoginID = CurrentUser.LoginID

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    lAccounts.Add(oAccounts)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End With

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me.tpgManageAccounts, ErrProvider)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountBalance, True)

                If oAccounts.AccountActionID.ToUpper().Equals(oAccountActionID.Debit.ToUpper()) Then

                    If Not oVariousOptions.AllowManualAccountDebitEntry Then
                        message = "The system is set not to allow manual account debit entry!"
                        Throw New ArgumentException(message)
                    Else
                        message = "You have decided to make a manual debit entry to this account. " +
                            ControlChars.NewLine + "Are you sure you want to save?"
                        If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    End If

                End If

                If oAccounts.AccountActionID.ToUpper().Equals(oAccountActionID.Debit.ToUpper()) AndAlso accountBalance < 0 Then

                    If Not oVariousOptions.AllowDirectDebitBalanceEntry Then
                        message = "The system is set not to allow direct debit balance entry!"
                        Throw New ArgumentException(message)
                    Else
                        message = "You have decided to make a direct debit that leaves this account with a debit balance. " +
                            ControlChars.NewLine + "Are you sure you want to save?"
                        If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    End If

                End If

            End Using

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lAccounts, Action.Save))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            DoTransactions(transactions)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.chkPrintReceiptOnSaving.Checked Then
                message = "You have not checked Print Receipt On Saving. " +
                    ControlChars.NewLine + "Would you want a receipt printed?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintAccounts(True)
            Else : Me.PrintAccounts(True)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oVariousOptions.SMSNotificationAtManageAccounts Then
                If stbAccountPhone.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(stbAccountPhone.Text) Then

                    Dim productOwner As String = AppData.ProductOwner
                    Dim recipients As String = stbAccountPhone.Text
                    Dim accountAction As String = StringMayBeEnteredIn(Me.cboAccountActionID)
                    If accountAction.ToUpper().Equals(GetLookupDataDes(oAccountActionID.Debit).ToUpper()) Then
                        Dim debittextmessage As String = ("Hi" + " " + Trim(stbAccountName.Text) + " " + "Your A/C at " + " " + productOwner + " " + "has been debited by" + " " + cboAccountCurrenciesID.Text + " " + nbxAccountAmountTendered.Text + " " + "Your new balance is :" + " " + nbxAccountBalance.Text + " " + "Reason :" + " " + cboAccountGroupID.Text + " " + "TranNo :" + " " + RevertText(stbAccountTranNo.Text) + " " + "-Via ClinicMaster")
                        SaveTextMessage(debittextmessage, recipients, Now, oVariousOptions.SMSLifeSpanManageACCs)
                    ElseIf accountAction.ToUpper().Equals(GetLookupDataDes(oAccountActionID.Credit).ToUpper()) Then
                        Dim credittextmessage As String = ("Hi" + " " + Trim(stbAccountName.Text) + " " + "Your A/C at " + " " + productOwner + " " + "has been Credited with" + " " + cboAccountCurrenciesID.Text + " " + nbxAccountAmountTendered.Text + " " + "Your new balance is :" + " " + nbxAccountBalance.Text + " " + "Reason :" + " " + cboAccountGroupID.Text + " " + "TranNo :" + " " + RevertText(stbAccountTranNo.Text) + " " + "-Via ClinicMaster")
                        SaveTextMessage(credittextmessage, recipients, Now, oVariousOptions.SMSLifeSpanManageACCs)
                    End If
                End If

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me.tpgManageAccounts)
            LoadLookupDataCombo(Me.cboAccountPayModesID, LookupObjects.PayModes)
            LoadLookupDataCombo(Me.cboAccountCurrenciesID, LookupObjects.Currencies)
            Me.cboAccountPayModesID.SelectedValue = oPayModesID.Cash
            Me.cboAccountCurrenciesID.SelectedValue = oCurrenciesID.UgandaShillings

            Me.dtpTransactionDate.Value = Today
            Me.dtpTransactionDate.Checked = True
            Me.chkPrintReceiptOnSaving.Checked = True

            Me.SetNextTranNo(Me.stbAccountTranNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            If ex.Message.Contains("The Transaction No:") OrElse ex.Message.Contains("already exists") Then
                Me.SetNextTranNo(Me.stbAccountTranNo)
                Me.btnSave.PerformClick()
            Else : ErrorMessage(ex)
            End If
        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveOtherIncome()

        Dim oCurrenciesID As New LookupDataID.CurrenciesID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oOtherIncome As New SyncSoft.SQLDb.OtherIncome()

            With oOtherIncome
                .IncomeNo = RevertText(StringEnteredIn(Me.stbIncomeNo, "Income No!"))
                .IncomeDate = DateEnteredIn(Me.dtpIncomeDate, "Income Date!")
                .IncomeSourcesID = StringValueEnteredIn(Me.cboIncomeSourcesID, "Income Source!")
                .PayModesID = StringValueEnteredIn(Me.cboOIPayModesID, "Pay Modes!")
                .Amount = Me.nbxOIAmount.GetDecimal(False)
                .CurrenciesID = StringValueEnteredIn(Me.cboOICurrenciesID, "Currency!")
                .AmountTendered = DecimalEnteredIn(Me.nbxOIAmountTendered, False, "Amount Tendered!")
                .ExchangeRate = Me.nbxOIExchangeRate.GetDecimal(False)
                .Change = DecimalEnteredIn(Me.stbOIChange, False, "Change!")
                .DocumentNo = StringMayBeEnteredIn(Me.stbOIDocumentNo)
                .Notes = StringEnteredIn(Me.stbOINotes, "Notes!")
                .LoginID = CurrentUser.LoginID

                ValidateEntriesIn(Me.tpgOtherIncome)

                .Save()

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.chkPrintReceiptOnSaving.Checked Then
                Dim message As String = "You have not checked Print Receipt On Saving. " +
                           ControlChars.NewLine + "Would you want a receipt printed?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintOtherIncome(True)
            Else : Me.PrintOtherIncome(True)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me.tpgOtherIncome)

            Me.dtpIncomeDate.Value = Today
            Me.dtpIncomeDate.Checked = True
            Me.chkPrintReceiptOnSaving.Checked = True
            LoadLookupDataCombo(Me.cboOIPayModesID, LookupObjects.PayModes)
            LoadLookupDataCombo(Me.cboOICurrenciesID, LookupObjects.Currencies)
            Me.cboOICurrenciesID.SelectedValue = oCurrenciesID.UgandaShillings

            Me.SetNextIncomeNo()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub SaveRefunds()

        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.dgvPaymentRefunds.RowCount < 1 Then Throw New ArgumentException("Must Register At least one item!")



            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim receiptNo As String = RevertText(StringEnteredIn(Me.stbRefundReceiptNo, "Refund Receipt No!"))
            Dim refundNo As String = RevertText(StringEnteredIn(Me.stbRefundNo, "Refund No!"))
            Dim refundRequestNo As String = RevertText(StringEnteredIn(Me.stbRefundRequestNo, "Refund Request No"))
            Dim refundDate As Date = DateEnteredIn(Me.dtpRefundDate, "Refund Date!")
            Dim toRefundAmount As Decimal = Me.nbxToRefundAmount.GetDecimal(False)
            Dim notes As String = StringEnteredIn(Me.stbRefundNotes, "Notes")
            Dim entryLevelID As String = oDocumentTypeID.Refund()
            Dim oAdjustmentTypeID As New LookupDataID.AdjustmentTypeID()

            Dim toAcknowledgeQuantity As Integer = 0
            Dim message As String = String.Empty
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oRefunds As New SyncSoft.SQLDb.Refunds()
            Dim lRefunds As New List(Of DBConnect)
            Dim lRefundItems As New List(Of DBConnect)
            Dim transactions As New List(Of TransactionList(Of DBConnect))
            Dim lInvoiceAdjustments As New List(Of DBConnect)
            Dim lInvoiceAdjustmentDetail As New List(Of DBConnect)
            Dim lReturns As New List(Of DBConnect)
            Dim lReturnItems As New List(Of DBConnect)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If DecimalEnteredIn(stbRefundAmountPaid, False, "Amount Paid") < nbxTotalRefundAmount.GetDecimal(False) Then
                DisplayMessage("Total amount paid cannot be less amount refunded")
                Return
            End If

            With oRefunds
                .ReceiptNo = receiptNo
                .RefundNo = refundNo
                .RefundRequestNo = refundRequestNo
                .VisitTypeID = Me.visitTypeID
                .RefundDate = refundDate
                .Amount = toRefundAmount
                .AmountWords = NumberToWords(.Amount)
                .Notes = notes
                .LoginID = CurrentUser.LoginID


            End With
            lRefunds.Add(oRefunds)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For Each invoiceNo As String In Me.GetInvoiceNoList()
                Using oInvoiceAdjustments As New InvoiceAdjustments()

                    With oInvoiceAdjustments

                        .AdjustmentNo = RevertText(Me.GetNextInvoiceAdjustmentNo(invoiceNo))
                        .InvoiceNo = invoiceNo
                        .VisitTypeID = Me.visitTypeID
                        .EntryLevelID = oDocumentTypeID.Refund()
                        .AdjustmentTypeID = oAdjustmentTypeID.Down()
                        .ReversalActionID = oReversalActionID.Adjustment()
                        .AdjustmentDate = refundDate
                        .Amount = toRefundAmount
                        .LoginID = CurrentUser.LoginID


                        lInvoiceAdjustments.Add(oInvoiceAdjustments)
                    End With
                End Using
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For Each visitNo As String In Me.GetVisitNoList()

                Using oBillAdjustments As New SyncSoft.SQLDb.BillAdjustments()
                    With oBillAdjustments
                        .AdjustmentNo = RevertText(Me.GetNextBillAdjustmentNo(visitNo))
                        .BillNo = visitNo
                        .AdjustmentDate = refundDate
                        .VisitTypeID = Me.visitTypeID
                        .AdjustmenTypeID = oAdjustmentTypeID.Down
                        .LoginID = CurrentUser.LoginID


                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    End With
                    lReturns.Add(oBillAdjustments)
                End Using
            Next

            For rowNo As Integer = 0 To Me.dgvPaymentRefunds.Rows.Count - 1

                Dim cells As DataGridViewCellCollection = Me.dgvPaymentRefunds.Rows(rowNo).Cells

                Dim itemCode As String = StringEnteredIn(cells, Me.colRefItemCode, "Item Code!")
                Dim itemName As String = StringEnteredIn(cells, Me.colRefItemName, "Item Name!")
                Dim itemCategoryID As String = StringEnteredIn(cells, Me.colRefItemCategoryID, "Item Category!")
                Dim amount As Decimal = DecimalEnteredIn(Me.dgvPaymentRefunds.Rows(rowNo).Cells, colRefAmount, False)
                Dim newPrice As Decimal = DecimalEnteredIn(Me.dgvPaymentRefunds.Rows(rowNo).Cells, colRefNewPrice, False)
                Dim returnable As Boolean = CBool(BooleanMayBeEnteredIn(cells, colAcknowledgeable))
                Dim returnReason As String = StringEnteredIn(cells, Me.colRefundReason, "Refund Reason!")
                Dim visitNo As String = RevertText(StringEnteredIn(cells, Me.colRefVisitNo, "VisitNo!"))
                Dim invoiceNo As String = RevertText(StringMayBeEnteredIn(cells, Me.colRefInvoiceNo))
                Dim unitPrice As Decimal = DecimalEnteredIn(Me.dgvPaymentRefunds.Rows(rowNo).Cells, colRefSalesUnitPrice, False)
                Dim Quantity As Integer = IntegerEnteredIn(Me.dgvPaymentRefunds.Rows(rowNo).Cells, colRefQuantity)
                Dim billQuantity As Integer = IntegerEnteredIn(Me.dgvPaymentRefunds.Rows(rowNo).Cells, colRefSoldQuantity)
                Dim billAmount As Decimal = DecimalEnteredIn(Me.dgvPaymentRefunds.Rows(rowNo).Cells, colRefPaidAmount, False)
                Dim returnReasonDes As String = GetLookupDataDes(returnReason)

                If refundDate > Today Then Throw New ArgumentException("Return date can’t be ahead of today!")

                Dim pos As Integer = rowNo + 1
                If Quantity < 1 AndAlso amount < 1 Then Throw New ArgumentException("Returned quantity and return Amount can’t be less than one " + pos.ToString + "!")
                If Quantity > billQuantity Then Throw New ArgumentException("returned quantity can’t be more than bill quantity " + pos.ToString + "!")
                If amount > billAmount Then Throw New ArgumentException("returned amount can’t be more than bill amount!" + pos.ToString + "!")


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Me.visitTypeID.ToUpper.Equals(oVisitTypeID.OutPatient) Then




                    Using oRefundDetails As New RefundDetails()

                        With oRefundDetails

                            .RefundNo = refundNo
                            .VisitNo = visitNo
                            .ReceiptNo = receiptNo
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .ReturnReasonID = returnReason
                            .Quantity = Quantity
                            .Amount = amount
                            .LoginID = CurrentUser.LoginID

                        End With
                        lRefundItems.Add(oRefundDetails)
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If Not String.IsNullOrEmpty(invoiceNo) Then
                        Using oInvoiceDetailAdjustments As New SyncSoft.SQLDb.InvoiceDetailAdjustments()

                            With oInvoiceDetailAdjustments
                                .AdjustmentNo = RevertText(Me.GetNextInvoiceAdjustmentNo(invoiceNo))
                                .InvoiceNo = invoiceNo
                                .VisitNo = visitNo
                                .ItemCategoryID = itemCategoryID
                                .ItemCode = itemCode
                                .Quantity = Quantity
                                .Amount = amount
                                .ReturnReasonID = returnReason
                                .LoginID = CurrentUser.LoginID

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                            End With

                            lInvoiceAdjustmentDetail.Add(oInvoiceDetailAdjustments)
                        End Using
                    End If
                ElseIf Me.visitTypeID.ToUpper.Equals(oVisitTypeID.InPatient.ToUpper) Then


                    Using oRefundExtraBillItems As New RefundExtraBillItems()

                        With oRefundExtraBillItems

                            .RefundNo = refundNo
                            .ExtraBillNo = visitNo
                            .ReceiptNo = receiptNo
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .ReturnReasonID = returnReason
                            .Quantity = Quantity
                            .Amount = amount
                            .LoginID = CurrentUser.LoginID


                        End With
                        lRefundItems.Add(oRefundExtraBillItems)
                    End Using


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(invoiceNo) Then

                        Using oInvoiceExtraBillItemAdjustments As New SyncSoft.SQLDb.InvoiceExtraBillItemAdjustments()

                            With oInvoiceExtraBillItemAdjustments
                                .AdjustmentNo = RevertText(Me.GetNextInvoiceAdjustmentNo(invoiceNo))
                                .InvoiceNo = invoiceNo
                                .ExtraBillNo = visitNo
                                .ItemCategoryID = itemCategoryID
                                .ItemCode = itemCode
                                .Quantity = Quantity
                                .Amount = amount
                                .ReturnReasonID = returnReason
                                .LoginID = CurrentUser.LoginID


                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                            End With

                            lInvoiceAdjustmentDetail.Add(oInvoiceExtraBillItemAdjustments)
                        End Using
                    End If
                End If


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Me.visitTypeID.ToUpper().Equals(oVisitTypeID.OutPatient.ToUpper()) Then

                    Using oitemAdjustments As New SyncSoft.SQLDb.ItemAdjustments()

                        With oitemAdjustments
                            .VisitNo = visitNo
                            .AdjustmentNo = Me.GetNextBillAdjustmentNo(visitNo)
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .Quantity = Quantity
                            .Amount = amount
                            .NewPrice = newPrice
                            .Acknowledgeable = returnable
                            .EntryLevelID = entryLevelID
                            .Notes = returnReasonDes
                            .LoginID = CurrentUser.LoginID
                        End With

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lReturnItems.Add(oitemAdjustments)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End Using
                ElseIf Me.visitTypeID.ToUpper().Equals(oVisitTypeID.InPatient().ToUpper()) Then
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oExtraBillItemAdjustments As New SyncSoft.SQLDb.ExtraBillItemAdjustments()

                        With oExtraBillItemAdjustments
                            .ExtraBillNo = visitNo
                            .AdjustmentNo = Me.GetNextBillAdjustmentNo(visitNo)
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .EntryLevelID = entryLevelID
                            .Quantity = Quantity
                            .Amount = amount
                            .NewPrice = newPrice
                            .Acknowledgeable = returnable
                            .Notes = returnReasonDes
                            .LoginID = CurrentUser.LoginID
                        End With

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lReturnItems.Add(oExtraBillItemAdjustments)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End Using
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If

                If returnable Then toAcknowledgeQuantity += 1



            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxRefundOutstandingBalance)

            If outstandingBalance > 0 Then
                message = "This patient has outstanding balance. It’s recommended to check on the said balance before refunding. " +
                    ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ErrProvider.SetError(Me.nbxRefundOutstandingBalance, String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me.tpgRefunds)
            ValidateEntriesIn(Me.tpgRefunds, ErrProvider)



            transactions.Add(New TransactionList(Of DBConnect)(lRefunds, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lRefundItems, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lInvoiceAdjustments, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lInvoiceAdjustmentDetail, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lReturns, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lReturnItems, Action.Save))

            If WarningMessage("You are about to perform an irreversible action are you sure you want to continue?") = Windows.Forms.DialogResult.No Then Return
            DoTransactions(transactions)

            If toAcknowledgeQuantity > 0 Then
                DisplayMessage(toAcknowledgeQuantity.ToString + " has been returned. Please ensure that " + visitTypeID + " acknowledgement is done")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.chkPrintReceiptOnSaving.Checked Then
                message = "You have not checked Print Receipt On Saving. " + ControlChars.NewLine + "Would you want a receipt printed?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintRefunds(True)
            Else : Me.PrintRefunds(True)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me.tpgRefunds)

            Me.dtpRefundDate.Value = Today
            Me.dtpRefundDate.Checked = True
            Me.chkPrintReceiptOnSaving.Checked = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ShowPendingRefundRequest()
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub SaveExpenditure()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oExpenditure As New SyncSoft.SQLDb.Expenditure()
            Dim maxAmount As Decimal = DecimalMayBeEnteredIn(nbxMaxAmount)
            Dim bankedAmount As Decimal = Me.nbxEXAmount.GetDecimal(False)

            If bankedAmount <= 0 Then
                DisplayMessage("Amount banked must be greater than 0")
                Return
            End If
            With oExpenditure
                .ExpenditureNo = RevertText(StringEnteredIn(Me.stbExpenditureNo, "Expenditure No!"))
                .SpentDate = DateEnteredIn(Me.dtpSpentDate, "Spent Date!")
                .ExpenditureCategoryID = StringValueEnteredIn(Me.cboExpenditureCategoryID, "Expenditure Category!")
                .ExpenditureSourceTypeID = StringValueEnteredIn(Me.cboExpenditureSourceType, "Expenditure Source Type!")
                .ExchangeRate = nbxExchange.GetDecimal(False)
                .GivenTo = StringEnteredIn(Me.stbGivenTo, "Given To!")
                .Amount = Me.nbxEXAmount.GetDecimal(False)
                .DocumentNo = StringMayBeEnteredIn(Me.stbEXDocumentNo)
                If .ExpenditureSourceTypeID.ToUpper.Equals(oExpenditureSourceType.Bank()) Then
                    .AccountNo = StringValueEnteredIn(Me.cboAccountNames, "Account Name!")
                    If (maxAmount * .ExchangeRate) < .Amount Then
                        DisplayMessage("Amount spent cannot be greater than the balance on Account  ")
                        Return
                    End If

                Else : .AccountNo = String.Empty

                End If
                .Details = StringEnteredIn(Me.stbEXDetails, "Details!")
                .LoginID = CurrentUser.LoginID
                .BranchID = GetStaffCurrentBranch(CurrentUser.LoginID)
                ValidateEntriesIn(Me.tpgExpenditure)

                .Save()

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.chkPrintReceiptOnSaving.Checked Then
                Dim message As String = "You have not checked Print Receipt On Saving. " +
                           ControlChars.NewLine + "Would you want a receipt printed?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintExpenditure(True)
            Else : Me.PrintExpenditure(True)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me.tpgExpenditure)

            Me.dtpSpentDate.Value = Today
            Me.dtpSpentDate.Checked = True
            Me.chkPrintReceiptOnSaving.Checked = True

            Me.SetNextExpenditureNo()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            If ex.Message.Contains("The Expenditure No:") OrElse ex.Message.EndsWith("already exists") Then

                Me.SetNextExpenditureNo()
                Me.btnSave.PerformClick()

            Else : ErrorMessage(ex)
            End If
           
        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

    Private Sub tbcCashier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbcCashier.SelectedIndexChanged

        Dim oVariousOptions As New VariousOptions()

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcCashier.SelectedTab.Name

                Case Me.tpgCashPayment.Name

                    Me.btnSave.Enabled = True
                    Me.btnEdit.Visible = True
                    Me.btnAddExtraBill.Visible = True
                    Me.btnAddExtraBill.Text = "Add Extra Charge"
                    Me.btnAddExtraBill.Tag = "ExtraCharge"
                    Me.btnSelfRequests.Visible = True
                    Me.btnManageAccounts.Visible = True
                    Me.btnManageAccounts.Text = "Manage Cash Account"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.btnAddExtraBill.Enabled = Not String.IsNullOrEmpty(RevertText(StringMayBeEnteredIn(Me.stbPatientNo)))
                    Me.btnManageAccounts.Enabled = Not String.IsNullOrEmpty(RevertText(StringMayBeEnteredIn(Me.stbPatientNo)))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.btnPrint.Enabled = oVariousOptions.AllowProvisionalPrinting
                    Me.chkPrintReceiptOnSaving.Enabled = True
                    Me.chkPrintReceiptOnSaving.Checked = True
                    Me.pnlNavigateVisits.Visible = True
                    ResetControlsIn(Me.pnlNavigateVisits)
                    Me.SetNextReceiptNo(Me.stbReceiptNo)

                Case Me.tpgBillFormPayment.Name


                    Me.btnSave.Enabled = True
                    Me.btnEdit.Visible = False
                    Me.btnAddExtraBill.Visible = False
                  
                    Me.btnSelfRequests.Visible = False
                    Me.btnManageAccounts.Visible = True
                    Me.btnManageAccounts.Text = "Manage Cash Account"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.btnAddExtraBill.Enabled = Not String.IsNullOrEmpty(RevertText(StringMayBeEnteredIn(Me.stbBFPPatientNo)))
                    Me.btnManageAccounts.Enabled = Not String.IsNullOrEmpty(RevertText(StringMayBeEnteredIn(Me.stbBFPPatientNo)))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.btnPrint.Enabled = oVariousOptions.AllowProvisionalPrinting
                    Me.chkPrintReceiptOnSaving.Enabled = True
                    Me.chkPrintReceiptOnSaving.Checked = True
                    Me.pnlNavigateVisits.Visible = True
                    ResetControlsIn(Me.pnlNavigateVisits)
                    Me.SetNextReceiptNo(Me.stbBFPReceiptNo)

                Case Me.tpgBillsPayment.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.btnSave.Enabled = Me.dgvBillsPayment.RowCount > 0
                    Me.fbnExportTo.Enabled = Me.dgvBillsPayment.RowCount > 0
                    Me.btnAddExtraBill.Enabled = Me.dgvBillsPayment.RowCount > 0
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.btnEdit.Visible = False
                    Me.btnAddExtraBill.Visible = False
                
                    Me.btnSelfRequests.Visible = False
                    Me.btnManageAccounts.Visible = True
                    Me.btnManageAccounts.Text = "Manage Accounts"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBPBillModesID, "Account Category!")
                    Dim billNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboBPBillAccountNo)))
                    Me.btnManageAccounts.Enabled = (Not String.IsNullOrEmpty(billModesID) AndAlso Not String.IsNullOrEmpty(billNo))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.btnPrint.Enabled = oVariousOptions.AllowProvisionalPrinting
                    Me.chkPrintReceiptOnSaving.Enabled = True
                    Me.chkPrintReceiptOnSaving.Checked = True
                    Me.pnlNavigateVisits.Visible = False
                    Me.SetNextReceiptNo(Me.stbBPReceiptNo)

                Case Me.tpgCreditBillFormPayment.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.btnSave.Enabled = Me.dgvCBFPExtraBillItems.RowCount > 0
                    Me.fbnExportTo.Enabled = Me.dgvCBFPExtraBillItems.RowCount > 0
                    Me.btnAddExtraBill.Enabled = Me.dgvCBFPExtraBillItems.RowCount > 0
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.btnEdit.Visible = False
                    Me.btnAddExtraBill.Visible = False
                    Me.btnSelfRequests.Visible = False
                    Me.btnManageAccounts.Visible = True
                    Me.btnManageAccounts.Text = "Manage Accounts"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboCBFPBillModesID, "Account Category!")
                    Dim billNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboCBFPBillAccountNo)))
                    Me.btnManageAccounts.Enabled = (Not String.IsNullOrEmpty(billModesID) AndAlso Not String.IsNullOrEmpty(billNo))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.btnPrint.Enabled = oVariousOptions.AllowProvisionalPrinting
                    Me.chkPrintReceiptOnSaving.Enabled = True
                    Me.chkPrintReceiptOnSaving.Checked = True
                    Me.pnlNavigateVisits.Visible = False
                    Me.SetNextReceiptNo(Me.stbCBFPReceiptNo)

                Case Me.tpgManageAccounts.Name

                    Me.btnSave.Enabled = True
                    Me.btnEdit.Visible = False
                    Me.btnAddExtraBill.Visible = False
                    Me.btnSelfRequests.Visible = False
                    Me.btnManageAccounts.Visible = False
                    Me.btnPrint.Enabled = oVariousOptions.AllowProvisionalPrinting
                    Me.chkPrintReceiptOnSaving.Enabled = True
                    Me.chkPrintReceiptOnSaving.Checked = True
                    Me.pnlNavigateVisits.Visible = False
                    Me.SetNextTranNo(Me.stbAccountTranNo)

                Case Me.tpgOtherIncome.Name

                    Me.btnSave.Enabled = True
                    Me.btnEdit.Visible = False
                    Me.btnAddExtraBill.Visible = False
                    Me.btnSelfRequests.Visible = False
                    Me.btnManageAccounts.Visible = False
                    Me.btnPrint.Enabled = oVariousOptions.AllowProvisionalPrinting
                    Me.chkPrintReceiptOnSaving.Enabled = True
                    Me.chkPrintReceiptOnSaving.Checked = True
                    Me.pnlNavigateVisits.Visible = False
                    Me.SetNextIncomeNo()

                Case Me.tpgRefunds.Name

                    Me.btnSave.Enabled = True
                    Me.btnEdit.Visible = False
                    Me.btnAddExtraBill.Visible = False
                    Me.btnSelfRequests.Visible = False
                    Me.btnManageAccounts.Visible = False
                    Me.btnPrint.Enabled = oVariousOptions.AllowProvisionalPrinting
                    Me.chkPrintReceiptOnSaving.Enabled = True
                    Me.chkPrintReceiptOnSaving.Checked = True
                    Me.pnlNavigateVisits.Visible = False

                Case Me.tpgExpenditure.Name

                    Me.btnSave.Enabled = True
                    Me.btnEdit.Visible = False
                    Me.btnAddExtraBill.Visible = False
                    Me.btnSelfRequests.Visible = False
                    Me.btnManageAccounts.Visible = False
                    Me.btnPrint.Enabled = oVariousOptions.AllowProvisionalPrinting
                    Me.chkPrintReceiptOnSaving.Enabled = True
                    Me.chkPrintReceiptOnSaving.Checked = True
                    Me.pnlNavigateVisits.Visible = False
                    Me.SetNextExpenditureNo()

                Case Else

                    Me.btnSave.Enabled = True
                    Me.btnEdit.Visible = False
                    Me.btnAddExtraBill.Visible = False
                    Me.btnSelfRequests.Visible = False
                    Me.btnManageAccounts.Visible = False
                    Me.btnPrint.Enabled = False
                    Me.chkPrintReceiptOnSaving.Enabled = False
                    Me.chkPrintReceiptOnSaving.Checked = False
                    Me.pnlNavigateVisits.Visible = False

            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.tbcCashier.SelectedTab.Name.Equals(Me.tpgCashPayment.Name) AndAlso Me.btnEdit.Text = UpdateText Then
                Me.EnableEditControls(False)

            Else : Me.ApplySecurity()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnExportTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnExportTo.Click

        Dim fStatus As New SyncSoft.Common.Win.Forms.Status()

        Try

            Me.Cursor = Cursors.WaitCursor()

            Dim billNo As String = StringMayBeEnteredIn(Me.cboBPBillAccountNo)
            Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbBPBillCustomerName)

            If String.IsNullOrEmpty(billNo) Then Return
            Dim documentTitle As String = "Bill for " + billCustomerName + " as at " + FormatDate(Today)

            Select Case True

                Case Me.rdoBPGetPeriod.Checked

                    Dim startDate As Date = DateEnteredIn(Me.dtpBPStartDate, "Start Date")
                    Dim endDate As Date = DateEnteredIn(Me.dtpBPEndDate, "End Date")

                    If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    documentTitle = "Bill for " + billCustomerName + " for the period between " +
                        FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.rdoBPGetAll.Checked
                    documentTitle = "Bill for " + billCustomerName + " for all period!"
            End Select

            fStatus.Show("Exporting Bill(s) for " + billCustomerName + " to Excel...", FormStartPosition.CenterScreen)
            ExportToExcel(Me.dgvBillsPayment, "Bill(s) for " + billCustomerName, documentTitle)

        Catch ex As Exception
            fStatus.Close()
            ErrorMessage(ex)

        Finally
            fStatus.Close()
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnCBFPExportTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnCBFPExportTo.Click

        Dim fStatus As New SyncSoft.Common.Win.Forms.Status()

        Try

            Me.Cursor = Cursors.WaitCursor()

            Dim billNo As String = StringMayBeEnteredIn(Me.cboCBFPBillAccountNo)
            Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbCBFPBillCustomerName)

            If String.IsNullOrEmpty(billNo) Then Return
            Dim documentTitle As String = "Bill for " + billCustomerName + " as at " + FormatDate(Today)

            Select Case True

                Case Me.rdoCBFPGetPeriod.Checked

                    Dim startDate As Date = DateEnteredIn(Me.dtpCBFPStartDate, "Start Date")
                    Dim endDate As Date = DateEnteredIn(Me.dtpCBFPEndDate, "End Date")

                    If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    documentTitle = "Bill for " + billCustomerName + " for the period between " +
                        FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.rdoCBFPGetAll.Checked
                    documentTitle = "Bill for " + billCustomerName + " for all period!"
            End Select

            fStatus.Show("Exporting Bill(s) for " + billCustomerName + " to Excel...", FormStartPosition.CenterScreen)
            ExportToExcel(Me.dgvCBFPExtraBillItems, "Bill(s) for " + billCustomerName, documentTitle)

        Catch ex As Exception
            fStatus.Close()
            ErrorMessage(ex)

        Finally
            fStatus.Close()
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcCashier.SelectedTab.Name

                Case Me.tpgCashPayment.Name
                    Me.PrintCashReceipt(False)

                Case Me.tpgBillFormPayment.Name
                    Me.PrintBillFormReceipt(False)

                Case Me.tpgBillsPayment.Name
                    Me.PrintBPReceipt(False)

                Case Me.tpgCreditBillFormPayment.Name
                    Me.PrintCBFPReceipt(False)

                Case Me.tpgManageAccounts.Name
                    Me.PrintAccounts(False)

                Case Me.tpgOtherIncome.Name
                    Me.PrintOtherIncome(False)

                Case Me.tpgRefunds.Name
                    Me.PrintRefunds(False)

                Case Me.tpgExpenditure.Name
                    Me.PrintExpenditure(False)

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Visits Navigate "

    Private Sub EnableNavigateVisitsCTLS(ByVal state As Boolean)

        Dim visitNo As String
        Dim patientNo As String
        Dim startPosition As Integer
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Select Case Me.tbcCashier.SelectedTab.Name

                    Case Me.tpgCashPayment.Name

                        visitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                        patientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

                    Case Me.tpgBillFormPayment.Name

                        visitNo = RevertText(StringEnteredIn(Me.stbBFPVisitNo, "Visit No!"))
                        patientNo = RevertText(StringEnteredIn(Me.stbBFPPatientNo, "Patient No!"))

                    Case Else
                        visitNo = String.Empty
                        patientNo = String.Empty

                End Select

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(currentValue.ToString())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(visitNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.tbcCashier.SelectedTab.Name

                Case Me.tpgCashPayment.Name

                    Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
                    Me.LoadCashPaymentData(visitNo)

                Case Me.tpgBillFormPayment.Name

                    Me.stbBFPVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
                    Me.LoadBillFormPaymentData(visitNo)

                Case Else : Return

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Cashier Printing "

    Private Sub PrintCashReceipt(ByVal receiptSaved As Boolean)

        Dim dlgPrint As New PrintDialog()
        Dim oprinterPaperSize As New LookupDataID.PrinterPaperSize()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPaymentDetails.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry on payment details!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvPaymentDetails.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry on payment details!")

            Select Case cashierPrinterPaperSize
                Case GetLookupDataDes(oprinterPaperSize.A4)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cashReceiptSaved = receiptSaved
                    Me.SetCashPrintData()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    dlgPrint.Document = docCashReceipt
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docCashReceipt.Print()

                Case String.Empty
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cashReceiptSaved = receiptSaved
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
            Dim title As String

            If Me.cashReceiptSaved Then
                title = AppData.ProductOwner.ToUpper() + " Cash Receipt".ToUpper()
            Else : title = AppData.ProductOwner.ToUpper() + " Cash Receipt (Provisional)".ToUpper()
            End If

            Dim fromName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim receiptNo As String = StringMayBeEnteredIn(Me.stbReceiptNo)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim payDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpPayDate))
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim notes As String = StringMayBeEnteredIn(Me.stbNotes)
            Dim docNo As String = StringMayBeEnteredIn(Me.stbDocumentNo)
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

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not oVariousOptions.HideCashReceiptHeader Then yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

                        If Not String.IsNullOrEmpty(docNo) Then

                            .DrawString("Document No:", bodyNormalFont, Brushes.Black, xPos, yPos)
                            .DrawString(docNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        End If

                        .DrawString(notesData.ToString(), bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
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

                    If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, rowNo).Value) = True Then

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

                    End If
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                cashParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            Dim changeAmount As New System.Text.StringBuilder(String.Empty)

            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbTotalAmountPaid, True)
            Dim totalChange As Decimal = DecimalMayBeEnteredIn(Me.stbChange, True)
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

            If totalChange > 0 Then
                changeAmount.Append(ControlChars.NewLine)
                changeAmount.Append("Change: ")
                changeAmount.Append(FormatNumber(totalChange, AppData.DecimalPlaces).PadLeft(padTotalAmount + 6))

                changeAmount.Append(ControlChars.NewLine)
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, changeAmount.ToString()))
            End If

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim amountTenderedData As New System.Text.StringBuilder(String.Empty)
            Dim foreignCurrencyData As New System.Text.StringBuilder(String.Empty)

            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxExchangeRate, False)
            Dim change As Decimal = DecimalMayBeEnteredIn(Me.stbChange, True)
            Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboCurrenciesID, "Currency!")
            Dim currency As String = StringMayBeEnteredIn(Me.cboCurrenciesID)
            Dim amountTenderedLocalCurrency As Decimal = amountTendered * exchangeRate

            amountTenderedData.Append(ControlChars.NewLine)
            amountTenderedData.Append("Amount Tendered: ")
            amountTenderedData.Append(FormatNumber(amountTenderedLocalCurrency, AppData.DecimalPlaces).PadLeft(padAmountTendered))
            amountTenderedData.Append(ControlChars.NewLine)

            If Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                foreignCurrencyData.Append("(" + currency + ": " + FormatNumber(amountTendered, AppData.DecimalPlaces))
                foreignCurrencyData.Append(", Exchange Rate: " + FormatNumber(exchangeRate, AppData.DecimalPlaces) + ")")
                foreignCurrencyData.Append(ControlChars.NewLine)
            End If

            If Me.chkUseAccountBalance.Checked OrElse (Me.chkSendBalanceToAccount.Checked AndAlso Not change = 0) OrElse
                Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, amountTenderedData.ToString()))
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                cashParagraphs.Add(New PrintParagraps(bodyNormalFont, foreignCurrencyData.ToString()))
            End If

            If Me.chkUseAccountBalance.Checked Then

                Dim accountData As New System.Text.StringBuilder(String.Empty)
                Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxCashAccountBalance, True)
                Dim balanceFromAccount As Decimal

                If accountBalance <= totalBill Then
                    balanceFromAccount = accountBalance
                Else : balanceFromAccount = totalBill
                End If

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.cashReceiptSaved Then
                Dim provisionalData As New System.Text.StringBuilder(String.Empty)
                provisionalData.Append(ControlChars.NewLine)
                provisionalData.Append("*** Remember to return this provisional receipt for a final one ***")
                provisionalData.Append(ControlChars.NewLine)
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, provisionalData.ToString()))

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim appreciationData As New System.Text.StringBuilder(String.Empty)
            appreciationData.Append(ControlChars.NewLine)
            appreciationData.Append("*** Thank you for choosing " + AppData.ProductOwner + " ***")
            appreciationData.Append(ControlChars.NewLine)
            cashParagraphs.Add(New PrintParagraps(bodyBoldFont, appreciationData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            cashParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function GetPaymentDetailsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim paymentDetails As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvPaymentDetails.RowCount - 1

                If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPaymentDetails.Rows(rowNo).Cells
                    Dim category As String = cells.Item(Me.colCategory.Name).Value.ToString()
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")

                    paymentDetails.Add(New Tuple(Of String, Decimal)(category, amount))

                End If
            Next

            Return paymentDetails

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function GetPaymentDetailsItemTotalsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim paymentDetails As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvPaymentDetails.RowCount - 1

                If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPaymentDetails.Rows(rowNo).Cells
                    Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")

                    paymentDetails.Add(New Tuple(Of String, Decimal)(itemName, amount))

                End If
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
            If Me.dgvPaymentDetails.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for Payments!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvPaymentDetails.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry for payments!")

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

            Dim title As String = AppData.ProductOwner.ToUpper()

            'Dim title As String
            'If (AppData.ProductOwner.Length > 27) Then
            '    title = AppData.ProductOwner.Substring(0, 26).ToUpper() + ControlChars.NewLine + AppData.ProductOwner.Substring(26) + ControlChars.NewLine + "Cashier PrintOut".ToUpper()
            'Else
            '    title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Cashier PrintOut".ToUpper()
            'End If

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim VisitNo As String = StringMayBeEnteredIn(Me.stbVisitNo)
            Dim VisitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim BillCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)
            Dim ReceiptNo As String = StringMayBeEnteredIn(Me.stbReceiptNo)

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
                        .DrawString("CASHIER RECEIPT".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
                        yPos += 3 * lineHeight
                    Else
                        .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                        yPos += lineHeight
                        .DrawString("CASHIER RECEIPT".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
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

                    If (BillCustomerName.Length > 14) Then

                        .DrawString("Bill Customer: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(BillCustomerName.Substring(0, 14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                        .DrawString(BillCustomerName.Substring(14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += 2 * lineHeight

                    Else
                        .DrawString("Bill Customer: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(BillCustomerName.Trim, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += 2 * lineHeight
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

        Dim padQty As Integer = 4
        Dim padUp As Integer = 9
        Dim padDc As Integer = 8
        Dim padTl As Integer = 13


        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        CashThermalReceiptParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
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
            CashThermalReceiptParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            Dim Amount As Double = 0.0
            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvPaymentDetails.RowCount - 1

                If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPaymentDetails.Rows(rowNo).Cells

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim ItemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                    Dim itemQuantity As String = cells.Item(Me.colQuantity.Name).Value.ToString()
                    Dim itemUnitPrice As String = cells.Item(Me.colUnitPrice.Name).Value.ToString()
                    'Dim itemDicount As String = cells.Item(Me.colDiscount.Name).Value.ToString()
                    Dim itemAmount As String = cells.Item(Me.colAmount.Name).Value.ToString()
                    'tableData.Append(itemNo.PadRight(padItemNo))
                    tableData.Append(ItemName.PadRight(padItemNo))
                    tableData.Append(ControlChars.NewLine)
                    tableData.Append(itemQuantity.PadRight(padQty))
                    tableData.Append(itemUnitPrice.PadLeft(padUp))
                    'tableData.Append(itemDicount.PadLeft(padDc))
                    tableData.Append(itemAmount.PadLeft(padTl))
                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            tableData.Append(ControlChars.NewLine)
            CashThermalReceiptParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

           
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim paymentDetailsItemTotals = From data In Me.GetPaymentDetailsItemTotalsList Group data By ItemName = data.Item1
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
            CashThermalReceiptParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim appreciationData As New System.Text.StringBuilder(String.Empty)
            appreciationData.Append(ControlChars.NewLine)
            appreciationData.Append("*** Thank you for choosing ***")
            appreciationData.Append(ControlChars.NewLine)
            appreciationData.Append("*** " + AppData.ProductOwner + " ***")
            appreciationData.Append(ControlChars.NewLine)
            CashThermalReceiptParagraphs.Add(New PrintParagraps(bodyBoldFont, appreciationData.ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("On " + FormatDate(Now))
            footerData.Append(ControlChars.NewLine)
            footerData.Append("At " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            CashThermalReceiptParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " Bill Form Printing "

    Private Sub PrintBillFormReceipt(ByVal receiptSaved As Boolean)

        Dim dlgPrint As New PrintDialog()
        Dim oprinterPaperSize As New LookupDataID.PrinterPaperSize()
        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPaymentExtraBillItems.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry on bill form payments!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvPaymentExtraBillItems.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPaymentExtraBillItems.Item(Me.colBFPInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry on bill form payments!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case cashierPrinterPaperSize
                Case GetLookupDataDes(oprinterPaperSize.A4)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.billFormReceiptSaved = receiptSaved
                    Me.SetBillFormPrintData()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    dlgPrint.Document = docBillFormReceipt
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docBillFormReceipt.Print()

                Case String.Empty
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.billFormReceiptSaved = receiptSaved
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

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub docBillFormReceipt_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docBillFormReceipt.PrintPage

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
            Dim title As String

            If Me.billFormReceiptSaved Then
                title = AppData.ProductOwner.ToUpper() + " Cash Receipt".ToUpper()
            Else : title = AppData.ProductOwner.ToUpper() + " Cash Receipt (Provisional)".ToUpper()
            End If

            Dim fromName As String = StringMayBeEnteredIn(Me.stbBFPFullName)
            Dim receiptNo As String = StringMayBeEnteredIn(Me.stbBFPReceiptNo)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbBFPPatientNo)
            Dim payDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpBFPPayDate))
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

            ElseIf oVariousOptions.CategorizeVisitPaymentDetails Then

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

                    If CBool(Me.dgvPaymentExtraBillItems.Item(Me.colBFPInclude.Name, rowNo).Value) = True Then

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

                    End If
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

            ElseIf oVariousOptions.CategorizeVisitPaymentDetails Then
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

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim amountTenderedData As New System.Text.StringBuilder(String.Empty)
            Dim foreignCurrencyData As New System.Text.StringBuilder(String.Empty)

            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxBFPAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxBFPExchangeRate, False)
            Dim change As Decimal = DecimalMayBeEnteredIn(Me.stbBFPChange, True)
            Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboBFPCurrenciesID, "Currency!")
            Dim currency As String = StringMayBeEnteredIn(Me.cboBFPCurrenciesID)
            Dim amountTenderedLocalCurrency As Decimal = amountTendered * exchangeRate

            amountTenderedData.Append(ControlChars.NewLine)
            amountTenderedData.Append("Amount Tendered: ")
            amountTenderedData.Append(FormatNumber(amountTenderedLocalCurrency, AppData.DecimalPlaces).PadLeft(padAmountTendered))
            amountTenderedData.Append(ControlChars.NewLine)

            If Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                foreignCurrencyData.Append("(" + currency + ": " + FormatNumber(amountTendered, AppData.DecimalPlaces))
                foreignCurrencyData.Append(", Exchange Rate: " + FormatNumber(exchangeRate, AppData.DecimalPlaces) + ")")
                foreignCurrencyData.Append(ControlChars.NewLine)
            End If

            If Me.chkBFPUseAccountBalance.Checked OrElse (Me.chkBFPSendBalanceToAccount.Checked AndAlso Not change = 0) OrElse
                Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                billFormParagraphs.Add(New PrintParagraps(bodyBoldFont, amountTenderedData.ToString()))
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                billFormParagraphs.Add(New PrintParagraps(bodyNormalFont, foreignCurrencyData.ToString()))
            End If

            If Me.chkBFPUseAccountBalance.Checked Then

                Dim accountData As New System.Text.StringBuilder(String.Empty)
                Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxBFPCashAccountBalance, True)
                Dim balanceFromAccount As Decimal

                If accountBalance <= totalBill Then
                    balanceFromAccount = accountBalance
                Else : balanceFromAccount = totalBill
                End If

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.billFormReceiptSaved Then
                Dim provisionalData As New System.Text.StringBuilder(String.Empty)
                provisionalData.Append(ControlChars.NewLine)
                provisionalData.Append("*** Remember to return this provisional receipt for a final one ***")
                provisionalData.Append(ControlChars.NewLine)
                billFormParagraphs.Add(New PrintParagraps(bodyBoldFont, provisionalData.ToString()))

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim appreciationData As New System.Text.StringBuilder(String.Empty)
            appreciationData.Append(ControlChars.NewLine)
            appreciationData.Append("*** Thank you for choosing " + AppData.ProductOwner + " ***")
            appreciationData.Append(ControlChars.NewLine)
            billFormParagraphs.Add(New PrintParagraps(bodyBoldFont, appreciationData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            billFormParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function GetPaymentExtraBillItemsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim paymentExtraBillItems As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvPaymentExtraBillItems.RowCount - 1

                If CBool(Me.dgvPaymentExtraBillItems.Item(Me.colBFPInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPaymentExtraBillItems.Rows(rowNo).Cells
                    Dim category As String = cells.Item(Me.colBFPCategory.Name).Value.ToString()
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colBFPAmount, False, "amount!")

                    paymentExtraBillItems.Add(New Tuple(Of String, Decimal)(category, amount))

                End If
            Next

            Return paymentExtraBillItems

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region " Bills Payment Printing "

    Private Sub PrintBPReceipt(ByVal receiptSaved As Boolean)

        Dim dlgPrint As New PrintDialog()
        Dim oprinterPaperSize As New LookupDataID.PrinterPaperSize()
        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvBillsPayment.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry on bills payment details!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvBillsPayment.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvBillsPayment.Item(Me.colBPInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry on bills payment details!")

          
            Select Case cashierPrinterPaperSize
                Case GetLookupDataDes(oprinterPaperSize.A4)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.bPReceiptSaved = receiptSaved
                    Me.SetBPPrintData()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    dlgPrint.Document = docBPReceipt
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docBPReceipt.Print()

                Case String.Empty
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.bPReceiptSaved = receiptSaved
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

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub docBPReceipt_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docBPReceipt.PrintPage

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim oBillModesID As New LookupDataID.BillModesID()

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
            Dim title As String

            If Me.bPReceiptSaved Then
                title = AppData.ProductOwner.ToUpper() + " Bills Payment Receipt".ToUpper()
            Else : title = AppData.ProductOwner.ToUpper() + " Bills Payment Receipt (Provisional)".ToUpper()
            End If

            Dim fullName As String
            Dim payMode As String
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBPBillModesID)
            Dim fromName As String = StringMayBeEnteredIn(Me.stbBPBillCustomerName)

            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbBPVisitNo))
            If String.IsNullOrEmpty(visitNo) Then
                fullName = String.Empty
            Else : fullName = GetPatientFullName(visitNo)
            End If

            Dim receiptNo As String = StringMayBeEnteredIn(Me.stbBPReceiptNo)
            Dim billAccountNo As String = StringMayBeEnteredIn(Me.cboBPBillAccountNo)
            Dim payDate As String = FormatDate(Today)
            Dim documentNo As String = StringMayBeEnteredIn(Me.stbBPDocumentNo)
            If String.IsNullOrEmpty(documentNo) Then
                payMode = StringMayBeEnteredIn(Me.cboBPPayModesID)
            Else : payMode = StringMayBeEnteredIn(Me.cboBPPayModesID) + " (No: " + documentNo + ")"
            End If
            Dim startDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpBPStartDate))
            Dim endDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpBPEndDate))

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
                    If String.IsNullOrEmpty(fullName) Then
                        .DrawString(fromName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    Else : .DrawString(fromName + " (" + fullName + ")", bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    End If
                    yPos += lineHeight

                    .DrawString("Receipt No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(receiptNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                    If billModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then
                        .DrawString("Insurance No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    Else : .DrawString("Account No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    End If
                    .DrawString(billAccountNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Pay Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(payDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                    .DrawString("Mode of Payment: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(payMode, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)

                    If Me.rdoBPGetPeriod.Checked Then
                        yPos += lineHeight

                        .DrawString("Start Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(startDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                        .DrawString("End Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                        .DrawString(endDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)

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
            For rowNo As Integer = 0 To Me.dgvBillsPayment.RowCount - 1

                If CBool(Me.dgvBillsPayment.Item(Me.colBPInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvBillsPayment.Rows(rowNo).Cells

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

                End If
            Next

            If Not oVariousOptions.HideCreditBillsPaymentReceiptDetails Then
                bPParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
            End If

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            Dim withholdingTaxLine As New System.Text.StringBuilder(String.Empty)
            Dim grandDiscountLine As New System.Text.StringBuilder(String.Empty)
            Dim netBillLine As New System.Text.StringBuilder(String.Empty)
            Dim netBill As Decimal = DecimalMayBeEnteredIn(stbBPTotalBill)
            Dim withholdingTax As Decimal = DecimalMayBeEnteredIn(nbxBPWithholdingTax)
            Dim grandDiscount As Decimal = DecimalMayBeEnteredIn(Me.nbxBPGrandDiscount)
            Dim totalBill = netBill + withholdingTax + grandDiscount

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
               
                If withholdingTax > 0 Then
                    withholdingTaxLine.Append("Withholding Tax: ")
                    withholdingTaxLine.Append(FormatNumber(withholdingTax, AppData.DecimalPlaces).PadLeft(padTotalAmount - 4))
                End If
                If grandDiscount > 0 Then
                    grandDiscountLine.Append("Grand Discount: ")
                    grandDiscountLine.Append(FormatNumber(grandDiscount, AppData.DecimalPlaces).PadLeft(padTotalAmount - 2))
                End If
                
                totalAmount.Append("Medical Bills Total Amount: ")
                totalAmount.Append(FormatNumber(totalBill, AppData.DecimalPlaces).PadLeft(padTotalAmount - 14))

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

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim amountTenderedData As New System.Text.StringBuilder(String.Empty)
            Dim foreignCurrencyData As New System.Text.StringBuilder(String.Empty)

            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxBPAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxBPExchangeRate, False)
            Dim change As Decimal = DecimalMayBeEnteredIn(Me.stbBPChange, True)
            Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboBPCurrenciesID, "Currency!")
            Dim currency As String = StringMayBeEnteredIn(Me.cboBPCurrenciesID)
            Dim amountTenderedLocalCurrency As Decimal = amountTendered * exchangeRate

            amountTenderedData.Append(ControlChars.NewLine)
            amountTenderedData.Append("Amount Tendered: ")
            amountTenderedData.Append(FormatNumber(amountTenderedLocalCurrency, AppData.DecimalPlaces).PadLeft(padAmountTendered))
            amountTenderedData.Append(ControlChars.NewLine)

            If Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                foreignCurrencyData.Append("(" + currency + ": " + FormatNumber(amountTendered, AppData.DecimalPlaces))
                foreignCurrencyData.Append(", Exchange Rate: " + FormatNumber(exchangeRate, AppData.DecimalPlaces) + ")")
                foreignCurrencyData.Append(ControlChars.NewLine)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkBPUseAccountBalance.Checked OrElse (Me.chkBPSendBalanceToAccount.Checked AndAlso Not change = 0) OrElse
                  Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                bPParagraphs.Add(New PrintParagraps(bodyBoldFont, amountTenderedData.ToString()))
            End If

            If Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                bPParagraphs.Add(New PrintParagraps(bodyNormalFont, foreignCurrencyData.ToString()))
            End If

            If Me.chkBPUseAccountBalance.Checked Then

                Dim accountData As New System.Text.StringBuilder(String.Empty)
                Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.stbBPAccountBalance, True)
                Dim balanceFromAccount As Decimal

                If accountBalance <= totalBill Then
                    balanceFromAccount = accountBalance
                Else : balanceFromAccount = totalBill
                End If

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.bPReceiptSaved Then
                Dim provisionalData As New System.Text.StringBuilder(String.Empty)
                provisionalData.Append(ControlChars.NewLine)
                provisionalData.Append("*** Remember to return this provisional receipt for a final one ***")
                provisionalData.Append(ControlChars.NewLine)
                bPParagraphs.Add(New PrintParagraps(bodyBoldFont, provisionalData.ToString()))

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim appreciationData As New System.Text.StringBuilder(String.Empty)
            appreciationData.Append(ControlChars.NewLine)
            appreciationData.Append("*** Thank you for choosing " + AppData.ProductOwner + " ***")
            appreciationData.Append(ControlChars.NewLine)
            bPParagraphs.Add(New PrintParagraps(bodyBoldFont, appreciationData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            bPParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Function GetPaymentBPItemsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim paymentbP As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvBillsPayment.RowCount - 1

                If CBool(Me.dgvBillsPayment.Item(Me.colBPInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvBillsPayment.Rows(rowNo).Cells
                    Dim category As String = cells.Item(Me.colBPCategory.Name).Value.ToString()
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colBPAmount, False, "amount!")

                    paymentbP.Add(New Tuple(Of String, Decimal)(category, amount))

                End If
            Next

            Return paymentbP

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
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvPaymentExtraBillItems.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPaymentExtraBillItems.Item(Me.colBFPInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry for payments!")

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
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBFPBillMode)
            Dim BillCustomerName As String = StringMayBeEnteredIn(Me.stbBFPCustomerName)
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
                        .DrawString("IPD CASHIER RECEIPT".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
                        yPos += 3 * lineHeight
                    Else
                        .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                        yPos += lineHeight
                        .DrawString("IPD CASHIER RECEIPT".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
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

                    If (BillCustomerName.Length > 14) Then

                        .DrawString("Bill Customer: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(BillCustomerName.Substring(0, 14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                        .DrawString(BillCustomerName.Substring(14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += 2 * lineHeight

                    Else
                        .DrawString("Bill Customer: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(BillCustomerName.Trim, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += 2 * lineHeight
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

                    If CBool(Me.dgvPaymentExtraBillItems.Item(Me.colBFPInclude.Name, rowNo).Value) = True Then

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

                    End If
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


#Region "Bills Payment THERMAL RECEIPT PRINTOUT"

    Private Sub PrintBPThermalReceipt()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvBillsPayment.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for Payments!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvBillsPayment.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvBillsPayment.Item(Me.colBPInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry for payments!")

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
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBPBillModesID)
            Dim fromName As String = StringMayBeEnteredIn(Me.stbBPBillCustomerName)

            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbBPVisitNo))
            If String.IsNullOrEmpty(visitNo) Then
                fullName = String.Empty
            Else : fullName = GetPatientFullName(visitNo)
            End If

            Dim receiptNo As String = StringMayBeEnteredIn(Me.stbBPReceiptNo)
            Dim billAccountNo As String = StringMayBeEnteredIn(Me.cboBPBillAccountNo)
            Dim payDate As String = FormatDate(Today)
            Dim documentNo As String = StringMayBeEnteredIn(Me.stbBPDocumentNo)
            If String.IsNullOrEmpty(documentNo) Then
                payMode = StringMayBeEnteredIn(Me.cboBPPayModesID)
            Else : payMode = StringMayBeEnteredIn(Me.cboBPPayModesID) + " (No: " + documentNo + ")"
            End If
            Dim startDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpBPStartDate))
            Dim endDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpBPEndDate))

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

                    .DrawString("Visit No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(VisitNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
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



                For rowNo As Integer = 0 To Me.dgvBillsPayment.RowCount - 1

                    If CBool(Me.dgvBillsPayment.Item(Me.colBPInclude.Name, rowNo).Value) = True Then

                        Dim cells As DataGridViewCellCollection = Me.dgvBillsPayment.Rows(rowNo).Cells

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

                    End If
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



#Region " Credit Bill Form Payment Printing "

    Private Sub PrintCBFPReceipt(ByVal receiptSaved As Boolean)

        Dim dlgPrint As New PrintDialog()
        Dim oprinterPaperSize As New LookupDataID.PrinterPaperSize()
        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvCBFPExtraBillItems.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry on credit bill form payment details!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvCBFPExtraBillItems.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvCBFPExtraBillItems.Item(Me.colCBFPInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry on credit bill form payment details!")

            Select Case cashierPrinterPaperSize

                Case GetLookupDataDes(oprinterPaperSize.A4)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cBFPReceiptSaved = receiptSaved
                    Me.SetCBFPPrintData()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    dlgPrint.Document = docCBFPReceipt
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docCBFPReceipt.Print()
                Case String.Empty

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cBFPReceiptSaved = receiptSaved
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

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub docCBFPReceipt_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docCBFPReceipt.PrintPage

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim oBillModesID As New LookupDataID.BillModesID()

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
            Dim title As String

            If Me.cBFPReceiptSaved Then
                title = AppData.ProductOwner.ToUpper() + " CR Bill Form Payment Receipt".ToUpper()
            Else : title = AppData.ProductOwner.ToUpper() + " CR Bill Form Payment Receipt (Provisional)".ToUpper()
            End If

            Dim fullName As String
            Dim payMode As String
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboCBFPBillModesID)
            Dim fromName As String = StringMayBeEnteredIn(Me.stbCBFPBillCustomerName)

            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbCBFPVisitNo))
            If String.IsNullOrEmpty(visitNo) Then
                fullName = String.Empty
            Else : fullName = GetPatientFullName(visitNo)
            End If

            Dim receiptNo As String = StringMayBeEnteredIn(Me.stbCBFPReceiptNo)
            Dim billAccountNo As String = StringMayBeEnteredIn(Me.cboCBFPBillAccountNo)
            Dim payDate As String = FormatDate(Today)
            Dim documentNo As String = StringMayBeEnteredIn(Me.stbCBFPDocumentNo)
            If String.IsNullOrEmpty(documentNo) Then
                payMode = StringMayBeEnteredIn(Me.cboCBFPPayModesID)
            Else : payMode = StringMayBeEnteredIn(Me.cboCBFPPayModesID) + " (No: " + documentNo + ")"
            End If
            Dim startDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpCBFPStartDate))
            Dim endDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpCBFPEndDate))

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
                    If String.IsNullOrEmpty(fullName) Then
                        .DrawString(fromName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    Else : .DrawString(fromName + " (" + fullName + ")", bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    End If
                    yPos += lineHeight

                    .DrawString("Receipt No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(receiptNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                    If billModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then
                        .DrawString("Insurance No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    Else : .DrawString("Account No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    End If
                    .DrawString(billAccountNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Pay Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(payDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                    .DrawString("Mode of Payment: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(payMode, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)

                    If Me.rdoCBFPGetPeriod.Checked Then
                        yPos += lineHeight
                        .DrawString("Start Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(startDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                        .DrawString("End Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                        .DrawString(endDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
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

            For rowNo As Integer = 0 To Me.dgvCBFPExtraBillItems.RowCount - 1

                If CBool(Me.dgvCBFPExtraBillItems.Item(Me.colCBFPInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvCBFPExtraBillItems.Rows(rowNo).Cells

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

                End If
            Next

            If Not oVariousOptions.HideCreditBillFormPaymentReceiptDetails Then
                cBFPParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
            End If

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            Dim netBill As Decimal = DecimalMayBeEnteredIn(stbCBFPTotalBill)
            Dim withholdingTaxLine As New System.Text.StringBuilder(String.Empty)
            Dim grandDiscountLine As New System.Text.StringBuilder(String.Empty)
            Dim netBillLine As New System.Text.StringBuilder(String.Empty)
            Dim withholdingTax As Decimal = DecimalMayBeEnteredIn(nbxCBFPWithholdingTax)
            Dim grandDiscount As Decimal = DecimalMayBeEnteredIn(Me.nbxCBFPGrandDiscount)
            Dim totalBill = netBill + withholdingTax + grandDiscount
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
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbCBFPAmountWords)
            totalAmountWords.Append("(" + amountWords.Trim() + " ONLY)")
            totalAmountWords.Append(ControlChars.NewLine)
            cBFPParagraphs.Add(New PrintParagraps(footerFont, NumberToWords(netBill)))

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim amountTenderedData As New System.Text.StringBuilder(String.Empty)
            Dim foreignCurrencyData As New System.Text.StringBuilder(String.Empty)

            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxCBFPAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxCBFPExchangeRate, False)
            Dim change As Decimal = DecimalMayBeEnteredIn(Me.stbCBFPChange, True)
            Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboCBFPCurrenciesID, "Currency!")
            Dim currency As String = StringMayBeEnteredIn(Me.cboCBFPCurrenciesID)
            Dim amountTenderedLocalCurrency As Decimal = amountTendered * exchangeRate

            amountTenderedData.Append(ControlChars.NewLine)
            amountTenderedData.Append("Amount Tendered: ")
            amountTenderedData.Append(FormatNumber(amountTenderedLocalCurrency, AppData.DecimalPlaces).PadLeft(padAmountTendered))
            amountTenderedData.Append(ControlChars.NewLine)

            If Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                foreignCurrencyData.Append("(" + currency + ": " + FormatNumber(amountTendered, AppData.DecimalPlaces))
                foreignCurrencyData.Append(", Exchange Rate: " + FormatNumber(exchangeRate, AppData.DecimalPlaces) + ")")
                foreignCurrencyData.Append(ControlChars.NewLine)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkCBFPUseAccountBalance.Checked OrElse (Me.chkCBFPSendBalanceToAccount.Checked AndAlso Not change = 0) OrElse
                  Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                cBFPParagraphs.Add(New PrintParagraps(bodyBoldFont, amountTenderedData.ToString()))
            End If

            If Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                cBFPParagraphs.Add(New PrintParagraps(bodyNormalFont, foreignCurrencyData.ToString()))
            End If

            If Me.chkCBFPUseAccountBalance.Checked Then

                Dim accountData As New System.Text.StringBuilder(String.Empty)
                Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.stbCBFPAccountBalance, True)
                Dim balanceFromAccount As Decimal

                If accountBalance <= totalBill Then
                    balanceFromAccount = accountBalance
                Else : balanceFromAccount = totalBill
                End If

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.cBFPReceiptSaved Then
                Dim provisionalData As New System.Text.StringBuilder(String.Empty)
                provisionalData.Append(ControlChars.NewLine)
                provisionalData.Append("*** Remember to return this provisional receipt for a final one ***")
                provisionalData.Append(ControlChars.NewLine)
                cBFPParagraphs.Add(New PrintParagraps(bodyBoldFont, provisionalData.ToString()))

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim appreciationData As New System.Text.StringBuilder(String.Empty)
            appreciationData.Append(ControlChars.NewLine)
            appreciationData.Append("*** Thank you for choosing " + AppData.ProductOwner + " ***")
            appreciationData.Append(ControlChars.NewLine)
            cBFPParagraphs.Add(New PrintParagraps(bodyBoldFont, appreciationData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            cBFPParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Function GetPaymentCBFPItemsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim paymentbP As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvCBFPExtraBillItems.RowCount - 1

                If CBool(Me.dgvCBFPExtraBillItems.Item(Me.colCBFPInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvCBFPExtraBillItems.Rows(rowNo).Cells
                    Dim category As String = cells.Item(Me.colCBFPCategory.Name).Value.ToString()
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colCBFPAmount, False, "amount!")

                    paymentbP.Add(New Tuple(Of String, Decimal)(category, amount))

                End If
            Next

            Return paymentbP

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#Region "Credit Bills Payment THERMAL RECEIPT PRINT OUT"

    Private Sub PrintCBPThermalReceipt()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvCBFPExtraBillItems.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for Payments!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvCBFPExtraBillItems.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvCBFPExtraBillItems.Item(Me.colCBFPInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry for payments!")

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
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboCBFPBillModesID)
            Dim fromName As String = StringMayBeEnteredIn(Me.stbCBFPBillCustomerName)

            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbCBFPVisitNo))
            If String.IsNullOrEmpty(visitNo) Then
                fullName = String.Empty
            Else : fullName = GetPatientFullName(visitNo)
            End If

            Dim receiptNo As String = StringMayBeEnteredIn(Me.stbCBFPReceiptNo)
            Dim billAccountNo As String = StringMayBeEnteredIn(Me.cboCBFPBillAccountNo)
            Dim payDate As String = FormatDate(Today)
            Dim documentNo As String = StringMayBeEnteredIn(Me.stbCBFPDocumentNo)
            If String.IsNullOrEmpty(documentNo) Then
                payMode = StringMayBeEnteredIn(Me.cboCBFPPayModesID)
            Else : payMode = StringMayBeEnteredIn(Me.cboCBFPPayModesID) + " (No: " + documentNo + ")"
            End If
            Dim startDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpCBFPStartDate))
            Dim endDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpCBFPEndDate))

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

                    .DrawString("Visit No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(visitNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
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



                For rowNo As Integer = 0 To Me.dgvCBFPExtraBillItems.RowCount - 1

                    If CBool(Me.dgvCBFPExtraBillItems.Item(Me.colCBFPInclude.Name, rowNo).Value) = True Then

                        Dim cells As DataGridViewCellCollection = Me.dgvCBFPExtraBillItems.Rows(rowNo).Cells

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

                    End If
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

    Private Sub PrintAccounts(ByVal receiptSaved As Boolean)

        Dim dlgPrint As New PrintDialog()
        Dim oprinterPaperSize As New LookupDataID.PrinterPaperSize()
        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case cashierPrinterPaperSize

                Case GetLookupDataDes(oprinterPaperSize.A4)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.accountReceiptSaved = receiptSaved
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    dlgPrint.Document = docAccounts
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docAccounts.Print()
                Case String.Empty
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.accountReceiptSaved = receiptSaved
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    dlgPrint.Document = docAccounts
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docAccounts.Print()

                Case GetLookupDataDes(oprinterPaperSize.EightyMillimeters)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.accountReceiptSaved = receiptSaved
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
            Dim title As String

            If Me.accountReceiptSaved Then
                title = AppData.ProductOwner.ToUpper() + " Account Receipt".ToUpper()
            Else : title = AppData.ProductOwner.ToUpper() + " Account Receipt (Provisional)".ToUpper()
            End If

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
                Dim accountNo As String = StringMayBeEnteredIn(Me.cboAccountNo)
                Dim accountCategory As String = StringMayBeEnteredIn(Me.cboBillModesID)
                Dim transactionNo As String = StringMayBeEnteredIn(Me.stbAccountTranNo)
                Dim transactionDate As String = FormatDate(DateTimeMayBeEnteredIn(Me.dtpTransactionDate))
                Dim payMode As String = StringMayBeEnteredIn(Me.cboAccountPayModesID)
                Dim accountAction As String = StringMayBeEnteredIn(Me.cboAccountActionID)
                Dim documentNo As String = StringMayBeEnteredIn(Me.stbAccountDocumentNo)
                Dim balance As String = FormatNumber(DecimalMayBeEnteredIn(Me.nbxAccountBalance, True), AppData.DecimalPlaces)
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
                'If DecimalMayBeEnteredIn(Me.nbxAccountBalance, True) < 0 Then
                '    .DrawString("Account Balance (DR): ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                'Else : .DrawString("Account Balance (CR): ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                'End If
                '.DrawString(balance, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
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
                Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboAccountCurrenciesID, "Currency!")

                If Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then

                    Dim foreignCurrencyData As New System.Text.StringBuilder(String.Empty)

                    Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmountTendered, True)
                    Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountExchangeRate, False)
                    Dim amountTenderedLocalCurrency As String = FormatNumber(amountTendered * exchangeRate, AppData.DecimalPlaces)
                    Dim currency As String = StringMayBeEnteredIn(Me.cboAccountCurrenciesID)

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
                If Not Me.accountReceiptSaved Then
                    Dim provisionalFooter As String = "*** Remember to return this provisional receipt for a final one ***"
                    Dim provisionalData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedProvisionalData As List(Of String) = WrapText(provisionalFooter, textLEN)

                    If wrappedProvisionalData.Count > 1 Then
                        For pos As Integer = 0 To wrappedProvisionalData.Count - 1
                            provisionalData.Append(wrappedProvisionalData(pos).Trim())
                            provisionalData.Append(ControlChars.NewLine)
                        Next
                    Else : provisionalData.Append(provisionalFooter)
                    End If

                    .DrawString(provisionalData.ToString(), bodyBoldFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

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

            If Me.accountReceiptSaved Then
                title = " Account Receipt".ToUpper()
            Else : title = " Account Receipt (Provisional)".ToUpper()
            End If

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
                Dim accountNo As String = StringMayBeEnteredIn(Me.cboAccountNo)
                Dim accountCategory As String = StringMayBeEnteredIn(Me.cboBillModesID)
                Dim transactionNo As String = StringMayBeEnteredIn(Me.stbAccountTranNo)
                Dim transactionDate As String = FormatDate(DateTimeMayBeEnteredIn(Me.dtpTransactionDate))
                Dim payMode As String = StringMayBeEnteredIn(Me.cboAccountPayModesID)
                Dim accountAction As String = StringMayBeEnteredIn(Me.cboAccountActionID)
                Dim documentNo As String = StringMayBeEnteredIn(Me.stbAccountDocumentNo)
                Dim balance As String = FormatNumber(DecimalMayBeEnteredIn(Me.nbxAccountBalance, True), AppData.DecimalPlaces)
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

                If String.IsNullOrEmpty(accountAction) Then
                    .DrawString("Amount: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                ElseIf accountAction.ToUpper().Equals(GetLookupDataDes(oAccountActionID.Debit).ToUpper()) Then
                    .DrawString("Amount Debited: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                ElseIf accountAction.ToUpper().Equals(GetLookupDataDes(oAccountActionID.Credit).ToUpper()) Then
                    .DrawString("Amount Credited: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                Else : .DrawString("Amount: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                End If
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

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim oCurrenciesID As New LookupDataID.CurrenciesID()
                Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboAccountCurrenciesID, "Currency!")

                If Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then

                    Dim foreignCurrencyData As New System.Text.StringBuilder(String.Empty)

                    Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmountTendered, True)
                    Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountExchangeRate, False)
                    Dim amountTenderedLocalCurrency As String = FormatNumber(amountTendered * exchangeRate, AppData.DecimalPlaces)
                    Dim currency As String = StringMayBeEnteredIn(Me.cboAccountCurrenciesID)

                    .DrawString("Amount Tendered: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(amountTenderedLocalCurrency, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    foreignCurrencyData.Append("(" + currency + ": " + FormatNumber(amountTendered, AppData.DecimalPlaces))
                    foreignCurrencyData.Append(", Exchange Rate: " + FormatNumber(exchangeRate, AppData.DecimalPlaces) + ")")
                    foreignCurrencyData.Append(ControlChars.NewLine)
                    .DrawString(foreignCurrencyData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    yPos += lineHeight

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

                Else : yPos += lineHeight

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not Me.accountReceiptSaved Then
                    Dim provisionalFooter As String = "*** Remember to return this provisional receipt for a final one ***"
                    Dim provisionalData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedProvisionalData As List(Of String) = WrapText(provisionalFooter, textLEN)

                    If wrappedProvisionalData.Count > 1 Then
                        For pos As Integer = 0 To wrappedProvisionalData.Count - 1
                            provisionalData.Append(wrappedProvisionalData(pos).Trim())
                            provisionalData.Append(ControlChars.NewLine)
                        Next
                    Else : provisionalData.Append(provisionalFooter)
                    End If

                    .DrawString(provisionalData.ToString(), bodyBoldFont, Brushes.Black, xPos, yPos)
                    yPos += lineHeight

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If accountAction.ToUpper().Equals(GetLookupDataDes(oAccountActionID.Debit).ToUpper()) Then

                    Dim patientSignData As New System.Text.StringBuilder(String.Empty)

                    patientSignData.Append("Patient's Sign: " + GetCharacters("."c, 15))
                    patientSignData.Append(ControlChars.NewLine)
                    yPos += lineHeight
                    patientSignData.Append("Date: " + GetCharacters("."c, 15))
                    .DrawString(patientSignData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)

                    yPos += lineHeight
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim checkedSignData As New System.Text.StringBuilder(String.Empty)

                    checkedSignData.Append("Checked By: " + GetCharacters("."c, 15))
                    checkedSignData.Append(ControlChars.NewLine)
                    yPos += lineHeight
                    checkedSignData.Append("Date: " + GetCharacters("."c, 15))
                    .DrawString(checkedSignData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)

                    yPos += lineHeight
                End If

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

    Private Sub PrintOtherIncome(ByVal receiptSaved As Boolean)

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.otherIncomeReceiptSaved = receiptSaved
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
            Dim title As String

            If Me.otherIncomeReceiptSaved Then
                title = AppData.ProductOwner.ToUpper() + " Other Income Receipt".ToUpper()
            Else : title = AppData.ProductOwner.ToUpper() + " Other Income Receipt (Provisional)".ToUpper()
            End If

            With e.Graphics

                Dim lineWidth As Single = .MeasureString("W", titleFont).Width * 12

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not oVariousOptions.HideCashReceiptHeader Then yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                yPos += 3 * lineHeight

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim incomeNo As String = StringMayBeEnteredIn(Me.stbIncomeNo)
                Dim incomeDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpIncomeDate))
                Dim incomeSource As String = StringMayBeEnteredIn(Me.cboIncomeSourcesID)
                Dim payMode As String = StringMayBeEnteredIn(Me.cboOIPayModesID)
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
                Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboOICurrenciesID, "Currency!")

                If Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then

                    Dim foreignCurrencyData As New System.Text.StringBuilder(String.Empty)

                    Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxOIAmountTendered, True)
                    Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxOIExchangeRate, False)
                    Dim amountTenderedLocalCurrency As String = FormatNumber(amountTendered * exchangeRate, AppData.DecimalPlaces)
                    Dim currency As String = StringMayBeEnteredIn(Me.cboOICurrenciesID)

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

                If Not Me.otherIncomeReceiptSaved Then
                    Dim provisionalFooter As String = "*** Remember to return this provisional receipt for a final one ***"
                    Dim provisionalData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedProvisionalData As List(Of String) = WrapText(provisionalFooter, textLEN)

                    If wrappedProvisionalData.Count > 1 Then
                        For pos As Integer = 0 To wrappedProvisionalData.Count - 1
                            provisionalData.Append(wrappedProvisionalData(pos).Trim())
                            provisionalData.Append(ControlChars.NewLine)
                        Next
                    Else : provisionalData.Append(provisionalFooter)
                    End If

                    .DrawString(provisionalData.ToString(), bodyBoldFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " Refunds Printing "

    Private Sub PrintRefunds(ByVal receiptSaved As Boolean)

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.refundsReceiptSaved = receiptSaved
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
            Dim title As String

            If Me.refundsReceiptSaved Then
                title = AppData.ProductOwner.ToUpper() + " Refunds Receipt".ToUpper()
            Else : title = AppData.ProductOwner.ToUpper() + " Refunds Receipt (Provisional)".ToUpper()
            End If

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
                Dim refundDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpRefundDate))
                Dim refundAmount As String = FormatNumber(DecimalMayBeEnteredIn(Me.nbxToRefundAmount, True), AppData.DecimalPlaces)
                Dim refundAmountWords As String = NumberToWords(DecimalMayBeEnteredIn(Me.nbxToRefundAmount, True))
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
                If Not Me.refundsReceiptSaved Then
                    Dim provisionalFooter As String = "*** Remember to return this provisional receipt for a final one ***"
                    Dim provisionalData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedProvisionalData As List(Of String) = WrapText(provisionalFooter, textLEN)

                    If wrappedProvisionalData.Count > 1 Then
                        For pos As Integer = 0 To wrappedProvisionalData.Count - 1
                            provisionalData.Append(wrappedProvisionalData(pos).Trim())
                            provisionalData.Append(ControlChars.NewLine)
                        Next
                    Else : provisionalData.Append(provisionalFooter)
                    End If

                    .DrawString(provisionalData.ToString(), bodyBoldFont, Brushes.Black, xPos, yPos)
                    wordLines = provisionalData.ToString().Split(CChar(ControlChars.NewLine)).Length
                    If wordLines < 2 Then wordLines = 2
                    yPos += wordLines * lineHeight

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

    Private Sub PrintExpenditure(ByVal receiptSaved As Boolean)

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.expenditureReceiptSaved = receiptSaved
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
            Dim title As String

            If Me.expenditureReceiptSaved Then
                title = AppData.ProductOwner.ToUpper() + " Expenditure Receipt".ToUpper()
            Else : title = AppData.ProductOwner.ToUpper() + " Expenditure Receipt (Provisional)".ToUpper()
            End If

            With e.Graphics

                Dim lineWidth As Single = .MeasureString("W", titleFont).Width * 12

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not oVariousOptions.HideCashReceiptHeader Then yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                yPos += 3 * lineHeight

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim expenditureNo As String = StringMayBeEnteredIn(Me.stbExpenditureNo)
                Dim spentDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpSpentDate))
                Dim givenTo As String = StringMayBeEnteredIn(Me.stbGivenTo)
                Dim documentNo As String = StringMayBeEnteredIn(Me.stbEXDocumentNo)
                Dim amount As String = FormatNumber(DecimalMayBeEnteredIn(Me.nbxEXAmount, True), AppData.DecimalPlaces)
                Dim amountWords As String = NumberToWords(DecimalMayBeEnteredIn(Me.nbxEXAmount, True))
                Dim details As String = StringMayBeEnteredIn(Me.stbEXDetails)
                Dim expenditureSource As String = StringEnteredIn(Me.cboExpenditureSourceType)
                Dim expenditureCategory As String = StringEnteredIn(Me.cboExpenditureCategoryID)
                Dim accountNo As String = StringMayBeEnteredIn(Me.cboAccountNames)
                Dim textLEN As Integer = 75

                .DrawString("Expenditure No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(expenditureNo, bodyBoldFont, Brushes.Black, xPos + lineWidth, yPos)
                yPos += lineHeight

                .DrawString("Spent Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(spentDate, bodyBoldFont, Brushes.Black, xPos + lineWidth, yPos)
                yPos += lineHeight

                .DrawString("Expenditure Category: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(expenditureCategory, bodyBoldFont, Brushes.Black, xPos + lineWidth, yPos)
                yPos += lineHeight

                .DrawString("Source Type: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(expenditureSource, bodyBoldFont, Brushes.Black, xPos + lineWidth, yPos)
                yPos += lineHeight

                If Not String.IsNullOrEmpty(accountNo) Then
                    .DrawString("Account No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(accountNo, bodyBoldFont, Brushes.Black, xPos + lineWidth, yPos)
                    yPos += lineHeight
                End If
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

                If Not Me.expenditureReceiptSaved Then
                    Dim provisionalFooter As String = "*** Remember to return this provisional receipt for a final one ***"
                    Dim provisionalData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedProvisionalData As List(Of String) = WrapText(provisionalFooter, textLEN)

                    If wrappedProvisionalData.Count > 1 Then
                        For pos As Integer = 0 To wrappedProvisionalData.Count - 1
                            provisionalData.Append(wrappedProvisionalData(pos).Trim())
                            provisionalData.Append(ControlChars.NewLine)
                        Next
                    Else : provisionalData.Append(provisionalFooter)
                    End If

                    .DrawString(provisionalData.ToString(), bodyBoldFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

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

                Dim printedBy As String = "Printed by " + CurrentUser.FullName + " on " +
                    FormatDate(Now) + " at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle

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

#Region " Payments Extras "

    Private Sub dgvPaymentDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPaymentDetails.CellDoubleClick

        Try
            '
            If Not Me.btnAddExtraBill.Enabled OrElse
                e.ColumnIndex.Equals(Me.colInclude.Index) OrElse
                e.ColumnIndex.Equals(Me.colQuantity.Index) OrElse
                e.ColumnIndex.Equals(Me.colUnitPrice.Index) OrElse
                e.ColumnIndex.Equals(Me.colDiscount.Index) Then Return

            Me.btnAddExtraBill_Click(Me, EventArgs.Empty)

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub dgvBillsPayment_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillsPayment.CellDoubleClick

        Try
            If Not Me.btnAddExtraBill.Enabled OrElse
                e.ColumnIndex.Equals(Me.colBPInclude.Index) OrElse
                e.ColumnIndex.Equals(Me.colBPDiscount.Index) Then Return

            Me.btnAddExtraBill_Click(Me, EventArgs.Empty)

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cmsPayments_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsPayments.Opening

        Select Case Me.tbcCashier.SelectedTab.Name

            Case Me.tpgCashPayment.Name

                Me.cmsPaymentsAddExtraCharge.Visible = True
             
                If Me.dgvPaymentDetails.ColumnCount < 1 OrElse Me.dgvPaymentDetails.RowCount < 1 Then
                    Me.cmsPaymentsCopy.Enabled = False
                    Me.cmsPaymentsSelectAll.Enabled = False
                    Me.cmsPaymentsAddExtraCharge.Enabled = False
                    Me.cmsPaymentsIncludeAll.Enabled = False
                    Me.cmsPaymentsIncludeNone.Enabled = False
                Else
                    Me.cmsPaymentsCopy.Enabled = True
                    Me.cmsPaymentsSelectAll.Enabled = True
                    Me.cmsPaymentsAddExtraCharge.Enabled = Me.btnAddExtraBill.Enabled
                    Me.cmsPaymentsIncludeAll.Enabled = Me.GetIncludeAllState(Me.dgvPaymentDetails)
                    Me.cmsPaymentsIncludeNone.Enabled = Me.GetIncludeNoneState(Me.dgvPaymentDetails)
                End If

            Case Me.tpgBillFormPayment.Name

                Me.cmsPaymentsAddExtraCharge.Visible = False
               
                If Me.dgvPaymentExtraBillItems.ColumnCount < 1 OrElse Me.dgvPaymentExtraBillItems.RowCount < 1 Then
                    Me.cmsPaymentsCopy.Enabled = False
                    Me.cmsPaymentsSelectAll.Enabled = False
                    Me.cmsPaymentsAddExtraCharge.Enabled = False
                    Me.cmsPaymentsIncludeAll.Enabled = False
                    Me.cmsPaymentsIncludeNone.Enabled = False
                Else
                    Me.cmsPaymentsCopy.Enabled = True
                    Me.cmsPaymentsSelectAll.Enabled = True
                    Me.cmsPaymentsAddExtraCharge.Enabled = Me.btnAddExtraBill.Enabled
                    Me.cmsPaymentsIncludeAll.Enabled = Me.GetIncludeAllState(Me.dgvPaymentExtraBillItems)
                    Me.cmsPaymentsIncludeNone.Enabled = Me.GetIncludeNoneState(Me.dgvPaymentExtraBillItems)
                End If

            Case Me.tpgBillsPayment.Name

                Me.cmsPaymentsAddExtraCharge.Visible = True


                If Me.dgvBillsPayment.ColumnCount < 1 OrElse Me.dgvBillsPayment.RowCount < 1 Then
                    Me.cmsPaymentsCopy.Enabled = False
                    Me.cmsPaymentsSelectAll.Enabled = False
                    Me.cmsPaymentsAddExtraCharge.Enabled = False

                    Me.cmsPaymentsIncludeAll.Enabled = False
                    Me.cmsPaymentsIncludeNone.Enabled = False
                Else
                    Me.cmsPaymentsCopy.Enabled = True
                    Me.cmsPaymentsSelectAll.Enabled = True
                    Me.cmsPaymentsAddExtraCharge.Enabled = Me.btnAddExtraBill.Enabled
                    Me.cmsPaymentsIncludeAll.Enabled = Me.GetIncludeAllState(Me.dgvBillsPayment)
                    Me.cmsPaymentsIncludeNone.Enabled = Me.GetIncludeNoneState(Me.dgvBillsPayment)
                End If

            Case Me.tpgCreditBillFormPayment.Name

                Me.cmsPaymentsAddExtraCharge.Visible = False


                If Me.dgvCBFPExtraBillItems.ColumnCount < 1 OrElse Me.dgvCBFPExtraBillItems.RowCount < 1 Then
                    Me.cmsPaymentsCopy.Enabled = False
                    Me.cmsPaymentsSelectAll.Enabled = False
                    Me.cmsPaymentsAddExtraCharge.Enabled = False
                    Me.cmsPaymentsIncludeAll.Enabled = False
                    Me.cmsPaymentsIncludeNone.Enabled = False
                Else
                    Me.cmsPaymentsCopy.Enabled = True
                    Me.cmsPaymentsSelectAll.Enabled = True
                    Me.cmsPaymentsAddExtraCharge.Enabled = Me.btnAddExtraBill.Enabled
                    Me.cmsPaymentsIncludeAll.Enabled = Me.GetIncludeAllState(Me.dgvCBFPExtraBillItems)
                    Me.cmsPaymentsIncludeNone.Enabled = Me.GetIncludeNoneState(Me.dgvCBFPExtraBillItems)
                End If

        End Select

    End Sub

    Private Sub cmsPaymentsCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsPaymentsCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcCashier.SelectedTab.Name

                Case Me.tpgCashPayment.Name

                    If Me.dgvPaymentDetails.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvPaymentDetails))

                Case Me.tpgBillFormPayment.Name

                    If Me.dgvPaymentExtraBillItems.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvPaymentExtraBillItems))

                Case Me.tpgBillsPayment.Name

                    If Me.dgvBillsPayment.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvBillsPayment))

                Case Me.tpgCreditBillFormPayment.Name

                    If Me.dgvCBFPExtraBillItems.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvCBFPExtraBillItems))

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsPaymentsSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsPaymentsSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcCashier.SelectedTab.Name

                Case Me.tpgCashPayment.Name
                    Me.dgvPaymentDetails.SelectAll()

                Case Me.tpgBillFormPayment.Name
                    Me.dgvPaymentExtraBillItems.SelectAll()

                Case Me.tpgBillsPayment.Name
                    Me.dgvBillsPayment.SelectAll()

                Case Me.tpgCreditBillFormPayment.Name
                    Me.dgvCBFPExtraBillItems.SelectAll()

            End Select

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsPaymentsAddExtraCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsPaymentsAddExtraCharge.Click

        Try

            If Me.btnAddExtraBill.Enabled = False Then Return
            Me.btnAddExtraBill_Click(Me, EventArgs.Empty)

        Catch ex As Exception
            Return
        End Try

    End Sub


    Private Sub cmsPaymentsIncludeAll_Click(sender As System.Object, e As System.EventArgs) Handles cmsPaymentsIncludeAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oServiceCodes As New LookupDataID.ServiceCodes()
            Select Case Me.tbcCashier.SelectedTab.Name

                Case Me.tpgCashPayment.Name

                    For Each row As DataGridViewRow In Me.dgvPaymentDetails.Rows
                        If row.IsNewRow Then Exit For

                        Me.dgvPaymentDetails.Item(Me.colInclude.Name, row.Index).Value = True

                    Next

                    Me.CalculateCashTotalBill()

                Case Me.tpgBillFormPayment.Name

                    For Each row As DataGridViewRow In Me.dgvPaymentExtraBillItems.Rows
                        If row.IsNewRow Then Exit For
                        Me.dgvPaymentExtraBillItems.Item(Me.colBFPInclude.Name, row.Index).Value = True
                    Next

                    Me.CalculateBillFormTotalBill()

                Case Me.tpgBillsPayment.Name

                    For Each row As DataGridViewRow In Me.dgvBillsPayment.Rows
                        If row.IsNewRow Then Exit For
                        Me.dgvBillsPayment.Item(Me.colBPInclude.Name, row.Index).Value = True
                    Next

                    Me.CalculateAccountTotalBill()

                Case Me.tpgCreditBillFormPayment.Name

                    For Each row As DataGridViewRow In Me.dgvCBFPExtraBillItems.Rows
                        If row.IsNewRow Then Exit For
                        Me.dgvCBFPExtraBillItems.Item(Me.colCBFPInclude.Name, row.Index).Value = True
                    Next

                    Me.CalculateCBFPAccountTotalBill()

            End Select

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsPaymentsIncludeNone_Click(sender As System.Object, e As System.EventArgs) Handles cmsPaymentsIncludeNone.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oServiceCodes As New LookupDataID.ServiceCodes()
            Select Case Me.tbcCashier.SelectedTab.Name

                Case Me.tpgCashPayment.Name

                    For Each row As DataGridViewRow In Me.dgvPaymentDetails.Rows

                        If Me.dgvPaymentDetails.Item(Me.colItemCode.Name, row.Index).Value.Equals(oServiceCodes.ServiceFee) Then
                            row.Cells(colInclude.Index).ReadOnly = True
                            row.Cells(colInclude.Index).Value = True
                            row.Cells(colInclude.Index).Style.BackColor = Color.FromKnownColor(KnownColor.MistyRose)
                        Else
                            Me.dgvPaymentDetails.Item(Me.colInclude.Name, row.Index).Value = False
                        End If
                    Next
                    Me.CalculateCashTotalBill()

                Case Me.tpgBillFormPayment.Name

                    For Each row As DataGridViewRow In Me.dgvPaymentExtraBillItems.Rows
                        If row.IsNewRow Then Exit For
                        Me.dgvPaymentExtraBillItems.Item(Me.colBFPInclude.Name, row.Index).Value = False
                    Next

                    Me.CalculateBillFormTotalBill()

                Case Me.tpgBillsPayment.Name

                    For Each row As DataGridViewRow In Me.dgvBillsPayment.Rows
                        If row.IsNewRow Then Exit For
                        Me.dgvBillsPayment.Item(Me.colBPInclude.Name, row.Index).Value = False
                    Next

                    Me.CalculateAccountTotalBill()

                Case Me.tpgCreditBillFormPayment.Name

                    For Each row As DataGridViewRow In Me.dgvCBFPExtraBillItems.Rows
                        If row.IsNewRow Then Exit For
                        Me.dgvCBFPExtraBillItems.Item(Me.colCBFPInclude.Name, row.Index).Value = False
                    Next

                    Me.CalculateCBFPAccountTotalBill()

            End Select

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function GetIncludeAllState(grid As DataGridView) As Boolean

        Dim includeAll As Boolean = False

        If grid.Name.ToUpper().Equals(Me.dgvPaymentDetails.Name.ToUpper()) Then

            For Each row As DataGridViewRow In Me.dgvPaymentDetails.Rows
                If row.IsNewRow Then Exit For
                If Not CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, row.Index).Value) Then
                    includeAll = True
                    Exit For
                End If
                includeAll = False
            Next

        ElseIf grid.Name.ToUpper().Equals(Me.dgvPaymentExtraBillItems.Name.ToUpper()) Then

            For Each row As DataGridViewRow In Me.dgvPaymentExtraBillItems.Rows
                If row.IsNewRow Then Exit For
                If Not CBool(Me.dgvPaymentExtraBillItems.Item(Me.colBFPInclude.Name, row.Index).Value) Then
                    includeAll = True
                    Exit For
                End If
                includeAll = False
            Next

        ElseIf grid.Name.ToUpper().Equals(Me.dgvBillsPayment.Name.ToUpper()) Then

            For Each row As DataGridViewRow In Me.dgvBillsPayment.Rows
                If row.IsNewRow Then Exit For
                If Not CBool(Me.dgvBillsPayment.Item(Me.colBPInclude.Name, row.Index).Value) Then
                    includeAll = True
                    Exit For
                End If
                includeAll = False
            Next

        ElseIf grid.Name.ToUpper().Equals(Me.dgvCBFPExtraBillItems.Name.ToUpper()) Then

            For Each row As DataGridViewRow In Me.dgvCBFPExtraBillItems.Rows
                If row.IsNewRow Then Exit For
                If Not CBool(Me.dgvCBFPExtraBillItems.Item(Me.colCBFPInclude.Name, row.Index).Value) Then
                    includeAll = True
                    Exit For
                End If
                includeAll = False
            Next

        Else : includeAll = False
        End If

        Return includeAll

    End Function

    Private Function GetIncludeNoneState(grid As DataGridView) As Boolean

        Dim includeNone As Boolean = False

        If grid.Name.ToUpper().Equals(Me.dgvPaymentDetails.Name.ToUpper()) Then

            For Each row As DataGridViewRow In Me.dgvPaymentDetails.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, row.Index).Value) Then
                    includeNone = True
                    Exit For
                End If
                includeNone = False
            Next

        ElseIf grid.Name.ToUpper().Equals(Me.dgvPaymentExtraBillItems.Name.ToUpper()) Then

            For Each row As DataGridViewRow In Me.dgvPaymentExtraBillItems.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPaymentExtraBillItems.Item(Me.colBFPInclude.Name, row.Index).Value) Then
                    includeNone = True
                    Exit For
                End If
                includeNone = False
            Next

        ElseIf grid.Name.ToUpper().Equals(Me.dgvBillsPayment.Name.ToUpper()) Then

            For Each row As DataGridViewRow In Me.dgvBillsPayment.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvBillsPayment.Item(Me.colBPInclude.Name, row.Index).Value) Then
                    includeNone = True
                    Exit For
                End If
                includeNone = False
            Next

        ElseIf grid.Name.ToUpper().Equals(Me.dgvCBFPExtraBillItems.Name.ToUpper()) Then

            For Each row As DataGridViewRow In Me.dgvCBFPExtraBillItems.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvCBFPExtraBillItems.Item(Me.colCBFPInclude.Name, row.Index).Value) Then
                    includeNone = True
                    Exit For
                End If
                includeNone = False
            Next

        Else : includeNone = False
        End If

        Return includeNone

    End Function

#End Region

#Region " Security Method "

    Private Sub ApplySecurity()

        Try

            Me.btnSave.Tag = Me.tbcCashier.SelectedTab.Tag.ToString()
            If Me.btnAddExtraBill.Enabled Then Security.Apply(Me.btnAddExtraBill, AccessRights.Write)
            If Me.btnSelfRequests.Enabled Then Security.Apply(Me.btnSelfRequests, AccessRights.Write)
            If Me.btnEdit.Enabled Then Security.Apply(Me.btnEdit, AccessRights.Update)
            If Me.btnManageAccounts.Enabled Then Security.Apply(Me.btnManageAccounts, AccessRights.Write)
            If Me.btnSave.Enabled Then Security.Apply(Me.btnSave, AccessRights.Write)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

    Private Sub dgvPendingBillItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPendingBillItems.CellEndEdit
        If e.ColumnIndex.Equals(Me.colPendingBillItemsQuantity.Index) OrElse
            e.ColumnIndex.Equals(Me.colPendingBillItemsUnitPrice.Index) OrElse
            e.ColumnIndex.Equals(Me.colPendingBillItemsDiscount.Index) Then
            Me.CalculatePendingBillAmount(e.RowIndex)
            Me.CalculateBillFormTotalBill()

        ElseIf e.ColumnIndex.Equals(Me.colPendingBillItemsInclude.Index) Then
            Me.CalculateBillFormTotalBill()

        End If
    End Sub

    Private Sub tbcBillFormPayment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcBillFormPayment.SelectedIndexChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            'Select Case Me.tbcBillFormPayment.SelectedTab.Name
            '    Case tpgBillingForm.Name
            '        Me.btnSave.Enabled = True
            '    Case tpgPendingBill.Name
            '        Me.btnSave.Enabled = False
            '    Case Else
            '        Me.btnSave.Enabled = True
            'End Select
            Me.btnSave.Enabled = True
            Me.CalculateBillFormTotalBill()

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

#Region "Expenditure"
    Private Sub LoadAccountNames(ByVal bankID As String)

        Dim oBankAccount As New SyncSoft.SQLDb.BankAccounts()

        cboAccountNames.DataSource = Nothing
        Try
            Me.Cursor = Cursors.WaitCursor
            cboAccountNames.DisplayMember = "AccountName"
            cboAccountNames.ValueMember = "AccountNo"

            If String.IsNullOrEmpty(bankID) Then Return
            Dim bankAccount As DataTable = oBankAccount.GetBankAccountsByBankID(bankID).Tables("BankAccounts")

            cboAccountNames.DataSource = bankAccount

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub LoadAccountNo(ByVal bankID As String, ByVal accountName As String)

        Dim oBankAccount As New SyncSoft.SQLDb.BankAccounts()
        nbxAccountAmount.Clear()
        Try
            Me.Cursor = Cursors.WaitCursor

            If String.IsNullOrEmpty(bankID) OrElse String.IsNullOrEmpty(accountName) Then Return
            Dim bankAccount As DataTable = oBankAccount.GetBankAccounts(String.Empty, bankID, accountName).Tables("BankAccounts")

            Dim row As DataRow = bankAccount.Rows(0)
            If bankAccount.Rows.Count <= 0 Then Return
            nbxMaxAmount.Text = FormatNumber(CDec(row.Item("Balance")))
            cboCurrency.SelectedValue = StringEnteredIn(row, "CurrencyID")
            'stbCurrency.Text = currency

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub cboBankID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBankID.SelectedIndexChanged
        LoadAccountNames(StringValueMayBeEnteredIn(cboBankID))

    End Sub

    Private Sub cboAccountNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAccountNames.SelectedIndexChanged
        LoadAccountNo(StringValueMayBeEnteredIn(cboBankID), StringMayBeEnteredIn(cboAccountNames))
    End Sub

    Private Sub cboExpenditureSourceType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboExpenditureSourceType.SelectedIndexChanged
        Dim expenditureSource As String = StringValueMayBeEnteredIn(cboExpenditureSourceType)

        cboBankID.Enabled = expenditureSource.Equals(oExpenditureSourceType.Bank())
        cboAccountNames.Enabled = expenditureSource.Equals(oExpenditureSourceType.Bank())
        cboCurrency.Enabled = expenditureSource.Equals(oExpenditureSourceType.Cash())

        If expenditureSource.Equals(oExpenditureSourceType.Cash) Then
            cboAccountNames.SelectedIndex = -1
            cboBankID.SelectedIndex = -1
            nbxAccountAmount.Clear()
        End If

    End Sub


    Private Sub btnExRate_Click(sender As Object, e As EventArgs) Handles btnExRate.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim fExchangeRates As New frmExchangeRates()
            fExchangeRates.ShowDialog()

            Me.cboCurrency_SelectedIndexChanged(sender, EventArgs.Empty)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub nbxAmountWithdrawn_TextChanged(sender As Object, e As EventArgs) Handles nbxAmountWithdrawn.TextChanged
        CalculateEXAmount()
    End Sub

    Private Sub cboCurrency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCurrency.SelectedIndexChanged
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim currenciesID As String = StringValueMayBeEnteredIn(cboCurrency)

            If String.IsNullOrEmpty(currenciesID) Then Return

            Me.SetExCurrencyControls(currenciesID)
            CalculateEXAmount()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub CalculateEXAmount()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxEXAmount.Clear()


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim amountSpent As Decimal = DecimalMayBeEnteredIn(Me.nbxAmountWithdrawn, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxExchange, False)

            Dim amount As Decimal = amountSpent * exchangeRate
            Me.nbxEXAmount.Text = FormatNumber(amount, AppData.DecimalPlaces)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub



    Private Sub CalculateTotalRefundAmount()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim refundAmount As Decimal = CalculateGridAmount(dgvPaymentRefunds, Me.colRefAmount)
        nbxToRefundAmount.Text = FormatNumber(refundAmount, AppData.DecimalPlaces)
        Me.nbxTotalRefundAmount.Text = FormatNumber(refundAmount, AppData.DecimalPlaces)
        Me.stbRefundAmountWords.Text = NumberToWords(refundAmount)

        Dim previousRefunded As Decimal = DecimalMayBeEnteredIn(stbAmountRefunded, False)
        nbxTotalRefundAmount.Text = FormatNumber((refundAmount + previousRefunded), AppData.DecimalPlaces)

    End Sub


    Private Function GetBankingRegisterList(registerNo As String, collectionSourceType As String, amountCollected As Decimal,
                                            payCurrency As String, exchangeRate As Decimal, bankDate As Date) As List(Of DBConnect)
        Dim oBankingRegister As New SyncSoft.SQLDb.BankingRegister()
        Dim oCurrenciesID As New LookupDataID.CurrenciesID

        Dim lBankingRegister As New List(Of DBConnect)
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim oBankAccount As New BankAccounts()

            Dim bankAccount As DataTable = oBankAccount.GetBankAccounts(Me.bankAccountNo).Tables("BankAccounts")
            Dim row As DataRow = bankAccount.Rows(0)

            Dim currencyID As String = StringEnteredIn(row, "CurrencyID")
            Dim accountName As String = StringEnteredIn(row, "AccountName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            If currencyID.ToUpper.Equals(oCurrenciesID.UgandaShillings) Then
                exchangeRate = 1
            Else
                exchangeRate = GetExchangeRateBuying(currencyID)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



            With oBankingRegister

                .RegisterNo = registerNo
                .CollectionStartDate = Today
                .CollectionEndDate = Now
                .BankingDate = bankDate
                .CollectionSourCeTypeID = collectionSourceType
                .BankNameID = bankNameID
                .AccountName = accountName
                .AccountNo = Me.bankAccountNo
                .AmountCollected = amountCollected
                .AmountBanked = Me.CalculateAccountAmount(payCurrency, amountCollected, currencyID)
                .AmountInWords = NumberToWords(amountCollected)
                .CurrencyID = currencyID

                .ExchangeRate = exchangeRate
                If (.AmountCollected < .AmountBanked * exchangeRate) Then
                    DisplayMessage("Amount banked cannot be greater than amount collected")

                End If
                .BankedBy = CurrentUser.LoginID
                .LoginID = CurrentUser.LoginID

                .RecordDateTime = Now()

            End With

            lBankingRegister.Add(oBankingRegister)

        Catch ex As Exception
            ErrorMessage(ex)
        Finally

        End Try
        Return lBankingRegister
    End Function


    Private Function GetBankingDetailList(registerNo As String, amountBanked As Decimal, payModesID As String, documentNo As String) As List(Of DBConnect)

        Dim lBankingRegisterDetails As New List(Of DBConnect)

        Using oBankingRegisterDetails As New SyncSoft.SQLDb.BankingRegisterDetails()

            With oBankingRegisterDetails

                .RegisterNo = registerNo
                .Amount = amountBanked
                .CollectionModesID = payModesID
                .BankModesID = payModesID
                .DocumentNo = documentNo
                .LoginID = CurrentUser.LoginID
                .RecordDateTime = Now()


            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lBankingRegisterDetails.Add(oBankingRegisterDetails)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        End Using

        Return lBankingRegisterDetails

    End Function


    Private Function CalculateAccountAmount(paymentCurrencyID As String, amountBanked As Decimal, accountCurrencyID As String) As Decimal

        Dim bankedinAccountCurrency As Decimal
        Try
            Me.Cursor = Cursors.WaitCursor
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If accountCurrencyID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                bankedinAccountCurrency = amountBanked
            Else
                Dim exchangeRate As Decimal = GetExchangeRateBuying(accountCurrencyID)
                bankedinAccountCurrency = amountBanked / exchangeRate
            End If

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
        Return bankedinAccountCurrency

    End Function

    Private Function GetNextRegisterNo() As String
        Dim yearL2 As String = Today.Year.ToString().Substring(2)
        Dim registerNo As String = String.Empty
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oBankingRegister As New BankingRegister()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("BankingRegister", "RegisterNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim nextRegisterID As String = oBankingRegister.GetNextRegisterID().ToString().PadLeft(paddingLEN, paddingCHAR)

            registerNo = FormatText(yearL2 + nextRegisterID.Trim(), "BankingRegister", "RegisterNo")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
        Return registerNo
    End Function

    Private Function GetBankingDetails(receiptNo As String, documentNo As String, payModeID As String) As List(Of DBConnect)
        Dim lBankPaymentDetails As New List(Of DBConnect)
        Dim oBankPaymentDetails As New BankPaymentDetails()
        With oBankPaymentDetails

            .ReceiptNo = receiptNo
            .BankNamesID = Me.bankNameID
            .AccountNo = Me.bankAccountNo
            .DocumentNo = documentNo
            .PayModesID = payModeID

            .RecordDateTime = Now()
            .LoginID = CurrentUser.LoginID

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End With
        lBankPaymentDetails.Add(oBankPaymentDetails)
        Return lBankPaymentDetails
    End Function





#End Region



    Private Sub btnReject_Click(sender As System.Object, e As System.EventArgs) Handles btnReject.Click
        Dim refundRequestNo As String = StringEnteredIn(stbRefundRequestNo, "Refund Refund No")
        Dim receiptNo As String = StringEnteredIn(stbRefundReceiptNo, "Refund ReceiptNo")
        Dim rejectedAt As String = oServicepointID.Cashier()

        Dim fRejectedRequests As New frmRefundRejects(refundRequestNo, receiptNo, rejectedAt)
        fRejectedRequests.ShowDialog()
        Me.ClearRefundsControls()
        Me.stbRefundReceiptNo.Clear()
        Me.ShowPendingRefundRequest()
        Me.stbRefundRequestNo.Clear()

    End Sub

    Private Sub btnLoadRefundRequests_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadRefundRequests.Click
        Dim fPendingRefundRequests As New frmPendingRefundRequests(Me.stbRefundRequestNo, False)
        fPendingRefundRequests.ShowDialog(Me)
        Dim refundRequestNo As String = RevertText(StringMayBeEnteredIn(Me.stbRefundRequestNo))
        If String.IsNullOrEmpty(refundRequestNo) Then Return
        Me.LoadRefundRequests(refundRequestNo)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub


    Private Sub LoadRefundRequests(refundRequestNo As String)


        Dim oRefundRequests As New SyncSoft.SQLDb.RefundRequests()

        Try
            Me.ClearRefundsControls()
            If String.IsNullOrEmpty(refundRequestNo) Then Return

            Me.Cursor = Cursors.WaitCursor()

            Dim dataSource As DataTable = oRefundRequests.GetToRefundRequests(refundRequestNo).Tables("RefundRequests")
            Dim row As DataRow = dataSource.Rows(0)
            Dim receiptNo As String = StringEnteredIn(row, "ReceiptNo")
           Me.visitTypeID = StringEnteredIn(row, "VisitTypeID")


            If visitTypeID.ToUpper().Equals(oVisitTypeID.InPatient().ToUpper()) Then
                Me.colRefVisitNo.DataPropertyName = "ExtraBillNo"
                Me.colRefVisitNo.HeaderText = "Extra Bill No"
                Me.colRefItemStatus.DataPropertyName = "EntryMode"
                Me.colRefItemStatus.HeaderText = "Entry Mode"
                Me.colRefItemStatusID.DataPropertyName = "EntryModeID"
                Me.colRefItemStatusID.HeaderText = "Entry Mode ID"
            Else : visitTypeID.ToUpper().Equals(oVisitTypeID.OutPatient().ToUpper())

                Me.colRefVisitNo.DataPropertyName = "VisitNo"
                Me.colRefVisitNo.HeaderText = "Visit No"
                Me.colRefItemStatus.DataPropertyName = "ItemStatus"
                Me.colRefItemStatus.HeaderText = "Item Status"
                Me.colRefItemStatusID.DataPropertyName = "ItemStatusID"
                Me.colRefItemStatusID.HeaderText = "Item Status ID"

            End If


            ShowPayments(receiptNo)

            Me.LoadRefundRequestDetails(refundRequestNo)
            Me.btnReject.Visible = True
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub


    Private Sub LoadRefundRequestDetails(refundRequentNo As String)
        Try

            Dim oRefundRequestDetails As New RefundRequestDetails()
            Dim oRefundRequestExtraBillItems As New RefundRequestExtraBillItems()
            Dim refundRequestDetails As DataTable = New DataTable

            dgvPaymentRefunds.Rows.Clear()

            If String.IsNullOrEmpty(Me.visitTypeID) Then Return

            If Me.visitTypeID.ToUpper.Equals(oVisitTypeID.InPatient.ToUpper) Then
                refundRequestDetails = oRefundRequestExtraBillItems.GetRefundRequestExtraBillItemsByRequestNo(refundRequentNo).Tables("RefundRequestExtraBillItems")

            ElseIf Me.visitTypeID.ToUpper.Equals(oVisitTypeID.OutPatient.ToUpper) Then
                refundRequestDetails = oRefundRequestDetails.GetRefundRequestDetailsByRequestNo(refundRequentNo).Tables("RefundRequestDetails")

            ElseIf Me.visitTypeID.ToUpper.Equals(oVisitTypeID.Combined.ToUpper) Then
                refundRequestDetails = oRefundRequestDetails.GetRefundRequestDetailsByRequestNo(refundRequentNo).Tables("RefundRequestDetails")
                refundRequestDetails.Merge(oRefundRequestExtraBillItems.GetRefundRequestExtraBillItemsByRequestNo(refundRequentNo).Tables("RefundRequestExtraBillItems"))
            End If


            If refundRequestDetails.Rows.Count < 1 Then Return

            LoadGridData(Me.dgvPaymentRefunds, refundRequestDetails)
            FormatGridRow(dgvPaymentRefunds)
            Me.CheckAcknowledgeable()
            Me.CalculateTotalRefundAmount()
        Catch ex As Exception
            ErrorMessage(ex)
        Finally

        End Try
    End Sub

    Private Sub CheckAcknowledgeable()
        Dim lInvoiceNo As New List(Of String)

        For rowNo As Integer = 0 To Me.dgvPaymentRefunds.Rows.Count - 1

            Dim cells As DataGridViewCellCollection = Me.dgvPaymentRefunds.Rows(rowNo).Cells

            Dim itemCategoryID As String = RevertText(StringMayBeEnteredIn(cells, Me.colRefItemCategoryID))
            Dim returnQuantity As Integer = IntegerMayBeEnteredIn(cells, Me.colRefQuantity)
            Dim itemStatusID As String = StringMayBeEnteredIn(cells, Me.colRefItemStatusID)

            If (itemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) OrElse
                 itemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) OrElse
                 itemCategoryID.ToUpper().Equals(oItemCategoryID.NonMedical.ToUpper())) AndAlso returnQuantity > 0 Then

                If Me.visitTypeID.ToUpper.Equals(oVisitTypeID.InPatient.ToUpper) Then
                    Me.dgvPaymentRefunds.Item(Me.colAcknowledgeable.Name, rowNo).Value = True
                    Me.dgvPaymentRefunds.Item(Me.colAcknowledgeable.Name, rowNo).ReadOnly = False
                ElseIf Me.visitTypeID.ToUpper.Equals(oVisitTypeID.OutPatient.ToUpper) AndAlso itemStatusID.ToUpper.Equals(oItemStatusID.Offered) Then
                    Me.dgvPaymentRefunds.Item(Me.colAcknowledgeable.Name, rowNo).Value = True
                    Me.dgvPaymentRefunds.Item(Me.colAcknowledgeable.Name, rowNo).ReadOnly = True
                End If


            Else

                Me.dgvPaymentRefunds.Item(Me.colAcknowledgeable.Name, rowNo).Value = False

            End If
        Next

    End Sub


    Private Sub ShowPendingRefundRequest()

        Dim oRefundRequests As New SyncSoft.SQLDb.RefundRequests()
        Dim oItemStatusID As New SyncSoft.SQLDb.Lookup.LookupDataID.ItemStatusID()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim pendingRequests As Integer = oRefundRequests.GetCountToRefundRequests()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblPendingRefundRequests.Text = "Pending Request(s): " + pendingRequests.ToString()

            ' Me.btnLoadRefundRequests.Visible = pendingRequests > 0
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub CalculateRefundAmount()
        Dim refundAmount As Decimal = CalculateGridAmount(dgvPaymentRefunds, Me.colRefAmount)
        Dim previousRefunded As Decimal = DecimalMayBeEnteredIn(stbAmountRefunded)
        Dim amountAmount = (refundAmount + previousRefunded)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        stbRefundAmountWords.Text = NumberToWords(amountAmount)
        nbxTotalRefundAmount.Text = FormatNumber(amountAmount, AppData.DecimalPlaces)
        nbxToRefundAmount.Value = FormatNumber(refundAmount, AppData.DecimalPlaces)

    End Sub

    Private Sub stbRefundRequestNo_Leave(sender As Object, e As System.EventArgs) Handles stbRefundRequestNo.Leave
        Dim refundRequestNo As String = RevertText(StringMayBeEnteredIn(Me.stbRefundRequestNo))
        If String.IsNullOrEmpty(refundRequestNo) Then Return
        Me.LoadRefundRequests(refundRequestNo)
    End Sub

    Private Sub stbRefundRequestNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbRefundRequestNo.TextChanged
        Me.ClearRefundsControls()
    End Sub


    Private Sub nbxTotalRefundAmount_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles nbxTotalRefundAmount.Validating
        Dim errorMSG As String = "Total refunded amount can't be more than receipt amount!"

        Try

            Dim receiptAmount As Decimal = DecimalMayBeEnteredIn(Me.stbRefundAmountPaid)
            Dim totalRefundAmount As Decimal = DecimalMayBeEnteredIn(Me.stbAmountRefunded) + DecimalMayBeEnteredIn(Me.nbxTotalRefundAmount)

            If receiptAmount < totalRefundAmount Then
                ErrProvider.SetError(Me.nbxTotalRefundAmount, errorMSG)
                Me.nbxTotalRefundAmount.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.nbxTotalRefundAmount, String.Empty)
            End If

        Catch ex As Exception
            Return

        End Try
    End Sub

    Private Function GetInvoiceDetails(visitNo As String, copayTypeID As String) As List(Of DBConnect)
        Dim lInvoiceDetails As New List(Of DBConnect)
        Dim invoiceNo As String = RevertText(StringEnteredIn(Me.stbInvoiceNo, "Invoice No!"))
        For rowNo As Integer = 0 To Me.dgvPaymentDetails.RowCount - 1

            If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, rowNo).Value) = True Then
                Dim cells As DataGridViewCellCollection = Me.dgvPaymentDetails.Rows(rowNo).Cells
                Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode, "item!")
                Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID)
                Dim prevInvoiceNo As String = StringMayBeEnteredIn(cells, Me.colInvoiceNo)
                If String.IsNullOrEmpty(prevInvoiceNo) Then

                    Using oInvoiceDetails As New SyncSoft.SQLDb.InvoiceDetails()



                        With oInvoiceDetails
                            .InvoiceNo = invoiceNo
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            If copayTypeID.ToUpper().Equals(oCopayTypeID.Percent().ToUpper()) OrElse copayTypeID.Equals(oCopayTypeID.Value().ToUpper()) Then
                                .ObjectName = oObjectNames.ItemsCASH()
                            ElseIf copayTypeID.ToUpper().Equals(oCopayTypeID.NA().ToUpper()) Then
                                .ObjectName = oObjectNames.Items()
                            End If

                            .Quantity = IntegerEnteredIn(cells, Me.colQuantity)

                            If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                                  (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                                .UnitPrice = Math.Abs(DecimalEnteredIn(cells, Me.colUnitPrice, True, "unit price!"))
                            Else : .UnitPrice = DecimalEnteredIn(cells, Me.colUnitPrice, False, "unit price!")
                            End If
                            .Discount = DecimalEnteredIn(cells, Me.colDiscount, True, "discount!")
                            If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                                  (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                                .Amount = DecimalEnteredIn(cells, Me.colAmount, True, "amount!")
                            Else : .Amount = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")
                            End If

                        End With


                        lInvoiceDetails.Add(oInvoiceDetails)
                    End Using
                End If
            End If
        Next

        Return lInvoiceDetails
    End Function

    Private Function GetNextBillAdjustmentNo(ByVal billNo As String) As String

        Dim billAdjustmentNo As String = String.Empty
        Try

            Dim oBillAdjustments As New SyncSoft.SQLDb.BillAdjustments()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("BillAdjustments", "AdjustmentNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim billAdjustmentID As String = oBillAdjustments.GetNextBillAdjustmentID(billNo).ToString()
            billAdjustmentID = billAdjustmentID.PadLeft(paddingLEN, paddingCHAR)

            billAdjustmentNo = FormatText(billNo + billAdjustmentID.Trim(), "BillAdjustments", "AdjustmentNo")

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

        Return billAdjustmentNo
    End Function




    Private Function GetNextInvoiceAdjustmentNo(ByVal invoiceNo As String) As String

        Dim AdjustmentNo As String = String.Empty
        Try

            Dim oInvoiceAdjustment As New SyncSoft.SQLDb.InvoiceAdjustments()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("InvoiceAdjustments", "AdjustmentNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim InvoiceAdjustmentsID As String = oInvoiceAdjustment.GetNextAdjustmentID(invoiceNo).ToString()
            InvoiceAdjustmentsID = InvoiceAdjustmentsID.PadLeft(paddingLEN, paddingCHAR)

            AdjustmentNo = FormatText(invoiceNo + InvoiceAdjustmentsID.Trim(), "InvoiceAdjustments", "AdjustmentNo")

        Catch ex As Exception

        End Try
        Return AdjustmentNo
    End Function


     Private Function GetVisitNoList() As List(Of String)
        Dim lvisitNo As New List(Of String)

        For rowNo As Integer = 0 To Me.dgvPaymentRefunds.Rows.Count - 1

            Dim cells As DataGridViewCellCollection = Me.dgvPaymentRefunds.Rows(rowNo).Cells

            Dim visitNo As String = RevertText(StringEnteredIn(cells, Me.colRefVisitNo, "VisitNo!"))
            If Not lvisitNo.Contains(visitNo) Then lvisitNo.Add(visitNo)



        Next
        Return lvisitNo
    End Function

    Private Function GetInvoiceNoList() As List(Of String)
        Dim lInvoiceNo As New List(Of String)

        For rowNo As Integer = 0 To Me.dgvPaymentRefunds.Rows.Count - 1

            Dim cells As DataGridViewCellCollection = Me.dgvPaymentRefunds.Rows(rowNo).Cells

            Dim invoiceNo As String = StringMayBeEnteredIn(cells, Me.colRefInvoiceNo)
            If Not String.IsNullOrEmpty(invoiceNo) Then
                If Not lInvoiceNo.Contains(invoiceNo) Then lInvoiceNo.Add(invoiceNo)
            End If

        Next

        Return lInvoiceNo

    End Function

  
    Private Sub btnBPFindVisitNoByInvoiceNo_Click(sender As System.Object, e As System.EventArgs) Handles btnBPFindVisitNoByInvoiceNo.Click
        Try

            Dim fFindObject As New frmFindObject(ObjectName.InvoiceNo)

            If fFindObject.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then Me.LoadInvoiceNoDetails(fFindObject.GetInvoiceNo())

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub LoadInvoiceNoDetails(ByVal invoices As DataTable)

        Try

            Me.Cursor = Cursors.WaitCursor


            Dim row As DataRow = invoices.Rows(0)


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbBPVisitNo.Text = StringMayBeEnteredIn(row, "VisitNo")
            Me.cboBPBillAccountNo.Text = StringMayBeEnteredIn(row, "BIllNo")
            Dim StartDate As Date = DateMayBeEnteredIn(row, "VisitDate")

            Me.dtpBPStartDate.Value = StartDate
            Me.dtpBPEndDate.Value = StartDate.AddDays(+2)

            Me.cboBPBillAccountNo.Focus()

            Me.stbBPVisitNo.Focus()

            Me.stbBPVisitNo.Focus()
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub


    Private Sub btnCBFFindVisitNoByInvoiceNo_Click(sender As System.Object, e As System.EventArgs) Handles btnCBFFindVisitNoByInvoiceNo.Click
        Try

            Dim fFindObject As New frmFindObject(ObjectName.InvoiceNo)

            If fFindObject.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then Me.LoadIPDInvoiceNoDetails(fFindObject.GetIPDInvoiceNo())

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub LoadIPDInvoiceNoDetails(ByVal invoices As DataTable)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim row As DataRow = invoices.Rows(0)


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbCBFPVisitNo.Text = StringMayBeEnteredIn(row, "VisitNo")
            Me.cboCBFPBillAccountNo.Text = StringMayBeEnteredIn(row, "BIllNo")
            Dim StartDate As Date = DateMayBeEnteredIn(row, "ExtraBillDate")

            Me.dtpCBFPStartDate.Value = StartDate
            Me.dtpCBFPEndDate.Value = StartDate.AddDays(+2)

            Me.cboCBFPBillAccountNo.Focus()

            Me.stbCBFPVisitNo.Focus()



        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try




    End Sub


    Private Sub stbRefundReceiptNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbRefundReceiptNo.TextChanged
        Me.ClearRefundsControls()
    End Sub

    Public Function CheckAvaliableToPayForDrugs(itemCode As String, itemCategoryID As String, quantity As Integer) As Boolean

        If itemCategoryID.ToUpper.Equals(oItemCategoryID.Drug().ToUpper()) Then
            Dim availableDrugs As Integer = GetAvailableToPayForDrugs(itemCode)
            If (quantity > availableDrugs AndAlso oVariousOptions.DisallowPaymentOfOutStockDrugs()) Then
                Throw New Exception("The available to pay for drug: " + availableDrugs.ToString() + " can't be less than to pay for quantity: " + quantity.ToString())

            End If
        End If
        Return True
    End Function

    Private Sub nbxBPWithholdingTax_TextChanged(sender As System.Object, e As System.EventArgs) Handles nbxBPWithholdingTax.TextChanged
        Me.CalculateAccountTotalBill()
    End Sub

    Private Sub nbxBPGrandDiscount_TextChanged(sender As System.Object, e As System.EventArgs) Handles nbxBPGrandDiscount.TextChanged
        Me.CalculateAccountTotalBill()
    End Sub

  
    Private Sub nbxCBFPGrandDiscount_TextChanged(sender As System.Object, e As System.EventArgs) Handles nbxCBFPGrandDiscount.TextChanged
        Me.CalculateCBFPAccountTotalBill()
    End Sub

    Private Sub nbxCBFPWithholdingTax_TextChanged(sender As System.Object, e As System.EventArgs) Handles nbxCBFPWithholdingTax.TextChanged
        Me.CalculateCBFPAccountTotalBill()
    End Sub

  

    Private Sub btnFindReceiptNo_Click(sender As System.Object, e As System.EventArgs) Handles btnFindReceiptNo.Click

        Dim refundRequestNo As String = RevertText(StringMayBeEnteredIn(Me.stbRefundRequestNo))
        Dim fRefundRequestNo As New frmFindAutoNo(Me.stbRefundRequestNo, AutoNumber.RefundRequestNo)
        fRefundRequestNo.ShowDialog(Me)
        Me.stbRefundRequestNo.Focus()

        If String.IsNullOrEmpty(refundRequestNo) Then Return
        Me.LoadRefundRequests(refundRequestNo)

    End Sub

    
End Class