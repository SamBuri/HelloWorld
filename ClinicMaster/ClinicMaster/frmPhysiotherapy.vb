
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

Public Class frmPhysiotherapy

#Region " Fields "
    Private alerts As DataTable
    Private alertsStartDateTime As Date = Now

    Private physiotherapySaved As Boolean = True
    Private diagnosisSaved As Boolean = True
    Private _DiagnosisValue As String = String.Empty

    Private oCurrentVisit As CurrentVisit
    Private currentAllSaved As Boolean = True
    Private currentVisitNo As String = String.Empty
    Private oVariousOptions As New VariousOptions()
    Private defaultVisitNo As String = String.Empty
    Private oExercisotherapyID As New LookupDataID.ExercisotherapyID
    Private oElectrotherapyID As New LookupDataID.ElectrotherapyID
    Private oManipulativeTechniqueID As New LookupDataID.ManipulativeTechniqueID
    Private oTherapyCategoryID As New LookupDataID.TherapyCategoryID

    Private diseases As DataTable
#End Region

    Private Sub frmPhysiotherapy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            'Me.ShowSentAlerts()
            Me.LoadDiseases()
            LoadLookupDataCombo(Me.cboOnMedication, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboLevelOfDependenceOrADLS, LookupObjects.LevelOfDependence, False)
            LoadLookupDataCombo(Me.cboPain24hrsOrVAS, LookupObjects.Pallor, False)
            LoadLookupDataCombo(Me.colCategory, LookupObjects.TherapyCategory, False)

            'Me.ClearControls()
            'Me.ResetControls()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmPhysiotherapy_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oPhysiotherapy As New SyncSoft.SQLDb.Physiotherapy()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return



            DisplayMessage(oPhysiotherapy.Delete())
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



        Dim oPhysiotherapy As New SyncSoft.SQLDb.Physiotherapy()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim VisitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            Dim dataSource As DataTable = oPhysiotherapy.GetPhysiotherapy(VisitNo).Tables("Physiotherapy")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oPhysiotherapy As New SyncSoft.SQLDb.Physiotherapy()

        Try
            Me.Cursor = Cursors.WaitCursor()
            For rowNo As Integer = 0 To Me.dgvTreatmentPlan.RowCount - 2
                Dim cells As DataGridViewCellCollection = Me.dgvTreatmentPlan.Rows(rowNo).Cells
                Try

                Catch ex As Exception

                End Try

                Dim therapyNotes As String = StringMayBeEnteredIn(cells, Me.colPhysiotherapyNotes)
                Dim provisionalDiagnosis As String = StringMayBeEnteredIn(Me.stbProvisionalDiagnosis)

                With oPhysiotherapy

                    .VisitNo = RevertText(StringEnteredIn(stbVisitNo, "Visit's No!"))
                    .OnMedication = StringValueMayBeEnteredIn(Me.cboOnMedication, "On Medication!")
                    .Medication = StringMayBeEnteredIn(Me.stbMedication)
                    .Pain24hoursOrVAS = StringValueMayBeEnteredIn(Me.cboPain24hrsOrVAS, "Pain 24 hours Or VAS!")
                    .LevelOfDependenceOrADLS = StringValueMayBeEnteredIn(Me.cboLevelOfDependenceOrADLS, "Level Of Dependence Or ADLS!")
                    .MuscleStatus = StringMayBeEnteredIn(Me.stbMuscleStatus)
                    .StatusOfJoints = StringMayBeEnteredIn(Me.stbStatusOfJoints)
                    .Sensitivity = StringMayBeEnteredIn(Me.stbSensitivity)
                    .WalkingAnalysis = StringMayBeEnteredIn(Me.stbWalkingAnalysis)
                    .ShortTermTreatmentTargets = StringMayBeEnteredIn(Me.stbShortTermTreatmentTargets)
                    .LongTermTreatmentTargets = StringMayBeEnteredIn(Me.stbLongTermTreatmentTargets)
                    .ProvisionalDiagnosis = provisionalDiagnosis
                    .LoginID = CurrentUser.LoginID

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ValidateEntriesIn(Me)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    .Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    physiotherapySaved = True
                    Me.dgvPhysiotherapyDiagnosis.Item(Me.colDiagnosisSaved.Name, rowNo).Value = True
                    Me.dgvTreatmentPlan.Item(Me.colPhysiotherapyTechniquesSaved.Name, rowNo).Value = True
                    DisplayMessage("Physiotherapy Details Successfully Saved!")
                    Me.SavePhysioDiagnosis()

                    Me.SaveTreatmentPlan()

                End With
            Next

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                Case ButtonCaption.Update

                    DisplayMessage(oPhysiotherapy.Update())
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

