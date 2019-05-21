Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports SyncSoft.SQLDb
Imports SyncSoft.Common.Structures
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports System.Drawing.Printing
Imports System.Collections.Generic


Public Class frmPatientRecord

#Region "Fields"

    ' The paragraphs.
    Private orderParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)

    Private padItemNo As Integer = 4
    Private padItemName As Integer = 20
    Private padQuantity As Integer = 15
    Private padUnitMeasure As Integer = 10
    Private padRate As Integer = 12

    Private padAmount As Integer = 15
    Private padTotalAmount As Integer = 58

    Private itemCount As Integer = 0
    Private WithEvents docPurchaseOrders As New PrintDocument()

#End Region



    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub ClearControls()

        Me.stbFullName.Clear()
        Me.stbAge.Clear()
        Me.lblAgeString.Text = String.Empty
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbPhone.Clear()
        Me.stbLastVisitDate.Clear()
        Me.stbTotalVisits.Clear()
        Me.spbPhoto.Image = Nothing
        Me.dgvOPDVisits.Rows.Clear()

    End Sub

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Patients", Me.stbPatientNo)
            fQuickSearch.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            If Not String.IsNullOrEmpty(patientNo) Then
                Me.ShowPatientDetails(patientNo)
                Me.ShowGetOPDVisits(patientNo)
                Me.ShowGetIPDVisits(patientNo)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub ShowPatientDetails(ByVal patientNo As String)

        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            Dim patients As DataTable = oPatients.GetPatients(patientNo).Tables("Patients")
            Dim row As DataRow = patients.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Dim birthDate As Date = DateMayBeEnteredIn(row, "BirthDate")
            Me.lblAgeString.Text = GetAgeString(birthDate, True)
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbPhone.Text = StringMayBeEnteredIn(row, "Phone")
            Me.stbLastVisitDate.Text = FormatDate(DateMayBeEnteredIn(row, "LastVisitDate"))
            Me.stbTotalVisits.Text = StringEnteredIn(row, "TotalVisits")
            Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")




            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub stbPatientNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbPatientNo.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub stbPatientNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbPatientNo.Leave
        Try

            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            ErrProvider.Clear()
            If String.IsNullOrEmpty(patientNo) Then Return
            Me.ShowPatientDetails(patientNo)
            Me.ShowGetOPDVisits(patientNo)
            Me.ShowGetIPDVisits(patientNo)
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub frmPatientRecord_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.ClearControls()
    End Sub

    Private Sub ShowGetOPDVisits(ByVal patientNo As String)

        Dim oGetOPDVisits As New SyncSoft.SQLDb.Items

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Items
            Dim GetOPDVisits As DataTable = oGetOPDVisits.GetPatientsRecordOPD(patientNo).Tables("Items")


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvOPDVisits, GetOPDVisits)

            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowGetIPDVisits(ByVal patientNo As String)

        Dim oGetIPDVisits As New SyncSoft.SQLDb.Items

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Items
            Dim GetIPDVisits As DataTable = oGetIPDVisits.GetPatientsRecordIPD(patientNo).Tables("ExtraBillItems")


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvIPDVisits, GetIPDVisits)

            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region "Print Patient Records"

    Private Function OPDVisits() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvOPDVisits.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvOPDVisits.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemName As String = cells.Item(Me.colItemDetails.Name).Value.ToString()
                Dim datetime As String = cells.Item(Me.colDateTime.Name).Value.ToString()
                Dim quantity As String = cells.Item(Me.ColQuantity.Name).Value.ToString()
                Dim amount As String = cells.Item(Me.ColTotalAmount.Name).Value.ToString()

                tableData.Append(itemNo.PadRight(padItemNo))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                If wrappeditemName.Count > 1 Then
                    For pos As Integer = 0 To wrappeditemName.Count - 1
                        tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                        If Not pos = wrappeditemName.Count - 1 Then
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padItemNo))
                        Else
                            tableData.Append(datetime.PadLeft(padQuantity))
                            If quantity.Length > 10 Then
                                tableData.Append(GetSpaces(1) + quantity.Substring(0, 10).PadRight(padQuantity))
                            Else : tableData.Append(GetSpaces(1) + quantity.PadRight(padQuantity))
                            End If

                            tableData.Append(amount.PadLeft(padAmount))
                        End If
                    Next

                Else
                    tableData.Append(FixDataLength(itemName, padItemName))
                    tableData.Append(datetime.PadLeft(padQuantity))
                    If quantity.Length > 10 Then
                        tableData.Append(GetSpaces(1) + quantity.Substring(0, 10).PadRight(padQuantity))
                    Else : tableData.Append(GetSpaces(1) + quantity.PadRight(padUnitMeasure))
                    End If

                    tableData.Append(amount.PadLeft(padAmount))
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                tableData.Append(ControlChars.NewLine)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    'Private Function OtherItemsData() As String

    '    Try

    '        Dim tableData As New System.Text.StringBuilder(String.Empty)

    '        For rowNo As Integer = 0 To Me.dgvOtherItems.RowCount - 2

    '            Dim cells As DataGridViewCellCollection = Me.dgvOtherItems.Rows(rowNo).Cells

    '            itemCount += 1

    '            Dim itemNo As String = (itemCount).ToString()
    '            Dim itemName As String = cells.Item(Me.ColOtherItemsItemName.Name).Value.ToString()
    '            Dim quantity As String = cells.Item(Me.colOtherItemsTotalUnits.Name).Value.ToString()
    '            Dim unitMeasure As String = cells.Item(Me.ColOtherItemsUnitMeasure.Name).Value.ToString()
    '            Dim rate As String = cells.Item(Me.ColOtherItemsRate.Name).Value.ToString()
    '            Dim amount As String = cells.Item(Me.ColOtherItemsAmount.Name).Value.ToString()

    '            tableData.Append(itemNo.PadRight(padItemNo))

    '            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
    '            If wrappeditemName.Count > 1 Then
    '                For pos As Integer = 0 To wrappeditemName.Count - 1
    '                    tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
    '                    If Not pos = wrappeditemName.Count - 1 Then
    '                        tableData.Append(ControlChars.NewLine)
    '                        tableData.Append(GetSpaces(padItemNo))
    '                    Else
    '                        tableData.Append(quantity.PadLeft(padQuantity))
    '                        If unitMeasure.Length > 10 Then
    '                            tableData.Append(GetSpaces(1) + unitMeasure.Substring(0, 10).PadRight(padUnitMeasure))
    '                        Else : tableData.Append(GetSpaces(1) + unitMeasure.PadRight(padUnitMeasure))
    '                        End If
    '                        tableData.Append(rate.PadLeft(padRate))
    '                        tableData.Append(amount.PadLeft(padAmount))
    '                    End If
    '                Next

    '            Else
    '                tableData.Append(FixDataLength(itemName, padItemName))
    '                tableData.Append(quantity.PadLeft(padQuantity))
    '                If unitMeasure.Length > 10 Then
    '                    tableData.Append(GetSpaces(1) + unitMeasure.Substring(0, 10).PadRight(padUnitMeasure))
    '                Else : tableData.Append(GetSpaces(1) + unitMeasure.PadRight(padUnitMeasure))
    '                End If
    '                tableData.Append(rate.PadLeft(padRate))
    '                tableData.Append(amount.PadLeft(padAmount))

    '            End If
    '            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            tableData.Append(ControlChars.NewLine)
    '            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        Next

    '        Return tableData.ToString()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function



