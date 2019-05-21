
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Security.SQL
Imports SyncSoft.SQL.Win.Forms
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Win.Forms
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Imports System.IO
Imports SyncSoft.SQLDb
Imports SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmMain

#Region " Fields "

    Private proHelp As New System.Diagnostics.Process()
    Private proCalculator As New System.Diagnostics.Process()
    Private fLogin As New SyncSoft.SQL.Win.Forms.Login()
    Private oItemCategoryID As New LookupDataID.ItemCategoryID()
    Private oVariousOptions As New VariousOptions()
#End Region

#Region " Closed Code "

    Private Sub mdiClient_Paint(ByVal sender As Object, ByVal pevent As System.Windows.Forms.PaintEventArgs) Handles mdiClient.Paint

        ' Getting the graphics object
        Dim g As Graphics = pevent.Graphics

        ' Creating the rectangle for the gradient
        Dim rBackground As New Rectangle(0, 0, Me.Width, Me.Height)

        ' Creating the lineargradient
        Dim bBackground As New System.Drawing.Drawing2D.LinearGradientBrush(rBackground, GradientColorOne, GradientColorTwo, GradientColorAngle)

        ' Draw the gradient onto the form
        g.FillRectangle(bBackground, rBackground)

        ' Disposing of the resources held by the brush
        bBackground.Dispose()

    End Sub

    Private Sub SetStyles()
        ' Makes sure the form repaints when it was resized
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
    End Sub

    Private Sub mnuWindowCascade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWindowCascade.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub mnuWindowTileHorizontal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWindowTileHorizontal.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub mnuWindowTileVertical_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWindowTileVertical.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub mnuWindowArrangeIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWindowArrangeIcons.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub mnuWindowCloseAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWindowCloseAll.Click
        Do Until IsNothing(Me.ActiveMdiChild)
            Me.ActiveMdiChild.Close()
        Loop
    End Sub

    Private Sub mnuWindow_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuWindow.MouseEnter
        Dim blnMDIChild As Boolean = Me.ActiveMdiChild IsNot Nothing
        ManageMenuItemsIn(Me.mnuWindow, blnMDIChild)
    End Sub



    Private Sub mnuFileClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileClose.Click
        If Me.ActiveMdiChild Is Nothing Then Return
        Me.ActiveMdiChild.Close()
    End Sub

    Private Sub mnuViewToolBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewToolBar.Click
        Dim blnViewToolBar As Boolean = Not Me.mnuViewToolBar.Checked
        Me.mnuViewToolBar.Checked = blnViewToolBar
        Me.tlbMain.Visible = blnViewToolBar
    End Sub

    Private Sub mnuViewStatusBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewStatusBar.Click
        Dim blnViewStatusBar As Boolean = Not mnuViewStatusBar.Checked
        Me.mnuViewStatusBar.Checked = blnViewStatusBar
        Me.stbMain.Visible = blnViewStatusBar
    End Sub

    Private Sub mnuHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelpAbout.Click
        Dim fAbout As New SyncSoft.Common.Win.Forms.About()
        fAbout.ShowDialog(Me)
    End Sub

    Private Sub mnuHelpHelpTopics_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelpHelpTopics.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            LoadProcess(proHelp, AppData.HelpName)

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub mnuToolsCalculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsCalculator.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            LoadProcess(proCalculator, "Calc.exe", AppData.AppTitle + "-Calculator")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub mnuToolsErrorLogView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsErrorLogView.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            If File.Exists(LogFile) Then
                Process.Start(LogFile)
            Else : DisplayMessage("No Error Message Logged!")
            End If

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub mnuToolsErrorLogClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsErrorLogClear.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim clearMessage As String = "Are you sure you want to clear the log file. "

            If File.Exists(LogFile) Then
                If MessageBox.Show(clearMessage, AppData.AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                File.Delete(LogFile)
            End If

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub mnuViewData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewSearch.Click
        LoadChildForm(Me, New SyncSoft.SQL.Win.Forms.Search())
    End Sub

    Private Sub mnuToolsOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsOptions.Click
        Security.Apply(Me.mnuToolsOptions, AccessRights.Write)
        Dim fOptions As New frmOptions()
        fOptions.ShowDialog(Me)
    End Sub

    Private Sub mnuSetupSecurityLicenses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupSecurityLicenses.Click
        Dim fLicenses As New SyncSoft.SQL.Win.Forms.Licenses()
        fLicenses.ShowDialog(Me)
    End Sub

#End Region

#Region " Other Common Code "

    Private Sub SetStatusbarReadyText(ByVal statusbarText As String)

        If String.IsNullOrEmpty(statusbarText) Then
            Me.sbpReady.Text = "Ready..."
        Else : Me.sbpReady.Text = statusbarText
        End If

    End Sub

    Private Sub frmMain_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        Me.ShowUnreadMessageAlerts()
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim oActiveUsers As New SyncSoft.Security.SQL.ActiveUsers()
        oActiveUsers.Logoff()
        Application.Exit()
    End Sub

    Private Sub frmMain_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MdiChildActivate
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oActiveUsers As New SyncSoft.Security.SQL.ActiveUsers()
        oActiveUsers.Activate()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Me.ActiveMdiChild IsNot Nothing Then
            Me.SetStatusbarReadyText(Me.ActiveMdiChild.Text)
        Else : Me.SetStatusbarReadyText(String.Empty)
        End If
    End Sub

    Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        Dim oActiveUsers As New SyncSoft.Security.SQL.ActiveUsers()
        oActiveUsers.Logoff()
        Application.Exit()
    End Sub

    Private Sub mnuFileSwitchUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileSwitchUser.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.EnableMainCTLS(False)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Me.mnuWindowCloseAll_Click(Me, Nothing)

        With fLogin
            .lblUserName.Enabled = True
            .stbUserName.ReadOnly = False
            .lblServerName.Enabled = False
            .cboServerName.Enabled = False
            .btnCancel.Text = "Close"
            .pnlMore.Enabled = False
            .ShowDialog(Me)
            If .CancelLogin = True Then Me.mnuFileExit_Click(Me, Nothing)
        End With

        Me.SwitchUser()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.EnableMainCTLS(True)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub SwitchUser()

        With CurrentUser
            Me.sbpLogin.Text = "User Name: " + .FullName
            Me.sbpLevel.Text = "Level: " + .LoginLevel.ToString()
        End With

        With AppData
            Me.sbpServerName.Text = "Server: " + .ServerName
            Me.sbpConnectionMode.Text = "Connection Mode: " + .ConnectionMode
            Me.sbpUserID.Text = "Login Name: " + .UserID
            Me.sbpPoweredBy.Text = "Powered By: " + .Company + " (" + .Website + ")"
        End With

        Me.mnuFileSwitchUser.Text = "S&witch Login - " + CurrentUser.LoginID

        Security.Apply(Me.tlbMain, AccessRights.All)

        ' Load startup window
        Me.StartUpWindow()

    End Sub

    Private Sub mnuFile_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFile.MouseEnter
        Me.mnuFileClose.Enabled = Me.ActiveMdiChild IsNot Nothing
        Security.Apply(Me.mnuFile, AccessRights.Write)
    End Sub

    Private Sub mnuSetupNew_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSetupNew.MouseEnter
        Security.Apply(Me.mnuSetupNew, AccessRights.Write)
    End Sub

    Private Sub mnuSetupEdit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSetupEdit.MouseEnter
        Security.Apply(Me.mnuSetupEdit, AccessRights.Edit)
    End Sub

    Private Sub mnuSetupSecurity_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSetupSecurity.MouseEnter
        Security.Apply(Me.mnuSetupSecurity, AccessRights.Write)
        If Not Me.mnuSetupSecurityLicenses.Enabled Then Return
        Me.mnuSetupSecurityLicenses.Enabled = AppData.EnforceLicensing
    End Sub

    Private Sub mnuFileNew_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileNew.MouseEnter
        Security.Apply(Me.mnuFileNew, AccessRights.Write)
    End Sub

    Private Sub mnuFileEdit_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileEdit.MouseEnter
        Security.Apply(Me.mnuFileEdit, AccessRights.Edit)
    End Sub

    Private Sub mnuTools_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTools.MouseEnter
        Security.Apply(Me.mnuTools, AccessRights.Read)
    End Sub

    Private Sub mnuToolsDatabase_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuToolsDatabase.MouseEnter
        Security.Apply(Me.mnuToolsDatabase, AccessRights.Write)
    End Sub

    Private Sub mnuToolsNew_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsNew.MouseEnter
        Security.Apply(Me.mnuToolsNew, AccessRights.Write)
    End Sub

    Private Sub mnuToolsEdit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsEdit.MouseEnter
        Security.Apply(Me.mnuToolsEdit, AccessRights.Edit)
    End Sub

    Private Sub frmMain_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Try

            CloseProcess(proHelp)
            CloseProcess(proCalculator)

        Catch eX As Exception
            ErrorMessage(eX)

        End Try

    End Sub

    Private Sub mnuSetup_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetup.MouseEnter
        Security.Apply(Me.mnuSetup, AccessRights.Write)
    End Sub

    Private Sub mnuReports_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuReports.MouseEnter
        Security.Apply(Me.mnuReports, AccessRights.Read)
    End Sub

    Private Sub mnuSetupSecurityUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupSecurityUsers.Click
        Dim oLogin As New Logins()
        Dim fUsers As New SyncSoft.SQL.Win.Forms.Users(oLogin.ServerName, oLogin.DatabaseName)
        LoadChildForm(Me, fUsers)
    End Sub

    Private Sub mnuSetupSecurityRoles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupSecurityRoles.Click
        LoadChildForm(Me, New SyncSoft.SQL.Win.Forms.Roles())
    End Sub

    Private Sub mnuSetupSecurityChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupSecurityChangePassword.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim fPassword As New Password(PasswordAction.Change, CurrentUser.LoginID)
            fPassword.ShowDialog(Me)

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub mnuSetupLookupData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupLookupData.Click
        LoadChildForm(Me, New SyncSoft.SQL.Win.Forms.LookupData())
    End Sub

    Private Sub mnuToolsDashboard_Click(sender As System.Object, e As System.EventArgs) Handles mnuToolsDashboard.Click
        LoadChildForm(Me, New frmDashboard())
    End Sub

    Private Sub mnuToolsDatabaseBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsDatabaseBackup.Click

        Dim _backupFolder As String

        Try

            If String.IsNullOrEmpty(InitOptions.BackupFolder) Then
                _backupFolder = BackupFolder
            Else : _backupFolder = InitOptions.BackupFolder.ToString()
            End If

            Dim fBackupDatabase As New SyncSoft.SQL.Win.Forms.BackupDatabase(_backupFolder)
            fBackupDatabase.ShowDialog(Me)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub mnuToolsDatabaseRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsDatabaseRestore.Click
        Dim _backupFolder As String
        If String.IsNullOrEmpty(InitOptions.BackupFolder) Then
            _backupFolder = BackupFolder
        Else : _backupFolder = InitOptions.BackupFolder.ToString()
        End If
        Dim fRestoreDatabase As New SyncSoft.SQL.Win.Forms.RestoreDatabase(_backupFolder)
        fRestoreDatabase.ShowDialog(Me)
    End Sub

    Private Sub mnuToolsManageSpecialEdits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsManageSpecialEdits.Click
        Dim fSpecialEdits As New SyncSoft.SQL.Win.Forms.SpecialEdits()
        fSpecialEdits.ShowDialog(Me)
    End Sub

    Private Sub mnuToolsManageRestrictedKeys_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsManageRestrictedKeys.Click
        Dim fRestrictedKeys As New SyncSoft.SQL.Win.Forms.RestrictedKeys()
        fRestrictedKeys.ShowDialog(Me)
    End Sub


    Private Sub mnuToolsOthersSagePastel_Click(sender As System.Object, e As System.EventArgs) Handles mnuToolsOthersSagePastel.Click
        LoadChildForm(Me, New frmSagePastel())
    End Sub

    Private Sub tmrUserIdleDuration_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrUserIdleDuration.Tick

        Try

            Dim oActiveUsers As New SyncSoft.Security.SQL.ActiveUsers()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If InitOptions.UserIdleDuration <= 0 OrElse oActiveUsers.GetUserIdleDuration <= 0 Then Return
            If fLogin.Visible = True Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oActiveUsers.GetUserIdleDuration > InitOptions.UserIdleDuration Then

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.EnableMainCTLS(False)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                With fLogin
                    .lblUserName.Enabled = False
                    .stbUserName.ReadOnly = True
                    .lblServerName.Enabled = False
                    .cboServerName.Enabled = False
                    .btnCancel.Text = "Cancel"
                    .pnlMore.Enabled = False
                    .ShowDialog(Me)
                    If .CancelLogin = True Then Me.mnuFileExit_Click(Me, Nothing)
                End With

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If oActiveUsers.GetUserNoLogins > 1 Then oActiveUsers.Logoff()
                Me.EnableMainCTLS(True)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

        Catch eX As Exception
            Return

        End Try

    End Sub

    Private Sub EnableMainCTLS(ByVal state As Boolean)

        Me.mnuMain.Enabled = state
        Me.tlbMain.Enabled = state
        Me.stbMain.Enabled = state

    End Sub

#End Region

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oMyDefaultPCID As New LookupDataID.MyDefaultPC()
        Dim defaultpc As String = GetLookupDataDes(oMyDefaultPCID.DefaultPC)
        Dim oIntegrationAgent As New IntegrationAgents()


        Try

            fSplash.Splash.Refresh()

            proHelp = Nothing
            proCalculator = Nothing

            Me.Text = AppData.AppTitle + " - " + AppData.ProductOwner
            Me.mnuHelpAbout.Text = "About " + AppData.AppTitle + "..."

            Me.SetStyles()
            DisablestartItems()
            Me.ClosedPendingItems()
            LoadSetupData()
            Me.SwitchUser()
            
            fSplash.Splash.Close()
            Me.mnuLocation.Text = "Location : " + GetLookupDataDes(GetStaffCurrentBranch(CurrentUser.LoginID))
            Me.bmniInPatientsPara.Visible = AgentExists(oIntegrationAgent.PARA)
            Me.bmniInPatientsSmartBilling.Visible = AgentExists(oIntegrationAgent.SMART)

            If oVariousOptions.SMSNotificationForIncomeSummaries Then
                If defaultpc = My.Computer.Name Then
                    Me.tmrSMSNotifications.Enabled = True
                Else
                    Me.tmrSMSNotifications.Enabled = False
                End If
            End If

            If oVariousOptions.EnableOPDExtraBills Then

                Me.bmiNewOPDExtraBills.Visible = True
            Else
                Me.bmiNewOPDExtraBills.Visible = False
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            fSplash.Splash.Close()

        End Try

    End Sub

    Private Sub ClosedPendingItems()
        Try
            Dim oItems As New Items()
            Dim oIPDItems As New IPDItems()
            oItems.ClosePendingItems()
            oIPDItems.ClosePendingIPDItems()
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub DisablestartItems()
        Dim oVariousOptions As New VariousOptions()

        If oVariousOptions.DisablePatientRegistration Then
            Me.ddbPatients.Visible = False
            Me.tbbSeparator1.Visible = False
        End If

        If oVariousOptions.DisableVisitsCreation Then
            Me.ddbVisits.Visible = False
            Me.tbbSeparator2.Visible = False
        End If

        If oVariousOptions.DisableExtras Then
            Me.ddbExtras.Visible = False
            Me.ToolStripSeparator2.Visible = False
        End If

        If oVariousOptions.DisableTriagePoint Then
            Me.ddbTriage.Visible = False
            Me.ToolStripSeparator7.Visible = False
        End If

        If oVariousOptions.DisableCashier Then
            Me.tbbCashier.Visible = False
            Me.tbbSeparotor3.Visible = False
        End If

        If oVariousOptions.DisableInvoices Then
            Me.ddbInvoices.Visible = False
            Me.ToolStripSeparator12.Visible = False
        End If

        If oVariousOptions.DisableDoctor Then
            Me.tbbDoctor.Visible = False
            Me.tbbSeparator4.Visible = False
        End If

        If oVariousOptions.DisableLaboratory Then
            Me.ddbLaboratory.Visible = False
            Me.tbbSeparator5.Visible = False
        End If

        If oVariousOptions.DisableRadiology Then
            Me.ddbRadiology.Visible = False
            Me.ToolStripSeparator8.Visible = False
        End If

        If oVariousOptions.DisablePharmacy Then
            Me.ddbPharmacy.Visible = False
            Me.tbbSeparator6.Visible = False
        End If

        If oVariousOptions.DisableTheatre Then
            Me.ddbTheatreOperations.Visible = False
            Me.tbbSeparator7.Visible = False
        End If

        If oVariousOptions.DisableDental Then
            Me.ddbDental.Visible = False
            Me.ToolStripSeparator9.Visible = False
        End If

        If oVariousOptions.DisableAppointments Then
            Me.ddbAppointments.Visible = False
            Me.tbbSeparator10.Visible = False
        End If

        If oVariousOptions.DisableInPatients Then
            Me.ddbInPatients.Visible = False
            Me.ToolStripSeparator17.Visible = False
        End If




        If oVariousOptions.DisableManageART Then
            Me.ddbManageART.Visible = False
            Me.ToolStripSeparator15.Visible = False
        End If

        If oVariousOptions.DisableDeaths Then
            Me.ddbDeaths.Visible = False
        End If

        If oVariousOptions.DisablePathology Then
            Me.ddbCardiology.Visible = False
            Me.ToolStripSeparator18.Visible = False
        End If

        If oVariousOptions.DisableFinance Then
            Me.ddbFinances.Visible = False
            Me.ToolStripSeparator3.Visible = False
        End If
    End Sub



    Private Sub StartUpWindow()

        Select Case InitOptions.StartUpWindow

            Case "Home"

            Case "Search"
                Me.mnuViewData_Click(Me, EventArgs.Empty)

            Case "Patients"
                Me.mnuFileNewPatients_Click(Me, EventArgs.Empty)

            Case "Visits"
                Me.mnuFileNewVisits_Click(Me, EventArgs.Empty)

            Case "Triage"
                Me.mnuFileNewTriageTriage_Click(Me, EventArgs.Empty)

            Case "Cashier"
                Me.mnuFileNewCashier_Click(Me, EventArgs.Empty)

            Case "Doctor"
                Me.mnuFileNewDoctor_Click(Me, EventArgs.Empty)

            Case "Lab Requests"
                Me.mnuFileNewLaboratoryLabRequests_Click(Me, EventArgs.Empty)

            Case "Lab Results"
                Me.mnuFileNewLaboratoryLabResults_Click(Me, EventArgs.Empty)

            Case "Pharmacy"
                Me.mnuFileNewPharmacyDispense_Click(Me, EventArgs.Empty)

            Case "Appointments"
                Me.mnuFileNewAppointments_Click(Me, EventArgs.Empty)

            Case "Admissions"
                Me.mnuFileNewInPatientsAdmissions_Click(Me, EventArgs.Empty)

            Case "Discharges"
                Me.mnuFileNewInPatientsDischarges_Click(Me, EventArgs.Empty)

            Case "Deaths"
                Me.mnuFileNewDeaths_Click(Me, EventArgs.Empty)

            Case "ART Regimen"
                Me.mnuFileNewManageARTARTRegimen_Click(Me, EventArgs.Empty)

            Case "ART Stopped"
                Me.mnuFileNewManageARTARTStopped_Click(Me, EventArgs.Empty)

            Case "Inventory"
                Me.mnuFileNewPharmacyDrugInventory_Click(Me, EventArgs.Empty)

            Case "Self Request"
                Me.bmiExtrasNewSelfRequests_Click(Me, EventArgs.Empty)
            Case "Unsent Text Messages"
                Me.mnuToolsOthersUnsentTextMessages_Click(Me, EventArgs.Empty)

            Case Else
                Me.mnuViewData_Click(Me, EventArgs.Empty)

        End Select

    End Sub

#Region " Setup Menu "

    Private Sub mnuSetupExchangeRates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupExchangeRates.Click
        LoadChildForm(Me, New frmExchangeRates())
    End Sub

#Region " Setup New Billable Menu "

    Private Sub mnuSetupNewBillable_MouseEnter(sender As System.Object, e As System.EventArgs) Handles mnuSetupNewBillable.MouseEnter
        Security.Apply(Me.mnuSetupNewBillable, AccessRights.Write)
    End Sub

    Private Sub mnuSetupNewBillableServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewBillableServices.Click
        Dim _form As Form = LoadChildForm(Me, New frmServices())
        If Not _form Is Nothing Then DirectCast(_form, frmServices).Save()
    End Sub

    Private Sub mnuSetupNewBillableDrugs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewBillableDrugs.Click
        Dim _form As Form = LoadChildForm(Me, New frmDrugs())
        If Not _form Is Nothing Then DirectCast(_form, frmDrugs).Save()
    End Sub

    Private Sub mnuSetupNewBillableConsumableItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewBillableConsumableItems.Click
        Dim _form As Form = LoadChildForm(Me, New frmConsumableItems())
        If Not _form Is Nothing Then DirectCast(_form, frmConsumableItems).Save()
    End Sub

    Private Sub mnuSetupNewBillableLabTests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewBillableLabTests.Click
        Dim _form As Form = LoadChildForm(Me, New frmLabTests())
        If Not _form Is Nothing Then DirectCast(_form, frmLabTests).Save()
    End Sub

    Private Sub mnuSetupNewBillableRadiologyExaminations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewBillableRadiologyExaminations.Click
        Dim _form As Form = LoadChildForm(Me, New frmRadiologyExaminations())
        If Not _form Is Nothing Then DirectCast(_form, frmRadiologyExaminations).Save()
    End Sub

    Private Sub mnuSetupNewBillableBeds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewBillableBeds.Click
        Dim _form As Form = LoadChildForm(Me, New frmBeds())
        If Not _form Is Nothing Then DirectCast(_form, frmBeds).Save()
    End Sub

    Private Sub mnuSetupNewBillableExtraChargeItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewBillableExtraChargeItems.Click
        Dim _form As Form = LoadChildForm(Me, New frmExtraChargeItems())
        If Not _form Is Nothing Then DirectCast(_form, frmExtraChargeItems).Save()
    End Sub

    Private Sub mnuSetupNewBillableProcedures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewBillableProcedures.Click
        Dim _form As Form = LoadChildForm(Me, New frmProcedures())
        If Not _form Is Nothing Then DirectCast(_form, frmProcedures).Save()
    End Sub

    Private Sub mnuSetupNewBillableDentalServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewBillableDentalServices.Click
        Dim _form As Form = LoadChildForm(Me, New frmDentalServices())
        If Not _form Is Nothing Then DirectCast(_form, frmDentalServices).Save()
    End Sub

    Private Sub mnuSetupNewBillableTheatreServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewBillableTheatreServices.Click
        Dim _form As Form = LoadChildForm(Me, New frmTheatreServices())
        If Not _form Is Nothing Then DirectCast(_form, frmTheatreServices).Save()
    End Sub

    Private Sub mnuSetupNewBillableEyeServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewBillableEyeServices.Click
        Dim _form As Form = LoadChildForm(Me, New frmEyeServices())
        If Not _form Is Nothing Then DirectCast(_form, frmEyeServices).Save()
    End Sub

    Private Sub mnuSetupNewBillableOpticalServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewBillableOpticalServices.Click
        Dim _form As Form = LoadChildForm(Me, New frmOpticalServices())
        If Not _form Is Nothing Then DirectCast(_form, frmOpticalServices).Save()
    End Sub

    Private Sub mnuSetupNewBillableMaternityServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewBillableMaternityServices.Click
        Dim _form As Form = LoadChildForm(Me, New frmMaternityServices())
        If Not _form Is Nothing Then DirectCast(_form, frmMaternityServices).Save()
    End Sub

    Private Sub mnuSetupNewBillableICUServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewBillableICUServices.Click
        Dim _form As Form = LoadChildForm(Me, New frmICUServices())
        If Not _form Is Nothing Then DirectCast(_form, frmICUServices).Save()
    End Sub

    Private Sub mnuSetupNewPathologyExaminations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewPathologyExaminations.Click
        Dim _form As Form = LoadChildForm(Me, New frmPathologyExaminations())
        If Not _form Is Nothing Then DirectCast(_form, frmPathologyExaminations).Save()
    End Sub

#End Region

#Region " Setup New Menu "

    Private Sub mnuSetupNewOtherItems_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupNewOtherItems.Click
        Dim _form As Form = LoadChildForm(Me, New frmOtherItems())
        If Not _form Is Nothing Then DirectCast(_form, frmOtherItems).Save()

    End Sub

    Private Sub mnuSetupNewDrugCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewDrugCategories.Click
        Dim _form As Form = LoadChildForm(Me, New frmDrugCategories())
        If Not _form Is Nothing Then DirectCast(_form, frmDrugCategories).Save()
    End Sub

    Private Sub mnuSetupNewStaff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewStaff.Click
        Dim _form As Form = LoadChildForm(Me, New frmStaff())
        If Not _form Is Nothing Then DirectCast(_form, frmStaff).Save()
    End Sub

    Private Sub mnuSetupNewBillCustomers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewBillCustomers.Click
        Dim _form As Form = LoadChildForm(Me, New frmBillCustomers())
        If Not _form Is Nothing Then DirectCast(_form, frmBillCustomers).Save()
    End Sub

    Private Sub mnuSetupNewBillCustomerMembers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewBillCustomerMembers.Click
        Dim _form As Form = LoadChildForm(Me, New frmBillCustomerMembers())
        If Not _form Is Nothing Then DirectCast(_form, frmBillCustomerMembers).Save()
    End Sub

    Private Sub mnuSetupNewMemberBenefits_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupNewMemberBenefits.Click
        Dim _form As Form = LoadChildForm(Me, New frmMemberBenefits())
        If Not _form Is Nothing Then DirectCast(_form, frmMemberBenefits).Save()
    End Sub

    Private Sub mnuSetupNewDrugCombinations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewDrugCombinations.Click
        Dim _form As Form = LoadChildForm(Me, New frmDrugCombinations())
        If Not _form Is Nothing Then DirectCast(_form, frmDrugCombinations).Save()
    End Sub

    Private Sub mnuSetupNewRooms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewRooms.Click
        Dim _form As Form = LoadChildForm(Me, New frmRooms())
        If Not _form Is Nothing Then DirectCast(_form, frmRooms).Save()
    End Sub

    Private Sub mnuSetupNewDiseases_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewDiseases.Click
        Dim _form As Form = LoadChildForm(Me, New frmDiseases())
        If Not _form Is Nothing Then DirectCast(_form, frmDiseases).Save()
    End Sub

    Private Sub mnuSetupNewCancerDiseases_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupNewCancerDiseases.Click
        Dim _form As Form = LoadChildForm(Me, New frmCancerDiseases())
        If Not _form Is Nothing Then DirectCast(_form, frmCancerDiseases).Save()
    End Sub

    Private Sub mnuSetupNewUCITopologySites_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupNewUCITopologySites.Click
        Dim _form As Form = LoadChildForm(Me, New frmTopologySites())
        If Not _form Is Nothing Then DirectCast(_form, frmTopologySites).Save()
    End Sub

    Private Sub mnuSetupNewAllergies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewAllergies.Click
        Dim _form As Form = LoadChildForm(Me, New frmAllergies())
        If Not _form Is Nothing Then DirectCast(_form, frmAllergies).Save()
    End Sub

    Private Sub mnuSetupNewSuppliers_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupNewSuppliers.Click
        Dim _form As Form = LoadChildForm(Me, New frmSuppliers())
        If Not _form Is Nothing Then DirectCast(_form, frmSuppliers).Save()
    End Sub

#End Region

#Region " Setup Edit Billable Menu "

    Private Sub mnuSetupEditBillable_MouseEnter(sender As System.Object, e As System.EventArgs) Handles mnuSetupEditBillable.MouseEnter
        Security.Apply(Me.mnuSetupEditBillable, AccessRights.Edit)
    End Sub

    Private Sub mnuSetupEditBillableServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditBillableServices.Click
        Dim _form As Form = LoadChildForm(Me, New frmServices())
        If Not _form Is Nothing Then DirectCast(_form, frmServices).Edit()
    End Sub

    Private Sub mnuSetupEditBillableDrugs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditBillableDrugs.Click
        Dim _form As Form = LoadChildForm(Me, New frmDrugs())
        If Not _form Is Nothing Then DirectCast(_form, frmDrugs).Edit()
    End Sub

    Private Sub mnuSetupEditBillableConsumableItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditBillableConsumableItems.Click
        Dim _form As Form = LoadChildForm(Me, New frmConsumableItems())
        If Not _form Is Nothing Then DirectCast(_form, frmConsumableItems).Edit()
    End Sub

    Private Sub mnuSetupEditBillableLabTests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditBillableLabTests.Click
        Dim _form As Form = LoadChildForm(Me, New frmLabTests())
        If Not _form Is Nothing Then DirectCast(_form, frmLabTests).Edit()
    End Sub

    Private Sub mnuSetupEditBillableRadiologyExaminations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditBillableRadiologyExaminations.Click
        Dim _form As Form = LoadChildForm(Me, New frmRadiologyExaminations())
        If Not _form Is Nothing Then DirectCast(_form, frmRadiologyExaminations).Edit()
    End Sub

    Private Sub mnuSetupEditBillableBeds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditBillableBeds.Click
        Dim _form As Form = LoadChildForm(Me, New frmBeds())
        If Not _form Is Nothing Then DirectCast(_form, frmBeds).Edit()
    End Sub

    Private Sub mnuSetupEditBillableExtraChargeItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditBillableExtraChargeItems.Click
        Dim _form As Form = LoadChildForm(Me, New frmExtraChargeItems())
        If Not _form Is Nothing Then DirectCast(_form, frmExtraChargeItems).Edit()
    End Sub

    Private Sub mnuSetupEditBillableProcedures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditBillableProcedures.Click
        Dim _form As Form = LoadChildForm(Me, New frmProcedures())
        If Not _form Is Nothing Then DirectCast(_form, frmProcedures).Edit()
    End Sub

    Private Sub mnuSetupEditBillableDentalServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditBillableDentalServices.Click
        Dim _form As Form = LoadChildForm(Me, New frmDentalServices())
        If Not _form Is Nothing Then DirectCast(_form, frmDentalServices).Edit()
    End Sub

    Private Sub mnuSetupEditBillableTheatreServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditBillableTheatreServices.Click
        Dim _form As Form = LoadChildForm(Me, New frmTheatreServices())
        If Not _form Is Nothing Then DirectCast(_form, frmTheatreServices).Edit()
    End Sub

    Private Sub mnuSetupEditBillableEyeServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditBillableEyeServices.Click
        Dim _form As Form = LoadChildForm(Me, New frmEyeServices())
        If Not _form Is Nothing Then DirectCast(_form, frmEyeServices).Edit()
    End Sub

    Private Sub mnuSetupEditBillableOpticalServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditBillableOpticalServices.Click
        Dim _form As Form = LoadChildForm(Me, New frmOpticalServices())
        If Not _form Is Nothing Then DirectCast(_form, frmOpticalServices).Edit()
    End Sub

    Private Sub mnuSetupEditBillableMaternityServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditBillableMaternityServices.Click
        Dim _form As Form = LoadChildForm(Me, New frmMaternityServices())
        If Not _form Is Nothing Then DirectCast(_form, frmMaternityServices).Edit()
    End Sub

    Private Sub mnuSetupEditBillableICUServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditBillableICUServices.Click
        Dim _form As Form = LoadChildForm(Me, New frmICUServices())
        If Not _form Is Nothing Then DirectCast(_form, frmICUServices).Edit()
    End Sub

    Private Sub mnuSetupEditPathologyExaminations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditPathologyExaminations.Click
        Dim _form As Form = LoadChildForm(Me, New frmPathologyExaminations())
        If Not _form Is Nothing Then DirectCast(_form, frmPathologyExaminations).Edit()
    End Sub


#End Region

#Region " Setup Edit Menu "

    Private Sub mnuSetupEditOtherItems_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupEditOtherItems.Click
        Dim _form As Form = LoadChildForm(Me, New frmOtherItems())
        If Not _form Is Nothing Then DirectCast(_form, frmOtherItems).Edit()
    End Sub

    Private Sub mnuSetupEditDrugCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditDrugCategories.Click
        Dim _form As Form = LoadChildForm(Me, New frmDrugCategories())
        If Not _form Is Nothing Then DirectCast(_form, frmDrugCategories).Edit()
    End Sub

    Private Sub mnuSetupEditStaff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditStaff.Click
        Dim _form As Form = LoadChildForm(Me, New frmStaff())
        If Not _form Is Nothing Then DirectCast(_form, frmStaff).Edit()
    End Sub

    Private Sub mnuSetupEditBillCustomers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditBillCustomers.Click
        Dim _form As Form = LoadChildForm(Me, New frmBillCustomers())
        If Not _form Is Nothing Then DirectCast(_form, frmBillCustomers).Edit()
    End Sub

    Private Sub mnuSetupEditBillCustomerMembers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditBillCustomerMembers.Click
        Dim _form As Form = LoadChildForm(Me, New frmBillCustomerMembers())
        If Not _form Is Nothing Then DirectCast(_form, frmBillCustomerMembers).Edit()
    End Sub

    Private Sub mnuSetupEditMemberBenefits_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupEditMemberBenefits.Click
        Dim _form As Form = LoadChildForm(Me, New frmMemberBenefits())
        If Not _form Is Nothing Then DirectCast(_form, frmMemberBenefits).Edit()
    End Sub

    Private Sub mnuSetupEditDrugCombinations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditDrugCombinations.Click
        Dim _form As Form = LoadChildForm(Me, New frmDrugCombinations())
        If Not _form Is Nothing Then DirectCast(_form, frmDrugCombinations).Edit()
    End Sub

    Private Sub mnuSetupEditRooms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditRooms.Click
        Dim _form As Form = LoadChildForm(Me, New frmRooms())
        If Not _form Is Nothing Then DirectCast(_form, frmRooms).Edit()
    End Sub

    Private Sub mnuSetupEditDiseases_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditDiseases.Click
        Dim _form As Form = LoadChildForm(Me, New frmDiseases())
        If Not _form Is Nothing Then DirectCast(_form, frmDiseases).Edit()
    End Sub

    Private Sub mnuSetupEditCancerDiseases_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupEditCancerDiseases.Click
        Dim _form As Form = LoadChildForm(Me, New frmCancerDiseases())
        If Not _form Is Nothing Then DirectCast(_form, frmCancerDiseases).Edit()
    End Sub

    Private Sub mnuSetupEditTopologySites_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupEditTopologySites.Click
        Dim _form As Form = LoadChildForm(Me, New frmTopologySites())
        If Not _form Is Nothing Then DirectCast(_form, frmTopologySites).Edit()
    End Sub

    Private Sub mnuSetupEditAllergies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditAllergies.Click
        Dim _form As Form = LoadChildForm(Me, New frmAllergies())
        If Not _form Is Nothing Then DirectCast(_form, frmAllergies).Edit()
    End Sub

    Private Sub mnuSetupEditSuppliers_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupEditSuppliers.Click
        Dim _form As Form = LoadChildForm(Me, New frmSuppliers())
        If Not _form Is Nothing Then DirectCast(_form, frmSuppliers).Edit()
    End Sub

#End Region

#Region " Setup New Geographical Location Menu "

    Private Sub mnuSetupNewGeographicalLocation_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewGeographicalLocation.MouseEnter
        Security.Apply(Me.mnuSetupNewGeographicalLocation, AccessRights.Write)
    End Sub

    Private Sub mnuSetupNewGeographicalLocationCounties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewGeographicalLocationCounties.Click
        Dim _form As Form = LoadChildForm(Me, New frmCounties())
        If Not _form Is Nothing Then DirectCast(_form, frmCounties).Save()
    End Sub

    Private Sub mnuSetupNewGeographicalLocationSubCounties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewGeographicalLocationSubCounties.Click
        Dim _form As Form = LoadChildForm(Me, New frmSubCounties())
        If Not _form Is Nothing Then DirectCast(_form, frmSubCounties).Save()
    End Sub

    Private Sub mnuSetupNewGeographicalLocationParishes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewGeographicalLocationParishes.Click
        Dim _form As Form = LoadChildForm(Me, New frmParishes())
        If Not _form Is Nothing Then DirectCast(_form, frmParishes).Save()
    End Sub

    Private Sub mnuSetupNewGeographicalLocationVillages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewGeographicalLocationVillages.Click
        Dim _form As Form = LoadChildForm(Me, New frmVillages())
        If Not _form Is Nothing Then DirectCast(_form, frmVillages).Save()
    End Sub

#End Region

#Region " Setup Edit Geographical Location Menu "

    Private Sub mnuSetupEditGeographicalLocation_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditGeographicalLocation.MouseEnter
        Security.Apply(Me.mnuSetupEditGeographicalLocation, AccessRights.Edit)
    End Sub

    Private Sub mnuSetupEditGeographicalLocationCounties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditGeographicalLocationCounties.Click
        Dim _form As Form = LoadChildForm(Me, New frmCounties())
        If Not _form Is Nothing Then DirectCast(_form, frmCounties).Edit()
    End Sub

    Private Sub mnuSetupEditGeographicalLocationSubCounties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditGeographicalLocationSubCounties.Click
        Dim _form As Form = LoadChildForm(Me, New frmSubCounties())
        If Not _form Is Nothing Then DirectCast(_form, frmSubCounties).Edit()
    End Sub

    Private Sub mnuSetupEditGeographicalLocationParishes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditGeographicalLocationParishes.Click
        Dim _form As Form = LoadChildForm(Me, New frmParishes())
        If Not _form Is Nothing Then DirectCast(_form, frmParishes).Edit()
    End Sub

    Private Sub mnuSetupEditGeographicalLocationVillages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditGeographicalLocationVillages.Click
        Dim _form As Form = LoadChildForm(Me, New frmVillages())
        If Not _form Is Nothing Then DirectCast(_form, frmVillages).Edit()
    End Sub

#End Region

#Region " Setup New Insurance Menu "

    Private Sub mnuSetupNewInsurance_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewInsurance.MouseEnter
        Security.Apply(Me.mnuSetupNewInsurance, AccessRights.Write)
    End Sub

    Private Sub mnuSetupNewInsuranceInsurances_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewInsuranceInsurances.Click
        Dim _form As Form = LoadChildForm(Me, New frmInsurances())
        If Not _form Is Nothing Then DirectCast(_form, frmInsurances).Save()
    End Sub

    Private Sub mnuSetupNewInsuranceInsurancePolicies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewInsuranceInsurancePolicies.Click
        Dim _form As Form = LoadChildForm(Me, New frmInsurancePolicies())
        If Not _form Is Nothing Then DirectCast(_form, frmInsurancePolicies).Save()
    End Sub

    Private Sub mnuSetupNewInsuranceCompanies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewInsuranceCompanies.Click
        Dim _form As Form = LoadChildForm(Me, New frmCompanies())
        If Not _form Is Nothing Then DirectCast(_form, frmCompanies).Save()
    End Sub

    Private Sub mnuSetupNewInsuranceInsuranceSchemes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewInsuranceInsuranceSchemes.Click
        Dim _form As Form = LoadChildForm(Me, New frmInsuranceSchemes())
        If Not _form Is Nothing Then DirectCast(_form, frmInsuranceSchemes).Save()
    End Sub

    Private Sub mnuSetupNewInsuranceSchemeMembers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewInsuranceSchemeMembers.Click
        Dim _form As Form = LoadChildForm(Me, New frmSchemeMembers())
        If Not _form Is Nothing Then DirectCast(_form, frmSchemeMembers).Save()
    End Sub

    Private Sub mnuSetupNewInsuranceHealthUnits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupNewInsuranceHealthUnits.Click
        Dim _form As Form = LoadChildForm(Me, New frmHealthUnits())
        If Not _form Is Nothing Then DirectCast(_form, frmHealthUnits).Save()
    End Sub

#End Region

#Region " Setup Edit Insurance Menu "

    Private Sub mnuSetupEditInsurance_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditInsurance.MouseEnter
        Security.Apply(Me.mnuSetupEditInsurance, AccessRights.Edit)
    End Sub

    Private Sub mnuSetupEditInsuranceInsurances_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditInsuranceInsurances.Click
        Dim _form As Form = LoadChildForm(Me, New frmInsurances())
        If Not _form Is Nothing Then DirectCast(_form, frmInsurances).Edit()
    End Sub

    Private Sub mnuSetupEditInsuranceInsurancePolicies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditInsuranceInsurancePolicies.Click
        Dim _form As Form = LoadChildForm(Me, New frmInsurancePolicies())
        If Not _form Is Nothing Then DirectCast(_form, frmInsurancePolicies).Edit()
    End Sub

    Private Sub mnuSetupEditInsuranceCompanies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditInsuranceCompanies.Click
        Dim _form As Form = LoadChildForm(Me, New frmCompanies())
        If Not _form Is Nothing Then DirectCast(_form, frmCompanies).Edit()
    End Sub

    Private Sub mnuSetupEditInsuranceInsuranceSchemes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditInsuranceInsuranceSchemes.Click
        Dim _form As Form = LoadChildForm(Me, New frmInsuranceSchemes())
        If Not _form Is Nothing Then DirectCast(_form, frmInsuranceSchemes).Edit()
    End Sub

    Private Sub mnuSetupEditInsuranceSchemeMembers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditInsuranceSchemeMembers.Click
        Dim _form As Form = LoadChildForm(Me, New frmSchemeMembers())
        If Not _form Is Nothing Then DirectCast(_form, frmSchemeMembers).Edit()
    End Sub

    Private Sub mnuSetupEditInsuranceHealthUnits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupEditInsuranceHealthUnits.Click
        Dim _form As Form = LoadChildForm(Me, New frmHealthUnits())
        If Not _form Is Nothing Then DirectCast(_form, frmHealthUnits).Edit()
    End Sub

#End Region

#End Region

#Region " File Menu "

#Region " File New Menu "

    Private Sub mnuFileNewPatients_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewPatients.Click
        If Not oVariousOptions.EnableSecondPatientForm Then
            Dim _form As Form = LoadChildForm(Me, New frmPatients())
            If Not _form Is Nothing Then DirectCast(_form, frmPatients).Save()
        Else
            Dim _form As Form = LoadChildForm(Me, New frmPatientsTwo())
            If Not _form Is Nothing Then DirectCast(_form, frmPatientsTwo).Save()
        End If
    End Sub

    Private Sub mnuFileNewCashier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewCashier.Click
        LoadChildForm(Me, New frmCashier())
    End Sub

    Private Sub mnuFileNewDoctor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewDoctor.Click
        LoadChildForm(Me, New frmDoctor())
    End Sub

    Private Sub mnuFileNewVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewVisits.Click
        Dim _form As Form = LoadChildForm(Me, New frmVisits())
        If Not _form Is Nothing Then DirectCast(_form, frmVisits).Save()
    End Sub

    Private Sub mnuFileNewAppointments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewAppointments.Click
        Dim _form As Form = LoadChildForm(Me, New frmAppointments())
        If Not _form Is Nothing Then DirectCast(_form, frmAppointments).Save()
    End Sub

    Private Sub mnuFileNewDeaths_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewDeaths.Click
        Dim _form As Form = LoadChildForm(Me, New frmDeaths(String.Empty))
        If Not _form Is Nothing Then DirectCast(_form, frmDeaths).Save()
    End Sub

    Private Sub mnuFileNewManageARTExaminations_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileNewManageARTExaminations.Click
        Dim _form As Form = LoadChildForm(Me, New frmExaminations())
        If Not _form Is Nothing Then DirectCast(_form, frmExaminations).Save()
    End Sub

#End Region

#Region " File Edit Menu "

    Private Sub mnuFileEditPatients_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditPatients.Click
        If Not oVariousOptions.EnableSecondPatientForm Then
            Dim _form As Form = LoadChildForm(Me, New frmPatients())
            If Not _form Is Nothing Then DirectCast(_form, frmPatients).Edit()
        Else
            Dim _form As Form = LoadChildForm(Me, New frmPatientsTwo())
            If Not _form Is Nothing Then DirectCast(_form, frmPatientsTwo).Edit()
        End If
    End Sub

    Private Sub mnuFileEditVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditVisits.Click
        Dim _form As Form = LoadChildForm(Me, New frmVisits())
        If Not _form Is Nothing Then DirectCast(_form, frmVisits).Edit()
    End Sub

    Private Sub mnuFileEditAppointments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditAppointments.Click
        Dim _form As Form = LoadChildForm(Me, New frmAppointments())
        If Not _form Is Nothing Then DirectCast(_form, frmAppointments).Edit()
    End Sub

    Private Sub mnuFileEditDeaths_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditDeaths.Click
        Dim _form As Form = LoadChildForm(Me, New frmDeaths(String.Empty))
        If Not _form Is Nothing Then DirectCast(_form, frmDeaths).Edit()
    End Sub

    Private Sub mnuFileEditManageARTExaminations_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileEditManageARTExaminations.Click
        Dim _form As Form = LoadChildForm(Me, New frmExaminations())
        If Not _form Is Nothing Then DirectCast(_form, frmExaminations).Edit()
    End Sub

#End Region

#Region " File New Extras Menu "

    Private Sub mnuFileNewExtras_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewExtras.MouseEnter
        Security.Apply(Me.mnuFileNewExtras, AccessRights.Write)
    End Sub

    Private Sub mnuFileNewExtrasSelfRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewExtrasSelfRequests.Click
        Dim _form As Form = LoadChildForm(Me, New frmSelfRequests())
        If Not _form Is Nothing Then DirectCast(_form, frmSelfRequests).Save()
    End Sub

    Private Sub mnuFileNewExtrasClaims_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewExtrasClaims.Click
        Dim _form As Form = LoadChildForm(Me, New frmClaims())
        If Not _form Is Nothing Then DirectCast(_form, frmClaims).Save()
    End Sub

    Private Sub mnuFileNewExtrasQuotations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewExtrasQuotations.Click
        Dim _form As Form = LoadChildForm(Me, New frmQuotations())
        If Not _form Is Nothing Then DirectCast(_form, frmQuotations).Save()
    End Sub

    Private Sub mnuFileNewExtrasConsumables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewExtrasConsumables.Click
        LoadChildForm(Me, New frmConsumables())
    End Sub

    Private Sub mnuFileNewExtrasExtraCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewExtrasExtraCharge.Click
        LoadChildForm(Me, New frmExtraCharge())
    End Sub

    Private Sub mnuFileNewExtrasConsumableInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewExtrasConsumableInventory.Click
        Dim oItemCategoryID As New SyncSoft.SQLDb.Lookup.LookupDataID.ItemCategoryID()
        LoadChildForm(Me, New frmInventory(oItemCategoryID.Consumable))
    End Sub

    Private Sub mnuFileNewExtrasPurchaseOrders_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileNewExtrasPurchaseOrders.Click
        Dim _form As Form = LoadChildForm(Me, New frmPurchaseOrders())
        If Not _form Is Nothing Then DirectCast(_form, frmPurchaseOrders).Save()
    End Sub

    Private Sub mnuFileNewExtrasGoodsReceivedNote_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileNewExtrasGoodsReceivedNote.Click
        LoadChildForm(Me, New frmGoodsReceivedNote())
    End Sub

    Private Sub mnuFileNewExtrasInventoryOrders_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileNewExtrasInventoryOrders.Click
        Dim _form As Form = LoadChildForm(Me, New frmInventoryOrders())
        If Not _form Is Nothing Then DirectCast(_form, frmInventoryOrders).Save()
    End Sub

    Private Sub mnuFileNewExtrasInventoryTransfers_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileNewExtrasInventoryTransfers.Click
        Dim _form As Form = LoadChildForm(Me, New frmInventoryTransfers())
        If Not _form Is Nothing Then DirectCast(_form, frmInventoryTransfers).Save()
    End Sub

    Private Sub mnuFileNewExtrasProcessInventoryOrders_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileNewExtrasProcessInventoryOrders.Click
        LoadChildForm(Me, New frmProcessInventoryOrders())
    End Sub

    Private Sub mnuFileNewExtrasInventoryAcknowledges_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileNewExtrasInventoryAcknowledges.Click
        LoadChildForm(Me, New frmInventoryAcknowledges())
    End Sub

    Private Sub bmiExtrasNewAssetsRegister_Click(sender As Object, e As EventArgs) Handles bmiExtrasNewAssetsRegister.Click
        Dim _form As Form = LoadChildForm(Me, New frmAssetRegister())
        If Not _form Is Nothing Then DirectCast(_form, frmAssetRegister).Save()
    End Sub

    Private Sub bmiExtrasNewAssetMaintainanceLog_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasNewAssetMaintainanceLog.Click
        Dim _form As Form = LoadChildForm(Me, New frmAssetMaintainanceLog())
        If Not _form Is Nothing Then DirectCast(_form, frmAssetMaintainanceLog).Save()
    End Sub

    Private Sub bmiExtrasNewSymptomsHistory_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasNewSymptomsHistory.Click
        Dim _form As Form = LoadChildForm(Me, New frmSymptomsHistory())
        If Not _form Is Nothing Then DirectCast(_form, frmSymptomsHistory).Save()
    End Sub

    Private Sub bmiExtrasNewBillableMappings_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasNewBillableMappings.Click
        Dim _form As Form = LoadChildForm(Me, New frmBillableMappings())
        If Not _form Is Nothing Then DirectCast(_form, frmBillableMappings).Save()
    End Sub

    Private Sub bmiExtrasEditAssetsRegister_Click(sender As Object, e As EventArgs) Handles bmiExtrasEditAssetsRegister.Click
        Dim _form As Form = LoadChildForm(Me, New frmAssetRegister())
        If Not _form Is Nothing Then DirectCast(_form, frmAssetRegister).Edit()
    End Sub


    Private Sub bmiExtrasEditAssetMaintainanceLog_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasEditAssetMaintainanceLog.Click
        Dim _form As Form = LoadChildForm(Me, New frmAssetMaintainanceLog())
        If Not _form Is Nothing Then DirectCast(_form, frmAssetMaintainanceLog).Edit()
    End Sub

    Private Sub bmiExtrasEditSymptomsHistory_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasEditSymptomsHistory.Click
        Dim _form As Form = LoadChildForm(Me, New frmSymptomsHistory())
        If Not _form Is Nothing Then DirectCast(_form, frmSymptomsHistory).Edit()
    End Sub

    Private Sub mnuFileNewExtrasVisitFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewExtrasVisitFiles.Click
        LoadChildForm(Me, New frmVisitFiles())
    End Sub

    Private Sub mnuFileNewExtrasOutwardFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewExtrasOutwardFiles.Click
        Dim _form As Form = LoadChildForm(Me, New frmOutwardFiles())
        If Not _form Is Nothing Then DirectCast(_form, frmOutwardFiles).Save()
    End Sub

    Private Sub mnuFileNewExtrasInwardFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewExtrasInwardFiles.Click
        Dim _form As Form = LoadChildForm(Me, New frmInwardFiles())
        If Not _form Is Nothing Then DirectCast(_form, frmInwardFiles).Save()
    End Sub

    Private Sub mnuFileNewExtrasSmartCardAuthorisations_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileNewExtrasSmartCardAuthorisations.Click
        Dim _form As Form = LoadChildForm(Me, New frmSmartCardAuthorisations())
        If Not _form Is Nothing Then DirectCast(_form, frmSmartCardAuthorisations).Save()
    End Sub

    Private Sub mnuFileNewExternalReferralForm_Click(sender As Object, e As EventArgs) Handles mnuFileNewExternalReferralForm.Click
        Dim _form As Form = LoadChildForm(Me, New frmExternalReferrals())
        If Not _form Is Nothing Then DirectCast(_form, frmExternalReferrals).Save()
    End Sub
    Private Sub mnuFileNewExtrasResearchRoutingForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewExtrasResearchRoutingForm.Click
        Dim _form As Form = LoadChildForm(Me, New frmResearchRoutingForm())
        If Not _form Is Nothing Then DirectCast(_form, frmResearchRoutingForm).Save()
    End Sub

    Private Sub mnuFileNewExtrasEnrollmentInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewExtrasEnrollmentInformation.Click
        Dim _form As Form = LoadChildForm(Me, New frmEnrollmentInformation())
        If Not _form Is Nothing Then DirectCast(_form, frmEnrollmentInformation).Save()
    End Sub

    Private Sub bmiExtrasNewARTPatient_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasNewARTPatient.Click
        Dim _form As Form = LoadChildForm(Me, New frmHIVCARE())
        If Not _form Is Nothing Then DirectCast(_form, frmHIVCARE).Save()
    End Sub

    Private Sub bmiExtrasNewClients_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasNewClients.Click
        Dim _form As Form = LoadChildForm(Me, New frmClients())
        If Not _form Is Nothing Then DirectCast(_form, frmClients).Save()
    End Sub



#End Region

#Region " File Edit Extras Menu "

    Private Sub mnuFileEditExtras_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditExtras.MouseEnter
        Security.Apply(Me.mnuFileEditExtras, AccessRights.Edit)
    End Sub

    Private Sub mnuFileEditSelfRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditExtrasSelfRequests.Click
        Dim _form As Form = LoadChildForm(Me, New frmSelfRequests())
        If Not _form Is Nothing Then DirectCast(_form, frmSelfRequests).Edit()
    End Sub

    Private Sub mnuFileEditQuotations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditExtrasQuotations.Click
        Dim _form As Form = LoadChildForm(Me, New frmQuotations())
        If Not _form Is Nothing Then DirectCast(_form, frmQuotations).Edit()
    End Sub

    Private Sub mnuFileEditExtrasPurchaseOrders_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileEditExtrasPurchaseOrders.Click
        Dim _form As Form = LoadChildForm(Me, New frmPurchaseOrders())
        If Not _form Is Nothing Then DirectCast(_form, frmPurchaseOrders).Edit()
    End Sub

    Private Sub mnuFileEditExtrasInventoryOrders_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileEditExtrasInventoryOrders.Click
        Dim _form As Form = LoadChildForm(Me, New frmInventoryOrders())
        If Not _form Is Nothing Then DirectCast(_form, frmInventoryOrders).Edit()
    End Sub

    Private Sub mnuFileEditExtrasInventoryTransfers_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileEditExtrasInventoryTransfers.Click
        Dim _form As Form = LoadChildForm(Me, New frmInventoryTransfers())
        If Not _form Is Nothing Then DirectCast(_form, frmInventoryTransfers).Edit()
    End Sub

    Private Sub mnuFileEditExtrasClaims_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditExtrasClaims.Click
        Dim _form As Form = LoadChildForm(Me, New frmClaims())
        If Not _form Is Nothing Then DirectCast(_form, frmClaims).Edit()
    End Sub

    Private Sub mnuFileEditExtrasOutwardFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditExtrasOutwardFiles.Click
        Dim _form As Form = LoadChildForm(Me, New frmOutwardFiles())
        If Not _form Is Nothing Then DirectCast(_form, frmOutwardFiles).Edit()
    End Sub

    Private Sub mnuFileEditExtrasInwardFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditExtrasInwardFiles.Click
        Dim _form As Form = LoadChildForm(Me, New frmInwardFiles())
        If Not _form Is Nothing Then DirectCast(_form, frmInwardFiles).Edit()
    End Sub

    Private Sub mnuFileEditExtrasSmartCardAuthorisations_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileEditExtrasSmartCardAuthorisations.Click
        Dim _form As Form = LoadChildForm(Me, New frmSmartCardAuthorisations())
        If Not _form Is Nothing Then DirectCast(_form, frmSmartCardAuthorisations).Edit()
    End Sub

    Private Sub mnuFileEditExtrasResearchRoutingForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditExtrasResearchRoutingForm.Click
        Dim _form As Form = LoadChildForm(Me, New frmResearchRoutingForm())
        If Not _form Is Nothing Then DirectCast(_form, frmResearchRoutingForm).Edit()
    End Sub

    Private Sub mnuFileEditExtrasResearchEnrollmentInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditExtrasResearchEnrollmentInformation.Click
        Dim _form As Form = LoadChildForm(Me, New frmEnrollmentInformation())
        If Not _form Is Nothing Then DirectCast(_form, frmEnrollmentInformation).Edit()
    End Sub

    Private Sub mnuFileEditExtrasExternalReferralForm_Click(sender As Object, e As EventArgs) Handles mnuFileEditExtrasExternalReferralForm.Click
        Dim _form As Form = LoadChildForm(Me, New frmExternalReferrals())
        If Not _form Is Nothing Then DirectCast(_form, frmExternalReferrals).Edit()
    End Sub

    Private Sub bmiExtrasEditARTPatient_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasEditARTPatient.Click
        Dim _form As Form = LoadChildForm(Me, New frmHIVCARE())
        If Not _form Is Nothing Then DirectCast(_form, frmHIVCARE).Edit()
    End Sub

    Private Sub bmiExtrasEditClients_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasEditClients.Click
        Dim _form As Form = LoadChildForm(Me, New frmClients())
        If Not _form Is Nothing Then DirectCast(_form, frmClients).Edit()
    End Sub

#End Region

#Region " File New Triage Menu "

    Private Sub mnuFileNewTriage_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewTriage.MouseEnter
        Security.Apply(Me.mnuFileNewTriage, AccessRights.Write)
    End Sub

    Private Sub mnuFileNewTriageTriage_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileNewTriageTriage.Click
        Dim _form As Form = LoadChildForm(Me, New frmTriage())
        If Not _form Is Nothing Then DirectCast(_form, frmTriage).Save()
    End Sub

    Private Sub mnuFileNewTriageVisionAssessment_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileNewTriageVisionAssessment.Click
        Dim _form As Form = LoadChildForm(Me, New frmVisionAssessment())
        If Not _form Is Nothing Then DirectCast(_form, frmVisionAssessment).Save()
    End Sub

    Private Sub mnuFileNewTriageIPDVisionAssessment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewTriageIPDVisionAssessment.Click
        Dim _form As Form = LoadChildForm(Me, New frmIPDVisionAssessment())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDVisionAssessment).Save()
    End Sub

