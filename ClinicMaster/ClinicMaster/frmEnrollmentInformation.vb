
Option Strict On
Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Enumerations
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Collections.Generic

Public Class frmEnrollmentInformation

#Region " Fields "

    Private defaultKeyNo As String = String.Empty
    Private enrollmentKeyNo As ItemsKeyNo
    Private oCurrentEnrollmentInformation As CurrentEnrollmentInformation
#End Region

Private Sub frmEnrollmentInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
            Me.Cursor = Cursors.WaitCursor()
            Me.dtpEnrollmentDate.MaxDate = Today

            LoadLookupDataCombo(Me.cboEnrolledID, LookupObjects.YesNo, True)
            LoadLookupDataCombo(Me.cboCoEnrolledID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboCoEnrolledStudyCodeID, LookupObjects.ReferralStudyCode, False)
            LoadLookupDataCombo(Me.cboReferralStudyCodeID, LookupObjects.ReferralStudyCode, False)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oCurrentEnrollmentInformation IsNot Nothing AndAlso Not String.IsNullOrEmpty(oCurrentEnrollmentInformation.UCIID) Then

                Me.ShowresearchRoutingFormDetails(oCurrentEnrollmentInformation.UCIID)
                Me.ProcessTabKey(True)


                Me.cboReferralStudyCodeID.SelectedValue = oCurrentEnrollmentInformation.ReferralStudyCodeID
                Me.cboEnrolledID.Text = oCurrentEnrollmentInformation.EnrolledID
                Me.cboCoEnrolledID.SelectedValue = oCurrentEnrollmentInformation.CoEnrolledID
                Me.cboCoEnrolledStudyCodeID.SelectedValue = oCurrentEnrollmentInformation.CoEnrolledStudyCodeID
                Me.stbCCInitials.Text = oCurrentEnrollmentInformation.CCInitials
                Me.stbExclusionReason.Text = oCurrentEnrollmentInformation.ExclusionReason
                Me.dtpEnrollmentDate.Value = oCurrentEnrollmentInformation.EnrollmentDate
                Me.stbPatientReferred.Text = oCurrentEnrollmentInformation.PatientReferred
                Me.dtpReferredDate.Value = oCurrentEnrollmentInformation.ReferredDate
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.cboReferralStudyCodeID.Enabled = False
                Me.cboEnrolledID.Enabled = False
                Me.cboCoEnrolledID.Enabled = False
                Me.cboCoEnrolledStudyCodeID.Enabled = False
                Me.stbCCInitials.Enabled = False
                Me.stbExclusionReason.Enabled = False
                Me.dtpEnrollmentDate.Enabled = False
                Me.stbPatientReferred.Enabled = False
                Me.dtpReferredDate.Enabled = False

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf Not String.IsNullOrEmpty(defaultKeyNo) AndAlso enrollmentKeyNo = ItemsKeyNo.UCIID Then

                Me.ShowresearchRoutingFormDetails(defaultKeyNo)
                Me.stbUCIID.ReadOnly = True
                Security.Apply(Me.ebnSaveUpdate, AccessRights.Write)
            Else : Me.stbUCIID.ReadOnly = False
            End If

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub frmEnrollmentInformation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub
    Private Sub ClearControls()

    End Sub


    Private Sub ShowresearchRoutingFormDetails(ByVal uCIID As String)

        Dim oResearchRoutingForm As New SyncSoft.SQLDb.ResearchRoutingForm()
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            Dim researchRoutingForm As DataTable = oResearchRoutingForm.GetResearchRoutingForm(uCIID).Tables("ResearchRoutingForm")
            Dim row As DataRow = researchRoutingForm.Rows(0)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbUCIID.Text = FormatText(uCIID, "ResearchRoutingForm", "UCIID")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbFullName.Text = StringMayBeEnteredIn(row, "FullName")
            Me.stbReferalInitials.Text = StringMayBeEnteredIn(row, "ReferalInitials")
            Me.stbGender.Text = StringMayBeEnteredIn(row, "Sex")
            Me.stbAge.Text = StringMayBeEnteredIn(row, "Age")
            Me.stbSCRNo.Text = StringMayBeEnteredIn(row, "SCRNo")
            Me.stbPID.Text = StringMayBeEnteredIn(row, "PID")
            Me.stbSID.Text = StringMayBeEnteredIn(row, "SID")


        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub

Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

Dim oEnrollmentInformation As New SyncSoft.SQLDb.EnrollmentInformation()

	Try
		Me.Cursor = Cursors.WaitCursor()

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oEnrollmentInformation.UCIID = RevertText(StringEnteredIn(Me.stbUCIID, "UCIID!"))
            oEnrollmentInformation.ReferralStudyCodeID = StringValueEnteredIn(Me.cboReferralStudyCodeID, "Referral Study Code!")

		DisplayMessage(oEnrollmentInformation.Delete())
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

Dim uCIID As String
Dim referralStudyCodeID As String

