Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects

Imports System.Collections.Generic

Public Class frmLabResults

#Region " Fields "
    Private tipCoPayValueWords As New ToolTip()
    Private oResultFlagID As New LookupDataID.ResultFlagID()
    Private labTests As New DataTable()
    Private labDoctorNotes As New DataTable()
    Private resultDataType As String = String.Empty
    Private hasSubTests As Boolean = False
    Private labTestsEXT As New DataTable()
    Private _SubTestCodeValue As String = String.Empty
    Private attendingDoctorNo As String = String.Empty
    Private labRequestsCount As Integer = 0
    Private totalLabRequests As Integer = 0
    Private patientpackageNo As String = String.Empty
    Private hasPackage As Boolean = False
    Private doctorStaffNo As String = String.Empty
#End Region

#Region " Validations "

    Private Sub dtpTestDateTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpTestDateTime.Validating

        Dim errorMSG As String = "Test date and time can't be before drawn date and time!"

        Try

            Dim drawnDateTime As Date = DateTimeMayBeEnteredIn(Me.stbDrawnDateTime)
            Dim testDateTime As Date = DateTimeMayBeEnteredIn(Me.dtpTestDateTime)

            If testDateTime = AppData.NullDateValue Then Return

            If testDateTime < drawnDateTime Then
                ErrProvider.SetError(Me.dtpTestDateTime, errorMSG)
                Me.dtpTestDateTime.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpTestDateTime, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub


    Private Sub frmLabResults_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub cboResult_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboResult.Validating

        Dim _Number As String
        Dim _Decimal As String
        Dim _String As String

        Try

            Dim oLookupData As New LookupData()
            Dim oDataTypeID As New LookupCommDataID.SearchDataTypeID()

            Dim errorMSG As String = "Result should be numeric!"
            Dim result As String = StringMayBeEnteredIn(Me.cboResult)
            If String.IsNullOrEmpty(result) OrElse String.IsNullOrEmpty(Me.cboTestCode.Text.Trim()) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            _Number = SubstringLeft(oLookupData.GetLookupDataName(oDataTypeID.Number, LookupCommObjects.SearchDataType)).Trim()
            _Decimal = SubstringLeft(oLookupData.GetLookupDataName(oDataTypeID.Decimal, LookupCommObjects.SearchDataType)).Trim()
            _String = SubstringLeft(oLookupData.GetLookupDataName(oDataTypeID.String, LookupCommObjects.SearchDataType)).Trim()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case resultDataType

                Case _Number, _Decimal
                    If Not IsNumeric(result) Then
                        ErrProvider.SetError(Me.cboResult, errorMSG)
                        Me.cboResult.Focus()
                        e.Cancel = True
                    Else : ErrProvider.SetError(Me.cboResult, String.Empty)
                    End If

                Case Else : ErrProvider.SetError(Me.cboResult, String.Empty)

            End Select

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region
    Private Sub frmLabResults_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.dtpTestDateTime.MaxDate = Today.AddDays(1)
            Me.dtpTestDateTime.Value = Now
            Me.LoadStaff()

            LoadLookupDataCombo(Me.cboResultFlagID, LookupObjects.ResultFlag, False)
            LoadLookupDataCombo(Me.cboEntryModeID, LookupObjects.EntryMode, True)
            LoadLookupDataCombo(Me.colResultFlagID, LookupObjects.ResultFlag, False)
            LoadLookupDataCombo(Me.clbSpecimenDescription, LookupObjects.SpecimenDescription, False)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.LabTechnologist).Tables("Staff")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboLabTechnologist, staff, "StaffFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnFindSpecimenNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindSpecimenNo.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindSpecimenNo As New frmFindAutoNo(Me.stbSpecimenNo, AutoNumber.SpecimenNo)
        fFindSpecimenNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim specimenNo As String = RevertText(StringMayBeEnteredIn(Me.stbSpecimenNo))
        If String.IsNullOrEmpty(specimenNo) Then Return
        Me.LoadLabTestsResults(specimenNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub SetDefaultControls()

        Try

            Dim oEntryModeID As New LookupDataID.EntryModeID()

            Me.cboResultFlagID.SelectedValue = oResultFlagID.NA
            Me.cboEntryModeID.SelectedValue = oEntryModeID.Manual

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub ClearControls()

        Me.ResetControls()
        Me.ClearResultControls()
        Me.cboTestCode.Items.Clear()
        Me.dgvLabResultsEXT.Rows.Clear()

    End Sub

    Private Sub ClearResultControls()

        Me.stbNormalRange.Clear()
        Me.cboResult.SelectedIndex = -1
        Me.cboResult.SelectedIndex = -1
        Me.cboResult.Text = String.Empty
        Me.cboResultFlagID.SelectedValue = oResultFlagID.NA
        Me.stbUnitMeasure.Clear()
        Me.btnImportLabResults.Enabled = False

    End Sub

    Private Sub ResetControls()

        Me.clbSpecimenDescription.ClearSelected()
        Me.stbDrawnDateTime.Clear()
        attendingDoctorNo = String.Empty
        doctorStaffNo = String.Empty
        patientpackageNo = String.Empty
        hasPackage = False
        Me.stbVisitNo.Clear()
        Me.stbAttendingDoctor.Clear()
        Me.stbRoundNo.Clear()
        Me.stbFullName.Clear()
        Me.stbPatientNo.Clear()
        Me.stbPhoneNo.Clear()
        Me.stbAge.Clear()
        Me.stbGender.Clear()
        Me.lblAgeString.Text = String.Empty
        Me.cboLabTechnologist.SelectedIndex = -1
        Me.cboLabTechnologist.SelectedIndex = -1
        Me.stbCoPayType.Clear()
        Me.stbPrimaryDoctor.Clear()
        Me.chkIsAdmitted.Checked = False
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()

    End Sub

    Private Sub txtSpecimenNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbSpecimenNo.Leave

        Dim specimenNo As String = RevertText(StringMayBeEnteredIn(Me.stbSpecimenNo))
        If String.IsNullOrEmpty(specimenNo) Then Return
        Me.LoadLabTestsResults(specimenNo)

    End Sub

    Private Sub txtSpecimenNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbSpecimenNo.TextChanged
        Me.CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ClearControls()
    End Sub

    Private Sub SetTestDateTime()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                Dim drawnDate As Date = DateMayBeEnteredIn(Me.stbDrawnDateTime)
                If drawnDate = AppData.NullDateValue Then Return

                If Not drawnDate.Equals(Today) Then
                    Me.dtpTestDateTime.Value = DateTimeMayBeEnteredIn(Me.stbDrawnDateTime)
                    Me.dtpTestDateTime.Checked = False
                Else : Me.dtpTestDateTime.Value = Now
                End If
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub LoadLabTestsResults(ByVal specimenNo As String)

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()

        Dim oLabRequests As New SyncSoft.SQLDb.LabRequests()
        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim iPDItems As New DataTable()
        Dim items As New DataTable()
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ResetControls()

            If String.IsNullOrEmpty(specimenNo) Then Return

            Dim labRequests As DataTable = oLabRequests.GetLabRequests(specimenNo).Tables("LabRequests")
            If labRequests Is Nothing OrElse labRequests.Rows.Count < 1 Then Return

            Dim row As DataRow = labRequests.Rows(0)
            Dim visitNo As String = RevertText(StringEnteredIn(row, "VisitNo"))
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(row, "RoundNo"))

            Me.stbSpecimenNo.Text = FormatText(specimenNo, "LabRequests", "SpecimenNo")
            CheckListItems(clbSpecimenDescription, StringMayBeEnteredIn(row, "SpecimenDes"))
            Me.stbDrawnDateTime.Text = FormatDateTime(DateTimeEnteredIn(row, "DrawnDateTime"))
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Me.stbPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Dim birthDate As Date = DateMayBeEnteredIn(row, "BirthDate")
            Me.lblAgeString.Text = GetAgeString(birthDate, True)
            Me.stbAttendingDoctor.Text = StringMayBeEnteredIn(row, "AttendingDoctor")
            Me.stbRoundNo.Text = StringMayBeEnteredIn(row, "RoundNo")
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
            Me.stbPrimaryDoctor.Text = StringMayBeEnteredIn(row, "PrimaryDoctor")

            attendingDoctorNo = StringMayBeEnteredIn(row, "AttendingDoctorNo")
            doctorStaffNo = StringMayBeEnteredIn(row, "DoctorStaffNo")
            totalLabRequests = IntegerMayBeEnteredIn(row, "TotalLabRequests")

            hasPackage = BooleanMayBeEnteredIn(row, "HasIPDPackage")
            patientpackageNo = StringMayBeEnteredIn(row, "PackageNo")
            Me.stbPhoneNo.Text = StringMayBeEnteredIn(row, "PhoneNo")
            Me.chkIsAdmitted.Checked = BooleanMayBeEnteredIn(row, "IsAdmitted")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboLabTechnologist.Text = oStaff.GetCurrentStaffFullName
            Me.SetTestDateTime()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If chkIsAdmitted.Checked = True Then

                If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                    'load requested
                    iPDItems = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Test, oItemStatusID.Processing).Tables("IPDItems")
                    labRequestsCount = iPDItems.Rows.Count
                ElseIf Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
                    'load done
                    iPDItems = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Test, oItemStatusID.Done).Tables("IPDItems")
                End If

                Me.cboTestCode.Items.Clear()
                LoadComboData(Me.cboTestCode, iPDItems, "ItemFullName")

            End If


            If chkIsAdmitted.Checked = False Then

                If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                    items = oItems.GetItems(visitNo, oItemCategoryID.Test, oItemStatusID.Processing).Tables("Items")
                    labRequestsCount = items.Rows.Count
                ElseIf Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
                    items = oItems.GetItems(visitNo, oItemCategoryID.Test, oItemStatusID.Done).Tables("Items")
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Me.btnReject.Enabled = Items.Rows.Count > 0
                Me.cboTestCode.Items.Clear()
                LoadComboData(Me.cboTestCode, items, "ItemFullName")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboTestCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTestCode.SelectedIndexChanged
        Me.GetLabTests()
        Me.CallOnKeyEdit()
    End Sub

    Private Sub GetLabTests()

        Dim oLabTests As New SyncSoft.SQLDb.LabTests()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearResultControls()

            Dim testCode As String = SubstringRight(Me.cboTestCode.Text)
            Dim specimenNo As String = RevertText(StringEnteredIn(Me.stbSpecimenNo))
            If String.IsNullOrEmpty(testCode) Then Return
            labTests = oLabTests.GetLabTests(testCode).Tables("LabTests")
            labDoctorNotes = oLabTests.GetLabDoctorNotes(testCode, specimenNo).Tables("LabTests")

            If labTests Is Nothing OrElse labTests.Rows.Count < 1 Then Return

            Me.stbNormalRange.Text = labTests.Rows(0).Item("NormalRange").ToString()
            Me.stbUnitMeasure.Text = labTests.Rows(0).Item("UnitMeasure").ToString()
            Me.stbDoctorNotes.Text = labDoctorNotes.Rows(0).Item("ItemDetails").ToString()
            resultDataType = labTests.Rows(0).Item("ResultDataType").ToString()

            Me.LoadLabPossibleResults(testCode)

            hasSubTests = CBool(labTests.Rows(0).Item("HasSubTests"))

            If hasSubTests Then
                Me.ShowLabResultsEXT(True)
                Me.LoadLabTestsEXT(testCode)
            Else : Me.ShowLabResultsEXT(False)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetTestDateTime()
            Me.btnImportLabResults.Enabled = True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub LoadLabPossibleResults(ByVal testCode As String)

        Dim oLabPossibleResults As New SyncSoft.SQLDb.LabPossibleResults()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.cboResult.Items.Clear()

            Dim labPossibleResults As DataTable = oLabPossibleResults.GetLabPossibleResults(testCode).Tables("LabPossibleResults")

            If labPossibleResults.Rows.Count > 0 Then
                LoadComboData(Me.cboResult, labPossibleResults, "PossibleResult")
                Me.cboResult.DropDownStyle = ComboBoxStyle.DropDownList
            Else : Me.cboResult.DropDownStyle = ComboBoxStyle.DropDown
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub LoadLabTestsEXT(ByVal testCode As String)

        Dim oLabTestsEXT As New SyncSoft.SQLDb.LabTestsEXT()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.dgvLabResultsEXT.Rows.Clear()

            If String.IsNullOrEmpty(testCode) Then Return
            labTestsEXT = oLabTestsEXT.GetLabTestsEXT(testCode, False).Tables("LabTestsEXT")
            If labTestsEXT Is Nothing OrElse labTestsEXT.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colSubTestCode.Sorted = False
            Me.colSubTestCode.DataSource = labTestsEXT
            Me.colSubTestCode.DisplayMember = "SubTestName"
            Me.colSubTestCode.ValueMember = "SubTestCode"

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''Display Lab Tests EXTRA
            For pos As Integer = 0 To labTestsEXT.Rows.Count - 1
                With Me.dgvLabResultsEXT
                    ' Ensure that you add a new row first
                    .Rows.Add()
                    .Item(Me.colSubTestCode.Name, pos).Value = labTestsEXT.Rows(pos).Item("SubTestCode")
                    .Item(Me.colNormalRange.Name, pos).Value = labTestsEXT.Rows(pos).Item("NormalRange")
                    .Item(Me.colUnitMeasure.Name, pos).Value = labTestsEXT.Rows(pos).Item("UnitMeasure")
                    .Item(Me.colResultFlagID.Name, pos).Value = oResultFlagID.NA
                    .Item(Me.colResultDataTypeID.Name, pos).Value = labTestsEXT.Rows(pos).Item("ResultDataTypeID")
                    .Item(Me.colInclude.Name, pos).Value = True
                End With
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowLabResultsEXT(ByVal show As Boolean)

        If show Then
            Me.Size = New Size(809, 598)
            Me.grpLabResultsEXT.SendToBack()
            Me.grpLabResultsEXT.Visible = True
        Else
            Me.Size = New Size(809, 350)
            Me.grpLabResultsEXT.Visible = False
        End If

    End Sub

    Private Sub stbNormalRange_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbNormalRange.Leave
        Me.SetLabResultFlag()
    End Sub

    Private Sub cboResult_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboResult.SelectedIndexChanged

        Try

            Me.cboResultFlagID.SelectedValue = oResultFlagID.NA

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cboResult_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboResult.Leave
        Me.SetLabResultFlag()
    End Sub

    Private Sub SetLabResultFlag()

        Try

            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim normalRange As String = StringMayBeEnteredIn(Me.stbNormalRange)
            Dim result As String = StringMayBeEnteredIn(Me.cboResult)

            Me.cboResultFlagID.SelectedValue = GetLabResultFlag(resultDataType, gender, normalRange, result)

        Catch ex As Exception
            Return
        End Try

    End Sub

