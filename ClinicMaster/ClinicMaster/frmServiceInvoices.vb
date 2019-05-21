
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

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Collections.Generic
Imports System.Drawing.Printing

Public Class frmServiceInvoices

#Region " Fields "

    Dim oVariousOptions As New VariousOptions()

    Private defaultServiceInvoiceNo As String = String.Empty

    Private suppliers As DataTable

    Private currentAllSaved As Boolean = True
    Private currentServiceInvoiceNo As String = String.Empty

    Private supplierAddress As String = String.Empty

    Private _DrugNo As String = String.Empty
    Private _OtherItems As String = String.Empty
    Private _ConsumableNo As String = String.Empty

    Private oItemCategoryID As New LookupDataID.ItemCategoryID()
    Private oStockTypeID As New LookupDataID.StockTypeID()
    Private oItemStatusID As New LookupDataID.ItemStatusID()
    Private oPayStatusID As New LookupDataID.PayStatusID()
    Private WithEvents docServiceInvoices As New PrintDocument()

    ' The paragraphs.
    Private orderParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)

    Private padItemNo As Integer = 4
    Private padItemName As Integer = 20
    Private padQuantity As Integer = 10
    Private padUnitMeasure As Integer = 10
    Private padRate As Integer = 12

    Private padAmount As Integer = 15
    Private padTotalAmount As Integer = 58

    Private itemCount As Integer = 0
    Private oPack As New LookupDataID.PackID
#End Region

    Private Sub frmServiceInvoices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.useInventoryPacks()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpInvoiceDate.MaxDate = Today
            Me.dtpInvoiceDate.Checked = True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadSuppliers()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(defaultServiceInvoiceNo) Then

                Me.btnLoad.Enabled = False
                Me.stbServiceInvoiceNo.ReadOnly = True
                Me.stbServiceInvoiceNo.Text = FormatText(defaultServiceInvoiceNo, "ServiceInvoices", "ServiceInvoiceNo")
                Me.Search(defaultServiceInvoiceNo)

            End If


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
           

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmServiceInvoices_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        If Me.AllSaved() Then Me.Close()
    End Sub

    Private Sub frmServiceInvoices_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            If Not Me.AllSaved() Then
                If WarningMessage("Just close anyway?") = Windows.Forms.DialogResult.No Then
                    e.Cancel = True
                End If
            End If

        Catch eX As Exception
            ErrorMessage(eX)

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oServiceInvoices As New SyncSoft.SQLDb.ServiceInvoices()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oServiceInvoices.ServiceInvoiceNo = RevertText(StringEnteredIn(Me.stbServiceInvoiceNo, "Service Invoice No!"))
            DisplayMessage(oServiceInvoices.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            ResetControlsIn(Me.pnlBill)
            Me.ResetTabControls()
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim ServiceInvoiceNo As String = RevertText(StringEnteredIn(Me.stbServiceInvoiceNo, "Service Invoice No!"))
            Me.Search(ServiceInvoiceNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


#Region " Save Methods "

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim message As String
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim oServiceInvoices As New SyncSoft.SQLDb.ServiceInvoices()
            Dim lServiceInvoices As New List(Of DBConnect)

            With oServiceInvoices

                .ServiceInvoiceNo = RevertText(StringEnteredIn(Me.stbServiceInvoiceNo, "Purchase Order No!"))
                .InvoiceDate = DateEnteredIn(Me.dtpInvoiceDate, "Order Date!")
                .DocumentNo = StringEnteredIn(Me.stbDocumentNo, "Document No!")
                .SupplierNo = RevertText(StringEnteredIn(Me.cboSupplierNo, "Supplier No!"))
                .ShipAddress = StringEnteredIn(Me.stbShipAddress, "Ship Address!")

                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lServiceInvoices.Add(oServiceInvoices)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Me.dgvOtherItems.RowCount <= 1 Then

                message = "Must register at least one item for Other Items!"
                Throw New ArgumentException(message)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
           
            Me.VerifyOtherItemsEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lServiceInvoices, Action.Save))
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                  
                    Me.SaveOtherItems()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not Me.chkPrintOnSaving.Checked Then
                        message = "You have not checked Print Order On Saving. " + ControlChars.NewLine + "Would you want Order printed?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintServiceInvoices()
                    Else : Me.PrintServiceInvoices()
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ResetControlsIn(Me.pnlBill)
                    Me.ResetTabControls()
                    Me.SetDefaultShipToAddress()
                    Me.SetNextServiceInvoiceNo()
                    Me.useInventoryPacks()
                    Me.dtpInvoiceDate.Value = Today
                    Me.dtpInvoiceDate.Checked = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(lServiceInvoices, Action.Update, "ServiceInvoices"))
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                  
                    Me.SaveOtherItems()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DisplayMessage("record(s) updated successfully!")
                    Me.CallOnKeyEdit()
                    Me.useInventoryPacks()
            End Select

        Catch ex As Exception

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If ex.Message.Contains("The Service Invoice No:") OrElse ex.Message.EndsWith("already exists") Then
                message = "The Service Invoice No: " + Me.stbServiceInvoiceNo.Text + ", you are trying to enter already exists" +
                    ControlChars.NewLine + "If you are using the system generated number, probably another user has already taken it." +
                    ControlChars.NewLine + "Would you like the system to generate another one?."
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.SetNextServiceInvoiceNo()
            Else : ErrorMessage(ex)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Function SaveOtherItems() As Boolean

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim ServiceInvoiceNo As String = RevertText(StringEnteredIn(Me.stbServiceInvoiceNo, "Service Invoice No!"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvOtherItems.RowCount - 2

                Try

                    Dim transactions As New List(Of TransactionList(Of DBConnect))
                    Dim lServiceInvoiceDetails As New List(Of DBConnect)

                    Dim cells As DataGridViewCellCollection = Me.dgvOtherItems.Rows(rowNo).Cells

                    Dim itemCode As String = StringEnteredIn(cells, Me.colOtherItemsNo, "OtherItems No!")
                    Dim itemName As String = StringEnteredIn(cells, Me.ColOtherItemsItemName, "OtherItems Name!")
                    Dim unitMeasure As String = StringMayBeEnteredIn(cells, Me.ColOtherItemsUnitMeasure)
                    Dim itemGroup As String = StringMayBeEnteredIn(cells, Me.ColOtherItemsItemGroup)
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.ColOtherItemsQuantity, "Quantity!")
                    Dim rate As Decimal = DecimalEnteredIn(cells, Me.ColOtherItemsRate, False, "Rate!")
                    Dim PackID As String = StringMayBeEnteredIn(cells, Me.colOtherItemsPack)
                    Dim PackSize As Integer = IntegerMayBeEnteredIn(cells, Me.ColOtherItemsPackSize)
                    Dim _VATPercentage As Decimal = DecimalMayBeEnteredIn(cells, Me.ColOtherItemsVATPercentage, False)
                    Dim _VATValue As Decimal = DecimalEnteredIn(cells, Me.ColOtherItemsVATValue, False, "VAT Value!")
                    If (String.IsNullOrEmpty(PackID)) Then
                        PackID = oPack.NA
                        PackSize = 1
                    End If

                    Dim Amount As Decimal = DecimalEnteredIn(cells, Me.ColOtherItemsAmount, False, "Amount!")
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.ColOtherItemsNotes)

                    Using oServiceInvoiceDetails As New SyncSoft.SQLDb.ServiceInvoiceDetails()
                        With oServiceInvoiceDetails
                            .ServiceInvoiceNo = ServiceInvoiceNo
                            .ItemCategoryID = oItemCategoryID.NonMedical
                            .ItemCode = itemCode
                            .ItemName = itemName
                            .UnitMeasure = unitMeasure
                            .ItemGroup = itemGroup
                            .Quantity = quantity
                            .Rate = rate
                            .VATValue = _VATValue
                            .PackID = PackID
                            .PackSize = PackSize
                            .Amount = Amount
                            .Notes = notes
                            .PayStatusID = oPayStatusID.NotPaid
                            .LoginID = CurrentUser.LoginID
                        End With
                        lServiceInvoiceDetails.Add(oServiceInvoiceDetails)
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim lItemVATPercentage As New List(Of DBConnect)
                    Using oItemVATPercentage As New SyncSoft.SQLDb.ItemsVATPercentage



                        If _VATPercentage > 0 Then

                            With oItemVATPercentage
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.NonMedical
                                .VATPercentage = _VATPercentage

                            End With

                            lItemVATPercentage.Add(oItemVATPercentage)
                        End If
                    End Using


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    transactions.Add(New TransactionList(Of DBConnect)(lServiceInvoiceDetails, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lItemVATPercentage, Action.Update))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvOtherItems.Item(Me.colOtherItemsSaved.Name, rowNo).Value = True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcServiceInvoices.SelectTab(Me.tpgOthers.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcServiceInvoices.SelectTab(Me.tpgOthers.Name)
            SaveOtherItems = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function



#End Region

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        Me.stbServiceInvoiceNo.ReadOnly = False
        Me.btnLoad.Enabled = True
        Me.pnlPrintOnSaving.Visible = False
        Me.btnPrint.Visible = True

        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlBill)
        Me.ResetTabControls()

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.stbServiceInvoiceNo.ReadOnly = InitOptions.ServiceInvoiceNoLocked
        Me.btnLoad.Enabled = False
        Me.pnlPrintOnSaving.Visible = True
        Me.btnPrint.Visible = False

        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlBill)
        Me.ResetTabControls()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.SetDefaultShipToAddress()
        Me.SetNextServiceInvoiceNo()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.dtpInvoiceDate.Value = Today
        Me.dtpInvoiceDate.Checked = True
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.fbnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            Security.Apply(Me.fbnDelete, AccessRights.Delete)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.ebnSaveUpdate.Enabled = False
            Me.fbnDelete.Enabled = False
            Me.btnPrint.Enabled = False
        End If
    End Sub

