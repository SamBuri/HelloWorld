Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmOpenVisitOptions

#Region " Fields "
    Private defaultVisitNo As String = String.Empty
#End Region

    Private Sub frmOpenVisitOptions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Security.Apply(Me.fbnAdmission, AccessRights.Write)
            Security.Apply(Me.fbnCashier, AccessRights.Write)
            Security.Apply(Me.fbnTriage, AccessRights.Write)
            Security.Apply(Me.fbnVisionAssessment, AccessRights.Write)
            Security.Apply(Me.fbnExtraCharge, AccessRights.Write)
            lblMessage.Text = " How would you like to Proceed?"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fbnTriage_Click(sender As System.Object, e As System.EventArgs) Handles fbnTriage.Click
        Dim fTriage As New frmTriage(defaultVisitNo, True)
        fTriage.Save()
        fTriage.ShowDialog()
        Me.Close()
    End Sub

    Private Sub fbnCashier_Click(sender As System.Object, e As System.EventArgs) Handles fbnCashier.Click
        Dim oVisitTypeID As New LookupDataID.VisitTypeID()
        Dim fCashier As New frmCashier(defaultVisitNo, oVisitTypeID.OutPatient)
        fCashier.ShowDialog()
        Me.Close()
    End Sub

    Private Sub fbnAdmission_Click(sender As System.Object, e As System.EventArgs) Handles fbnAdmission.Click
        Dim fAdmissions As New frmAdmissions(defaultVisitNo, Nothing)
        fAdmissions.Save()
        fAdmissions.ShowDialog()
        Me.Close()
    End Sub

    Private Sub fbnExtraCharge_Click(sender As System.Object, e As System.EventArgs) Handles fbnExtraCharge.Click
        Dim fExtraCharge As New frmExtraCharge(defaultVisitNo)
        fExtraCharge.ShowDialog()
        Me.Close()
    End Sub

    Private Sub fbnVisionAssessment_Click(sender As System.Object, e As System.EventArgs) Handles fbnVisionAssessment.Click
        Dim fVisionAssessment As New frmVisionAssessment(defaultVisitNo, True)
        fVisionAssessment.Save()
        fVisionAssessment.ShowDialog()
        Me.Close()
    End Sub

    Private Sub fbnCancel_Click(sender As System.Object, e As System.EventArgs) Handles fbnCancel.Click
        Me.Close()
    End Sub
End Class