
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmAppointments

#Region " Fields "
    Private oNextAppointment As New NextAppointment()
    Private defaultPatientNo As String = String.Empty
#End Region

    Private Sub frmAppointments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oLookupData As New LookupData()
        Dim oAppointmentPrecisionID As New LookupDataID.AppointmentPrecisionID()

        Me.EnableClearExactCTLS(False, True)

        Me.PopulateForm()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.rdoRange.Text = GetLookupDataDes(oAppointmentPrecisionID.Range)
            Me.rdoExact.Text = GetLookupDataDes(oAppointmentPrecisionID.Exact)

            LoadLookupDataCombo(Me.cboDoctorSpecialtyID, LookupObjects.DoctorSpecialty, False)

            LoadLookupDataCombo(Me.cboAppointmentCategoryID, LookupObjects.VisitCategory, False)



            LoadLookupDataCombo(Me.cboCommunityID, LookupObjects.Community, True)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            If Not String.IsNullOrEmpty(defaultPatientNo) Then
                Me.stbPatientNo.Text = FormatText(defaultPatientNo, "Patients", "PatientNo")
                'Me.stbPatientNo.ReadOnly = True
                Me.ShowPatientDetails(defaultPatientNo)
                Me.ProcessTabKey(True)
            Else : Me.stbPatientNo.ReadOnly = False
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

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

    Private Sub frmAppointments_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub PopulateForm()

        Try

            Me.Cursor = Cursors.WaitCursor

            LoadLookupDataCombo(Me.cboAppointmentStatusID, LookupObjects.AppointmentStatus, True)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub EnableClearExactCTLS(ByVal state As Boolean, ByVal clear As Boolean)

        Me.nbxDuration.Enabled = state
        Me.stpStartTime.Enabled = state

        If clear Then
            Me.stpStartTime.Text = "00:00"
            Me.stpStartTime.Checked = False
            Me.nbxDuration.Clear()
        End If

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub ClearControls()
        Me.stbFullName.Clear()
    End Sub

    Private Sub stbPatientNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbPatientNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub stbPatientNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbPatientNo.TextChanged
        Me.ClearControls()
        Me.CallOnKeyEdit()
    End Sub

    Private Sub stbPatientNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbPatientNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))

            '''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''

            If String.IsNullOrEmpty(patientNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowPatientDetails(patientNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)
            '''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Patients", Me.stbPatientNo)
            fQuickSearch.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            If Not String.IsNullOrEmpty(patientNo) Then Me.ShowPatientDetails(patientNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbPatientNo_Leave(Me, System.EventArgs.Empty)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub ShowPatientDetails(ByVal patientNo As String)

        Dim oPatients As New SyncSoft.SQLDb.Patients()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oPatients.GetPatient(patientNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbFullName.Text = oPatients.FullName
            Me.stbPhoneNo.Text = oPatients.Phone

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub dtpStartDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpStartDate.ValueChanged
        Me.CallOnKeyEdit()
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

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim oAppointments As New SyncSoft.SQLDb.Appointments()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oAppointments.PatientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))
            oAppointments.StartDate = DateEnteredIn(Me.dtpStartDate, "Start Date")

            DisplayMessage(oAppointments.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            ResetControlsIn(Me.grpAppointmentPrecision)
            Me.CallOnKeyEdit()

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim patientNo As String
        Dim startDate As Date

        Dim oAppointments As New SyncSoft.SQLDb.Appointments()
        Dim dataSource As New DataTable()

        Try

            Me.Cursor = Cursors.WaitCursor

            patientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))
            startDate = DateEnteredIn(Me.dtpStartDate, "Start Date!")

            dataSource = oAppointments.GetAppointments(patientNo, startDate).Tables("Appointments")
            DisplayData(dataSource)

            Me.dtpEndDate.Checked = True

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim appointmentPrecisionID As String
        Dim duration As Integer
        Dim startTime As String
        Dim oVariousOptions As New VariousOptions()
        Dim VisitCategory As String

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oAppointmentPrecisionID As New LookupDataID.AppointmentPrecisionID()
            Dim oAppointments As New SyncSoft.SQLDb.Appointments()

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))
            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date!")

            If Me.rdoRange.Checked = True Then
                appointmentPrecisionID = oAppointmentPrecisionID.Range
                startTime = String.Empty

            ElseIf Me.rdoExact.Checked = True Then
                appointmentPrecisionID = oAppointmentPrecisionID.Exact
                startTime = TimeEnteredIn(Me.stpStartTime, "Start Time")
                duration = Me.nbxDuration.GetInteger()

                Me.CalculateEndDate()

            Else
                appointmentPrecisionID = String.Empty
                startTime = String.Empty
                Me.grpAppointmentPrecision.Focus()
                Throw New ArgumentException("Must Select Appointment Precision!")
            End If

            With oAppointments

                .PatientNo = patientNo
                .StartDate = startDate
                .AppointmentPrecisionID = appointmentPrecisionID
                .StartTime = startTime
                .Duration = duration
                .EndDate = DateEnteredIn(Me.dtpEndDate, "End Date!")
                .DoctorSpecialtyID = StringValueEnteredIn(Me.cboDoctorSpecialtyID, "Doctor Specialty!")
                If Me.cboStaffNo.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.cboStaffNo.Text) Then
                    .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "To See Doctor!")
                Else : .StaffNo = String.Empty
                End If

                .CommunityID = StringValueEnteredIn(Me.cboCommunityID, "CommunityID!")

                VisitCategory = StringValueMayBeEnteredIn(Me.cboAppointmentCategoryID, "Appointment Category!")

                .AppointmentCategoryID = VisitCategory

                .AppointmentDes = StringMayBeEnteredIn(Me.stbAppointmentDes)
                .AppointmentStatusID = StringValueEnteredIn(Me.cboAppointmentStatusID, "Appointment Status!")
                .LoginID = CurrentUser.LoginID

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                If .EndDate < .StartDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oAppointments.Save()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If oVariousOptions.SMSNotificationAtAppointments Then
                        If stbPhoneNo.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(stbPhoneNo.Text) Then
                            Dim oPatients As New SyncSoft.SQLDb.Patients()
                            oPatients.GetPatient(patientNo)
                            Dim message As String
                            Dim productOwner As String = AppData.ProductOwner
                            Dim phoneNo As String = stbPhoneNo.Text
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            If rdoRange.Checked Then
                                message = "Hi" + " " + oPatients.FirstName.ToString + " " + "you have an Appointment at" + " " + productOwner + " " + "From" + " " + dtpStartDate.Text + " " + "to" + " " + dtpEndDate.Text + " " + "- Via ClinicMaster"
                                SaveTextMessage(message, phoneNo, Now, oVariousOptions.SMSLifeSpanAppointments)

                                'If dtpStartDate. < Now Then

                                'End If
                            ElseIf rdoExact.Checked Then

                                message = "Hi" + " " + oPatients.FirstName.ToString + " " + "you have an Appointment at" + " " + productOwner + " " + "Starting" + " " + (dtpStartDate.Text) + " " + "at" + " " + stpStartTime.Text + " " + "lasting " + " " + nbxDuration.Text + " " + "Mins" + " " + "- Via ClinicMaster"
                                SaveTextMessage(message, phoneNo, Now, oVariousOptions.SMSLifeSpanAppointments)
                            End If
                        End If
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ResetControlsIn(Me.grpAppointmentPrecision)
                    EnableClearExactCTLS(False, True)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oAppointments.Update())
                    Me.CallOnKeyEdit()

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub rdoRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoRange.CheckedChanged
        If Me.rdoRange.Checked Then EnableClearExactCTLS(False, True)
    End Sub

    Private Sub rdoExact_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoExact.CheckedChanged
        If Me.rdoExact.Checked Then EnableClearExactCTLS(True, False)
        Me.SetEndDate()
    End Sub

    Private Sub SetEndDate()

        If Me.rdoRange.Checked = True Then
            Me.dtpEndDate.Value = Today
            Me.dtpEndDate.Checked = False
            Me.dtpEndDate.Enabled = True

        ElseIf Me.rdoExact.Checked = True Then
            Me.dtpEndDate.Value = Me.dtpStartDate.Value
            Me.dtpEndDate.Checked = True
            Me.dtpEndDate.Enabled = False

            Me.CalculateEndDate()

        End If

    End Sub

    Private Sub CalculateEndDate()

        Dim duration As Integer

        Try

            Dim startDate As String = FormatDate(dtpStartDate.Value)
            Dim startTime As String = TimeMayBeEnteredIn(Me.stpStartTime)

            If IsNumeric(Me.nbxDuration.Value) Then duration = CInt(Me.nbxDuration.Value)
            Me.dtpEndDate.Value = CDate(startDate + " " + startTime).AddMinutes(duration)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub stpStartTime_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stpStartTime.Leave
        Me.CalculateEndDate()
    End Sub

    Private Sub nbxDuration_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbxDuration.Leave
        Me.CalculateEndDate()
    End Sub

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.btnDelete.Visible = True
        Me.btnDelete.Enabled = False
        Me.btnSearch.Visible = True
        Me.btnLoad.Enabled = False

        Me.grpAppointmentPrecision.Enabled = False
        Me.dtpEndDate.Enabled = False

        ResetControlsIn(Me)
        ResetControlsIn(Me.grpAppointmentPrecision)
        ResetControlsIn(Me.pnlAppointmentStatusID)
        Me.dtpStartDate.MinDate = AppData.NullDateValue

        Me.cboStaffNo.Items.Clear()

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.btnDelete.Visible = False
        Me.btnDelete.Enabled = True
        Me.btnSearch.Visible = False
        Me.btnLoad.Enabled = True

        Me.grpAppointmentPrecision.Enabled = True
        Me.dtpEndDate.Enabled = True

        ResetControlsIn(Me)
        ResetControlsIn(Me.grpAppointmentPrecision)

        Me.cboStaffNo.Items.Clear()

        Me.dtpStartDate.MinDate = Today
        Me.dtpEndDate.MinDate = Today
        Me.PopulateForm()

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

    Public Sub NextAppointment()

        Dim oAppointmentPrecisionID As New LookupDataID.AppointmentPrecisionID()

        Me.Save()
        Me.stbPatientNo.Enabled = False
        Me.grpAppointmentPrecision.Enabled = False
        Me.stbAppointmentDes.Enabled = False

        Me.dtpStartDate.Checked = True
        Me.dtpEndDate.Checked = True

        With Me.oNextAppointment
            Me.stbPatientNo.Text = .PatientNo
            Me.stbFullName.Text = .FullName
            Me.dtpStartDate.Value = .StartDate
            Me.rdoRange.Checked = oAppointmentPrecisionID.Range.Equals(.AppointmentPrecisionID)
            Me.dtpEndDate.Value = .EndDate
            Me.cboStaffNo.Text = .StaffFullName
            Me.stbAppointmentDes.Text = .AppointmentDes
        End With

    End Sub

#End Region

End Class