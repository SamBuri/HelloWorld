
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Public Class frmFindAutoNo

#Region " Fields "
    Private autoNoControl As Control
    Private _AutoNumber As AutoNumber
#End Region

    Private Sub frmFindAutoNo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.dtpFindDate.MaxDate = Today
        If _AutoNumber = AutoNumber.VisitNo Then
            Me.Text = "Find Visit No"

        ElseIf _AutoNumber = AutoNumber.SpecimenNo Then
            Me.Text = "Find Specimen No"

        ElseIf _AutoNumber = AutoNumber.VisitNoCurrentlyOnART Then
            Me.Text = "Find Visit No Currently On ART"
            Me.dtpFindDate.Checked = False

        ElseIf _AutoNumber = AutoNumber.AdmissionNo Then
            Me.Text = "Find Admission No"
            Me.dtpFindDate.Checked = False
        ElseIf _AutoNumber = AutoNumber.VARoundNo Then
            Me.Text = "Find VA Round No"
            Me.lblFindNo.Text = "Admission No"
            Me.lblFindDate.Text = "Round Date"
            Me.dtpFindDate.Checked = False
        ElseIf _AutoNumber = AutoNumber.RoundNo Then
            Me.Text = "Find Round No"
            Me.lblFindNo.Text = "Admission No"
            Me.lblFindDate.Text = "Round Date Time"
            Me.lblMessage.Text = "Hint: Uncheck round date to get the latest"
            Me.dtpFindDate.Format = DateTimePickerFormat.Custom
            Me.dtpFindDate.CustomFormat = "dd MMM yyyy hh:mm tt"
            Me.dtpFindDate.MaxDate = Now.AddSeconds(30)
            Me.dtpFindDate.Value = Now
            Me.dtpFindDate.Checked = False

        ElseIf _AutoNumber = AutoNumber.ClaimNo Then
            Me.Text = "Find Claim No"
            Me.lblFindNo.Text = "Medical Card No"

        ElseIf _AutoNumber = AutoNumber.ExtraBillNo Then
            Me.Text = "Find Extra Bill No"
            Me.lblFindDate.Text = "Extra Bill Date"
            Me.lblMessage.Text = "Hint: Uncheck extra bill date to get the latest"

        ElseIf _AutoNumber = AutoNumber.OutwardNo Then
            Me.Text = "Find Outward No"
            Me.lblFindDate.Text = "Taken Date Time"
            Me.lblMessage.Text = "Hint: Uncheck taken date to get the latest"
            Me.dtpFindDate.Format = DateTimePickerFormat.Custom
            Me.dtpFindDate.CustomFormat = "dd MMM yyyy hh:mm tt"
            Me.dtpFindDate.MaxDate = Now.AddSeconds(30)
            Me.dtpFindDate.Value = Now
            Me.dtpFindDate.Checked = False

        ElseIf _AutoNumber = AutoNumber.RefundRequestNo Then
            Me.Text = "Find Refund Request No"
            Me.lblFindNo.Text = "Receipt No"
            Me.lblFindDate.Text = "Receipt Date Time"
            Me.lblMessage.Text = "Hint: Uncheck taken date to get the latest"
            Me.dtpFindDate.Format = DateTimePickerFormat.Custom
            Me.dtpFindDate.CustomFormat = "dd MMM yyyy hh:mm tt"
            Me.dtpFindDate.MaxDate = Now.AddSeconds(30)
            Me.dtpFindDate.Value = Now
            Me.dtpFindDate.Checked = False
        End If

    End Sub

    Private Sub frmFindAutoNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub frmFindAutoNo_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        FadeClosingForm(Me, 200)
    End Sub

    Private Sub fbnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnCancel.Click
        Me.Close()
    End Sub

    Private Sub fbnFindNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnFindNow.Click

        Dim autoNo As String

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oVisits As New SyncSoft.SQLDb.Visits()
            Dim oLabRequests As New SyncSoft.SQLDb.LabRequests()
            Dim oARTRegimen As New SyncSoft.SQLDb.ARTRegimen()
            Dim oAdmissions As New SyncSoft.SQLDb.Admissions()
            Dim oIPDVisionAssessment As New SyncSoft.SQLDb.IPDVisionAssessment()
            Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()
            Dim oClaims As New SyncSoft.SQLDb.Claims()
            Dim oExtraBills As New SyncSoft.SQLDb.ExtraBills()
            Dim oOutwardFiles As New SyncSoft.SQLDb.OutwardFiles()
            Dim oRefundRequests As New SyncSoft.SQLDb.RefundRequests()

            Dim findNo As String = RevertText(StringEnteredIn(Me.stbFindNo, Me.lblFindNo.Text + "!"))
            Dim findDate As Date = DateMayBeEnteredIn(Me.dtpFindDate)
            Dim findDateTime As Date = DateTimeMayBeEnteredIn(Me.dtpFindDate)

            If _AutoNumber = AutoNumber.VisitNo Then
                autoNo = FormatText(oVisits.GetVisitNo(findNo, findDate), "Visits", "VisitNo")

            ElseIf _AutoNumber = AutoNumber.SpecimenNo Then
                autoNo = FormatText(oLabRequests.GetSpecimenNo(findNo, findDate), "LabRequests", "SpecimenNo")

            ElseIf _AutoNumber = AutoNumber.AdmissionNo Then
                autoNo = FormatText(oAdmissions.GetAdmissionNo(findNo, findDate), "Admissions", "AdmissionNo")
            ElseIf _AutoNumber = AutoNumber.VARoundNo Then
                autoNo = FormatText(oIPDVisionAssessment.GetVARoundNo(findNo, findDate), "IPDVisionAssessment", "VARoundNo")

            ElseIf _AutoNumber = AutoNumber.VisitNoCurrentlyOnART Then
                autoNo = FormatText(oARTRegimen.GetVisitNoCurrentlyOnART(findNo, findDate), "Visits", "VisitNo")

            ElseIf _AutoNumber = AutoNumber.RoundNo Then
                autoNo = FormatText(oIPDDoctor.GetRoundNo(findNo, findDateTime), "IPDDoctor", "RoundNo")
            ElseIf _AutoNumber = AutoNumber.ClaimNo Then
                autoNo = FormatText(oClaims.GetClaimNo(findNo, findDate), "Claims", "ClaimNo")

            ElseIf _AutoNumber = AutoNumber.ExtraBillNo Then
                autoNo = FormatText(oExtraBills.GetExtraBillNo(findNo, findDate), "ExtraBills", "ExtraBillNo")

            ElseIf _AutoNumber = AutoNumber.OutwardNo Then
                autoNo = FormatText(oOutwardFiles.GetOutwardNo(findNo, findDateTime), "OutwardFiles", "OutwardNo")

            ElseIf _AutoNumber = AutoNumber.RefundRequestNo Then
                autoNo = FormatText(oRefundRequests.GetRefundRequestNo(findNo, findDateTime), "RefundRequests", "RefundRequestNo")
            Else : autoNo = String.Empty
            End If
            '
            If TypeOf Me.autoNoControl Is TextBox Then
                CType(Me.autoNoControl, TextBox).Text = autoNo
                CType(Me.autoNoControl, TextBox).Focus()

            ElseIf TypeOf Me.autoNoControl Is SmartTextBox Then
                CType(Me.autoNoControl, SmartTextBox).Text = autoNo
                CType(Me.autoNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.autoNoControl Is ComboBox Then
                CType(Me.autoNoControl, ComboBox).Text = autoNo
                CType(Me.autoNoControl, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class