#Region "Load Options"
    Private Sub LoadPhysiotherapy(ByVal visitNo As String)

        Dim oPhysiotherapy As New SyncSoft.SQLDb.Physiotherapy

        Try
            Me.dgvTreatmentPlan.Rows.Clear()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Dim Physiotherapy As DataTable = oPhysiotherapy.GetPhysiotherapy(visitNo).Tables("Physiotherapy")
            If Physiotherapy Is Nothing OrElse Physiotherapy.Rows.Count < 1 Then Return


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvTreatmentPlan, Physiotherapy)
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To Physiotherapy.Rows.Count - 1

                Dim row As DataRow = Physiotherapy.Rows(pos)
                With Me.dgvTreatmentPlan
                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colCategory.Name, pos).Value = StringMayBeEnteredIn(row, "CategoryID")
                    .Item(Me.colTherapyTechnique.Name, pos).Value = StringMayBeEnteredIn(row, "TherapyTechniques")
                    .Item(Me.colPhysiotherapyNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")
                    .Item(Me.colPhysiotherapyTechniquesSaved.Name, pos).Value = True
                End With

            Next
            For Each row As DataRow In Physiotherapy.Rows

                Me.cboOnMedication.SelectedValue = StringMayBeEnteredIn(row, "OnMedication")
                Me.stbMedication.Text = StringMayBeEnteredIn(row, "Medication")
                Me.cboPain24hrsOrVAS.SelectedValue = StringMayBeEnteredIn(row, "Pain24hoursOrVAS")
                Me.cboLevelOfDependenceOrADLS.SelectedValue = StringMayBeEnteredIn(row, "LevelOfDependenceOrADLS")
                Me.stbMuscleStatus.Text = StringMayBeEnteredIn(row, "MuscleStatus")
                Me.stbStatusOfJoints.Text = StringMayBeEnteredIn(row, "StatusOfJoints")
                Me.stbSensitivity.Text = StringMayBeEnteredIn(row, "Sensitivity")
                Me.stbWalkingAnalysis.Text = StringMayBeEnteredIn(row, "WalkingAnalysis")
                Me.stbShortTermTreatmentTargets.Text = StringMayBeEnteredIn(row, "ShortTermTreatmentTargets")
                Me.stbLongTermTreatmentTargets.Text = StringMayBeEnteredIn(row, "LongTermTreatmentTargets")

            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colCategory.ReadOnly = True
            Me.colTherapyTechnique.ReadOnly = True
            Me.colTherapyID.ReadOnly = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            physiotherapySaved = True
        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)
        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oExamVisitTypeID As New LookupDataID.ExamVisitTypeID

        Try
          
            Dim Visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = Visits.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            'Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")
            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
            If visitDate = AppData.NullDateValue Then Return
            'Me.DeleteAlerts(visitNo, visitDate)


            Me.fbnSearch_Click(Me, EventArgs.Empty)
        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub


    Private Sub btnLoadPeriodicVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPeriodicVisits.Click

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicVisits As New frmPeriodicVisits(Me.stbVisitNo)
            fPeriodicVisits.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            Me.ShowPatientDetails(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Me.ClearControls()

        End Try

    End Sub

    Private Sub LoadDiseases()

        Dim oDiseases As New SyncSoft.SQLDb.PhysioDiseases()
        Dim oSetupData As New SetupData()

        Try
              Me.Cursor = Cursors.WaitCursor

            ' Load from Diseases
            diseases = oDiseases.GetPhysioDiseases().Tables("PhysioDiseases")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colPhysioDiseaseDiagnosis.Sorted = False
            LoadComboData(Me.colPhysioDiseaseDiagnosis, diseases, "PhysioDiseaseNo", "DiseaseName")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region "Physiotherapy Grid"

    Private Sub dgvTreatmentPlan_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTreatmentPlan.CellClick, dgvPhysiotherapyDiagnosis.CellClick

        Try
            Dim oCategoryID As New LookupDataID.TherapyCategoryID()

            If e.ColumnIndex <> Me.colTherapyTechnique.Index OrElse Me.dgvTreatmentPlan.Rows.Count <= 1 Then Return
            Dim selectedRow As Integer = Me.dgvTreatmentPlan.CurrentCell.RowIndex

            Dim categoryID As String = StringMayBeEnteredIn(Me.dgvTreatmentPlan.Rows(selectedRow).Cells, Me.colCategory)

            '    If categoryID.ToUpper().Equals(oCategoryID.ManipulativeTechnique) And Not String.IsNullOrEmpty(categoryID) Then
            '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '        Me.dgvTreatmentPlan.Item(Me.colTherapyTechnique.Name, selectedRow).Value = String.Empty
            '    Dim dSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Manipulative Technique", "Therapy Technique", "Therapy Technique Name", Me.ManipulativeTechniqueItems(), "DataDes",
            '                                                     "DataDes", "ItemFullName", Me.dgvTreatmentPlan, Me.colTherapyTechnique, e.RowIndex)

            '    dSelectItem.ShowDialog(Me)
            '        Me.dgvTreatmentPlan.Item(Me.colTherapyTechnique.Name, selectedRow).Value = GetLookupDataID(LookupObjects.ManipulativeTechnique, (Me.dgvTreatmentPlan.Item(Me.colTherapyTechnique.Name, selectedRow).Value).ToString).ToString
            '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'End If
            If categoryID.Equals(oCategoryID.ManipulativeTechnique) And Not String.IsNullOrEmpty(categoryID) Then
                ''    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.dgvTreatmentPlan.Item(Me.colTherapyTechnique.Name, selectedRow).Value = String.Empty
                Dim tSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Manipulative Technique", "Therapy Technique", "Therapy Technique Name", Me.ManipulativeTechniqueItems(), "DataDes",
                                                             "DataDes", "ItemFullName", Me.dgvTreatmentPlan, Me.colTherapyTechnique, e.RowIndex)

                tSelectItem.ShowDialog(Me)
                'Me.dgvPhysiotherapy.Item(Me.colFluidsMeasureRouteID.Name, selectedRow).Value = GetLookupDataDes((Me.dgvPhysiotherapy.Item(Me.colFluidsMeasureFluidRoute.Name, selectedRow).Value).ToString)
                Me.dgvTreatmentPlan.Item(Me.colTherapyID.Name, selectedRow).Value = GetLookupDataID(LookupObjects.ManipulativeTechnique, (Me.dgvTreatmentPlan.Item(Me.colTherapyTechnique.Name, selectedRow).Value).ToString).ToString '
                '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            If categoryID.ToUpper().Equals(oCategoryID.Electrotherapy) And Not String.IsNullOrEmpty(categoryID) Then
                ''    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.dgvTreatmentPlan.Item(Me.colTherapyTechnique.Name, selectedRow).Value = String.Empty
                Dim tSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Electrotherapy Technique", "Therapy Technique", "Therapy Technique Name", Me.ElectrotherapyItems(), "DataDes",
                                                             "DataDes", "ItemFullName", Me.dgvTreatmentPlan, Me.colTherapyTechnique, e.RowIndex)

                tSelectItem.ShowDialog(Me)
                'Me.dgvPhysiotherapy.Item(Me.colFluidsMeasureRouteID.Name, selectedRow).Value = GetLookupDataDes((Me.dgvPhysiotherapy.Item(Me.colFluidsMeasureFluidRoute.Name, selectedRow).Value).ToString)
                Me.dgvTreatmentPlan.Item(Me.colTherapyID.Name, selectedRow).Value = GetLookupDataID(LookupObjects.Electrotherapy, (Me.dgvTreatmentPlan.Item(Me.colTherapyTechnique.Name, selectedRow).Value).ToString).ToString '
                '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            If categoryID.ToUpper().Equals(oCategoryID.Exercisotherapy) And Not String.IsNullOrEmpty(categoryID) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.dgvTreatmentPlan.Item(Me.colTherapyTechnique.Name, selectedRow).Value = String.Empty
                Dim qSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Exercisotherapy Technique", "Therapy Technique", "Therapy Technique Name", Me.ExercisotherapyItems(), "DataDes",
                                                             "DataDes", "ItemFullName", Me.dgvTreatmentPlan, Me.colTherapyTechnique, e.RowIndex)

                qSelectItem.ShowDialog(Me)
                'Me.dgvPhysiotherapy.Item(Me.colFluidsMeasureRouteID.Name, selectedRow).Value = GetLookupDataDes((Me.dgvPhysiotherapy.Item(Me.colFluidsMeasureFluidRoute.Name, selectedRow).Value).ToString)
                Me.dgvTreatmentPlan.Item(Me.colTherapyID.Name, selectedRow).Value = GetLookupDataID(LookupObjects.Exercisotherapy, (Me.dgvTreatmentPlan.Item(Me.colTherapyTechnique.Name, selectedRow).Value).ToString).ToString '
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If



        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub


    Private Function ManipulativeTechniqueItems() As DataTable

        Dim Items As DataTable
        Dim oTreatmentPlan As New SyncSoft.SQLDb.TreatmentPlan()

        Try
            Items = oTreatmentPlan.GetManipulativeTechniqueItems().Tables("ManipulativeTechniqueItems")
            '''''''''''''''''''''''''''''''''''''''''''''''''
            Return Items
            '''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Private Function ElectrotherapyItems() As DataTable

        Dim Items As DataTable
        Dim oTreatmentPlan As New SyncSoft.SQLDb.TreatmentPlan()

        Try
            Items = oTreatmentPlan.GetElectrotherapyItems().Tables("ElectrotherapyItems")
            '''''''''''''''''''''''''''''''''''''''''''''''''
            Return Items
            '''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Private Function ExercisotherapyItems() As DataTable

        Dim Items As DataTable
        Dim oTreatmentPlan As New SyncSoft.SQLDb.TreatmentPlan()

        Try
            Items = oTreatmentPlan.GetExercisotherapyItems().Tables("ExercisotherapyItems")
            '''''''''''''''''''''''''''''''''''''''''''''''''
            Return Items
            '''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function


#End Region

#Region " Diagnosis - Grid "

    Private Sub dgvPhysioDiagnosis_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPhysiotherapyDiagnosis.CellBeginEdit

        If e.ColumnIndex <> Me.colPhysioDiseaseDiagnosis.Index OrElse Me.dgvPhysiotherapyDiagnosis.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvPhysiotherapyDiagnosis.CurrentCell.RowIndex
        _DiagnosisValue = StringMayBeEnteredIn(Me.dgvPhysiotherapyDiagnosis.Rows(selectedRow).Cells, Me.colPhysioDiseaseDiagnosis)

    End Sub

    Private Sub dgvPhysiotherapyDiagnosis_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPhysiotherapyDiagnosis.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colPhysioDiseaseDiagnosis.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvPhysiotherapyDiagnosis.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvPhysiotherapyDiagnosis.CurrentCell.RowIndex
                    Me.SetDiagnosisEntries(selectedRow)

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetDiagnosisEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvPhysiotherapyDiagnosis.Rows(selectedRow).Cells, Me.colPhysioDiseaseDiagnosis)

            If CBool(Me.dgvPhysiotherapyDiagnosis.Item(Me.colDiagnosisSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim physioDiagnosis As EnumerableRowCollection(Of DataRow) = Diseases.AsEnumerable()
                Dim diagnosisDisplay As String = (From data In physioDiagnosis
                                    Where data.Field(Of String)("DiseaseCode").ToUpper().Equals(_DiagnosisValue.ToUpper())
                                    Select data.Field(Of String)("DiseaseName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Diagnosis (" + diagnosisDisplay + ") can't be edited!")
                Me.dgvPhysiotherapyDiagnosis.Item(Me.colPhysioDiseaseDiagnosis.Name, selectedRow).Value = _DiagnosisValue
                Me.dgvPhysiotherapyDiagnosis.Item(Me.colPhysioDiseaseDiagnosis.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvPhysiotherapyDiagnosis.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvPhysiotherapyDiagnosis.Rows(rowNo).Cells, Me.colPhysioDiseaseDiagnosis)
                    If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim diagnosis As EnumerableRowCollection(Of DataRow) = diseases.AsEnumerable()
                        Dim enteredDisplay As String = (From data In diagnosis
                                            Where data.Field(Of String)("DiseaseCode").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("DiseaseName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Diagnosis (" + enteredDisplay + ") already entered!")
                        Me.dgvPhysiotherapyDiagnosis.Item(Me.colPhysioDiseaseDiagnosis.Name, selectedRow).Value = _DiagnosisValue
                        Me.dgvPhysiotherapyDiagnosis.Item(Me.colPhysioDiseaseDiagnosis.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If diseases Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

            For Each row As DataRow In diseases.Select("DiseaseCode = '" + selectedItem + "'")
                Me.dgvPhysiotherapyDiagnosis.Item(Me.colPhysioDiseaseDiagnosis.Name, selectedRow).Value = selectedItem
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvPhysiotherapyDiagnosis_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvPhysiotherapyDiagnosis.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPhysioDiagnosis As New SyncSoft.SQLDb.PhysioDiagnosis()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvPhysiotherapyDiagnosis.Item(Me.colDiagnosisSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim physioDiagnosis As String = CStr(Me.dgvPhysiotherapyDiagnosis.Item(Me.colPhysioDiseaseDiagnosis.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With oPhysioDiagnosis
                .VisitNo = visitNo
                '.DiseaseCode = physioDiagnosis
                DisplayMessage(.Delete())
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvPhysiotherapyDiagnosis_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvPhysiotherapyDiagnosis.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    'Private Sub LoadPhysioDiagnosis(ByVal visitNo As String)

    '    Dim oPhysioDiagnosis As New SyncSoft.SQLDb.PhysioDiagnosis()

    '    Try

    '        Me.dgvPhysiotherapyDiagnosis.Rows.Clear()

    '        ' Load items not yet paid for

    '        Dim physioDiagnosis As DataTable
    '        '= oPhysioDiagnosis.GetPhysioDiagnosis(RevertText(visitNo)).Tables("PhysioDiagnosis")
    '        If physioDiagnosis Is Nothing OrElse physioDiagnosis.Rows.Count < 1 Then Return

    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '        For pos As Integer = 0 To physioDiagnosis.Rows.Count - 1

    '            Dim row As DataRow = physioDiagnosis.Rows(pos)

    '            With Me.dgvPhysiotherapyDiagnosis
    '                ' Ensure that you add a new row
    '                .Rows.Add()
    '                .Item(Me.colPhysioDiseaseDiagnosis.Name, pos).Value = StringEnteredIn(row, "DiseaseCode")
    '                '.Item(Me.colICDDiagnosisCode.Name, pos).Value = StringEnteredIn(row, "DiseaseCode")
    '                .Item(Me.colPhysioDiagnosisNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")
    '                .Item(Me.colDiagnosisSaved.Name, pos).Value = True
    '            End With
    '        Next

    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '    Catch ex As Exception
    '        Throw ex

    '    End Try

    'End Sub

#End Region

    Private Sub ClearControls()
        Me.stbFullName.Clear()
        Me.stbAge.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbVisitDate.Clear()
        ' Me.spbPhoto.Image = Nothing
        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgExamination)
        ResetControlsIn(Me.tpgPhysiotherapyTreatment)
        ResetControlsIn(Me.dgvPhysiotherapyDiagnosis)
    End Sub

#Region "Physiotherapy Templates"

    Private Sub stbMuscleStatus_Enter(sender As System.Object, e As System.EventArgs) Handles stbMuscleStatus.Enter
        Me.PlaceTemplateButton(Me.stbMuscleStatus)
    End Sub

    Private Sub stbStatusOfJoints_Enter(sender As System.Object, e As System.EventArgs) Handles stbStatusOfJoints.Enter
        Me.PlaceTemplateButton(Me.stbStatusOfJoints)
    End Sub

    Private Sub stbSensitivity_Enter(sender As System.Object, e As System.EventArgs) Handles stbSensitivity.Enter
        Me.PlaceTemplateButton(Me.stbSensitivity)
    End Sub

    Private Sub stbWalkingAnalysis_Enter(sender As System.Object, e As System.EventArgs) Handles stbWalkingAnalysis.Enter
        Me.PlaceTemplateButton(Me.stbWalkingAnalysis)
    End Sub

    Private Sub stbShortTermTreatmentTargets_Enter(sender As System.Object, e As System.EventArgs)
        Me.PlaceTemplateButton(Me.stbShortTermTreatmentTargets)
    End Sub

    Private Sub stbLongTermTreatmentTargets_Enter(sender As System.Object, e As System.EventArgs)
        Me.PlaceTemplateButton(Me.stbLongTermTreatmentTargets)
    End Sub

    Private Sub stbProvisionalDiagnosis_Enter(sender As System.Object, e As System.EventArgs) Handles stbProvisionalDiagnosis.Enter
        Me.PlaceTemplateButton(Me.stbProvisionalDiagnosis)
    End Sub

    Private Sub tpgExamination_Leave(sender As System.Object, e As System.EventArgs) Handles tpgTreatmentTargets.Leave
        Me.btnLoadTemplate.Visible = True
    End Sub

    Private Sub PlaceTemplateButton(textControl As TextBox)
        Dim x As Integer = textControl.Location.X
        Dim y As Integer = textControl.Location.Y
        Dim width As Integer = textControl.Size.Width
        Me.btnLoadTemplate.Location = New System.Drawing.Point(x + width, y)
        Me.btnLoadTemplate.TabIndex = textControl.TabIndex - 1
        Me.btnLoadTemplate.BringToFront()
        Me.btnLoadTemplate.Visible = True
    End Sub

#End Region

#Region " Save Methods "
    Private Sub SavePhysioDiagnosis()

        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim lDiagnosis As New List(Of DBConnect)
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            If Me.dgvPhysiotherapyDiagnosis.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for diagnosis!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvPhysiotherapyDiagnosis.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvPhysiotherapyDiagnosis.Rows(rowNo).Cells

                Try

                    Using oDiagnosis As New SyncSoft.SQLDb.PhysioDiagnosis
                        With oDiagnosis

                            .VisitNo = visitNo
                            .PhysioDiseaseNo = StringEnteredIn(cells, Me.colPhysioDiseaseDiagnosis)
                            .Notes = StringMayBeEnteredIn(cells, Me.colPhysioDiagnosisNotes)
                            .LoginID = CurrentUser.LoginID
                        End With

                        lDiagnosis.Add(oDiagnosis)
                        oDiagnosis.Save()

                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lDiagnosis, Action.Save))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Me.dgvPhysiotherapyDiagnosis.Item(Me.colDiagnosisSaved.Name, rowNo).Value = True


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dgvPhysiotherapyDiagnosis.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub
    

    Private Sub SaveTreatmentPlan()

        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim lTreatmentPlan As New List(Of DBConnect)
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            If Me.dgvTreatmentPlan.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for Treatment Plan!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvTreatmentPlan.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvTreatmentPlan.Rows(rowNo).Cells

                Try

                    Using oTreatmentPlan As New SyncSoft.SQLDb.TreatmentPlan()
                        With oTreatmentPlan

                            .VisitNo = visitNo
                            .CategoryID = StringEnteredIn(cells, Me.colCategory)
                            .TherapyTechniqueID = StringEnteredIn(cells, Me.colTherapyID)
                            .Notes = StringEnteredIn(cells, Me.colPhysiotherapyNotes)
                            .LoginID = CurrentUser.LoginID

                        End With

                        lTreatmentPlan.Add(oTreatmentPlan)
                        oTreatmentPlan.Save()

                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lTreatmentPlan, Action.Save))


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvTreatmentPlan.Item(Me.colPhysiotherapyTechniquesSaved.Name, rowNo).Value = True

                    DisplayMessage("Treatment Plan Successfully Saved!")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub
#End Region

    Private Sub cboOnMedication_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        If Me.cboOnMedication.SelectedIndex = 1 Then
            Me.stbMedication.Enabled = False
        Else
            Me.stbMedication.Enabled = True

        End If
    End Sub

    Private Sub ResetControls()
        ResetControlsIn(Me.tpgPhysiotherapyTreatment)
        physiotherapySaved = True

        ResetControlsIn(Me.tpgPhysiotherapyDiagnosis)
        DiagnosisSaved = True
    End Sub


    Private Sub cboOnMedication_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles cboOnMedication.SelectedIndexChanged
        If Me.cboOnMedication.SelectedIndex = 1 Then
            Me.stbMedication.Enabled = False
        Else
            Me.stbMedication.Enabled = True

        End If
    End Sub

    Private Sub btnLoadTemplate_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadTemplate.Click
        Dim oTemplateTypeID As New LookupDataID.TemplateTypeID()

        If ((Me.btnLoadTemplate.Location.X - stbMuscleStatus.Width = stbMuscleStatus.Location.X) AndAlso
            (Me.btnLoadTemplate.Location.Y = stbMuscleStatus.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.MuscleStatus, Me.stbMuscleStatus, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbStatusOfJoints.Width = stbStatusOfJoints.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbStatusOfJoints.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.StatusOfJoints, Me.stbStatusOfJoints, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbSensitivity.Width = stbSensitivity.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbSensitivity.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.Sensitivity, Me.stbSensitivity, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbWalkingAnalysis.Width = stbWalkingAnalysis.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbWalkingAnalysis.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.WalkingAnalysis, Me.stbWalkingAnalysis, True)
            fGetTemplates.ShowDialog(Me)

        End If
    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Me.ShowPatientDetails(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            'Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub



    Private Sub stbVisitNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbVisitNo.TextChanged

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not currentAllSaved AndAlso Not String.IsNullOrEmpty(currentVisitNo) Then
            'Me.stbVisitNo.Text = currentVisitNo
            Return
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Me.ClearControls()
        'Me.ResetControls()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub


    Private Sub btnFindVisitNo_Click(sender As System.Object, e As System.EventArgs) Handles btnFindVisitNo.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        Me.ShowPatientDetails(visitNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub


    Private Sub btnAddConsumables_Click(sender As System.Object, e As System.EventArgs) Handles btnAddConsumables.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit Number!"))
            Dim fConsumables As New frmConsumables(visitNo)
            fConsumables.ShowDialog()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub btnAddExtraCharge_Click(sender As System.Object, e As System.EventArgs) Handles btnAddExtraCharge.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit Number!"))
            Dim fExtraCharge As New frmExtraCharge(visitNo)
            fExtraCharge.ShowDialog()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
End Class