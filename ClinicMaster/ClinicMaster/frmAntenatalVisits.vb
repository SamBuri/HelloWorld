
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Enumerations
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona
Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports SyncSoft.Common.Win.Controls

Public Class frmAntenatalVisits

#Region " Fields "
    Private allergies As DataTable
    Private patientAllergies As DataTable
    Private antenatalVisitsSaved As Boolean = True
    Private pelvicExaminationSaved As Boolean = True
    Private oCurrentVisit As CurrentVisit
    Private oExaminerSpecialityID As New LookupDataID.StaffTitleID

    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()
#End Region

#Region " Properties "

    Private ReadOnly Property NewTriageTest() As String
        Get
            Return "Register Triage..."
        End Get
    End Property

    Private ReadOnly Property EditTriageTest() As String
        Get
            Return "Edit Triage..."
        End Get
    End Property

    Private ReadOnly Property ScheduleAppointment() As String
        Get
            Return "Schedule Appointment"
        End Get
    End Property

    Private ReadOnly Property TodaysAppointment() As String
        Get
            Return "Today's Appointments"
        End Get
    End Property

    Private ReadOnly Property ANCVisitClosed() As String
        Get
            Return "Visit Closed"
        End Get
    End Property

    Private ReadOnly Property ANCCloseVisit() As String
        Get
            Return "Close Visit"
        End Get
    End Property