#End Region

#Region " File Edit Triage Menu "

    Private Sub mnuFileEditTriage_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditTriage.MouseEnter
        Security.Apply(Me.mnuFileEditTriage, AccessRights.Edit)
    End Sub

    Private Sub mnuFileEditTriageTriage_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileEditTriageTriage.Click
        Dim _form As Form = LoadChildForm(Me, New frmTriage())
        If Not _form Is Nothing Then DirectCast(_form, frmTriage).Edit()
    End Sub

    Private Sub mnuFileEditTriageVisionAssessment_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileEditTriageVisionAssessment.Click
        Dim _form As Form = LoadChildForm(Me, New frmVisionAssessment())
        If Not _form Is Nothing Then DirectCast(_form, frmVisionAssessment).Edit()
    End Sub

    Private Sub mnuFileEditTriageIPDVisionAssessment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditTriageIPDVisionAssessment.Click
        Dim _form As Form = LoadChildForm(Me, New frmIPDVisionAssessment())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDVisionAssessment).Edit()
    End Sub

#End Region

#Region " File New Invoices Menu "

    Private Sub mnuFileNewInvoices_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewInvoices.MouseEnter
        Security.Apply(Me.mnuFileNewInvoices, AccessRights.Write)
    End Sub

    Private Sub mnuFileNewInvoicesInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewInvoicesInvoices.Click
        Dim _form As Form = LoadChildForm(Me, New frmInvoices())
        If Not _form Is Nothing Then DirectCast(_form, frmInvoices).Save()
    End Sub

    Private Sub mnuFileNewInvoicesIPDInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewInvoicesIPDInvoices.Click
        Dim _form As Form = LoadChildForm(Me, New frmIPDInvoices())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDInvoices).Save()
    End Sub

