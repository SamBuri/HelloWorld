
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects



Public Class frmBarCodeDetails

#Region " Fields "

    Private drugs As DataTable
    Private consumableItems As DataTable
    Private defaultItemCategoryID As String = String.Empty
    Private defaultItemCode As String = String.Empty
    Private oItemCategoryID As New LookupDataID.ItemCategoryID()
#End Region

Private Sub frmBarCodeDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()

            If defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then

                Me.Text = "Drugs BarCode"
                Me.lblItemCode.Text = "Drug Number"
                Me.lblItemName.Text = "Drug Name"

          

                Me.LoadDrugs()

            ElseIf defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then

                Me.Text = "Consumables BarCode"
                Me.lblItemCode.Text = "Consumable Number"
                Me.lblItemName.Text = "Consumable Name"


                Me.LoadConsumableItems()

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboItemCode, drugs, "DrugFullName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

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

    Private Sub ShowItemDetails(ByVal itemCode As String)

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim row As DataRow
            Dim itemName As String

            Me.cboItemCode.Text = itemCode.ToUpper()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then

                row = oDrugs.GetDrugs(itemCode).Tables("Drugs").Rows(0)
                itemName = StringMayBeEnteredIn(row, "DrugName")

            ElseIf defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then

                row = oConsumableItems.GetConsumableItems(itemCode).Tables("ConsumableItems").Rows(0)
                itemName = StringMayBeEnteredIn(row, "ConsumableName")

            Else
                row = oDrugs.GetDrugs(itemCode).Tables("Drugs").Rows(0)
                itemName = StringMayBeEnteredIn(row, "DrugName")

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(itemName) Then Me.cboItemCode.Text = itemCode
            Me.stbItemName.Text = itemName
            Me.stbUnitMeasure.Text = StringMayBeEnteredIn(row, "UnitMeasure")
     
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

Private Sub frmBarCodeDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub

Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

Dim oBarCodeDetails As New SyncSoft.SQLDb.BarCodeDetails()

	Try
		Me.Cursor = Cursors.WaitCursor()

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		If DeleteMessage() = Windows.Forms.DialogResult.No Then Return



		DisplayMessage(oBarCodeDetails.Delete())
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



        'Dim oBarCodeDetails As New SyncSoft.SQLDb.BarCodeDetails()

        '	Try
        '		Me.Cursor = Cursors.WaitCursor()



        '		Dim dataSource As DataTable = oBarCodeDetails.GetBarCodeDetails().Tables("BarCodeDetails")
        '		Me.DisplayData(dataSource)

        '	Catch ex As Exception
        '		ErrorMessage(ex)

        '	Finally
        '		Me.Cursor = Cursors.Default()

        '	End Try

End Sub

Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

Dim oBarCodeDetails As New SyncSoft.SQLDb.BarCodeDetails()

	Try
		Me.Cursor = Cursors.WaitCursor()
            With oBarCodeDetails
                .ItemCode = StringEnteredIn(Me.cboItemCode, Me.lblItemCode.Text + "!")
                .ItemCategoryID = defaultItemCategoryID
                .BarCode = StringEnteredIn(Me.stbBarCode, "BarCode!")
                .LoginID = CurrentUser.LoginID
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

		Select Case Me.ebnSaveUpdate.ButtonText

		Case ButtonCaption.Save

		oBarCodeDetails.Save()

		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		ResetControlsIn(Me)
		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		Case ButtonCaption.Update

		DisplayMessage(oBarCodeDetails.Update())
		Me.CallOnKeyEdit()

	End Select

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

    Private Sub cboItemCode_Leave(sender As System.Object, e As System.EventArgs) Handles cboItemCode.Leave
        Try

            Dim itemCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboItemCode)).ToUpper()
            Me.ShowItemDetails(itemCode)
         
        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub ClearControls()

        Me.stbItemName.Clear()
        Me.stbUnitMeasure.Clear()
   

    End Sub

    Private Sub cboItemCode_TextChanged(sender As Object, e As System.EventArgs) Handles cboItemCode.TextChanged
        Me.ClearControls()
    End Sub
End Class