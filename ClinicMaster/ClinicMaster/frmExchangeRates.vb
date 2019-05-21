

Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations

Imports System.Collections.Generic

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects

Public Class frmExchangeRates

#Region " Fields "

    Private _CurrenciesIDValue As String = String.Empty

#End Region

    Private Sub frmExchangeRates_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.colCurrenciesID, LookupObjects.Currencies)
            Me.LoadExchangeRates()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmExchangeRates_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSave.Click

        Dim message As String
        Dim oCurrenciesID As New LookupDataID.CurrenciesID()
        Dim lExchangeRates As New List(Of DBConnect)
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try

            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvExchangeRates.RowCount <= 1 Then Throw New ArgumentException("Must include at least one entry on exchange rates!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvExchangeRates.RowCount - 2

                Using oExchangeRates As New SyncSoft.SQLDb.ExchangeRates()

                    Dim cells As DataGridViewCellCollection = Me.dgvExchangeRates.Rows(rowNo).Cells

                    Dim currenciesID As String = StringEnteredIn(cells, Me.colCurrenciesID, "Currency!")
                    Dim buying As Decimal = DecimalEnteredIn(cells, Me.colBuying, False, "Buying!")
                    Dim selling As Decimal = DecimalEnteredIn(cells, Me.colSelling, False, "Selling!")

                    If currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                        Throw New ArgumentException(GetLookupDataDes(oCurrenciesID.UgandaShillings) + " value not allowed for currency!")
                    End If

                    If buying = 0 Then Throw New ArgumentException("Zero value not allowed for buying!")
                    If selling = 0 Then Throw New ArgumentException("Zero value not allowed for selling!")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If buying >= selling Then

                        If buying = selling Then
                            message = "Buying equals selling for " + GetLookupDataDes(currenciesID) + ". "
                        Else : message = "Buying is more than selling for " + GetLookupDataDes(currenciesID) + ". "
                        End If
                        message += ControlChars.NewLine + "Are you sure you want to save?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action cancelled!")

                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    With oExchangeRates

                        .CurrenciesID = currenciesID
                        .Buying = buying
                        .Selling = selling
                        .LoginID = CurrentUser.LoginID

                    End With

                    lExchangeRates.Add(oExchangeRates)

                End Using

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lExchangeRates, Action.Save))

            Dim records As Integer = DoTransactions(transactions)
            DisplayMessage(records.ToString() + " record(s) affected!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvExchangeRates.RowCount - 2
                Me.dgvExchangeRates.Item(Me.colExchangeRatesSaved.Name, rowNo).Value = True
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

#Region " Exchange Rates - Grid "

    Private Sub dgvExchangeRates_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvExchangeRates.CellBeginEdit

        If e.ColumnIndex <> Me.colCurrenciesID.Index OrElse Me.dgvExchangeRates.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvExchangeRates.CurrentCell.RowIndex
        _CurrenciesIDValue = StringMayBeEnteredIn(Me.dgvExchangeRates.Rows(selectedRow).Cells, Me.colCurrenciesID)

    End Sub

    Private Sub dgvExchangeRates_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvExchangeRates.CellEndEdit

        Try

            If Me.colCurrenciesID.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colCurrenciesID.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvExchangeRates.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvExchangeRates.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvExchangeRates.Rows(selectedRow).Cells, Me.colCurrenciesID)

                    If CBool(Me.dgvExchangeRates.Item(Me.colExchangeRatesSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Currency (" + GetLookupDataDes(_CurrenciesIDValue) + ") can't be edited!")
                        Me.dgvExchangeRates.Item(Me.colCurrenciesID.Name, selectedRow).Value = _CurrenciesIDValue
                        Me.dgvExchangeRates.Item(Me.colCurrenciesID.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvExchangeRates.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvExchangeRates.Rows(rowNo).Cells, Me.colCurrenciesID)
                            If enteredItem.Equals(selectedItem) Then
                                DisplayMessage("Currency (" + GetLookupDataDes(enteredItem) + ") already entered!")
                                Me.dgvExchangeRates.Item(Me.colCurrenciesID.Name, selectedRow).Value = _CurrenciesIDValue
                                Me.dgvExchangeRates.Item(Me.colCurrenciesID.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvExchangeRates_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvExchangeRates.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oExchangeRates As New SyncSoft.SQLDb.ExchangeRates()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvExchangeRates.Item(Me.colExchangeRatesSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim currenciesID As String = CStr(Me.dgvExchangeRates.Item(Me.colCurrenciesID.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim message As String = "You do not have permission to delete this record!"
            'If Me.fbnDelete.Enabled = False Then
            '    DisplayMessage(message)
            '    e.Cancel = True
            '    Return
            'End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oExchangeRates
                .CurrenciesID = currenciesID
            End With

            DisplayMessage(oExchangeRates.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvExchangeRates_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvExchangeRates.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadExchangeRates()

        Dim oExchangeRates As New SyncSoft.SQLDb.ExchangeRates()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim exchangeRates As DataTable = oExchangeRates.GetExchangeRates().Tables("ExchangeRates")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To exchangeRates.Rows.Count - 1

                Dim row As DataRow = exchangeRates.Rows(rowNo)

                Dim currenciesID As String = StringEnteredIn(row, "CurrenciesID")
                Dim buying As Decimal = DecimalMayBeEnteredIn(row, "Buying")
                Dim selling As Decimal = DecimalMayBeEnteredIn(row, "Selling")

                With Me.dgvExchangeRates

                    .Rows.Add()

                    .Item(Me.colCurrenciesID.Name, rowNo).Value = currenciesID
                    If buying >= 1 Then
                        .Item(Me.colBuying.Name, rowNo).Value = FormatNumber(buying, AppData.DecimalPlaces)
                    Else : .Item(Me.colBuying.Name, rowNo).Value = buying.ToString()
                    End If
                    If selling >= 1 Then
                        .Item(Me.colSelling.Name, rowNo).Value = FormatNumber(selling, AppData.DecimalPlaces)
                    Else : .Item(Me.colSelling.Name, rowNo).Value = selling.ToString()
                    End If
                    .Item(Me.colExchangeRatesSaved.Name, rowNo).Value = True

                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

End Class