
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.Enumerations
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona


Public Class frmSchemeMembers

#Region " Fields "

    Private oPatients As SyncSoft.SQLDb.Patients

    Private insuranceSchemesCompanies As DataTable
    Private tipCoPayValueWords As New ToolTip()

    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()

#End Region

#Region " Validations "

    Private Sub ndpBirthDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpBirthDate.Leave
        Try
            SetBirthDateAge(BirthDateAge.SetAge, Me.dtpBirthDate, Me.nbxAge)
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub nbxAge_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbxAge.Leave
        Try
            SetBirthDateAge(BirthDateAge.SetBirthDate, Me.dtpBirthDate, Me.nbxAge)
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub PolicyStartDate(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
                                Handles dtpJoinDate.Validating, dtpPolicyStartDate.Validating

        Dim errorMSG As String

        Try

            Dim schemeStartDate As Date = DateMayBeEnteredIn(Me.stbSchemeStartDate)
            Dim joinDate As Date = DateMayBeEnteredIn(Me.dtpJoinDate)
            Dim policyStartDate As Date = DateMayBeEnteredIn(Me.dtpPolicyStartDate)

            If policyStartDate = AppData.NullDateValue Then Return

            If policyStartDate < schemeStartDate Then
                If schemeStartDate = AppData.NullDateValue Then Return
                errorMSG = "Policy start date can't be before scheme start date!"
                ErrProvider.SetError(Me.dtpPolicyStartDate, errorMSG)
                Me.dtpPolicyStartDate.Focus()
                e.Cancel = True
                Return
            Else : ErrProvider.SetError(Me.dtpPolicyStartDate, String.Empty)
            End If

            If policyStartDate < joinDate Then
                errorMSG = "Policy start date can't be before join date!"
                ErrProvider.SetError(Me.dtpPolicyStartDate, errorMSG)
                Me.dtpPolicyStartDate.Focus()
                e.Cancel = True
                Return
            Else : ErrProvider.SetError(Me.dtpPolicyStartDate, String.Empty)
            End If

        Catch ex As Exception
            Return

        End Try

    End Sub

    Private Sub PolicyEndDate(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
                              Handles dtpPolicyStartDate.Validating, dtpPolicyEndDate.Validating

        Dim errorMSG As String

        Try

            Dim policyStartDate As Date = DateMayBeEnteredIn(Me.dtpPolicyStartDate)
            Dim policyEndDate As Date = DateMayBeEnteredIn(Me.dtpPolicyEndDate)
            Dim schemeEndDate As Date = DateMayBeEnteredIn(Me.stbSchemeEndDate)

            If policyEndDate = AppData.NullDateValue Then Return

            If policyEndDate < policyStartDate Then
                errorMSG = "Policy end date can't be before policy start date!"
                ErrProvider.SetError(Me.dtpPolicyEndDate, errorMSG)
                Me.dtpPolicyEndDate.Focus()
                e.Cancel = True
                Return
            Else : ErrProvider.SetError(Me.dtpPolicyEndDate, String.Empty)
            End If

            If policyEndDate > schemeEndDate Then
                If schemeEndDate = AppData.NullDateValue Then Return
                errorMSG = "Policy end date can't be after scheme end date!"
                ErrProvider.SetError(Me.dtpPolicyEndDate, errorMSG)
                Me.dtpPolicyEndDate.Focus()
                e.Cancel = True
                Return
            Else : ErrProvider.SetError(Me.dtpPolicyEndDate, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

    Private Sub frmSchemeMembers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.dtpJoinDate.MaxDate = Today

            LoadLookupDataCombo(Me.cboMemberTypeID, LookupObjects.MemberType, False)
            LoadLookupDataCombo(Me.cboGenderID, LookupObjects.Gender, False)

            Me.MemberStatus()
            Me.LoadInsuranceSchemesCompanies()
            Me.LoadInsuranceSchemesInsurances()

            If oPatients IsNot Nothing AndAlso Not String.IsNullOrEmpty(oPatients.DefaultBillNo) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.Save()
                Me.cboMedicalCardNo.Enabled = True
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                With oPatients
                    Me.cboMedicalCardNo.Text = FormatText(.DefaultBillNo, "SchemeMembers", "MedicalCardNo")
                    Me.stbReferenceNo.Text = .ReferenceNo
                    Me.stbSurname.Text = .Surname
                    Me.stbFirstName.Text = .FirstName
                    Me.stbMiddleName.Text = .MiddleName
                    Me.dtpBirthDate.Value = .BirthDate
                    Me.nbxAge.Value = GetAge(.BirthDate).ToString()
                    Me.spbPhoto.Image = GetImage(.Photo)
                    Me.cboGenderID.SelectedValue = .GenderID
                    Me.stbAddress.Text = .Address
                    Me.stbPhoneWork.Text = .Phone
                    Me.stbEmail.Text = .Email
                End With
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmSchemeMembers_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

   

    Private Sub btnLoadPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPhoto.Click
        Me.spbPhoto.LoadPhoto(Me.spbPhoto.ImageSizeLimit)
    End Sub

    Private Sub btnClearPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearPhoto.Click
        Me.spbPhoto.DeletePhoto()
    End Sub

    Private Sub MemberStatus()

        Dim oLookupData As New LookupData()
        Dim oGenderID As New LookupDataID.GenderID()
        Dim oStatusID As New LookupCommDataID.StatusID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim genderLookupData As DataTable = oLookupData.GetLookupData(LookupObjects.Gender).Tables("LookupData")

            If genderLookupData IsNot Nothing Then

                For Each row As DataRow In genderLookupData.Rows
                    If Not (oGenderID.Male.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) OrElse
                            oGenderID.Female.ToUpper().Equals(row.Item("DataID").ToString().ToUpper())) Then
                        row.Delete()
                    End If
                Next

                Me.cboGenderID.DataSource = genderLookupData

                Me.cboGenderID.DisplayMember = "DataDes"
                Me.cboGenderID.ValueMember = "DataID"

                Me.cboGenderID.SelectedIndex = -1
                Me.cboGenderID.SelectedIndex = -1

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusLookupData As DataTable = oLookupData.GetLookupData(LookupCommObjects.Status).Tables("LookupData")
            If statusLookupData Is Nothing Then Return

            For Each row As DataRow In statusLookupData.Rows
                If oStatusID.Active.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) OrElse
                    oStatusID.Inactive.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) Then
                    Continue For
                Else : row.Delete()
                End If
            Next

            Me.fcbStatusID.DataSource = statusLookupData

            Me.fcbStatusID.DisplayMember = "DataDes"
            Me.fcbStatusID.ValueMember = "DataID"

            Me.fcbStatusID.SelectedValue = oStatusID.Active
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadInsuranceSchemesCompanies()

        Dim oInsuranceSchemes As New SyncSoft.SQLDb.InsuranceSchemes()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load Companies from InsuranceSchemes

            insuranceSchemesCompanies = oInsuranceSchemes.GetInsuranceSchemesCompanies().Tables("InsuranceSchemes")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboCompanyNo, insuranceSchemesCompanies, "CompanyFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadInsuranceSchemesInsurances()

        Dim oInsuranceSchemes As New SyncSoft.SQLDb.InsuranceSchemes()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from Insurances

            Dim insuranceSchemesInsurances As DataTable = oInsuranceSchemes.GetInsuranceSchemesInsurances().Tables("InsuranceSchemes")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboInsuranceNo.Sorted = False
            Me.cboInsuranceNo.DataSource = insuranceSchemesInsurances
            Me.cboInsuranceNo.DisplayMember = "InsuranceName"
            Me.cboInsuranceNo.ValueMember = "InsuranceNo"

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearControls()
        Me.stbSchemeStartDate.Clear()
        Me.stbSchemeEndDate.Clear()
        Me.stbCoPayType.Clear()
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        Me.dtpPolicyStartDate.Value = Today
        Me.dtpPolicyEndDate.Value = Today
        Me.dtpPolicyStartDate.Checked = False
        Me.dtpPolicyEndDate.Checked = False
    End Sub

    Private Sub ClearCompanyName(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCompanyNo.SelectedIndexChanged, cboCompanyNo.TextChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.stbCompanyName.Clear()
    End Sub

    Private Sub cboCompanyNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCompanyNo.Leave

        Dim companyName As String

        Try
            Dim companyNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboCompanyNo)))

            Me.cboCompanyNo.Text = FormatText(companyNo, "Companies", "companyNo")

            If String.IsNullOrEmpty(companyNo) Then Return

            For Each row As DataRow In insuranceSchemesCompanies.Select("companyNo = '" + companyNo + "'")

                If Not IsDBNull(row.Item("companyName")) Then
                    companyName = StringEnteredIn(row, "companyName")
                    companyNo = StringMayBeEnteredIn(row, "companyNo")
                    Me.cboCompanyNo.Text = FormatText(companyNo.ToUpper(), "Companies", "companyNo")
                Else
                    companyName = String.Empty
                    companyNo = String.Empty
                End If

                Me.stbCompanyName.Text = companyName
            Next

            Me.ShowInsuranceSchemes()

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub ShowInsuranceSchemes()

        Dim oInsuranceSchemes As New SyncSoft.SQLDb.InsuranceSchemes()
        
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim companyNo As String = RevertText(StringMayBeEnteredIn(Me.cboCompanyNo))
            Dim policyNo As String = RevertText(StringValueMayBeEnteredIn(Me.cboPolicyNo, "Policy No!"))

            If String.IsNullOrEmpty(companyNo) OrElse String.IsNullOrEmpty(policyNo) Then Return

            Me.ClearControls()

            Dim insuranceSchemes As DataTable = oInsuranceSchemes.GetInsuranceSchemes(companyNo, policyNo).Tables("InsuranceSchemes")

            Dim row As DataRow = insuranceSchemes.Rows(0)

            Dim schemeStartDate As Date = DateMayBeEnteredIn(row, "SchemeStartDate")
            Dim schemeEndDate As Date = DateMayBeEnteredIn(row, "SchemeEndDate")

            Me.stbSchemeStartDate.Text = FormatDate(schemeStartDate)
            Me.stbSchemeEndDate.Text = FormatDate(schemeEndDate)
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                Me.dtpJoinDate.Value = schemeStartDate
                Me.dtpJoinDate.Checked = False
                Me.dtpPolicyStartDate.Value = schemeStartDate
                Me.dtpPolicyStartDate.Checked = False
                Me.dtpPolicyEndDate.Value = schemeEndDate
                Me.dtpPolicyEndDate.Checked = False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboPolicyNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPolicyNo.Leave
        Me.ShowInsuranceSchemes()
    End Sub

    Private Sub cboMemberTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMemberTypeID.SelectedIndexChanged
        Me.SetAutoNumbers()
    End Sub

    Private Sub stbMainMemberNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbMainMemberNo.Leave

        Try
            Me.SetNextDependantMedicalCardNo()
            Me.stbMainMemberNo.Text = FormatText(StringMayBeEnteredIn(Me.stbMainMemberNo), "SchemeMembers", "MainMemberNo")

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub ResetMainMemberNo()

        Dim oMemberTypeID As New LookupDataID.MemberTypeID()

        Try

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim memberTypeID As String = StringValueMayBeEnteredIn(Me.cboMemberTypeID, "Member Type!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If memberTypeID.ToUpper().Equals(oMemberTypeID.Staff.ToUpper()) Then
                Me.stbMainMemberNo.Text = FormatText(StringMayBeEnteredIn(Me.cboMedicalCardNo), "SchemeMembers", "MainMemberNo")
                Me.stbMainMemberNo.ReadOnly = True
                Me.stbRelationship.Text = String.Empty
                Me.stbRelationship.Enabled = False
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SetAutoNumbers()

        Dim oMemberTypeID As New LookupDataID.MemberTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim memberTypeID As String = StringValueMayBeEnteredIn(Me.cboMemberTypeID, "Member Type!")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(memberTypeID) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If memberTypeID.ToUpper().Equals(oMemberTypeID.Staff.ToUpper()) Then

                If oPatients IsNot Nothing AndAlso Not String.IsNullOrEmpty(oPatients.DefaultBillNo) Then
                    Me.cboMedicalCardNo.Text = FormatText(oPatients.DefaultBillNo, "SchemeMembers", "MedicalCardNo")
                Else : Me.SetNextMainMemberMedicalCardNo()
                End If

                Me.stbMainMemberNo.Text = FormatText(StringMayBeEnteredIn(Me.cboMedicalCardNo), "SchemeMembers", "MainMemberNo")
                Me.stbMainMemberNo.ReadOnly = True
                Me.stbRelationship.Text = String.Empty
                Me.stbRelationship.Enabled = False

            ElseIf memberTypeID.ToUpper().Equals(oMemberTypeID.Dependant.ToUpper()) Then

                If oPatients IsNot Nothing AndAlso Not String.IsNullOrEmpty(oPatients.DefaultBillNo) Then
                    Me.cboMedicalCardNo.Text = FormatText(oPatients.DefaultBillNo, "SchemeMembers", "MedicalCardNo")
                    Me.stbMainMemberNo.Text = String.Empty
                    Me.stbMainMemberNo.ReadOnly = False
                Else
                    Me.cboMedicalCardNo.Text = String.Empty
                    Me.stbMainMemberNo.Text = String.Empty
                    Me.stbMainMemberNo.ReadOnly = False
                End If

                Me.stbRelationship.Enabled = True

            Else

                If oPatients IsNot Nothing AndAlso Not String.IsNullOrEmpty(oPatients.DefaultBillNo) Then
                    Me.cboMedicalCardNo.Text = FormatText(oPatients.DefaultBillNo, "SchemeMembers", "MedicalCardNo")
                    Me.stbMainMemberNo.Text = String.Empty
                    Me.stbMainMemberNo.ReadOnly = False
                Else
                    Me.cboMedicalCardNo.Text = String.Empty
                    Me.stbMainMemberNo.Text = String.Empty
                    Me.stbMainMemberNo.ReadOnly = InitOptions.MainMemberNoLocked
                End If

                Me.stbRelationship.Enabled = True
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function GetMedicalCardNoPostfix() As String

        Try

            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("SchemeMembers", "MainMemberNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Return (0).ToString().PadLeft(paddingLEN, paddingCHAR)

        Catch eX As Exception
            Throw eX

        End Try

    End Function

    Private Sub SetNextMainMemberMedicalCardNo()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oVariousOptions As New VariousOptions()

            Dim oSchemeMembers As New SyncSoft.SQLDb.SchemeMembers()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim medicalCardNoPrefix As String = oVariousOptions.MedicalCardNoPrefix + Today.Year.ToString().Substring(2)
            Dim medicalCardNoPostfix As String = Me.GetMedicalCardNoPostfix()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("SchemeMembers", "MedicalCardNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))
            Dim nextMedicalCardNo As String = CStr(oSchemeMembers.GetNextMedicalCardID).PadLeft(paddingLEN, paddingCHAR)
            Me.cboMedicalCardNo.Text = FormatText(medicalCardNoPrefix.Trim() + nextMedicalCardNo.Trim() + medicalCardNoPostfix.Trim(), "SchemeMembers", "MedicalCardNo")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetNextDependantMedicalCardNo()

        Dim oMemberTypeID As New LookupDataID.MemberTypeID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim memberLength As Integer = 0

            Dim memberTypeID As String = StringValueMayBeEnteredIn(Me.cboMemberTypeID, "Member Type!")
            Dim mainMemberNo As String = RevertText(StringMayBeEnteredIn(Me.stbMainMemberNo))

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
            If String.IsNullOrEmpty(memberTypeID) Then Return
            If String.IsNullOrEmpty(mainMemberNo) Then Return
            If Not memberTypeID.ToUpper().Equals(oMemberTypeID.Dependant.ToUpper()) Then Return
            If oPatients IsNot Nothing AndAlso Not String.IsNullOrEmpty(oPatients.DefaultBillNo) Then Return

            Dim oSchemeMembers As New SyncSoft.SQLDb.SchemeMembers()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("SchemeMembers", "MainMemberNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim mainMemberID As String = oSchemeMembers.GetNextMainMemberID(mainMemberNo).ToString()
            mainMemberID = mainMemberID.PadLeft(paddingLEN, paddingCHAR)

            If (mainMemberNo.Length > paddingLEN) Then
                memberLength = mainMemberNo.Length - paddingLEN
            Else : memberLength = mainMemberNo.Length
            End If

            If mainMemberNo.ToUpper().EndsWith(Me.GetMedicalCardNoPostfix().ToUpper()) Then
                Me.cboMedicalCardNo.Text = FormatText(mainMemberNo.Substring(0, memberLength) + mainMemberID.Trim(), "SchemeMembers", "MainMemberNo")
            Else : Me.cboMedicalCardNo.Text = FormatText(mainMemberNo + mainMemberID.Trim(), "SchemeMembers", "MainMemberNo")
            End If

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Insurance Schemes "

    Private Sub cboInsuranceNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInsuranceNo.SelectedIndexChanged

        Try

            Dim insuranceNo As String
            If Me.cboInsuranceNo.SelectedValue Is Nothing OrElse String.IsNullOrEmpty(Me.cboInsuranceNo.SelectedValue.ToString()) Then
                insuranceNo = String.Empty
            Else : insuranceNo = StringValueEnteredIn(Me.cboInsuranceNo, "Insurance Policy!")
            End If

            Me.LoadInsuranceSchemes(insuranceNo)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub LoadInsuranceSchemes(ByVal insuranceNo As String)

        Dim oInsuranceSchemes As New SyncSoft.SQLDb.InsuranceSchemes()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.cboPolicyNo.DataSource = Nothing
            If String.IsNullOrEmpty(insuranceNo) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Load all from InsuranceSchemes
            Dim insuranceSchemes As DataTable = oInsuranceSchemes.GetInsuranceSchemes(insuranceNo).Tables("InsuranceSchemes")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboPolicyNo.Sorted = False
            Me.cboPolicyNo.DataSource = insuranceSchemes
            Me.cboPolicyNo.DisplayMember = "PolicyName"
            Me.cboPolicyNo.ValueMember = "PolicyNo"

            Me.cboPolicyNo.SelectedIndex = -1
            Me.cboPolicyNo.SelectedIndex = -1
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Fingerprint Enrollment "

    Private Sub btnEnrollFingerprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnrollFingerprint.Click

        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try

            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then
                Dim fFingerprintCapture As New FingerprintCapture(CaptureType.Enroll)
                fFingerprintCapture.ShowDialog()
                Me.chkFingerprintCaptured.Checked = (Me.oCrossMatchTemplate.Fingerprint IsNot Nothing)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then
                Dim fEnrollment As New Enrollment()
                fEnrollment.ShowDialog()
                Me.chkFingerprintCaptured.Checked = (Me.oDigitalPersonaTemplate.Template IsNot Nothing)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

#End Region

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oSchemeMembers As New SyncSoft.SQLDb.SchemeMembers()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oSchemeMembers.MedicalCardNo = RevertText(StringEnteredIn(Me.cboMedicalCardNo, "Medical Card No!"))
            DisplayMessage(oSchemeMembers.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpBirthDate.Value = Today
            Me.oCrossMatchTemplate.Fingerprint = Nothing
            Me.oDigitalPersonaTemplate.Template = Nothing
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me)
            Me.CallOnKeyEdit()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oMemberTypeID As New LookupDataID.MemberTypeID()
        Dim oSchemeMembers As New SyncSoft.SQLDb.SchemeMembers()
        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim medicalCardNo As String = RevertText(StringEnteredIn(Me.cboMedicalCardNo, "Medical Card No!"))
            Dim dataSource As DataTable = oSchemeMembers.GetSchemeMembers(medicalCardNo).Tables("SchemeMembers")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim _InsuranceSchemes As EnumerableRowCollection(Of DataRow) = dataSource.AsEnumerable()
            Dim insuranceNo As String = (From data In _InsuranceSchemes Select data.Field(Of String)("InsuranceNo")).First()
            Dim policyNo As String = (From data In _InsuranceSchemes Select data.Field(Of String)("PolicyNo")).First()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(insuranceNo) Then Me.LoadInsuranceSchemes(insuranceNo)
            Me.cboInsuranceNo.SelectedValue = insuranceNo
            Me.cboPolicyNo.SelectedValue = policyNo

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DisplayData(dataSource)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboMedicalCardNo.Text = FormatText(StringMayBeEnteredIn(Me.cboMedicalCardNo), "SchemeMembers", "MedicalCardNo")
            Me.stbMainMemberNo.Text = FormatText(StringMayBeEnteredIn(Me.stbMainMemberNo), "SchemeMembers", "MainMemberNo")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim memberTypeID As String = StringValueMayBeEnteredIn(Me.cboMemberTypeID, "Member Type!")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbRelationship.Enabled = Not memberTypeID.ToUpper().Equals(oMemberTypeID.Staff.ToUpper())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patient As EnumerableRowCollection(Of DataRow) = dataSource.AsEnumerable()
            Dim fingerprint As Byte() = (From data In patient Select data.Field(Of Byte())("Fingerprint")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then
                Me.oCrossMatchTemplate.Fingerprint = fingerprint
                Me.chkFingerprintCaptured.Checked = (Me.oCrossMatchTemplate.Fingerprint IsNot Nothing)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then
                Me.oDigitalPersonaTemplate.Template = GetDigitalPersonaTemplate(fingerprint)
                Me.chkFingerprintCaptured.Checked = (Me.oDigitalPersonaTemplate.Template IsNot Nothing)

            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim message As String
        Dim oMemberTypeID As New LookupDataID.MemberTypeID()
        Dim oSchemeMembers As New SyncSoft.SQLDb.SchemeMembers()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()
        Dim oVariousOptions As New VariousOptions()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oSchemeMembers

                .MemberTypeID = StringValueEnteredIn(Me.cboMemberTypeID, "Member Type!")
                .MainMemberNo = RevertText(StringMayBeEnteredIn(Me.stbMainMemberNo))
                .MedicalCardNo = RevertText(StringEnteredIn(Me.cboMedicalCardNo, "Medical Card No!"))
                .CompanyNo = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
                StringValueEnteredIn(Me.cboInsuranceNo, "Insurance Name!")
                .PolicyNo = StringValueEnteredIn(Me.cboPolicyNo, "Policy Name!")
                .ReferenceNo = StringMayBeEnteredIn(Me.stbReferenceNo)
                .Surname = StringEnteredIn(Me.stbSurname, "Surname!")
                .FirstName = StringEnteredIn(Me.stbFirstName, "First Name!")
                .MiddleName = StringMayBeEnteredIn(Me.stbMiddleName)
                .BirthDate = DateEnteredIn(Me.dtpBirthDate, "Birth Date!")
                .GenderID = StringValueEnteredIn(Me.cboGenderID, "Gender!")
                .PhoneWork = StringMayBeEnteredIn(Me.stbPhoneWork)
                .PhoneMobile = StringMayBeEnteredIn(Me.stbPhoneMobile)
                .PhoneHome = StringMayBeEnteredIn(Me.stbPhoneHome)
                .Email = StringMayBeEnteredIn(Me.stbEmail)
                .Photo = BytesMayBeEnteredIn(Me.spbPhoto)

                If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) AndAlso
                     oCrossMatchTemplate.Fingerprint IsNot Nothing Then
                    .Fingerprint = oCrossMatchTemplate.Fingerprint

                ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) AndAlso
                    (oDigitalPersonaTemplate.Template IsNot Nothing) Then
                    .Fingerprint = oDigitalPersonaTemplate.Template.Bytes

                Else : .Fingerprint = Nothing
                End If

                .Address = StringMayBeEnteredIn(Me.stbAddress)
                .JoinDate = DateEnteredIn(Me.dtpJoinDate, "Join Date!")
                .Relationship = StringMayBeEnteredIn(Me.stbRelationship)
                .PolicyStartDate = DateEnteredIn(Me.dtpPolicyStartDate, "Policy Start Date!")
                .PolicyEndDate = DateEnteredIn(Me.dtpPolicyEndDate, "Policy End Date!")
                .MemberStatusID = StringValueEnteredIn(Me.fcbStatusID, "Member Status!")
                .LoginID = CurrentUser.LoginID

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ValidateEntriesIn(Me, ErrProvider)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not oSchemeMembers.BirthDate.Equals(AppData.NullDateValue) AndAlso
                Not oSchemeMembers.JoinDate.Equals(AppData.NullDateValue) Then
                message = "Join date can't be before birth date!"
                If oSchemeMembers.JoinDate < oSchemeMembers.BirthDate Then Throw New ArgumentException(message)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oSchemeMembers.MemberTypeID.ToUpper().Equals(oMemberTypeID.Dependant) Then
                If String.IsNullOrEmpty(oSchemeMembers.MainMemberNo.Trim()) Then
                    message = "You have not entered a Main Member No for this Dependant. " +
                               ControlChars.NewLine + "Are you sure you want to save?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.stbMainMemberNo.Focus() : Return
                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oVariousOptions.IncorporateFingerprintCapture Then
                If (oSchemeMembers.Fingerprint Is Nothing) Then
                    message = "You have not enrolled fingerprint for this Patient. " +
                              "It’s recommended that you enroll fingerprint for verification purposes. " +
                               ControlChars.NewLine + "Are you sure you want to save?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.btnEnrollFingerprint.Focus() : Return
                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If IsCharacterInString(oSchemeMembers.MedicalCardNo) Then
                        message = "Medical Card No contains a space (' '), an invalid character. " +
                                   ControlChars.NewLine + "Are you sure you want to save?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.cboMedicalCardNo.Focus() : Return
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    oSchemeMembers.Save()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    Me.oCrossMatchTemplate.Fingerprint = Nothing
                    Me.oDigitalPersonaTemplate.Template = Nothing
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oSchemeMembers.Update())
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
        '' LoadSchemeMembers()
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        Me.pnlStatusID.Enabled = True

        Me.stbMainMemberNo.ReadOnly = False
        Me.cboMedicalCardNo.Enabled = True

        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlStatusID)
        Me.oCrossMatchTemplate.Fingerprint = Nothing
        Me.oDigitalPersonaTemplate.Template = Nothing

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        '' LoadSchemeMembers()
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.pnlStatusID.Enabled = False

        Me.stbMainMemberNo.ReadOnly = InitOptions.MainMemberNoLocked
        Me.cboMedicalCardNo.Enabled = InitOptions.MedicalCardNoLocked

        ResetControlsIn(Me)

        '' Me.MemberStatus()
        Me.oCrossMatchTemplate.Fingerprint = Nothing
        Me.oDigitalPersonaTemplate.Template = Nothing

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

    Private Sub LoadSchemeMembers()

        Dim oSchemeMember As New SyncSoft.SQLDb.SchemeMembers()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim schemeMember As DataTable = oSchemeMember.GetSchemeMembers().Tables("SchemeMembers")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboMedicalCardNo, schemeMember, "MemberFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub cboMedicalCardNo_Leave(sender As Object, e As EventArgs) Handles cboMedicalCardNo.Leave
        cboMedicalCardNo.Text = SubstringRight(RevertText(StringMayBeEnteredIn(Me.cboMedicalCardNo)))
    End Sub

#End Region

End Class