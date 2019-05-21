
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona

Public Class frmStaff

#Region " Fields "
    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()
#End Region

    Private Sub frmStaff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.SetNextStaffNo()
            LoadLookupDataCombo(Me.fcbGenderID, LookupObjects.Gender, False)
            LoadLookupDataCombo(Me.fcbStaffTitleID, LookupObjects.StaffTitle, False)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmStaff_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbStaffNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        Me.CallOnKeyEdit()
    End Sub

    Private Sub fcbStaffTitleID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fcbStaffTitleID.SelectedIndexChanged

        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try

            If Me.fcbStaffTitleID.SelectedValue Is Nothing OrElse String.IsNullOrEmpty(Me.fcbStaffTitleID.SelectedValue.ToString()) Then Return

            Dim staffTitleID As String = StringValueEnteredIn(Me.fcbStaffTitleID, "Staff Title!")
            If String.IsNullOrEmpty(staffTitleID) Then Return

            Dim IsDoctor As Boolean = staffTitleID.ToUpper().Equals(oStaffTitleID.Doctor.ToUpper()) OrElse
                staffTitleID.ToUpper().Equals(oStaffTitleID.Nurse.ToUpper())
            Me.LoadDoctorSpecialty(IsDoctor)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub LoadDoctorSpecialty(ByVal IsDoctor As Boolean)

        Try

            Me.Cursor = Cursors.WaitCursor

            If Not IsDoctor Then
                Me.cboDoctorSpecialtyID.DataSource = Nothing
                Me.cboDoctorSpecialtyID.SelectedIndex = -1
                Me.cboDoctorSpecialtyID.SelectedIndex = -1
            Else : LoadLookupDataCombo(Me.cboDoctorSpecialtyID, LookupObjects.DoctorSpecialty, False)
            End If

            Me.cboDoctorSpecialtyID.Enabled = IsDoctor

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetNextStaffNo()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oStaff As New SyncSoft.SQLDb.Staff()
            Dim oVariousOptions As New VariousOptions()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Staff", "StaffNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim staffNoPrefix As String = oVariousOptions.StaffNoPrefix
            Dim nextStaffNo As String = CStr(oStaff.GetNextStaffID).PadLeft(paddingLEN, paddingCHAR)

            Me.cboStaffNo.Text = FormatText((staffNoPrefix + nextStaffNo).Trim(), "Staff", "StaffNo")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoadSignature_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadSignature.Click
        Me.spbSignature.LoadPhoto(Me.spbSignature.ImageSizeLimit)
    End Sub

    Private Sub btnClearSignature_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSignature.Click
        Me.spbSignature.DeletePhoto()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim oStaff As New SyncSoft.SQLDb.Staff()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oStaff.StaffNo = RevertText(StringEnteredIn(Me.cboStaffNo, "Staff No!"))
            DisplayMessage(oStaff.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()


        Try

            Me.Cursor = Cursors.WaitCursor
            Dim staffNo As String = RevertText(StringEnteredIn(Me.cboStaffNo, "Staff No!"))
            Dim dataSource As DataTable = oStaff.GetStaff(staffNo).Tables("Staff")

            Me.DisplayData(dataSource)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim staff As EnumerableRowCollection(Of DataRow) = dataSource.AsEnumerable()
            Dim fingerprint As Byte() = (From data In staff Select data.Field(Of Byte())("Fingerprint")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then
                Me.oCrossMatchTemplate.Fingerprint = fingerprint
                Me.chkFingerprintCaptured.Checked = (Me.oCrossMatchTemplate.Fingerprint IsNot Nothing)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then
                Me.oDigitalPersonaTemplate.Template = GetDigitalPersonaTemplate(fingerprint)
                Me.chkFingerprintCaptured.Checked = (Me.oDigitalPersonaTemplate.Template IsNot Nothing)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim miniStaff As EnumerableRowCollection(Of DataRow) = dataSource.AsEnumerable()
            Me.cboDoctorSpecialtyID.SelectedValue = (From data In miniStaff Select data.Field(Of String)("DoctorSpecialtyID")).First()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oStaff As New SyncSoft.SQLDb.Staff()
            Dim oVariousOptions As New VariousOptions()
            Dim oStaffTitleID As New LookupDataID.StaffTitleID()
            Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

            With oStaff

                .StaffNo = RevertText(StringEnteredIn(Me.cboStaffNo, "Staff Number!"))
                .FirstName = StringEnteredIn(Me.stbFirstName, "First Name!")
                .LastName = StringEnteredIn(Me.stbLastName, "Last Name!")
                .GenderID = StringValueEnteredIn(Me.fcbGenderID, "Gender!")
                .StaffTitleID = StringValueEnteredIn(Me.fcbStaffTitleID, "Staff Title!")
                .Speciality = StringMayBeEnteredIn(Me.stbSpeciality)
                .Qualifications = StringMayBeEnteredIn(Me.stbQualifications)
                .Email = StringMayBeEnteredIn(Me.stbEmail)
                .JoinDate = Now 'DateEnteredIn(Me.ndpJoinDate, "Join Date!")
                .Phone = StringMayBeEnteredIn(Me.stbPhone)
                .Location = StringMayBeEnteredIn(Me.stbLocation)
                If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) AndAlso
                     oCrossMatchTemplate.Fingerprint IsNot Nothing Then
                    .Fingerprint = oCrossMatchTemplate.Fingerprint

                ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) AndAlso
                    (oDigitalPersonaTemplate.Template IsNot Nothing) Then
                    .Fingerprint = oDigitalPersonaTemplate.Template.Bytes

                Else : .Fingerprint = Nothing
                End If

                If oStaff.StaffTitleID.ToUpper().Equals(oStaffTitleID.Doctor.ToUpper()) OrElse
                oStaff.StaffTitleID.ToUpper().Equals(oStaffTitleID.Nurse.ToUpper()) Then
                    .DoctorSpecialtyID = StringValueEnteredIn(Me.cboDoctorSpecialtyID, "Doctor Specialty!")
                Else : .DoctorSpecialtyID = String.Empty
                End If
                .Signature = BytesMayBeEnteredIn(Me.spbSignature)

                .LoginID = StringMayBeEnteredIn(Me.stbLoginID)
                .Hidden = Me.chkHidden.Checked
                .CreatorLoginID = CurrentUser.LoginID
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oStaff.StaffTitleID.ToUpper().Equals(oStaffTitleID.Doctor.ToUpper()) OrElse
                oStaff.StaffTitleID.ToUpper().Equals(oStaffTitleID.Nurse.ToUpper()) Then

                If String.IsNullOrEmpty(oStaff.LoginID.Trim()) Then
                    Dim message As String = "You have not entered the associated Login ID for this staff. " +
                    "It’s recommended that you enter associated Login ID for staff with title doctor." +
                                            ControlChars.NewLine + "Are you sure you want to continue?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.stbLoginID.Focus() : Return
                End If

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oStaff.Hidden.Equals(True) Then
                Dim message As String = "You have chosen to hide this staff and won’t be presented for selection. " +
                                        ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.chkHidden.Focus() : Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    oStaff.Save()
                    ResetControlsIn(Me)
                    Me.SetNextStaffNo()
                    Me.oCrossMatchTemplate.Fingerprint = Nothing
                    Me.oDigitalPersonaTemplate.Template = Nothing
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case ButtonCaption.Update

                    DisplayMessage(oStaff.Update())

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.CallOnKeyEdit()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


