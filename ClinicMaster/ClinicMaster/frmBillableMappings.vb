
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
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmBillableMappings

#Region " Fields "
    Private defaultItemCode As String = String.Empty
    Private defaultItemCategoryID As String = String.Empty

    Private _MappedTypeValue As String = String.Empty
    Private saved As Boolean = False
#End Region

    Private Sub frmBillableMappings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.colMappedTypeID, LookupObjects.MappedType, False)
            LoadLookupDataCombo(Me.cboItemCategoryID, LookupObjects.ItemCategory, False)

            LoadDefaultData()


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Public Sub LoadDefaultData()
        Try
            LoadAllAgents()
            If Not String.IsNullOrEmpty(defaultItemCode) Then
                Me.stbItemCode.Text = defaultItemCode


            End If

            If Not String.IsNullOrEmpty(defaultItemCategoryID) Then
                Me.cboItemCategoryID.SelectedValue = defaultItemCategoryID


            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmBillableMappings_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        saved = False
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oBillableMappings As New SyncSoft.SQLDb.BillableMappings()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            ' oBillableMappings.ItemCategoryID = StringEnteredIn(Me.stbItemCategoryID, "Item Category!")
            oBillableMappings.ItemCode = StringEnteredIn(Me.stbItemCode, "ItemCode!")

            DisplayMessage(oBillableMappings.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click
        Dim oBillableMappings As New SyncSoft.SQLDb.BillableMappings()


        Try
            Me.Cursor = Cursors.WaitCursor()
            Dim itemCategoryID As String = RevertText(StringValueEnteredIn(Me.cboItemCategoryID, "Item Category ID!"))
            Dim itemCode As String = RevertText(StringEnteredIn(Me.stbItemCode, "Item Code!"))
           
            LoadBillableMappings(itemCategoryID, itemCode)


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

        'Dim itemCategoryID As String
        'Dim itemCode As String
        'Dim rowNo As Integer


        'Dim oBillableMappings As New SyncSoft.SQLDb.BillableMappings()
        'Dim cells As DataGridViewCellCollection = Me.dgvBillableMappings.Rows(rowNo).Cells
        'Try
        '    Me.Cursor = Cursors.WaitCursor()

        '    itemCategoryID = StringValueEnteredIn(Me.cboItemCategoryID, "Item Category!")
        '    itemCode = StringEnteredIn(Me.stbItemCode, "ItemCode!")
        '    Dim mappedCode As String = StringEnteredIn(cells, Me.colMappedCode, "Mapped Code!")
        '    Dim BillableMappings As DataTable = oBillableMappings.GetBillableMappings(itemCategoryID, itemCode, mappedCode).Tables("BillableMappings")


        '    If BillableMappings Is Nothing OrElse BillableMappings.Rows.Count < 1 Then Return
        '    For Each row As DataRow In BillableMappings.Rows

        '        Me.stbItemCode.Text = StringMayBeEnteredIn(row, "ItemCode")

        '        LoadGridData(Me.dgvBillableMappings, BillableMappings)
        '    Next

        'Catch ex As Exception
        '    ErrorMessage(ex)

        'Finally
        '    Me.Cursor = Cursors.Default()

        'End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim lBillableMappings As New List(Of DBConnect)

            Dim ItemCategoryID As String = StringValueEnteredIn(Me.cboItemCategoryID, "Item Category!")
            Dim ItemCode As String = RevertText(StringEnteredIn(Me.stbItemCode, "ItemCode!"))
            Dim AgentNo As String = StringValueEnteredIn(Me.cboAgentNo, "Agent No!")

            ValidateDimensions(ItemCategoryID)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvBillableMappings.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvBillableMappings.Rows(rowNo).Cells

                Try

                    Using oBillableMappings As New SyncSoft.SQLDb.BillableMappings()
                        With oBillableMappings
                            .ItemCategoryID = ItemCategoryID
                            .ItemCode = ItemCode
                            .AgentNo = AgentNo
                            .MappedTypeID = StringEnteredIn(cells, Me.colMappedTypeID)
                            .MappedCode = StringEnteredIn(cells, Me.colMappedCode, "Mapped Code!")
                            .LoginID = CurrentUser.LoginID

                        End With

                        lBillableMappings.Add(oBillableMappings)
                        oBillableMappings.Save()


                    End Using

                    
                    Me.dgvBillableMappings.Item(Me.colMappedCodeSaved.Name, rowNo).Value = True


                Catch ex As Exception
                    Throw ex
                End Try
            Next

            DisplayMessage("Operation Successful")
            If Not String.IsNullOrEmpty(Me.defaultItemCode) Then
                saved = True
                Me.Close()
            End If
            

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Function MappedCodesList() As List(Of DBConnect)

        Dim lBillableMappings As New List(Of DBConnect)


        Try

            Dim itemCode As String = StringEnteredIn(Me.stbItemCode, "Item Code!")
            Dim itemCategoryID As String = RevertText(StringEnteredIn(Me.cboItemCategoryID, "Item Category!"))

            For rowNo As Integer = 0 To Me.dgvBillableMappings.RowCount - 2

                Using oBillableMappings As New SyncSoft.SQLDb.BillableMappings()

                    Dim cells As DataGridViewCellCollection = Me.dgvBillableMappings.Rows(rowNo).Cells

                    With oBillableMappings


                        .MappedTypeID = StringMayBeEnteredIn(cells, Me.colMappedTypeID)
                        .MappedCode = StringEnteredIn(cells, Me.colMappedCode, "Mapped Code!")

                    End With

                    lBillableMappings.Add(oBillableMappings)

                End Using

            Next

            Return lBillableMappings

        Catch ex As Exception
            ' Me.tbcBillExcludedItems.SelectTab(Me.tpgBillCustomFee.Name)
            Throw ex

        End Try

    End Function

    Public Sub LoadBillableMappings(itemCategoryID As String, itemCode As String)

        Dim oBillableMappings As New SyncSoft.SQLDb.BillableMappings()


        Try

            Me.dgvBillableMappings.Rows.Clear()

            ' Load billable mappings
           
            Dim agentNo As String = RevertText(StringValueEnteredIn(Me.cboAgentNo, "Agent No!"))
            Dim billableMappings As DataTable = oBillableMappings.GetBillableMappingsByItemCategoryItemCode(itemCategoryID, itemCode, agentNo).Tables("BillableMappings")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not (billableMappings Is Nothing OrElse billableMappings.Rows.Count < 1) Then
                For pos As Integer = 0 To billableMappings.Rows.Count - 1

                    Dim row As DataRow = billableMappings.Rows(pos)

                    With Me.dgvBillableMappings
                        ' Ensure that you add a new row
                        .Rows.Add()

                        .Item(Me.colMappedCode.Name, pos).Value = StringEnteredIn(row, "MappedCode")
                        .Item(Me.colMappedTypeID.Name, pos).Value = StringEnteredIn(row, "MappedTypeID")
                        .Item(Me.colMappedCodeSaved.Name, pos).Value = True
                    End With
                Next

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.DisplayData(billableMappings)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        ResetControlsIn(Me)

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = True
            Me.fbnDelete.Enabled = dataSource.Rows.Count > 0
            ebnSaveUpdate.Enabled = True

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
        End If
    End Sub

#End Region


    Private Sub ClearControls()
        Me.cboAgentNo.SelectedIndex = -1
        Me.stbItemCode.Clear()

        Me.dgvBillableMappings.Rows.Clear()
    End Sub


    Private Sub dgvBillableMappings_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillableMappings.CellClick
        If Me.colMappedTypeID.Items.Count < 1 Then Return
        If e.ColumnIndex.Equals(Me.colMappedCode.Index) Then
            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvBillableMappings.Rows(e.RowIndex).Cells, Me.colMappedTypeID)
            If String.IsNullOrEmpty(enteredItem) Then Return
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem(GetLookupDataDes(enteredItem), "Dimension No", "Dimension Name", Me.GetDimensions(enteredItem), "AdmissionFullName",
                                                             "DimensionCode", "DimensionName", Me.dgvBillableMappings, Me.colMappedCode, e.RowIndex)
            fSelectItem.ShowDialog()

        End If
    End Sub

   

    Private Sub dgvBillableMappings_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillableMappings.CellEndEdit
        Try

            If Me.colMappedTypeID.Items.Count < 1 Then Return
            Dim BillableMappingselectedRow As Integer = Me.dgvBillableMappings.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colMappedTypeID.Index) Then

                ' Ensure unique entry in the combo column


                Dim BillableMappingselectedItem As String = StringMayBeEnteredIn(Me.dgvBillableMappings.Rows(BillableMappingselectedRow).Cells, Me.colMappedTypeID)

                For rowNo As Integer = 0 To Me.dgvBillableMappings.RowCount - 1

                    Dim MappedType As String = StringMayBeEnteredIn(Me.dgvBillableMappings.Rows(rowNo).Cells, Me.colMappedTypeID)

                    If MappedType.Equals(GetLookupDataDes(BillableMappingselectedItem)) Then
                        DisplayMessage("Mapped Item (" + MappedType + ") already entered!")
                        Me.dgvBillableMappings.Item(Me.colMappedTypeID.Name, BillableMappingselectedRow).Value = _MappedTypeValue
                        Me.dgvBillableMappings.Item(Me.colMappedTypeID.Name, BillableMappingselectedRow).Selected = True
                    End If

                Next


                If Me.dgvBillableMappings.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvBillableMappings.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvBillableMappings.Rows(selectedRow).Cells, Me.colMappedTypeID)

                    If CBool(Me.dgvBillableMappings.Item(Me.colMappedCodeSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Mapped Type (" + _MappedTypeValue + ") can't be edited!")
                        Me.dgvBillableMappings.Item(Me.colMappedTypeID.Name, selectedRow).Value = _MappedTypeValue
                        Me.dgvBillableMappings.Item(Me.colMappedTypeID.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvBillableMappings.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvBillableMappings.Rows(rowNo).Cells, Me.colMappedTypeID)
                            If enteredItem.Equals(selectedItem) Then
                                DisplayMessage("Mapped Type (" + enteredItem + ") already entered!")
                                Me.dgvBillableMappings.Item(Me.colMappedTypeID.Name, selectedRow).Value = _MappedTypeValue
                                Me.dgvBillableMappings.Item(Me.colMappedTypeID.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                End If
                Me.dgvBillableMappings.Item(Me.colMappedCode.Name, e.RowIndex).Value = String.Empty
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub LoadAllAgents()

        Dim oINTAgents As New SyncSoft.SQLDb.INTAgents()


        Try
            Me.Cursor = Cursors.WaitCursor



            Dim _IntAgents As DataTable = oINTAgents.GetINTAgents().Tables("INTAgents")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With cboAgentNo
                .DataSource = _IntAgents
                .DisplayMember = "AgentName"
                .ValueMember = "AgentNo"
                If _IntAgents.Rows.Count() > 0 Then .SelectedIndex = 0
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception

        End Try

    End Sub


    Private Function GetDimensions(dimensionType As String) As DataTable
        Dim oDimensions As New Dimensions()
        Dim dimensions As New DataTable
        Try
            Return oDimensions.GetDimensionByDimensionTypeID(dimensionType).Tables("Dimensions")
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function IsSaved() As Boolean
        Return Me.saved

    End Function


    Private Sub ValidateDimensions(itemCategoryID As String)
        Dim oMappedTypeID As New LookupDataID.MappedTypeID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID
        Dim message As String = String.Empty
        Dim rowCount As Integer = dgvBillableMappings.Rows.Count()
        Dim lMappedTypeID As New List(Of String)
        Dim lErrors As New List(Of String)
        If rowCount < 2 Then Throw New Exception("You must enter atleast one dimension")
        For rowNo As Integer = 0 To rowCount - 2
            Dim cells As DataGridViewCellCollection = Me.dgvBillableMappings.Rows(rowNo).Cells
            lMappedTypeID.Add(StringEnteredIn(cells, Me.colMappedTypeID))
        Next
        

        If Not lMappedTypeID.Contains(oMappedTypeID.GenProdPostingGroup) Then
            Throw New Exception("You must enter General product Posting group")
        End If
        If itemCategoryID.Equals(oItemCategoryID.Drug) Then
            If Not lMappedTypeID.Contains(oMappedTypeID.Family) Then
                lErrors.add("Family")

            End If
        Else
            If Not lMappedTypeID.Contains(oMappedTypeID.Family) Then
                lErrors.Add("Family")

            End If
            If Not lMappedTypeID.Contains(oMappedTypeID.Department) Then
                lErrors.Add("Department")

            End If
            If Not lMappedTypeID.Contains(oMappedTypeID.Account) Then

                lErrors.Add("Account")

            End If
        End If

        For index As Integer = 0 To lErrors.Count - 1
            message += lErrors.Item(index)
            If (index < lErrors.Count - 1) Then
                message += ", "
            End If
        Next


        If Not String.IsNullOrEmpty(message) Then Throw New Exception("You must enter: " + message + " for " + GetLookupDataDes(itemCategoryID))
    End Sub

    Private Sub dgvBillableMappings_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillableMappings.CellContentClick

    End Sub

    Private Sub dgvBillableMappings_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvBillableMappings.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
        Return
    End Sub

    Private Sub dgvBillableMappings_UserDeletingRow(sender As Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvBillableMappings.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oBillableMapping As New SyncSoft.SQLDb.BillableMappings()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvBillableMappings.Item(Me.colMappedCodeSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return
         

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim mappedTypeID As String = CStr(Me.dgvBillableMappings.Item(Me.colMappedTypeID.Name, toDeleteRowNo).Value)
            Dim itemCode As String = StringEnteredIn(Me.stbItemCode, "Item Code!")
            Dim itemCategoryID As String = StringValueEnteredIn(Me.cboItemCategoryID, "Item Category!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oBillableMapping
                .ItemCategoryID = itemCategoryID
                .MappedTypeID = mappedTypeID
                .ItemCode = itemCode
            End With

            DisplayMessage(oBillableMapping.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub
End Class