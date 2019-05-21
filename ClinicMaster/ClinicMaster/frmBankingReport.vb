
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports SyncSoft.SQLDb
Imports System.Drawing.Printing
Imports SyncSoft.Common.Structures

Public Class frmBankingReport
    Private WithEvents docBankingRegister As New PrintDocument()
    Private bankingRegisterParagraph As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 6, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 6)

#Region " Fields "

#End Region

    Private Sub frmBankingReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()
            Me.dtpStartDateTime.MaxDate = Today.AddDays(1)
            Me.dtpEndDateTime.MaxDate = Today.AddDays(1)

            Me.dtpStartDateTime.Value = Today
            Me.dtpEndDateTime.Value = Now
            LoadLookupDataCombo(Me.cboBankNamesID, LookupObjects.BankNamesID, False)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.cboLoginID.Text = CurrentUser.LoginID
            Dim loginID As String = StringMayBeEnteredIn(Me.cboLoginID)
            Dim bankNameID As String = StringValueMayBeEnteredIn(Me.cboBankNamesID)
            Dim accountNo As String = StringValueMayBeEnteredIn(Me.cboAccountNo)
            Me.LoadBankingRegister(bankNameID, accountNo, loginID, Today, Now)
            LoadAccounts()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmBankingReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadAccounts()

        Dim oBankAccount As New SyncSoft.SQLDb.BankAccounts()

        cboAccountNo.DataSource = Nothing
        Try
            Me.Cursor = Cursors.WaitCursor
            cboAccountNo.DataSource = Nothing
            Dim bankAccount As DataTable
            Dim bankID As String = StringValueMayBeEnteredIn(cboBankNamesID)
            If String.IsNullOrEmpty(bankID) Then
                bankAccount = oBankAccount.GetBankAccounts(String.Empty, String.Empty, String.Empty).Tables("BankAccounts")
            Else
                bankAccount = oBankAccount.GetBankAccountsByBankID(bankID).Tables("BankAccounts")
            End If
            cboAccountNo.DisplayMember = "AccountName"
            cboAccountNo.ValueMember = "AccountNo"
            cboAccountNo.DataSource = bankAccount
            cboAccountNo.SelectedIndex = -1
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Public Function GetPeriodicBankingRegister(ByVal bankNamesID As String, ByVal accountNo As String, ByVal loginID As String, startDate As Date, endDate As Date) As DataSet
        Dim oBankingRegister As New BankingRegister
        If String.IsNullOrEmpty(bankNamesID) AndAlso String.IsNullOrEmpty(accountNo) AndAlso String.IsNullOrEmpty(loginID) Then
            Return oBankingRegister.GetPeriodicBankingRegister(String.Empty, String.Empty, String.Empty, startDate, endDate)

        ElseIf Not String.IsNullOrEmpty(bankNamesID) AndAlso String.IsNullOrEmpty(accountNo) AndAlso String.IsNullOrEmpty(loginID) Then
            Return oBankingRegister.GetPeriodicBankingRegister(bankNamesID, String.Empty, String.Empty, startDate, endDate)

        ElseIf String.IsNullOrEmpty(bankNamesID) AndAlso Not String.IsNullOrEmpty(accountNo) AndAlso String.IsNullOrEmpty(loginID) Then
            Return oBankingRegister.GetPeriodicBankingRegister(String.Empty, accountNo, String.Empty, startDate, endDate)

        ElseIf String.IsNullOrEmpty(bankNamesID) AndAlso String.IsNullOrEmpty(accountNo) AndAlso Not String.IsNullOrEmpty(loginID) Then
            Return oBankingRegister.GetPeriodicBankingRegister(String.Empty, String.Empty, loginID, startDate, endDate)

        ElseIf Not String.IsNullOrEmpty(bankNamesID) AndAlso Not String.IsNullOrEmpty(accountNo) AndAlso String.IsNullOrEmpty(loginID) Then
            Return oBankingRegister.GetPeriodicBankingRegister(bankNamesID, accountNo, String.Empty, startDate, endDate)

        ElseIf Not String.IsNullOrEmpty(bankNamesID) AndAlso String.IsNullOrEmpty(accountNo) AndAlso Not String.IsNullOrEmpty(loginID) Then
            Return oBankingRegister.GetPeriodicBankingRegister(bankNamesID, String.Empty, loginID, startDate, endDate)

        ElseIf String.IsNullOrEmpty(bankNamesID) AndAlso Not String.IsNullOrEmpty(accountNo) AndAlso Not String.IsNullOrEmpty(loginID) Then
            Return oBankingRegister.GetPeriodicBankingRegister(String.Empty, accountNo, loginID, startDate, endDate)

        Else
            Return oBankingRegister.GetPeriodicBankingRegister(bankNamesID, accountNo, loginID, startDate, endDate)
        End If

    End Function

    Public Function GetMessage(ByVal bankNamesID As String, ByVal accountNo As String, ByVal loginID As String, startDate As Date, endDate As Date) As String
        Dim oBankingRegister As New BankingRegister
        Dim message As String = String.Empty
        Dim startPeriod As String = FormatDate(startDate)
        Dim endPeriod As String = FormatDate(endDate)
        If String.IsNullOrEmpty(bankNamesID) AndAlso String.IsNullOrEmpty(accountNo) AndAlso String.IsNullOrEmpty(loginID) Then
            Return "No banked records found between " + startPeriod + " and " + endPeriod

        ElseIf Not String.IsNullOrEmpty(bankNamesID) AndAlso String.IsNullOrEmpty(accountNo) AndAlso String.IsNullOrEmpty(loginID) Then
            Return "No banked records found between " + startPeriod + " and " + endPeriod + " for " + GetLookupDataDes(bankNamesID) + " bank"

        ElseIf String.IsNullOrEmpty(bankNamesID) AndAlso Not String.IsNullOrEmpty(accountNo) AndAlso String.IsNullOrEmpty(loginID) Then
            Return "No banked records found between " + startPeriod + " and " + endPeriod + " for account No: " + accountNo

        ElseIf String.IsNullOrEmpty(bankNamesID) AndAlso String.IsNullOrEmpty(accountNo) AndAlso Not String.IsNullOrEmpty(loginID) Then
            Return "No banked records found between " + startPeriod + " and " + endPeriod + " for LoginID " + loginID

        ElseIf Not String.IsNullOrEmpty(bankNamesID) AndAlso Not String.IsNullOrEmpty(accountNo) AndAlso String.IsNullOrEmpty(loginID) Then
            Return "No banked records found between " + startPeriod + " and " + endPeriod + " for Account No: " + accountNo + " in" + GetLookupDataDes(bankNamesID) + " bank"

        ElseIf String.IsNullOrEmpty(bankNamesID) AndAlso Not String.IsNullOrEmpty(accountNo) AndAlso Not String.IsNullOrEmpty(loginID) Then
            Return "No banked records found between " + startPeriod + " and " + endPeriod + " for Account No: " + accountNo + " in" + GetLookupDataDes(bankNamesID) + " bank"

        ElseIf Not String.IsNullOrEmpty(bankNamesID) AndAlso String.IsNullOrEmpty(accountNo) AndAlso Not String.IsNullOrEmpty(loginID) Then
            Return "No banked records found between " + startPeriod + " and " + endPeriod + " for Login ID: " + loginID + " and Account No:" + accountNo + " bank"



        Else
            Return "No banked records found between " + startPeriod + " and " + endPeriod + " for Account No: " + accountNo + " in" + GetLookupDataDes(bankNamesID) + " for Login ID" + loginID
        End If

    End Function

    Private Sub LoadBankingRegister(ByVal bankNameID As String, ByVal accountNo As String, ByVal loginID As String, ByVal startDateTime As Date, ByVal endDateTime As Date)

        Dim bankingRegister As DataTable

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from banking records 
            bankingRegister = GetPeriodicBankingRegister(bankNameID, accountNo, loginID, startDateTime, endDateTime).Tables("BankingRegister")
            Dim rows As Integer = bankingRegister.Rows.Count()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBankingRegister, bankingRegister)
            FormatGridRow(Me.dgvBankingRegister)


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If rows < 1 Then
                DisplayMessage(GetMessage(bankNameID, accountNo, loginID, startDateTime, endDateTime))

            End If

            fbnExport.Enabled = rows > 0
            btnPrintPreview.Enabled = rows > 0
            btnPrint.Enabled = rows > 0
            lblRecordsNo.Text = "Returned Banked Record(s): " + rows.ToString


            Me.CalculateTotal()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub CalculateTotal()
        Try
            Cursor = Cursors.WaitCursor
            Dim oBankAccounts As New BankAccounts()

            Dim amountBanked As Decimal
            Dim currency As String
            Dim accountNo As String = StringValueMayBeEnteredIn(cboAccountNo)

            Dim bankAccounts As DataTable

            If Not String.IsNullOrEmpty(accountNo) Then

                amountBanked = CalculateGridAmount(Me.dgvBankingRegister, Me.colAmoutBanked)
                bankAccounts = oBankAccounts.GetBankAccounts(accountNo).Tables("BankAccounts")
                If bankAccounts.Rows.Count() < 1 Then Return
                currency = bankAccounts.Rows(0).Item("Currency").ToString()

            Else


                amountBanked = CalculateGridAmount(Me.dgvBankingRegister, Me.colBankedInShillings)
                currency = "Shillings"

            End If

            stbTotalAmount.Text = FormatNumber(amountBanked, AppData.DecimalPlaces)

            If amountBanked < 1 Then Return
            stbAmountWords.Text = NumberToWords(amountBanked) + " " + currency.ToUpper
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub fbnLoad_Click(sender As Object, e As EventArgs) Handles fbnLoad.Click
        Dim bankID As String = StringValueMayBeEnteredIn(cboBankNamesID)
        Dim accountNo As String = StringValueMayBeEnteredIn(cboAccountNo)
        Dim loginID As String = StringMayBeEnteredIn(Me.cboLoginID)
        Dim startDate As Date = DateTimeEnteredIn(dtpStartDateTime)
        Dim endDate As Date = DateTimeEnteredIn(dtpEndDateTime)

        LoadBankingRegister(bankID, accountNo, loginID, startDate, endDate)
        LoadBankingLogins(startDate, endDate)
    End Sub

    Private Sub fbnRefresh_Click(sender As Object, e As EventArgs) Handles fbnRefresh.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpStartDateTime.Value = Today
            Me.dtpEndDateTime.Value = Now
            ''''''''''''''''''''''''''''''''''''''''''''
            Me.fbnLoad.PerformClick()
            ''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnExport_Click(sender As Object, e As EventArgs) Handles fbnExport.Click
        ExportToExcel(Me.dgvBankingRegister, Me.Text)
    End Sub

    Private Sub LoadBankingLogins(ByVal startDateTime As Date, ByVal endDateTime As Date)

        Dim oBankingRegister As New SyncSoft.SQLDb.BankingRegister()


        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboLoginID.Items.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim bankingRegister As DataTable = oBankingRegister.GetBankingLogins(startDateTime, endDateTime).Tables("BankingRegister")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboLoginID, bankingRegister, "LoginID")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboBankNamesID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBankNamesID.SelectedIndexChanged
        LoadAccounts()
    End Sub