#End Region

    Private Sub frmAntenatalVisits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboPallorID, LookupObjects.Pallor, False)
            LoadLookupDataCombo(Me.cboJaundiceID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboLynphadenopathyID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboVaricoseID, LookupObjects.Varicose, False)
            LoadLookupDataCombo(Me.cboOedemaID, LookupObjects.Oedema, False)
            LoadLookupDataCombo(Me.cboHeartSoundID, LookupObjects.Normality, False)
            LoadLookupDataCombo(Me.cboAirEntryID, LookupObjects.Normality, False)
            LoadLookupDataCombo(Me.cboBreastID, LookupObjects.Normality, False)
            LoadLookupDataCombo(Me.cboLiverID, LookupObjects.Normality, False)
            LoadLookupDataCombo(Me.cboSpleenID, LookupObjects.Normality, False)
            LoadLookupDataCombo(Me.cboBowelSoundsID, LookupObjects.Normality, False)
            LoadLookupDataCombo(Me.cboScarID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboPupilReactionID, LookupObjects.Normality, False)
            LoadLookupDataCombo(Me.cboReflexesID, LookupObjects.Normality, False)
            LoadLookupDataCombo(Me.cboOtherSTIID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboSkeletalDeformityID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboVulvaID, LookupObjects.Normality, False)
            LoadLookupDataCombo(Me.cboCervixID, LookupObjects.Normality, False)
            LoadLookupDataCombo(Me.cboAdnexaID, LookupObjects.Normality, False)
            LoadLookupDataCombo(Me.cboVaginaID, LookupObjects.Normality, False)
            LoadLookupDataCombo(Me.cboUterusID, LookupObjects.Normality, False)
            LoadLookupDataCombo(Me.cboConclusionID, LookupObjects.PelvicConclusion, False)
            LoadLookupDataCombo(Me.cboLieID, LookupObjects.Lie, False)
            LoadLookupDataCombo(Me.cboPositionID, LookupObjects.Position, False)
            LoadLookupDataCombo(Me.cboDoctorSpecialtyID, LookupObjects.DoctorSpecialty, False)
            LoadLookupDataCombo(Me.cboIPT, LookupObjects.YesNoUnknown, False)
            LoadLookupDataCombo(Me.cboNetUse, LookupObjects.YesNoUnknown, False)
            LoadLookupDataCombo(Me.cboPresentationID, LookupObjects.Presentation, False)
            Me.LoadDoctor()

            Me.LoadNurse()

           

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmAntenatalVisits_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oAntenatalVisits As New SyncSoft.SQLDb.AntenatalVisits()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oAntenatalVisits.VisitNo = StringEnteredIn(Me.stbVisitNo, "Visit No!")

            DisplayMessage(oAntenatalVisits.Delete())
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

        Dim visitNo As String

        Dim oAntenatalVisits As New SyncSoft.SQLDb.AntenatalVisits()

        Try
            Me.Cursor = Cursors.WaitCursor()

            visitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            Dim dataSource As DataTable = oAntenatalVisits.GetAntenatalVisits(visitNo).Tables("AntenatalVisits")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oAntenatalVisits As New SyncSoft.SQLDb.AntenatalVisits()

        Try
            Me.Cursor = Cursors.WaitCursor()

             Select Me.tbcAntenatalProgress.SelectedTab.Name


                Case Me.tpgPelvicExamination.Name

                    If Me.tbcAntenatalProgress.SelectedTab.Name.Equals(Me.tpgPelvicExamination.Name) Then Me.SavePelvicExamination()


            End Select
            With oAntenatalVisits
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .ANCNo = RevertText(StringEnteredIn(Me.stbANCNo, "ANC No!"))
                .PallorID = StringValueEnteredIn(Me.cboPallorID, "Pallor!")
                .JaundiceID = StringValueEnteredIn(Me.cboJaundiceID, "Jaundice!")
                .LynphadenopathyID = StringValueMayBeEnteredIn(Me.cboLynphadenopathyID, "Lynphadenopathy!")
                .VaricoseID = StringValueEnteredIn(Me.cboVaricoseID, "Varicose!")
                .OedemaID = StringValueEnteredIn(Me.cboOedemaID, "Oedema!")
                .HeartSoundID = StringValueEnteredIn(Me.cboHeartSoundID, "Heart Sound!")
                .AirEntryID = StringValueEnteredIn(Me.cboAirEntryID, "Air Entry!")
                .BreastID = StringValueEnteredIn(Me.cboBreastID, "Breast!")
                .LiverID = StringValueEnteredIn(Me.cboLiverID, "Liver!")
                .SpleenID = StringValueEnteredIn(Me.cboSpleenID, "Spleen!")
                .BowelSoundsID = StringValueMayBeEnteredIn(Me.cboBowelSoundsID, "Bowel Sounds!")
                .ScarID = StringValueMayBeEnteredIn(Me.cboScarID, "Scar!")
                .PupilReactionID = StringValueEnteredIn(Me.cboPupilReactionID, "Pupil Reaction!")
                .ReflexesID = StringValueEnteredIn(Me.cboReflexesID, "Reflexes!")
                .OtherSTIID = StringValueEnteredIn(Me.cboOtherSTIID, "Other STIs!")
                .STIDetails = StringMayBeEnteredIn(Me.stbSTIDetails)
                .SkeletalDeformityID = StringValueMayBeEnteredIn(Me.cboSkeletalDeformityID, "Skeletal Deformity!")
                .AnenorrheaWeeks = Me.nbxAnenorrheaWeeks.GetInteger()
                .FundalHeight = StringMayBeEnteredIn(Me.stbFundalHeight)
                .PresentationID = StringValueMayBeEnteredIn(Me.cboPresentationID)
                .LieID = StringValueMayBeEnteredIn(Me.cboLieID)
                .PositionID = StringValueMayBeEnteredIn(Me.cboPositionID, "Position!")
                .RelationPPOrBrim = StringEnteredIn(Me.stbRelationPPOrBrim, "RelationPP Or Brim!")
                .FoetalHeart = Me.nbxFoetalHeart.GetInteger()
                .TTGiven = Me.chkTTGiven.Checked
                .IPTID = StringValueMayBeEnteredIn(Me.cboIPT, "IPT!")
                .NetUseID = StringValueMayBeEnteredIn(Me.cboNetUse)
                .Remarks = StringMayBeEnteredIn(Me.stbRemarks)
                .ReturnDate = DateEnteredIn(Me.dtpReturnDate, "Return Date!")
                .DoctorSpecialityID = StringValueEnteredIn(Me.cboDoctorSpecialtyID, "Doctor Speciality!")
                .DoctorID = SubstringEnteredIn(Me.cboDoctorID, "Doctor!")
                .NurseInChargeID = SubstringEnteredIn(Me.cboNurseID, "Nurse!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                antenatalVisitsSaved = True
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Antenatal Details Successfully Saved!")


            End With




            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save
                    'oAntenatalVisits.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oAntenatalVisits.Update())
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

#Region "LOAD OPTIONS"
    

    Private Sub btnLoadSeeANCVisits_Click_1(sender As System.Object, e As System.EventArgs) Handles btnLoadSeeANCVisits.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        
        ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fPeriodicMaternalEnrollments As New frmPeriodicMaternalEnrollment(Me.stbANCNo)
        fPeriodicMaternalEnrollments.ShowDialog(Me)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim _ANCNo As String = RevertText(StringMayBeEnteredIn(Me.stbANCNo))
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If String.IsNullOrEmpty(_ANCNo) Then Return
        Me.ShowPatientDetails(_ANCNo)
    End Sub

  

    Private Sub LoadMaternalEnrollmentData(ByVal patientNo As String)
        Dim oMaternalEnrollment As New SyncSoft.SQLDb.MaternalEnrollment()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim maternalEnrollment As DataTable = oMaternalEnrollment.GetMaternalEnrollment(patientNo).Tables("MaternalEnrollment")
            Dim row3 As DataRow = maternalEnrollment.Rows(0)
            Me.stbANCNo.Text = RevertText(StringEnteredIn(row3, "ANCNo"))
            Me.stbEDD.Text = FormatDate(DateEnteredIn(row3, "EDD"))
            Me.stbHIVStatus.Text = StringEnteredIn(row3, "HIVStatus")
            Me.stbPartnersHIVStatus.Text = StringEnteredIn(row3, "PartnersHIVStatus")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadAntenatalVisits(ByVal visitNo As String)
        Dim oAntenatalVisits As New SyncSoft.SQLDb.AntenatalVisits()

        Try

            Me.Cursor = Cursors.WaitCursor


            Dim antenatalVisits As DataTable = oAntenatalVisits.GetAntenatalVisits(visitNo).Tables("AntenatalVisits")

            'Dim row4 As DataRow = antenatalVisits.Rows(0)
            If antenatalVisits Is Nothing OrElse antenatalVisits.Rows.Count < 1 Then Return

            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row4 As DataRow In antenatalVisits.Rows
                Me.cboPallorID.Text = StringEnteredIn(row4, "Pallor")
                Me.cboJaundiceID.Text = StringEnteredIn(row4, "Jaundice")
                Me.cboLynphadenopathyID.Text = StringEnteredIn(row4, "Lynphadenopathy")
                Me.cboVaricoseID.Text = StringEnteredIn(row4, "Varicose")
                Me.cboOedemaID.Text = StringEnteredIn(row4, "Oedema")
                Me.cboHeartSoundID.Text = StringEnteredIn(row4, "HeartSound")
                Me.cboAirEntryID.Text = StringEnteredIn(row4, "AirEntry")
                Me.cboBreastID.Text = StringEnteredIn(row4, "Breast")
                Me.cboLiverID.Text = StringEnteredIn(row4, "Liver")
                Me.cboSpleenID.Text = StringEnteredIn(row4, "Spleen")
                Me.cboBowelSoundsID.Text = StringEnteredIn(row4, "BowelSounds")
                Me.cboScarID.Text = StringEnteredIn(row4, "Scar")
                Me.cboPupilReactionID.Text = StringEnteredIn(row4, "PupilReaction")
                Me.cboReflexesID.Text = StringEnteredIn(row4, "Reflexes")
                Me.cboOtherSTIID.Text = StringEnteredIn(row4, "OtherSTIID")
                Me.stbSTIDetails.Text = StringEnteredIn(row4, "STIDetails")
                Me.cboSkeletalDeformityID.Text = StringEnteredIn(row4, "SkeletalDeformity")
                Me.nbxAnenorrheaWeeks.Value = StringMayBeEnteredIn(row4, "AnenorrheaWeeks")
                Me.stbFundalHeight.Text = StringEnteredIn(row4, "FundalHeight")
                Me.cboPresentationID.Text = StringEnteredIn(row4, "Presentation")
                Me.cboLieID.Text = StringEnteredIn(row4, "Lie")
                Me.cboPositionID.Text = StringEnteredIn(row4, "Position")
                Me.stbRelationPPOrBrim.Text = StringEnteredIn(row4, "RelationPPOrBrim")
                Me.nbxFoetalHeart.Value = StringMayBeEnteredIn(row4, "FoetalHeart")
                Me.chkTTGiven.Checked = BooleanMayBeEnteredIn(row4, "TTGiven")
                Me.cboIPT.Text = StringEnteredIn(row4, "IPT")
                Me.cboNetUse.Text = StringEnteredIn(row4, "NetUse")
                Me.stbRemarks.Text = StringEnteredIn(row4, "Remarks")
                Me.dtpReturnDate.Value = DateMayBeEnteredIn(row4, "ReturnDate")
                Me.dtpReturnDate.Checked = True
                Me.cboDoctorSpecialtyID.Text = StringEnteredIn(row4, "DoctorSpeciality")
                'Me.cboDoctorID.Text = StringEnteredIn(row4, "DoctorID")
                ' Me.cboNurseID.Text = StringEnteredIn(row4, "NurseInCharge")
            Next
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal _ANCNo As String)
        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oVariousOptions As New VariousOptions()
        Dim opatientallergies As New SyncSoft.SQLDb.PatientAllergies()
        Dim oMaternalEnrollment As New SyncSoft.SQLDb.MaternalEnrollment()
        Dim message As String = String.Empty


        Dim maternalEnrollments As DataTable = oMaternalEnrollment.GetMaternalEnrollment(_ANCNo).Tables("MaternalEnrollment")

        Dim row As DataRow = maternalEnrollments.Rows(0)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim patientNo As String = RevertText(StringEnteredIn(row, "PatientNo"))
        Dim outstandingBalanceErrorMSG As String = "This patient has offered/done service(s) with pending payment. " +
                                                    ControlChars.NewLine + "Please advice accordingly!"
        Dim patientAllergyMsg As String = " This Patient has Allergy(s)" + ControlChars.NewLine + "Please take note"

        Try

            Dim allergyList As DataTable = opatientallergies.GetPatientAllergies(patientNo).Tables("PatientAllergies")
            Me.stbVisitNo.Text = FormatText(_ANCNo, "Visits", "VisitNo")

            Me.LoadPatientAllergies(patientNo)



            '#################### PATIENT DETAILS################################'
          

            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbPhone.Text = StringEnteredIn(row, "Phone")
            Me.stbBloodGroup.Text = StringEnteredIn(row, "BloodGroup")
            Me.stbANCJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Dim birthDate As Date = DateMayBeEnteredIn(row, "BirthDate")
            Me.stbTotalVisits.Text = StringEnteredIn(row, "TotalVisits")
            Me.stbAdress.Text = StringMayBeEnteredIn(row, "Address")
            Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")
            Me.txtVisitDate.Text = FormatDate(DateEnteredIn(row, "lastVisitDate"))
            Me.stbTotalVisits.Text = StringEnteredIn(row, "TotalVisits")


            Dim visitDate As Date = DateEnteredIn(row, "VisitDate")



            '===================================================================================================================================='
            '===================================================================================================================================='

          

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save And Me.chkNavigateVisits.Checked = False Then

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If Not String.IsNullOrEmpty(message) Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DisplayMessage(message)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Me.ClearControls()
                    'Me.ResetControls()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' ResetControlsIn(Me.pnlNavigateVisits)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If

            End If
        Catch ex As Exception
            Message = "This Patient has never been created a visit. First create a visit to proceed."
            'Me.ClearControls()
            'Me.ResetControls()
        End Try




        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '######################### MATERNAL ENROLLMENT#############################################
        'Me.stbANCNo.Text = RevertText(StringEnteredIn(row, "ANCNo"))
        'Me.stbEDD.Text = FormatDate(DateEnteredIn(row, "EDD"))
        'Me.stbHIVStatus.Text = StringEnteredIn(row, "HIVStatus")
        'Me.stbPartnersHIVStatus.Text = StringEnteredIn(row, "PartnersHIVStatus")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ''################################## TRIAGE DETAILS #####################################

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Try
            Dim hasTriage As Boolean = BooleanMayBeEnteredIn(row, "HasTriage")
            If Not hasTriage Then
                Me.btnTriage.Text = Me.NewTriageTest
                Security.Apply(Me.btnTriage, AccessRights.Write)
            Else
                Me.btnTriage.Text = Me.EditTriageTest
                Security.Apply(Me.btnTriage, AccessRights.Edit)
            End If
            Me.nbxWeight.Value = StringMayBeEnteredIn(row, "Weight")
            Me.nbxTemperature.Value = StringMayBeEnteredIn(row, "Temperature")
            Me.nbxHeight.Value = StringMayBeEnteredIn(row, "Height")
            Me.nbxPulse.Value = StringMayBeEnteredIn(row, "Pulse")
            Me.stbBloodPressure.Text = StringMayBeEnteredIn(row, "BloodPressure")
            Me.nbxRespirationRate.Value = StringMayBeEnteredIn(row, "RespirationRate")
            Me.nbxOxygenSaturation.Value = StringMayBeEnteredIn(row, "OxygenSaturation")
            Me.nbxHeartRate.Value = StringMayBeEnteredIn(row, "HeartRate")
            Me.nbxBMI.Value = StringMayBeEnteredIn(row, "BMI")
            Me.stbNotes.Text = StringMayBeEnteredIn(row, "Notes")
            Me.nbxMUAC.Value = StringMayBeEnteredIn(row, "MUAC")
            Me.stbBMIStatus.Text = StringMayBeEnteredIn(row, "BMIStatus")



            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()
        Dim oVariousOptions As New VariousOptions()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")

            If oVariousOptions.RestrictSelectionOfOnlyLoggedInDoctors Then
                staff = oStaff.GetLoggedInStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboDoctorID, staff, "StaffFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDoctor()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboDoctorID, staff, "StaffFullName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadNurse()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Nurse).Tables("Staff")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboNurseID, staff, "StaffFullName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

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
#End Region

