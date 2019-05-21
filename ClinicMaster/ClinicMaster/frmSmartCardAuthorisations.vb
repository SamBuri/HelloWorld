
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmSmartCardAuthorisations

#Region " Fields "

    Private Const _CashCustomer As String = "Cash Customer"
    Private billCustomers As DataTable

#End Region

#Region " Validations "

    Private Sub dtpToVisitDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpToVisitDate.Validating

        Dim errorMSG As String = "To-Visit date can't be before last visit date!"

        Try

            Dim lastVisitDate As Date = DateMayBeEnteredIn(Me.stbLastVisitDate)
            Dim toVisitDate As Date = DateMayBeEnteredIn(Me.dtpToVisitDate)

            If toVisitDate = AppData.NullDateValue Then Return

            If toVisitDate < lastVisitDate Then
                ErrProvider.SetError(Me.dtpToVisitDate, errorMSG)
                Me.dtpToVisitDate.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpToVisitDate, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

    Private Sub frmSmartCardAuthorisations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboBillModesID, LookupObjects.BillModes, False)
            LoadLookupDataCombo(Me.cboAuthorisationReason, LookupObjects.AuthorisationReason, False)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmSmartCardAuthorisations_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Patients", Me.stbPatientNo)
            fQuickSearch.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            If Not String.IsNullOrEmpty(patientNo) Then Me.ShowPatientDetails(patientNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbFullName.Clear()
        Me.stbAge.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbLastVisitDate.Clear()
        Me.cboBillModesID.SelectedIndex = -1
        Me.cboBillModesID.SelectedIndex = -1
        Me.cboBillNo.Text = String.Empty
        Me.ResetBillControls()

    End Sub

    Private Sub stbPatientNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbPatientNo.TextChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ClearControls()
    End Sub

    Private Sub stbPatientNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbPatientNo.Leave

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            If Not String.IsNullOrEmpty(patientNo) Then Me.ShowPatientDetails(patientNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal patientNo As String)

        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            Dim patients As DataTable = oPatients.GetPatients(patientNo).Tables("Patients")
            Dim row As DataRow = patients.Rows(0)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbLastVisitDate.Text = FormatDate(DateMayBeEnteredIn(row, "LastVisitDate"))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboBillModesID.SelectedValue = StringEnteredIn(row, "DefaultBillModesID")
            Me.cboBillNo.Text = StringEnteredIn(row, "DefaultBillNo")
            Me.stbMemberCardNo.Text = StringMayBeEnteredIn(row, "DefaultMemberCardNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbBillCustomerName.Text = StringEnteredIn(row, "BillCustomerName")
            Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboBillModesID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBillModesID.Leave

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
                Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
                If String.IsNullOrEmpty(billModesID) Then Return
                Me.LoadBillClients(billModesID)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboBillModesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillModesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
            If String.IsNullOrEmpty(billModesID) Then Return
            Me.LoadBillClients(billModesID)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearBillControls()
        Me.cboBillNo.DataSource = Nothing
        Me.cboBillNo.Items.Clear()
        Me.cboBillNo.Text = String.Empty
        Me.ResetBillControls()
    End Sub

    Private Sub ResetBillControls()

        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
            Me.stbMemberCardNo.Clear()
            Me.stbClaimReferenceNo.Clear()
        End If

        Me.stbBillCustomerName.Clear()
        Me.stbInsuranceName.Clear()

    End Sub

    Private Sub LoadBillClients(ByVal billModesID As String)

        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearBillControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.LoadCASHCustomer()
                    Me.cboBillNo.Enabled = False
                    Me.lblBillNo.Text = "To-Bill Number"
                    Me.stbMemberCardNo.Enabled = False
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Load all from Bill Customers

                    If Not InitOptions.LoadBillCustomersAtStart Then
                        billCustomers = oBillCustomers.GetBillCustomers().Tables("BillCustomers")
                        oSetupData.BillCustomers = billCustomers
                    Else : billCustomers = oSetupData.BillCustomers
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.cboBillNo, billCustomers, "BillCustomerFullName")
                    Me.cboBillNo.Enabled = True
                    Me.lblBillNo.Text = "To-Bill Number"
                    Me.stbMemberCardNo.Enabled = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboBillNo.Enabled = True
                    Me.lblBillNo.Text = "To-Bill Medical Card No"
                    Me.stbMemberCardNo.Enabled = False
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub OrganizeBillControls(ByVal billModesID As String)

        Dim oBillModesID As New LookupDataID.BillModesID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboBillNo.Enabled = False
                    Me.lblBillNo.Text = "To-Bill Number"
                    Me.stbMemberCardNo.Enabled = False
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboBillNo.Enabled = False
                    Me.lblBillNo.Text = "To-Bill Number"
                    Me.stbMemberCardNo.Enabled = False
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboBillNo.Enabled = False
                    Me.lblBillNo.Text = "To-Bill Medical Card No"
                    Me.stbMemberCardNo.Enabled = False
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadCASHCustomer()

        Try

            Dim oBillModesID As New LookupDataID.BillModesID()
            Dim accountNo As String = GetLookupDataDes(oBillModesID.Cash).ToUpper()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboBillModesID.SelectedValue = oBillModesID.Cash
            Me.cboBillNo.Text = accountNo
            Me.stbBillCustomerName.Text = _CashCustomer

            Me.stbInsuranceName.Clear()
            Me.stbMemberCardNo.Clear()

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub ClearBillCustomerName(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillNo.SelectedIndexChanged, cboBillNo.TextChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ResetBillControls()
    End Sub

    Private Sub cboBillAccountNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBillNo.Leave
        Me.DetailBillClient()
    End Sub

    Private Sub DetailBillClient()

        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oSchemeMembers As New SyncSoft.SQLDb.SchemeMembers()

        Try

            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
            If String.IsNullOrEmpty(billModesID) Then Return

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()
                    Return

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim accountNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboBillNo)))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboBillNo.Text = FormatText(accountNo, "BillCustomers", "AccountNo").ToUpper()
                    If billCustomers Is Nothing OrElse billCustomers.Rows.Count < 1 Then Return
                    Me.ResetBillControls()

                    For Each row As DataRow In billCustomers.Select("AccountNo = '" + accountNo + "'")
                        Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "BillCustomerName")
                        Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "BillCustomerInsurance")
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ResetBillControls()

                    Dim medicalCardNo As String = RevertText(StringMayBeEnteredIn(Me.cboBillNo))
                    If String.IsNullOrEmpty(medicalCardNo) Then Return

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboBillNo.Text = FormatText(medicalCardNo.ToUpper(), "SchemeMembers", "MedicalCardNo")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oSchemeMembers.GetSchemeMembers(medicalCardNo).Tables("SchemeMembers").Rows(0)
                    Me.stbMemberCardNo.Text = medicalCardNo.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "CompanyName")
                    Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oSmartCardAuthorisations As New SyncSoft.SQLDb.SmartCardAuthorisations()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            With oSmartCardAuthorisations
                .PatientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Paient's Number!"))
                .BillModesID = StringValueEnteredIn(Me.cboBillModesID, "Bill Mode!")
                .BillNo = RevertText(StringEnteredIn(Me.cboBillNo, "To-Bill No!"))
                .ToVisitDate = DateEnteredIn(Me.dtpToVisitDate, "Authorisation Date!")
            End With

            DisplayMessage(oSmartCardAuthorisations.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oSmartCardAuthorisations As New SyncSoft.SQLDb.SmartCardAuthorisations()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Paient's Number!"))
            Dim billModesID As String = StringValueEnteredIn(Me.cboBillModesID, "Bill Mode!")
            Dim billNo As String = RevertText(StringEnteredIn(Me.cboBillNo, "To-Bill No!"))
            Dim toVisitDate As Date = DateEnteredIn(Me.dtpToVisitDate, "To Visit Date!")

            Dim dataSource As DataTable = oSmartCardAuthorisations.GetSmartCardAuthorisations(patientNo, billModesID, billNo, toVisitDate).Tables("SmartCardAuthorisations")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oSmartCardAuthorisations As New SyncSoft.SQLDb.SmartCardAuthorisations()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oSmartCardAuthorisations

                .PatientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Paient's Number!"))
                .BillModesID = StringValueEnteredIn(Me.cboBillModesID, "Bill Mode!")
                .BillNo = RevertText(StringEnteredIn(Me.cboBillNo, "To-Bill No!"))
                .ToVisitDate = DateEnteredIn(Me.dtpToVisitDate, "Authorisation Date!")
                If .BillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) Then
                    .MedicalCardNo = StringEnteredIn(Me.stbMemberCardNo, "Member Card No!")
                Else : .MedicalCardNo = StringMayBeEnteredIn(Me.stbMemberCardNo)
                End If
                .AuthorisedBy = StringEnteredIn(Me.stbAuthorisedBy, "Authorised By!")
                .AuthorisationReason = StringValueEnteredIn(Me.cboAuthorisationReason, "Authorisation Reason!")
                .ClaimReferenceNo = StringMayBeEnteredIn(Me.stbClaimReferenceNo)
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oSmartCardAuthorisations.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    Me.ClearBillControls()
                    Me.dtpToVisitDate.Value = Today
                    Me.dtpToVisitDate.Checked = True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oSmartCardAuthorisations.Update())
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
        Me.btnLoad.Enabled = True

        Me.dtpToVisitDate.MinDate = AppData.NullDateValue

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.dtpToVisitDate.MinDate = Today

        ResetControlsIn(Me)

        Me.dtpToVisitDate.Value = Today
        Me.dtpToVisitDate.Checked = True

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