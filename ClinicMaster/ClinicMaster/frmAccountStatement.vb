
Option Strict On
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports SyncSoft.Common.Structures
Imports SyncSoft.Common.SQL.Methods
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports SyncSoft.SQLDb
Imports System.Drawing.Printing

Public Class frmAccountStatement

#Region " Fields "
    Private billCustomers As DataTable
    Private WithEvents docPrintAccountStatement As New PrintDocument()
    Private accountStatement As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private bodySmallFont As New Font(printFontName, 6)
#End Region

    Private Sub frmAccountStatement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboBillMode, LookupObjects.BillModes, False)
            Me.dtpStartDate.Value = Today.AddDays(-1)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmAccountStatement_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub


    Private Sub LoadAccountClients(ByVal billModesID As String)

        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblAccountNo.Text = "Account No"
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

    Private Sub ClearControls()
        Me.stbAccountName.Clear()
        Me.nbxAccountBalance.Clear()
        Me.nbxOutstandingBill.Clear()
        Me.stbAccountName.Clear()
        Me.dgvCashReceipts.Rows.Clear()
        Me.dgvAccountTrasaction.Rows.Clear()
        Me.dgvRefunds.Rows.Clear()
        Me.cboAccountNo.Text = String.Empty

    End Sub

    Private Sub LoadData()

        Dim oAccounts As New SyncSoft.SQLDb.Accounts
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oItems As New Items()
            Dim oExtraBillItems As New ExtraBillItems()
            Dim oPayments As New Payments()
            Dim oRefunds As New Refunds()

            Dim items As New DataTable
            Dim oBillModesID As New LookupDataID.BillModesID()
            Dim AccountNo As String = RevertText(StringMayBeEnteredIn(Me.cboAccountNo))
            Dim startDate As Date = DateTimeEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDateTime As Date = DateTimeEnteredIn(Me.dtpEndDate, "End  Date")
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillMode, "Account Category!")
            Dim includeProcessing As Boolean = chkIncludeProcessing.Checked
            Dim includePending As Boolean = chkIncludePending.Checked
            If endDateTime < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            If String.IsNullOrEmpty(billModesID) Then Return

            If billModesID.ToUpper.Equals(oBillModesID.Cash.ToUpper) Then
                items = oItems.GetPeriodicItemsByPatientNo(AccountNo, startDate, endDateTime, includeProcessing, includePending).Tables("Items")

            Else
                items = oItems.GetPeriodicItemsByBillNo(AccountNo, startDate, endDateTime, includeProcessing, includePending).Tables("Items")
            End If
            Dim extraBillItems As DataTable = oExtraBillItems.GetPeriodicExtraBillItemsByBillToCustomerNo(AccountNo, billModesID, startDate, endDateTime).Tables("ExtraBillItems")
            Dim payments As DataTable = oPayments.GetPeriodicPaymentsByBillToCustomerNo(AccountNo, billModesID, startDate, endDateTime).Tables("Payments")
            Dim refunds As DataTable = oRefunds.GetPeriodicRefundsByBillToCustomerNo(AccountNo, billModesID, startDate, endDateTime).Tables("Refunds")
            Dim accounts As DataTable = oAccounts.GetPeriodicAccountTransactionsByAccountBillNo(AccountNo, startDate, endDateTime).Tables("Accounts")


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim message As String = "No " + Me.Text + " record(s) found for period between " +
                FormatDate(startDate) + " and " + FormatDate(endDateTime) + "!"

            LoadGridData(dgvOPDBills, items)
            LoadGridData(Me.dgvIPDBills, extraBillItems)
            LoadGridData(dgvCashReceipts, payments)
            LoadGridData(dgvRefunds, refunds)
            LoadGridData(Me.dgvAccountTrasaction, accounts)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            FormatGridColumn(dgvOPDBills)
            FormatGridColumn(dgvIPDBills)
            FormatGridColumn(dgvCashReceipts)
            FormatGridColumn(dgvRefunds)
            FormatGridColumn(Me.dgvAccountTrasaction)

            Dim totalOPDBills As Decimal = CalculateGridAmount(dgvOPDBills, Me.colOPDBillAmount)
            Dim totalIPDBills As Decimal = CalculateGridAmount(dgvIPDBills, Me.colIPDBillAmount)
            Dim totalPaidAmount As Decimal = CalculateGridAmount(dgvCashReceipts, Me.colPayAmount)
            Dim totalRefunds As Decimal = CalculateGridAmount(dgvRefunds, Me.colRefAmount)

            Dim totalCredit As Decimal = CalculateGridAmount(dgvAccountTrasaction, Me.colCredit)
            Dim totalDebit As Decimal = CalculateGridAmount(dgvAccountTrasaction, Me.colDebit)
            Dim accountBalance As Decimal = totalCredit - totalDebit
            Dim balance As Decimal = (totalPaidAmount + accountBalance) - (totalOPDBills + totalIPDBills + totalRefunds)

            Me.stbTotalOPDBills.Text = FormatNumber(totalOPDBills, AppData.DecimalPlaces)
            Me.stblTotalIPDBills.Text = FormatNumber(totalIPDBills, AppData.DecimalPlaces)
            Me.stbTotalPayments.Text = FormatNumber(totalPaidAmount, AppData.DecimalPlaces)
            Me.stbTotalRefunds.Text = FormatNumber(totalRefunds, AppData.DecimalPlaces)
            Me.stbTotalCredit.Text = FormatNumber(totalCredit, AppData.DecimalPlaces)
            Me.stbTotalDebit.Text = FormatNumber(totalDebit, AppData.DecimalPlaces)
            Me.stbNetAmount.Text = FormatNumber(accountBalance, AppData.DecimalPlaces)
            Me.stbBalance.Text = FormatNumber(balance, AppData.DecimalPlaces)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbTotalOPDBillWords.Text = NumberToWords(totalOPDBills)
            Me.stbTotalIPDBillWords.Text = NumberToWords(totalIPDBills)
            Me.stbTotalPaymentWords.Text = NumberToWords(totalPaidAmount)
            Me.stbTotalRefundWords.Text = NumberToWords(totalRefunds)
            Me.stbNetAmountWords.Text = NumberToWords(accountBalance)
            Me.stbBalanceWords.Text = NumberToWords(balance)


            EnablePrintButtons(dgvOPDBills.Rows.Count > 0 OrElse dgvIPDBills.Rows.Count > 0 OrElse dgvCashReceipts.RowCount > 0 OrElse dgvAccountTrasaction.RowCount > 0 OrElse dgvRefunds.RowCount > 0)
            'If dgvPatientsAccount.Rows.Count < 1 Then DisplayMessage(message)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



    Private Sub LoadAccountDetails()
        Try

            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillMode, "Account Category!")
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

    Private Sub EnablePrintButtons(bool As Boolean)
        btnPrint.Enabled = bool
        btnPrintPreview.Enabled = bool

    End Sub

    Private Sub LoadAccountDetails(ByVal billModesID As String, ByVal accountNo As String)

        Dim accountName As String = String.Empty
        Dim accountBalance As Decimal

        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()

        Dim oBillModesID As New LookupDataID.BillModesID()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbAccountName.Clear()
            Me.nbxAccountBalance.Clear()
            'Me.stbTotalDeposit.Clear()
            'Me.stbBill.Clear()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oPatients.GetPatients(accountNo).Tables("Patients").Rows(0)

                    Me.cboAccountNo.Text = FormatText(accountNo, "Patients", "PatientNo")
                    accountName = StringMayBeEnteredIn(row, "FullName")
                    accountBalance = GetAccountBalance(oBillModesID.Cash, accountNo)
                    Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(row, "OutstandingBalance")
                    Me.nbxOutstandingBill.Value = FormatNumber(outstandingBalance, AppData.DecimalPlaces)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oBillCustomers.GetBillCustomers(accountNo).Tables("BillCustomers").Rows(0)

                    Me.cboAccountNo.Text = FormatText(accountNo, "BillCustomers", "AccountNo").ToUpper()
                    accountName = StringMayBeEnteredIn(row, "BillCustomerName")
                    accountBalance = GetAccountBalance(oBillModesID.Account, accountNo)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oInsurances.GetInsurances(accountNo).Tables("Insurances").Rows(0)

                    Me.cboAccountNo.Text = FormatText(accountNo, "Insurances", "InsuranceNo")
                    accountName = StringMayBeEnteredIn(row, "InsuranceName")
                    accountBalance = GetAccountBalance(oBillModesID.Insurance, accountNo)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbAccountName.Text = accountName
            Me.nbxAccountBalance.Value = FormatNumber(accountBalance, AppData.DecimalPlaces)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboBillMode_Leave(sender As Object, e As System.EventArgs) Handles cboBillMode.Leave
        fbnLoad.PerformClick()
    End Sub



    Private Sub cboBillMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBillMode.SelectedIndexChanged
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oBillModesID As New LookupDataID.BillModesID()
            Me.cboAccountNo.Items.Clear()
            Me.ClearControls()


            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillMode, "Account Category!")
            If String.IsNullOrEmpty(billModesID) Then Return
            Me.btnLoad.Visible = billModesID.ToUpper().Equals(oBillModesID.Cash().ToUpper())
            Me.LoadAccountClients(billModesID)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub



    Private Sub fbnLoad_Click(sender As Object, e As EventArgs) Handles fbnLoad.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            LoadData()
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub



    Private Sub cboAccountNo_Leave(sender As Object, e As EventArgs) Handles cboAccountNo.Leave
        Try
            Me.Cursor = Cursors.WaitCursor
            LoadAccountDetails()
            fbnLoad.PerformClick()
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Patients", Me.cboAccountNo)
            fQuickSearch.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.cboAccountNo))
            If Not String.IsNullOrEmpty(patientNo) Then Me.LoadAccountDetails()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

