Option Strict On
Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Imports System.Collections.Generic
Imports System.Drawing.Printing



Public Class frmPatientAccountStatement

#Region "Field"

    Private billCustomers As DataTable
    Private WithEvents docPatientAccountStatement As New PrintDocument()

    ' The paragraphs.
    Private transferParagraphs As Collection
    Private footertransferParagraphs As Collection
    Private ftransferParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private m_PagesPrinted As Integer
#End Region

    Private Sub ClearControls()
        Me.stbAccountName.Clear()
        Me.nbxAccountBalance.Clear()
        Me.stbAccountName.Clear()
        Me.dgvPatientsAccount.Rows.Clear()
        
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

    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

#Region " Patient's Account Statement "

    Private Sub PrintAccountStatement()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPatientsAccount.RowCount < 1 Then
                Throw New ArgumentException("Must have at least one entry on Patient's Account Statement!")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetPatientAccountStatementPrintData()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docPatientAccountStatement
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docPatientAccountStatement.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docPatientAccountStatement_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docPatientAccountStatement.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Account Statement".ToUpper()
            Dim accountName As String = StringMayBeEnteredIn(Me.stbAccountName)
            Dim accountNo As String = StringMayBeEnteredIn(Me.cboAccountNo)
            Dim accountCategory As String = StringMayBeEnteredIn(Me.cboBillModesID)
            Dim startDateTime As String = FormatDate(DateMayBeEnteredIn(Me.dtpStartDateTime))
            Dim endDateTime As String = FormatDate(DateMayBeEnteredIn(Me.dtpEndDateTime))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width

                Dim widthTopSecond As Single = 10 * widthTopFirst
                Dim widthTopThird As Single = 17 * widthTopFirst
                Dim widthTopFourth As Single = 30 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    Dim oProductOwner As ProductOwner = GetProductOwnerInfo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Account Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(accountName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Account No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(accountNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Account Type: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(accountCategory, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("From Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(startDateTime, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("To Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird + 80, yPos)
                    .DrawString(endDateTime, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += 3 * lineHeight

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

                If transferParagraphs Is Nothing Then Return

                Do While transferParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(transferParagraphs(1), PrintParagraps)
                    transferParagraphs.Remove(1)

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
                        transferParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (transferParagraphs.Count > 0)

                If ftransferParagraphs Is Nothing Then Return

                Do While ftransferParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(ftransferParagraphs(1), PrintParagraps)
                    ftransferParagraphs.Remove(1)

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
                        ftransferParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop
                e.HasMorePages = (ftransferParagraphs.Count > 0)


                If footertransferParagraphs Is Nothing Then Return

                Do While footertransferParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(footertransferParagraphs(1), PrintParagraps)
                    footertransferParagraphs.Remove(1)

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
                        footertransferParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop
                e.HasMorePages = (footertransferParagraphs.Count > 0)
            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetPatientAccountStatementPrintData()
        Dim padTotalAmount As Integer = 1
        Dim padTransNo As Integer = 10
        Dim padAmount As Integer = 10
        Dim padBalance As Integer = 10
        Dim padDate As Integer = 12
        Dim padAction As Integer = 6
        Dim padDescription As Integer = 20

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        transferParagraphs = New Collection()
        ftransferParagraphs = New Collection()
        footertransferParagraphs = New Collection()

        Try


            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            transferParagraphs.Add(New PrintParagraps(bodyNormalFont, tableHeader.ToString()))
            tableHeader.Append("Date: ".PadRight(padDate))
            tableHeader.Append("Description: ".PadRight(padDescription))
            tableHeader.Append("Tran No: ".PadRight(padTransNo))
            tableHeader.Append("Bill: ".PadRight(padAction))
            tableHeader.Append(GetSpaces(5) + "Deposit: ".PadRight(padAmount))
            tableHeader.Append(GetSpaces(1) + "Balance: ".PadRight(padBalance))


            '    tableHeader.Append("Time: ".PadRight(padDate))
            tableHeader.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvPatientsAccount.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvPatientsAccount.Rows(rowNo).Cells
                Dim transNo As String = StringMayBeEnteredIn(cells, Me.colTransNo)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.ColBill)
                Dim deposit As String = StringMayBeEnteredIn(cells, Me.colDeposit)
                Dim balance As String = StringMayBeEnteredIn(cells, Me.colBalance)
                Dim description As String = StringMayBeEnteredIn(cells, Me.ColName)
                'Dim accountAction As String = StringMayBeEnteredIn(cells, Me.ColAccountActionID)
                Dim recordDate As String = StringMayBeEnteredIn(cells, Me.ColRecordDateTime)

                tableData.Append(recordDate.PadRight(padDate))

                Dim wrappeddescription As List(Of String) = WrapText(description, padDescription)
                If wrappeddescription.Count > 1 Then

                    For pos As Integer = 0 To wrappeddescription.Count - 1
                        tableData.Append(FixDataLength(wrappeddescription(pos).Trim(), padDescription))
                        If Not pos = wrappeddescription.Count - 1 Then
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padDate))
                        Else
                            tableData.Append(transNo.PadRight(padTransNo))
                            '  tableData.Append(accountAction.PadRight(padAction))
                            tableData.Append(GetSpaces(1) + amount.PadRight(padAmount))
                            tableData.Append(GetSpaces(1) + deposit.PadRight(padBalance))
                            ' tableData.Append(ControlChars.NewLine)
                        End If

                    Next

                Else

                    tableData.Append(FixDataLength(description, padDescription))
                    tableData.Append(transNo.PadRight(padTransNo))
                    ' tableData.Append(accountAction.PadRight(padAction))
                    tableData.Append(GetSpaces(1) + amount.PadRight(padAmount))
                    tableData.Append(GetSpaces(1) + deposit.PadRight(padBalance))
                    tableData.Append(GetSpaces(1) + balance.PadRight(padBalance))
                End If
                tableData.Append(ControlChars.NewLine)

            Next

            transferParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
            Dim accountBalances As Decimal = DecimalMayBeEnteredIn(nbxAccountBalance, True)
            Dim accountOpeningBalances As Decimal = DecimalMayBeEnteredIn(nbxAccountOpeningBalance, True)
            Dim accountBills As String = StringMayBeEnteredIn(Me.stbBill)
            Dim accountDeposit As String = StringMayBeEnteredIn(Me.stbTotalDeposit)
            Dim accountBalance As New System.Text.StringBuilder(String.Empty)
            Dim accountBill As New System.Text.StringBuilder(String.Empty)
            Dim accountDeposits As New System.Text.StringBuilder(String.Empty)
            Dim accountbalanceBill As New System.Text.StringBuilder(String.Empty)

            accountbalanceBill.Append(ControlChars.NewLine)
            accountbalanceBill.Append("Opening Balance: ")
            accountbalanceBill.Append(FormatNumber(accountOpeningBalances, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            accountbalanceBill.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(bodyBoldFont, accountbalanceBill.ToString()))

            accountBill.Append(ControlChars.NewLine)
            accountBill.Append("Total Bill: ")
            accountBill.Append(accountBills)
            accountBill.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(bodyBoldFont, accountBill.ToString()))

            accountDeposits.Append(ControlChars.NewLine)
            accountDeposits.Append("Total Deposit: ")
            accountDeposits.Append(accountDeposit)
            accountDeposits.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(bodyBoldFont, accountDeposits.ToString()))

            accountBalance.Append(ControlChars.NewLine)
            accountBalance.Append("Current Account Balance: ")
            accountBalance.Append(FormatNumber(accountBalances, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            accountBalance.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(bodyBoldFont, accountBalance.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            accountBalance.Append(ControlChars.NewLine)
            accountBalance.Append(ControlChars.NewLine)
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Received By:   " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:  " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            checkedSignData.Append(ControlChars.NewLine)

            checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
            checkedSignData.Append(GetSpaces(4))
            checkedSignData.Append("Date:  " + GetCharacters("."c, 20))
            checkedSignData.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            accountBalance.Append(ControlChars.NewLine)
            accountBalance.Append(ControlChars.NewLine)

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            footertransferParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region


    Private Sub fbnPrint_Click(sender As System.Object, e As System.EventArgs) Handles fbnPrint.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintAccountStatement()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub fbnExportTo_Click(sender As System.Object, e As System.EventArgs) Handles fbnExportTo.Click
        Dim fStatus As New SyncSoft.Common.Win.Forms.Status()

        Try

            Me.Cursor = Cursors.WaitCursor()

            Dim startDate As Date = DateEnteredIn(Me.dtpStartDateTime, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDateTime, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            Dim _objectCaption As String = Me.tbcAccountStatement.SelectedTab.Text

            Dim documentTitle As String = _objectCaption + " for the period between " _
                       + FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"

            fStatus.Show("Exporting " + _objectCaption + " to Excel...", FormStartPosition.CenterScreen)

            Select Case Me.tbcAccountStatement.SelectedTab.Name

                Case Me.tpgAccountStatement.Name
                    ExportToExcel(Me.dgvPatientsAccount, _objectCaption, documentTitle)

            End Select

        Catch ex As Exception
            fStatus.Close()
            ErrorMessage(ex)

        Finally
            fStatus.Close()
            Me.Cursor = Cursors.Default

        End Try
    End Sub



    Private Sub cboBillModesID_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboBillModesID.SelectedIndexChanged
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oBillModesID As New LookupDataID.BillModesID()

            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Account Category!")
            Me.btnLoad.Visible = billModesID.ToUpper().Equals(oBillModesID.Cash().ToUpper())
            If String.IsNullOrEmpty(billModesID) Then Return

            Me.LoadAccountClients(billModesID)
           
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub frmPatientAccountStatement_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try

            Me.Cursor = Cursors.WaitCursor
            LoadLookupDataCombo(Me.cboBillModesID, LookupObjects.BillModes, False)
            Me.dtpStartDateTime.Value = Today.AddDays(-1)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cboAccountNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles cboAccountNo.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub cboAccountNo_Leave(sender As System.Object, e As System.EventArgs) Handles cboAccountNo.Leave
        Try
            Me.Loaddetails()
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Loaddetails()
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
        Dim accountBalance, accountOpeningBalance As Decimal

        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()
        Dim startDateTime As Date = DateTimeEnteredIn(Me.dtpStartDateTime, "Start Record Date & Time")
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbAccountName.Clear()
            Me.nbxAccountBalance.Clear()
            Me.stbTotalDeposit.Clear()
            Me.stbBill.Clear()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oPatients.GetPatients(accountNo).Tables("Patients").Rows(0)

                    Me.cboAccountNo.Text = FormatText(accountNo, "Patients", "PatientNo")
                    accountName = StringMayBeEnteredIn(row, "FullName")
                    accountBalance = GetAccountBalance(oBillModesID.Cash, accountNo)
                    accountOpeningBalance = GetAccountOpeningBalance(accountNo, oBillModesID.Cash, startDateTime)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oBillCustomers.GetBillCustomers(accountNo).Tables("BillCustomers").Rows(0)

                    Me.cboAccountNo.Text = FormatText(accountNo, "BillCustomers", "AccountNo").ToUpper()
                    accountName = StringMayBeEnteredIn(row, "BillCustomerName")
                    accountBalance = GetAccountBalance(oBillModesID.Account, accountNo)
                    accountOpeningBalance = GetAccountOpeningBalance(accountNo, oBillModesID.Account, startDateTime)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oInsurances.GetInsurances(accountNo).Tables("Insurances").Rows(0)

                    Me.cboAccountNo.Text = FormatText(accountNo, "Insurances", "InsuranceNo")
                    accountName = StringMayBeEnteredIn(row, "InsuranceName")
                    accountBalance = GetAccountBalance(oBillModesID.Insurance, accountNo)
                    accountOpeningBalance = GetAccountOpeningBalance(accountNo, oBillModesID.Insurance, startDateTime)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbAccountName.Text = accountName
            Me.nbxAccountBalance.Value = FormatNumber(accountBalance, AppData.DecimalPlaces)
            Me.nbxAccountOpeningBalance.Value = FormatNumber(accountOpeningBalance, AppData.DecimalPlaces)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnLoadStatement_Click(sender As System.Object, e As System.EventArgs) Handles fbnLoadStatement.Click

        Dim oAccounts As New SyncSoft.SQLDb.Accounts
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oBillModesID As New LookupDataID.BillModesID()
            Dim AccountNo As String = RevertText(StringMayBeEnteredIn(Me.cboAccountNo))
            Dim startDateTime As Date = DateTimeEnteredIn(Me.dtpStartDateTime, "Start Record Date & Time")
            Dim endDateTime As Date = DateTimeEnteredIn(Me.dtpEndDateTime, "End Record Date & Time")
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Account Category!")

            If endDateTime < startDateTime Then Throw New ArgumentException("End Date can't be before Start Date!")
            If String.IsNullOrEmpty(billModesID) Then Return
            Dim accounts As DataTable = oAccounts.GetPeriodicAccountTransactionsByAccountBillNo(AccountNo, startDateTime, endDateTime).Tables("Accounts")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Loaddetails()
            LoadGridData(Me.dgvPatientsAccount, accounts)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If accounts IsNot Nothing AndAlso accounts.Rows.Count > 0 Then
              
                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                
                Dim totalBill As Decimal = CalculateGridAmount(dgvPatientsAccount, Me.ColBill)
                Dim totalDeposit As Decimal = CalculateGridAmount(dgvPatientsAccount, Me.colDeposit)
                Me.stbBill.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                Me.stbTotalDeposit.Text = FormatNumber(totalDeposit, AppData.DecimalPlaces)

            Else
                Me.stbBill.Clear()
                Me.stbTotalDeposit.Clear()

            End If
            Dim message As String = "No " + Me.Text + " record(s) found for period between " +
                FormatDate(startDateTime) + " and " + FormatDate(endDateTime) + "!"

            If dgvPatientsAccount.Rows.Count < 1 Then DisplayMessage(message)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

   
  
    Private Sub btnPrintPreview_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintPreview.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            m_PagesPrinted = 0


            ' Make a PrintDocument and attach it to the PrintPreview dialog.
            Dim dlgPrintPreview As New PrintPreviewDialog()


            Me.SetPatientAccountStatementPrintData()

            With dlgPrintPreview
                .Document = docPatientAccountStatement
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

   
   
    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Patients", Me.cboAccountNo)
            fQuickSearch.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.cboAccountNo))
            If Not String.IsNullOrEmpty(patientNo) Then Me.Loaddetails()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

  
End Class
