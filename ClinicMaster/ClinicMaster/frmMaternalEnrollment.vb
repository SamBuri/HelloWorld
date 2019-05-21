
Option Strict On
Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.Enumerations
Imports SyncSoft.Common.SQL.Enumerations

Imports System.Collections.Generic

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Public Class frmMaternalEnrollment

#Region " Fields "
    Private maternalEnrollmentSaved As Boolean = True
    Private oBloodTransfusionID As New LookupDataID.YesNoID
    Private oAbortionID As New LookupDataID.YesNoID
    Dim oStatusID As New LookupCommDataID.StatusID()
    Private oCurrentANCVisit As CurrentPatient

    Private allergies As DataTable
    Private _AllergyNoValue As String = String.Empty

#End Region

Private Sub frmMaternalEnrollment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboCycleRegularID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboHIVStatusID, LookupObjects.HIVStatus, False)
            LoadLookupDataCombo(Me.cboPartnersHIVStatusID, LookupObjects.HIVStatus, False)
            LoadLookupDataCombo(Me.clbMedicalHistory, LookupObjects.MedicalHistory, False)
            LoadLookupDataCombo(Me.cboBloodTransfusion, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.clbFamilyHistory, LookupObjects.FamilyHistory, False)
            LoadLookupDataCombo(Me.clbSocialHistory, LookupObjects.SocialHistory, False)
            LoadLookupDataCombo(Me.clbGynaecologicalHistory, LookupObjects.GynaecologicalHistory, False)
            LoadLookupDataCombo(Me.clbSurgicalHistory, LookupObjects.SurgicalHistory, False)
            LoadLookupDataCombo(Me.colObstetricAbortionID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.colObstetricAbortionPeriodID, LookupObjects.AbortionPeriod, False)
            LoadLookupDataCombo(Me.colObstetricThirdStageID, LookupObjects.PregnancyOutcome, False)
            LoadLookupDataCombo(Me.colObstetricPeurPerinumID, LookupObjects.PregnancyOutcome, False)
            LoadLookupDataCombo(Me.colObstetricGenderID, LookupObjects.Gender, False)
            LoadLookupDataCombo(Me.colObstetricChildStatusID, LookupObjects.ChildStatus, False)
            LoadLookupDataCombo(Me.colTypeOfDelivery, LookupObjects.TypeOfDelivery, False)
            Me.dtpEDD.MinDate = Today
            Me.dtpLNMP.MaxDate = Today
            Me.dtpScanDate.MaxDate = Today
            Me.LoadAllergies()
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Me.LoadPatientAllergies(patientNo)
            Me.PatientStatus()


            Me.fcbStatusID.Enabled = False


	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub frmMaternalEnrollment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub

Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

Dim oMaternalEnrollment As New SyncSoft.SQLDb.MaternalEnrollment()

	Try
		Me.Cursor = Cursors.WaitCursor()

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oMaternalEnrollment.PatientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

		DisplayMessage(oMaternalEnrollment.Delete())
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

        Dim _ANCNo As String

        Dim oMaternalEnrollment As New SyncSoft.SQLDb.MaternalEnrollment()

        Try
            Me.Cursor = Cursors.WaitCursor()

            _ANCNo = RevertText(StringEnteredIn(Me.stbANCNo, "ANC No!"))

            Dim dataSource As DataTable = oMaternalEnrollment.GetMaternalEnrollment(_ANCNo).Tables("MaternalEnrollment")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

End Sub


#Region " Edit Methods "

    Public Sub Edit()

        Me.btnSave.ButtonText = ButtonCaption.Update
        Me.btnSave.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.btnSave.ButtonText = ButtonCaption.Save
        Me.btnSave.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        ResetControlsIn(Me)
        'Me.SetNextANCNo(patientNo)

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.btnSave.DataSource = dataSource
            Me.btnSave.LoadData(Me)

            Me.btnSave.Enabled = dataSource.Rows.Count > 0
            Me.fbnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.btnSave, AccessRights.Update)
            Security.Apply(Me.fbnDelete, AccessRights.Delete)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CallOnKeyEdit()
        If Me.btnSave.ButtonText = ButtonCaption.Update Then
            Me.btnSave.Enabled = False
            Me.fbnDelete.Enabled = False
        End If
    End Sub

#End Region