#End Region

#Region " File Edit Invoices Menu "

    Private Sub mnuFileEditInvoices_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditInvoices.MouseEnter
        Security.Apply(Me.mnuFileEditInvoices, AccessRights.Edit)
    End Sub

    Private Sub mnuFileEditInvoicesInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditInvoicesInvoices.Click
        Dim _form As Form = LoadChildForm(Me, New frmInvoices())
        If Not _form Is Nothing Then DirectCast(_form, frmInvoices).Edit()
    End Sub

    Private Sub mnuFileEditInvoicesIPDInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditInvoicesIPDInvoices.Click
        Dim _form As Form = LoadChildForm(Me, New frmIPDInvoices())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDInvoices).Edit()
    End Sub

#End Region

#Region " File New Laboratory Menu "

    Private Sub mnuFileNewLaboratory_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewLaboratory.MouseEnter
        Security.Apply(Me.mnuFileNewLaboratory, AccessRights.Write)
    End Sub

    Private Sub mnuFileNewLaboratoryLabRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewLaboratoryLabRequests.Click
        Dim _form As Form = LoadChildForm(Me, New frmLabRequests())
        If Not _form Is Nothing Then DirectCast(_form, frmLabRequests).Save()
    End Sub

    Private Sub mnuFileNewLaboratoryLabResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewLaboratoryLabResults.Click
        Dim _form As Form = LoadChildForm(Me, New frmLabResults())
        If Not _form Is Nothing Then DirectCast(_form, frmLabResults).Save()
    End Sub

    Private Sub mnuFileNewLaboratoryIPDLabRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewLaboratoryIPDLabRequests.Click
        Dim _form As Form = LoadChildForm(Me, New frmIPDLabRequests())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDLabRequests).Save()
    End Sub



    Private Sub mnuFileNewLaboratoryPathologyRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadChildForm(Me, New frmPathologyRequests())
    End Sub

    Private Sub mnuFileNewLaboratoryIPDPathologyRequests_Click(sender As System.Object, e As System.EventArgs)
        LoadChildForm(Me, New frmIPDPathologyRequests())
    End Sub

    Private Sub bmiLaboratoryNewIPDPathologyRequests_Click(sender As System.Object, e As System.EventArgs) Handles bmiPathologyNewIPDPathologyRequests.Click
        mnuFileNewLaboratoryIPDPathologyRequests_Click(Me, EventArgs.Empty)
    End Sub