#Region " Utilities "

    Private Sub btnLoadList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadList.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fPendingIPDLabResults As New frmPendingAllLabResults(Me.stbSpecimenNo)
        fPendingIPDLabResults.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim specimenNo As String = RevertText(StringMayBeEnteredIn(Me.stbSpecimenNo))
        If String.IsNullOrEmpty(specimenNo) Then Return
        Me.LoadLabTestsResults(specimenNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnViewTemplates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewTemplates.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oTemplateTypeID As New LookupDataID.TemplateTypeID()
        Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.LabResults, Me.stbReport)
        fGetTemplates.ShowDialog(Me)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnImportLabResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportLabResults.Click

        Dim message As String
        Dim oImportDataInfo As New SyncSoft.SQLDb.ImportDataInfo()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim testCode As String = SubstringEnteredIn(Me.cboTestCode, "Lab Test!")
            Dim testName As String = SubstringLeft(StringMayBeEnteredIn(Me.cboTestCode))
            Dim importDataInfo As DataTable = oImportDataInfo.GetImportDataSources(testCode).Tables("ImportDataInfo")
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)

            message = "Lab Test: " + testName + ", is not configured for external lab results importation"
            If importDataInfo.Rows.Count < 1 Then Throw New ArgumentException(message)
            Dim fGetExternalLabResults As New frmGetExternalLabResults(testCode, importDataInfo, patientNo)
            fGetExternalLabResults.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim results As Dictionary(Of String, String) = ExternalLabResults.Results
            If results.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvLabResultsEXT.Rows
                If row.IsNewRow Then Exit For

                With Me.dgvLabResultsEXT

                    Dim subTestName As String = String.Empty

                    Try

                        subTestName = .Item(Me.colSubTestCode.Name, row.Index).FormattedValue.ToString()
                        .Item(Me.colResult.Name, row.Index).Value = results.Item(subTestName.ToUpper())
                        Me.FlagLabResultsEXT(row.Index)

                    Catch ex As Exception

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If ex.Message.Contains("The given key") Then
                            message = ex.Message + ControlChars.NewLine + "Make sure that test name: " + subTestName + ", has results sent!"
                            DisplayMessage(message)
                        Else : ErrorMessage(ex)
                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    End Try

                End With

            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            ExternalLabResults.Results.Clear()
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        'Dim oLabResults As New SyncSoft.SQLDb.LabResults()

        'Try
        '    Me.Cursor = Cursors.WaitCursor

        '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '    If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
        '    oLabResults.SpecimenNo = StringEnteredIn(Me.txtSpecimenNo, "Specimen No!")
        '    deletedMSG = oLabResults.Delete()
        '    MessageBox.Show(deletedMSG, oAppData.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '    ResetControlsIn(Me)
        '    ResetControlsIn(Me.grpLabResultsEXT)
        '    Me.CallOnKeyEdit()

        'Catch eX As Exception
        '    ErrorMessage(eX)

        'Finally
        '    Me.Cursor = Cursors.Default

        'End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim oLabResults As New SyncSoft.SQLDb.LabResults()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim specimenNo As String = RevertText(StringEnteredIn(Me.stbSpecimenNo, "Specimen No!"))
            Dim testCode As String = SubstringEnteredIn(Me.cboTestCode, "Lab Test!")

            Dim dataSource As DataTable = oLabResults.GetLabResults(specimenNo, testCode).Tables("LabResults")
            Me.DisplayData(dataSource)

            Me.stbSpecimenNo.Text = FormatText(specimenNo, "LabRequests", "SpecimenNo")
            Me.LoadLabResultsEXT(specimenNo, testCode)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    If chkIsAdmitted.Checked = True Then

                        Me.SaveIPDLabResults()

                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If chkIsAdmitted.Checked = False Then

                        Me.SaveOPDLabResults()

                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    If chkIsAdmitted.Checked = True Then
                        Me.UpdateIPDLabResults()
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If chkIsAdmitted.Checked = False Then
                        Me.UpdateOPDLabResults()

                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvLabResultsEXT.RowCount - 2
                Me.dgvLabResultsEXT.Item(Me.colSaved.Name, rowNo).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function LabResultsEXTList() As List(Of DBConnect)

        Dim lLabResultsEXT As New List(Of DBConnect)
        Dim oDataTypeID As New LookupCommDataID.SearchDataTypeID()
        Dim oUnitMeasureID As New LookupDataID.UnitMeasureID()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim specimenNo As String = RevertText(StringEnteredIn(Me.stbSpecimenNo, "Specimen No!"))
            Dim testCode As String = SubstringEnteredIn(Me.cboTestCode, "Lab Test!")
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Me.dgvLabResultsEXT.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for Lab Results EXTRA!")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvLabResultsEXT.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvLabResultsEXT.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If nonSelected Then Throw New ArgumentException("Must include at least one entry for Lab Results EXTRA!")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For Each row As DataGridViewRow In Me.dgvLabResultsEXT.Rows

                If row.IsNewRow Then Exit For

                If BooleanMayBeEnteredIn(row.Cells, Me.colInclude) Then

                    Dim subTestCode As String = StringEnteredIn(row.Cells, Me.colSubTestCode, "sub test code with include set to true!")
                    Dim result As String = StringEnteredIn(row.Cells, Me.colResult, "result with include set to true!")
                    Dim normalRange As String = StringMayBeEnteredIn(row.Cells, Me.colNormalRange)
                    Dim resultDataTypeID As String = StringMayBeEnteredIn(row.Cells, Me.colResultDataTypeID)

                    If String.IsNullOrEmpty(resultDataTypeID) Then resultDataTypeID = oDataTypeID.String

                    Select Case resultDataTypeID
                        Case oDataTypeID.Decimal, oDataTypeID.Number
                            If Not IsNumeric(result) Then
                                Throw New ArgumentException("Result for Sub Test Code: " + subTestCode + " should be numeric!")
                            End If
                        Case Else
                    End Select

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If LabResultNotInNormalRange(GetLookupDataDes(resultDataTypeID), gender, normalRange, result) Then
                        Dim message As String = "The result value (" + result + ") for Sub Test Code: " + subTestCode _
                                                + " is outside the normal range." + ControlChars.NewLine + "Are you sure you want to save?"
                        If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Save action cancelled!")
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvLabResultsEXT.RowCount - 2

                If CBool(Me.dgvLabResultsEXT.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Using oLabResultsEXT As New SyncSoft.SQLDb.LabResultsEXT()

                        Dim cells As DataGridViewCellCollection = Me.dgvLabResultsEXT.Rows(rowNo).Cells
                        Dim unitMeasure As String = StringMayBeEnteredIn(cells, Me.colUnitMeasure)

                        With oLabResultsEXT
                            .SpecimenNo = specimenNo
                            .TestCode = testCode
                            .SubTestCode = StringEnteredIn(cells, Me.colSubTestCode)
                            If unitMeasure.ToUpper().Equals(GetLookupDataDes(oUnitMeasureID.NA).ToUpper()) Then
                                .UnitMeasure = String.Empty
                            Else : .UnitMeasure = unitMeasure
                            End If
                            .Result = StringEnteredIn(cells, Me.colResult)
                            .ResultFlagID = StringEnteredIn(cells, Me.colResultFlagID, "Result Flag!")
                            .NormalRange = StringMayBeEnteredIn(cells, Me.colNormalRange)
                            .Report = StringMayBeEnteredIn(cells, Me.colReport)
                        End With

                        lLabResultsEXT.Add(oLabResultsEXT)

                    End Using
                End If
            Next

            Return lLabResultsEXT

        Catch ex As Exception
            Throw ex

        End Try

    End Function

#Region " LabResultsEXT - Grid "

    Private Sub LabResultsEXT_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvLabResultsEXT.CellBeginEdit

        If e.ColumnIndex <> Me.colSubTestCode.Index OrElse Me.dgvLabResultsEXT.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvLabResultsEXT.CurrentCell.RowIndex
        _SubTestCodeValue = StringMayBeEnteredIn(Me.dgvLabResultsEXT.Rows(selectedRow).Cells, Me.colSubTestCode)

    End Sub

    Private Sub LabResultsEXT_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLabResultsEXT.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colSubTestCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvLabResultsEXT.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvLabResultsEXT.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvLabResultsEXT.Rows(selectedRow).Cells, Me.colSubTestCode)

                    If CBool(Me.dgvLabResultsEXT.Item(Me.colSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Sub Test Code (" + _SubTestCodeValue + ") can't be edited!")
                        Me.dgvLabResultsEXT.Item(Me.colSubTestCode.Name, selectedRow).Value = _SubTestCodeValue
                        Me.dgvLabResultsEXT.Item(Me.colSubTestCode.Name, selectedRow).Selected = True
                        Return

                    End If

                    For rowNo As Integer = 0 To Me.dgvLabResultsEXT.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvLabResultsEXT.Rows(rowNo).Cells, Me.colSubTestCode)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                DisplayMessage("Sub Test Code (" + enteredItem + ") already entered!")
                                Me.dgvLabResultsEXT.Item(Me.colSubTestCode.Name, selectedRow).Value = _SubTestCodeValue
                                Me.dgvLabResultsEXT.Item(Me.colSubTestCode.Name, selectedRow).Selected = True
                                Return
                            End If
                        End If
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '' Populate other columns based upon what is entered in combo column
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If labTestsEXT Is Nothing OrElse labTestsEXT.Rows.Count < 1 Then Return

                    For Each row As DataRow In labTestsEXT.Select("SubTestCode = '" + selectedItem + "'")
                        With Me.dgvLabResultsEXT
                            .Item(Me.colNormalRange.Name, selectedRow).Value = row.Item("NormalRange")
                            .Item(Me.colUnitMeasure.Name, selectedRow).Value = row.Item("UnitMeasure")
                            .Item(Me.colResultDataTypeID.Name, selectedRow).Value = row.Item("ResultDataTypeID")
                        End With
                    Next
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

            ElseIf e.ColumnIndex.Equals(Me.colNormalRange.Index) OrElse e.ColumnIndex.Equals(Me.colResult.Index) Then

                Me.FlagLabResultsEXT(Me.dgvLabResultsEXT.CurrentCell.RowIndex)

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub LabResultsEXT_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvLabResultsEXT.UserDeletingRow

        Dim recordDeleted As String

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oLabResultsEXT As New SyncSoft.SQLDb.LabResultsEXT()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvLabResultsEXT.Item(Me.colSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim specimenNo As String = RevertText(StringEnteredIn(Me.stbSpecimenNo, "Specimen No!"))
            Dim testCode As String = SubstringEnteredIn(Me.cboTestCode, "Lab Test!")
            Dim subTestCode As String = CStr(Me.dgvLabResultsEXT.Item(Me.colSubTestCode.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim deleteMSG As String = "You do not have permission to delete this record!"
            If Me.btnDelete.Enabled = False Then
                MessageBox.Show(deleteMSG, AppData.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
                Return
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oLabResultsEXT
                .SpecimenNo = specimenNo
                .TestCode = testCode
                .SubTestCode = subTestCode
                recordDeleted = .Delete()
            End With

            MessageBox.Show(recordDeleted, AppData.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvLabResultsEXT_UserAddedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvLabResultsEXT.UserAddedRow
        Me.dgvLabResultsEXT.Item(Me.colInclude.Name, e.Row.Index - 1).Value = True
        Me.dgvLabResultsEXT.Item(Me.colResultFlagID.Name, e.Row.Index - 1).Value = oResultFlagID.NA
    End Sub

    Private Sub dgvLabResultsEXT_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvLabResultsEXT.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub FlagLabResultsEXT(ByVal selectedRow As Integer)

        Try

            Dim resultDataTypeID As String = StringMayBeEnteredIn(Me.dgvLabResultsEXT.Rows(selectedRow).Cells, Me.colResultDataTypeID)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim normalRange As String = StringMayBeEnteredIn(Me.dgvLabResultsEXT.Rows(selectedRow).Cells, Me.colNormalRange)
            Dim result As String = StringMayBeEnteredIn(Me.dgvLabResultsEXT.Rows(selectedRow).Cells, Me.colResult)

            Me.dgvLabResultsEXT.Item(Me.colResultFlagID.Name, selectedRow).Value = GetLabResultFlag(GetLookupDataDes(resultDataTypeID), gender, normalRange, result)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub LoadLabResultsEXT(ByVal specimenNo As String, ByVal testCode As String)

        Dim oLabResultsEXT As New SyncSoft.SQLDb.LabResultsEXT()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.dgvLabResultsEXT.Rows.Clear()

            ' Load items not yet paid for

            Dim labResultsEXT As DataTable = oLabResultsEXT.GetLabResultsEXT(specimenNo, testCode).Tables("LabResultsEXT")
            If labResultsEXT Is Nothing OrElse labResultsEXT.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To labResultsEXT.Rows.Count - 1

                Dim row As DataRow = labResultsEXT.Rows(pos)
                ' Ensure that you add a new row first

                With Me.dgvLabResultsEXT
                    .Rows.Add()

                    .Item(Me.colInclude.Name, pos).Value = True
                    .Item(Me.colSubTestCode.Name, pos).Value = StringEnteredIn(row, "SubTestCode")
                    .Item(Me.colNormalRange.Name, pos).Value = StringMayBeEnteredIn(row, "NormalRange")
                    .Item(Me.colResult.Name, pos).Value = StringEnteredIn(row, "Result")
                    .Item(Me.colResultFlagID.Name, pos).Value = StringMayBeEnteredIn(row, "ResultFlagID")
                    .Item(Me.colUnitMeasure.Name, pos).Value = StringMayBeEnteredIn(row, "UnitMeasure")
                    .Item(Me.colReport.Name, pos).Value = StringMayBeEnteredIn(row, "Report")
                    .Item(Me.colResultDataTypeID.Name, pos).Value = StringMayBeEnteredIn(row, "ResultDataTypeID")
                    .Item(Me.colSaved.Name, pos).Value = True
                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub dgvLabResultsEXT_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLabResultsEXT.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oLabTestsEXT As New SyncSoft.SQLDb.LabTestsEXT
            Dim cells As DataGridViewCellCollection = Me.dgvLabResultsEXT.Rows(e.RowIndex).Cells
            Dim subtestcode As String = StringMayBeEnteredIn(cells, Me.colSubTestCode)

            If oLabTestsEXT.IsHasPossibleSubTestsResults(subtestcode) Then

                Dim fHasSubTests As New frmHasSubTests(subtestcode, Me.dgvLabResultsEXT, Me.colResult, e.RowIndex)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                If Me.colResult.Index.Equals(e.ColumnIndex) AndAlso Me.dgvLabResultsEXT.Rows(e.RowIndex).IsNewRow Then

                    Me.dgvLabResultsEXT.Rows.Add()

                    fHasSubTests.ShowDialog()

                ElseIf Me.colResult.Index.Equals(e.ColumnIndex) Then
                    fHasSubTests.ShowDialog()

                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Public Sub setLabResults(rowNo As Integer, toLoadValue As String)
        Try
            Me.dgvLabResultsEXT.Item(Me.colResult.Name, rowNo).Value = toLoadValue
        Catch ex As Exception

        End Try

    End Sub

#End Region


    Private Sub SaveIPDLabResults()

        Dim records As Integer
        Dim message As String
        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oVariousOptions As New VariousOptions()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oUnitMeasureID As New LookupDataID.UnitMeasureID()
        Dim oResultFlagID As New LookupDataID.ResultFlagID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()
        Dim oLabTests As New SyncSoft.SQLDb.LabTests()
        Dim oLabResults As New SyncSoft.SQLDb.LabResults()
        Dim oLabRequests As New SyncSoft.SQLDb.LabRequests()

        Dim lLabResults As New List(Of DBConnect)
        Dim lIPDItems As New List(Of DBConnect)

        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim iPDItems As New DataTable()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim labTechnologist As String
            Dim specimenNo As String = RevertText(StringEnteredIn(Me.stbSpecimenNo, "Specimen No!"))
            Dim testCode As String = SubstringEnteredIn(Me.cboTestCode, "Lab Test!")
            Dim testDateTime As Date = DateTimeEnteredIn(Me.dtpTestDateTime, "Test Date and Time!")

            Dim labRequests As DataTable = oLabRequests.GetLabRequests(specimenNo).Tables("LabRequests")
            Dim roundNo As String = CStr(labRequests.Rows(0).Item("RoundNo"))
            Dim iPDDoctor As DataTable = oIPDDoctor.GetIPDDoctor(RevertText(roundNo)).Tables("IPDDoctor")

            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim normalRange As String = StringMayBeEnteredIn(Me.stbNormalRange)
            Dim unitMeasure As String = StringMayBeEnteredIn(Me.stbUnitMeasure)

            With oLabResults

                .SpecimenNo = specimenNo
                .TestCode = testCode
                .TestDateTime = testDateTime
                .NormalRange = normalRange
                If hasSubTests Then
                    .Result = StringMayBeEnteredIn(Me.cboResult)
                    Dim resultFlagID As String = StringValueMayBeEnteredIn(Me.cboResultFlagID)
                    If String.IsNullOrEmpty(resultFlagID) Then
                        .ResultFlagID = oResultFlagID.NA
                    Else : .ResultFlagID = resultFlagID
                    End If
                Else
                    .Result = StringEnteredIn(Me.cboResult, "Result!")
                    .ResultFlagID = StringValueEnteredIn(Me.cboResultFlagID, "Result Flag!")
                End If

                If unitMeasure.ToUpper().Equals(GetLookupDataDes(oUnitMeasureID.NA).ToUpper()) Then
                    .UnitMeasure = String.Empty
                Else : .UnitMeasure = unitMeasure
                End If

                .Report = StringMayBeEnteredIn(Me.stbReport)
                labTechnologist = SubstringEnteredIn(Me.cboLabTechnologist, "Lab Technologist (Staff)!")
                .LabTechnologist = labTechnologist
                .EntryModeID = StringValueEnteredIn(Me.cboEntryModeID, "Entry Mode!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ValidateEntriesIn(Me, ErrProvider)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim staffRow As DataRow = oStaff.GetStaff(labTechnologist).Tables("Staff").Rows(0)
            Dim userLoginID As String = StringMayBeEnteredIn(staffRow, "LoginID")

            If oVariousOptions.RestrictLabTechnologistLoginID AndAlso Not userLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then

                message = "The Lab Technologist (Staff) you have selected has a different associated login ID from that " +
                "of the current user." + ControlChars.NewLine + "The system is set not to allow a login ID not associated with selected staff. " +
               "Contact administrator if you still need to do this."

                Throw New ArgumentException(message)

            ElseIf String.IsNullOrEmpty(userLoginID) Then
                message = "The Lab Technologist (Staff) you have selected does not have an associated login ID. We recommend " +
               "that you contact the administrator to have this fixed. " + ControlChars.NewLine + "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

            ElseIf Not userLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then
                message = "The Lab Technologist (Staff) you have selected has a different associated login ID from that " +
                "of the current user. " + ControlChars.NewLine + "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim drawnDateTime As Date = DateTimeMayBeEnteredIn(Me.stbDrawnDateTime)

            If testDateTime < drawnDateTime Then
                Throw New ArgumentException("Test date and time can't be before drawn date and time!")

            ElseIf testDateTime > Now Then
                Throw New ArgumentException("Test date and time can't be a head of current date and time!")

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not hasSubTests Then
                If LabResultNotInNormalRange(resultDataType, gender, normalRange, oLabResults.Result) Then
                    message = "The result value is outside the normal range." + ControlChars.NewLine + "Are you sure you want to save?"
                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return
                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lLabResults.Add(oLabResults)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                With oIPDItems
                    .RoundNo = roundNo
                    .ItemCode = testCode
                    .ItemCategoryID = oItemCategoryID.Test
                    .LastUpdate = testDateTime
                    .PayStatusID = String.Empty
                    .LoginID = CurrentUser.LoginID
                    .ItemStatusID = oItemStatusID.Done
                End With
                lIPDItems.Add(oIPDItems)
                iPDItems = oIPDItems.GetIPDItem(roundNo, testCode, oItemCategoryID.Test).Tables("IPDItems")
            End Using

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oExtraBillsEXT As New SyncSoft.SQLDb.ExtraBillsEXT()
            Dim lExtraBills As New List(Of DBConnect)
            Dim lExtraBillsEXT As New List(Of DBConnect)
            Dim lExtraBillItems As New List(Of DBConnect)
            Dim lExtraBillItemsCASH As New List(Of DBConnect)

            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim unitPrice As Decimal = CDec(iPDItems.Rows(0).Item("UnitPrice"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim extraBillNo As String = oExtraBillsEXT.GetExtraBillsEXTExtraBillNo(roundNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Using oExtraBills As New SyncSoft.SQLDb.ExtraBills()

                With oExtraBills

                    .VisitNo = visitNo
                    .ExtraBillNo = GetNextExtraBillNo(visitNo, patientNo)
                    .ExtraBillDate = DateEnteredIn(Me.stbDrawnDateTime, "Extra Bill Date!")
                    .StaffNo = attendingDoctorNo
                    .LoginID = CurrentUser.LoginID

                End With

                lExtraBills.Add(oExtraBills)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If String.IsNullOrEmpty(extraBillNo) Then

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBills, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    With oExtraBillsEXT
                        .ExtraBillNo = oExtraBills.ExtraBillNo
                        .RoundNo = roundNo
                    End With

                    lExtraBillsEXT.Add(oExtraBillsEXT)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillsEXT, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    extraBillNo = oExtraBills.ExtraBillNo
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If
            End Using

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim testName As String = SubstringLeft(StringEnteredIn(Me.cboTestCode))
            Dim quantity As Integer = 1

            Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

                With oExtraBillItems

                    .ExtraBillNo = extraBillNo
                    .ItemCode = testCode
                    .ItemCategoryID = oItemCategoryID.Test
                    .Quantity = quantity
                    .UnitPrice = unitPrice
                    .Notes = "Test: " + testName + ", done to Patient No: " + patientNo + ", Specimen No: " + specimenNo + ", and Round No: " + roundNo
                    .LastUpdate = testDateTime
                    If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, testCode, oItemCategoryID.Test).Equals(True) Then
                        .PayStatusID = oPayStatusID.NA
                    Else
                        .PayStatusID = oPayStatusID.NotPaid
                    End If
                    .EntryModeID = oEntryModeID.System
                    .LoginID = CurrentUser.LoginID

                End With

                lExtraBillItems.Add(oExtraBillItems)

            End Using

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()
            Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

            If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                    With oExtraBillItemsCASH
                        .ExtraBillNo = extraBillNo
                        .ItemCode = testCode
                        .ItemCategoryID = oItemCategoryID.Test
                        .CashAmount = cashAmount

                        If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, testCode, oItemCategoryID.Test).Equals(True) Then
                            .CashPayStatusID = oPayStatusID.NA
                        Else
                            .CashPayStatusID = oPayStatusID.NotPaid
                        End If

                    End With
                    lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                End Using
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lLabResults, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Update))

            If hasSubTests Then transactions.Add(New TransactionList(Of DBConnect)(LabResultsEXTList, Action.Save))

            records = DoTransactions(transactions)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me)
            ResetControlsIn(Me.grpLabResultsEXT)
            Me.LoadLabTestsResults(specimenNo)

            Me.cboResult.DropDownStyle = ComboBoxStyle.DropDown
            Me.SetDefaultControls()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not oVariousOptions.ForceLabResultsVerification AndAlso GetShortDate(testDateTime).Equals(GetShortDate(Today)) Then

                Using oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
                    With oIPDAlerts

                        .AlertTypeID = oAlertTypeID.LabResults
                        .RoundNo = roundNo
                        .StaffNo = attendingDoctorNo
                        .Notes = (totalLabRequests - labRequestsCount).ToString() + " of " + totalLabRequests.ToString() + " Done"
                        .LoginID = CurrentUser.LoginID

                        .Save()

                    End With
                End Using
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveOPDLabResults()

        Dim records As Integer
        Dim message As String
        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oVariousOptions As New VariousOptions()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oBenefitCodes As New LookupDataID.BenefitCodes()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oUnitMeasureID As New LookupDataID.UnitMeasureID()
        Dim oResultFlagID As New LookupDataID.ResultFlagID()

        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oLabTests As New SyncSoft.SQLDb.LabTests()
        Dim oLabResults As New SyncSoft.SQLDb.LabResults()
        Dim oLabRequests As New SyncSoft.SQLDb.LabRequests()
        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()

        Dim lLabResults As New List(Of DBConnect)
        Dim lItems As New List(Of DBConnect)
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)

        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim items As New DataTable()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim labTechnologist As String
            Dim specimenNo As String = RevertText(StringEnteredIn(Me.stbSpecimenNo, "Specimen No!"))
            Dim testCode As String = SubstringEnteredIn(Me.cboTestCode, "Lab Test!")
            Dim testDateTime As Date = DateTimeEnteredIn(Me.dtpTestDateTime, "Test Date and Time!")

            Dim labRequests As DataTable = oLabRequests.GetLabRequests(RevertText(specimenNo)).Tables("LabRequests")
            Dim visitNo As String = labRequests.Rows(0).Item("VisitNo").ToString()
            Dim visits As DataTable = oVisits.GetVisits(RevertText(visitNo)).Tables("Visits")

            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim normalRange As String = StringMayBeEnteredIn(Me.stbNormalRange)
            Dim unitMeasure As String = StringMayBeEnteredIn(Me.stbUnitMeasure)

            With oLabResults

                .SpecimenNo = specimenNo
                .TestCode = testCode
                .TestDateTime = testDateTime
                .NormalRange = normalRange
                If hasSubTests Then
                    .Result = StringMayBeEnteredIn(Me.cboResult)
                    Dim resultFlagID As String = StringValueMayBeEnteredIn(Me.cboResultFlagID)
                    If String.IsNullOrEmpty(resultFlagID) Then
                        .ResultFlagID = oResultFlagID.NA
                    Else : .ResultFlagID = resultFlagID
                    End If
                Else
                    .Result = StringEnteredIn(Me.cboResult, "Result!")
                    .ResultFlagID = StringValueEnteredIn(Me.cboResultFlagID, "Result Flag!")
                End If

                If unitMeasure.ToUpper().Equals(GetLookupDataDes(oUnitMeasureID.NA).ToUpper()) Then
                    .UnitMeasure = String.Empty
                Else : .UnitMeasure = unitMeasure
                End If
                .Report = StringMayBeEnteredIn(Me.stbReport)
                labTechnologist = SubstringEnteredIn(Me.cboLabTechnologist, "Lab Technologist (Staff)!")
                .LabTechnologist = labTechnologist
                .EntryModeID = StringValueEnteredIn(Me.cboEntryModeID, "Entry Mode!")
                .LoginID = CurrentUser.LoginID

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ValidateEntriesIn(Me, ErrProvider)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim staffRow As DataRow = oStaff.GetStaff(labTechnologist).Tables("Staff").Rows(0)
            Dim userLoginID As String = StringMayBeEnteredIn(staffRow, "LoginID")

            If oVariousOptions.RestrictLabTechnologistLoginID AndAlso Not userLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then

                message = "The Lab Technologist (Staff) you have selected has a different associated login ID from that " +
                "of the current user." + ControlChars.NewLine + "The system is set not to allow a login ID not associated with selected staff. " +
               "Contact administrator if you still need to do this."

                Throw New ArgumentException(message)

            ElseIf String.IsNullOrEmpty(userLoginID) Then
                message = "The Lab Technologist (Staff) you have selected does not have an associated login ID. We recommend " +
               "that you contact the administrator to have this fixed. " + ControlChars.NewLine + "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

            ElseIf Not userLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then
                message = "The Lab Technologist (Staff) you have selected has a different associated login ID from that " +
                "of the current user. " + ControlChars.NewLine + "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim drawnDateTime As Date = DateTimeMayBeEnteredIn(Me.stbDrawnDateTime)

            If testDateTime < drawnDateTime Then
                Throw New ArgumentException("Test date and time can't be before drawn date and time!")

            ElseIf testDateTime > Now Then
                Throw New ArgumentException("Test date and time can't be a head of current date and time!")

            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Not hasSubTests Then
                If LabResultNotInNormalRange(resultDataType, gender, normalRange, oLabResults.Result) Then
                    message = "The result value is outside the normal range." + ControlChars.NewLine + "Are you sure you want to save?"
                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return
                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lLabResults.Add(oLabResults)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Using oItems As New SyncSoft.SQLDb.Items()
                With oItems
                    .VisitNo = visitNo
                    .ItemCode = testCode
                    .ItemCategoryID = oItemCategoryID.Test
                    .LastUpdate = DateEnteredIn(Me.dtpTestDateTime, "Test Date!")
                    .PayStatusID = String.Empty
                    .LoginID = CurrentUser.LoginID
                    .ItemStatusID = oItemStatusID.Done
                End With
                lItems.Add(oItems)
                items = oItems.GetItem(visitNo, testCode, oItemCategoryID.Test).Tables("Items")
            End Using

            Dim billModesID As String = visits.Rows(0).Item("BillModesID").ToString()
            Dim billMode As String = visits.Rows(0).Item("BillMode").ToString()
            Dim billNo As String = visits.Rows(0).Item("BillNo").ToString()
            Dim patientNo As String = visits.Rows(0).Item("PatientNo").ToString()
            Dim unitPrice As Decimal = CDec(items.Rows(0).Item("UnitPrice"))

            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If billMode.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()
                Dim oEntryModeID As New LookupDataID.EntryModeID()
                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims

                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = DateEnteredIn(Me.dtpTestDateTime, "TestDateTime!")
                        .VisitTime = GetTime(Me.dtpTestDateTime.Value)
                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                        .PrimaryDoctor = StringMayBeEnteredIn(Me.stbPrimaryDoctor)
                        .ClaimStatusID = oClaimStatusID.Pending
                        .ClaimEntryID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID

                    End With

                    lClaims.Add(oClaims)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(claimNo) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim testName As String = SubstringLeft(StringEnteredIn(Me.cboTestCode))

            If billMode.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim limitBalance As Decimal
                Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Test)
                Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Test)
                If limitAmount > 0 Then
                    limitBalance = limitAmount - consumedAmount
                Else : limitBalance = 0
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()

                    With oClaimDetails

                        .ClaimNo = claimNo
                        .ItemName = testName
                        .BenefitCode = oBenefitCodes.Test
                        .Quantity = 1
                        .UnitPrice = unitPrice
                        .Adjustment = 0
                        .Amount = .Quantity * .UnitPrice
                        .Notes = "Test: " + testName + ", done to Patient No: " + patientNo + " and Specimen No: " + specimenNo
                        .LimitAmount = limitAmount
                        .ConsumedAmount = consumedAmount
                        .LimitBalance = limitBalance

                    End With

                    lClaimDetails.Add(oClaimDetails)

                End Using

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lLabResults, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Update))
            transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))

            If hasSubTests Then transactions.Add(New TransactionList(Of DBConnect)(LabResultsEXTList, Action.Save))

            records = DoTransactions(transactions)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me)
            ResetControlsIn(Me.grpLabResultsEXT)
            Me.LoadLabTestsResults(specimenNo)

            Me.cboResult.DropDownStyle = ComboBoxStyle.DropDown
            Me.SetDefaultControls()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not oVariousOptions.ForceLabResultsVerification AndAlso GetShortDate(DateMayBeEnteredIn(Me.dtpTestDateTime)) >= GetShortDate(Today.AddHours(-12)) AndAlso
                Not String.IsNullOrEmpty(doctorStaffNo) Then
                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                    With oAlerts

                        .AlertTypeID = oAlertTypeID.LabResults
                        .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo))
                        .StaffNo = doctorStaffNo
                        .Notes = (totalLabRequests - labRequestsCount).ToString() + " of " + totalLabRequests.ToString() + " Done"
                        .LoginID = CurrentUser.LoginID

                        .Save()

                    End With
                End Using
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oVariousOptions.SMSNotificationAtLab Then

                Dim txtNo As Integer = cboTestCode.Items.Count

                If stbPhoneNo.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(stbPhoneNo.Text) Then
                    If txtNo = 0 Then
                        Dim oPatients As New SyncSoft.SQLDb.Patients()
                        oPatients.GetPatient(patientNo)
                        Dim recipients As String = stbPhoneNo.Text
                        Dim productOwner As String = AppData.ProductOwner
                        Dim txtmessage As String = ("Hi" + " " + oPatients.FirstName.ToString + " " + " Your Lab results are ready check with DR." + stbPrimaryDoctor.Text + " " + "at" + " " + (productOwner) + " " +
                        "- Via ClinicMaster")
                        SaveTextMessage(txtmessage, recipients, Now, oVariousOptions.SMSLifeSpanLab)

                    End If

                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub UpdateIPDLabResults()

        Dim records As Integer
        Dim message As String
        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oVariousOptions As New VariousOptions()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oUnitMeasureID As New LookupDataID.UnitMeasureID()
        Dim oResultFlagID As New LookupDataID.ResultFlagID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()
        Dim oLabTests As New SyncSoft.SQLDb.LabTests()
        Dim oLabResults As New SyncSoft.SQLDb.LabResults()
        Dim oLabRequests As New SyncSoft.SQLDb.LabRequests()

        Dim lLabResults As New List(Of DBConnect)
        Dim lIPDItems As New List(Of DBConnect)

        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim iPDItems As New DataTable()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim labTechnologist As String
            Dim specimenNo As String = RevertText(StringEnteredIn(Me.stbSpecimenNo, "Specimen No!"))
            Dim testCode As String = SubstringEnteredIn(Me.cboTestCode, "Lab Test!")
            Dim testDateTime As Date = DateTimeEnteredIn(Me.dtpTestDateTime, "Test Date and Time!")

            Dim labRequests As DataTable = oLabRequests.GetLabRequests(specimenNo).Tables("LabRequests")
            Dim roundNo As String = CStr(labRequests.Rows(0).Item("RoundNo"))
            Dim iPDDoctor As DataTable = oIPDDoctor.GetIPDDoctor(RevertText(roundNo)).Tables("IPDDoctor")

            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim normalRange As String = StringMayBeEnteredIn(Me.stbNormalRange)
            Dim unitMeasure As String = StringMayBeEnteredIn(Me.stbUnitMeasure)

            With oLabResults

                .SpecimenNo = specimenNo
                .TestCode = testCode
                .TestDateTime = testDateTime
                .NormalRange = normalRange
                If hasSubTests Then
                    .Result = StringMayBeEnteredIn(Me.cboResult)
                    Dim resultFlagID As String = StringValueMayBeEnteredIn(Me.cboResultFlagID)
                    If String.IsNullOrEmpty(resultFlagID) Then
                        .ResultFlagID = oResultFlagID.NA
                    Else : .ResultFlagID = resultFlagID
                    End If
                Else
                    .Result = StringEnteredIn(Me.cboResult, "Result!")
                    .ResultFlagID = StringValueEnteredIn(Me.cboResultFlagID, "Result Flag!")
                End If

                If unitMeasure.ToUpper().Equals(GetLookupDataDes(oUnitMeasureID.NA).ToUpper()) Then
                    .UnitMeasure = String.Empty
                Else : .UnitMeasure = unitMeasure
                End If

                .Report = StringMayBeEnteredIn(Me.stbReport)
                labTechnologist = SubstringEnteredIn(Me.cboLabTechnologist, "Lab Technologist (Staff)!")
                .LabTechnologist = labTechnologist
                .EntryModeID = StringValueEnteredIn(Me.cboEntryModeID, "Entry Mode!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ValidateEntriesIn(Me, ErrProvider)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim staffRow As DataRow = oStaff.GetStaff(labTechnologist).Tables("Staff").Rows(0)
            Dim userLoginID As String = StringMayBeEnteredIn(staffRow, "LoginID")

            If oVariousOptions.RestrictLabTechnologistLoginID AndAlso Not userLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then

                message = "The Lab Technologist (Staff) you have selected has a different associated login ID from that " +
                "of the current user." + ControlChars.NewLine + "The system is set not to allow a login ID not associated with selected staff. " +
               "Contact administrator if you still need to do this."

                Throw New ArgumentException(message)

            ElseIf String.IsNullOrEmpty(userLoginID) Then
                message = "The Lab Technologist (Staff) you have selected does not have an associated login ID. We recommend " +
               "that you contact the administrator to have this fixed. " + ControlChars.NewLine + "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

            ElseIf Not userLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then
                message = "The Lab Technologist (Staff) you have selected has a different associated login ID from that " +
                "of the current user. " + ControlChars.NewLine + "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim drawnDateTime As Date = DateTimeMayBeEnteredIn(Me.stbDrawnDateTime)

            If testDateTime < drawnDateTime Then
                Throw New ArgumentException("Test date and time can't be before drawn date and time!")

            ElseIf testDateTime > Now Then
                Throw New ArgumentException("Test date and time can't be a head of current date and time!")

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not hasSubTests Then
                If LabResultNotInNormalRange(resultDataType, gender, normalRange, oLabResults.Result) Then
                    message = "The result value is outside the normal range." + ControlChars.NewLine + "Are you sure you want to save?"
                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return
                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lLabResults.Add(oLabResults)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            transactions.Add(New TransactionList(Of DBConnect)(lLabResults, Action.Update, "LabResults"))
            If hasSubTests Then transactions.Add(New TransactionList(Of DBConnect)(LabResultsEXTList, Action.Save))

            records = DoTransactions(transactions)

            DisplayMessage(records.ToString() + " record(s) updated!")


        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub UpdateOPDLabResults()

        Dim records As Integer
        Dim message As String
        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oVariousOptions As New VariousOptions()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oBenefitCodes As New LookupDataID.BenefitCodes()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oUnitMeasureID As New LookupDataID.UnitMeasureID()
        Dim oResultFlagID As New LookupDataID.ResultFlagID()

        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oLabTests As New SyncSoft.SQLDb.LabTests()
        Dim oLabResults As New SyncSoft.SQLDb.LabResults()
        Dim oLabRequests As New SyncSoft.SQLDb.LabRequests()
        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()

        Dim lLabResults As New List(Of DBConnect)
        Dim lItems As New List(Of DBConnect)
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)

        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim items As New DataTable()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim labTechnologist As String
            Dim specimenNo As String = RevertText(StringEnteredIn(Me.stbSpecimenNo, "Specimen No!"))
            Dim testCode As String = SubstringEnteredIn(Me.cboTestCode, "Lab Test!")
            Dim testDateTime As Date = DateTimeEnteredIn(Me.dtpTestDateTime, "Test Date and Time!")

            Dim labRequests As DataTable = oLabRequests.GetLabRequests(RevertText(specimenNo)).Tables("LabRequests")
            Dim visitNo As String = labRequests.Rows(0).Item("VisitNo").ToString()
            Dim visits As DataTable = oVisits.GetVisits(RevertText(visitNo)).Tables("Visits")

            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim normalRange As String = StringMayBeEnteredIn(Me.stbNormalRange)
            Dim unitMeasure As String = StringMayBeEnteredIn(Me.stbUnitMeasure)

            With oLabResults

                .SpecimenNo = specimenNo
                .TestCode = testCode
                .TestDateTime = testDateTime
                .NormalRange = normalRange
                If hasSubTests Then
                    .Result = StringMayBeEnteredIn(Me.cboResult)
                    Dim resultFlagID As String = StringValueMayBeEnteredIn(Me.cboResultFlagID)
                    If String.IsNullOrEmpty(resultFlagID) Then
                        .ResultFlagID = oResultFlagID.NA
                    Else : .ResultFlagID = resultFlagID
                    End If
                Else
                    .Result = StringEnteredIn(Me.cboResult, "Result!")
                    .ResultFlagID = StringValueEnteredIn(Me.cboResultFlagID, "Result Flag!")
                End If

                If unitMeasure.ToUpper().Equals(GetLookupDataDes(oUnitMeasureID.NA).ToUpper()) Then
                    .UnitMeasure = String.Empty
                Else : .UnitMeasure = unitMeasure
                End If
                .Report = StringMayBeEnteredIn(Me.stbReport)
                labTechnologist = SubstringEnteredIn(Me.cboLabTechnologist, "Lab Technologist (Staff)!")
                .LabTechnologist = labTechnologist
                .EntryModeID = StringValueEnteredIn(Me.cboEntryModeID, "Entry Mode!")
                .LoginID = CurrentUser.LoginID

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ValidateEntriesIn(Me, ErrProvider)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim staffRow As DataRow = oStaff.GetStaff(labTechnologist).Tables("Staff").Rows(0)
            Dim userLoginID As String = StringMayBeEnteredIn(staffRow, "LoginID")

            If oVariousOptions.RestrictLabTechnologistLoginID AndAlso Not userLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then

                message = "The Lab Technologist (Staff) you have selected has a different associated login ID from that " +
                "of the current user." + ControlChars.NewLine + "The system is set not to allow a login ID not associated with selected staff. " +
               "Contact administrator if you still need to do this."

                Throw New ArgumentException(message)

            ElseIf String.IsNullOrEmpty(userLoginID) Then
                message = "The Lab Technologist (Staff) you have selected does not have an associated login ID. We recommend " +
               "that you contact the administrator to have this fixed. " + ControlChars.NewLine + "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

            ElseIf Not userLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then
                message = "The Lab Technologist (Staff) you have selected has a different associated login ID from that " +
                "of the current user. " + ControlChars.NewLine + "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim drawnDateTime As Date = DateTimeMayBeEnteredIn(Me.stbDrawnDateTime)

            If testDateTime < drawnDateTime Then
                Throw New ArgumentException("Test date and time can't be before drawn date and time!")

            ElseIf testDateTime > Now Then
                Throw New ArgumentException("Test date and time can't be a head of current date and time!")

            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Not hasSubTests Then
                If LabResultNotInNormalRange(resultDataType, gender, normalRange, oLabResults.Result) Then
                    message = "The result value is outside the normal range." + ControlChars.NewLine + "Are you sure you want to save?"
                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return
                End If
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lLabResults.Add(oLabResults)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            transactions.Add(New TransactionList(Of DBConnect)(lLabResults, Action.Update, "LabResults"))
            If hasSubTests Then transactions.Add(New TransactionList(Of DBConnect)(LabResultsEXTList, Action.Save))

            records = DoTransactions(transactions)

            DisplayMessage(records.ToString() + " record(s) updated!")


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
        ' Me.btnDelete.Visible = True 
        Me.btnDelete.Enabled = False
        Me.btnSearch.Visible = True

        Me.cboResult.DropDownStyle = ComboBoxStyle.DropDown
        Me.colInclude.ReadOnly = True

        ResetControlsIn(Me)
        ResetControlsIn(Me.grpLabResultsEXT)
        ResetControlsIn(Me.pnlSpecimenNo)
        Me.cboTestCode.Items.Clear()
        Me.ShowLabResultsEXT(False)
        Me.pnlAlerts.Visible = False
        Me.btnImportLabResults.Visible = False

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.btnDelete.Visible = False
        'Me.btnDelete.Enabled = True
        Me.btnSearch.Visible = False

        Me.cboResult.DropDownStyle = ComboBoxStyle.DropDown
        Me.colInclude.ReadOnly = False

        ResetControlsIn(Me)
        ResetControlsIn(Me.grpLabResultsEXT)
        Me.cboTestCode.Items.Clear()
        Me.ShowLabResultsEXT(False)
        Me.pnlAlerts.Visible = True
        Me.btnImportLabResults.Visible = True

        Me.SetDefaultControls()

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            ' Me.btnDelete.Enabled = dataSource.Rows.Count > 0

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