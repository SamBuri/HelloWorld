
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmAntenatal

#Region " Fields "

#End Region

Private Sub frmAntenatal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()
            LoadLookupDataCombo(Me.cboInfection, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboSmoking, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboAccidentDuringPregnancy, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboUseOfDrugsOrPrescription, LookupObjects.YesNoUnknown, False)
            'LoadLookupDataCombo(Me.cboAbortions, LookupObjects.YesNo, False)
            'LoadLookupDataCombo(Me.cboCaesarian, LookupObjects.YesNo, False)
            'LoadLookupDataCombo(Me.cboStillBirth, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboChronicIllness, LookupObjects.YesNo, False)


	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub frmAntenatal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oAntenatal As New SyncSoft.SQLDb.Antenatal()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return



            DisplayMessage(oAntenatal.Delete())
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

        'Dim PatientNo As String

        'Dim oAntenatal As New SyncSoft.SQLDb.Antenatal()

        'Try
        '    Me.Cursor = Cursors.WaitCursor()



        '    Dim dataSource As DataTable = oAntenatal.GetAntenatal(patientNo).Tables("Antenatal")
        '    Me.DisplayData(dataSource)

        'Catch ex As Exception
        '    ErrorMessage(ex)

        'Finally
        '    Me.Cursor = Cursors.Default()

        'End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oAntenatal As New SyncSoft.SQLDb.Antenatal()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oAntenatal

                .VisitNo = StringEnteredIn(Me.stbVisitNo, "Visit No!")
                .Infection = StringValueMayBeEnteredIn(Me.cboInfection, "Infection!")
                .InfectionDetails = StringMayBeEnteredIn(Me.stbInfectionDetails)
                .AccidentDuringPregnancy = StringValueEnteredIn(Me.cboAccidentDuringPregnancy, "Accident During Pregnancy!")
                .DetailsOfAccident = StringMayBeEnteredIn(Me.stbDetailsOfAccident)
                .UseOfDrugsOrPrescription = StringValueEnteredIn(Me.cboUseOfDrugsOrPrescription, "Use Of Drugs Or Prescription!")
                .DrugDetails = StringMayBeEnteredIn(Me.stbDrugDetails)
                .Smoking = StringValueMayBeEnteredIn(Me.cboSmoking, "Smoking!")
                .ChronicIllness = StringValueMayBeEnteredIn(Me.cboChronicIllness, "Chronic Illness!")
                .DetailsOfIllness = StringMayBeEnteredIn(Me.stbDetailsOfIllness)
                .LoginID = CurrentUser.LoginID


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oAntenatal.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oAntenatal.Update())
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

    Private Sub btnLoadPatients_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadPatients.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Patients", Me.stbVisitNo)
            fQuickSearch.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            'If Not String.IsNullOrEmpty(patientNo) Then Me.ShowPatientDetails(patientNo)
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Me.stbPatientNo_Leave(Me, System.EventArgs.Empty)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
End Class