#End Region

#Region " File Edit Laboratory Menu "

    Private Sub mnuFileEditLaboratory_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditLaboratory.MouseEnter
        Security.Apply(Me.mnuFileEditLaboratory, AccessRights.Edit)
    End Sub

    Private Sub mnuFileEditLaboratoryLabRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditLaboratoryLabRequests.Click
        Dim _form As Form = LoadChildForm(Me, New frmLabRequests())
        If Not _form Is Nothing Then DirectCast(_form, frmLabRequests).Edit()
    End Sub

    Private Sub mnuFileEditLaboratoryLabResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditLaboratoryLabResults.Click
        Dim _form As Form = LoadChildForm(Me, New frmLabResults())
        If Not _form Is Nothing Then DirectCast(_form, frmLabResults).Edit()
    End Sub

    Private Sub mnuFileEditLaboratoryIPDLabRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditLaboratoryIPDLabRequests.Click
        Dim _form As Form = LoadChildForm(Me, New frmIPDLabRequests())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDLabRequests).Edit()
    End Sub

    Private Sub mnuFileEditLaboratoryIPDLabResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _form As Form = LoadChildForm(Me, New frmIPDLabResults())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDLabResults).Edit()
    End Sub


#End Region

#Region " File New Cardiology Menu "

    Private Sub mnuFileNewCardiology_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewCardiology.MouseEnter
        Security.Apply(Me.mnuFileNewCardiology, AccessRights.Write)
    End Sub

    Private Sub mnuFileNewCardiologyCardiologyRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewCardiologyCardiologyRequests.Click
        LoadChildForm(Me, New frmCardiologyRequests())
    End Sub

    Private Sub mnuFileNewCardiologyIPDCardiologyRequests_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileNewCardiologyIPDCardiologyRequests.Click
        LoadChildForm(Me, New frmIPDCardiologyRequests())
    End Sub

    Private Sub bmiCardiologyNewIPDCardiologyRequests_Click(sender As System.Object, e As System.EventArgs) Handles bmiCardiologyNewIPDCardiologyRequests.Click
        mnuFileNewCardiologyIPDCardiologyRequests_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub mnuFileNewCardiologyCardiologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewCardiologyCardiologyReports.Click
        Dim _form As Form = LoadChildForm(Me, New frmCardiologyReports())
        If Not _form Is Nothing Then DirectCast(_form, frmCardiologyReports).Save()
    End Sub

    Private Sub bmiCardiologyNewIPDCardiologyReports_Click(sender As System.Object, e As System.EventArgs) Handles bmiCardiologyNewIPDCardiologyReports.Click
        Dim _form As Form = LoadChildForm(Me, New frmIPDCardiologyReports())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDCardiologyReports).Save()
    End Sub
#End Region

#Region " File Edit Cardiology Menu "

    Private Sub mnuFileEditCardiology_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditCardiology.MouseEnter
        Security.Apply(Me.mnuFileEditCardiology, AccessRights.Edit)
    End Sub

    Private Sub mnuFileEditCardiologyCardiologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditCardiologyCardiologyReports.Click
        Dim _form As Form = LoadChildForm(Me, New frmCardiologyReports())
        If Not _form Is Nothing Then DirectCast(_form, frmCardiologyReports).Edit()
    End Sub

#End Region

#Region " File New Pathology Menu "

    Private Sub mnuFileNewPathology_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewPathology.MouseEnter
        Security.Apply(Me.mnuFileNewPathology, AccessRights.Write)
    End Sub

    Private Sub mnuFileNewPathologyPathologyRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewPathologyPathologyRequests.Click
        LoadChildForm(Me, New frmPathologyRequests())
    End Sub

    Private Sub mnuFileNewPathologyIPDPathologyRequests_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileNewPathologyIPDPathologyRequests.Click
        LoadChildForm(Me, New frmIPDPathologyRequests())
    End Sub



    Private Sub mnuFileNewPathologyPathologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewPathologyPathologyReports.Click
        Dim _form As Form = LoadChildForm(Me, New frmPathologyReports())
        If Not _form Is Nothing Then DirectCast(_form, frmPathologyReports).Save()
    End Sub


#End Region

#Region " File Edit Pathology Menu "

    Private Sub mnuFileEditPathology_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditPathology.MouseEnter
        Security.Apply(Me.mnuFileEditPathology, AccessRights.Edit)
    End Sub

    Private Sub mnuFileEditPathologyPathologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditPathologyPathologyReports.Click
        Dim _form As Form = LoadChildForm(Me, New frmPathologyReports())
        If Not _form Is Nothing Then DirectCast(_form, frmPathologyReports).Edit()
    End Sub

#End Region


#Region " File New Radiology Menu "

    Private Sub mnuFileNewRadiology_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewRadiology.MouseEnter
        Security.Apply(Me.mnuFileNewRadiology, AccessRights.Write)
    End Sub

    Private Sub mnuFileNewRadiologyRadiologyRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewRadiologyRadiologyRequests.Click
        LoadChildForm(Me, New frmRadiologyRequests())
    End Sub

    Private Sub mnuFileNewRadiologyRadiologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewRadiologyRadiologyReports.Click
        Dim _form As Form = LoadChildForm(Me, New frmRadiologyReports())
        If Not _form Is Nothing Then DirectCast(_form, frmRadiologyReports).Save()
    End Sub

    Private Sub mnuFileNewRadiologyIPDRadiologyRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewRadiologyIPDRadiologyRequests.Click
        LoadChildForm(Me, New frmIPDRadiologyRequests())
    End Sub

    Private Sub mnuFileNewRadiologyIPDRadiologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewRadiologyIPDRadiologyReports.Click
        Dim _form As Form = LoadChildForm(Me, New frmIPDRadiologyReports())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDRadiologyReports).Save()
    End Sub

#End Region

#Region " File Edit Radiology Menu "

    Private Sub mnuFileEditRadiology_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditRadiology.MouseEnter
        Security.Apply(Me.mnuFileEditRadiology, AccessRights.Edit)
    End Sub

    Private Sub mnuFileEditRadiologyRadiologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditRadiologyRadiologyReports.Click
        Dim _form As Form = LoadChildForm(Me, New frmRadiologyReports())
        If Not _form Is Nothing Then DirectCast(_form, frmRadiologyReports).Edit()
    End Sub

    Private Sub mnuFileEditRadiologyIPDRadiologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditRadiologyIPDRadiologyReports.Click
        Dim _form As Form = LoadChildForm(Me, New frmIPDRadiologyReports())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDRadiologyReports).Edit()
    End Sub

#End Region


#Region " File New Pharmacy Menu "

    Private Sub mnuFileNewPharmacy_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewPharmacy.MouseEnter
        Security.Apply(Me.mnuFileNewPharmacy, AccessRights.Write)
    End Sub

    Private Sub mnuFileNewPharmacyDispense_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewPharmacyDispense.Click
        LoadChildForm(Me, New frmPharmacy())
    End Sub

    Private Sub mnuFileNewPharmacyIPDDispense_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewPharmacyIPDDispense.Click
        LoadChildForm(Me, New frmIPDPharmacy())
    End Sub

    Private Sub mnuFileNewPharmacyDrugInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewPharmacyDrugInventory.Click
        Dim oItemCategoryID As New SyncSoft.SQLDb.Lookup.LookupDataID.ItemCategoryID()
        LoadChildForm(Me, New frmInventory(oItemCategoryID.Drug))
    End Sub

    Private Sub mnuFileNewPharmacyIssueConsumables_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileNewPharmacyIssueConsumables.Click
        LoadChildForm(Me, New frmIssueConsumables())
    End Sub

    Private Sub mnuFileNewPharmacyIssueIPDConsumables_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileNewPharmacyIssueIPDConsumables.Click
        LoadChildForm(Me, New frmIssueIPDConsumables())
    End Sub

#End Region

#Region " File Edit Pharmacy Menu "

    Private Sub mnuFileEditPharmacy_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditPharmacy.MouseEnter
        Security.Apply(Me.mnuFileEditPharmacy, AccessRights.Edit)
    End Sub

#End Region

#Region " File New Theatre Menu "

    Private Sub mnuFileNewTheatre_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewTheatre.MouseEnter
        Security.Apply(Me.mnuFileNewTheatre, AccessRights.Write)
    End Sub

    Private Sub mnuFileNewTheatreTheatreOperations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewTheatreTheatreOperations.Click
        Dim _form As Form = LoadChildForm(Me, New frmTheatreOperations())
        If Not _form Is Nothing Then DirectCast(_form, frmTheatreOperations).Save()
    End Sub

    Private Sub mnuFileNewTheatreIPDTheatreOperations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewTheatreIPDTheatreOperations.Click
        Dim _form As Form = LoadChildForm(Me, New frmIPDTheatreOperations())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDTheatreOperations).Save()
    End Sub

#End Region

#Region " File Edit Theatre Menu "

    Private Sub mnuFileEditTheatre_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditTheatre.MouseEnter
        Security.Apply(Me.mnuFileEditTheatre, AccessRights.Edit)
    End Sub

    Private Sub mnuFileEditTheatreTheatreOperations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditTheatreTheatreOperations.Click
        Dim _form As Form = LoadChildForm(Me, New frmTheatreOperations())
        If Not _form Is Nothing Then DirectCast(_form, frmTheatreOperations).Edit()
    End Sub

    Private Sub mnuFileEditTheatreIPDTheatreOperations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditTheatreIPDTheatreOperations.Click
        Dim _form As Form = LoadChildForm(Me, New frmIPDTheatreOperations())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDTheatreOperations).Edit()
    End Sub

#End Region

#Region " File New Dental Menu "

    Private Sub mnuFileNewDental_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewDental.MouseEnter
        Security.Apply(Me.mnuFileNewDental, AccessRights.Write)
    End Sub

    Private Sub mnuFileNewDentalDentalReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewDentalDentalReports.Click
        Dim _form As Form = LoadChildForm(Me, New frmDentalReports())
        If Not _form Is Nothing Then DirectCast(_form, frmDentalReports).Save()
    End Sub

    Private Sub mnuFileNewDentalIPDDentalReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewDentalIPDDentalReports.Click
        Dim _form As Form = LoadChildForm(Me, New frmIPDDentalReports())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDDentalReports).Save()
    End Sub

#End Region

#Region " File Edit Dental Menu "

    Private Sub mnuFileEditDental_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditDental.MouseEnter
        Security.Apply(Me.mnuFileEditDental, AccessRights.Edit)
    End Sub

    Private Sub mnuFileEditDentalDentalReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditDentalDentalReports.Click
        Dim _form As Form = LoadChildForm(Me, New frmDentalReports())
        If Not _form Is Nothing Then DirectCast(_form, frmDentalReports).Edit()
    End Sub

    Private Sub mnuFileEditDentalIPDDentalReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditDentalIPDDentalReports.Click
        Dim _form As Form = LoadChildForm(Me, New frmIPDDentalReports())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDDentalReports).Edit()
    End Sub

#End Region

#Region " File New In Patients Menu "

    Private Sub mnuFileNewInPatients_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewInPatients.MouseEnter
        Security.Apply(Me.mnuFileNewInPatients, AccessRights.Write)
    End Sub

    Private Sub mnuFileNewInPatientsAdmissions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewInPatientsAdmissions.Click
        Dim _form As Form = LoadChildForm(Me, New frmAdmissions())
        If Not _form Is Nothing Then DirectCast(_form, frmAdmissions).Save()
    End Sub

    Private Sub mnuFileNewInPatientsExtraBills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewInPatientsExtraBills.Click
          Dim oItemCategoryID As New SyncSoft.SQLDb.Lookup.LookupDataID.VisitTypeID()
        LoadChildForm(Me, New frmExtraBills(Nothing, oItemCategoryID.InPatient))
    End Sub

    Private Sub mnuFileNewInPatientsIPDDoctor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewInPatientsIPDDoctor.Click
        LoadChildForm(Me, New frmIPDDoctor())
    End Sub

    Private Sub mnuFileNewInPatientsIPDConsumables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewInPatientsIPDConsumables.Click
        LoadChildForm(Me, New frmIPDConsumables())
    End Sub

    Private Sub mnuFileNewInPatientsReturnedExtraBillItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewInPatientsReturnedExtraBillItems.Click
        LoadChildForm(Me, New frmBillAdjustments())
    End Sub

    Private Sub mnuFileNewInPatientsDischarges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewInPatientsDischarges.Click
        Dim _form As Form = LoadChildForm(Me, New frmDischarges())
        If Not _form Is Nothing Then DirectCast(_form, frmDischarges).Save()
    End Sub

