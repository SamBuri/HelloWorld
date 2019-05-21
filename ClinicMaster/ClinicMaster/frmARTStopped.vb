
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmARTStopped

#Region " Validations "

    Private Sub dtpStopDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpStopDate.Validating

        Dim errorMSG As String = "Stop date can't be before start date!"

        Try

            Dim startDate As Date = DateMayBeEnteredIn(Me.stbStartDate)
            Dim stopDate As Date = DateMayBeEnteredIn(Me.dtpStopDate)

            If stopDate = AppData.NullDateValue Then Return

            If stopDate < startDate Then
                ErrProvider.SetError(Me.dtpStopDate, errorMSG)
                Me.dtpStopDate.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpStopDate, "")
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

    Private Sub frmfrmARTStopped_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.dtpStopDate.MaxDate = Today

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.LoadStaff()
            LoadLookupDataCombo(Me.clbARTStopReasons, LookupObjects.ARTStopReasons, False)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmARTStopped_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
            Dim fFindVisitNoCurrentlyOnART As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNoCurrentlyOnART)
            fFindVisitNoCurrentlyOnART.ShowDialog(Me)
        Else
            Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
            fFindVisitNo.ShowDialog(Me)
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        Me.ShowPatientDetails(visitNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnLoadPeriodicVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPeriodicVisits.Click

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicVisits As New frmPeriodicVisits(Me.stbVisitNo)
            fPeriodicVisits.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            Me.ShowPatientDetails(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        Me.ShowPatientDetails(visitNo)

    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged
        Me.CallOnKeyEdit()
        Me.ClearControls()
    End Sub

    Private Sub ClearControls()
        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()
        Me.stbCombination.Clear()
        Me.stbStartDate.Clear()
        Me.stbVisitDate.Clear()
        Me.stbLastVisitDate.Clear()
    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oARTRegimen As New SyncSoft.SQLDb.ARTRegimen()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(visitNo) Then Return

            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim ARTRegimen As DataTable = oARTRegimen.GetARTRegimen(visitNo).Tables("ARTRegimen")

            Dim visitsRow As DataRow = visits.Rows(0)
            Dim ARTRegimenRow As DataRow = ARTRegimen.Rows(0)

            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Me.stbPatientNo.Text = FormatText(StringEnteredIn(visitsRow, "PatientNo"), "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(visitsRow, "FullName")
            Me.stbCombination.Text = StringEnteredIn(ARTRegimenRow, "Combination")
            Me.stbStartDate.Text = FormatDate(DateEnteredIn(ARTRegimenRow, "StartDate"))
            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(visitsRow, "VisitDate"))

            Me.stbLastVisitDate.Text = FormatDate(DateEnteredIn(visitsRow, "LastVisitDate"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpStopDate.Value = DateEnteredIn(visitsRow, "LastVisitDate")
            Me.dtpStopDate.Checked = False
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim oARTStopped As New SyncSoft.SQLDb.ARTStopped()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oARTStopped.VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            DisplayMessage(oARTStopped.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me)
            Me.CallOnKeyEdit()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim oARTStopped As New SyncSoft.SQLDb.ARTStopped()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim dataSource As DataTable = oARTStopped.GetARTStopped(visitNo).Tables("ARTStopped")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oARTStopped As New SyncSoft.SQLDb.ARTStopped()

            With oARTStopped

                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .StopDate = DateEnteredIn(Me.dtpStopDate, "Stop Date!")
                .ARTStopReasons = StringToSplitSelectedInAtleastOne(Me.clbARTStopReasons, LookupObjects.ARTStopReasons, "ART Stop Reasons!")
                .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Staff No!")
                .LoginID = CurrentUser.LoginID

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ValidateEntriesIn(Me, ErrProvider)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oARTStopped.Save()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oARTStopped.Update())

                    Me.CallOnKeyEdit()

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.btnDelete.Visible = True
        Me.btnDelete.Enabled = False
        Me.btnSearch.Visible = True

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.btnDelete.Visible = False
        Me.btnDelete.Enabled = True
        Me.btnSearch.Visible = False

        ResetControlsIn(Me)

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.btnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            Security.Apply(Me.btnDelete, AccessRights.Delete)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.ebnSaveUpdate.Enabled = False
            Me.btnDelete.Enabled = False
        End If
    End Sub

#End Region

End Class