Option Strict On

Public Class frmCamera
    Private CamMgr As TouchlessLib.TouchlessMgr
    Private control As SyncSoft.Common.Win.Controls.SmartPictureBox

    Private Sub frmCamera_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            tmrcamera.Enabled = False
            CamMgr.CurrentCamera.Dispose()
            CamMgr.Cameras.Item(cmbCamera.SelectedIndex).Dispose()
            CamMgr.Dispose()
            Me.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub SetControl(control As SyncSoft.Common.Win.Controls.SmartPictureBox)
        Me.control = control
    End Sub

    Private Sub frmCamera_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.picFeed.DeletePhoto()
        Me.picPreview.DeletePhoto()

        CamMgr = New TouchlessLib.TouchlessMgr

        For i As Integer = 0 To CamMgr.Cameras.Count - 1
            cmbCamera.Items.Add(CamMgr.Cameras(i).ToString)
        Next

        If cmbCamera.Items.Count > 0 Then
            cmbCamera.SelectedIndex = 0
            tmrcamera.Enabled = True
        Else
            MsgBox("There are no Cameras attached on this Computer...", MsgBoxStyle.Exclamation, "ClinicMaster")
            Me.Close()
        End If

    End Sub

    Private Sub cmbCamera_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCamera.SelectedIndexChanged
        CamMgr.CurrentCamera = CamMgr.Cameras.ElementAt(cmbCamera.SelectedIndex)
    End Sub

    Private Sub tmrcamera_Tick(sender As System.Object, e As System.EventArgs) Handles tmrcamera.Tick
        Try
            picFeed.Image = CamMgr.CurrentCamera.GetCurrentImage()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnCapture_Click(sender As System.Object, e As System.EventArgs) Handles btnCapture.Click
        picPreview.Image = CamMgr.CurrentCamera.GetCurrentImage()

        btnSave.Enabled = True
       
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            Me.control.Image = CamMgr.CurrentCamera.GetCurrentImage()
            tmrcamera.Enabled = False
            CamMgr.CurrentCamera.Dispose()
            CamMgr.Cameras.Item(cmbCamera.SelectedIndex).Dispose()
            CamMgr.Dispose()
            Me.Dispose()
        Catch ex As Exception

        End Try

    End Sub

  
End Class