#End Region

#Region " File Edit In Patients Menu "

    Private Sub mnuFileEditInPatients_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditInPatients.MouseEnter
        Security.Apply(Me.mnuFileEditInPatients, AccessRights.Edit)
    End Sub

    Private Sub mnuFileEditInPatientsAdmissions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditInPatientsAdmissions.Click
        Dim _form As Form = LoadChildForm(Me, New frmAdmissions())
        If Not _form Is Nothing Then DirectCast(_form, frmAdmissions).Edit()
    End Sub

    Private Sub mnuFileEditInPatientsExtraBills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditInPatientsExtraBills.Click
        Dim _form As Form = LoadChildForm(Me, New frmExtraBills())
        If Not _form Is Nothing Then DirectCast(_form, frmExtraBills).Edit()
    End Sub

    Private Sub mnuFileEditInPatientsDischarges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditInPatientsDischarges.Click
        Dim _form As Form = LoadChildForm(Me, New frmDischarges())
        If Not _form Is Nothing Then DirectCast(_form, frmDischarges).Edit()
    End Sub

#End Region

#Region " File New Manage ART Menu "

    Private Sub mnuFileNewManageART_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewManageART.MouseEnter
        Security.Apply(Me.mnuFileNewManageART, AccessRights.Write)
    End Sub

    Private Sub mnuFileNewManageARTARTRegimen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewManageARTARTRegimen.Click
        Dim _form As Form = LoadChildForm(Me, New frmARTRegimen())
        If Not _form Is Nothing Then DirectCast(_form, frmARTRegimen).Save()
    End Sub

    Private Sub mnuFileNewManageARTARTStopped_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNewManageARTARTStopped.Click
        Dim _form As Form = LoadChildForm(Me, New frmARTStopped())
        If Not _form Is Nothing Then DirectCast(_form, frmARTStopped).Save()
    End Sub

#End Region

#Region " File Edit Manage ART Menu "

    Private Sub mnuFileEditManageART_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditManageART.MouseEnter
        Security.Apply(Me.mnuFileEditManageART, AccessRights.Edit)
    End Sub

    Private Sub mnuFileEditManageARTARTRegimen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditManageARTARTRegimen.Click
        Dim _form As Form = LoadChildForm(Me, New frmARTRegimen())
        If Not _form Is Nothing Then DirectCast(_form, frmARTRegimen).Edit()
    End Sub

    Private Sub mnuFileEditManageARTARTStopped_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileEditManageARTARTStopped.Click
        Dim _form As Form = LoadChildForm(Me, New frmARTStopped())
        If Not _form Is Nothing Then DirectCast(_form, frmARTStopped).Edit()
    End Sub

#End Region

#End Region

#Region " Utilities  "

#Region " File "

    Private Sub mnuFileImport_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileImport.MouseEnter
        Security.Apply(Me.mnuFileImport, AccessRights.Write)
    End Sub

    Private Sub mnuFileImportLabResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileImportLabResults.Click
        LoadChildForm(Me, New frmImportLabResults())
    End Sub

    Private Sub mnuFileImportLabResultsEXT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileImportLabResultsEXT.Click
        LoadChildForm(Me, New frmImportLabResultsEXT())
    End Sub

    Private Sub mnuFileImportPatients_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileImportPatients.Click
        LoadChildForm(Me, New frmImportPatients())
    End Sub

    Private Sub mnuFileImportVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileImportVisits.Click
        LoadChildForm(Me, New frmImportVisits())
    End Sub

#End Region

#Region " Setup "

    Private Sub mnuSetupImport_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupImport.MouseEnter
        Security.Apply(Me.mnuSetupImport, AccessRights.Write)
    End Sub

    Private Sub mnuSetupImportDrugs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupImportDrugs.Click
        LoadChildForm(Me, New frmImportDrugs())
    End Sub

    Private Sub mnuSetupImportConsumableItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupImportConsumableItems.Click
        LoadChildForm(Me, New frmImportConsumableItems())
    End Sub

    Private Sub mnuSetupImportInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupImportInventory.Click
        LoadChildForm(Me, New frmImportInventory())
    End Sub

    Private Sub mnuSetupImportLabTests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupImportLabTests.Click
        LoadChildForm(Me, New frmImportLabTests())
    End Sub

    Private Sub mnuSetupImportLabTestsEXT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupImportLabTestsEXT.Click
        LoadChildForm(Me, New frmImportLabTestsEXT())
    End Sub

    Private Sub mnuSetupImportLabPossibleResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupImportLabPossibleResults.Click
        LoadChildForm(Me, New frmImportLabPossibleResults())
    End Sub

    Private Sub mnuSetupImportRadiologyExaminations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupImportRadiologyExaminations.Click
        LoadChildForm(Me, New frmImportRadiologyExaminations())
    End Sub

    Private Sub mnuSetupImportBillCustomers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupImportBillCustomers.Click
        LoadChildForm(Me, New frmImportBillCustomers())
    End Sub

    Private Sub mnuSetupImportBillCustomFee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupImportBillCustomFee.Click
        LoadChildForm(Me, New frmImportBillCustomFee())
    End Sub

    Private Sub mnuSetupImportInsuranceCustomFee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupImportInsuranceCustomFee.Click
        LoadChildForm(Me, New frmImportInsuranceCustomFee())
    End Sub

    Private Sub mnuSetupImportBillExcludedItems_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupImportBillExcludedItems.Click
        LoadChildForm(Me, New frmImportBillExcludedItems())
    End Sub

    Private Sub mnuSetupImportInsuranceExclusions_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupImportInsuranceExclusions.Click
        LoadChildForm(Me, New frmImportInsuranceExclusions())
    End Sub

    Private Sub mnuSetupImportInsuranceExcludedItems_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupImportInsuranceExcludedItems.Click
        LoadChildForm(Me, New frmImportInsuranceExcludedItems())
    End Sub

    Private Sub mnuSetupImportBillCustomerMembers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupImportBillCustomerMembers.Click
        LoadChildForm(Me, New frmImportBillCustomerMembers())
    End Sub

    Private Sub mnuSetupImportProcedures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupImportProcedures.Click
        LoadChildForm(Me, New frmImportProcedures())
    End Sub

    Private Sub mnuSetupImportDentalServices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupImportDentalServices.Click
        LoadChildForm(Me, New frmImportDentalServices())
    End Sub

    Private Sub mnuSetupImportDiseases_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupImportDiseases.Click
        LoadChildForm(Me, New frmImportDiseases())
    End Sub

    Private Sub mnuSetupImportSchemeMembers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetupImportSchemeMembers.Click
        LoadChildForm(Me, New frmImportSchemeMembers())
    End Sub

#End Region

#Region " Tools "

    Private Sub mnuToolsNewServerCredentials_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsNewServerCredentials.Click
        Dim _form As Form = LoadChildForm(Me, New SyncSoft.SQL.Win.Forms.ServerCredentials())
        If Not _form Is Nothing Then DirectCast(_form, SyncSoft.SQL.Win.Forms.ServerCredentials).Save()
    End Sub

    Private Sub mnuToolsEditServerCredentials_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsEditServerCredentials.Click
        Dim _form As Form = LoadChildForm(Me, New SyncSoft.SQL.Win.Forms.ServerCredentials())
        If Not _form Is Nothing Then DirectCast(_form, SyncSoft.SQL.Win.Forms.ServerCredentials).Edit()
    End Sub

    Private Sub mnuToolsNewTemplates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsNewTemplates.Click
        Dim _form As Form = LoadChildForm(Me, New frmTemplates())
        If Not _form Is Nothing Then DirectCast(_form, frmTemplates).Save()
    End Sub

    Private Sub mnuToolsEditTemplates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsEditTemplates.Click
        Dim _form As Form = LoadChildForm(Me, New frmTemplates())
        If Not _form Is Nothing Then DirectCast(_form, frmTemplates).Edit()
    End Sub

    Private Sub mnuToolsNewImportDataInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsNewImportDataInfo.Click
        Dim _form As Form = LoadChildForm(Me, New frmImportDataInfo())
        If Not _form Is Nothing Then DirectCast(_form, frmImportDataInfo).Save()
    End Sub

    Private Sub mnuToolsEditImportDataInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsEditImportDataInfo.Click
        Dim _form As Form = LoadChildForm(Me, New frmImportDataInfo())
        If Not _form Is Nothing Then DirectCast(_form, frmImportDataInfo).Edit()
    End Sub

#End Region

#End Region

#Region " Reports Menu "

    Private Sub mnuReportsPayments_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsPayments.MouseEnter
        Security.Apply(Me.mnuReportsPayments, AccessRights.Read)
    End Sub

    Private Sub mnuReportsInvoices_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsInvoices.MouseEnter
        Security.Apply(Me.mnuReportsInvoices, AccessRights.Read)
    End Sub

    Private Sub mnuReportsExtras_MouseEnter(sender As System.Object, e As System.EventArgs) Handles mnuReportsExtras.MouseEnter
        Security.Apply(Me.mnuReportsExtras, AccessRights.Read)
    End Sub

    Private Sub mnuReportsClaims_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsClaims.MouseEnter
        Security.Apply(Me.mnuReportsClaims, AccessRights.Read)
    End Sub

    Private Sub mnuReportsInventory_MouseEnter(sender As System.Object, e As System.EventArgs) Handles mnuReportsInventory.MouseEnter
        Security.Apply(Me.mnuReportsInventory, AccessRights.Read)
    End Sub

    Private Sub mnuReportsLineGraphs_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsLineGraphs.MouseEnter
        Security.Apply(Me.mnuReportsLineGraphs, AccessRights.Read)
    End Sub

    Private Sub mnuPaymentsCashCollections_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPaymentsCashCollections.Click
        LoadChildForm(Me, New frmCashCollections())
    End Sub

    Private Sub mnuReportsPaymentsCashReceipts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsPaymentsCashReceipts.Click
        LoadChildForm(Me, New frmPrintCashReceipts())
    End Sub

    Private Sub mnuReportsPaymentsDailyFinancialReport_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsPaymentsDailyFinancialReport.Click
        LoadChildForm(Me, New frmCashDailyReport())
    End Sub

    Private Sub mnuReportsInvoicesVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsInvoicesVisits.Click
        LoadChildForm(Me, New frmPrintVisitsInvoice(String.Empty))
    End Sub

    Private Sub mnuReportsInvoicesBillCustomers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsInvoicesBillCustomers.Click
        Dim oPayTypeID As New SyncSoft.SQLDb.Lookup.LookupDataID.PayTypeID()
        Dim _form As Form = LoadChildForm(Me, New frmPrintBillsInvoice())
        If Not _form Is Nothing Then DirectCast(_form, frmPrintBillsInvoice).BillState(oPayTypeID.AccountBill)
    End Sub

    Private Sub mnuReportsInvoicesInsurances_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsInvoicesInsurances.Click
        Dim oPayTypeID As New SyncSoft.SQLDb.Lookup.LookupDataID.PayTypeID()
        Dim _form As Form = LoadChildForm(Me, New frmPrintBillsInvoice())
        If Not _form Is Nothing Then DirectCast(_form, frmPrintBillsInvoice).BillState(oPayTypeID.InsuranceBill)
    End Sub

    Private Sub mnuReportsInvoicesExtraBills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsInvoicesExtraBills.Click
        LoadChildForm(Me, New frmPrintExtraBillsInvoice())
    End Sub

    Private Sub mnuReportsExtrasInventoryAcknowledges_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsExtrasInventoryAcknowledges.Click
        LoadChildForm(Me, New frmPrintInventoryAcknowledges())
    End Sub

    Private Sub mnuReportsExtrasGoodsReceivedNote_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsExtrasGoodsReceivedNote.Click
        LoadChildForm(Me, New frmPrintGoodsReceivedNotes())
    End Sub


    Private Sub mnuReportsRadiologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsRadiologyReports.Click
        LoadChildForm(Me, New frmPrintRadiologyReports())
    End Sub

    Private Sub mnuReportsIPDRadiologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsIPDRadiologyReports.Click
        LoadChildForm(Me, New frmPrintIPDRadiologyReports())
    End Sub

    Private Sub mnuReportsClaimsBillCustomersClaimForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsClaimsBillCustomersClaimForm.Click
        LoadChildForm(Me, New frmPrintBillCustomersClaims())
    End Sub

    Private Sub mnuReportsClaimsInsuranceClaimForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsClaimsInsuranceClaimForm.Click
        LoadChildForm(Me, New frmPrintInsuranceClaims())
    End Sub

    Private Sub mnuReportsClaimsInsuranceClaimSummaries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsClaimsInsuranceClaimSummaries.Click
        LoadChildForm(Me, New frmInsuranceClaimSummaries())
    End Sub



    Private Sub mnuReportsIncomeSummaries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsIncomeSummaries.Click
        LoadChildForm(Me, New frmIncomeSummaries())
    End Sub

    Private Sub mnuReportsIPDIncomeSummaries_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsIPDIncomeSummaries.Click
        LoadChildForm(Me, New frmIPDIncomeSummaries())
    End Sub

    Private Sub mnuReportsInventoryDrugStockCard_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsInventoryDrugStockCard.Click
        Dim oItemCategoryID As New SyncSoft.SQLDb.Lookup.LookupDataID.ItemCategoryID()
        LoadChildForm(Me, New frmStockCard(oItemCategoryID.Drug))
    End Sub

    Private Sub mnuReportsInventoryConsumableStockCard_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsInventoryConsumableStockCard.Click
        Dim oItemCategoryID As New SyncSoft.SQLDb.Lookup.LookupDataID.ItemCategoryID()
        LoadChildForm(Me, New frmStockCard(oItemCategoryID.Consumable))
    End Sub

    Private Sub mnuReportsInventoryDrugInventorySummaries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsInventoryDrugInventorySummaries.Click
        LoadChildForm(Me, New frmDrugInventorySummaries())
    End Sub

    Private Sub mnuReportsInventoryConsumableInventorySummaries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsInventoryConsumableInventorySummaries.Click
        LoadChildForm(Me, New frmConsumableInventorySummaries())
    End Sub


    Private Sub mnuReportsLineGraphsLabResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportsLineGraphsLabResults.Click
        LoadChildForm(Me, New frmGraphLabResults())
    End Sub

    Private Sub mnuReportsGeneralAppointments_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsGeneralAppointments.Click
        LoadChildForm(Me, New frmReportAppointments())
    End Sub

#End Region