#Region " Fingerprint Enrollment "

    Private Sub btnEnrollFingerprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnrollFingerprint.Click

        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try

            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then
                Dim fFingerprintCapture As New FingerprintCapture(CaptureType.Enroll)
                fFingerprintCapture.ShowDialog()
                Me.chkFingerprintCaptured.Checked = (Me.oCrossMatchTemplate.Fingerprint IsNot Nothing)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then
                Dim fEnrollment As New Enrollment()
                fEnrollment.ShowDialog()
                Me.chkFingerprintCaptured.Checked = (Me.oDigitalPersonaTemplate.Template IsNot Nothing)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

#End Region

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        LoadStaff()
        Me.ebnSaveUpdate.Enabled = False
        Me.btnDelete.Visible = True
        Me.btnDelete.Enabled = False
        Me.btnSearch.Visible = True

        Me.cboStaffNo.Enabled = True
        Me.chkHidden.Enabled = True

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.btnDelete.Visible = False
        Me.btnDelete.Enabled = True
        Me.btnSearch.Visible = False

        Me.cboStaffNo.Enabled = Not InitOptions.StaffNoLocked

        Me.chkHidden.Enabled = False

        ResetControlsIn(Me)
        Me.SetNextStaffNo()

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.btnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            Security.Apply(Me.btnDelete, AccessRights.Delete)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.ebnSaveUpdate.Enabled = False
            Me.btnDelete.Enabled = False
        End If
    End Sub

#End Region

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()

        Try
            Me.Cursor = Cursors.WaitCursor


            Dim Staff As DataTable = oStaff.GetStaff().Tables("Staff")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, Staff, "StaffFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboStaffNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStaffNo.SelectedIndexChanged

    End Sub

    Private Sub cboStaffNo_Leave(sender As Object, e As EventArgs) Handles cboStaffNo.Leave
        If ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            cboStaffNo.Text = SubstringRight(RevertText(StringMayBeEnteredIn(cboStaffNo)))

        End If
    End Sub
End Class