#Region "LOAD OPTIONS"
    Private Sub ShowVisitsHeaderData()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            Me.ResetControls()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))


            If String.IsNullOrEmpty(patientNo) Then Return
            Me.ShowPatientDetails(patientNo)

            Me.LoadAllergies(patientNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            Me.ResetControls()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal patientNo As String)

        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oVisitCategoryID As New LookupDataID.VisitCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim patients As DataTable = oPatients.GetPatients(patientNo).Tables("Patients")
            Dim row As DataRow = patients.Rows(0)
            
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.txtFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbAdress.Text = StringMayBeEnteredIn(row, "Address")
            Me.stbPhone.Text = StringMayBeEnteredIn(row, "Phone")
            Me.stbBloodGroup.Text = StringMayBeEnteredIn(row, "BloodGroup")
            Me.txtVisitDate.Text = FormatDate(DateEnteredIn(row, "lastVisitDate"))
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "joinDate"))
            Dim birthDate As Date = DateMayBeEnteredIn(row, "BirthDate")
            Me.txtAge.Text = GetAgeString(birthDate)
            Me.stbMaritalStatus.Text = StringMayBeEnteredIn(row, "MaritalStatus")
            Me.stbOccupation.Text = StringMayBeEnteredIn(row, "Occupation")
            Me.stbTotalVisits.Text = StringEnteredIn(row, "TotalVisits")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetNextANCNo(patientNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub LoadAllergies(ByVal patientNo As String)
        Dim oPatientAllergies As New SyncSoft.SQLDb.PatientAllergies()
        Dim oVariousOptions As New VariousOptions()
        
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim patientAllergies As DataTable = oPatientAllergies.GetPatientAllergies(patientNo).Tables("PatientAllergies")

            If patientAllergies Is Nothing OrElse patientAllergies.Rows.Count < 1 Then Return


            LoadGridData(Me.dgvPatientAllergies, patientAllergies)

           
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Me.dgvPatientAllergies.Rows.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception

            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadAllergies()

        Dim oAllergies As New SyncSoft.SQLDb.Allergies()

        Try

            Me.Cursor = Cursors.WaitCursor

            ' Load from allergies
            allergies = oAllergies.GetAllergies().Tables("Allergies")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colAllergyNo.Sorted = False
            LoadComboData(Me.colAllergyNo, allergies, "AllergyNo", "AllergyName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    'Private Sub PatientStatus()

    '    Dim oLookupData As New LookupData()
    '    Dim oStatusID As New LookupCommDataID.StatusID()

    '    Try
    '        Me.Cursor = Cursors.WaitCursor
    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '        Dim statusLookupData As DataTable = oLookupData.GetLookupData(LookupCommObjects.Status).Tables("LookupData")
    '        If statusLookupData Is Nothing Then Return

    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        For Each row As DataRow In statusLookupData.Rows
    '            If oStatusID.Active.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) OrElse
    '                oStatusID.Deceased.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) OrElse
    '                oStatusID.Transferred.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) OrElse
    '                oStatusID.Inactive.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) Then
    '                Continue For
    '            Else : row.Delete()
    '            End If
    '        Next
    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '        Me.cboPatientStatusID.DataSource = statusLookupData
    '        Me.cboPatientStatusID.DisplayMember = "DataDes"
    '        Me.cboPatientStatusID.ValueMember = "DataID"
    '        Me.cboPatientStatusID.SelectedValue = oStatusID.Active
    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        MsgBox(statusLookupData)
    '    Catch ex As Exception
    '        ErrorMessage(ex)

    '    Finally
    '        Me.Cursor = Cursors.Default

    '    End Try

    'End Sub

    Private Sub PatientStatus()

        Dim oLookupData As New LookupData()
        Dim oGenderID As New LookupDataID.GenderID()
        Dim oStatusID As New LookupCommDataID.StatusID()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusLookupData As DataTable = oLookupData.GetLookupData(LookupCommObjects.Status).Tables("LookupData")
            If statusLookupData Is Nothing Then Return

            For Each row As DataRow In statusLookupData.Rows
                If oStatusID.Active.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) OrElse
                    oStatusID.Inactive.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) Then

                    Continue For
                Else : row.Delete()
                End If
            Next

            Me.fcbStatusID.DataSource = statusLookupData

            Me.fcbStatusID.DisplayMember = "DataDes"
            Me.fcbStatusID.ValueMember = "DataID"

            Me.fcbStatusID.SelectedValue = oStatusID.Active
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub SetNextANCNo(ByVal patientNo As String)

        Try
            'Me.Cursor = Cursors.WaitCursor


            Dim oMaternalEnrollment As New SyncSoft.SQLDb.MaternalEnrollment()
            Dim oVariousOption As New VariousOptions()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("MaternalEnrollment", "ANCNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim ANCNoPrefix As String = oVariousOption.ANCNoPrefix

            Dim ANCID As String = oMaternalEnrollment.GetNextANCID(patientNo).ToString()
            ANCID = ANCID.PadLeft(paddingLEN, paddingCHAR)

            Me.stbANCNo.Text = FormatText(ANCNoPrefix + patientNo + ANCID.Trim(), "MaternalEnrollment", "ANCNo")
        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub
#End Region

#Region "SAVE METHODS"
    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Try


            Select Case Me.tbcMaternalEnrollment.SelectedTab.Name

                Case Me.tpgCurrentPregnancy.Name

                    Me.SaveContraceptivesHistory()

                Case Me.tpgPreviousIllnesses.Name
                    Me.SaveMaternalEnrollment()

                Case Me.tpgObstetricHistory.Name
                    Me.SaveObstetricHistory()

                Case Me.tpgPatientAllergies.Name
                    Me.SavePatientAllergies()


            End Select

            For rowNo As Integer = 0 To Me.dgvContraceptives.RowCount - 2
                Me.dgvContraceptives.Item(Me.colContraceptiveSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvOBHistory.RowCount - 2
                Me.dgvOBHistory.Item(Me.colObstetricSaved.Name, rowNo).Value = True
            Next


        Catch ex As Exception

        End Try
    End Sub


    Private Sub SaveObstetricHistory()

        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim lObstetric As New List(Of DBConnect)
            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvOBHistory.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvOBHistory.Rows(rowNo).Cells

                Try

                    Using oObstetric As New SyncSoft.SQLDb.Obstetric
                        With oObstetric

                            .PatientNo = patientNo
                            .Pregnancy = CInt(StringEnteredIn(cells, Me.colObstetricPregnancy))
                            .YearPregnant = CInt(StringEnteredIn(cells, Me.colObstetricYear))
                            .AbortionID = StringEnteredIn(cells, Me.colObstetricAbortionID)
                            .AbortionPeriodID = StringEnteredIn(cells, Me.colObstetricAbortionPeriodID)
                            .TypeOfDeliveryID = StringMayBeEnteredIn(cells, Me.colTypeOfDelivery)
                            .ThirdStageID = StringMayBeEnteredIn(cells, Me.colObstetricThirdStageID)
                            .PuerPeriumID = StringMayBeEnteredIn(cells, Me.colObstetricPeurPerinumID)
                            .ChildStatusID = StringMayBeEnteredIn(cells, Me.colObstetricChildStatusID)
                            .GenderID = StringMayBeEnteredIn(cells, Me.colObstetricGenderID)
                            .BirthWeight = CSng(StringMayBeEnteredIn(cells, Me.colObstetricBirthWeight))
                            .ChildImmunised = CBool(StringMayBeEnteredIn(cells, Me.colObstetricImmunised))
                            .HealthCondition = StringEnteredIn(cells, Me.colObstetricHealthCondition)
                            .LoginID = CurrentUser.LoginID
                        End With

                        lObstetric.Add(oObstetric)
                        

                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lObstetric, Action.Save))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dgvOBHistory.Rows.Clear()
            Me.ClearControls()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveContraceptivesHistory()

        Try
            Me.Cursor = Cursors.WaitCursor
            Dim transactions As New List(Of TransactionList(Of DBConnect))
            Dim lContraceptivesHistory As New List(Of DBConnect)
            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

            'If Me.dgvContraceptives.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for Contraceptives History!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvContraceptives.RowCount - 2


                Dim cells As DataGridViewCellCollection = Me.dgvContraceptives.Rows(rowNo).Cells
                Dim contraceptiveID As String = StringMayBeEnteredIn(cells, Me.colContraceptiveID)
                Dim complicationsID As String = StringMayBeEnteredIn(cells, Me.colComplications)
                Dim complicationDetails As String = StringMayBeEnteredIn(cells, Me.colComplicationDetails)
                Dim dateStarted As Date = CDate(CStr(DateMayBeEnteredIn(cells, Me.colContraceptiveDateStarted)))
                Dim discontinuedRemovedID As String = StringMayBeEnteredIn(cells, Me.colContraceptiveDiscontinued)
                Dim removalReasonsID As String = StringMayBeEnteredIn(cells, Me.colContraceptiveRemovalReasons)


                Try

                    Using oContraceptivesHistory As New SyncSoft.SQLDb.ContraceptivesHistory()
                        With oContraceptivesHistory

                            .PatientNo = patientNo
                            .ContraceptiveID = contraceptiveID
                            .ComplicationsID = complicationsID
                            .ComplicationDetails = complicationDetails
                            .DateStarted = dateStarted
                            .DiscontinuedRemovedID = discontinuedRemovedID
                            .RemovalReasonsID = removalReasonsID
                            .Notes = StringMayBeEnteredIn(cells, Me.colContraceptiveNotes)
                            .LoginID = CurrentUser.LoginID

                        End With

                        lContraceptivesHistory.Add(oContraceptivesHistory)


                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lContraceptivesHistory, Action.Save))

                    DoTransactions(transactions)



                Catch ex As Exception
                    Me.tbcCurrentPregnancy.SelectTab(Me.tpgContraceptivesHistory.Name)
                    Throw ex

                End Try
            Next

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub SaveMaternalEnrollment()


        Try
            Me.Cursor = Cursors.WaitCursor()
            Dim oMaternalEnrollment As New SyncSoft.SQLDb.MaternalEnrollment()

            With oMaternalEnrollment

                .ANCNo = RevertText(StringEnteredIn(Me.stbANCNo, "ANC No!"))
                .PatientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))
                .HIVStatusID = StringValueEnteredIn(Me.cboHIVStatusID, "HIV Status!")
                .PartnersHIVStatusID = StringValueMayBeEnteredIn(Me.cboPartnersHIVStatusID, "Partner's HIV Status!")
                .Gravida = Me.nbxGravida.GetInteger()
                .Para = Me.nbxGravida.GetInteger()
                .LNMP = DateEnteredIn(Me.dtpLNMP, "LNMP!")
                .LNMPDateReliable = Me.chkLNMPDateReliable.Checked
                .CycleRegularID = StringValueEnteredIn(Me.cboCycleRegularID, "Cycle Regular!")
                .EDD = DateMayBeEnteredIn(Me.dtpEDD)
                .ScanDate = DateMayBeEnteredIn(Me.dtpScanDate)
                .MedicalHistory = StringToSplitSelectedIn(Me.clbMedicalHistory, LookupObjects.MedicalHistory)
                .MedicalHistoryNotes = StringMayBeEnteredIn(Me.stbMedicalHistoryNotes)
                .BloodTransfusion = StringValueEnteredIn(Me.cboBloodTransfusion, "Blood Transfusion!")
                .BloodTransfusionDate = DateMayBeEnteredIn(Me.dtpBloodTransfusionDate)
                .SurgicalHistory = StringToSplitSelectedIn(Me.clbSurgicalHistory, LookupObjects.SurgicalHistory)
                .SurgicalHistoryNotes = StringMayBeEnteredIn(Me.stbSurgicalHistoryNotes)
                .GynaecologicalHistory = StringToSplitSelectedIn(Me.clbGynaecologicalHistory, LookupObjects.GynaecologicalHistory)
                .GynaecologicalHistoryNotes = StringMayBeEnteredIn(Me.stbGynHistoryNotes)
                .FamilyHistory = StringToSplitSelectedIn(Me.clbFamilyHistory, LookupObjects.FamilyHistory)
                .FamilyHistoryNotes = StringMayBeEnteredIn(Me.stbFamilyHistoryNotes)
                .SocialHistory = StringToSplitSelectedIn(Me.clbSocialHistory, LookupObjects.SocialHistory)
                .SocialHistoryNotes = StringMayBeEnteredIn(Me.stbSocialHistoryNotes)
                .PatientStatusID = StringValueEnteredIn(Me.fcbStatusID, "Status!")

                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                maternalEnrollmentSaved = True
                DisplayMessage("Enrollment Successfully Saved!")

                Me.PatientStatus()
                Me.ResetControls()
                Me.ClearControls()
            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SavePatientAllergies()

        Dim lPatientAllergies As New List(Of DBConnect)
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))


            For rowNo As Integer = 0 To Me.dgvPatientAllergies.RowCount - 2
                Dim cells As DataGridViewCellCollection = Me.dgvPatientAllergies.Rows(rowNo).Cells
                Using oPatientAllergies As New SyncSoft.SQLDb.PatientAllergies()


                    With oPatientAllergies

                        .PatientNo = patientNo
                        .AllergyNo = StringEnteredIn(cells, Me.colAllergyNo, "Allergy No!")
                        .Reaction = StringMayBeEnteredIn(cells, Me.colReaction)

                    End With

                    lPatientAllergies.Add(oPatientAllergies)
                    oPatientAllergies.Save()
                    Me.dgvOBHistory.Item(Me.colPatientAllergiesSaved.Name, rowNo).Value = True
                End Using

            Next
           
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lPatientAllergies, Action.Save))

            DoTransactions(transactions)


            DisplayMessage("Allergies Successfully Saved!")

        Catch ex As Exception

            Throw ex

        End Try
    End Sub