#Region "Allergies -Grid"

    Private Sub LoadAllergies()

        Dim oAllergies As New SyncSoft.SQLDb.Allergies()

        Try

            Me.Cursor = Cursors.WaitCursor

            ' Load from allergies
            allergies = oAllergies.GetAllergies().Tables("Allergies")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Me.colAllergyNo.Sorted = False
            'LoadComboData(Me.colAllergyNo, allergies, "AllergyNo", "AllergyName")
            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub ShowAllergyNo(ByVal allergyNo As String, ByVal pos As Integer)
        Dim oAllergies As New SyncSoft.SQLDb.Allergies()
        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If patientAllergies Is Nothing OrElse String.IsNullOrEmpty(allergyNo) Then Return

            For Each row As DataRow In patientAllergies.Select("AllergyNo = '" + allergyNo + "'")
                ' Me.dgvPatientAllergies.Item(Me.colAllergyNo.Name, pos).Value = StringMayBeEnteredIn(row, "AllergyNo")
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub


    Private Sub LoadPatientAllergies(ByVal patientNo As String)

        Dim oPatientAllergies As New SyncSoft.SQLDb.PatientAllergies()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim patientAllergies As DataTable = oPatientAllergies.GetPatientAllergies(patientNo).Tables("PatientAllergies")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If patientAllergies Is Nothing OrElse patientAllergies.Rows.Count < 1 Then Return

            For Each row As DataRow In patientAllergies.Rows


                LoadGridData(Me.dgvPatientAllergies, patientAllergies)
            Next




            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnAddAllergy_Click(sender As System.Object, e As System.EventArgs) Handles btnAddAllergy.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim oVariousOptions As New VariousOptions()
            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, " A Visit No, to Continue!"))
            If Not oVariousOptions.EnableSecondPatientForm Then
                Dim fPatientAllergies As New frmPatients(patientNo, True)
                fPatientAllergies.tbcPatients.SelectTab(fPatientAllergies.tpgPatientAllergies.Name)
                fPatientAllergies.Edit()
                fPatientAllergies.ShowDialog()
            Else
                Dim fPatientAllergies As New frmPatientsTwo(patientNo, True)
                fPatientAllergies.tbcPatients.SelectTab(fPatientAllergies.tpgPatientAllergies.Name)
                fPatientAllergies.Edit()
                fPatientAllergies.ShowDialog()
            End If


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