#End Region

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintPurchaseOrders()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
    Private Sub PrintPurchaseOrders()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If Me.dgvDrugs.RowCount < 1 OrElse Me.dgvConsumables.RowCount < 1 OrElse Me.dgvOtherItems.RowCount < 1 Then
            '    Throw New ArgumentException("Must set at least one entry on Order details!")
            'End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetPurchaseOrdersPrintData()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docPurchaseOrders
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docPurchaseOrders.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docPurchaseOrders_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docPurchaseOrders.PrintPage

        Try
            Dim m_PagesPrinted As Integer
            m_PagesPrinted = 0
            'Const gutter As Integer = 100
            '
            Dim string_format As New StringFormat
            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Patient's History".ToUpper()

            Dim orderNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim orderDate As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim documentNo As String = StringMayBeEnteredIn(Me.stbAge)
            Dim shipAddress As String = StringMayBeEnteredIn(Me.stbLastVisitDate)
            Dim supplierName As String = StringMayBeEnteredIn(Me.stbAge)

            ' Dim vendor As String = supplierName + ControlChars.NewLine + supplierAddress

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 11 * widthTopFirst
                Dim widthTopThird As Single = 20 * widthTopFirst
                Dim widthTopFourth As Single = 29 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    Dim oProductOwner As ProductOwner = GetProductOwnerInfo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Order No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(orderNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Order Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(orderDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Document (Ref.) No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(documentNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += 2 * lineHeight

                    .DrawString("Ship To: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(shipAddress, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    Dim addressLines As Integer = shipAddress.Split(CChar(ControlChars.NewLine)).Length
                    yPos += addressLines * lineHeight
                    yPos += lineHeight

                    Dim vendorLines As Integer = shipAddress.Split(CChar(ControlChars.NewLine)).Length
                    yPos += vendorLines * lineHeight
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

                If orderParagraphs Is Nothing Then Return

                Do While orderParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(orderParagraphs(1), PrintParagraps)
                    orderParagraphs.Remove(1)

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
                        orderParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (orderParagraphs.Count > 0)


                Dim x As Integer = (e.MarginBounds.Right + e.PageBounds.Right) \ 2
                string_format.Alignment = StringAlignment.Far

                e.Graphics.DrawString(m_PagesPrinted.ToString, bodyNormalFont, Brushes.Black, x,
                (e.MarginBounds.Top + e.PageBounds.Top) \ 2, string_format)

                'If m_PagesPrinted = 0 Then
                '    ' The next page is the first.
                '    ' Increase the left margin.
                '    e.PageSettings.Margins.Left += gutter
                'ElseIf (m_PagesPrinted Mod 2) = 0 Then
                '    ' The next page will be odd.
                '    ' Shift the margins right.
                '    e.PageSettings.Margins.Left += gutter
                '    e.PageSettings.Margins.Right -= gutter
                'Else
                '    ' The next page will be even.
                '    ' Shift the margins left.
                '    e.PageSettings.Margins.Left -= gutter
                '    e.PageSettings.Margins.Right += gutter
                'End If

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetPurchaseOrdersPrintData()

        Dim footerFont As New Font(printFontName, 9)

        itemCount = 0
        pageNo = 0
        orderParagraphs = New Collection()

        Try

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Item Name: ".PadRight(padItemName))
            tableHeader.Append("Date: ".PadLeft(padQuantity - 6))
            tableHeader.Append("Quantity: ".PadLeft(padUnitMeasure + 8))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            orderParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            orderParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.OPDVisits().ToString()))
            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'orderParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ConsumablesData().ToString()))
            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'orderParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.OtherItemsData().ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim totalAmountData As New System.Text.StringBuilder(String.Empty)
            Dim drugAmount As Decimal = CalculateGridAmount(Me.dgvOPDVisits, Me.ColTotalAmount)
            'Dim consumableAmount As Decimal = CalculateGridAmount(Me.dgvConsumables, Me.colConsumableAmount)
            'Dim otherItemsAmount As Decimal = CalculateGridAmount(Me.dgvOtherItems, Me.ColOtherItemsAmount)
            Dim totalAmount As Decimal = drugAmount
            ' + consumableAmount + otherItemsAmount

            totalAmountData.Append(ControlChars.NewLine)
            totalAmountData.Append("Total Amount: ")
            totalAmountData.Append(FormatNumber(totalAmount, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            totalAmountData.Append(ControlChars.NewLine)
            orderParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmountData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim totalAmountWords As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = NumberToWords(totalAmount)
            totalAmountWords.Append("(" + amountWords.Trim() + " ONLY)")
            totalAmountWords.Append(ControlChars.NewLine)
            orderParagraphs.Add(New PrintParagraps(footerFont, totalAmountWords.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Prepared By:        " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:         " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            orderParagraphs.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            orderParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub



End Class