#Region "Print"

    Private Sub PrintBankingRegister()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvBankingRegister.RowCount < 1 Then
                Throw New ArgumentException("Must set at least one entry one item!")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetBankingRegisterPrintData()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docBankingRegister
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docBankingRegister.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docBankingRegister_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docBankingRegister.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Banking Register"

            Dim startDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpStartDateTime))
            Dim endDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpEndDateTime))
            Dim generalNotes As String = StringMayBeEnteredIn(cboBankNamesID)
            Dim loginID As String = StringMayBeEnteredIn(cboLoginID)
            Dim bank As String = StringMayBeEnteredIn(cboBankNamesID)
            Dim totalbanked As String = FormatNumber(DecimalMayBeEnteredIn(stbTotalAmount), AppData.DecimalPlaces)
            Dim totalBankedInWords As String = StringMayBeEnteredIn(stbAmountWords)

            If Not String.IsNullOrEmpty(loginID) Then
                title += " by Login ID: " + loginID
            End If


            If Not String.IsNullOrEmpty(bank) Then
                title += " at " + bank + " Bank"
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

                    .DrawString("Start Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(startDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("End Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(endDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Total Banked: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(totalbanked, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Amount In Words: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(totalBankedInWords, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
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

                If bankingRegisterParagraph Is Nothing Then Return

                Do While bankingRegisterParagraph.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(bankingRegisterParagraph(1), PrintParagraps)
                    bankingRegisterParagraph.Remove(1)

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
                        bankingRegisterParagraph.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (bankingRegisterParagraph.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetBankingRegisterPrintData()

        Dim padItemNo As Integer = 3
        Dim padCollectionStartDate As Integer = 15
        Dim padCollectionEndDate As Integer = 15
        Dim padBankingDate As Integer = 13
        Dim padAmountCollected As Integer = 15
        Dim padAmountBanked As Integer = 15
        Dim padCurrency As Integer = 13
        Dim padBankName As Integer = 12
        Dim AccountNo As Integer = 12


        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        bankingRegisterParagraph = New Collection()

        Try


            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append("No".PadRight(padItemNo))
            tableHeader.Append("Colln Start".PadRight(padCollectionStartDate))
            tableHeader.Append("Colln End".PadRight(padCollectionEndDate))
            tableHeader.Append("Banking Date".PadRight(padBankingDate))
            tableHeader.Append("Collected".PadRight(padAmountCollected))
            tableHeader.Append("Banked".PadRight(padAmountBanked))
            tableHeader.Append("Currency".PadRight(padAmountBanked))
            tableHeader.Append("Bank".PadRight(padBankName))
            tableHeader.Append("Account No".PadRight(AccountNo))

            tableHeader.Append(ControlChars.NewLine)
            bankingRegisterParagraph.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim itemCount As Integer = 0

            For rowNo As Integer = 0 To Me.dgvBankingRegister.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvBankingRegister.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim collectionStartDate As String = StringMayBeEnteredIn(cells, Me.colColectionDate)
                Dim collectionEndDate As String = StringMayBeEnteredIn(cells, Me.colCollectionEndDate)
                Dim bankingDate As String = StringMayBeEnteredIn(cells, Me.colBankingDate)
                Dim collected As String = FormatNumber(DecimalMayBeEnteredIn(cells, Me.colAmountCollected), AppData.DecimalPlaces)
                Dim banked As String = FormatNumber(DecimalMayBeEnteredIn(cells, Me.colAmoutBanked), AppData.DecimalPlaces)
                Dim currency As String = StringMayBeEnteredIn(cells, Me.colCurrency)
                Dim bank As String = StringMayBeEnteredIn(cells, Me.colBankName)
                Dim accNo As String = StringMayBeEnteredIn(cells, Me.colAccountNo)



                tableData.Append(itemNo.PadRight(padItemNo))
                tableData.Append(collectionStartDate.PadRight(padCollectionStartDate))
                tableData.Append(collectionEndDate.PadRight(padCollectionEndDate))
                tableData.Append(bankingDate.PadRight(padBankingDate))
                tableData.Append(collected.PadRight(padAmountCollected))
                tableData.Append(banked.PadRight(padAmountBanked))
                tableData.Append(currency.PadRight(padCurrency))

                tableData.Append(bank.PadRight(padBankName))
                tableData.Append(accNo.PadRight(AccountNo))


                tableData.Append(ControlChars.NewLine)

            Next

            bankingRegisterParagraph.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Received By:      " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:         " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            bankingRegisterParagraph.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            checkedSignData.Append(ControlChars.NewLine)

            checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
            checkedSignData.Append(GetSpaces(4))
            checkedSignData.Append("Date:         " + GetCharacters("."c, 20))
            checkedSignData.Append(ControlChars.NewLine)
            bankingRegisterParagraph.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            bankingRegisterParagraph.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnPrintPreview_Click(sender As Object, e As EventArgs) Handles btnPrintPreview.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            ' Make a PrintDocument and attach it to the PrintPreview dialog.
            Dim dlgPrintPreview As New PrintPreviewDialog()

            Me.SetBankingRegisterPrintData()

            With dlgPrintPreview
                .Document = docBankingRegister
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

            Me.PrintBankingRegister()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub



    Private Sub cboAccountNo_Leave(sender As Object, e As EventArgs) Handles cboAccountNo.Leave

        stbAccountNo.Clear()
        stbAccountNo.Text = StringValueMayBeEnteredIn(cboAccountNo)

    End Sub

#End Region

End Class