
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

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Collections.Generic
Imports System.Drawing.Printing
Imports SyncSoft.SQLDb.Lookup

Public Class frmInventoryAcknowledges
    Private oVariousOptions As New VariousOptions()
#Region " Fields "

    Private fromLocationID As String = String.Empty
    Private toLocationID As String = String.Empty
    Private transferReasons As String = String.Empty
    Private ItemCategoryID As String = String.Empty
    Private orderNo As String = String.Empty
    Private WithEvents docInventoryAcknowledges As New PrintDocument()

    ' The paragraphs.
    Private transferParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private orderType As String
#End Region

#Region " Validations "

    Private Sub dtpReceivedDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpReceivedDate.Validating

        Dim errorMSG As String = "Received date can't be before Transfer date!"

        Try

            Dim transferDate As Date = DateMayBeEnteredIn(Me.stbTransferDate)
            Dim receivedDate As Date = DateMayBeEnteredIn(Me.dtpReceivedDate)

            If receivedDate = AppData.NullDateValue Then Return

            If receivedDate < transferDate Then
                ErrProvider.SetError(Me.dtpReceivedDate, errorMSG)
                Me.dtpReceivedDate.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpReceivedDate, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

    Private Sub frmInventoryAcknowledges_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim LocationID As String = StringValueMayBeEnteredIn(Me.cboFromLocationID)
            Me.GetAllPendingOrderDetails(LocationID)
            '''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub frmInventoryAcknowledges_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Cursor = Cursors.WaitCursor
            LoadLookupDataCombo(Me.cboFromLocationID, LookupObjects.Location, False)

            Dim LocationID As String = StringValueMayBeEnteredIn(Me.cboFromLocationID)
            '''''''''''''''''''''''''''''''''''
            Me.dtpReceivedDate.MaxDate = Today
            Me.dtpReceivedDate.Value = Today
            Me.dtpReceivedDate.Checked = True
            SetDefaultLocation()

            Me.GetAllPendingOrderDetails(LocationID)


            '''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmInventoryAcknowledges_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnLoadIssuedInventoryTransfers_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadIssuedInventoryTransfers.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim LocationID As String = StringValueMayBeEnteredIn(Me.cboFromLocationID)
            Dim fIssuedInventoryTransferDetails As New frmIssuedInventoryTransferDetails(Me.stbTransferNo, AlertItemCategory.Internal)
            fIssuedInventoryTransferDetails.ShowDialog(Me)



            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowInventoryTransfers()

            Me.GetAllPendingOrderDetails(LocationID)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            HideInventoryPacks()
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub HideInventoryPacks()
        Dim packControl As DataGridViewColumn() = {colPack, colPackSize, colTotalUnits}
        HideGridComponets(packControl, oVariousOptions.UseOfInventoryPackSizes)

    End Sub



    Private Sub stbTransferNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbTransferNo.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub stbTransferNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbTransferNo.Leave

        Try

            Me.ShowInventoryTransfers()

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbTransferDate.Clear()
        Me.stbFromLocation.Clear()
        Me.stbToLocation.Clear()

        fromLocationID = String.Empty
        toLocationID = String.Empty
        orderNo = String.Empty
        Me.dgvInventoryAcknowledges.Rows.Clear()
        Me.SetDefaultLocation()
    End Sub

    Private Sub EnableSetInventoryLocation()

        Dim oVariousOptions As New VariousOptions()

        Try

            Dim fromLocation As String = StringMayBeEnteredIn(Me.cboFromLocationID)
            If Not oVariousOptions.EnableSetInventoryLocation AndAlso Not String.IsNullOrEmpty(fromLocation) Then
                Me.cboFromLocationID.Enabled = False
            Else : Me.cboFromLocationID.Enabled = True
            End If

        Catch ex As Exception
            Me.cboFromLocationID.Enabled = True
        End Try

    End Sub

    Private Sub SetDefaultLocation()

        Try
            Me.Cursor = Cursors.WaitCursor
            Dim LocationID As String = StringValueMayBeEnteredIn(Me.cboFromLocationID)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboFromLocationID, LookupObjects.Location, True)
            If Not String.IsNullOrEmpty(InitOptions.Location) Then
                Me.cboFromLocationID.SelectedValue = GetLookupDataID(LookupObjects.Location, InitOptions.Location)
                Me.EnableSetInventoryLocation()
            End If


            Me.GetAllPendingOrderDetails(LocationID)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub


    Private Sub ShowInventoryTransfers()

        Dim oInventoryTransfers As New SyncSoft.SQLDb.InventoryTransfers()
        Dim oInventoryOrders As New SyncSoft.SQLDb.InventoryOrders()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            Dim transferNo As String = RevertText(StringMayBeEnteredIn(Me.stbTransferNo))
            If String.IsNullOrEmpty(transferNo) Then Return

            Dim inventoryTransfers As DataTable = oInventoryTransfers.GetInventoryTransfers(transferNo).Tables("InventoryTransfers")

            Dim row As DataRow = inventoryTransfers.Rows(0)
          
            Dim transferDate As Date = DateEnteredIn(row, "TransferDate")
            Me.stbTransferDate.Text = FormatDate(transferDate)
            fromLocationID = StringEnteredIn(row, "FromLocationID")
            orderNo = StringEnteredIn(row, "OrderNo")
            Me.stbFromLocation.Text = StringEnteredIn(row, "FromLocation")
            toLocationID = StringEnteredIn(row, "ToLocationID")
            Me.stbToLocation.Text = StringEnteredIn(row, "ToLocation")
            transferReasons = StringEnteredIn(row, "TransferReason")
            Me.stbTransferReason.Text = StringEnteredIn(row, "TransferReason")
            Me.orderType = StringEnteredIn(row, "OrderType")
            Me.sbtOrderType.Text = Me.orderType
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpReceivedDate.Value = transferDate
            Me.dtpReceivedDate.Checked = GetShortDate(transferDate) >= GetShortDate(Today)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadInventoryTransferDetails(transferNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function GetAllPendingOrderDetails(locationCode As String) As Integer

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oVariousOptions As New VariousOptions()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim records As Integer = oDrugs.GetAllPendingOrderDetails(locationCode)

            Me.lblPendingIventoryAcknowledgements.Text = "Pending Acknowledgements: " + records.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return records
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub LoadInventoryTransferDetails(ByVal transferNo As String)

        Dim oInventoryTransferDetails As New SyncSoft.SQLDb.InventoryTransferDetails()

        Try

            Me.dgvInventoryAcknowledges.Rows.Clear()

            ' Load InventoryTransferDetails

            Dim transferDetails As DataTable = oInventoryTransferDetails.GetInventoryTransferDetails(transferNo).Tables("InventoryTransferDetails")
            If transferDetails Is Nothing OrElse transferDetails.Rows.Count < 1 Then
                DisplayMessage("No issued inventory stock waiting to be received!")
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInventoryAcknowledges, transferDetails)

            For Each row As DataGridViewRow In Me.dgvInventoryAcknowledges.Rows
                If row.IsNewRow Then Exit For
                Me.dgvInventoryAcknowledges.Item(Me.colInclude.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub fbnSave_Click(sender As System.Object, e As System.EventArgs) Handles fbnSave.Click

        Dim message As String
        Dim records As Integer

        Dim oStockTypeID As New LookupDataID.StockTypeID()
        Dim oTransferReasonID As New LookupDataID.TransferReasonID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Dim lInventoryAcknowledges As New List(Of DBConnect)
        Dim lInventoryIssued As New List(Of DBConnect)
        Dim lInventoryReceived As New List(Of DBConnect)
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim LocationID As String = StringValueMayBeEnteredIn(Me.cboFromLocationID)

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim transferNo As String = RevertText(StringEnteredIn(Me.stbTransferNo, "Transfer No!"))
            Dim transferDate As Date = DateEnteredIn(Me.stbTransferDate, "Transfer Date!")
            Dim receivedDate As Date = DateEnteredIn(Me.dtpReceivedDate, "Received Date!")
            Dim transferReasonID As String = StringEnteredIn(Me.stbTransferReason)
            Dim transferReason As String = GetLookupDataDes(oTransferReasonID.Expensing)
            Me.VerifyInventoryAcknowledgesEntries()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvInventoryAcknowledges.RowCount - 1

                If CBool(Me.dgvInventoryAcknowledges.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvInventoryAcknowledges.Rows(rowNo).Cells

                    Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID)
                    Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode, "item!")
                    Dim totalUnits As Integer = IntegerEnteredIn(cells, Me.colTotalUnits, "Total Units!")
                    Dim batchNo As String = StringEnteredIn(cells, Me.colBatchNo, "Batch No!")
                    Dim expiryDate As Date = DateEnteredIn(cells, Me.colExpiryDate, "Expiry Date!")

                    Using oInventoryAcknowledges As New SyncSoft.SQLDb.InventoryAcknowledges()

                        With oInventoryAcknowledges

                            .TransferNo = transferNo
                            .ItemCategoryID = itemCategoryID
                            .ItemCode = itemCode
                            .ReceivedDate = receivedDate
                            .LoginID = CurrentUser.LoginID

                        End With

                        lInventoryAcknowledges.Add(oInventoryAcknowledges)

                    End Using

                    ''''''''''''''''Issued'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oInventoryIssued As New SyncSoft.SQLDb.Inventory()

                        With oInventoryIssued

                            .LocationID = fromLocationID
                            .ItemCategoryID = itemCategoryID
                            .ItemCode = itemCode
                            .TranDate = transferDate
                            .StockTypeID = oStockTypeID.Issued
                            .Quantity = totalUnits

                            If itemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then
                                .Details = "Drug(s) Issued to " + Me.stbToLocation.Text + " from " + Me.stbFromLocation.Text + " Via OrderNo " + orderNo
                            ElseIf itemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then
                                .Details = "Consumable(s) Issued to " + Me.stbToLocation.Text + " from " + Me.stbFromLocation.Text + " Via OrderNo " + orderNo
                            ElseIf itemCategoryID.ToUpper().Equals(oItemCategoryID.NonMedical.ToUpper()) Then
                                .Details = "Other Item(s) Issued to " + Me.stbToLocation.Text + " from " + Me.stbFromLocation.Text + " Via OrderNo " + orderNo
                            Else : .Details = String.Empty
                            End If

                            .EntryModeID = oEntryModeID.System
                            .LoginID = CurrentUser.LoginID
                            .BatchNo = batchNo
                            .ExpiryDate = expiryDate

                        End With

                        lInventoryIssued.Add(oInventoryIssued)

                    End Using

                    ''''''''''''Received '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not Me.stbTransferReason.Text = transferReason Then

                        Using oInventoryReceived As New SyncSoft.SQLDb.Inventory()

                            With oInventoryReceived

                                .LocationID = toLocationID
                                .ItemCategoryID = itemCategoryID
                                .ItemCode = itemCode
                                .TranDate = DateEnteredIn(Me.dtpReceivedDate, "Received Date!")
                                .StockTypeID = oStockTypeID.Received
                                '.TransferReason = Me.stbTransferReason.Text
                                .Quantity = totalUnits

                                If itemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then
                                    .Details = "Drug(s) Received from " + Me.stbFromLocation.Text + " to " + Me.stbToLocation.Text + " Via OrderNo " + orderNo
                                ElseIf itemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then
                                    .Details = "Consumable(s) Received from " + Me.stbFromLocation.Text + " to " + Me.stbToLocation.Text + " Via OrderNo " + orderNo
                                ElseIf itemCategoryID.ToUpper().Equals(oItemCategoryID.NonMedical.ToUpper()) Then
                                    .Details = "Other Items(s) Received from " + Me.stbFromLocation.Text + " to " + Me.stbToLocation.Text + " Via OrderNo " + orderNo

                                Else : .Details = String.Empty
                                End If


                                .EntryModeID = oEntryModeID.System
                                .LoginID = CurrentUser.LoginID
                                .BatchNo = batchNo
                                .ExpiryDate = expiryDate

                            End With

                            lInventoryReceived.Add(oInventoryReceived)

                        End Using

                    End If
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lInventoryAcknowledges, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lInventoryIssued, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lInventoryReceived, Action.Save))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            message = "You are about to perform an irreversible action that affects inventory stock. " +
                            ControlChars.NewLine + "Are you sure you want to save?"

            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            records = DoTransactions(transactions)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.chkPrintOnSaving.Checked Then
                message = "You have not checked Print Acknowledge On Saving. " + ControlChars.NewLine + "Would you want Acknowledge printed?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintInventoryAcknowledges()
            Else : Me.PrintInventoryAcknowledges()
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            DisplayMessage(records.ToString() + " record(s) affected!")
            Me.SetDefaultLocation()
            Me.GetAllPendingOrderDetails(LocationID)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim allSelected As Boolean = True

            For Each row As DataGridViewRow In Me.dgvInventoryAcknowledges.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvInventoryAcknowledges.Item(Me.colInclude.Name, row.Index).Value) = False Then
                    allSelected = False
                    Me.LoadInventoryTransferDetails(transferNo)
                    Exit For
                End If
                allSelected = True
            Next

            If allSelected Then
                ResetControlsIn(Me)
                Me.dgvInventoryAcknowledges.Rows.Clear()
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Function VerifyInventoryAcknowledgesEntries() As Boolean

        Try

            Me.Cursor = Cursors.WaitCursor()

            Dim message As String

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If fromLocationID.ToUpper().Equals(toLocationID.ToUpper()) Then
                message = "Sent 'From Location' " + Me.stbFromLocation.Text + " can not be the same as 'To Location'! "
                Throw New ArgumentException(message)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvInventoryAcknowledges.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvInventoryAcknowledges.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If Me.dgvInventoryAcknowledges.RowCount < 1 OrElse nonSelected Then
                Throw New ArgumentException("Must include at least one entry on transfer details!")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvInventoryAcknowledges.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvInventoryAcknowledges.Item(Me.colInclude.Name, row.Index).Value) = True Then

                    Dim itemCategoryID As String = StringEnteredIn(row.Cells, Me.colItemCategoryID)
                    Dim itemCode As String = StringEnteredIn(row.Cells, Me.colItemCode, "item!")
                    Dim itemName As String = StringEnteredIn(row.Cells, Me.colItemName, "item name!")
                    Dim totalUnits As Integer = IntegerMayBeEnteredIn(row.Cells, Me.colTotalUnits)

                    If totalUnits < 0 Then Throw New ArgumentException("Total Units must be higher than zero!")

                    Dim locationBalance As Integer = GetInventoryBalance(fromLocationID, itemCategoryID, itemCode)
                    If locationBalance < totalUnits Then
                        message = "You do not have sufficient balance to transfer for " + itemName + ". " + ControlChars.NewLine +
                           "Sent from location has " + locationBalance.ToString() + ", and you what to transfer " + totalUnits.ToString() + "!"
                        Throw New ArgumentException(message)
                    End If

                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            VerifyInventoryAcknowledgesEntries = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Function