#Region " ToolStrip "

    Private Sub bmiExtrasNew_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiExtrasNew.MouseEnter
        Security.Apply(Me.bmiExtrasNew, AccessRights.Write)
    End Sub

    Private Sub bmiExtrasEdit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiExtrasEdit.MouseEnter
        Security.Apply(Me.bmiExtrasEdit, AccessRights.Edit)
    End Sub

    Private Sub bmiInvoicesNew_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiInvoicesNew.MouseEnter
        Security.Apply(Me.bmiInvoicesNew, AccessRights.Write)
    End Sub


    Private Sub bmiTriageNew_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiTriageNew.MouseEnter
        Security.Apply(Me.bmiTriageNew, AccessRights.Write)
    End Sub

    Private Sub bmiTriageEdit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiTriageEdit.MouseEnter
        Security.Apply(Me.bmiTriageEdit, AccessRights.Edit)
    End Sub

    Private Sub bmiLaboratoryNew_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiLaboratoryNew.MouseEnter
        Security.Apply(Me.bmiLaboratoryNew, AccessRights.Write)
    End Sub

    Private Sub bmiLaboratoryEdit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiLaboratoryEdit.MouseEnter
        Security.Apply(Me.bmiLaboratoryEdit, AccessRights.Edit)
    End Sub

    Private Sub bmiRadiologyNew_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiRadiologyNew.MouseEnter
        Security.Apply(Me.bmiRadiologyNew, AccessRights.Write)
    End Sub

    Private Sub bmiRadiologyEdit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiRadiologyEdit.MouseEnter
        Security.Apply(Me.bmiRadiologyEdit, AccessRights.Edit)
    End Sub

    Private Sub bmiTheatreNew_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiTheatreNew.MouseEnter
        Security.Apply(Me.bmiTheatreNew, AccessRights.Write)
    End Sub

    Private Sub bmiTheatreEdit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiTheatreEdit.MouseEnter
        Security.Apply(Me.bmiTheatreEdit, AccessRights.Edit)
    End Sub

    Private Sub bmiDentalNew_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiDentalNew.MouseEnter
        Security.Apply(Me.bmiDentalNew, AccessRights.Write)
    End Sub

    Private Sub bmiDentalEdit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiDentalEdit.MouseEnter
        Security.Apply(Me.bmiDentalEdit, AccessRights.Edit)
    End Sub

    Private Sub bmiInPatientsNew_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiInPatientsNew.MouseEnter
        Security.Apply(Me.bmiInPatientsNew, AccessRights.Write)
    End Sub

    Private Sub bmiInPatientsEdit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiInPatientsEdit.MouseEnter
        Security.Apply(Me.bmiInPatientsEdit, AccessRights.Edit)
    End Sub

    Private Sub bmiManageARTNew_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiManageARTNew.MouseEnter
        Security.Apply(Me.bmiManageARTNew, AccessRights.Write)
    End Sub

    Private Sub bmiManageARTEdit_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiManageARTEdit.MouseEnter
        Security.Apply(Me.bmiManageARTEdit, AccessRights.Edit)
    End Sub

    Private Sub bmiCardiologyNew_MouseEnter(sender As System.Object, e As System.EventArgs) Handles bmiCardiologyNew.MouseEnter
        Security.Apply(Me.bmiCardiologyNew, AccessRights.Write)
    End Sub

    Private Sub bmiCardiologyEdit_MouseEnter(sender As System.Object, e As System.EventArgs) Handles bmiCardiologyEdit.MouseEnter
        Security.Apply(Me.bmiCardiologyEdit, AccessRights.Edit)
    End Sub



    Private Sub bmiPatientsNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiPatientsNew.Click

        If Not oVariousOptions.EnableSecondPatientForm Then
            Me.mnuFileNewPatients_Click(Me, EventArgs.Empty)
        Else
            Dim _form As Form = LoadChildForm(Me, New frmPatientsTwo())
            If Not _form Is Nothing Then DirectCast(_form, frmPatientsTwo).Save()
        End If
    End Sub

    Private Sub bmiPatientsEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiPatientsEdit.Click
        If Not oVariousOptions.EnableSecondPatientForm Then
            Me.mnuFileEditPatients_Click(Me, EventArgs.Empty)
        Else
            Dim _form As Form = LoadChildForm(Me, New frmPatientsTwo())
            If Not _form Is Nothing Then DirectCast(_form, frmPatientsTwo).Edit()
        End If
    End Sub

    Private Sub bmiVisitsNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiVisitsNew.Click
        Me.mnuFileNewVisits_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiVisitsEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiVisitsEdit.Click
        Me.mnuFileEditVisits_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiTriageNewTriage_Click(sender As System.Object, e As System.EventArgs) Handles bmiTriageNewTriage.Click
        Me.mnuFileNewTriageTriage_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiTriageEditTriage_Click(sender As System.Object, e As System.EventArgs) Handles bmiTriageEditTriage.Click
        Me.mnuFileEditTriageTriage_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiTriageNewVisionAssessment_Click(sender As System.Object, e As System.EventArgs) Handles bmiTriageNewVisionAssessment.Click
        Me.mnuFileNewTriageVisionAssessment_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiTriageEditVisionAssessment_Click(sender As System.Object, e As System.EventArgs) Handles bmiTriageEditVisionAssessment.Click
        mnuFileEditTriageVisionAssessment_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiTriageNewIPDVisionAssessment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiTriageNewIPDVisionAssessment.Click
        mnuFileNewTriageIPDVisionAssessment_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiTriageEditIPDVisionAssessment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiTriageEditIPDVisionAssessment.Click
        mnuFileEditTriageIPDVisionAssessment_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasNewSelfRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiExtrasNewSelfRequests.Click
        Me.mnuFileNewExtrasSelfRequests_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasEditSelfRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiExtrasEditSelfRequests.Click
        Me.mnuFileEditSelfRequests_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasNewClaims_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiExtrasNewClaims.Click
        Me.mnuFileNewExtrasClaims_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasEditClaims_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiExtrasEditClaims.Click
        Me.mnuFileEditExtrasClaims_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasNewQuotations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.mnuFileNewExtrasQuotations_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasEditQuotations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.mnuFileEditQuotations_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasNewPurchaseOrders_Click(sender As System.Object, e As System.EventArgs)
        Me.mnuFileNewExtrasPurchaseOrders_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasEditPurchaseOrders_Click(sender As System.Object, e As System.EventArgs)
        Me.mnuFileEditExtrasPurchaseOrders_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasNewInventoryOrders_Click(sender As System.Object, e As System.EventArgs)
        Me.mnuFileNewExtrasInventoryOrders_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasEditInventoryOrders_Click(sender As System.Object, e As System.EventArgs)
        Me.mnuFileEditExtrasInventoryOrders_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasNewInventoryTransfers_Click(sender As System.Object, e As System.EventArgs)
        Me.mnuFileNewExtrasInventoryTransfers_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasEditInventoryTransfers_Click(sender As System.Object, e As System.EventArgs)
        Me.mnuFileEditExtrasInventoryTransfers_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasNewOutwardFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiExtrasNewOutwardFiles.Click
        Me.mnuFileNewExtrasOutwardFiles_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasEditOutwardFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiExtrasEditOutwardFiles.Click
        Me.mnuFileEditExtrasOutwardFiles_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasNewInwardFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiExtrasNewInwardFiles.Click
        Me.mnuFileNewExtrasInwardFiles_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasNewResearchRoutingForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiExtrasNewResearchRoutingForm.Click
        Me.mnuFileNewExtrasResearchRoutingForm_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasNewEnrollmentInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiExtrasNewEnrollmentInformation.Click
        Me.mnuFileNewExtrasEnrollmentInformation_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasNewExternalReferralForm_Click(sender As Object, e As EventArgs) Handles bmiExtrasNewExternalReferralForm.Click
        Me.mnuFileNewExternalReferralForm_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasEditInwardFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiExtrasEditInwardFiles.Click
        Me.mnuFileEditExtrasInwardFiles_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasNewSmartCardAuthorisations_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasNewSmartCardAuthorisations.Click
        Me.mnuFileNewExtrasSmartCardAuthorisations_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasEditSmartCardAuthorisations_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasEditSmartCardAuthorisations.Click
        Me.mnuFileEditExtrasSmartCardAuthorisations_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasEditResearchRoutingForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiExtrasEditResearchRoutingForm.Click
        Me.mnuFileEditExtrasResearchRoutingForm_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasEditResearchEnrollmentInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiExtrasEditResearchEnrollmentInformation.Click
        Me.mnuFileEditExtrasResearchEnrollmentInformation_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiExtrasEditExternalReferralForm_Click(sender As Object, e As EventArgs) Handles bmiExtrasEditExternalReferralForm.Click
        Me.mnuFileEditExtrasExternalReferralForm_Click(Me, EventArgs.Empty)
    End Sub


    Private Sub bmiExtrasExtraCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiExtrasExtraCharge.Click
        Me.mnuFileNewExtrasExtraCharge_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub mnuExtraAttachPackage_Click(sender As System.Object, e As System.EventArgs) Handles mnuExtraAttachPackage.Click
        Dim _form As Form = LoadChildForm(Me, New frmAttachPackage())
        If Not _form Is Nothing Then DirectCast(_form, frmAttachPackage).Save()
    End Sub

    Private Sub bmiExtrasVisitFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiExtrasVisitFiles.Click
        Me.mnuFileNewExtrasVisitFiles_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiCancerDiagnosis_Click(sender As System.Object, e As System.EventArgs) Handles bmiCancerDiagnosis.Click
        mnuFileNewExtrasCancerDiagnosis_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiHCTClientCard_Click(sender As System.Object, e As System.EventArgs) Handles bmiHCTClientCard.Click
        mnuFileNewHCTClientCard_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiPreviousPrescriptions_Click(sender As System.Object, e As System.EventArgs) Handles bmiPreviousPrescriptions.Click
        LoadChildForm(Me, New frmPreviousPrescriptions())
    End Sub

    Private Sub bmiDrugAdministration_Click(sender As System.Object, e As System.EventArgs) Handles bmiDrugAdministration.Click
        Dim _form As Form = LoadChildForm(Me, New frmDrugAdministration())
        If Not _form Is Nothing Then DirectCast(_form, frmDrugAdministration).Save()
    End Sub

    Private Sub bmiExtrasAccessCashServices_Click(sender As Object, e As EventArgs) Handles bmiExtrasAccessCashServices.Click
        Dim _form As Form = LoadChildForm(Me, New frmAccessedCashServices())
        If Not _form Is Nothing Then DirectCast(_form, frmAccessedCashServices).Save()
    End Sub

    Private Sub mnuFileNewExtrasCancerDiagnosis_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileNewExtrasCancerDiagnosis.Click
        LoadChildForm(Me, New frmCancerDiagnosis())
    End Sub

    Private Sub mnuFileNewHCTClientCard_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileNewHCTClientCard.Click
        LoadChildForm(Me, New frmHCTClientCard())
    End Sub

    Private Sub bmiInvoicesNewInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiInvoicesNewInvoices.Click
        Me.mnuFileNewInvoicesInvoices_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInvoicesEditInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.mnuFileEditInvoicesInvoices_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInvoicesNewIPDInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiInvoicesNewIPDInvoices.Click
        Me.mnuFileNewInvoicesIPDInvoices_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInvoicesEditIPDInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.mnuFileEditInvoicesIPDInvoices_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiLaboratoryNewLabRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiLaboratoryNewLabRequests.Click
        Me.mnuFileNewLaboratoryLabRequests_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiLaboratoryEditLabRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiLaboratoryEditLabRequests.Click
        Me.mnuFileEditLaboratoryLabRequests_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiLaboratoryNewLabResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiLaboratoryNewLabResults.Click
        Me.mnuFileNewLaboratoryLabResults_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiLaboratoryEditLabResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiLaboratoryEditLabResults.Click
        Me.mnuFileEditLaboratoryLabResults_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiLaboratoryNewIPDLabRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiLaboratoryNewIPDLabRequests.Click
        Me.mnuFileNewLaboratoryIPDLabRequests_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiLaboratoryEditIPDLabRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiLaboratoryEditIPDLabRequests.Click
        Me.mnuFileEditLaboratoryIPDLabRequests_Click(Me, EventArgs.Empty)
    End Sub


    Private Sub bmiRadiologyNewRadiologyRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiRadiologyNewRadiologyRequests.Click
        Me.mnuFileNewRadiologyRadiologyRequests_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiRadiologyNewRadiologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiRadiologyNewRadiologyReports.Click
        Me.mnuFileNewRadiologyRadiologyReports_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiRadiologyEditRadiologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiRadiologyEditRadiologyReports.Click
        Me.mnuFileEditRadiologyRadiologyReports_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiRadiologyNewIPDRadiologyRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiRadiologyNewIPDRadiologyRequests.Click
        Me.mnuFileNewRadiologyIPDRadiologyRequests_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiRadiologyNewIPDRadiologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiRadiologyNewIPDRadiologyReports.Click
        Me.mnuFileNewRadiologyIPDRadiologyReports_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiRadiologyEditIPDRadiologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiRadiologyEditIPDRadiologyReports.Click
        Me.mnuFileEditRadiologyIPDRadiologyReports_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiPharmacyDispense_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiPharmacyDispense.Click
        Me.mnuFileNewPharmacyDispense_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiIPDPharmacyDispense_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiIPDPharmacyDispense.Click
        Me.mnuFileNewPharmacyIPDDispense_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiPharmacyIssueConsumables_Click(sender As System.Object, e As System.EventArgs) Handles bmiPharmacyIssueConsumables.Click
        Me.mnuFileNewPharmacyIssueConsumables_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiPharmacyIssueIPDConsumables_Click(sender As System.Object, e As System.EventArgs) Handles bmiPharmacyIssueIPDConsumables.Click
        Me.mnuFileNewPharmacyIssueIPDConsumables_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiTheatreNewTheatreOperations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiTheatreNewTheatreOperations.Click
        Me.mnuFileNewTheatreTheatreOperations_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiTheatreEditTheatreOperations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiTheatreEditTheatreOperations.Click
        Me.mnuFileEditTheatreTheatreOperations_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiTheatreNewIPDTheatreOperations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiTheatreNewIPDTheatreOperations.Click
        Me.mnuFileNewTheatreIPDTheatreOperations_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiTheatreEditIPDTheatreOperations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiTheatreEditIPDTheatreOperations.Click
        Me.mnuFileEditTheatreIPDTheatreOperations_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiDentalNewDentalReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiDentalNewDentalReports.Click
        Me.mnuFileNewDentalDentalReports_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiDentalEditDentalReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiDentalEditDentalReports.Click
        Me.mnuFileEditDentalDentalReports_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiDentalNewIPDDentalReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiDentalNewIPDDentalReports.Click
        Me.mnuFileNewDentalIPDDentalReports_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiDentalEditIPDDentalReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiDentalEditIPDDentalReports.Click
        Me.mnuFileEditDentalIPDDentalReports_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiAppointmentsNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiAppointmentsNew.Click
        Me.mnuFileNewAppointments_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiAppointmentsEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiAppointmentsEdit.Click
        Me.mnuFileEditAppointments_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInPatientsNewAdmissions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiInPatientsNewAdmissions.Click
        Me.mnuFileNewInPatientsAdmissions_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInPatientsEditAdmissions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiInPatientsEditAdmissions.Click
        Me.mnuFileEditInPatientsAdmissions_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInPatientsNewExtraBills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiInPatientsNewExtraBills.Click
        Me.mnuFileNewInPatientsExtraBills_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiNewOPDExtraBills_Click(sender As System.Object, e As System.EventArgs) Handles bmiNewOPDExtraBills.Click
        Dim oItemCategoryID As New SyncSoft.SQLDb.Lookup.LookupDataID.VisitTypeID()
        LoadChildForm(Me, New frmExtraBills(Nothing, oItemCategoryID.OutPatient))
    End Sub

    Private Sub bmiInPatientsNewDischarges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiInPatientsNewDischarges.Click
        Me.mnuFileNewInPatientsDischarges_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInPatientsEditDischarges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiInPatientsEditDischarges.Click
        Me.mnuFileEditInPatientsDischarges_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInPatientsIPDDoctor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiInPatientsIPDDoctor.Click
        Me.mnuFileNewInPatientsIPDDoctor_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInPatientsIPDConsumables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiInPatientsIPDConsumables.Click
        Me.mnuFileNewInPatientsIPDConsumables_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInPatientsReturnedExtraBillItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiInPatientsBillAdjustments.Click
        Me.mnuFileNewInPatientsReturnedExtraBillItems_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiManageARTNewARTRegimen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiManageARTNewARTRegimen.Click
        Me.mnuFileNewManageARTARTRegimen_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiManageARTEditARTRegimen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiManageARTEditARTRegimen.Click
        Me.mnuFileEditManageARTARTRegimen_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiManageARTNewARTStopped_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiManageARTNewARTStopped.Click
        Me.mnuFileNewManageARTARTStopped_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiManageARTEditARTStopped_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiManageARTEditARTStopped.Click
        Me.mnuFileEditManageARTARTStopped_Click(Me, EventArgs.Empty)
    End Sub


    Private Sub bmiCardiologyNewCardiologyRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiCardiologyNewCardiologyRequests.Click
        Me.mnuFileNewCardiologyCardiologyRequests_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiCardiologyNewCardiologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiCardiologyNewCardiologyReports.Click
        Me.mnuFileNewCardiologyCardiologyReports_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiCardiologyEditCardiologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiCardiologyEditCardiologyReports.Click
        Me.mnuFileEditCardiologyCardiologyReports_Click(Me, EventArgs.Empty)
    End Sub




    Private Sub bmiPathologyNewPathologyRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiPathologyNewPathologyRequests.Click
        Me.mnuFileNewPathologyPathologyRequests_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiPathologyNewPathologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiPathologyNewPathologyReports.Click
        Me.mnuFileNewPathologyPathologyReports_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiRadiologyEditPathologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiPathologyEditPathologyReports.Click
        Me.mnuFileEditPathologyPathologyReports_Click(Me, EventArgs.Empty)
    End Sub



    Private Sub bmiDeathsNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiDeathsNew.Click
        Me.mnuFileNewDeaths_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiDeathsEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bmiDeathsEdit.Click
        Me.mnuFileEditDeaths_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub tlbMain_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tlbMain.ItemClicked

        Select Case e.ClickedItem.Name

            Case Me.tbbCashier.Name
                Me.mnuFileNewCashier_Click(Me, Nothing)

            Case Me.tbbDoctor.Name
                Me.mnuFileNewDoctor_Click(Me, Nothing)

        End Select

    End Sub


#End Region

#Region "Inventory"

    Private Sub bmiPharmacyDrugInventory_Click(sender As System.Object, e As System.EventArgs) Handles bmiPharmacyDrugInventory.Click
        Me.mnuFileNewPharmacyDrugInventory_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiPharmacyConsumableInventory_Click(sender As System.Object, e As System.EventArgs) Handles bmiPharmacyConsumableInventory.Click
        Me.mnuFileNewExtrasConsumableInventory_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInventoryDeliveryNote_Click(sender As System.Object, e As System.EventArgs) Handles bmiInventoryDeliveryNote.Click
        Dim _form As Form = LoadChildForm(Me, New frmDeliveryNote())
        If Not _form Is Nothing Then DirectCast(_form, frmDeliveryNote).Save()
    End Sub

    Private Sub bmiInventoryConsumables_Click(sender As System.Object, e As System.EventArgs) Handles bmiInventoryConsumables.Click
        Me.mnuFileNewExtrasConsumables_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInventoryGoodsReceived_Click(sender As System.Object, e As System.EventArgs) Handles bmiInventoryGoodsReceived.Click
        Me.mnuFileNewExtrasGoodsReceivedNote_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInventoryGoodsReturned_Click(sender As System.Object, e As System.EventArgs) Handles bmiInventoryGoodsReturned.Click
        LoadChildForm(Me, New frmGoodsReturnedNote())
    End Sub

    Private Sub bmiinventoryInventoryAcknowledges_Click(sender As System.Object, e As System.EventArgs) Handles bmiinventoryInventoryAcknowledges.Click
        Me.mnuFileNewExtrasInventoryAcknowledges_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiinventoryProcessInventoryOrders_Click(sender As System.Object, e As System.EventArgs) Handles bmiinventoryProcessInventoryOrders.Click
        Me.mnuFileNewExtrasProcessInventoryOrders_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bminventoryDrugStockCard_Click(sender As System.Object, e As System.EventArgs) Handles bminventoryDrugStockCard.Click
        Me.mnuReportsInventoryDrugStockCard_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInventoryConsumableStockCard_Click(sender As System.Object, e As System.EventArgs) Handles bmiInventoryConsumableStockCard.Click
        Me.mnuReportsInventoryConsumableStockCard_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInventoryDrugInventorySummaries_Click(sender As System.Object, e As System.EventArgs) Handles bmiInventoryDrugInventorySummaries.Click
        Me.mnuReportsInventoryDrugInventorySummaries_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInventoryConsumableInventorySummaries_Click(sender As System.Object, e As System.EventArgs) Handles bmiInventoryConsumableInventorySummaries.Click
        Me.mnuReportsInventoryConsumableInventorySummaries_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInventoryPhysicalStockCountReport_Click(sender As System.Object, e As System.EventArgs) Handles bmiInventoryPhysicalStockCountReport.Click
        Me.mnuReportsExtrasPhysicalStockCount_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiNewInventoryQuotation_Click(sender As System.Object, e As System.EventArgs) Handles bmiNewInventoryQuotation.Click
        Me.mnuFileNewExtrasQuotations_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiEditInventoryQuotation_Click(sender As System.Object, e As System.EventArgs) Handles bmiEditInventoryQuotation.Click
        Me.mnuFileEditQuotations_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiEditInventoryPurchaseOrders_Click(sender As System.Object, e As System.EventArgs) Handles bmiEditInventoryPurchaseOrders.Click
        Me.mnuFileEditExtrasPurchaseOrders_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiEditInventoryInventoryOrders_Click(sender As System.Object, e As System.EventArgs) Handles bmiEditInventoryInventoryOrders.Click
        Me.mnuFileEditExtrasInventoryOrders_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInventoryEditInventoryTransfers_Click(sender As System.Object, e As System.EventArgs) Handles bmiInventoryEditInventoryTransfers.Click
        Me.mnuFileEditExtrasInventoryTransfers_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiNewInventoryPurchaseOrders_Click(sender As System.Object, e As System.EventArgs) Handles bmiNewInventoryPurchaseOrders.Click
        Me.mnuFileNewExtrasPurchaseOrders_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiNewInventoryInventoryOrders_Click(sender As System.Object, e As System.EventArgs) Handles bmiNewInventoryInventoryOrders.Click
        Me.mnuFileNewExtrasInventoryOrders_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInventoryNewInventoryTransfers_Click(sender As System.Object, e As System.EventArgs) Handles bmiInventoryNewInventoryTransfers.Click
        Me.mnuFileNewExtrasInventoryTransfers_Click(Me, EventArgs.Empty)
    End Sub

    Private Sub bmiInventoryAcknowledgeReturnsAcknowledgeBillFormReturns_Click(sender As System.Object, e As System.EventArgs) Handles bmiInventoryAcknowledgeReturnsAcknowledgeBillFormReturns.Click
        LoadChildForm(Me, New frmAcknowledgeBillReturns(True))
    End Sub

    Private Sub bmiInventoryAcknowledgeReturnsAcknowledgeOPDReturns_Click(sender As System.Object, e As System.EventArgs) Handles bmiInventoryAcknowledgeReturnsAcknowledgeOPDReturns.Click
        LoadChildForm(Me, New frmAcknowledgeBillReturns(False))
    End Sub