#End Region

#Region " OtherItems - Grid "

    Private Sub dgvOtherItems_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvOtherItems.CellBeginEdit

        'If e.ColumnIndex <> Me.colDrugNo.Index OrElse Me.dgvOtherItems.Rows.Count <= 1 Then Return
        If CInt(e.ColumnIndex <> Me.dgvOtherItems.Rows.Count) <= 1 Then Return

        Dim selectedRow As Integer = Me.dgvOtherItems.CurrentCell.RowIndex
        Me._OtherItems = StringMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.colOtherItemsNo)
    End Sub


    Private Sub dgvOtherItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOtherItems.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Other Items", "Item No", "Item Name", Me.GetOtherItems(), "ItemFullName",
                                                                     "ItemCode", "ItemName", Me.dgvOtherItems, Me.colOtherItemsNo, e.RowIndex)

            Me._OtherItems = StringMayBeEnteredIn(Me.dgvOtherItems.Rows(e.RowIndex).Cells, Me.colOtherItemsNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.colOtherItemselect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvOtherItems.Rows(e.RowIndex).IsNewRow Then

                Me.dgvOtherItems.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetOtherItemsEntries(e.RowIndex)

            ElseIf Me.colOtherItemselect.Index.Equals(e.ColumnIndex) Then

                fSelectItem.ShowDialog(Me)
                Me.SetOtherItemsEntries(e.RowIndex)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvOtherItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOtherItems.CellEndEdit

        Dim selectedRow As Integer = Me.dgvOtherItems.CurrentCell.RowIndex

        If e.ColumnIndex.Equals(Me.colOtherItemsNo.Index) Then
            If Me.dgvOtherItems.Rows.Count > 1 Then Me.SetOtherItemsEntries(selectedRow)

        ElseIf e.ColumnIndex.Equals(Me.ColOtherItemsQuantity.Index) Then
            Me.CalculateOtherItemsAmount(selectedRow)
            Me.CalculateBillForOtherItems()

        ElseIf e.ColumnIndex.Equals(Me.ColOtherItemsRate.Index) Then
            Me.CalculateOtherItemsAmount(selectedRow)
            Me.CalculateBillForOtherItems()

        ElseIf e.ColumnIndex.Equals(Me.ColOtherItemsVATPercentage.Index) Then
            Me.CalculateOtherItemsAmount(selectedRow)
            Me.CalculateBillForOtherItems()

        ElseIf e.ColumnIndex.Equals(Me.colOtherItemsPack.Index) Then
            Dim pack As String = StringMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.colOtherItemsPack)
            Me.dgvOtherItems.Item(Me.ColOtherItemsPackSize.Name, selectedRow).Value = 1
            If (String.IsNullOrEmpty(pack) OrElse pack.Equals(oPack.NA)) Then
                ColOtherItemsPackSize.ReadOnly = True
            Else

                ColOtherItemsPackSize.ReadOnly = False
            End If
            Me.CalculateOtherItemsAmount(selectedRow)
            Me.CalculateBillForOtherItems()
        ElseIf e.ColumnIndex.Equals(Me.ColOtherItemsPackSize.Index) Then
            Me.CalculateOtherItemsAmount(selectedRow)
            Me.CalculateBillForOtherItems()

        ElseIf e.ColumnIndex.Equals(Me.ColOtherItemsAmount.Index) Then
            Me.CalculateOtherItemsRate(selectedRow)
            Me.CalculateBillForOtherItems()

        End If
    End Sub

    Private Sub SetOtherItemsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = SubstringRight(StringMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.colOtherItemsNo))

            Me.SetOtherItemsEntries(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetOtherItemsEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try

            If CBool(Me.dgvOtherItems.Item(Me.colOtherItemsSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Item No (" + Me._OtherItems + ") can't be edited!")
                Me.dgvOtherItems.Item(Me.colOtherItemsNo.Name, selectedRow).Value = Me._OtherItems
                Me.dgvOtherItems.Item(Me.colOtherItemsNo.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvOtherItems.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvOtherItems.Rows(rowNo).Cells, Me.colOtherItemsNo)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Item No (" + enteredItem + ") already selected!")
                        Me.dgvOtherItems.Rows.RemoveAt(selectedRow)
                        Me.dgvOtherItems.Item(Me.colOtherItemsNo.Name, selectedRow).Value = Me._OtherItems
                        Me.dgvOtherItems.Item(Me.colOtherItemsNo.Name, selectedRow).Selected = True
                    End If
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailotherItems(selectedRow)
            Me.CalculateOtherItemsAmount(selectedRow)
            Me.CalculateBillForOtherItems()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvOtherItems_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvOtherItems.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oServiceInvoiceDetails As New SyncSoft.SQLDb.ServiceInvoiceDetails()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvOtherItems.Item(Me.colOtherItemsSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim ServiceInvoiceNo As String = RevertText(StringEnteredIn(Me.stbServiceInvoiceNo, "Service Invoice No!"))
            Dim itemCode As String = Me.dgvOtherItems.Item(Me.colOtherItemsNo.Name, toDeleteRowNo).Value.ToString()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oServiceInvoiceDetails
                .ServiceInvoiceNo = ServiceInvoiceNo
                .ItemCategoryID = oItemCategoryID.NonMedical
                .ItemCode = itemCode
            End With

            DisplayMessage(oServiceInvoiceDetails.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvOtherItems_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvOtherItems.UserDeletedRow
        Me.CalculateBillForOtherItems()
    End Sub

    Private Sub dgvOtherItems_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvOtherItems.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailotherItems(ByVal selectedRow As Integer)

        Try

            Dim oOtherItems As New SyncSoft.SQLDb.OtherItems()
            Dim oUnitMeasureID As New LookupDataID.UnitMeasureID()
            Dim itemNo As String = String.Empty

            If Me.dgvOtherItems.Rows.Count > 1 Then itemNo = SubstringRight(StringMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.colOtherItemsNo))

            If String.IsNullOrEmpty(itemNo) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim OtherItems As DataTable = oOtherItems.GetOtherItems(itemNo).Tables("OtherItems")
            Dim row As DataRow = OtherItems.Rows(0)

            Dim hidden As Boolean = BooleanMayBeEnteredIn(row, "Hidden")
            If hidden Then Throw New ArgumentException("The Item No: " + itemNo + ", is not enabled for selection. Contact administrator!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim itemName As String = StringEnteredIn(row, "ItemName", "Item Name!")
            Dim unitMeasure As String = StringMayBeEnteredIn(row, "UnitMeasure")
            Dim group As String = StringMayBeEnteredIn(row, "Group")
            Dim quantity As Integer = 1
            Dim unitCost As Decimal = DecimalMayBeEnteredIn(row, "UnitCost")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Me.dgvOtherItems
                .Item(Me.colOtherItemsNo.Name, selectedRow).Value = itemNo.ToUpper()
                .Item(Me.ColOtherItemsItemName.Name, selectedRow).Value = itemName
                If GetLookupDataDes(oUnitMeasureID.NA).ToUpper().Equals(unitMeasure.ToUpper()) Then
                    .Item(Me.ColOtherItemsUnitMeasure.Name, selectedRow).Value = GetLookupDataDes(oUnitMeasureID.NA)
                Else : Me.dgvOtherItems.Item(Me.ColOtherItemsUnitMeasure.Name, selectedRow).Value = unitMeasure
                End If
                .Item(Me.ColOtherItemsItemGroup.Name, selectedRow).Value = group
                .Item(Me.ColOtherItemsPackSize.Name, selectedRow).Value = 1
                .Item(Me.ColOtherItemsQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colOtherItemsTotalUnits.Name, selectedRow).Value = quantity
                .Item(Me.ColOtherItemsVATPercentage.Name, selectedRow).Value = DecimalMayBeEnteredIn(row, "VATPercentage")
                .Item(Me.ColOtherItemsRate.Name, selectedRow).Value = FormatNumber(unitCost, AppData.DecimalPlaces)
                .Item(Me.colOtherItemPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvOtherItems.Item(Me.colOtherItemsNo.Name, selectedRow).Value = Me._OtherItems.ToUpper()
            Throw ex

        End Try

    End Sub
    Private Sub CalculateBillForOtherItems()

        ResetControlsIn(Me.pnlBill)

        Dim totalBill As Decimal = CalculateGridAmount(Me.dgvOtherItems, Me.ColOtherItemsAmount)
        Dim totalVATValue As Decimal = CalculateGridAmount(Me.dgvOtherItems, Me.ColOtherItemsVATValue)
        Me.stbVATValue.Text = FormatNumber(totalVATValue, AppData.DecimalPlaces)
        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)



    End Sub

    Private Sub CalculateOtherItemsAmount(ByVal selectedRow As Integer)

        Dim quantity As Integer = IntegerMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.ColOtherItemsQuantity)
        Dim rate As Decimal = DecimalMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.ColOtherItemsRate)
        Dim packSize As Integer = IntegerMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.ColOtherItemsPackSize)
        Dim _VATPercentage As Decimal = DecimalMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.ColOtherItemsVATPercentage)

        Dim totalUnits As Integer
        totalUnits = quantity * packSize

        Dim amountBeforeVAT As Decimal = CDec(totalUnits * rate)
        Dim _VATValue As Decimal
        If _VATPercentage = 0 Then
            _VATValue = 0
        Else
            _VATValue = (amountBeforeVAT * _VATPercentage / 100)
        End If



        If (_VATValue < 0) Then
            _VATValue = 0
        End If

        Dim amount As Decimal = amountBeforeVAT + _VATValue

        If (amount < 0) Then
            amount = 0
        End If


        Me.dgvOtherItems.Item(Me.ColOtherItemsAmount.Name, selectedRow).Value = FormatNumber(amount, AppData.DecimalPlaces)
        Me.dgvOtherItems.Item(Me.ColOtherItemsVATValue.Name, selectedRow).Value = FormatNumber(_VATValue, AppData.DecimalPlaces)
        Me.dgvOtherItems.Item(Me.colOtherItemsTotalUnits.Name, selectedRow).Value = totalUnits

    End Sub

    Private Sub CalculateOtherItemsRate(ByVal selectedRow As Integer)

        Dim rate As Decimal = 0
        Dim amount As Decimal = DecimalMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.ColOtherItemsAmount)
        Dim pack As String = StringMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.colOtherItemsPack)
        Dim totalUnits As Integer = IntegerMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.colOtherItemsTotalUnits)
        Dim _VATValue As Decimal = DecimalMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.ColOtherItemsVATValue)

        If totalUnits = 0 Then
            rate = 0

        Else

            rate = (amount - _VATValue) / totalUnits
        End If




        Me.dgvOtherItems.Item(Me.ColOtherItemsRate.Name, selectedRow).Value = FormatNumber(rate, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadOtherItemsOrderDetails(ByVal ServiceInvoiceNo As String)

        Dim oServiceInvoiceDetails As New SyncSoft.SQLDb.ServiceInvoiceDetails()

        Try

            Me.dgvOtherItems.Rows.Clear()

            ' Load ServiceInvoiceDetails

            Dim orderDetails As DataTable = oServiceInvoiceDetails.GetServiceInvoiceDetails(ServiceInvoiceNo, oItemCategoryID.NonMedical).Tables("ServiceInvoiceDetails")
            If orderDetails Is Nothing OrElse orderDetails.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvOtherItems, orderDetails)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To orderDetails.Rows.Count - 1

                Dim row As DataRow = orderDetails.Rows(pos)

                With Me.dgvOtherItems
                    .Item(Me.colOtherItemsPack.Name, pos).Value = StringEnteredIn(row, "PackID")
                End With
            Next


            For Each row As DataGridViewRow In Me.dgvOtherItems.Rows
                If row.IsNewRow Then Exit For
                Me.dgvOtherItems.Item(Me.colOtherItemsSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub


    Private Function VerifyOtherItemsEntries() As Boolean

        Try
            Dim rowCounter As Integer = 0
            For Each row As DataGridViewRow In Me.dgvOtherItems.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colOtherItemsNo, "Other Item No!")
                StringEnteredIn(row.Cells, Me.ColOtherItemsItemName, "Other Item Name!")
                Dim quantity As Single = SingleEnteredIn(row.Cells, Me.colOtherItemsTotalUnits, "Total Units!")
                Dim _VATPercentage As Decimal = DecimalEnteredIn(row.Cells, Me.ColOtherItemsVATPercentage, False, "VAT Percentage!")
                DecimalEnteredIn(row.Cells, Me.ColOtherItemsRate, False, "Rate!")
                DecimalEnteredIn(row.Cells, Me.ColOtherItemsAmount, False, "Amount!")
                rowCounter += 1
                If quantity <= 0 Then Throw New ArgumentException("Total Units must be higher than zero at row " + rowCounter.ToString() + "!")
                If _VATPercentage > 100 Then Throw New ArgumentException("VAT Percentage can't greater than 100 " + rowCounter.ToString() + "!")

            Next

            Return True

        Catch ex As Exception
            Me.tbcServiceInvoices.SelectTab(Me.tpgOthers.Name)
            VerifyOtherItemsEntries = False
            Throw ex

        End Try

    End Function

