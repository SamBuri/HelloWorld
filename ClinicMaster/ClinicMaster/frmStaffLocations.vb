
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmStaffLocations

#Region " Fields "

#End Region

Private Sub frmStaffLocations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()
            LoadLookupDataCombo(Me.cboLocationID, LookupObjects.BranchID, False)
	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub frmStaffLocations_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub

Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

Dim oStaffLocations As New SyncSoft.SQLDb.StaffLocations()

	Try
		Me.Cursor = Cursors.WaitCursor()

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

		oStaffLocations.StaffLoginID = StringEnteredIn(Me.stbStaffLoginID, "StaffLoginID!")
            oStaffLocations.LocationID = StringValueEnteredIn(Me.cboLocationID, "LocationID!")
		oStaffLocations.StartDate = DateEnteredIn(Me.dtpStartDate, "StartDate!")

		DisplayMessage(oStaffLocations.Delete())
		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		ResetControlsIn(Me)
		Me.CallOnKeyEdit()

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

    End Sub


    Private Sub ShowLoginNameDetails(ByVal loginID As String)

        Dim oStaff As New SyncSoft.SQLDb.Staff

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            Dim assets As DataTable = oStaff.GetLoginName(loginID).Tables("Logins")
            Dim row As DataRow = assets.Rows(0)

            Me.stbStaffName.Text = StringMayBeEnteredIn(row, "FullName")
            Me.stbLoginLevel.Text = StringMayBeEnteredIn(row, "LoginRole")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearControls()
        Me.stbStaffName.Clear()
    End Sub

Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        'Dim staffLoginID As String
        'Dim locationID As String
        'Dim startDate As Date

        'Dim oStaffLocations As New SyncSoft.SQLDb.StaffLocations()

        '	Try
        '		Me.Cursor = Cursors.WaitCursor()

        '		staffLoginID = StringEnteredIn(Me.stbStaffLoginID, "StaffLoginID!")
        '            locationID = StringValueEnteredIn(Me.cboLocationID, "LocationID!")
        '		startDate = DateEnteredIn(Me.dtpStartDate, "StartDate!")

        '		Dim dataSource As DataTable = oStaffLocations.GetStaffLocations(staffLoginID, locationID, startDate).Tables("StaffLocations")
        '		Me.DisplayData(dataSource)

        '	Catch ex As Exception
        '		ErrorMessage(ex)

        '	Finally
        '		Me.Cursor = Cursors.Default()

        '	End Try

End Sub

Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

Dim oStaffLocations As New SyncSoft.SQLDb.StaffLocations()

	Try
		Me.Cursor = Cursors.WaitCursor()

            With oStaffLocations

                .StaffLoginID = StringEnteredIn(Me.stbStaffLoginID, "StaffLoginID!")
                .LocationID = StringValueEnteredIn(Me.cboLocationID, "LocationID!")
                .StartDate = DateEnteredIn(Me.dtpStartDate, "StartDate!")
                .Notes = StringEnteredIn(Me.stbNotes, "Notes!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

		Select Case Me.ebnSaveUpdate.ButtonText

		Case ButtonCaption.Save

		oStaffLocations.Save()

		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		ResetControlsIn(Me)
		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		Case ButtonCaption.Update

		DisplayMessage(oStaffLocations.Update())
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

    Private Sub stbStaffLoginID_Leave(sender As System.Object, e As System.EventArgs) Handles stbStaffLoginID.Leave
        Try

            Dim loginID As String = RevertText(StringMayBeEnteredIn(Me.stbStaffLoginID))
            ErrProvider.Clear()
            If String.IsNullOrEmpty(loginID) Then Return
            Me.ShowLoginNameDetails(loginID)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub
End Class