#End Region




#Region "CLEAR CONTROLS"
    Private Sub ClearControls()
        Me.txtFullName.Clear()
        Me.txtVisitDate.Clear()
        Me.txtAge.Clear()
        Me.stbANCNo.Clear()
        Me.stbAdress.Clear()
        Me.stbOccupation.Clear()
        Me.stbFamilyHistoryNotes.Clear()
        Me.stbBloodGroup.Clear()
        Me.stbGynHistoryNotes.Clear()
        Me.stbMaritalStatus.Clear()
        Me.stbPhone.Clear()
        Me.stbSocialHistoryNotes.Clear()
        Me.stbJoinDate.Clear()
        Me.stbTotalVisits.Clear()
        Me.dgvContraceptives.Rows.Clear()
        Me.dgvOBHistory.Rows.Clear()
        Me.dgvPatientAllergies.Rows.Clear()



    End Sub

    Private Sub ResetControls()
        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgCurrentPregnancy)
        ResetControlsIn(Me.tpgPreviousIllnesses)
        ResetControlsIn(Me.tpgFamilySocialHistory)
        ResetControlsIn(Me.grpMedicalHistory)
        ResetControlsIn(Me.grpSurgicalHistory)
        ResetControlsIn(Me.grpOBSGyn)
        ResetControlsIn(Me.grpFamilyHistory)
        ResetControlsIn(Me.grpSocialHistory)


    End Sub
