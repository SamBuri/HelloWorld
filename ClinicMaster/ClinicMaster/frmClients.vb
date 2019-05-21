
Option Strict On
Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.Enumerations
Imports SyncSoft.Common.SQL.Enumerations
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona

Imports System.IO
Imports System.Collections.Generic

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Public Class frmClients

#Region " Validations "

    Private Sub ndpBirthDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpBirthDate.Leave
        Try
            SetBirthDateAge(BirthDateAge.SetAge, Me.dtpBirthDate, Me.nbxAge)
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub nbxAge_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbxAge.Leave
        Try
            SetBirthDateAge(BirthDateAge.SetBirthDate, Me.dtpBirthDate, Me.nbxAge)
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

#End Region

#Region " Fields "

#End Region

Private Sub frmClients_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()

		LoadLookupDataCombo(Me.cboGenderID, LookupObjects.Gender, False)
		LoadLookupDataCombo(Me.cboDoctorSpecialtyID, LookupObjects.DoctorSpecialty, False)

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub frmClients_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub


    Private Sub cbodoctorSpecialtyID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDoctorSpecialtyID.SelectedIndexChanged

        Try

            If Me.cboDoctorSpecialtyID.SelectedValue Is Nothing OrElse String.IsNullOrEmpty(Me.cboDoctorSpecialtyID.SelectedValue.ToString()) Then Return

            Dim doctorSpecialtyID As String = StringValueEnteredIn(Me.cboDoctorSpecialtyID, "Doctor Specialty!")
            If String.IsNullOrEmpty(doctorSpecialtyID) Then Return

            Me.LoadStaff(doctorSpecialtyID)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetNextReferenceNo()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oClients As New SyncSoft.SQLDb.Clients()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim yearL2 As String = Today.Year.ToString().Substring(2)
            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Clients", "ReferenceNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim nextCompanyNo As String = CStr(oClients.GetNextClientsReferenceNo).PadLeft(paddingLEN, paddingCHAR)
            Me.stbReferenceNo.Text = FormatText(("R" + yearL2 + nextCompanyNo).Trim(), "Clients", "ReferenceNo")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadStaff(ByVal doctorSpecialtyID As String)

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboStaffNo.Items.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ' Load all from Staff
            Dim staff As DataTable = oStaff.GetStaffByDoctorSpecialty(oStaffTitleID.Doctor, doctorSpecialtyID).Tables("Staff")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")
            Me.cboStaffNo.Items.Insert(0, "")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub

Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

Dim oClients As New SyncSoft.SQLDb.Clients()

	Try
		Me.Cursor = Cursors.WaitCursor()

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oClients.ReferenceNo = RevertText(StringEnteredIn(Me.stbReferenceNo, "ReferenceNo!"))

		DisplayMessage(oClients.Delete())
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

Dim referenceNo As String

Dim oClients As New SyncSoft.SQLDb.Clients()

	Try
		Me.Cursor = Cursors.WaitCursor()

            referenceNo = RevertText(StringEnteredIn(Me.stbReferenceNo, "ReferenceNo!"))

		Dim dataSource As DataTable = oClients.GetClients(referenceNo).Tables("Clients")
		Me.DisplayData(dataSource)

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

Dim oClients As New SyncSoft.SQLDb.Clients()

	Try
		Me.Cursor = Cursors.WaitCursor()

            With oClients


                .ReferenceNo = RevertText(StringEnteredIn(Me.stbReferenceNo, "Reference No!"))
                .FirstName = StringEnteredIn(Me.stbFirstName, "First Name!")
                .LastName = StringEnteredIn(Me.stbLastName, "Last Name!")
                .MiddleName = StringMayBeEnteredIn(Me.stbMiddleName)
                .GenderID = StringValueEnteredIn(Me.cboGenderID, "Gender!")
                .PhoneNo = StringMayBeEnteredIn(Me.stbPhoneNo)
                .BirthDate = DateEnteredIn(Me.dtpBirthDate, "BirthDate!")
                .AppointmentDate = DateEnteredIn(Me.dtpAppointmentDate, "AppointmentDate!")
                .DoctorSpecialtyID = StringValueEnteredIn(Me.cboDoctorSpecialtyID, "Doctor Specialty!")
                If Me.cboStaffNo.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.cboStaffNo.Text) Then
                    .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "To See Doctor!")
                Else : .StaffNo = String.Empty
                End If
                .Description = StringEnteredIn(Me.stbDescription, "Description!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

		Select Case Me.ebnSaveUpdate.ButtonText

		Case ButtonCaption.Save

		oClients.Save()

		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    Me.SetNextReferenceNo()
		''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		Case ButtonCaption.Update

		DisplayMessage(oClients.Update())
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
        Me.dtpAppointmentDate.MinDate = AppData.NullDateValue
        Me.dtpBirthDate.MinDate = AppData.NullDateValue
	ResetControlsIn(Me)

End Sub

Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save

	Me.ebnSaveUpdate.Enabled = True
	Me.fbnDelete.Visible = False
	Me.fbnDelete.Enabled = True
	Me.fbnSearch.Visible = False
        Me.dtpAppointmentDate.MinDate = Today
        Me.dtpBirthDate.MaxDate = Today
        ResetControlsIn(Me)

        Me.SetNextReferenceNo()
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