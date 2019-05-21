
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmOtherItems


#Region " Fields "
    Private categories As DataTable
    Private items As DataTable
    Private noCallOnKeyEdit As Boolean = False
    Private OVariousOptions As New VariousOptions()
#End Region

Private Sub frmOtherItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()


            LoadLookupDataCombo(Me.cboLocationID, LookupObjects.Location, False)
            LoadLookupDataCombo(Me.cboGroupsID, LookupObjects.Groups, False)
            LoadLookupDataCombo(Me.fcbUnitMeasurID, LookupObjects.UnitMeasure, False)
            Me.LoadOtherItems()
            Me.LoadchartOfAccountsCategory()
            Me.SetNextItemCode()

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

    End Sub

    Private Sub LoadchartOfAccountsCategory()

        If OVariousOptions.EnableClinicMasterFinanceItengration() Then
            LoadchartAccounts(Me.cboItemCategoryID)
        Else
            LoadLookupDataCombo(Me.cboItemCategoryID, LookupObjects.AssetCategory, False)
        End If

    End Sub


    Private Sub SetNextItemCode()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oVariousOptions As New VariousOptions()
            Dim oOtherItems As New SyncSoft.SQLDb.OtherItems
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("OtherItems", "ItemCode").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim otherItemsPrefix As String = oVariousOptions.OtherItemsPrefix
            Dim nextItemCode As String = CStr(oOtherItems.GetNextItemID).PadLeft(paddingLEN, paddingCHAR)
            Me.cboItemCode.Text = FormatText((otherItemsPrefix + nextItemCode).Trim(), "OtherItems", "ItemCode")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadOtherItems()

        Dim otheritems As New SyncSoft.SQLDb.OtherItems
         Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from other items
            items = otheritems.GetOtherItems().Tables("OtherItems")


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadOtherItems(ByVal populate As Boolean)

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If populate Then
                LoadComboData(Me.cboItemCode, items, "ItemFullName")
            Else : Me.cboItemCode.Items.Clear()
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboItemCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles cboItemCode.TextChanged
        If Not noCallOnKeyEdit Then Me.CallOnKeyEdit()
    End Sub

    Private Sub cboItemCode_Leave(sender As System.Object, e As System.EventArgs) Handles cboItemCode.Leave
        Try

            Dim itemCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboItemCode)).ToUpper()
            Me.cboItemCode.Text = itemCode.ToUpper()

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then Return

            For Each row As DataRow In items.Select("ItemCode = '" + itemCode + "'")
                Me.stbItemName.Text = StringMayBeEnteredIn(row, "ItemName")
            Next

        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub


Private Sub frmOtherItems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub

Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

Dim oOtherItems As New SyncSoft.SQLDb.OtherItems()

	Try
		Me.Cursor = Cursors.WaitCursor()

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oOtherItems.ItemCode = SubstringRight(RevertText(StringEnteredIn(Me.cboItemCode, "ItemCode!")))

		DisplayMessage(oOtherItems.Delete())
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

Dim itemCode As String

Dim oOtherItems As New SyncSoft.SQLDb.OtherItems()

	Try
		Me.Cursor = Cursors.WaitCursor()

            itemCode = SubstringRight(RevertText(StringEnteredIn(Me.cboItemCode, "ItemCode!")))

		Dim dataSource As DataTable = oOtherItems.GetOtherItems(itemCode).Tables("OtherItems")
		Me.DisplayData(dataSource)

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

Dim oOtherItems As New SyncSoft.SQLDb.OtherItems()

	Try
		Me.Cursor = Cursors.WaitCursor()

            With oOtherItems


                .ItemCode = SubstringLeft(RevertText(StringEnteredIn(Me.cboItemCode, "ItemCode!"))).ToUpper
                .ItemName = StringEnteredIn(Me.stbItemName, "ItemName!")
                .ItemCategoryID = StringValueEnteredIn(Me.cboItemCategoryID, "ItemCategoryID!")
                 .UnitCost = Me.nbxUnitCost.GetDecimal(False)
                .Quantity = Me.nbxQuantity.GetInteger()
                .Details = StringEnteredIn(Me.stbDetails, "Details!")
                .LocationID = StringValueEnteredIn(Me.cboLocationID, "LocationID!")
                .Hidden = Me.chkHidden.Checked
                .LoginID = CurrentUser.LoginID
                .GroupsID = StringValueEnteredIn(Me.cboGroupsID, "Item Group!")
                .UnitMeasureID = StringValueEnteredIn(Me.fcbUnitMeasurID, "Unit Measure!")
                .VATPercentage = DecimalMayBeEnteredIn(nbxVATPercentage)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

		Select Case Me.ebnSaveUpdate.ButtonText

		Case ButtonCaption.Save

		oOtherItems.Save()

		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    Me.SetNextItemCode()
		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		Case ButtonCaption.Update

		DisplayMessage(oOtherItems.Update())
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
        Me.LoadOtherItems(True)
        Me.cboItemCode.Enabled = True
	ResetControlsIn(Me)

End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.cboItemCode.Enabled = False
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False
        Me.LoadOtherItems(False)
        ResetControlsIn(Me)
        Me.SetNextItemCode()
        Me.cboItemCode.Enabled = Not InitOptions.NonMedicalItemCodeLocked
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

 
End Class