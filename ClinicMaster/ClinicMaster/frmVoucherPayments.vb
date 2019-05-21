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

Public Class frmVoucherPayments

    Dim oVariousOptions As New VariousOptions()
#Region " Fields "

    Private defaultPurchaseOrderNo As String = String.Empty

    Private suppliers As DataTable

    Private currentAllSaved As Boolean = True
    Private currentPurchaseOrderNo As String = String.Empty

    Private supplierAddress As String = String.Empty

    Private _DrugNo As String = String.Empty
    Private _OtherItems As String = String.Empty
    Private _ConsumableNo As String = String.Empty

    Private oItemCategoryID As New LookupDataID.ItemCategoryID()
    Private oStockTypeID As New LookupDataID.StockTypeID()

    Private WithEvents docPurchaseOrders As New PrintDocument()

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

    Private Sub frmVoucherPayments_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadSuppliers()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub


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

End Class