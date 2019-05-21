
Option Strict On
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmStockCard

#Region " Fields "

    Private defaultItemCategoryID As String = String.Empty
    Private drugs As DataTable
    Private consumableItems As DataTable
    Private oItemCategoryID As New LookupDataID.ItemCategoryID()

#End Region

    Private Sub frmStockCard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dtpStartDateTime.MaxDate = Today.AddDays(1)
            Me.dtpEndDateTime.MaxDate = Today.AddDays(1)

            Me.dtpStartDateTime.Value = Today
            Me.dtpEndDateTime.Value = Now


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then

                Me.Text = "Drug Stock Card"
                Me.lblItemCode.Text = "Drug Number"
                Me.lblItemName.Text = "Drug Name"

                Me.LoadDrugs()

            ElseIf defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then

                Me.Text = "Consumable Stock Card"
                Me.lblItemCode.Text = "Consumable Number"
                Me.lblItemName.Text = "Consumable Name"

                Me.LoadConsumableItems()

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataIn(Me.cboLocationID, LookupObjects.Location, False, "DataDes")
            Me.cboLocationID.Items.Insert(0, String.Empty)
            Me.cboLoginID.Text = CurrentUser.LoginID
            Dim loginID As String = StringMayBeEnteredIn(Me.cboLoginID)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmStockCard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadDrugs()

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from drugs

            With oDrugs
                .DrugNo = String.Empty
                .DrugName = String.Empty
            End With

            ' Load from drugs
            If Not InitOptions.LoadDrugsAtStart Then
                drugs = oDrugs.GetDrugs().Tables("Drugs")
                oSetupData.Drugs = drugs
            Else : drugs = oSetupData.Drugs
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboItemCode, drugs, "DrugFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadInventoryLogins(ByVal startDateTime As Date, ByVal endDateTime As Date)

        Dim oInventory As New SyncSoft.SQLDb.Inventory

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboLoginID.Items.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Load from inventory
            Dim Inventory As DataTable = oInventory.GetInventoryLogins(startDateTime, endDateTime).Tables("Inventory")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboLoginID, Inventory, "LoginID")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadConsumableItems()

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from ConsumableItems

            If Not InitOptions.LoadConsumableItemsAtStart Then
                consumableItems = oConsumableItems.GetConsumableItems().Tables("ConsumableItems")
                oSetupData.ConsumableItems = consumableItems
            Else : consumableItems = oSetupData.ConsumableItems
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboItemCode, consumableItems, "ConsumableFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearControls()

        Me.nbxOpeningLocationUnits.Value = String.Empty
        Me.nbxOpeningBalance.Value = String.Empty

    End Sub

    Private Sub cboItemCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItemCode.Leave

        Try

            Dim itemCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboItemCode)).ToUpper()
            Dim itemName As String = String.Empty

            Me.cboItemCode.Text = itemCode.ToUpper()
            Me.stbItemName.Clear()

            Me.ClearControls()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then

                For Each row As DataRow In drugs.Select("DrugNo = '" + itemCode + "'")
                    itemName = StringMayBeEnteredIn(row, "DrugName")
                Next

            ElseIf defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then

                For Each row As DataRow In consumableItems.Select("ConsumableNo = '" + itemCode + "'")
                    itemName = StringMayBeEnteredIn(row, "ConsumableName")
                Next

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(itemName) Then Me.cboItemCode.Text = itemCode.ToUpper()
            Me.stbItemName.Text = itemName
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub fbnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnLoad.Click

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.cboItemCode_Leave(Me, EventArgs.Empty)
            Dim locationID As String

            Dim startDateTime As Date = DateTimeEnteredIn(Me.dtpStartDateTime, "Start Record Date")
            Dim endDateTime As Date = DateTimeEnteredIn(Me.dtpEndDateTime, "End Record Date")
            Dim itemCode As String = SubstringRight(StringEnteredIn(Me.cboItemCode, Me.lblItemCode.Text))
            Dim location As String = StringMayBeEnteredIn(Me.cboLocationID)
            Dim loginID As String = StringMayBeEnteredIn(Me.cboLoginID)

            If Not String.IsNullOrEmpty(location) Then
                locationID = GetLookupDataID(LookupObjects.Location, location)
            Else : locationID = location
            End If

            Me.ShowStockCard(startDateTime, endDateTime, itemCode, locationID, loginID)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowStockCard(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal itemCode As String, ByVal locationID As String, ByVal loginID As String)

        Dim stockCard As New DataTable()
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Dim oInventory As New SyncSoft.SQLDb.Inventory()



        Try
            Dim message As String

            Me.Cursor = Cursors.WaitCursor
            LoadInventoryLogins(startDateTime, endDateTime)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If endDateTime < startDateTime Then Throw New ArgumentException("End Date can't be before Start Date!")
            ' Load from stockCard

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then

                If Not String.IsNullOrEmpty(locationID) AndAlso String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                    stockCard = oDrugs.GetDrugStockCard(startDateTime, endDateTime, itemCode, locationID, Nothing).Tables("Drugs")

                ElseIf Not String.IsNullOrEmpty(locationID) AndAlso Not String.IsNullOrEmpty(loginID) Then
                    stockCard = oDrugs.GetDrugStockCard(startDateTime, endDateTime, itemCode, locationID, loginID).Tables("Drugs")

                ElseIf Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(locationID) Then
                    stockCard = oDrugs.GetDrugStockCard(startDateTime, endDateTime, itemCode, Nothing, loginID).Tables("Drugs")

                ElseIf String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(locationID) Then
                    stockCard = oDrugs.GetDrugStockCard(startDateTime, endDateTime, itemCode, Nothing, Nothing).Tables("Drugs")

                End If

            ElseIf defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then
                If Not String.IsNullOrEmpty(locationID) AndAlso String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                    stockCard = oConsumableItems.GetConsumableStockCard(startDateTime, endDateTime, itemCode, locationID, Nothing).Tables("ConsumableItems")
                ElseIf Not String.IsNullOrEmpty(locationID) AndAlso Not String.IsNullOrEmpty(loginID) Then
                    stockCard = oConsumableItems.GetConsumableStockCard(startDateTime, endDateTime, itemCode, locationID, loginID).Tables("ConsumableItems")
                ElseIf Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(locationID) Then
                    stockCard = oConsumableItems.GetConsumableStockCard(startDateTime, endDateTime, itemCode, Nothing, loginID).Tables("ConsumableItems")
                ElseIf String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(locationID) Then
                    stockCard = oConsumableItems.GetConsumableStockCard(startDateTime, endDateTime, itemCode, Nothing, Nothing).Tables("ConsumableItems")
                End If
            Else
                If Not String.IsNullOrEmpty(locationID) AndAlso String.IsNullOrEmpty(loginID) Then
                    stockCard = oDrugs.GetDrugStockCard(startDateTime, endDateTime, itemCode, locationID, Nothing).Tables("Drugs")

                ElseIf Not String.IsNullOrEmpty(locationID) AndAlso Not String.IsNullOrEmpty(loginID) Then
                    stockCard = oDrugs.GetDrugStockCard(startDateTime, endDateTime, itemCode, locationID, loginID).Tables("Drugs")

                ElseIf Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(locationID) Then
                    stockCard = oDrugs.GetDrugStockCard(startDateTime, endDateTime, itemCode, Nothing, loginID).Tables("Drugs")

                ElseIf String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(locationID) Then
                    stockCard = oDrugs.GetDrugStockCard(startDateTime, endDateTime, itemCode, Nothing, Nothing).Tables("Drugs")

                Else : stockCard = oDrugs.GetDrugStockCard(startDateTime, endDateTime, itemCode, Nothing, Nothing).Tables("Drugs")

                End If
            End If


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvStockCard, stockCard)
            FormatGridRow(Me.dgvStockCard)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.tbcStockCard.SelectedTab.Name

                Case Me.tpgStockCard.Name

                    If Me.dgvStockCard.RowCount <= 0 Then

                        Dim itemName As String = StringMayBeEnteredIn(Me.stbItemName)

                        If Not String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(itemName) Then
                            message = "No " + Me.tpgStockCard.Text + " record(s) found for period between " + FormatDateTime(startDateTime) +
                                    " and " + FormatDateTime(endDateTime) + " for " + itemName + " and Login ID: " + loginID + "!"


                        ElseIf Not String.IsNullOrEmpty(itemName) AndAlso String.IsNullOrEmpty(loginID) Then
                            message = "No " + Me.tpgStockCard.Text + " record(s) found for period between " + FormatDateTime(startDateTime) +
                                    " and " + FormatDateTime(endDateTime) + " for " + itemName + "!"



                        Else : message = "No " + Me.tpgStockCard.Text + " record(s) found for period between " + FormatDateTime(startDateTime) +
                                " and " + FormatDateTime(endDateTime) + "!"
                        End If

                        DisplayMessage(message)

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Me.ClearControls()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Else
                        Dim openingLocationUnits As Integer = oInventory.GetInventoryStartBalance(locationID, defaultItemCategoryID,
                                                                                                  itemCode, startDateTime)
                        Dim openingBalance As Integer = oInventory.GetInventoryStartBalance(defaultItemCategoryID, itemCode, startDateTime)

                        Me.nbxOpeningLocationUnits.Value = openingLocationUnits.ToString()
                        Me.nbxOpeningBalance.Value = openingBalance.ToString()

                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvStockCard.RowCount
                    Me.fbnExportTo.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = Me.tpgStockCard.Text + " Returned Record(s): " + rowCount.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



    Private Sub fbnExportTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnExportTo.Click

        Dim fStatus As New SyncSoft.Common.Win.Forms.Status()

        Try

            Me.Cursor = Cursors.WaitCursor()

            Dim _objectCaption As String = Me.tbcStockCard.SelectedTab.Text
            Dim startDate As Date = DateEnteredIn(Me.dtpStartDateTime, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDateTime, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim documentTitle As String = "Stock Card for the period between " +
                FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            fStatus.Show("Exporting " + _objectCaption + " to Excel...", FormStartPosition.CenterScreen)

            If Me.tbcStockCard.SelectedTab.Name.Equals(Me.tpgStockCard.Name) Then
                ExportToExcel(Me.dgvStockCard, _objectCaption, documentTitle)
            End If

        Catch ex As Exception
            fStatus.Close()
            ErrorMessage(ex)

        Finally
            fStatus.Close()
            Me.Cursor = Cursors.Default

        End Try

    End Sub


#Region " Stock Card "

    Private Sub cmsStockCard_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsStockCard.Opening

        If Me.dgvStockCard.ColumnCount < 1 OrElse Me.dgvStockCard.RowCount < 1 Then
            Me.cmsCopy.Enabled = False
            Me.cmsSelectAll.Enabled = False
        Else
            Me.cmsCopy.Enabled = True
            Me.cmsSelectAll.Enabled = True
        End If

    End Sub

    Private Sub cmsCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.dgvStockCard.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvStockCard))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvStockCard.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


#End Region


End Class