#End Region

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        Try

           ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Patients", Me.stbPatientNo)
            fQuickSearch.ShowDialog(Me)

            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            If Not String.IsNullOrEmpty(patientNo) Then Me.ShowPatientDetails(patientNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub dgvContraceptives_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvContraceptives.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            LoadLookupDataCombo(Me.colContraceptiveID, LookupObjects.FPMethods, False)
            LoadLookupDataCombo(Me.colComplications, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.colComplicationDetails, LookupObjects.ContraceptivesComplications, False)
            LoadLookupDataCombo(Me.colContraceptiveDiscontinued, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.colContraceptiveRemovalReasons, LookupObjects.ReasonsForRemoval, False)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dateStarted As Date = DateMayBeEnteredIn(Me.dgvContraceptives.Rows(e.RowIndex).Cells, Me.colContraceptiveDateStarted)

            Dim fSelectDateTime As New SyncSoft.SQL.Win.Forms.SelectDateTime(dateStarted, "Date Started", AppData.MinimumDate, Today,
                                                                     Me.dgvContraceptives, Me.colContraceptiveDateStarted, e.RowIndex)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.colContraceptiveDateStarted.Index.Equals(e.ColumnIndex) AndAlso Me.dgvContraceptives.Rows(e.RowIndex).IsNewRow Then

                Me.dgvContraceptives.Rows.Add()
                fSelectDateTime.ShowDialog(Me)

                Dim enteredDate As Date = DateMayBeEnteredIn(Me.dgvContraceptives.Rows(e.RowIndex).Cells, Me.colContraceptiveDateStarted)
                If enteredDate = AppData.NullDateValue Then Me.dgvContraceptives.Rows.RemoveAt(e.RowIndex)

            ElseIf Me.colContraceptiveDateStarted.Index.Equals(e.ColumnIndex) Then

                fSelectDateTime.ShowDialog(Me)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub dgvPatientAllergies_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPatientAllergies.CellClick

    End Sub

#Region " PatientAllergies - Grid "

    Private Sub dgvPatientAllergies_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPatientAllergies.CellBeginEdit

        If e.ColumnIndex <> Me.colAllergyNo.Index OrElse Me.dgvPatientAllergies.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvPatientAllergies.CurrentCell.RowIndex
        _AllergyNoValue = StringMayBeEnteredIn(Me.dgvPatientAllergies.Rows(selectedRow).Cells, Me.colAllergyNo)

    End Sub

    Private Sub dgvPatientAllergies_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPatientAllergies.CellEndEdit

        Try

            If Me.colAllergyNo.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colAllergyNo.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvPatientAllergies.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvPatientAllergies.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvPatientAllergies.Rows(selectedRow).Cells, Me.colAllergyNo)

                    If CBool(Me.dgvPatientAllergies.Item(Me.colPatientAllergiesSaved.Name, selectedRow).Value).Equals(True) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Allergies As EnumerableRowCollection(Of DataRow) = allergies.AsEnumerable()
                        Dim allergyDisplay As String = (From data In _Allergies _
                                            Where data.Field(Of String)("AllergyNo").ToUpper().Equals(_AllergyNoValue.ToUpper()) _
                                            Select data.Field(Of String)("AllergyName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Allergy (" + allergyDisplay + ") can't be edited!")
                        Me.dgvPatientAllergies.Item(Me.colAllergyNo.Name, selectedRow).Value = _AllergyNoValue
                        Me.dgvPatientAllergies.Item(Me.colAllergyNo.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvPatientAllergies.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvPatientAllergies.Rows(rowNo).Cells, Me.colAllergyNo)
                            If enteredItem.Equals(selectedItem) Then
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _Alergies As EnumerableRowCollection(Of DataRow) = allergies.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _Alergies _
                                                    Where data.Field(Of String)("AllergyNo").ToUpper().Equals(enteredItem.ToUpper()) _
                                                    Select data.Field(Of String)("AllergyName")).First()
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Allergy (" + enteredDisplay + ") already entered!")
                                Me.dgvPatientAllergies.Item(Me.colAllergyNo.Name, selectedRow).Value = _AllergyNoValue
                                Me.dgvPatientAllergies.Item(Me.colAllergyNo.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If allergies Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

                    For Each row As DataRow In allergies.Select("AllergyNo = '" + selectedItem + "'")
                        Me.dgvPatientAllergies.Item(Me.colAllergyCategory.Name, selectedRow).Value = StringMayBeEnteredIn(row, "AllergyCategory")
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvPatientAllergies_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvPatientAllergies.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPatientAllergies As New SyncSoft.SQLDb.PatientAllergies()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvPatientAllergies.Item(Me.colPatientAllergiesSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))
            Dim allergyNo As String = CStr(Me.dgvPatientAllergies.Item(Me.colAllergyNo.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "You do not have permission to delete this record!"
            'If Me.btnDelete.Enabled = False Then
            '    DisplayMessage(message)
            '    e.Cancel = True
            '    Return
            'End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oPatientAllergies
                .PatientNo = patientNo
                .AllergyNo = allergyNo
            End With

            DisplayMessage(oPatientAllergies.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

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


            'For Each row As DataGridViewRow In Me.dgvPatientAllergies.Rows
            '    If row.IsNewRow Then Exit For
            '    Me.dgvPatientAllergies.Item(Me.colPatientAllergiesSaved.Name, row.Index).Value = True
            'Next

            Select Case Me.tbcMaternalEnrollment.SelectedTab.Name
                Case Me.tpgPatientAllergies.Name

                    LoadGridData(Me.dgvPatientAllergies, patientAllergies)
                    ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    For rowNo As Integer = 0 To patientAllergies.Rows.Count - 1

                        Dim row As DataRow = patientAllergies.Rows(rowNo)

                        With Me.dgvPatientAllergies

                            .Rows.Add()

                            .Item(Me.colAllergyNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "AllergyNo")
                            .Item(Me.colReaction.Name, rowNo).Value = DateMayBeEnteredIn(row, "Reaction")

                        End With

                    Next

                    ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvPatientAllergies.Rows.Clear()
                    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    'Private Function PatientAllergiesList() As List(Of DBConnect)

    '    Dim lPatientAllergies As New List(Of DBConnect)

    '    Dim transactions As New List(Of TransactionList(Of DBConnect))

    '    Try

    '        Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

    '        For rowNo As Integer = 0 To Me.dgvPatientAllergies.RowCount - 2

    '            Using oPatientAllergies As New SyncSoft.SQLDb.PatientAllergies()

    '                Dim cells As DataGridViewCellCollection = Me.dgvPatientAllergies.Rows(rowNo).Cells

    '                With oPatientAllergies

    '                    .PatientNo = patientNo
    '                    .AllergyNo = StringEnteredIn(cells, Me.colAllergyNo, "Allergy No!")
    '                    .Reaction = StringMayBeEnteredIn(cells, Me.colReaction)

    '                End With

    '                lPatientAllergies.Add(oPatientAllergies)

    '                oPatientAllergies.Save()

    '            End Using
    '            transactions.Add(New TransactionList(Of DBConnect)(lPatientAllergies, Action.Save))

    '            DoTransactions(transactions)


    '            DisplayMessage("Allergies Successfully Saved!")
    '        Next


    '        Return lPatientAllergies

    '    Catch ex As Exception
    '        Me.tbcMaternalEnrollment.SelectTab(Me.tpgPatientAllergies.Name)
    '        Throw ex

    '    End Try

    'End Function

#End Region

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim fFindObject As New frmFindObject(ObjectName.PatientNo)

            If fFindObject.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim patientNo As String = RevertText(fFindObject.GetPatientNo())
                Me.stbPatientNo.Text = patientNo
                Me.ShowPatientDetails(patientNo)
                Me.LoadPatientAllergies(patientNo)
            End If

        Catch eX As Exception
            ErrorMessage(eX)
            Me.btnSearch.PerformClick()

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cboBloodTransfusion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboBloodTransfusion.SelectedIndexChanged
        Dim BloodTransfusionID As String = StringValueMayBeEnteredIn(cboBloodTransfusion, "Blood Transfusion")

        If String.IsNullOrEmpty(BloodTransfusionID) Then Return


        If BloodTransfusionID.Equals(oBloodTransfusionID.Yes) Then
            dtpBloodTransfusionDate.Enabled = True

        Else
            dtpBloodTransfusionDate.Enabled = False

        End If
    End Sub


    Private Sub btnFindANCNo_Click(sender As System.Object, e As System.EventArgs) Handles btnFindANCNo.Click
        Dim fFindANCNo As New frmFindAutoNo(Me.stbANCNo, AutoNumber.ANCNo)
        fFindANCNo.ShowDialog(Me)
        Me.stbANCNo.Focus()
    End Sub

    Private Sub dgvOBHistory_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOBHistory.CellEndEdit

        Dim oAbortion As New LookupDataID.YesNoID
        Dim oAbortionPeriodID As New LookupDataID.AbortionPeriodID
        Dim oTypeOfDeliveryID As New LookupDataID.TypeOfDeliveryID
        Dim oThirdStageID As New LookupDataID.PregnancyOutcomeID
        Dim oPeurPerinumID As New LookupDataID.PregnancyOutcomeID
        Dim oGenderID As New LookupDataID.GenderID
        Dim oChildStatusID As New LookupDataID.ChildStatusID

        Dim selectedRow As Integer = Me.dgvOBHistory.CurrentCell.RowIndex
        Dim Row As New DataGrid
        Dim Abortion As String = StringMayBeEnteredIn(Me.dgvOBHistory.Rows(selectedRow).Cells, Me.colObstetricAbortionID)

     
        Try
            If Abortion.ToUpper.Equals(oAbortion.Yes.ToUpper) Then
                Me.dgvOBHistory.Item(Me.colObstetricAbortionPeriodID.Name, selectedRow).Value = oAbortionPeriodID.Below12Weeks
                Me.dgvOBHistory.Item(Me.colTypeOfDelivery.Name, selectedRow).Value = oTypeOfDeliveryID.NA
                Me.dgvOBHistory.Item(Me.colObstetricPeurPerinumID.Name, selectedRow).Value = oPeurPerinumID.NA
                Me.dgvOBHistory.Item(Me.colObstetricThirdStageID.Name, selectedRow).Value = oThirdStageID.NA
                Me.dgvOBHistory.Item(Me.colObstetricGenderID.Name, selectedRow).Value = oGenderID.NA
                Me.dgvOBHistory.Item(Me.colObstetricChildStatusID.Name, selectedRow).Value = oChildStatusID.NA
                Me.dgvOBHistory.Item(Me.colObstetricBirthWeight.Name, selectedRow).Value = 0
                Me.dgvOBHistory.Item(Me.colObstetricImmunised.Name, selectedRow).Value = 0

            Else

                Me.dgvOBHistory.Item(Me.colObstetricAbortionPeriodID.Name, selectedRow).Value = oAbortionPeriodID.NA
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub stbPatientNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbPatientNo.Leave
        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            If Not String.IsNullOrEmpty(patientNo) Then Me.ShowPatientDetails(patientNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Function ContraceptivesHistoryList() As List(Of DBConnect)

        Dim lContraceptivesHistory As New List(Of DBConnect)

        Try

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

            For rowNo As Integer = 0 To Me.dgvContraceptives.RowCount - 2
                Dim cells As DataGridViewCellCollection = Me.dgvContraceptives.Rows(rowNo).Cells
                Dim dateStarted As Date = CDate(CStr(DateMayBeEnteredIn(cells, Me.colContraceptiveDateStarted)))

                Using oContraceptivesHistory As New SyncSoft.SQLDb.ContraceptivesHistory()


                    With oContraceptivesHistory

                        .PatientNo = patientNo
                        .ContraceptiveID = StringMayBeEnteredIn(cells, Me.colContraceptiveID)
                        .ComplicationsID = StringMayBeEnteredIn(cells, Me.colComplications)
                        .ComplicationDetails = StringMayBeEnteredIn(cells, Me.colComplicationDetails)
                        .DateStarted = dateStarted
                        .DiscontinuedRemovedID = StringMayBeEnteredIn(cells, Me.colContraceptiveDiscontinued)
                        .RemovalReasonsID = StringMayBeEnteredIn(cells, Me.colContraceptiveRemovalReasons)
                        .Notes = StringMayBeEnteredIn(cells, Me.colContraceptiveNotes)
                        .LoginID = CurrentUser.LoginID

                    End With

                    lContraceptivesHistory.Add(oContraceptivesHistory)

                End Using

            Next

            Return lContraceptivesHistory

        Catch ex As Exception
            Me.tbcCurrentPregnancy.SelectTab(Me.tpgContraceptivesHistory.Name)
            Throw ex

        End Try

    End Function

    Private Sub dgvContraceptives_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvContraceptives.CellEndEdit
        Dim oComplications As New LookupDataID.YesNoID
        Dim oComplicationDetails As New LookupDataID.ContraceptivesComplicationsID
        Dim oContraceptiveDiscontinued As New LookupDataID.YesNoID
        Dim oContraceptiveRemovalReasons As New LookupDataID.ReasonsForRemovalID

        Dim selectedRow As Integer = Me.dgvContraceptives.CurrentCell.RowIndex
        Dim Row As New DataGrid
        Dim Complications As String = StringMayBeEnteredIn(Me.dgvContraceptives.Rows(selectedRow).Cells, Me.colComplications)
        Dim ContraceptiveDiscontinued As String = StringMayBeEnteredIn(Me.dgvContraceptives.Rows(selectedRow).Cells, Me.colContraceptiveDiscontinued)

        Try


            If ContraceptiveDiscontinued.ToUpper.Equals(oContraceptiveDiscontinued.No.ToUpper) Then
                Me.dgvContraceptives.Item(Me.colContraceptiveRemovalReasons.Name, selectedRow).Value = oContraceptiveRemovalReasons.NA
                Me.dgvContraceptives.Item(Me.colComplicationDetails.Name, selectedRow).Value = oComplicationDetails.NA
            Else

                Me.dgvContraceptives.Item(Me.colContraceptiveRemovalReasons.Name, selectedRow).Value = oContraceptiveRemovalReasons.WeightGainOrLoss
                Me.dgvContraceptives.Item(Me.colComplicationDetails.Name, selectedRow).Value = oComplicationDetails.NauseaOrVomiting
            End If

        Catch ex As Exception

        End Try

    End Sub
End Class