#End Region

#Region "Finances"

    Private Sub ddbFinancesAccessCashServices_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesAccessCashServices.Click
        Me.bmiExtrasAccessCashServices_Click(Me, EventArgs.Empty)
    End Sub


    Private Sub ddbFinancesCashier_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesCashier.Click
        Me.mnuFileNewCashier_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesRefundsRequest_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesRefundsRequest.Click
        Me.mnuExtrasRefundsRequests_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesRefundsApproval_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesRefundsApproval.Click
        Me.mnuExtrasRefundApprovals_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesClaimPaymentsClaimPayments_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesClaimPaymentsClaimPayments.Click
        Me.ClaimPaymentsToolStripMenuItem1_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesClaimPaymentsClaimPaymentDetailed_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesClaimPaymentsClaimPaymentDetailed.Click
        Me.ClaimPaymentDetailedToolStripMenuItem_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesStaffPaymentApprovals_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesStaffPaymentApprovals.Click

        Security.Apply(Me.ddbFinancesStaffPaymentApprovals, AccessRights.Write)

        Me.StaffPaymentApprovalsToolStripMenuItem_Click(Me, Nothing)

    End Sub

    Private Sub ddbFinancesStaffPaymentsOPDStaffPayments_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesStaffPaymentsOPDStaffPayments.Click
        Me.OPDStaffPaymentsToolStripMenuItem_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesStaffPaymentsPaymentApprovalsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesStaffPaymentsPaymentApprovalsToolStripMenuItem.Click
        Me.StaffPaymentApprovalsToolStripMenuItem_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesStaffPaymentsIPDStaffPayments_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesStaffPaymentsIPDStaffPayments.Click
        Me.IPDStaffPaymentsToolStripMenuItem_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesCreditNote_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesInvoiceAdjustments.Click
        Me.bmiInvoicesCreditNote_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesAccountStatement_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesAccountStatement.Click
        Me.mnuReportsPaymentsPatientsAccountStatement_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesDetailedAccountStatement_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesDetailedAccountStatement.Click
        Me.mniReportdDetailedAccountStatement_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesBankingNewBankAccount_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesBankingNewBankAccount.Click
        Me.nmnSetUpNewBankAccounts_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesBankingRegister_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesBankingRegister.Click
        Me.mnToolsBankingRegiser_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesBankingReport_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesBankingReport.Click
        Me.mnReportsBankingRegister_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesIncomeCashCollections_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesIncomeCashCollections.Click
        Me.mnuPaymentsCashCollections_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesOPDIncomeSummaries_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesOPDIncomeSummaries.Click
        Me.mnuReportsIncomeSummaries_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesIPDIncomeSummaries_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesIPDIncomeSummaries.Click
        Me.mnuReportsIPDIncomeSummaries_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesClaimsToBillCustomersClaimForm_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesClaimsToBillCustomersClaimForm.Click
        Me.mnuReportsClaimsBillCustomersClaimForm_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesClaimsInsuranceClaimForm_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesClaimsInsuranceClaimForm.Click
        Me.mnuReportsClaimsInsuranceClaimForm_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesInsuranceClaimSummaries_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesInsuranceClaimSummaries.Click
        Me.mnuReportsClaimsInsuranceClaimSummaries_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesInvoicesVisits_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesInvoicesVisits.Click
        Me.mnuReportsInvoicesVisits_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesInvoicesToBillCustomers_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesInvoicesToBillCustomers.Click
        Me.mnuReportsInvoicesBillCustomers_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesInvoicesInsurances_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesInvoicesInsurances.Click
        Me.mnuReportsInvoicesInsurances_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesInvoicesBillingForm_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesInvoicesBillingForm.Click
        Me.mnuReportsInvoicesExtraBills_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesInvoicesInvoiceCategorisation_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesInvoicesInvoiceCategorisation.Click
        Me.mnuReportInvoicesInvoiceCategorisation_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesSuspenseAccount_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesSuspenseAccount.Click
        Me.MnuToolsSuspenseAccount_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesInventoryDrugInventorySummaries_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesInventoryDrugInventorySummaries.Click
        Me.mnuReportsInventoryDrugInventorySummaries_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesInventoryConsumableInventorySummaries_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesInventoryConsumableInventorySummaries.Click
        Me.mnuReportsInventoryConsumableInventorySummaries_Click(Me, Nothing)
    End Sub


    Private Sub ddbFinancesNewAsse_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesNewAsse.Click
        Me.bmiExtrasNewAssetsRegister_Click(Me, Nothing)
    End Sub

    Private Sub ddbFinancesAssetMaintenanceLog_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesAssetMaintenanceLog.Click
        Me.bmiExtrasNewAssetMaintainanceLog_Click(Me, Nothing)
    End Sub

#End Region



    Private Sub mnuReportsPaymentsPatientsAccountStatement_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsPaymentsPatientsAccountStatement.Click
        LoadChildForm(Me, New frmPatientAccountStatement())
    End Sub

    Private Sub MnuToolsBulkSMS_Click(sender As System.Object, e As System.EventArgs) Handles MnuToolsBulkSMS.Click
        Dim _form As Form = LoadChildForm(Me, New frmBulkMessaging())
        If Not _form Is Nothing Then DirectCast(_form, frmBulkMessaging).Save()
    End Sub

    Private Sub mnuMessenger_Click(sender As System.Object, e As System.EventArgs) Handles mnuMessenger.Click
        Dim _form As Form = LoadChildForm(Me, New frmMessenger())
        If Not _form Is Nothing Then DirectCast(_form, frmMessenger).Save()
    End Sub

#Region "Notifications"

    Private Sub ShowUnreadMessageAlerts()
        Dim unread As DataTable
        Dim oMessenger As New SyncSoft.SQLDb.Messenger

        Try
            Me.Cursor = Cursors.WaitCursor
            If InitOptions.EnableChatNotification Then
                unread = oMessenger.GetUnreadMessages(CurrentUser.LoginID).Tables("Messenger")

                Dim alertsNo As Integer = unread.Rows.Count
                If alertsNo > 0 Then If InitOptions.AlertSoundOn Then Beep()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.mnuMessenger.Text = "Chat" + "(" + alertsNo.ToString() + ")"

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else
                Me.mnuMessenger.Text = "Chat"
            End If
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



    Private Sub tmrSMSNotifications_Tick(sender As System.Object, e As System.EventArgs) Handles tmrSMSNotifications.Tick
        Me.ShowUnreadMessageAlerts()

        Dim oMyDefaultPCID As New LookupDataID.MyDefaultPC()
        Dim defaultpc As String = GetLookupDataDes(oMyDefaultPCID.DefaultPC)
        Try

            LoadTimelySMSIncomeSummaries()

            ShowUnreadMessageAlerts()
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