#End Region

#Region " Fingerprint  "

    Private Sub btnFindByFingerprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindByFingerprint.Click

        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitFingerprints As DataTable = GetVisitFingerprints()

            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then

                Dim fFingerprintCapture As New FingerprintCapture(CaptureType.Verify, visitFingerprints, "VisitNo")
                fFingerprintCapture.ShowDialog()

                Dim visitNo As String = Me.oCrossMatchTemplate.ID
                If Me.oCrossMatchTemplate.Fingerprint Is Nothing OrElse String.IsNullOrEmpty(visitNo) Then Return

                Me.ShowPatientDetails(visitNo)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then

                Dim fVerification As New Verification(visitFingerprints, "VisitNo")
                fVerification.ShowDialog()

                ' If Not String.IsNullOrEmpty(Me.oDigitalPersonaTemplate.ID) Then Me.LoadVisitsData(Me.oDigitalPersonaTemplate.ID)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

#End Region

#Region "CLEAR CONTROLS"
    Private Sub ClearControls()

        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()
        Me.stbANCJoinDate.Clear()
        Me.stbAdress.Clear()
        Me.stbTotalVisits.Clear()
        Me.spbPhoto.Image = Nothing

        Me.nbxWeight.Clear()
        Me.nbxTemperature.Clear()
        Me.nbxHeight.Clear()
        Me.nbxMUAC.Clear()
        Me.nbxPulse.Clear()
        Me.stbBloodPressure.Clear()
        Me.nbxRespirationRate.Clear()
        Me.nbxOxygenSaturation.Clear()
        Me.nbxHeartRate.Clear()
        Me.nbxBMI.Clear()
        Me.stbBMIStatus.Clear()
        Me.stbNotes.Clear()



    End Sub

    Private Sub ResetControls()

        '''''''''''''''''''''''''''''''''''''''
        'staffFullName = String.Empty

        '''''''''''''''''''''''''''''''''''''''
        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgANCVitals)
        ResetControlsIn(Me.tpgFoetalExamination)
        ResetControlsIn(Me.tpgPelvicExamination)
        ResetControlsIn(Me.tpgPhysicalExamination)


        '''''''''''''''''''''''''''''''''''''''

        '''''''''''''''''''''''''''''''''''''''

    End Sub