#Region " InventoryAcknowledges Printing "

    Private Sub PrintInventoryAcknowledges()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvInventoryAcknowledges.RowCount < 1 Then
                Throw New ArgumentException("Must set at least one entry on Transfer details!")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetInventoryAcknowledgesPrintData()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docInventoryAcknowledges
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docInventoryAcknowledges.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docInventoryAcknowledges_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docInventoryAcknowledges.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Internal Inventory Acknowledges".ToUpper()

            Dim transferNo As String = StringMayBeEnteredIn(Me.stbTransferNo)
            Dim transferDate As String = FormatDate(DateMayBeEnteredIn(Me.stbTransferDate))
            Dim receivedDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpReceivedDate))
            Dim fromLocation As String = StringMayBeEnteredIn(Me.stbFromLocation)
            Dim toLocation As String = StringMayBeEnteredIn(Me.stbToLocation)

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

                    .DrawString("Transfer No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(transferNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Transfer Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(transferDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Received Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(receivedDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("From Location: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fromLocation, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("To Location: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(toLocation, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
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

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetInventoryAcknowledgesPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 25
        Dim padQuantity As Integer = 12
        Dim padBatchNo As Integer = 14
        Dim padExpiryDate As Integer = 12

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        transferParagraphs = New Collection()

        Try


            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Item Name: ".PadRight(padItemName))
            tableHeader.Append("Total Units: ".PadLeft(padQuantity))
            tableHeader.Append(GetSpaces(1) + "Batch No: ".PadRight(padBatchNo))
            tableHeader.Append("Expiry Date: ".PadRight(padExpiryDate))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim itemCount As Integer = 0

            For rowNo As Integer = 0 To Me.dgvInventoryAcknowledges.RowCount - 1
                If CBool(Me.dgvInventoryAcknowledges.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvInventoryAcknowledges.Rows(rowNo).Cells

                    itemCount += 1

                    Dim itemNo As String = (itemCount).ToString()
                    Dim itemName As String = StringMayBeEnteredIn(cells, Me.colItemName)
                    Dim totalUnits As String = StringMayBeEnteredIn(cells, Me.colTotalUnits)
                    Dim batchNo As String = StringMayBeEnteredIn(cells, Me.colBatchNo)
                    Dim expiryDate As String = FormatDate(DateMayBeEnteredIn(cells, Me.colExpiryDate))

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If itemName.Length > 25 Then
                        tableData.Append(itemName.Substring(0, 25).PadRight(padItemName))
                    Else : tableData.Append(itemName.PadRight(padItemName))
                    End If
                    tableData.Append(totalUnits.PadLeft(padQuantity))
                    tableData.Append(GetSpaces(1) + batchNo.PadRight(padBatchNo))
                    tableData.Append(expiryDate.PadRight(padExpiryDate))

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            transferParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Received By:      " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:         " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            checkedSignData.Append(ControlChars.NewLine)

            checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
            checkedSignData.Append(GetSpaces(4))
            checkedSignData.Append("Date:         " + GetCharacters("."c, 20))
            checkedSignData.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub lblFromLocationID_Click(sender As Object, e As EventArgs) Handles lblFromLocationID.Click

    End Sub

    Private Sub stbToLocation_TextChanged(sender As Object, e As EventArgs) Handles stbToLocation.TextChanged

    End Sub

#End Region

    Private Sub cboFromLocationID_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboFromLocationID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim LocationID As String = StringValueMayBeEnteredIn(Me.cboFromLocationID)
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If (Not (LocationID = "")) Then
                Me.GetAllPendingOrderDetails(LocationID)
            End If
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
End Class