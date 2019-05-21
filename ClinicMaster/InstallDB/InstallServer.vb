
Option Strict On

Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Configuration.Install

Public Class InstallServer

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add initialization code after the call to InitializeComponent

    End Sub

    Private Sub InstallServer_AfterInstall(ByVal sender As Object, ByVal e As InstallEventArgs) Handles Me.AfterInstall
        Dim fInstallDB As New Common.Install.Forms.frmInstallDB()
        SetServerParameters()
        fInstallDB.ShowDialog()
        fInstallDB.BringToFront()
    End Sub

    Private Sub InstallServer_AfterUninstall(ByVal sender As Object, ByVal e As InstallEventArgs) Handles Me.AfterUninstall
        Dim fUninstallDB As New Common.Install.Forms.frmUninstallDB()
        fUninstallDB.ShowDialog()
    End Sub

    Public Overrides Sub Install(ByVal savedState As IDictionary)
        MyBase.Install(savedState)
    End Sub

    Public Overrides Sub Commit(ByVal savedState As IDictionary)
        MyBase.Commit(savedState)
    End Sub

    Public Overrides Sub Rollback(ByVal savedState As IDictionary)
        MyBase.Rollback(savedState)
    End Sub

End Class
