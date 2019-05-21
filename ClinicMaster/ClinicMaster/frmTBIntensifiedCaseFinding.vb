
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmTBIntensifiedCaseFinding

#Region " Fields "
    Private defaultVisitNo As String = String.Empty
#End Region

    Private Sub frmTBIntensifiedCaseFinding_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboCoughingTwoWeeksMoreID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboPersistantFeversID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboNoticableWeightLossID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboExcessiveNightSweatsID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboPoorWeightGainID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboPulmonaryTBChronicCoughContactID, LookupObjects.YesNo, False)

            If Not String.IsNullOrEmpty(defaultVisitNo) Then
                Me.stbVisitNo.Text = FormatText(defaultVisitNo, "Visits", "VisitNo")

                Me.ShowPatientDetails(RevertText(defaultVisitNo))

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits

        Try

            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)

            ' Me.ClearControls()

            Me.stbPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")
            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
        

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub frmTBIntensifiedCaseFinding_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oTBIntensifiedCaseFinding As New SyncSoft.SQLDb.TBIntensifiedCaseFinding()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oTBIntensifiedCaseFinding.VisitNo = StringEnteredIn(Me.stbVisitNo, "VisitNo!")

            DisplayMessage(oTBIntensifiedCaseFinding.Delete())
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

        Dim oTBIntensifiedCaseFinding As New SyncSoft.SQLDb.TBIntensifiedCaseFinding()

        Try
            Me.Cursor = Cursors.WaitCursor()

            visitNo = StringEnteredIn(Me.stbVisitNo, "VisitNo!")

            Dim dataSource As DataTable = oTBIntensifiedCaseFinding.GetTBIntensifiedCaseFinding(visitNo).Tables("TBIntensifiedCaseFinding")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oTBIntensifiedCaseFinding As New SyncSoft.SQLDb.TBIntensifiedCaseFinding()
        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oYesNoID As New LookupDataID.YesNoID
        Dim oPriorityID As New LookupDataID.PriorityID


        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim coughingTwoWeeksMoreID As String = StringValueEnteredIn(Me.cboCoughingTwoWeeksMoreID, "Coughing Two Weeks More!")
            Dim persistantFeversID As String = StringValueEnteredIn(Me.cboPersistantFeversID, "Persistant Fevers!")
            Dim noticableWeightLossID As String = StringValueEnteredIn(Me.cboNoticableWeightLossID, "Noticable Weight Loss!")
            Dim excessiveNightSweatsID As String = StringValueEnteredIn(Me.cboExcessiveNightSweatsID, "Excessive Night Sweats!")
            Dim oorWeightGainID As String = StringValueEnteredIn(Me.cboPoorWeightGainID, "Poor Weight Gain!")
            Dim pulmonaryTBChronicCoughContactID As String = StringValueEnteredIn(Me.cboPulmonaryTBChronicCoughContactID, "Pulmonary TB Chronic Cough Contact!")

            Dim stringList As New ArrayList()

            With oTBIntensifiedCaseFinding

                .VisitNo = visitNo
                .CoughingTwoWeeksMoreID = coughingTwoWeeksMoreID
                .PersistantFeversID = noticableWeightLossID
                .NoticableWeightLossID = noticableWeightLossID
                .ExcessiveNightSweatsID = excessiveNightSweatsID
                .PoorWeightGainID = oorWeightGainID
                .PulmonaryTBChronicCoughContactID = pulmonaryTBChronicCoughContactID
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            'stringList.Add(coughingTwoWeeksMoreID)
            'stringList.Add(noticableWeightLossID)
            'stringList.Add(noticableWeightLossID)
            'stringList.Add(oorWeightGainID)
            'stringList.Add(oorWeightGainID)
            'stringList.Add(pulmonaryTBChronicCoughContactID)

            'Dim counted As Integer = 0
            'For counter As Integer = 0 To stringList.Count() - 1
            '    If stringList.Item(counter).ToString().ToUpper.Equals((oYesNoID.Yes.ToUpper())) Then
            '        counted += 1
            '    End If
            'Next

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oTBIntensifiedCaseFinding.Save()

                    'If counted >= 3 Then

                    '    With oVisits
                    '        .VisitNo = visitNo
                    '        .VisitsPriorityID = oPriorityID.Emergency

                    '        oVisits.Update()

                    '    End With
                    'End If


                    'If oTBIntensifiedCaseFinding.CoughingTwoWeeksMoreID.Equals(oYesNoID.Yes.ToUpper()) Or
                    '    oTBIntensifiedCaseFinding.PersistantFeversID.Equals(oYesNoID.Yes.ToUpper()) Then

                    'End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ResetControlsIn(Me.gbTbIntensifiedCaseFinding)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oTBIntensifiedCaseFinding.Update())
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