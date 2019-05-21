
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports SyncSoft.SQLDb.Lookup

Public Class frmExaminations

#Region " Fields "

#End Region

#Region " Validations "

    Private Sub dtpFollowupDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpFollowupDate.Validating

        Try

            Dim errorMSG As String = "Followup date can't be before visit date!"
            Dim visitDate As Date = DateMayBeEnteredIn(Me.txtVisitDate)
            Dim followupDate As Date = DateMayBeEnteredIn(Me.dtpFollowupDate)

            If followupDate.Equals(AppData.NullDateValue) Then Return

            If followupDate < visitDate Then
                ErrProvider.SetError(Me.dtpFollowupDate, errorMSG)
                Me.dtpFollowupDate.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpFollowupDate, "")
            End If

        Catch ex As Exception
            Return

        End Try

    End Sub

#End Region

    Private Sub frmExaminations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboExamVisitTypeID, LookupObjects.ExamVisitType, False)
            LoadLookupDataCombo(Me.cboOedemaID, LookupObjects.Oedema, False)
            LoadLookupDataCombo(Me.cboPregnancyStatusID, LookupObjects.PregnancyStatus, False)
            LoadLookupDataCombo(Me.cboMUACStatusID, LookupObjects.MUACStatus, False)
            LoadLookupDataCombo(Me.cboTBStatusID, LookupObjects.TBStatus, False)
            LoadLookupDataCombo(Me.cboFunctionalStatusID, LookupObjects.FunctionalStatus, False)
            LoadLookupDataCombo(Me.cboWHOStageID, LookupObjects.WHOStage, False)
            LoadLookupDataCombo(Me.cboCPTAdhereID, LookupObjects.AdhereStatus, False)
            LoadLookupDataCombo(Me.cboNutritionalSupID, LookupObjects.NutritionalSup, False)
            LoadLookupDataCombo(Me.cboARVAdhereID, LookupObjects.AdhereStatus, False)
            LoadLookupDataCombo(Me.clbFPMethods, LookupObjects.FPMethods, False)
            LoadLookupDataCombo(Me.clbSideEffects, LookupObjects.SideEffects, False)
            LoadLookupDataCombo(Me.clbNewOI, LookupObjects.NewOI, False)
            LoadLookupDataCombo(Me.clbARVAdhereWhy, LookupObjects.ARVAdhereWhy, False)
            LoadLookupDataCombo(Me.clbInvestigations, LookupObjects.Investigations, False)

            Me.LoadDrugCombinations()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmExaminations_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub ClearControls()
        Me.txtPatientNo.Clear()
        Me.txtFullName.Clear()
        Me.txtAge.Clear()
        Me.txtGender.Clear()
        Me.txtVisitDate.Clear()
        Me.txtPrimaryDoctor.Clear()
        Me.cboExamVisitTypeID.SelectedIndex = -1
        Me.cboExamVisitTypeID.SelectedIndex = -1
        Me.dtpFollowupDate.Value = Today
        Me.dtpFollowupDate.Checked = False
        Me.nbxDurationStartART.Clear()
        Me.nbxDurationCurrentART.Clear()
        Me.nbxWeight.Clear()
        Me.nbxHeight.Clear()
        Me.cboCombination.Text = String.Empty
    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged
        Me.CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ClearControls()
    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oExamVisitTypeID As New LookupDataID.ExamVisitTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Me.ClearControls()

            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")

            Dim row As DataRow = visits.Rows(0)

            Me.txtPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            Me.txtFullName.Text = StringEnteredIn(row, "FullName")
            Me.txtAge.Text = StringEnteredIn(row, "Age")
            Me.txtGender.Text = StringEnteredIn(row, "Gender")
            Me.txtVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.txtPrimaryDoctor.Text = StringMayBeEnteredIn(row, "PrimaryDoctor")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim isScheduledVisit As Boolean = BooleanMayBeEnteredIn(row, "IsScheduledVisit")
            If isScheduledVisit Then
                Me.cboExamVisitTypeID.SelectedValue = oExamVisitTypeID.Scheduled
            Else : Me.cboExamVisitTypeID.SelectedValue = oExamVisitTypeID.Unscheduled
            End If
            Dim followupDate As Date = DateMayBeEnteredIn(row, "NextAppointmentDate")
            If followupDate.Equals(AppData.NullDateValue) Then
                Me.dtpFollowupDate.Value = Today
                Me.dtpFollowupDate.Checked = False
            Else : Me.dtpFollowupDate.Value = followupDate
            End If
            Me.nbxDurationStartART.Value = StringMayBeEnteredIn(row, "DurationStartART")
            Me.nbxDurationCurrentART.Value = StringMayBeEnteredIn(row, "DurationCurrentART")
            Me.nbxWeight.Value = StringMayBeEnteredIn(row, "Weight")
            Me.nbxHeight.Value = StringMayBeEnteredIn(row, "Height")
            Me.cboCombination.Text = StringMayBeEnteredIn(row, "Combination")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub LoadDrugCombinations()

        Dim oDrugCombinations As New SyncSoft.SQLDb.DrugCombinations()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Drug Combinatios
            Dim drugCombinations As DataTable = oDrugCombinations.GetDrugCombinations().Tables("DrugCombinations")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboCombination, drugCombinations, "Combination")
            Me.cboCombination.Items.Insert(0, "")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)
        Me.stbVisitNo.Focus()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oExaminations As New SyncSoft.SQLDb.Examinations()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oExaminations.VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            DisplayMessage(oExaminations.Delete())
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

        Dim oExaminations As New SyncSoft.SQLDb.Examinations()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim VisitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim dataSource As DataTable = oExaminations.GetExaminations(VisitNo).Tables("Examinations")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oExaminations As New SyncSoft.SQLDb.Examinations()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oExaminations

                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .ExamVisitTypeID = StringValueEnteredIn(Me.cboExamVisitTypeID, "Exam Visit Type!")
                .FollowupDate = DateMayBeEnteredIn(Me.dtpFollowupDate)
                .DurationStartART = IntegerMayBeEnteredIn(Me.nbxDurationStartART, -1)
                .DurationCurrentART = IntegerMayBeEnteredIn(Me.nbxDurationCurrentART, -1)
                .OedemaID = StringValueEnteredIn(Me.cboOedemaID, "Oedema!")
                .PregnancyStatusID = StringValueEnteredIn(Me.cboPregnancyStatusID, "Pregnancy Status!")
                .ExpectedDeliveryDate = DateMayBeEnteredIn(Me.dtpExpectedDeliveryDate)
                .PMTCT = Me.chkPMTCT.Checked
                .GestationalAge = IntegerMayBeEnteredIn(Me.nbxGestationalAge, -1)
                .MUACID = StringValueEnteredIn(Me.cboMUACStatusID, "MUAC Status!")
                .FPMethods = StringToSplitSelectedIn(Me.clbFPMethods, LookupObjects.FPMethods)
                .TBStatusID = StringValueEnteredIn(Me.cboTBStatusID, "TB Status!")
                .TBRxStartDate = DateMayBeEnteredIn(Me.dtpTBRxStartDate)
                .TBRxStopDate = DateMayBeEnteredIn(Me.dtpTBRxStopDate)
                .TBRegNo = StringMayBeEnteredIn(Me.stbTBRegNo)
                .SideEffects = StringToSplitSelectedIn(Me.clbSideEffects, LookupObjects.SideEffects)
                .NewOI = StringToSplitSelectedIn(Me.clbNewOI, LookupObjects.NewOI)
                .FunctionalStatusID = StringValueEnteredIn(Me.cboFunctionalStatusID, "Functional Status!")
                .WHOStageID = StringValueEnteredIn(Me.cboWHOStageID, "WHO Stage!")
                .CPTAdhereID = StringValueEnteredIn(Me.cboCPTAdhereID, "CPT Adhere!")
                .CPTDosage = IntegerMayBeEnteredIn(Me.nbxCPTDosage, -1)
                .CPTDuration = IntegerMayBeEnteredIn(Me.nbxCPTDuration, -1)
                .OtherMeds = StringMayBeEnteredIn(Me.stbOtherMeds)
                .NutritionalSupID = StringValueEnteredIn(Me.cboNutritionalSupID, "Nutritional Sup!")
                .ARVAdhereID = StringValueEnteredIn(Me.cboARVAdhereID, "ARV Adhere!")
                .ARVAdhereWhy = StringToSplitSelectedIn(Me.clbARVAdhereWhy, LookupObjects.ARVAdhereWhy)
                .Combination = StringMayBeEnteredIn(Me.cboCombination)
                .ARVDosage = IntegerMayBeEnteredIn(Me.nbxARVDosage, -1)
                .ARVDuration = IntegerMayBeEnteredIn(Me.nbxARVDuration, -1)
                .CD4ABS = SingleMayBeEnteredIn(Me.nbxCD4ABS, -1)
                .CD4PCT = SingleMayBeEnteredIn(Me.nbxCD4PCT, -1)
                .Investigations = StringToSplitSelectedIn(Me.clbInvestigations, LookupObjects.Investigations)
                .Refer = StringMayBeEnteredIn(Me.stbRefer)
                .DaysHOSP = IntegerMayBeEnteredIn(Me.nbxDaysHOSP, -1)
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oExaminations.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oExaminations.Update())
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

End Class