#Region "Print"

    Private Sub docPrintCashReceipts_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docPrintAccountStatement.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = "Account Statement"

            Dim startDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpStartDate))
            Dim endDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpEndDate))
            Dim accountNo As String = StringEnteredIn(cboAccountNo, "Account No")
            Dim AccountName As String = StringMayBeEnteredIn(stbAccountName)
            Dim accountBalance As String = FormatNumber(DecimalMayBeEnteredIn(nbxAccountBalance), AppData.DecimalPlaces)
            Dim outStandingBill As String = FormatNumber(DecimalMayBeEnteredIn(nbxOutstandingBill), AppData.DecimalPlaces)

            If Not String.IsNullOrEmpty(accountNo) Then
                title += " of : " + AccountName
            End If


            title = title.ToUpper()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 11 * widthTopFirst
                Dim widthTopThird As Single = 18 * widthTopFirst
                Dim widthTopFourth As Single = 26 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    Dim oProductOwner As ProductOwner = GetProductOwnerInfo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Account No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(accountNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Start Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(startDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight
                    .DrawString("End Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(endDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Account Balance: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(accountBalance, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Outstanding Bill: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(outStandingBill, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
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

                If accountStatement Is Nothing Then Return

                Do While accountStatement.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(accountStatement(1), PrintParagraps)
                    accountStatement.Remove(1)

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
                        accountStatement.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (accountStatement.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub SetAccountStatementPrintData()



        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        accountStatement = New Collection()
        Dim padAmount As Integer = 60

        Try

            If Me.dgvOPDBills.Rows.Count > 0 Then
                Dim accountHeader As New System.Text.StringBuilder(String.Empty)
                accountHeader.Append(ControlChars.NewLine)
                accountHeader.Append(ControlChars.NewLine)
                accountStatement.Add(New PrintParagraps(bodyBoldFont, accountHeader.ToString()))
                accountStatement.Add(New PrintParagraps(bodyNormalFont, Me.GetOPDBillPrintData))
                accountStatement.Add(New PrintParagraps(bodyNormalFont, ControlChars.NewLine))
                Dim totalAmountBuilder As New System.Text.StringBuilder(String.Empty)
                Dim totalAmount As String = stbTotalOPDBills.Text
                totalAmountBuilder.Append("Total Amount")
                totalAmountBuilder.Append(totalAmount.PadLeft(padAmount))
                accountStatement.Add(New PrintParagraps(bodyBoldFont, totalAmountBuilder.ToString()))


            End If

            If Me.dgvIPDBills.Rows.Count > 0 Then
                Dim accountHeader As New System.Text.StringBuilder(String.Empty)
                accountHeader.Append(ControlChars.NewLine)
                accountHeader.Append(ControlChars.NewLine)
                accountStatement.Add(New PrintParagraps(bodyBoldFont, accountHeader.ToString()))
                accountStatement.Add(New PrintParagraps(bodyNormalFont, Me.GetIPDBillPrintData))
                accountStatement.Add(New PrintParagraps(bodyNormalFont, ControlChars.NewLine))
                Dim totalAmountBuilder As New System.Text.StringBuilder(String.Empty)
                Dim totalAmount As String = stblTotalIPDBills.Text
                totalAmountBuilder.Append("Total Amount")
                totalAmountBuilder.Append(totalAmount.PadLeft(padAmount))
                accountStatement.Add(New PrintParagraps(bodyBoldFont, totalAmountBuilder.ToString()))
            End If


            If Me.dgvCashReceipts.Rows.Count > 0 Then
                Dim accountHeader As New System.Text.StringBuilder(String.Empty)
                accountHeader.Append(ControlChars.NewLine)
                accountHeader.Append(ControlChars.NewLine)
                accountStatement.Add(New PrintParagraps(bodyBoldFont, accountHeader.ToString()))
                accountStatement.Add(New PrintParagraps(bodyNormalFont, Me.GetCashReceiptPrintData))
                accountStatement.Add(New PrintParagraps(bodyNormalFont, ControlChars.NewLine))
                Dim totalAmountBuilder As New System.Text.StringBuilder(String.Empty)
                Dim totalAmount As String = stbTotalPayments.Text
                totalAmountBuilder.Append("Total Amount")
                totalAmountBuilder.Append(totalAmount.PadLeft(padAmount))
                accountStatement.Add(New PrintParagraps(bodyBoldFont, totalAmountBuilder.ToString()))
            End If

            If Me.dgvRefunds.Rows.Count > 0 Then
                Dim refundHeader As New System.Text.StringBuilder(String.Empty)
                refundHeader.Append(ControlChars.NewLine)
                refundHeader.Append(ControlChars.NewLine)
                accountStatement.Add(New PrintParagraps(bodyBoldFont, refundHeader.ToString()))
                accountStatement.Add(New PrintParagraps(bodyNormalFont, Me.GetRefundPrintData()))
                accountStatement.Add(New PrintParagraps(bodyNormalFont, ControlChars.NewLine))
                Dim totalAmountBuilder As New System.Text.StringBuilder(String.Empty)
                Dim totalAmount As String = stbTotalRefunds.Text
                totalAmountBuilder.Append("Total Amount")
                totalAmountBuilder.Append(totalAmount.PadLeft(padAmount))
                accountStatement.Add(New PrintParagraps(bodyBoldFont, totalAmountBuilder.ToString()))
            End If


            If Me.dgvAccountTrasaction.Rows.Count > 0 Then
                Dim accountHeader As New System.Text.StringBuilder(String.Empty)
                accountHeader.Append(ControlChars.NewLine)
                accountHeader.Append(ControlChars.NewLine)
                accountStatement.Add(New PrintParagraps(bodyBoldFont, accountHeader.ToString()))
                accountStatement.Add(New PrintParagraps(bodyNormalFont, Me.GetAccountTransactionsPrintData()))
                accountStatement.Add(New PrintParagraps(bodyNormalFont, ControlChars.NewLine))
                Dim totalAmountBuilder As New System.Text.StringBuilder(String.Empty)
                Dim totalAmount As String = stbNetAmount.Text
                totalAmountBuilder.Append("Total Amount")
                totalAmountBuilder.Append(totalAmount.PadLeft(padAmount))
                accountStatement.Add(New PrintParagraps(bodyBoldFont, totalAmountBuilder.ToString()))
            End If

            Dim netAmountBuilder As New System.Text.StringBuilder(String.Empty)
            Dim balance As Decimal = DecimalMayBeEnteredIn(stbBalance)
            netAmountBuilder.Append(ControlChars.NewLine)
            netAmountBuilder.Append(ControlChars.NewLine)
            netAmountBuilder.Append("Balance")
            netAmountBuilder.Append(stbBalance.Text.PadLeft(padAmount + 5))
            If Not balance.Equals(0) Then
                netAmountBuilder.Append(ControlChars.NewLine)
                netAmountBuilder.Append("(" + stbBalanceWords.Text.Trim() + ")")
            End If

            accountStatement.Add(New PrintParagraps(bodyBoldFont, netAmountBuilder.ToString()))


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Received By:      " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:         " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            accountStatement.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            checkedSignData.Append(ControlChars.NewLine)

            checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
            checkedSignData.Append(GetSpaces(4))
            checkedSignData.Append("Date:         " + GetCharacters("."c, 20))
            checkedSignData.Append(ControlChars.NewLine)
            accountStatement.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            accountStatement.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function GetOPDBillPrintData() As String

        Dim padItemNo As Integer = 4
        Dim padVisitNo As Integer = 20
        Dim padVisitDate As Integer = 20
        Dim padAmount As Integer = 20



        Dim _OPDBills As New System.Text.StringBuilder(String.Empty)

        Try


            Dim tableHeader As New System.Text.StringBuilder("Out Patient Bills")
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append("No".PadRight(padItemNo))
            tableHeader.Append("Visit No".PadRight(padVisitNo))
            tableHeader.Append("Visit Date".PadRight(padVisitDate))
            tableHeader.Append("Amount".PadRight(padAmount))

            tableHeader.Append(ControlChars.NewLine)
            _OPDBills.Append(tableHeader)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim itemCount As Integer = 0

            For rowNo As Integer = 0 To Me.dgvOPDBills.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvOPDBills.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim visitNo As String = StringMayBeEnteredIn(cells, Me.colOPDBillViistNo)
                Dim visitDate As String = StringMayBeEnteredIn(cells, colVisitDate)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colOPDBillAmount)


                tableData.Append(itemNo.PadRight(padItemNo))
                tableData.Append(visitNo.PadRight(padVisitNo))
                tableData.Append(visitDate.PadRight(padVisitDate))
                tableData.Append(amount.PadRight(padAmount))


                tableData.Append(ControlChars.NewLine)

            Next

            _OPDBills.Append(tableData)



        Catch ex As Exception
            Throw ex
        End Try
        Return _OPDBills.ToString()
    End Function


    Private Function GetIPDBillPrintData() As String

        Dim padItemNo As Integer = 4
        Dim padExtraBillNo As Integer = 20
        Dim padExtraBillDate As Integer = 20
        Dim padAmount As Integer = 20


        Dim _IPDBills As New System.Text.StringBuilder(String.Empty)

        Try


            Dim tableHeader As New System.Text.StringBuilder("In Patient Bills")
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append("No".PadRight(padItemNo))
            tableHeader.Append("Extra Bill No".PadRight(padExtraBillNo))
            tableHeader.Append("Extra Bill Date".PadRight(padExtraBillDate))
            tableHeader.Append("Amount".PadRight(padAmount))


            tableHeader.Append(ControlChars.NewLine)
            _IPDBills.Append(tableHeader)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim itemCount As Integer = 0

            For rowNo As Integer = 0 To Me.dgvIPDBills.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvIPDBills.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim visitNo As String = StringMayBeEnteredIn(cells, Me.colIPDBillExtraBillNo)
                Dim extraBillDate As String = StringMayBeEnteredIn(cells, colExtraBillDate)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colIPDBillAmount)

                tableData.Append(itemNo.PadRight(padItemNo))
                tableData.Append(visitNo.PadRight(padExtraBillNo))
                tableData.Append(extraBillDate.PadRight(padExtraBillDate))
                tableData.Append(amount.PadRight(padAmount))
                tableData.Append(ControlChars.NewLine)

            Next

            _IPDBills.Append(tableData)


        Catch ex As Exception
            Throw ex
        End Try
        Return _IPDBills.ToString()
    End Function


    Private Function GetCashReceiptPrintData() As String

        Dim padItemNo As Integer = 4
        Dim padReceiptNo As Integer = 20
        Dim padVisitDate As Integer = 20
        Dim padAmount As Integer = 20


        Dim cashReceipt As New System.Text.StringBuilder(String.Empty)

        Try


            Dim tableHeader As New System.Text.StringBuilder("Cash Receipts")
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append("No".PadRight(padItemNo))
            tableHeader.Append("Receipt No".PadRight(padReceiptNo))
            tableHeader.Append("Pay Date".PadRight(padVisitDate))
            tableHeader.Append("Amount".PadRight(padAmount))



            tableHeader.Append(ControlChars.NewLine)
            cashReceipt.Append(tableHeader)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim itemCount As Integer = 0

            For rowNo As Integer = 0 To Me.dgvCashReceipts.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvCashReceipts.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim receiptNo As String = StringMayBeEnteredIn(cells, Me.colPayReceiptNo)
                Dim payDate As String = StringMayBeEnteredIn(cells, Me.colPayDate)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colPayAmount)
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colPayNotes)
                

                tableData.Append(itemNo.PadRight(padItemNo))
                tableData.Append(receiptNo.PadRight(padReceiptNo))
                tableData.Append(payDate.PadRight(padVisitDate))
                tableData.Append(amount.PadRight(padAmount))



                tableData.Append(ControlChars.NewLine)

            Next
            cashReceipt.Append(tableData)


        Catch ex As Exception
            Throw ex
        End Try
        Return cashReceipt.ToString()
    End Function

    Private Function GetRefundPrintData() As String

        Dim padItemNo As Integer = 3
        Dim padReceiptNo As Integer = 13
        Dim padAmount As Integer = 16
        Dim padRefundDate As Integer = 16

        Dim refundPrintString As New System.Text.StringBuilder(String.Empty)
        Try

            Dim tableHeader As New System.Text.StringBuilder("Refunds")
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append("No".PadRight(padItemNo))
            tableHeader.Append("Refund No".PadRight(padReceiptNo))
            tableHeader.Append("Refund Date".PadRight(padRefundDate))
            tableHeader.Append("Amount".PadRight(padAmount))

            tableHeader.Append(ControlChars.NewLine)
            refundPrintString.Append(tableHeader)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim itemCount As Integer = 0

            For rowNo As Integer = 0 To Me.dgvRefunds.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvRefunds.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim receiptNo As String = StringMayBeEnteredIn(cells, Me.colRefTransactionNo)
                Dim amount As String = FormatNumber(DecimalMayBeEnteredIn(cells, Me.colRefAmount), AppData.DecimalPlaces)
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colRefNotes)
                Dim refundDate As String = StringMayBeEnteredIn(cells, colRefundDate)

                tableData.Append(itemNo.PadRight(padItemNo))
                tableData.Append(receiptNo.PadRight(padReceiptNo))
                tableData.Append(refundDate.PadRight(padRefundDate))
                tableData.Append(amount.PadRight(padAmount))



                tableData.Append(ControlChars.NewLine)

            Next

            refundPrintString.Append(tableData)




        Catch ex As Exception
            Throw ex
        End Try
        Return refundPrintString.ToString()
    End Function


    Private Function GetAccountTransactionsPrintData() As String

        Dim padItemNo As Integer = 3
        Dim padTranNo As Integer = 12
        Dim padTranDate As Integer = 16
        Dim padCredit As Integer = 15
        Dim padDebit As Integer = 15
        Dim padBalance As Integer = 16




        pageNo = 0
        Dim accountTransactionsParagraphy As New System.Text.StringBuilder("Account Transactions")

        Try


            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append("No".PadRight(padItemNo))
            tableHeader.Append("Tran No".PadRight(padTranNo))
            tableHeader.Append("Tran Date".PadRight(padTranDate))
            tableHeader.Append("Credit".PadRight(padCredit))
            tableHeader.Append("Debit".PadRight(padDebit))
            tableHeader.Append("Balance".PadRight(padBalance))



            tableHeader.Append(ControlChars.NewLine)
            accountTransactionsParagraphy.Append(tableHeader)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim itemCount As Integer = 0

            For rowNo As Integer = 0 To Me.dgvAccountTrasaction.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvAccountTrasaction.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim tranNo As String = StringMayBeEnteredIn(cells, Me.colTranNo)
                Dim tranDate As String = StringMayBeEnteredIn(cells, colTranDate)
                Dim credit As String = StringMayBeEnteredIn(cells, Me.colCredit)
                Dim debit As String = StringMayBeEnteredIn(cells, Me.colDebit)
                Dim balance As String = StringMayBeEnteredIn(cells, Me.colBalance)
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colAccNotes)


                tableData.Append(itemNo.PadRight(padItemNo))
                tableData.Append(tranNo.PadRight(padTranNo))
                tableData.Append(tranDate.PadRight(padTranDate))
                tableData.Append(credit.PadRight(padCredit))
                tableData.Append(debit.PadRight(padDebit))
                tableData.Append(balance.PadRight(padBalance))



                tableData.Append(ControlChars.NewLine)

            Next

            accountTransactionsParagraphy.Append(tableData)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            Throw ex
        End Try
        Return accountTransactionsParagraphy.ToString()
    End Function

   
    Private Sub PrintPatientData()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvCashReceipts.RowCount < 1 AndAlso Me.dgvAccountTrasaction.RowCount < 1 AndAlso Me.dgvRefunds.RowCount < 1 Then
                Throw New ArgumentException("Must set at least one entry one item!")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetAccountStatementPrintData()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docPrintAccountStatement
            
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docPrintAccountStatement.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub



    Private Sub btnPrintPreview_Click(sender As Object, e As EventArgs) Handles btnPrintPreview.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ' Make a PrintDocument and attach it to the PrintPreview dialog.
            Dim dlgPrintPreview As New PrintPreviewDialog()

            Me.SetAccountStatementPrintData()

            With dlgPrintPreview
                .Document = docPrintAccountStatement
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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintPatientData()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub fbnRefresh_Click(sender As Object, e As EventArgs) Handles fbnRefresh.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            Me.cboBillMode.SelectedIndex = -1
            Me.dtpStartDate.Value = Today
            Me.dtpEndDate.Value = Now
            ''''''''''''''''''''''''''''''''''''''''''''
            Me.fbnLoad.PerformClick()
            ''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

#End Region

    Private Sub chkIncludePending_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkIncludePending.CheckedChanged
        chkIncludeProcessing.Checked = chkIncludePending.Checked
        chkIncludeProcessing.Enabled = Not chkIncludePending.Checked
    End Sub

End Class