#End Region

    
#Region " ServiceInvoices Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintServiceInvoices()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintServiceInvoices()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If Me.dgvDrugs.RowCount < 1 OrElse Me.dgvConsumables.RowCount < 1 OrElse Me.dgvOtherItems.RowCount < 1 Then
            If Me.dgvOtherItems.RowCount < 1 Then

                Throw New ArgumentException("Must set at least one entry on Order details!")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetServiceInvoicesPrintData()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docServiceInvoices
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docServiceInvoices.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docServiceInvoices_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docServiceInvoices.PrintPage

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

            Dim title As String = AppData.ProductOwner.ToUpper() + " Local Purchase Order".ToUpper()

            Dim orderNo As String = StringMayBeEnteredIn(Me.stbServiceInvoiceNo)
            Dim InvoiceDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpInvoiceDate))
            Dim documentNo As String = StringMayBeEnteredIn(Me.stbDocumentNo)
            Dim shipAddress As String = StringMayBeEnteredIn(Me.stbShipAddress)
            Dim supplierName As String = StringMayBeEnteredIn(Me.stbSupplierName)

            Dim vendor As String = supplierName + ControlChars.NewLine + supplierAddress

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

                    .DrawString("Invoice No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(orderNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Invoice Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(InvoiceDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Document (Ref.) No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(documentNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += 2 * lineHeight

                    .DrawString("Ship To: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(shipAddress, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    Dim addressLines As Integer = shipAddress.Split(CChar(ControlChars.NewLine)).Length
                    yPos += addressLines * lineHeight
                    yPos += lineHeight

                    .DrawString("Vendor: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(vendor, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
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

    Private Sub SetServiceInvoicesPrintData()

        Dim footerFont As New Font(printFontName, 9)

        itemCount = 0
        pageNo = 0
        orderParagraphs = New Collection()

        Try

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Item Name: ".PadRight(padItemName))
            tableHeader.Append("Qty: ".PadLeft(padQuantity))
            tableHeader.Append("UOM: ".PadRight(padUnitMeasure))
            tableHeader.Append("Rate: ".PadLeft(padRate))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            orderParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'orderParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.DrugsData().ToString()))
            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'orderParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ConsumablesData().ToString()))
            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            orderParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.OtherItemsData().ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim totalAmountData As New System.Text.StringBuilder(String.Empty)
            'Dim drugAmount As Decimal = CalculateGridAmount(Me.dgvDrugs, Me.colDrugAmount)
            'Dim consumableAmount As Decimal = CalculateGridAmount(Me.dgvConsumables, Me.colConsumableAmount)
            Dim otherItemsAmount As Decimal = CalculateGridAmount(Me.dgvOtherItems, Me.ColOtherItemsAmount)
            'Dim totalAmount As Decimal = drugAmount + consumableAmount + otherItemsAmount
            Dim totalAmount As Decimal = otherItemsAmount

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
            Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            checkedSignData.Append(ControlChars.NewLine)

            checkedSignData.Append("Authorized By:      " + GetCharacters("."c, 20))
            checkedSignData.Append(GetSpaces(4))
            checkedSignData.Append("Date:         " + GetCharacters("."c, 20))
            checkedSignData.Append(ControlChars.NewLine)
            orderParagraphs.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim approvedSignData As New System.Text.StringBuilder(String.Empty)
            approvedSignData.Append(ControlChars.NewLine)

            approvedSignData.Append("Approved By:        " + GetCharacters("."c, 20))
            approvedSignData.Append(GetSpaces(4))
            approvedSignData.Append("Date:         " + GetCharacters("."c, 20))
            approvedSignData.Append(ControlChars.NewLine)
            orderParagraphs.Add(New PrintParagraps(footerFont, approvedSignData.ToString()))

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

    'Private Function DrugsData() As String

    '    Try

    '        Dim tableData As New System.Text.StringBuilder(String.Empty)

    '        For rowNo As Integer = 0 To Me.dgvDrugs.RowCount - 2

    '            Dim cells As DataGridViewCellCollection = Me.dgvDrugs.Rows(rowNo).Cells

    '            itemCount += 1

    '            Dim itemNo As String = (itemCount).ToString()
    '            Dim itemName As String = cells.Item(Me.colDrugName.Name).Value.ToString()
    '            Dim quantity As String = cells.Item(Me.colDrugTotalUnits.Name).Value.ToString()
    '            Dim unitMeasure As String = cells.Item(Me.colDrugUnitMeasure.Name).Value.ToString()
    '            Dim rate As String = cells.Item(Me.colDrugRate.Name).Value.ToString()
    '            Dim amount As String = cells.Item(Me.colDrugAmount.Name).Value.ToString()

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

    'Private Function ConsumablesData() As String

    '    Try

    '        Dim tableData As New System.Text.StringBuilder(String.Empty)

    '        For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

    '            Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

    '            itemCount += 1

    '            Dim itemNo As String = (itemCount).ToString()
    '            Dim itemName As String = cells.Item(Me.colConsumableName.Name).Value.ToString()
    '            Dim quantity As String = cells.Item(Me.colTotalUnits.Name).Value.ToString()
    '            Dim unitMeasure As String = cells.Item(Me.colConsumableUnitMeasure.Name).Value.ToString()
    '            Dim rate As String = cells.Item(Me.colConsumableRate.Name).Value.ToString()
    '            Dim amount As String = cells.Item(Me.colConsumableAmount.Name).Value.ToString()

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

    Private Function OtherItemsData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvOtherItems.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvOtherItems.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemName As String = cells.Item(Me.ColOtherItemsItemName.Name).Value.ToString()
                Dim quantity As String = cells.Item(Me.colOtherItemsTotalUnits.Name).Value.ToString()
                Dim unitMeasure As String = cells.Item(Me.ColOtherItemsUnitMeasure.Name).Value.ToString()
                Dim rate As String = cells.Item(Me.ColOtherItemsRate.Name).Value.ToString()
                Dim amount As String = cells.Item(Me.ColOtherItemsAmount.Name).Value.ToString()

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
                            tableData.Append(quantity.PadLeft(padQuantity))
                            If unitMeasure.Length > 10 Then
                                tableData.Append(GetSpaces(1) + unitMeasure.Substring(0, 10).PadRight(padUnitMeasure))
                            Else : tableData.Append(GetSpaces(1) + unitMeasure.PadRight(padUnitMeasure))
                            End If
                            tableData.Append(rate.PadLeft(padRate))
                            tableData.Append(amount.PadLeft(padAmount))
                        End If
                    Next

                Else
                    tableData.Append(FixDataLength(itemName, padItemName))
                    tableData.Append(quantity.PadLeft(padQuantity))
                    If unitMeasure.Length > 10 Then
                        tableData.Append(GetSpaces(1) + unitMeasure.Substring(0, 10).PadRight(padUnitMeasure))
                    Else : tableData.Append(GetSpaces(1) + unitMeasure.PadRight(padUnitMeasure))
                    End If
                    tableData.Append(rate.PadLeft(padRate))
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

#End Region

#Region " AUTO NUMBERS"

    Private Sub SetNextServiceInvoiceNo()

        Dim yearL2 As String = Today.Year.ToString().Substring(2)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oServiceInvoices As New SyncSoft.SQLDb.ServiceInvoices()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("ServiceInvoices", "ServiceInvoiceNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))
            Dim ServiceInvoiceNo As String = yearL2 + oServiceInvoices.GetNextServiceInvoiceID.ToString().PadLeft(paddingLEN, paddingCHAR)

            Me.stbServiceInvoiceNo.Text = FormatText(ServiceInvoiceNo, "ServiceInvoices", "ServiceInvoiceNo")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " POPUP INFORMATION "

    Private Sub cmsServiceInvoices_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsServiceInvoices.Opening

        Select Case Me.tbcServiceInvoices.SelectedTab.Name

            'Case Me.tpgDrugs.Name
            '    Me.cmsServiceInvoicesQuickSearch.Visible = True

            'Case Me.tpgConsumables.Name
            '    Me.cmsServiceInvoicesQuickSearch.Visible = True

            Case Me.tpgOthers.Name
                Me.cmsServiceInvoicesQuickSearch.Visible = True

            Case Else
                Me.cmsServiceInvoicesQuickSearch.Visible = False

        End Select

    End Sub

    Private Sub cmsServiceInvoicesQuickSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsServiceInvoicesQuickSearch.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim rowIndex As Integer

            Select Case Me.tbcServiceInvoices.SelectedTab.Name

                'Case Me.tpgDrugs.Name

                '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Drugs", Me.dgvDrugs, Me.colDrugNo)
                '    fQuickSearch.ShowDialog(Me)

                '    rowIndex = Me.dgvDrugs.NewRowIndex
                '    If rowIndex > 0 Then Me.SetDrugsEntries(rowIndex - 1)
                '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                'Case Me.tpgConsumables.Name

                '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("ConsumableItems", Me.dgvConsumables, Me.colConsumableNo)
                '    fQuickSearch.ShowDialog(Me)

                '    rowIndex = Me.dgvConsumables.NewRowIndex
                '    If rowIndex > 0 Then Me.SetConsumableEntries(rowIndex - 1)
                '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgOthers.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("OtherItems", Me.dgvOtherItems, Me.colOtherItemsNo)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvOtherItems.NewRowIndex
                    If rowIndex > 0 Then Me.SetOtherItemsEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " SHOW INFORMATION"

    Private Function ShowToOrder(ItemCategoryID As String) As Integer

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim Result As Integer
            'Select Case Me.tbcServiceInvoices.SelectedTab.Name
            '    Case Me.tpgDrugs.Name
            '        Dim records As Integer = oDrugs.CountToOrderDrugs()
            '        Me.lblToOrderDrugs.Text = "To Order Drugs: " + records.ToString()
            '        records = Result
            '    Case Me.tpgConsumables.Name
            '        Dim records As Integer = oConsumableItems.CountToOrderConsumableItems
            '        Me.lblToOrderDrugs.Text = "To Order Consumables: " + records.ToString()
            '        records = Result
            'End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return Result
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function ShowToExpire(ItemCategoryID As String) As Integer

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems
        Dim oVariousOptions As New VariousOptions()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim Result As Integer
            'Me.lblToExpireDrugs.Text = "To Expire/Expired Drugs: " + records.ToString()
            'Select Case Me.tbcServiceInvoices.SelectedTab.Name
            '    Case Me.tpgDrugs.Name
            '        Dim records As Integer = oDrugs.CountToExpireDrugs(oVariousOptions.ExpiryWarningDays)
            '        Me.lblToExpireDrugs.Text = "To Expire/Expired Drugs: " + records.ToString()
            '        records = Result
            '    Case Me.tpgConsumables.Name
            '        Dim records As Integer = oConsumableItems.CountToExpireConsumableItems(oVariousOptions.ExpiryWarningDays)
            '        Me.lblToExpireDrugs.Text = "To Expire/Expired Consumables: " + records.ToString()
            '        records = Result
            'End Select
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return Result
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub useInventoryPacks()
        If Not oVariousOptions.UseOfInventoryPackSizes Then
            'colPack.Visible = False
            'colPackSize.Visible = False
            'colDrugsPack.Visible = False
            'colDrugsPackSize.Visible = False
            ColOtherItemsPackSize.Visible = False
            colOtherItemsPack.Visible = False
        End If
    End Sub

#End Region

#Region " LOAD INFORMATION"

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicServiceInvoices As New frmPeriodicServiceInvoices(Me.stbServiceInvoiceNo, True)
            fPeriodicServiceInvoices.ShowDialog(Me)
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function GetOtherItems() As DataTable

        Dim otherItems As DataTable
        Dim oOtherItems As New SyncSoft.SQLDb.OtherItems()

        Try

            otherItems = oOtherItems.GetOtherItems().Tables("OtherItems")

            '''''''''''''''''''''''''''''''''''''''''''''''''
            Return otherItems
            '''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)

        End Try

    End Function

    'Private Sub btnViewToOrderDrugsList_Click(sender As Object, e As EventArgs) Handles btnViewToOrderDrugsList.Click

    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Try

    '        ServiceInvoices.Values.Clear()

    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '        Select Case Me.tbcServiceInvoices.SelectedTab.Name
    '            Case Me.tpgDrugs.Name

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
    '                Dim fToOrderDrugs As New frmToOrderItems(ItemsTo.Order, oItemCategoryID.Drug, True)
    '                fToOrderDrugs.ShowDialog(Me)

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim DrugPair As KeyValuePair(Of String, String)
    '                For Each DrugPair In ServiceInvoices.Values

    '                    With Me.dgvDrugs
    '                        .Rows.Add()
    '                        .Item(Me.colDrugNo.Name, .NewRowIndex - 1).Value = DrugPair.Key
    '                        '.Item(Me.colDrugName.Name, .NewRowIndex - 1).Value = pair.Value
    '                        Me.SetDrugsEntries(.NewRowIndex - 1, DrugPair.Key)
    '                    End With
    '                Next
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Me.ShowToOrder(oItemCategoryID.Drug)
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


    '            Case Me.tpgConsumables.Name
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
    '                Dim fToOrderConsumables As New frmToOrderItems(ItemsTo.Order, oItemCategoryID.Consumable, True)
    '                fToOrderConsumables.ShowDialog(Me)

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim ConsumablePair As KeyValuePair(Of String, String)
    '                For Each ConsumablePair In ServiceInvoices.Values

    '                    With Me.dgvConsumables
    '                        .Rows.Add()
    '                        .Item(Me.colConsumableNo.Name, .NewRowIndex - 1).Value = ConsumablePair.Key
    '                        Me.SetConsumableEntries(.NewRowIndex - 1, ConsumablePair.Key)
    '                    End With
    '                Next
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Me.ShowToOrder(oItemCategoryID.Consumable)
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '        End Select


    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try
    'End Sub

    'Private Sub btnViewToExpireDrugsList_Click(sender As Object, e As EventArgs) Handles btnViewToExpireDrugsList.Click
    '    Try
    '        ServiceInvoices.Values.Clear()

    '        Select Case Me.tbcServiceInvoices.SelectedTab.Name
    '            Case Me.tpgDrugs.Name
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
    '                Dim fToOrderDrugs As New frmToOrderItems(ItemsTo.Expire, oItemCategoryID.Drug, True)
    '                fToOrderDrugs.ShowDialog(Me)
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim DrugPair As KeyValuePair(Of String, String)
    '                For Each DrugPair In ServiceInvoices.Values

    '                    With Me.dgvDrugs
    '                        .Rows.Add()
    '                        .Item(Me.colDrugNo.Name, .NewRowIndex - 1).Value = DrugPair.Key
    '                        '.Item(Me.colDrugName.Name, .NewRowIndex - 1).Value = pair.Value
    '                        Me.SetDrugsEntries(.NewRowIndex - 1, DrugPair.Key)
    '                    End With
    '                Next
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Me.ShowToExpire(oItemCategoryID.Drug)

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '            Case Me.tpgConsumables.Name
    '                Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
    '                Dim fToOrderConsumables As New frmToOrderItems(ItemsTo.Expire, oItemCategoryID.Consumable, True)
    '                fToOrderConsumables.ShowDialog(Me)
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim ConsumablePair As KeyValuePair(Of String, String)
    '                For Each ConsumablePair In ServiceInvoices.Values

    '                    With Me.dgvConsumables
    '                        .Rows.Add()
    '                        .Item(Me.colConsumableNo.Name, .NewRowIndex - 1).Value = ConsumablePair.Key
    '                        '.Item(Me.colConsumableName.Name, .NewRowIndex - 1).Value = pair.Value

    '                        Me.SetConsumableEntries(.NewRowIndex - 1, ConsumablePair.Key)
    '                    End With
    '                Next
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Me.ShowToExpire(oItemCategoryID.Consumable)

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        End Select


    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Function GetDrugs() As DataTable

    '    Dim drugs As DataTable
    '    Dim oSetupData As New SetupData()
    '    Dim oDrugs As New SyncSoft.SQLDb.Drugs()

    '    Try

    '        ' Load from drugs

    '        If Not InitOptions.LoadDrugsAtStart Then
    '            drugs = oDrugs.GetDrugs().Tables("Drugs")
    '            oSetupData.Drugs = drugs
    '        Else : drugs = oSetupData.Drugs
    '        End If

    '        '''''''''''''''''''''''''''''''''''''''''''''''''
    '        Return drugs
    '        '''''''''''''''''''''''''''''''''''''''''''''''''

    '    Catch ex As Exception
    '        Throw (ex)

    '    End Try

    'End Function

    'Private Function GetConsumableItems() As DataTable

    '    Dim consumableItems As DataTable
    '    Dim oSetupData As New SetupData()
    '    Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

    '    Try

    '        ' Load from ConsumableItems

    '        If Not InitOptions.LoadConsumableItemsAtStart Then
    '            consumableItems = oConsumableItems.GetConsumableItems().Tables("ConsumableItems")
    '            oSetupData.ConsumableItems = consumableItems
    '        Else : consumableItems = oSetupData.ConsumableItems
    '        End If

    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        Return consumableItems
    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '    Catch ex As Exception
    '        Throw (ex)

    '    End Try

    'End Function


#End Region

#Region " OTHER OPTIONS"

    Public Sub Search(ByVal ServiceInvoiceNo As String)

        Dim oServiceInvoices As New SyncSoft.SQLDb.ServiceInvoices()

        Try

            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dataSource As DataTable = oServiceInvoices.GetServiceInvoices(ServiceInvoiceNo).Tables("ServiceInvoices")
            Me.DisplayData(dataSource)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Me.LoadDrugOrderDetails(ServiceInvoiceNo)
            'Me.LoadConsumableOrderDetails(ServiceInvoiceNo)
            Me.LoadOtherItemsOrderDetails(ServiceInvoiceNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.tbcServiceInvoices.SelectedTab.Name

                'Case Me.tpgDrugs.Name
                '    Me.CalculateBillForDrugs()

                'Case Me.tpgConsumables.Name
                '    Me.CalculateBillForConsumables()
                Case Me.tpgOthers.Name
                    Me.CalculateBillForOtherItems()

                Case Else : ResetControlsIn(Me.pnlBill)

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.btnPrint.Enabled = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub tbcServiceInvoices_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles tbcServiceInvoices.SelectedIndexChanged

        Try

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcServiceInvoices.SelectedTab.Name

                'Case Me.tpgDrugs.Name
                '    Me.lblBillForItem.Text = "Bill for " + Me.tpgDrugs.Text
                '    Me.CalculateBillForDrugs()

                '    Me.ShowToOrder(oItemCategoryID.Drug)
                '    Me.ShowToExpire(oItemCategoryID.Drug)

                'Case Me.tpgConsumables.Name
                '    Me.lblBillForItem.Text = "Bill for " + Me.tpgConsumables.Text
                '    Me.CalculateBillForConsumables()

                '    Me.ShowToOrder(oItemCategoryID.Consumable)
                '    Me.ShowToExpire(oItemCategoryID.Consumable)

                Case Me.tpgOthers.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgOthers.Text
                    Me.CalculateBillForOtherItems()

                Case Else
                    Me.lblBillForItem.Text = "Bill for "
                    Me.pnlBill.Visible = False
                    ResetControlsIn(Me.pnlBill)

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function AllSaved() As Boolean

        Try



            Dim message As String = "Please ensure that all items are saved on "
            Dim ServiceInvoiceNo As String = StringMayBeEnteredIn(Me.stbServiceInvoiceNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(ServiceInvoiceNo) Then Return True

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'For Each page As TabPage In Me.tbcServiceInvoices.TabPages

            '    Select Case page.Name


            '        Case Me.tpgDrugs.Name
            '            For Each row As DataGridViewRow In Me.dgvDrugs.Rows
            '                If row.IsNewRow Then Exit For
            '                If Not BooleanMayBeEnteredIn(row.Cells, Me.colDrugsSaved) Then
            '                    DisplayMessage(message + Me.tpgDrugs.Text)
            '                    Me.tbcServiceInvoices.SelectTab(Me.tpgDrugs)
            '                    Me.BringToFront()
            '                    If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
            '                    Return False
            '                End If
            '            Next

            '        Case Me.tpgConsumables.Name
            '            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
            '                If row.IsNewRow Then Exit For
            '                If Not BooleanMayBeEnteredIn(row.Cells, Me.colConsumablesSaved) Then
            '                    DisplayMessage(message + Me.tpgConsumables.Text)
            '                    Me.tbcServiceInvoices.SelectTab(Me.tpgConsumables)
            '                    Me.BringToFront()
            '                    If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
            '                    Return False
            '                End If
            '            Next

            '    End Select
            'Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return True

        End Try

    End Function


#End Region

#Region " SUPPLIERS"

    Private Sub LoadSuppliers()

        Dim oSuppliers As New SyncSoft.SQLDb.Suppliers()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from Suppliers

            suppliers = oSuppliers.GetSuppliers().Tables("Suppliers")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboSupplierNo, suppliers, "SupplierFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearSupplierName(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSupplierNo.SelectedIndexChanged, cboSupplierNo.TextChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ClearControls()
    End Sub

    Private Sub cboSupplierNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSupplierNo.Leave

        Dim supplierName As String

        Try
            Dim supplierNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboSupplierNo)))

            Me.cboSupplierNo.Text = FormatText(supplierNo, "Suppliers", "SupplierNo")

            If String.IsNullOrEmpty(supplierNo) Then Return

            For Each row As DataRow In suppliers.Select("SupplierNo = '" + supplierNo + "'")

                If Not IsDBNull(row.Item("SupplierName")) Then
                    supplierName = StringEnteredIn(row, "SupplierName")
                    supplierAddress = StringMayBeEnteredIn(row, "Address")
                    supplierNo = StringMayBeEnteredIn(row, "SupplierNo")
                    Me.cboSupplierNo.Text = FormatText(supplierNo.ToUpper(), "Suppliers", "SupplierNo")
                Else
                    supplierName = String.Empty
                    supplierAddress = String.Empty
                    supplierNo = String.Empty
                End If

                Me.stbSupplierName.Text = supplierName
            Next

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

#End Region

#Region " DEFAULT SETTINGS"

    Private Sub SetDefaultShipToAddress()

        Try

            Dim oProductOwner As ProductOwner = GetProductOwnerInfo()
            Me.stbShipAddress.Clear()
            Me.stbShipAddress.Text += AppData.ProductOwner.ToUpper() + ControlChars.NewLine
            If Not String.IsNullOrEmpty(oProductOwner.Address) Then Me.stbShipAddress.Text += oProductOwner.Address + ControlChars.NewLine
            If Not String.IsNullOrEmpty(oProductOwner.Phone) Then Me.stbShipAddress.Text += "Tel: " + oProductOwner.Phone + ControlChars.NewLine

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub stbServiceInvoiceNo_Enter(sender As System.Object, e As System.EventArgs) Handles stbServiceInvoiceNo.Enter

        Try
            currentAllSaved = Me.AllSaved()
            If Not currentAllSaved Then
                currentServiceInvoiceNo = StringMayBeEnteredIn(Me.stbServiceInvoiceNo)
                ProcessTabKey(True)
            Else : currentServiceInvoiceNo = String.Empty
            End If

        Catch ex As Exception
            currentServiceInvoiceNo = String.Empty
        End Try

    End Sub

    Private Sub stbServiceInvoiceNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbServiceInvoiceNo.TextChanged

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not currentAllSaved AndAlso Not String.IsNullOrEmpty(currentServiceInvoiceNo) Then
            Me.stbServiceInvoiceNo.Text = currentServiceInvoiceNo
            Return
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.CallOnKeyEdit()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub stbServiceInvoiceNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbServiceInvoiceNo.Leave

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() AndAlso Not String.IsNullOrEmpty(currentServiceInvoiceNo) Then
            Me.stbServiceInvoiceNo.Text = currentServiceInvoiceNo
            Return
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub


#End Region

#Region " CONTROLS"

    Private Sub ClearControls()
        Me.stbSupplierName.Clear()
        supplierAddress = String.Empty
    End Sub

    Private Sub ResetTabControls()

        'ResetControlsIn(Me.tpgDrugs)
        'ResetControlsIn(Me.tpgConsumables)
        ResetControlsIn(Me.tpgOthers)
    End Sub

#End Region

End Class