#End Region


#Region "SAVE OPTIONS"
    Private Sub SavePelvicExamination()


        Try
            Me.Cursor = Cursors.WaitCursor()
            Dim oPelvicExamination As New SyncSoft.SQLDb.PelvicExamination()

            With oPelvicExamination

                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .ANCNo = RevertText(StringEnteredIn(Me.stbANCNo, "ANC No!"))
                .VulvaID = StringValueMayBeEnteredIn(Me.cboVulvaID, "Vulva!")
                .CervixID = StringValueMayBeEnteredIn(Me.cboCervixID, "Cervix!")
                .AdnexaID = StringValueMayBeEnteredIn(Me.cboAdnexaID, "Adnexa!")
                .VaginaID = StringValueMayBeEnteredIn(Me.cboVaginaID, "Vagina!")
                .UterusID = StringValueMayBeEnteredIn(Me.cboUterusID, "Uterus!")
                .DiagonalConjugate = Me.nbxDiagonalConjugate.GetInteger()
                .SacralCurve = Me.nbxSacralCurve.GetInteger()
                .IschialSpine = Me.nbxIschialSpine.GetInteger()
                .SubPublicAngle = Me.nbxSubPublicAngle.GetInteger()
                .IschialTuberosities = Me.nbxIschialTuberosities.GetInteger()
                .ConclusionID = StringValueMayBeEnteredIn(Me.cboConclusionID, "Conclusion!")
                .RiskFactors = StringMayBeEnteredIn(Me.stbRiskFactors)
                .Recommendations = StringMayBeEnteredIn(Me.stbRecommendations)
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                pelvicExaminationSaved = True
                DisplayMessage("Pelvic Examination Successfully Saved!")

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub
#End Region

    Private Sub chkNavigateVisits_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkNavigateVisits.CheckedChanged
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then
            Me.chkNavigateVisits.Checked = Not Me.chkNavigateVisits.Checked
            Return
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Me.EnableNavigateVisitsCTLS(Me.chkNavigateVisits.Checked)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub


