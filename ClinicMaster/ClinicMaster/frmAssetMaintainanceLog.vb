
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmAssetMaintainanceLog

#Region " Fields "

#End Region

Private Sub frmAssetMaintainanceLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()



	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub frmAssetMaintainanceLog_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub

Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

Dim oAssetMaintainanceLog As New SyncSoft.SQLDb.AssetMaintainanceLog()

	Try
		Me.Cursor = Cursors.WaitCursor()

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

		oAssetMaintainanceLog.SerialNo = StringEnteredIn(Me.stbSerialNo, "SerialNo!")
		oAssetMaintainanceLog.MaintainanceDate = DateEnteredIn(Me.dtpMaintainanceDate, "MaintainanceDate!")

		DisplayMessage(oAssetMaintainanceLog.Delete())
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

Dim serialNo As String
Dim maintainanceDate As Date

Dim oAssetMaintainanceLog As New SyncSoft.SQLDb.AssetMaintainanceLog()

	Try
		Me.Cursor = Cursors.WaitCursor()

		serialNo = StringEnteredIn(Me.stbSerialNo, "SerialNo!")
		maintainanceDate = DateEnteredIn(Me.dtpMaintainanceDate, "MaintainanceDate!")

		Dim dataSource As DataTable = oAssetMaintainanceLog.GetAssetMaintainanceLog(serialNo, maintainanceDate).Tables("AssetMaintainanceLog")
		Me.DisplayData(dataSource)

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

Dim oAssetMaintainanceLog As New SyncSoft.SQLDb.AssetMaintainanceLog()

	Try
		Me.Cursor = Cursors.WaitCursor()

		With oAssetMaintainanceLog

		.SerialNo = StringEnteredIn(Me.stbSerialNo, "SerialNo!")
		.ActionTaken = StringEnteredIn(Me.stbActionTaken, "ActionTaken!")
		.MaintainanceDate = DateEnteredIn(Me.dtpMaintainanceDate, "MaintainanceDate!")
		.MaintainedBy = StringEnteredIn(Me.stbMaintainedBy, "MaintainedBy!")
		.MaintainaceCost = Me.nbxMaintainaceCost.GetDecimal(False)
		.NextDue = DateEnteredIn(Me.dtpNextDue, "NextDue!")
		.LoginID = CurrentUser.LoginID

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		ValidateEntriesIn(Me)
		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		End With

		Select Case Me.ebnSaveUpdate.ButtonText

		Case ButtonCaption.Save

		oAssetMaintainanceLog.Save()

		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		ResetControlsIn(Me)
		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		Case ButtonCaption.Update

		DisplayMessage(oAssetMaintainanceLog.Update())
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

    Private Sub stbSerialNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbSerialNo.Leave

        Try

            Dim serialNo As String = RevertText(StringMayBeEnteredIn(Me.stbSerialNo))
            ErrProvider.Clear()
            If String.IsNullOrEmpty(serialNo) Then Return
            Me.ShowAssetMaintainanceLogDetails(serialNo)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub ShowAssetMaintainanceLogDetails(ByVal SerialNo As String)

        Dim oAssetAssetRegister As New SyncSoft.SQLDb.AssetRegister

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            Dim assets As DataTable = oAssetAssetRegister.GetAssetRegister(SerialNo).Tables("AssetRegister")
            Dim row As DataRow = assets.Rows(0)

            Me.stbItemDescription.Text = StringMayBeEnteredIn(row, "ItemDescription")
            Me.stbLastServiceDate.Text = StringMayBeEnteredIn(row, "LastAssetServiceDate")
            Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub
    Private Sub ClearControls()
        stbLastServiceDate.Clear()
        stbItemDescription.Clear()
    End Sub
End Class