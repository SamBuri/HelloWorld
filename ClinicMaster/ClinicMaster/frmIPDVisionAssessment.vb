
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmIPDVisionAssessment

#Region " Fields "
    Private defaultadmissionNo As String = String.Empty
    Private defaultEyeTestID As String = String.Empty
    Private defaulteyeID As String = String.Empty
    Private noCallOnKeyEdit As Boolean = False
#End Region

    Private Property cboClinicalCommentID As Object

    Private Sub frmIPDVisionAssessment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()
            LoadLookupDataCombo(Me.cboEyeTestID, LookupObjects.EyeTest, False)
            LoadLookupDataCombo(Me.cboVisualAcuityRightID, LookupObjects.VisualAcuity, False)
            LoadLookupDataCombo(Me.cboVisualAcuityRightExtID, LookupObjects.VisualAcuityExt, False)
            LoadLookupDataCombo(Me.cboVisualAcuityLeftID, LookupObjects.VisualAcuity, False)
            LoadLookupDataCombo(Me.cboVisualAcuityLeftExtID, LookupObjects.VisualAcuityExt, False)
            LoadLookupDataCombo(Me.cboPreferentialLookingRightID, LookupObjects.PreferentialLooking, True)
            LoadLookupDataCombo(Me.cboPreferentialLookingLeftID, LookupObjects.PreferentialLooking, True)

            If Not String.IsNullOrEmpty(defaultadmissionNo) Then
                Me.stbAdmissionNo.Text = FormatText(defaultadmissionNo, "Admissions", "AdmissionNo")
                Me.stbAdmissionNo.ReadOnly = True
                Me.btnFindRoundNo.Enabled = False
                Me.stbRoundNo.ReadOnly = True
                Me.ProcessTabKey(True)
            Else
                Me.stbRoundNo.ReadOnly = True
                Me.btnFindRoundNo.Enabled = True

            End If

            If Not String.IsNullOrEmpty(defaultadmissionNo) Then
                Me.stbAdmissionNo.Text = defaultadmissionNo.ToUpper()
                Me.stbAdmissionNo.ReadOnly = True
                If Not String.IsNullOrEmpty(defaultEyeTestID) Then
                    Me.cboEyeTestID.SelectedValue = defaultEyeTestID
                    Me.cboEyeTestID.Enabled = False
                    Me.Search(defaultadmissionNo, defaultEyeTestID)

                End If
                Me.ShowPatientDetails(defaultadmissionNo)
                Me.ProcessTabKey(True)
            Else
                Me.stbRoundNo.ReadOnly = True
                Me.cboEyeTestID.Enabled = True
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmIPDVisionAssessment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub ClearControls()

        Me.stbVisitDate.Clear()
        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()
        Me.stbGender.Clear()
        Me.stbVisitNo.Clear()
        Me.stbJoinDate.Clear()
        Me.stbAge.Clear()
        Me.stbAdmissionStatus.Clear()
        Me.stbAdmissionDateTime.Clear()
        Me.stbTotalIPDDoctorRounds.Clear()
        Me.spbPhoto.Image = Nothing
    End Sub

    Private Sub ShowPatientDetails(ByVal admissionNo As String)

        Dim oAdmissions As New SyncSoft.SQLDb.Admissions
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()
            If String.IsNullOrEmpty(admissionNo) Then Return
            Dim admissions As DataTable = oAdmissions.GetAdmissions(admissionNo).Tables("Admissions")
            Dim row As DataRow = admissions.Rows(0)
            Dim patientNo As String = StringEnteredIn(row, "PatientNo")
            Dim visitNo As String = StringEnteredIn(row, "VisitNo")
            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Me.stbAdmissionDateTime.Text = FormatDateTime(DateTimeEnteredIn(row, "AdmissionDateTime"))
            Me.stbAdmissionNo.Text = FormatText(admissionNo, "Admissions", "AdmissionNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbAdmissionStatus.Text = StringEnteredIn(row, "AdmissionStatus")
            Me.stbTotalIPDDoctorRounds.Text = StringEnteredIn(row, "TotalIPDDoctorRounds")
            Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")

            Me.SetNextVARoundNo(admissionNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetNextVARoundNo(ByVal admissionNo As String)

        Try

            Dim oVARoundNo As New SyncSoft.SQLDb.IPDVisionAssessment
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("IPDVisionAssessment", "VARoundNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim VARoundID As String = oVARoundNo.GetNextVARoundID(admissionNo).ToString()
            VARoundID = VARoundID.PadLeft(paddingLEN, paddingCHAR)

            Me.stbRoundNo.Text = FormatText(admissionNo + VARoundID.Trim(), "IPDVisionAssessment", "VARoundNo")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return
        End Try

    End Sub

    Private Sub ShowIPDVisionAssessment(ByVal vARoundNo As String)

        Dim oIPDVisionAssessment As New SyncSoft.SQLDb.IPDVisionAssessment
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()
            If String.IsNullOrEmpty(vARoundNo) Then Return
            Dim iPDVisionAssessment As DataTable = oIPDVisionAssessment.GetIPDVisionAssessment(vARoundNo).Tables("IPDVisionAssessment")
            Dim row As DataRow = iPDVisionAssessment.Rows(0)
            Dim patientNo As String = StringEnteredIn(row, "PatientNo")
            Dim visitNo As String = StringEnteredIn(row, "VisitNo")
            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Me.stbAdmissionDateTime.Text = FormatDateTime(DateTimeEnteredIn(row, "AdmissionDateTime"))
            Me.stbAdmissionNo.Text = FormatText(vARoundNo, "Admissions", "AdmissionNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbAdmissionStatus.Text = StringEnteredIn(row, "AdmissionStatus")
            Me.stbTotalIPDDoctorRounds.Text = StringEnteredIn(row, "TotalIPDDoctorRounds")
            Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oIPDVisionAssessment As New SyncSoft.SQLDb.IPDVisionAssessment()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oIPDVisionAssessment.VARoundNo = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))
            oIPDVisionAssessment.EyeTestID = StringValueEnteredIn(Me.cboEyeTestID, "Eye Test!")

            DisplayMessage(oIPDVisionAssessment.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub LoadSelectedDefaults()

        Try


            Dim oPreferentialLookingID As New LookupDataID.PreferentialLookingID()


            Me.cboPreferentialLookingRightID.SelectedValue = oPreferentialLookingID.NA
            Me.cboPreferentialLookingLeftID.SelectedValue = oPreferentialLookingID.NA


        Catch ex As Exception
            Return

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click
        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))
            Dim eyeTestID As String = StringValueEnteredIn(Me.cboEyeTestID, "Eye Test!")
            Me.Search(roundNo, eyeTestID)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub Search(ByVal vARoundNo As String, ByVal eyeTestID As String)

        Dim oIPDVisionAssessment As New SyncSoft.SQLDb.IPDVisionAssessment()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim dataSource As DataTable = oIPDVisionAssessment.GetIPDVisionAssessment(vARoundNo, eyeTestID).Tables("IPDVisionAssessment")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oIPDVisionAssessment As New SyncSoft.SQLDb.IPDVisionAssessment()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oIPDVisionAssessment
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .AdmissionNo = RevertText(StringEnteredIn(Me.stbAdmissionNo, "Admission No!"))
                .VARoundNo = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))
                .RoundDateTime = DateTimeEnteredIn(Me.dtpRoundDateTime, "Round Date Time!")
                .EyeTestID = StringValueEnteredIn(Me.cboEyeTestID, "Eye Test!")
                .VisualAcuityRightID = StringValueEnteredIn(Me.cboVisualAcuityRightID, "Visual Acuity Right!")
                .VisualAcuityRightExtID = StringValueEnteredIn(Me.cboVisualAcuityRightExtID, "Visual Acuity Right Ext!")
                .VisualAcuityLeftID = StringValueEnteredIn(Me.cboVisualAcuityLeftID, "VisualAcuity Left!")
                .VisualAcuityLeftExtID = StringValueEnteredIn(Me.cboVisualAcuityLeftExtID, "Visual Acuity Left Ext!")
                .PreferentialLookingRightID = StringValueEnteredIn(Me.cboPreferentialLookingRightID, "Preferential Looking Right!")
                .PreferentialLookingLeftID = StringValueEnteredIn(Me.cboPreferentialLookingLeftID, "Preferential Looking Left!")
                .Notes = StringMayBeEnteredIn(Me.stbNotes)
                .LoginID = CurrentUser.LoginID
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oIPDVisionAssessment.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oIPDVisionAssessment.Update())
                    ResetControlsIn(Me)
                    Me.LoadSelectedDefaults()
                    Me.CallOnKeyEdit()

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub btnFindAdmissionNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindAdmissionNo.Click
        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()
        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fFindAdmissionNo As New frmFindAutoNo(Me.stbAdmissionNo, AutoNumber.AdmissionNo)
            fFindAdmissionNo.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
            ' Dim roundNo As String = oIPDDoctor.GetRoundNo(admissionNo, Nothing)
            Me.ShowPatientDetails(admissionNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return

        End Try
    End Sub

    Private Sub btnFindRoundNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindRoundNo.Click


        Dim oIPDVisionAssessment As New SyncSoft.SQLDb.IPDVisionAssessment
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindRoundNo As New frmFindAutoNo(Me.stbRoundNo, AutoNumber.VARoundNo)
        fFindRoundNo.ShowDialog(Me)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
        If String.IsNullOrEmpty(admissionNo) Then Return

        Me.ShowPatientDetails(admissionNo)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True
        Me.btnFindAdmissionNo.Visible = False
        ResetControlsIn(Me)
        Me.LoadSelectedDefaults()

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False
        Me.btnFindRoundNo.Visible = False
        ResetControlsIn(Me)
        Me.LoadSelectedDefaults()
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