
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects



Public Class frmSymptomsHistory

#Region "Properties"

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

    Private ReadOnly Property VisitClosed() As String
        Get
            Return "Visit Closed"
        End Get
    End Property

    Private ReadOnly Property CloseVisit() As String
        Get
            Return "Close Visit"
        End Get
    End Property
#End Region
#Region " Fields "

#End Region

    Private Sub frmSymptomsHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboAlteredConsciousness, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboAirway, LookupObjects.Airway, False)
            LoadLookupDataCombo(Me.cboBloodDiarrhoea, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboBulgingFontanelle, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboCapRefill, LookupObjects.CapRefill, False)
            LoadLookupDataCombo(Me.cboConvulsions, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboCrackles, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboCough, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboCoughMoreThanTwoWeeks, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboDeepBreathing, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboDiarrhoea, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboDiarrhoeaLongerThanTwoWeeks, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboDifficultyInBreathing, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboEdema, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboFever, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboFlaringOfNostrils, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboImmunizationDetails, LookupObjects.ImmunizationDetails, False)
            LoadLookupDataCombo(Me.cboIntercostalRecession, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboJaundice, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboKerningsSign, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboLethargic, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboIsBloodTransfusionDesired, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboPallor, LookupObjects.Pallor, False)
            LoadLookupDataCombo(Me.cboPassingTeaColouredUrine, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboPulse, LookupObjects.Pulse, False)
            LoadLookupDataCombo(Me.cboPleuralRub, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboSevereWasting, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboSkinPinchReturn, LookupObjects.SkinPinchReturn, False)
            LoadLookupDataCombo(Me.cboStiffNeck, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboSunkenEyes, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboSubcostalRecession, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboUnableToDrinkBreastfeed, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboUnconscious, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboUnableToSitStand, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboVomiting, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboWheezing, LookupObjects.YesNo, False)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.clbBloodTransfusionStateReasons, LookupObjects.BloodTransfusionStateReason, False)
            LoadLookupDataCombo(Me.clbBloodTransfusionNotGivenStateReasons, LookupObjects.BloodTransfusionNotGivenStateReason, False)
            LoadLookupDataCombo(Me.clbOtherFormsOfSupportiveCare, LookupObjects.OtherFormsOfSupportiveCare, False)
            LoadLookupDataCombo(Me.clbReasonsForDiagnosisOfSevereComplicatedMalaria, LookupObjects.ReasonsForDiagnosisOfSevereComplicatedMalaria, False)
            LoadLookupDataCombo(Me.clbReasonsForAdmissionWithPositiveMalariaTest, LookupObjects.ReasonsForAdmissionWithPositiveMalariaTest, False)
            LoadLookupDataCombo(Me.cboIfDesiredWasBloodGiven, LookupObjects.YesNo, False)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.clbBloodTransfusionStateReasons.Enabled = False
            Me.clbBloodTransfusionNotGivenStateReasons.Enabled = False
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.ChangeState()


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmSymptomsHistory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oSymptomsHistory As New SyncSoft.SQLDb.SymptomsHistory()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oSymptomsHistory.VisitNo = StringEnteredIn(Me.stbVisitNo, "VisitNo!")

            DisplayMessage(oSymptomsHistory.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me)
            ResetControlsIn(Me.pnlPatientDetails)
            ResetControlsIn(Me.pnlBloodTransfusion)
            ResetControlsIn(Me.pnlBloodTransfusionNotGivenStateReasons)
            ResetControlsIn(Me.pnlBloodTransfusionStateReasons)
            ResetControlsIn(Me.pnlCentralNervousSystem)
            ResetControlsIn(Me.pnlGeneralExamination)
            ResetControlsIn(Me.pnlHistorySymptomCheckList)
            ResetControlsIn(Me.pnlInitialLaboratoryResults)
            ResetControlsIn(Me.pnlOtherFormsOfSupportiveCare)
            ResetControlsIn(Me.pnlReasonsForAdmissionWithPositiveMalariaTest)
            ResetControlsIn(Me.pnlReasonsForDiagnosisOfSevereComplicationMalaria)
            ResetControlsIn(Me.pnlRespiratorySystem)
            ResetControlsIn(Me.pnlTriage)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))

        Dim oSymptomsHistory As New SyncSoft.SQLDb.SymptomsHistory()


        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If String.IsNullOrEmpty(visitNo) Then Return
            Me.ShowPatientDetails(visitNo)
            Me.LoadLabResults(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            visitNo = StringEnteredIn(Me.stbVisitNo, "VisitNo!")

            Dim dataSource As DataTable = oSymptomsHistory.GetSymptomsHistory(visitNo).Tables("SymptomsHistory")
          
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oSymptomsHistory As New SyncSoft.SQLDb.SymptomsHistory()

        Dim oYesNo As New LookupDataID.YesNoID

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oSymptomsHistory

                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "VisitNo!"))
                .Fever = StringValueEnteredIn(Me.cboFever, "Fever!")
                .Cough = StringValueEnteredIn(Me.cboCough, "Cough!")
                .CoughMoreThanTwoWeeks = StringValueEnteredIn(Me.cboCoughMoreThanTwoWeeks, "Cough More Than Two Weeks!")
                .DifficultyInBreathing = StringValueEnteredIn(Me.cboDifficultyInBreathing, "Difficulty In Breathing!")
                .ImmunizationDetails = StringValueEnteredIn(Me.cboImmunizationDetails, "Immunization Details!")
                .OtherHistory = StringEnteredIn(Me.stbOtherHistory, "Other History!")
                .Convulsions = StringValueEnteredIn(Me.cboConvulsions, "Convulsions!")
                .AlteredConsciousness = StringValueEnteredIn(Me.cboAlteredConsciousness, "Altered Consciousness!")
                .Vomiting = StringValueEnteredIn(Me.cboVomiting, "Vomiting!")
                .UnableToDrinkBreastfeed = StringValueEnteredIn(Me.cboUnableToDrinkBreastfeed, "Unable To Drink  Breastfeed!")
                .PastMedicalHistory = StringEnteredIn(Me.stbPastMedicalHistory, "Past Medical History!")
                .Diarrhoea = StringValueEnteredIn(Me.cboDiarrhoea, "Diarrhoea!")
                .DiarrhoeaLongerThanTwoWeeks = StringValueEnteredIn(Me.cboDiarrhoeaLongerThanTwoWeeks, "Diarrhoea Longer Two Weeks!")
                .BloodDiarrhoea = StringValueEnteredIn(Me.cboBloodDiarrhoea, "Blood Diarrhoea!")
                .PassingTeaColouredUrine = StringValueEnteredIn(Me.cboPassingTeaColouredUrine, "Passing Tea Coloured Urine!")
                .FeedingHistory = StringEnteredIn(Me.stbFeedingHistory, "Feeding History!")

                .Pallor = StringValueEnteredIn(Me.cboPallor, "Pallor!")
                .SkinPinchReturn = StringValueEnteredIn(Me.cboSkinPinchReturn, "Skin Pinch Return!")
                .SevereWasting = StringValueEnteredIn(Me.cboSevereWasting, "Severe Wasting!")
                .Edema = StringValueEnteredIn(Me.cboEdema, "Edema!")
                .SunkenEyes = StringValueEnteredIn(Me.cboSunkenEyes, "Sunken Eyes!")
                .Jaundice = StringValueEnteredIn(Me.cboJaundice, "Jaundice!")
                .MUAC = Me.nbxMUAC.GetInteger()
                .Height = Me.nbxHeight.GetInteger()
                .DeepBreathing = StringValueEnteredIn(Me.cboDeepBreathing, "Deep Breathing!")
                .FlaringOfNostrils = StringValueEnteredIn(Me.cboFlaringOfNostrils, "Flaring Of Nostrils!")
                .IntercostalRecession = StringValueEnteredIn(Me.cboIntercostalRecession, "Intercostal Recession !")
                .SubcostalRecession = StringValueEnteredIn(Me.cboSubcostalRecession, "Subcostal Recession !")
                .Pulse = StringValueEnteredIn(Me.cboPulse, "Pulse!")
                .CapRefill = StringValueEnteredIn(Me.cboCapRefill, "Cap Refill!")

                .Airway = StringValueEnteredIn(Me.cboAirway, "Airway")
                .Wheezing = StringValueEnteredIn(Me.cboWheezing, "Wheezing")
                .PleuralRub = StringValueEnteredIn(Me.cboPleuralRub, "Pleural Rub")
                .Crackles = StringValueEnteredIn(Me.cboCrackles, "Crackles")

                .Unconscious = StringValueEnteredIn(Me.cboUnconscious, "Unconscious!")
                .Lethargic = StringValueEnteredIn(Me.cboLethargic, "Lethargic!")
                .UnableToSitStand = StringValueEnteredIn(Me.cboUnableToSitStand, "Unable To Sit  Stand!")
                .BulgingFontanelle = StringValueEnteredIn(Me.cboBulgingFontanelle, "Bulging Fontanelle!")
                .StiffNeck = StringValueEnteredIn(Me.cboStiffNeck, "Stiff Neck!")
                .KerningsSign = StringValueEnteredIn(Me.cboKerningsSign, "Kernings Sign!")
                .IsBloodTransfusionDesired = StringValueEnteredIn(Me.cboIsBloodTransfusionDesired, "Is Blood Transfusion Desired!")
                If .IsBloodTransfusionDesired.ToUpper.Equals(oYesNo.Yes.ToUpper()) Then
                    .BloodTransfusionStateReasons = StringToSplitSelectedInAtleastOne(Me.clbBloodTransfusionStateReasons, LookupObjects.BloodTransfusionStateReason, "Blood Transfusion State Reasons!")

                Else : .IsBloodTransfusionDesired.ToUpper.Equals(oYesNo.No.ToUpper())
                    .BloodTransfusionStateReasons = StringToSplitSelectedIn(Me.clbBloodTransfusionStateReasons, LookupObjects.BloodTransfusionStateReason)
                End If
                .IfDesiredWasBloodGiven = StringValueEnteredIn(Me.cboIfDesiredWasBloodGiven, "If Desired Was Blood Given!")
                If .IfDesiredWasBloodGiven.ToUpper.Equals(oYesNo.Yes.ToUpper()) Then
                    .IfYesVolume = IntegerEnteredIn(Me.nbxIfYesVolume, "If Yes Volume!")
                    .TransfusionDate = DateEnteredIn(Me.dtpTransfusionDate, "Transfusion Date!")
                    .BloodUnits = IntegerEnteredIn(Me.nbxBloodUnits, "Blood Units!")
                    .BloodTransfusionNotGivenStateReasons = StringToSplitSelectedInAtleastOne(Me.clbBloodTransfusionNotGivenStateReasons, LookupObjects.BloodTransfusionNotGivenStateReason, "Blood Transfusion Not Given State Reasons!")

                Else : .IfDesiredWasBloodGiven.ToUpper.Equals(oYesNo.No.ToUpper())
                    .IfYesVolume = IntegerMayBeEnteredIn(Me.nbxIfYesVolume)
                    .TransfusionDate = DateMayBeEnteredIn(Me.dtpTransfusionDate)
                    .BloodUnits = IntegerMayBeEnteredIn(Me.nbxBloodUnits)
                    .BloodTransfusionNotGivenStateReasons = StringToSplitSelectedIn(Me.clbBloodTransfusionNotGivenStateReasons, LookupObjects.BloodTransfusionNotGivenStateReason)
                End If
                .OtherFormsOfSupportiveCare = StringToSplitSelectedInAtleastOne(Me.clbOtherFormsOfSupportiveCare, LookupObjects.OtherFormsOfSupportiveCare, "Other Forms Of Supportive Care!")
                .ReasonsForDiagnosisOfSevereComplicatedMalaria = StringToSplitSelectedInAtleastOne(Me.clbReasonsForDiagnosisOfSevereComplicatedMalaria, LookupObjects.ReasonsForDiagnosisOfSevereComplicatedMalaria, "Reasons For Diagnosis Of Severe Complicated Malaria!")
                .ReasonsForAdmissionWithPositiveMalariaTest = StringToSplitSelectedInAtleastOne(Me.clbReasonsForAdmissionWithPositiveMalariaTest, LookupObjects.ReasonsForAdmissionWithPositiveMalariaTest, "Reasons For Admission With Positive Malaria Test!")

                .LoginID = CurrentUser.LoginID
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
           

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oSymptomsHistory.Save()
                   
                Case ButtonCaption.Update

                    DisplayMessage(oSymptomsHistory.Update())

                    Me.CallOnKeyEdit()

            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me)
            ResetControlsIn(Me.pnlPatientDetails)
            ResetControlsIn(Me.pnlBloodTransfusion)
            ResetControlsIn(Me.pnlBloodTransfusionNotGivenStateReasons)
            ResetControlsIn(Me.pnlBloodTransfusionStateReasons)
            ResetControlsIn(Me.pnlCentralNervousSystem)
            ResetControlsIn(Me.pnlGeneralExamination)
            ResetControlsIn(Me.pnlHistorySymptomCheckList)
            ResetControlsIn(Me.pnlInitialLaboratoryResults)
            ResetControlsIn(Me.pnlOtherFormsOfSupportiveCare)
            ResetControlsIn(Me.pnlReasonsForAdmissionWithPositiveMalariaTest)
            ResetControlsIn(Me.pnlReasonsForDiagnosisOfSevereComplicationMalaria)
            ResetControlsIn(Me.pnlRespiratorySystem)
            ResetControlsIn(Me.pnlTriage)
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
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlPatientDetails)
        ResetControlsIn(Me.pnlBloodTransfusion)
        ResetControlsIn(Me.pnlBloodTransfusionNotGivenStateReasons)
        ResetControlsIn(Me.pnlBloodTransfusionStateReasons)
        ResetControlsIn(Me.pnlCentralNervousSystem)
        ResetControlsIn(Me.pnlGeneralExamination)
        ResetControlsIn(Me.pnlHistorySymptomCheckList)
        ResetControlsIn(Me.pnlInitialLaboratoryResults)
        ResetControlsIn(Me.pnlOtherFormsOfSupportiveCare)
        ResetControlsIn(Me.pnlReasonsForAdmissionWithPositiveMalariaTest)
        ResetControlsIn(Me.pnlReasonsForDiagnosisOfSevereComplicationMalaria)
        ResetControlsIn(Me.pnlRespiratorySystem)
        ResetControlsIn(Me.pnlTriage)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlPatientDetails)
        ResetControlsIn(Me.pnlBloodTransfusion)
        ResetControlsIn(Me.pnlBloodTransfusionNotGivenStateReasons)
        ResetControlsIn(Me.pnlBloodTransfusionStateReasons)
        ResetControlsIn(Me.pnlCentralNervousSystem)
        ResetControlsIn(Me.pnlGeneralExamination)
        ResetControlsIn(Me.pnlHistorySymptomCheckList)
        ResetControlsIn(Me.pnlInitialLaboratoryResults)
        ResetControlsIn(Me.pnlOtherFormsOfSupportiveCare)
        ResetControlsIn(Me.pnlReasonsForAdmissionWithPositiveMalariaTest)
        ResetControlsIn(Me.pnlReasonsForDiagnosisOfSevereComplicationMalaria)
        ResetControlsIn(Me.pnlRespiratorySystem)
        ResetControlsIn(Me.pnlTriage)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub btnLoadPeriodicVisits_Click(sender As Object, e As EventArgs) Handles btnLoadPeriodicVisits.Click

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicVisits As New frmPeriodicVisits(Me.stbVisitNo)
            fPeriodicVisits.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            Me.ShowPatientDetails(visitNo)
            Me.LoadLabResults(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub btnFindVisitNo_Click(sender As Object, e As EventArgs) Handles btnFindVisitNo.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return

        Me.ShowPatientDetails(visitNo)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()
       
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(visitNo) Then Return
            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")

            Dim row As DataRow = visits.Rows(0)

            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbStatus.Text = StringEnteredIn(row, "VisitStatus")
            Me.stbVisitCategory.Text = StringEnteredIn(row, "VisitCategory")
            Me.stbVisitNo.Text = FormatText(visitNo, "visits", "visitNo")



            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
            Me.nbxHeadCircum.Value = StringMayBeEnteredIn(row, "HeadCircum")
            Me.nbxBodySurfaceArea.Value = StringMayBeEnteredIn(row, "BodySurfaceArea")
            Me.nbxRespirationRate.Value = StringMayBeEnteredIn(row, "RespirationRate")
            Me.nbxOxygenSaturation.Value = StringMayBeEnteredIn(row, "OxygenSaturation")
            Me.nbxHeartRate.Value = StringMayBeEnteredIn(row, "HeartRate")
            Me.nbxBMI.Value = StringMayBeEnteredIn(row, "BMI")
            Me.stbNotes.Text = StringMayBeEnteredIn(row, "Notes")

            ''  Me.LoadAllergyData(patientNo)

            'Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)

            'Me.lblMessage.Visible = (GetShortDate(visitDate) >= GetShortDate(Today.AddHours(-12)) AndAlso
            '                         billMode.ToUpper().Equals(cashAccountNo.ToUpper()))

            'Me.grpCoPay.Visible = Not billModesID.ToUpper().Equals(oBillModesID.Cash)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbAge.Clear()
        Me.stbStatus.Clear()
        Me.stbVisitCategory.Clear()
        Me.stbVisitDate.Clear()

    End Sub

    Private Sub ChangeState()
        Dim oYesNo As New LookupDataID.YesNoID

        If Me.cboIsBloodTransfusionDesired.Text = GetLookupDataDes(oYesNo.Yes) Then
            Me.clbBloodTransfusionStateReasons.Enabled = True
        ElseIf Me.cboIsBloodTransfusionDesired.Text = GetLookupDataDes(oYesNo.No) Then
            Me.clbBloodTransfusionStateReasons.Enabled = False
            ResetControlsIn(Me.pnlBloodTransfusionStateReasons)
        ElseIf Not (Me.cboIsBloodTransfusionDesired.Text = GetLookupDataDes(oYesNo.Yes) And Me.cboIsBloodTransfusionDesired.Text = GetLookupDataDes(oYesNo.No)) Then
            Me.clbBloodTransfusionStateReasons.Enabled = False
        End If

            If Me.cboIfDesiredWasBloodGiven.Text = GetLookupDataDes(oYesNo.Yes) Then
                Me.nbxIfYesVolume.Enabled = True
                Me.dtpTransfusionDate.Enabled = True
                Me.nbxBloodUnits.Enabled = True
                Me.clbBloodTransfusionNotGivenStateReasons.Enabled = True
            ElseIf Me.cboIfDesiredWasBloodGiven.Text = GetLookupDataDes(oYesNo.No) Then
                Me.nbxIfYesVolume.Enabled = False
                Me.dtpTransfusionDate.Enabled = False
            Me.nbxBloodUnits.Enabled = False
            Me.clbBloodTransfusionNotGivenStateReasons.Enabled = False
                ResetControlsIn(Me.pnlBloodTransfusionNotGivenStateReasons)
        ElseIf Not (Me.cboIfDesiredWasBloodGiven.Text = GetLookupDataDes(oYesNo.Yes) And Me.cboIfDesiredWasBloodGiven.Text = GetLookupDataDes(oYesNo.No)) Then
            Me.nbxIfYesVolume.Enabled = False
            Me.dtpTransfusionDate.Enabled = False
            Me.nbxBloodUnits.Enabled = False
            Me.clbBloodTransfusionNotGivenStateReasons.Enabled = False
        End If

    End Sub

  

    Private Sub btnTriage_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnPrintPreviewMedicalReport_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnTriage_Click_1(sender As Object, e As EventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim fTriage As New frmTriage(visitNo, True)

            If Me.btnTriage.Text.Equals(Me.EditTriageTest) Then
                fTriage.Edit()
                fTriage.Search(visitNo)
            Else : fTriage.Save()
            End If

            fTriage.ShowDialog()
            Me.ShowPatientDetails(visitNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnDoctorVisitClosed_Click_1(sender As Object, e As EventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oDoctorVisits As New SyncSoft.SQLDb.DoctorVisits()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "Closing this visit mean no more changes will be accepted. " +
                                    ControlChars.NewLine + "Are you sure you want to continue?"
            If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With oDoctorVisits
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
                .StaffNo = String.Empty
                .Closed = True
                DisplayMessage(.Update())
            End With
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub LoadLabResults(ByVal visitNo As String)

        Dim styleResult As New DataGridViewCellStyle()
        Dim font As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
        Dim oLabResults As New SyncSoft.SQLDb.LabResults()
        Dim oResultFlagID As New LookupDataID.ResultFlagID()

        Try

            Me.dgvLabResults.Rows.Clear()

            ' Load from Lab Results
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim labResults As DataTable = oLabResults.GetLabResultsByVisitNo(visitNo).Tables("LabResults")
            If labResults Is Nothing Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvLabResults, labResults)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            styleResult.BackColor = Color.MistyRose
            styleResult.Font = font

            For rowNo As Integer = 0 To Me.dgvLabResults.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvLabResults.Rows(rowNo).Cells

                Dim resultFlag As String = StringMayBeEnteredIn(cells, Me.colResultFlag)
                Dim resultDataType As String = StringMayBeEnteredIn(cells, Me.colResultDataType)
                Dim normalRange As String = StringMayBeEnteredIn(cells, Me.colNormalRange)
                Dim result As String = StringMayBeEnteredIn(cells, Me.colResult)

                If resultFlag.ToUpper().Equals(GetLookupDataDes(oResultFlagID.Low).ToUpper()) OrElse
                    resultFlag.ToUpper().Equals(GetLookupDataDes(oResultFlagID.High).ToUpper()) OrElse
                    LabResultNotInNormalRange(resultDataType, gender, normalRange, result) Then
                    Me.dgvLabResults.Rows(rowNo).Cells(Me.colResult.Name).Style.ApplyStyle(styleResult)
                End If

            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub cboIsBloodTransfusionDesired_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboIsBloodTransfusionDesired.SelectedIndexChanged
        Me.ChangeState()
    End Sub

    Private Sub cboIfDesiredWasBloodGiven_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboIfDesiredWasBloodGiven.SelectedIndexChanged
        Me.ChangeState()
    End Sub


    
    Private Sub stbVisitNo_TextChanged(sender As Object, e As EventArgs) Handles stbVisitNo.TextChanged
        'ResetControlsIn(Me)
        'ResetControlsIn(Me.pnlPatientDetails)
        ResetControlsIn(Me.pnlBloodTransfusion)
        ResetControlsIn(Me.pnlBloodTransfusionNotGivenStateReasons)
        ResetControlsIn(Me.pnlBloodTransfusionStateReasons)
        ResetControlsIn(Me.pnlCentralNervousSystem)
        ResetControlsIn(Me.pnlGeneralExamination)
        ResetControlsIn(Me.pnlHistorySymptomCheckList)
        ResetControlsIn(Me.pnlInitialLaboratoryResults)
        ResetControlsIn(Me.pnlOtherFormsOfSupportiveCare)
        ResetControlsIn(Me.pnlReasonsForAdmissionWithPositiveMalariaTest)
        ResetControlsIn(Me.pnlReasonsForDiagnosisOfSevereComplicationMalaria)
        ResetControlsIn(Me.pnlRespiratorySystem)
        ResetControlsIn(Me.pnlTriage)

    End Sub

    Private Sub btnTriage_Click_2(sender As Object, e As EventArgs) Handles btnTriage.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim fTriage As New frmTriage(visitNo, True)

            If Me.btnTriage.Text.Equals(Me.EditTriageTest) Then
                fTriage.Edit()
                fTriage.Search(visitNo)
            Else : fTriage.Save()
            End If

            fTriage.ShowDialog()
            Me.ShowPatientDetails(visitNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
End Class