Dim oEnrollmentInformation As New SyncSoft.SQLDb.EnrollmentInformation()

	Try
		Me.Cursor = Cursors.WaitCursor()

            uCIID = RevertText(StringEnteredIn(Me.stbUCIID, "Research No!"))
            referralStudyCodeID = StringValueEnteredIn(Me.cboReferralStudyCodeID, "Referral Study Code!")

		Dim dataSource As DataTable = oEnrollmentInformation.GetEnrollmentInformation(uCIID, referralStudyCodeID).Tables("EnrollmentInformation")
		Me.DisplayData(dataSource)

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oEnrollmentInformation As New SyncSoft.SQLDb.EnrollmentInformation()
        Dim oResearchRoutingForm As New SyncSoft.SQLDb.ResearchRoutingForm()
        Dim message As String
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim records As Integer
      
	Try
            Me.Cursor = Cursors.WaitCursor()
            Dim lEnrollmentInformation As New List(Of DBConnect)
            Dim researchNo As String = RevertText(StringEnteredIn(Me.stbUCIID, "Research No!"))
            With oEnrollmentInformation


                .UCIID = researchNo
                .ReferralStudyCodeID = StringValueEnteredIn(Me.cboReferralStudyCodeID, "Referral Study Code!")
                .EnrolledID = StringValueEnteredIn(Me.cboEnrolledID, "Enrolled!")
                .CoEnrolledID = StringValueEnteredIn(Me.cboCoEnrolledID, "Co Enrolled!")
                .CoEnrolledStudyCodeID = StringValueEnteredIn(Me.cboCoEnrolledStudyCodeID, "CoEnrolled Study Code!")
                .CCInitials = StringEnteredIn(Me.stbCCInitials, "CC Initials!")
                .ExclusionReason = StringEnteredIn(Me.stbExclusionReason, "Exclusion Reason!")
                .EnrollmentDate = DateEnteredIn(Me.dtpEnrollmentDate, "Date!")
                .PatientReferred = StringEnteredIn(Me.stbPatientReferred, "Where was the patient referred if not enrolled?!")
                .ReferredDate = DateEnteredIn(Me.dtpReferredDate, "Referred Date!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

		Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    lEnrollmentInformation.Add(oEnrollmentInformation)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lEnrollmentInformation, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)

                   
                    message = "Research No : " + FormatText(researchNo, "ResearchRoutingForm", "UCIID") +
                              ", was successfully attached to the Referral Study " + oEnrollmentInformation.ReferralStudyCodeID + "!"

                    DisplayMessage(message)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim ResearchRoutingForm As DataTable = oResearchRoutingForm.GetResearchRoutingForm(researchNo).Tables("ResearchRoutingForm")
                    If ResearchRoutingForm.Rows.Count < 1 Then Return
                    Dim row As DataRow = ResearchRoutingForm.Rows(0)
                    Dim patientNo As String = StringMayBeEnteredIn(row, "PatientNo")
                    If String.IsNullOrEmpty(patientNo) Then
                        message = "Would you like this Client with Research No : " + oEnrollmentInformation.UCIID + " to be enrolled as a Patient?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then
                            Dim fPatients As New frmPatients(oEnrollmentInformation.UCIID, ItemsKeyNo.UCIID)
                            fPatients.Save()
                            fPatients.ShowDialog()
                        End If
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oEnrollmentInformation.Update())
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

    Private Sub stbUCIID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbUCIID.Leave
        Try

            Dim uCIID As String = RevertText(StringMayBeEnteredIn(Me.stbUCIID))
            If String.IsNullOrEmpty(uCIID) Then Return
            Me.ShowresearchRoutingFormDetails(uCIID)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub stbUCIID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbUCIID.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub cboEnrolledID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEnrolledID.SelectedIndexChanged
        'Dim oYesNoID As New LookupDataID.YesNoID()
        'If Me.cboEnrolledID.SelectedValue Is Nothing OrElse String.IsNullOrEmpty(Me.cboEnrolledID.SelectedValue.ToString()) Then Return
        'Dim _YesNoID As String = Me.cboEnrolledID.SelectedValue.ToString()
        'If Not _YesNoID.ToUpper().Equals(oYesNoID.No.ToUpper()) Then
        '    Me.stbExclusionReason.Enabled = False
        '    Me.stbPatientReferred.Enabled = False
        '    Me.dtpReferredDate.Enabled = False
        'Else : Me.stbExclusionReason.Enabled = True
        '    Me.stbPatientReferred.Enabled = True
        '    Me.dtpReferredDate.Enabled = True

        'End If
    End Sub

    Private Sub btnLoadSeeDrVisits_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim fperiodicResearchRoutingForm As New frmPeriodicResearchRoutingForm(Me.stbUCIID)
            fperiodicResearchRoutingForm.ShowDialog(Me)

            Dim uCIID As String = RevertText(StringMayBeEnteredIn(Me.stbUCIID))
            If String.IsNullOrEmpty(uCIID) Then Return
            Me.ShowresearchRoutingFormDetails(uCIID)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
End Class