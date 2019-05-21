
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports SyncSoft.SQLDb.Lookup
Imports SyncSoft.SQLDb
Imports System.Collections.Generic
Imports SyncSoft.Common.SQL.Classes

Public Class frmLookupDataMappings

#Region " Fields "
    Private Const searchCHAR As Char = CChar(">")
    Private Const splitCHAR As Char = CChar(",")
    'Private oAppData As New AppData()
    Private dsLookupData As DataSet
    Private oLookupData As New SyncSoft.Lookup.SQL.LookupData()

#End Region

Private Sub frmLookupDataMappings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.LoadLookupObjects()

            Me.LoadAllAgents()

            Me.Cursor = Cursors.WaitCursor

           

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmLookupDataMappings_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        'Dim oLookupDataMappings As New SyncSoft.Lookup.SQL.LookupDataMappings()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            'DisplayMessage(oLookupDataMappings.Delete())
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


        Dim oLookupDataMappings As New SyncSoft.Lookup.SQL.LookupObjects()

        Try
            Me.Cursor = Cursors.WaitCursor()

            'dataID = StringEnteredIn(Me.stbDataID, "Data ID!")
            'agentDataID = StringEnteredIn(Me.stbAgentDataID, "Agent Data ID!")

            'Dim dataSource As DataTable = oLookupDataMappings.GetLookupDataMappings(dataID, agentDataID).Tables("LookupDataMappings")
            'Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click


        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim lLookupDataMappings As New List(Of DBConnect)
            Dim transactions As New List(Of TransactionList(Of DBConnect))
            Dim oLookupData As New SyncSoft.Lookup.SQL.LookupData()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False
            For Each row As DataGridViewRow In Me.dgvLookupDataMappings.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvLookupDataMappings.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If Me.dgvLookupDataMappings.RowCount < 1 OrElse nonSelected Then Throw New ArgumentException("Must include at least one item to map!")
            Dim objectName As String = StringValueEnteredIn(Me.cboObjectName, "Lookup Object Name!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvLookupDataMappings.Rows.Count - 1


                Using oLookupDataMappings As New SyncSoft.SQLDb.LookupDataMappings()

                    Dim cells As DataGridViewCellCollection = Me.dgvLookupDataMappings.Rows(rowNo).Cells

                    Dim include As Boolean = CBool(BooleanMayBeEnteredIn(cells, colInclude))

                    If include Then

                        Dim dataID As String = StringEnteredIn(cells, Me.colDataID, "Data ID!")
                        Dim agentDataID As String = StringEnteredIn(cells, Me.colAgentDataID, "Agent Data ID!")
                        Dim agentNo As String = StringMayBeEnteredIn(cells, Me.colAgentNo)

                        With oLookupDataMappings
                            .ObjectName = objectName
                            .DataID = dataID
                            .AgentDataID = agentDataID
                            .AgentNo = agentNo
                            .LoginID = CurrentUser.LoginID
                            .UserName = CurrentUser.FullName



                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            ValidateEntriesIn(Me)
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            lLookupDataMappings.Add(oLookupDataMappings)

                        End With


                    End If
                End Using

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me)
           
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lLookupDataMappings, Action.Save))
            DoTransactions(transactions)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

#Region " Edit Methods "

Public Sub Edit()

	Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
	Me.ebnSaveUpdate.Enabled = False
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
End If
End Sub

#End Region


    Private Sub LoadLookupData()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim objectName As String = StringValueMayBeEnteredIn(cboObjectName)


            Me.dgvLookupDataMappings.Rows.Clear()


            Dim dataSource As New DataTable
            Dim dataID As String = String.Empty
            Dim dataDes As String = String.Empty
            Dim oLookupData As New SyncSoft.Lookup.SQL.LookupData()
            Dim olookupObjects As New SyncSoft.Lookup.SQL.LookupObjects()
            Dim dataIDColumn As String = String.Empty
            Dim dataDescriptionColumn As String = String.Empty
            Dim selectedObject As String = StringValueMayBeEnteredIn(cboObjectName)

            If String.IsNullOrEmpty(selectedObject) Then Return
            Dim objectID As Integer = CInt(selectedObject)
            dataSource = oLookupData.GetLookupData(objectID).Tables("LookupData")
            dataIDColumn = "DataID"
            dataDescriptionColumn = "DataDes"

            Dim rowCount As Integer = dataSource.Rows.Count()

            For row As Integer = 0 To rowCount - 1
                Me.dgvLookupDataMappings.Rows.Add()
                Dim rowIndex As DataRow = dataSource.Rows(row)
                dataID = StringEnteredIn(rowIndex, dataIDColumn)
                dataDes = StringEnteredIn(rowIndex, dataDescriptionColumn)

                Me.dgvLookupDataMappings.Item(Me.colInclude.Name, row).Value = True
                Me.dgvLookupDataMappings.Item(Me.colDataID.Name, row).Value = dataID
                Me.dgvLookupDataMappings.Item(Me.colDataDes.Name, row).Value = dataDes

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    

    Private Sub LoadLookupObjects()
        Try
            Dim olookupObjects As New SyncSoft.Lookup.SQL.LookupObjects()
            Dim lookupObjects As New DataTable()
            lookupObjects = olookupObjects.GetLookupObjects.Tables("LookupObjects")

            Me.cboObjectName.DataSource = lookupObjects
            Me.cboObjectName.ValueMember = "ObjectID"
            Me.cboObjectName.DisplayMember = "ObjectName"

            Me.cboObjectName.SelectedIndex = -1
            Me.cboObjectName.SelectedIndex = -1
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub LoadAllAgents()

        Dim oINTAgents As New SyncSoft.SQLDb.INTAgents()


        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Agents

            Dim intAgents As DataTable = oINTAgents.GetINTAgents().Tables("INTAgents")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboAgentNo, intAgents, "AgentNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cboObjectName_Leave(sender As System.Object, e As System.EventArgs) Handles cboObjectName.Leave
        Me.LoadLookupData()
    End Sub

    
End Class