#End Region


    Private Sub mnuSetupNewConsumableBarCode_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupNewConsumableBarCode.Click
        Dim oItemCategoryID As New SyncSoft.SQLDb.Lookup.LookupDataID.ItemCategoryID()
        LoadChildForm(Me, New frmBarCodeDetails(oItemCategoryID.Consumable))
    End Sub

    Private Sub mnuSetupDrugBarcodes_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupDrugBarcodes.Click
        Dim oItemCategoryID As New SyncSoft.SQLDb.Lookup.LookupDataID.ItemCategoryID()
        LoadChildForm(Me, New frmBarCodeDetails(oItemCategoryID.Drug))
    End Sub

    Private Sub mnuReportsGeneralOperations_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsGeneralOperations.Click
        LoadChildForm(Me, New frmReportOperations())
    End Sub

    Private Sub mnuReportSales_Click(sender As System.Object, e As System.EventArgs)
        LoadChildForm(Me, New frmSales())
    End Sub

    Private Sub bmiInPatientsIPDNurse_Click(sender As Object, e As EventArgs) Handles bmiInPatientsIPDNurse.Click
        LoadChildForm(Me, New frmIPDNurse)
    End Sub

    Private Sub mnuHelpEULA_Click(sender As System.Object, e As System.EventArgs) Handles mnuHelpEULA.Click
        LoadChildForm(Me, New frmEULA)
    End Sub

    Private Sub mnuReportsExtrasPhysicalStockCount_Click(sender As Object, e As EventArgs) Handles mnuReportsExtrasPhysicalStockCount.Click
        LoadChildForm(Me, New frmPhysicalStockCountReport)
    End Sub

    Private Sub mnToolsBankingRegiser_Click(sender As Object, e As EventArgs) Handles mnToolsBankingRegiser.Click
        Dim _form As Form = LoadChildForm(Me, New frmBankingRegister())
        If Not _form Is Nothing Then DirectCast(_form, frmBankingRegister).Save()
    End Sub

    Private Sub nmnSetUpNewBankAccounts_Click(sender As Object, e As EventArgs) Handles mnSetUpNewBankAccounts.Click
        Dim _form As Form = LoadChildForm(Me, New frmBankAccounts())
        If Not _form Is Nothing Then DirectCast(_form, frmBankAccounts).Save()
    End Sub

    Private Sub mnSetupEditBankAccounts_Click(sender As Object, e As EventArgs) Handles mnSetupEditBankAccounts.Click
        Dim _form As Form = LoadChildForm(Me, New frmBankAccounts())
        If Not _form Is Nothing Then DirectCast(_form, frmBankAccounts).Edit()
    End Sub

    Private Sub mnReportsBankingRegister_Click(sender As Object, e As EventArgs) Handles mnReportsBankingRegister.Click
        LoadChildForm(Me, New frmBankingReport)
    End Sub


    Private Sub MnuToolsStaffLocations_Click(sender As System.Object, e As System.EventArgs) Handles MnuToolsStaffLocations.Click
        Dim _form As Form = LoadChildForm(Me, New frmStaffLocations())
        If Not _form Is Nothing Then DirectCast(_form, frmStaffLocations).Save()
    End Sub


    Private Sub DoctorVisitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        LoadChildForm(Me, New frmToSeeDoctorsVisits)
    End Sub

    Private Sub ClaimPaymentsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClaimPaymentsToolStripMenuItem1.Click
        LoadChildForm(Me, New frmClaimPayment)
    End Sub

    Private Sub ClaimPaymentDetailedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClaimPaymentDetailedToolStripMenuItem.Click
        LoadChildForm(Me, New FrmClaimPaymentDetails(Nothing))
    End Sub

    Private Sub mnuReportsGeneraItemStatus_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsGeneraItemStatus.Click
        LoadChildForm(Me, New frmReportItemStatus())
    End Sub

    Private Sub mnuReportInvoicesInvoiceCategorisation_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportInvoicesInvoiceCategorisation.Click
        LoadChildForm(Me, New frmInvoiceCategorisation())
    End Sub

    Private Sub mnToolsQueue_Click(sender As System.Object, e As System.EventArgs) Handles mnToolsQueue.Click
        frmQueues.ShowDialog()
    End Sub

    Private Sub mnuToolsOthersUnsentTextMessages_Click(sender As System.Object, e As System.EventArgs) Handles mnuToolsOthersUnsentTextMessages.Click
        LoadChildForm(Me, New frmSendTextMessages)
    End Sub

    Private Sub SMSRemindersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SMSRemindersToolStripMenuItem.Click
        LoadChildForm(Me, New frmSMSScheduling)
    End Sub

    Private Sub IPDStaffPaymentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IPDStaffPaymentsToolStripMenuItem.Click
        Dim _form As Form = LoadChildForm(Me, New frmIPDStaffPaymentDetails())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDStaffPaymentDetails).Save()
    End Sub

    Private Sub OPDStaffPaymentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OPDStaffPaymentsToolStripMenuItem.Click
        Dim _form As Form = LoadChildForm(Me, New frmOPDStaffPaymentDetails())
        If Not _form Is Nothing Then DirectCast(_form, frmOPDStaffPaymentDetails).Save()
    End Sub

    Private Sub IPDStaffPaymentsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles IPDStaffPaymentsToolStripMenuItem1.Click
        Dim _form As Form = LoadChildForm(Me, New frmIPDStaffPaymentDetails())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDStaffPaymentDetails).Edit()
    End Sub

    Private Sub OPDStaffPaymentsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OPDStaffPaymentsToolStripMenuItem1.Click
        Dim _form As Form = LoadChildForm(Me, New frmOPDStaffPaymentDetails())
        If Not _form Is Nothing Then DirectCast(_form, frmOPDStaffPaymentDetails).Edit()
    End Sub

    Private Sub StaffPaymentApprovalsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StaffPaymentApprovalsToolStripMenuItem.Click
        Security.Apply(Me.StaffPaymentApprovalsToolStripMenuItem, AccessRights.Write)
        LoadChildForm(Me, New FrmStaffPaymentsApprovals)
    End Sub

    Private Sub mniReportsExtrasSupplierHistory_Click(sender As Object, e As EventArgs) Handles mniReportsExtrasSupplierHistory.Click
        LoadChildForm(Me, New frmSupplierHistory)
    End Sub



    Private Sub mniReportdDetailedAccountStatement_Click(sender As System.Object, e As System.EventArgs) Handles mniReportdDetailedAccountStatement.Click
        LoadChildForm(Me, New frmAccountStatement)
    End Sub

    Private Sub btnExtraNewEmergencyCase_Click(sender As System.Object, e As System.EventArgs) Handles btnExtraNewEmergencyCase.Click
        LoadChildForm(Me, New frmEmergencies)
    End Sub

    Private Sub mnuSetupNewRevenueStreams_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupNewRevenueStreams.Click
        Dim _form As Form = LoadChildForm(Me, New frmRevenueStreams())
        If Not _form Is Nothing Then DirectCast(_form, frmRevenueStreams).Save()
    End Sub


    Private Sub mnuReportsDiagnosisReportsDiagnosisSummaries_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsDiagnosisReportsDiagnosisSummaries.Click
        LoadChildForm(Me, New frmDiagnosisSummaries())
    End Sub

    Private Sub mnuReportsDiagnosisReportsDiagnosisReattendances_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsDiagnosisReportsDiagnosisReattendances.Click
        LoadChildForm(Me, New frmDiagnosisReattendances())
    End Sub

    Private Sub mnuSetupNewPackages_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupNewPackages.Click
        Dim _form As Form = LoadChildForm(Me, New frmPackages())
        If Not _form Is Nothing Then DirectCast(_form, frmPackages).Save()
    End Sub

    Private Sub PackagesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PackagesToolStripMenuItem.Click
        Dim _form As Form = LoadChildForm(Me, New frmPackages())
        If Not _form Is Nothing Then DirectCast(_form, frmPackages).Edit()
    End Sub

    Private Sub mnuSetupNewLabEXTPossibleResults_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupNewLabEXTPossibleResults.Click
        Dim _form As Form = LoadChildForm(Me, New frmLabTestsEXTPossibleResults())
        If Not _form Is Nothing Then DirectCast(_form, frmLabTestsEXTPossibleResults).Save()
    End Sub

    Private Sub mnuSetupEditPossibleLabResultsSubTest_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupEditPossibleLabResultsSubTest.Click
        Dim _form As Form = LoadChildForm(Me, New frmLabTestsEXTPossibleResults())
        If Not _form Is Nothing Then DirectCast(_form, frmLabTestsEXTPossibleResults).Edit()
    End Sub


    Private Sub mnuReportLabResultsLabResultsReport_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportLabResultsLabResultsReport.Click
        LoadChildForm(Me, New frmPrintLabResults())
    End Sub

    Private Sub mnuReportLabResultsLabReport_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportLabResultsLabReport.Click
        LoadChildForm(Me, New frmLabReport())
    End Sub

    Private Sub bmniInPatientsIPDCancerDiagnosis_Click(sender As System.Object, e As System.EventArgs) Handles bmniInPatientsIPDCancerDiagnosis.Click
        LoadChildForm(Me, New frmIPDCancerDiagnosis())
    End Sub


    Private Sub MnuToolsSuspenseAccount_Click(sender As System.Object, e As System.EventArgs) Handles MnuToolsSuspenseAccount.Click
        LoadChildForm(Me, New frmManageSuspenceAccount())
    End Sub


    Private Sub bmiRadiologyEditIPDPathologyReports_Click(sender As System.Object, e As System.EventArgs) Handles bmiCardiologyEditIPDCardiologyReports.Click
        Dim _form As Form = LoadChildForm(Me, New frmIPDCardiologyReports())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDCardiologyReports).Edit()
    End Sub

    Private Sub mnuExtrasEnrollment_Click(sender As System.Object, e As System.EventArgs) Handles mnuExtrasMaternityEnrollment.Click
        Dim _form As Form = LoadChildForm(Me, New frmMaternalEnrollment())
        If Not _form Is Nothing Then DirectCast(_form, frmMaternalEnrollment).Save()
    End Sub

    Private Sub mnuExtrasAntenatalVisits_Click(sender As System.Object, e As System.EventArgs) Handles mnuExtrasAntenatalVisits.Click
        Dim _form As Form = LoadChildForm(Me, New frmAntenatalVisits())
        If Not _form Is Nothing Then DirectCast(_form, frmAntenatalVisits).Save()
    End Sub

    Private Sub mnuExtrasRefundsRequests_Click(sender As System.Object, e As System.EventArgs) Handles mnuExtrasRefundsRequests.Click
        Dim _form As Form = LoadChildForm(Me, New frmRefundRequests(String.Empty))
        If Not _form Is Nothing Then DirectCast(_form, frmRefundRequests).Save()
    End Sub

    Private Sub mnuExtrasRefundApprovals_Click(sender As System.Object, e As System.EventArgs) Handles mnuExtrasRefundApprovals.Click
        Dim _form As Form = LoadChildForm(Me, New frmRefundApprovals())
        If Not _form Is Nothing Then DirectCast(_form, frmRefundApprovals).Save()
    End Sub

    Private Sub bmiOPDPharmacyRefundRequestsDrugs_Click(sender As System.Object, e As System.EventArgs) Handles bmiOPDPharmacyRefundRequestsDrugs.Click
        Dim _form As Form = LoadChildForm(Me, New frmRefundRequests(oItemCategoryID.Drug))
        If Not _form Is Nothing Then DirectCast(_form, frmRefundRequests).Save()
    End Sub

    Private Sub bmiOPDPharmacyRefundRequestsConsumables_Click(sender As System.Object, e As System.EventArgs) Handles bmiOPDPharmacyRefundRequestsConsumables.Click
        Dim _form As Form = LoadChildForm(Me, New frmRefundRequests(oItemCategoryID.Consumable))
        If Not _form Is Nothing Then DirectCast(_form, frmRefundRequests).Save()
    End Sub

    Private Sub bmiLaboratoryRefundRequest_Click(sender As System.Object, e As System.EventArgs) Handles bmiLaboratoryRefundRequest.Click
        Dim _form As Form = LoadChildForm(Me, New frmRefundRequests(oItemCategoryID.Test))
        If Not _form Is Nothing Then DirectCast(_form, frmRefundRequests).Save()
    End Sub


    Private Sub bmiRadiologyRefundRequest_Click(sender As System.Object, e As System.EventArgs) Handles bmiRadiologyRefundRequest.Click
        Dim _form As Form = LoadChildForm(Me, New frmRefundRequests(oItemCategoryID.Radiology))
        If Not _form Is Nothing Then DirectCast(_form, frmRefundRequests).Save()
    End Sub

    Private Sub ddTheatreRefundReques_Click(sender As System.Object, e As System.EventArgs) Handles ddTheatreRefundReques.Click
        Dim _form As Form = LoadChildForm(Me, New frmRefundRequests(oItemCategoryID.Theatre))
        If Not _form Is Nothing Then DirectCast(_form, frmRefundRequests).Save()
    End Sub

    Private Sub ddDentalRefundReques_Click(sender As System.Object, e As System.EventArgs) Handles ddDentalRefundReques.Click
        Dim _form As Form = LoadChildForm(Me, New frmRefundRequests(oItemCategoryID.Dental))
        If Not _form Is Nothing Then DirectCast(_form, frmRefundRequests).Save()
    End Sub

    Private Sub bmiInvoicesCreditNote_Click(sender As System.Object, e As System.EventArgs) Handles bmiInvoicesInvoiceAdjustments.Click
        Dim _form As Form = LoadChildForm(Me, New frmInvoiceAdjustments())
        If Not _form Is Nothing Then DirectCast(_form, frmInvoiceAdjustments).Save()
    End Sub


    Private Sub bmiPathologyRefundRequests_Click(sender As System.Object, e As System.EventArgs) Handles bmiCardiologyRefundRequests.Click
        Dim _form As Form = LoadChildForm(Me, New frmRefundRequests(oItemCategoryID.Pathology))
        If Not _form Is Nothing Then DirectCast(_form, frmRefundRequests).Save()
    End Sub

    Private Sub mnuReportsGeneraPatientRecords_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsGeneraPatientRecords.Click
        LoadChildForm(Me, New frmPatientRecord())
    End Sub

    Private Sub btnExtraEditCodeMapping_Click(sender As System.Object, e As System.EventArgs) Handles btnExtraEditCodeMapping.Click
        Dim _form As Form = LoadChildForm(Me, New frmMappedCodes())
        If Not _form Is Nothing Then DirectCast(_form, frmMappedCodes).Edit()
    End Sub

    Private Sub btnFinCollectionBreakDownIncomeCollectionBreakdown_Click(sender As System.Object, e As System.EventArgs) Handles btnFinCollectionBreakDownIncomeCollectionBreakdown.Click
        LoadChildForm(Me, New frmConsolidatedFinancialReport())
    End Sub

    Private Sub mnuInventoryOtherItemsInventory_Click(sender As System.Object, e As System.EventArgs) Handles mnuInventoryOtherItemsInventory.Click
        Dim oItemCategoryID As New SyncSoft.SQLDb.Lookup.LookupDataID.ItemCategoryID()
        LoadChildForm(Me, New frmInventory(oItemCategoryID.NonMedical))
    End Sub


    Private Sub mnuSetupNewBillableCardiologyExaminations_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupNewBillableCardiologyExaminations.Click
        Dim _form As Form = LoadChildForm(Me, New frmCardiologyExaminations())
        If Not _form Is Nothing Then DirectCast(_form, frmCardiologyExaminations).Save()
    End Sub

    Private Sub mnuSetupEditBillableCardiologyExaminations_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupEditBillableCardiologyExaminations.Click
        Dim _form As Form = LoadChildForm(Me, New frmCardiologyExaminations())
        If Not _form Is Nothing Then DirectCast(_form, frmCardiologyExaminations).Edit()
    End Sub

    Private Sub mnuReportsCardiologyReports_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsCardiologyReports.Click
        LoadChildForm(Me, New frmPrintCardiologyReports())
    End Sub

    Private Sub mnuReportsIPDCardiologyReports_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsIPDCardiologyReports.Click
        LoadChildForm(Me, New frmPrintIPDCardiologyReports())
    End Sub

    Private Sub btnExtraNewImmunisation_Click(sender As System.Object, e As System.EventArgs) Handles btnExtraNewImmunisation.Click
        Dim _form As Form = LoadChildForm(Me, New frmImmunisationVaccines(String.Empty))
        If Not _form Is Nothing Then DirectCast(_form, frmImmunisationVaccines).Save()

    End Sub

    Private Sub btnExtraEditImmunisation_Click(sender As System.Object, e As System.EventArgs) Handles btnExtraEditImmunisation.Click
        Dim _form As Form = LoadChildForm(Me, New frmImmunisationVaccines())
        If Not _form Is Nothing Then DirectCast(_form, frmImmunisationVaccines).Edit()
    End Sub

    Private Sub bmiExtrasNewServiceInvoices_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasNewServiceInvoices.Click
        Dim _form As Form = LoadChildForm(Me, New frmServiceInvoices())
        If Not _form Is Nothing Then DirectCast(_form, frmServiceInvoices).Save()
    End Sub

    Private Sub bmiExtrasEditServiceInvoices_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasEditServiceInvoices.Click
        Dim _form As Form = LoadChildForm(Me, New frmServiceInvoices())
        If Not _form Is Nothing Then DirectCast(_form, frmServiceInvoices).Edit()
    End Sub

    Private Sub ddbFinancesInventoryConsumableInventoryPayments_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesInventoryConsumableInventoryPayments.Click
        LoadChildForm(Me, New frmPaymentVouchers())
    End Sub

    Private Sub PaymentVoucherBalances_Click(sender As System.Object, e As System.EventArgs) Handles PaymentVoucherBalances.Click
        LoadChildForm(Me, New frmPaymentVoucherBalances())
    End Sub



    Private Sub bmiExtrasNewPhysiotherapy_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasNewPhysiotherapy.Click
        Dim _form As Form = LoadChildForm(Me, New frmPhysiotherapy())
        If Not _form Is Nothing Then DirectCast(_form, frmPhysiotherapy).Save()
    End Sub

    Private Sub bmiExtrasEditPhysiotherapy_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasEditPhysiotherapy.Click
        Dim _form As Form = LoadChildForm(Me, New frmPhysiotherapy())
        If Not _form Is Nothing Then DirectCast(_form, frmPhysiotherapy).Edit()
    End Sub

    Private Sub mnuSetupNewPhysioDiseases_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupNewPhysioDiseases.Click
        Dim _form As Form = LoadChildForm(Me, New frmPhysioDiseases())
        If Not _form Is Nothing Then DirectCast(_form, frmPhysioDiseases).Save()
    End Sub

    Private Sub bmiExtrasNewCodeMappingBillCustomers_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasNewCodeMappingBillCustomers.Click
        Dim _form As Form = LoadChildForm(Me, New frmMappedCodes())
        If Not _form Is Nothing Then DirectCast(_form, frmMappedCodes).Save()
    End Sub


    Private Sub btnExtraEditCodeMappingBillCustomers_Click(sender As System.Object, e As System.EventArgs) Handles btnExtraEditCodeMappingBillCustomers.Click
        Dim _form As Form = LoadChildForm(Me, New frmMappedCodes())
        If Not _form Is Nothing Then DirectCast(_form, frmMappedCodes).Edit()
    End Sub


    Private Sub bmiExtrasNewCodeMappingFinance_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasNewCodeMappingFinance.Click
        Dim _form As Form = LoadChildForm(Me, New frmMappedCodesFinance())
        If Not _form Is Nothing Then DirectCast(_form, frmMappedCodesFinance).Save()
    End Sub


    Private Sub btnExtraEditCodeMappingFinance_Click(sender As System.Object, e As System.EventArgs) Handles btnExtraEditCodeMappingFinance.Click
        Dim _form As Form = LoadChildForm(Me, New frmMappedCodesFinance())
        If Not _form Is Nothing Then DirectCast(_form, frmMappedCodesFinance).Edit()
    End Sub

    Private Sub btnExtraEditCodeMappingBillableMappings_Click(sender As System.Object, e As System.EventArgs) Handles btnExtraEditCodeMappingBillableMappings.Click
        Dim _form As Form = LoadChildForm(Me, New frmBillableMappings())
        If Not _form Is Nothing Then DirectCast(_form, frmBillableMappings).Edit()
    End Sub

    Private Sub mnuReportsInvoicesVisitInvoices_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsInvoicesVisitInvoices.Click
        LoadChildForm(Me, New frmVisitInvoices(String.Empty, String.Empty))
    End Sub

    Private Sub mnuToolsReversalsReceipts_Click(sender As System.Object, e As System.EventArgs) Handles mnuToolsReversalsReceipts.Click
        Dim _form As Form = LoadChildForm(Me, New frmReceiptReversals())
        If Not _form Is Nothing Then DirectCast(_form, frmReceiptReversals).Save()
    End Sub

    Private Sub mnuToolsReveAccounts_Click(sender As System.Object, e As System.EventArgs) Handles mnuToolsReveAccounts.Click
        LoadChildForm(Me, New frmManageAccountsReversals())
    End Sub

    Private Sub btnExtraNewOccupationalTherapy_Click(sender As System.Object, e As System.EventArgs) Handles btnExtraNewOccupationalTherapy.Click
        Dim _form As Form = LoadChildForm(Me, New frmOccupationalTherapy())
        If Not _form Is Nothing Then DirectCast(_form, frmOccupationalTherapy).Save()
    End Sub

    Private Sub bmiInventoryNewPhysicalStockCount_Click(sender As System.Object, e As System.EventArgs) Handles bmiInventoryNewPhysicalStockCount.Click
        Dim _form As Form = LoadChildForm(Me, New frmPhysicalStockCount())
        If Not _form Is Nothing Then DirectCast(_form, frmPhysicalStockCount).Save()
    End Sub

    Private Sub bmiInventoryEditPhysicalStockCount_Click(sender As System.Object, e As System.EventArgs) Handles bmiInventoryEditPhysicalStockCount.Click
        Dim _form As Form = LoadChildForm(Me, New frmPhysicalStockCount())
        If Not _form Is Nothing Then DirectCast(_form, frmPhysicalStockCount).Edit()
    End Sub

    Private Sub bmiInventoryImportInventory_Click(sender As System.Object, e As System.EventArgs) Handles bmiInventoryImportInventory.Click
        LoadChildForm(Me, New frmImportInventory())
    End Sub

    Private Sub bmiLaboratoryRefundRequestLaboratory_Click(sender As System.Object, e As System.EventArgs) Handles bmiLaboratoryRefundRequestLaboratory.Click
        Dim _form As Form = LoadChildForm(Me, New frmRefundRequests(oItemCategoryID.Test))
        If Not _form Is Nothing Then DirectCast(_form, frmRefundRequests).Save()
    End Sub

    Private Sub bmiLaboratoryRefundRequestPathology_Click(sender As System.Object, e As System.EventArgs) Handles bmiLaboratoryRefundRequestPathology.Click
        Dim _form As Form = LoadChildForm(Me, New frmRefundRequests(oItemCategoryID.Pathology))
        If Not _form Is Nothing Then DirectCast(_form, frmRefundRequests).Save()
    End Sub

    Private Sub bmiExtraEditMaternityEnrollment_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtraEditMaternityEnrollment.Click
        Dim _form As Form = LoadChildForm(Me, New frmMaternalEnrollment())
        If Not _form Is Nothing Then DirectCast(_form, frmMaternalEnrollment).Edit()
    End Sub

    Private Sub bmiExtraEditMaternityAntenatalVisits_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtraEditMaternityAntenatalVisits.Click
        Dim _form As Form = LoadChildForm(Me, New frmAntenatalVisits())
        If Not _form Is Nothing Then DirectCast(_form, frmAntenatalVisits).Edit()
    End Sub


    Private Sub mnuFinancesAssets_Click(sender As System.Object, e As System.EventArgs) Handles mnuFinancesAssets.Click
        Security.Apply(Me.mnuFinancesAssets, AccessRights.Write)
    End Sub

    Private Sub ddbFinancesRefunds_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesRefunds.Click
        Security.Apply(Me.ddbFinancesRefunds, AccessRights.Write)
    End Sub

    Private Sub ddbFinancesIncome_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesIncome.Click
        Security.Apply(Me.ddbFinancesIncome, AccessRights.Write)
    End Sub

    Private Sub ddbFinancesInvoices_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesInvoices.Click
        Security.Apply(Me.ddbFinancesIncome, AccessRights.Write)
    End Sub

    Private Sub ddbFinancesInventory_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesInventory.Click
        Security.Apply(Me.ddbFinancesInventory, AccessRights.Write)
    End Sub

    Private Sub ddbFinancesClaims_Click(sender As System.Object, e As System.EventArgs) Handles ddbFinancesClaims.Click
        Security.Apply(Me.ddbFinancesClaims, AccessRights.Write)
    End Sub

    Private Sub mnuReportsPayments_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsPayments.Click
        Me.ddbFinancesInventory_Click(Me, Nothing)
    End Sub

    Private Sub mnuReportsInvoices_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsInvoices.Click
        Me.ddbFinancesInvoices_Click(Me, Nothing)
    End Sub

    Private Sub mnuReportsLabResults_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsLabResults.Click
        Security.Apply(Me.mnuReportsLabResults, AccessRights.Write)
    End Sub

    Private Sub mnuReportsInventory_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsInventory.Click
        Me.ddbFinancesInventory_Click(Me, Nothing)
    End Sub

    Private Sub mnuReportsClaims_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsClaims.Click
        Me.ddbFinancesClaims_Click(Me, Nothing)
    End Sub

    Private Sub mnuReportsExtras_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsExtras.Click
        Me.ddbFinancesInventory_Click(Me, Nothing)
    End Sub

    Private Sub bmiRadiologyReImages_Click(sender As System.Object, e As System.EventArgs) Handles bmiRadiologyReImages.Click
        LoadChildForm(Me, New frmAllImages())
    End Sub

    Private Sub mnuReportsPaymentCategorisation_Click(sender As System.Object, e As System.EventArgs) Handles mnuReportsPaymentCategorisation.Click
        LoadChildForm(Me, New frmPaymentCategorisation())
    End Sub

    Private Sub bmiLaboratoryApproveLabResults_Click(sender As System.Object, e As System.EventArgs) Handles bmiLaboratoryApproveLabResults.Click
        LoadChildForm(Me, New frmLabResultsApproval())
    End Sub

    Private Sub bmiExtrasOPDBillAdjustments_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasOPDBillAdjustments.Click
        LoadChildForm(Me, New frmBillAdjustments(String.Empty, False))
    End Sub


    Private Sub bmiExtrasNewLookupDataMappings_Click(sender As System.Object, e As System.EventArgs) Handles bmiExtrasNewLookupDataMappings.Click
        Dim _form As Form = LoadChildForm(Me, New frmLookupDataMappings())
        If Not _form Is Nothing Then DirectCast(_form, frmLookupDataMappings).Save()
    End Sub

    Private Sub mnuSetupNewINTAgents_Click(sender As System.Object, e As System.EventArgs)
        Dim _form As Form = LoadChildForm(Me, New frmINTAgents())
        If Not _form Is Nothing Then DirectCast(_form, frmINTAgents).Save()
    End Sub


    Private Sub mnuSetupEditIntegrationAgents_Click(sender As System.Object, e As System.EventArgs)
        Dim _form As Form = LoadChildForm(Me, New frmINTAgents())
        If Not _form Is Nothing Then DirectCast(_form, frmINTAgents).Edit()
    End Sub


    Private Sub bmniInPatientsSmartBilling_Click(sender As System.Object, e As System.EventArgs) Handles bmniInPatientsSmartBilling.Click
        LoadChildForm(Me, New frmSmartBilling())
    End Sub

    Private Sub bmiPathologyNewIPDPathologyReports_Click(sender As System.Object, e As System.EventArgs) Handles bmiPathologyNewIPDPathologyReports.Click
        Dim _form As Form = LoadChildForm(Me, New frmIPDPathologyReports())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDPathologyReports).Save()
    End Sub

    Private Sub bmiPathologyEditIPDPathologyReports_Click(sender As System.Object, e As System.EventArgs) Handles bmiPathologyEditIPDPathologyReports.Click
        Dim _form As Form = LoadChildForm(Me, New frmIPDPathologyReports())
        If Not _form Is Nothing Then DirectCast(_form, frmIPDPathologyReports).Edit()
    End Sub


    Private Sub mnuSetupEditBillableItemUnitPrice_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupEditBillableItemUnitPrice.Click
        Dim _form As Form = LoadChildForm(Me, New frmUpdateItemUnitPrice())
    End Sub

    Private Sub mnuSetupIntegrationAgents_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetupIntegrationAgents.Click
        Dim _form As Form = LoadChildForm(Me, New frmINTAgents())
        If Not _form Is Nothing Then DirectCast(_form, frmINTAgents).Edit()
    End Sub

    Private Sub bmniInPatientsPara_Click(sender As System.Object, e As System.EventArgs) Handles bmniInPatientsPara.Click
        Dim _form As Form = LoadChildForm(Me, New frmINTPara())
        If Not _form Is Nothing Then DirectCast(_form, frmINTPara).Save()
    End Sub

 
End Class
