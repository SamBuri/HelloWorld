Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmOpenOptions

#Region " Fields "
    Private defaultPatientNo As String = String.Empty
#End Region


    Private Sub fbnVisits_Click(sender As System.Object, e As System.EventArgs) Handles fbnVisits.Click
        Dim fVisits As New frmVisits(defaultPatientNo, ItemsKeyNo.PatientNo)
        fVisits.Save()
        fVisits.ShowDialog()
        Me.Close()
    End Sub

    Private Sub fbnSelfRequests_Click(sender As System.Object, e As System.EventArgs) Handles fbnSelfRequests.Click
        Dim fSelfRequest As New frmSelfRequests(True, defaultPatientNo)
        fSelfRequest.Save()
        fSelfRequest.ShowDialog()
        Me.Close()
    End Sub

   
    Private Sub fbnAppointment_Click(sender As System.Object, e As System.EventArgs) Handles fbnAppointment.Click
        Dim fAppointMents As New frmAppointments(defaultPatientNo)
        fAppointMents.Save()
        fAppointMents.ShowDialog()
        Me.Close()
    End Sub

    Private Sub fbnArt_Click(sender As System.Object, e As System.EventArgs) Handles fbnArt.Click
        Dim fHIVCARE As New frmHIVCARE(defaultPatientNo, ItemsKeyNo.PatientNo)
        fHIVCARE.Save()
        fHIVCARE.ShowDialog()

        Me.Close()
    End Sub

    Private Sub fbnCancel_Click(sender As System.Object, e As System.EventArgs) Handles fbnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmOpenOptions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try

            Security.Apply(Me.fbnVisits, AccessRights.Write)
            Security.Apply(Me.fbnSelfRequests, AccessRights.Write)
            Security.Apply(Me.fbnAppointment, AccessRights.Write)
            Security.Apply(Me.fbnManageAccount, AccessRights.Write)
            Security.Apply(Me.fbnArt, AccessRights.Write)
            Dim oPatients As New SyncSoft.SQLDb.Patients()
            oPatients.GetPatient(defaultPatientNo)
            lblMessage.Text = " How would you like " + oPatients.FullName + " to Proceed?"
        Catch ex As Exception

        End Try


    End Sub

    Private Sub fbnManageAccount_Click(sender As System.Object, e As System.EventArgs) Handles fbnManageAccount.Click
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim fManageAccount As New frmManageAccounts(oBillModesID.Cash, defaultPatientNo)
        fManageAccount.ShowDialog()

        Me.Close()
    End Sub
End Class