#Region " Visits Navigate "

    Private Sub EnableNavigateVisitsCTLS(ByVal state As Boolean)

        Dim startPosition As Integer
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

                Me.LoadAntenatalVisits(visitNo)

                Dim visits As DataTable = oVisits.GetVisitsByPatientNo(patientNo).Tables("Visits")

                For pos As Integer = 0 To visits.Rows.Count - 1
                    If visitNo.ToUpper().Equals(visits.Rows(pos).Item("VisitNo").ToString().ToUpper()) Then
                        startPosition = pos + 1
                        Exit For
                    Else : startPosition = 1
                    End If
                Next

                Me.navVisits.DataSource = visits
                Me.navVisits.Navigate(startPosition)

            Else : Me.navVisits.Clear()
            End If

        Catch eX As Exception
            Me.chkNavigateVisits.Checked = False
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


#End Region


    Private Sub chkNavigateVisits_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNavigateVisits.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then
            Me.chkNavigateVisits.Checked = Not Me.chkNavigateVisits.Checked
            Return
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.EnableNavigateVisitsCTLS(Me.chkNavigateVisits.Checked)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navVisits.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(currentValue.ToString())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(visitNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadRecords(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub LoadRecords(ByVal visitNo As String)
        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowPatientDetails(visitNo)
            Me.LoadAntenatalVisits(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub


    Private Sub ShowOtherDetails(ByVal visitNo As String)

        visitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

        Dim oAntenatalVisits As New SyncSoft.SQLDb.AntenatalVisits()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim dataSource As DataTable = oAntenatalVisits.GetAntenatalVisits(visitNo).Tables("AntenatalVisits")
            Me.DisplayData(dataSource)


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub


    Private Function AllSaved() As Boolean

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim message As String
            Dim visitNo As String = StringMayBeEnteredIn(Me.stbVisitNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(visitNo) Then Return True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Dim oAntenatalVisits As New SyncSoft.SQLDb.AntenatalVisits()

            Dim AntenatalVisits As DataTable = oAntenatalVisits.GetAntenatalVisits(RevertText(visitNo)).Tables("AntenatalVisits")



            If AntenatalVisits Is Nothing Then

                message = "Please ensure that At least One Record is saved under Antenatal progress!"
                DisplayMessage(message)

                Me.BringToFront()
                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                Return False
            End If

            '''''''''''''''''''''''''''''''
            Return True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return True

        End Try

    End Function


    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim VisitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo))
        Me.ShowPatientDetails(visitNo)
    End Sub

   
    Private Sub stbVisitNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbVisitNo.Leave
        Dim _ANCNo As String = RevertText(StringEnteredIn(Me.stbANCNo))
        Me.ShowPatientDetails(_ANCNo)
    End Sub
End Class