
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
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

Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmIPDPathologyReports

#Region " Fields "
    Private tipCoPayValueWords As New ToolTip()

    Private billCustomerName As String = String.Empty
    Private billModesID As String = String.Empty
    Private doctorStaffNo As String = String.Empty
    Private PathologyRequestsCount As Integer = 0
    Private totalIPDPathologyRequests As Integer = 0

    Private WithEvents docPathology As New PrintDocument()
    ' The paragraphs.
    Private PathologyParagraphs As Collection

    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private patientpackageNo As String = String.Empty
    Private hasPackage As Boolean = False
#End Region

Private Sub frmIPDPathologyReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()
            Me.LoadStaff()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboReportTypeID, LookupObjects.PathologyCategory, False)
            LoadLookupDataCombo(Me.cboPathologyTitleID, LookupObjects.PathologyTitles, False)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub frmIPDPathologyReports_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
    End Sub

    Private Sub LoadPathologyRequests(ByVal roundNo As String)

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim iPDItems As New DataTable()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboExamFullName.Items.Clear()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(roundNo) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                iPDItems = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Pathology, oItemStatusID.Processing).Tables("IPDItems")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If iPDItems Is Nothing OrElse iPDItems.Rows.Count < 1 Then

                    Dim message As String
                    Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)
                    Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
                    If String.IsNullOrEmpty(billMode) Then Return

                    If billMode.ToUpper().Equals(cashAccountNo.ToUpper()) Then
                        message = "This round has no processing pathology examination or is waiting for payment first!"
                    Else : message = "This round has no processing pathology examination!"
                    End If

                    DisplayMessage(message)
                    PathologyRequestsCount = 0
                    Return

                Else : PathologyRequestsCount = iPDItems.Rows.Count
                End If

            ElseIf Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
                iPDItems = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Pathology, oItemStatusID.Done).Tables("IPDItems")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboExamFullName, iPDItems, "ItemFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Utilities "

    Private Sub btnViewTemplates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewTemplates.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oTemplateTypeID As New LookupDataID.TemplateTypeID()
        Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.PathologyReports, Me.stbDiagnosis)
        fGetTemplates.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

#End Region



    Private Sub LoadPathologyReportsData(ByVal roundNo As String)

        Try

            Me.ShowPatientDetails(roundNo)
            Me.LoadPathologyRequests(roundNo)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Pathologist).Tables("Staff")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboPathologist, staff, "StaffFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbRoundNo.Clear()
        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()
        Me.stbGender.Clear()
        Me.stbVisitNo.Clear()
        Me.stbJoinDate.Clear()
        Me.stbAge.Clear()
        Me.stbAdmissionStatus.Clear()
        Me.stbBillNo.Clear()
        Me.stbBillMode.Clear()
        billCustomerName = String.Empty
        billModesID = String.Empty
        doctorStaffNo = String.Empty
        Me.stbBillCustomerName.Clear()
        Me.stbVisitCategory.Clear()
        Me.stbAttendingDoctor.Clear()
        Me.stbAdmissionDateTime.Clear()
        Me.stbRoundDateTime.Clear()
        ' Me.stbAdmissionNo.Clear()
        Me.cboPathologist.SelectedIndex = -1
        Me.stbIndication.Clear()
        Me.stbUnitPrice.Clear()
        Me.stbCoPayType.Clear()
        patientpackageNo = String.Empty
        hasPackage = False
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.cboExamFullName.SelectedIndex = -1
            Me.cboExamFullName.SelectedIndex = -1
        End If
        Me.ResetControls()
    End Sub

    Private Sub ResetControls()
        Me.stbIndication.Clear()
        Me.stbUnitPrice.Clear()
        Me.dtpExamDateTime.Value = Now
        Me.dtpExamDateTime.Checked = False
        Me.stbDiagnosis.Clear()
        Me.stbMacroscopic.Clear()
        Me.stbMicroscopic.Clear()
        Me.cboPathologist.SelectedIndex = -1
    End Sub


    Private Sub ShowPatientDetails(ByVal roundNo As String)

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()
        Dim oVisitCategoryID As New LookupDataID.VisitCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            '  Me.ClearControls()

            If String.IsNullOrEmpty(roundNo) Then Return

            Dim iPDDoctor As DataTable = oIPDDoctor.GetIPDDoctor(roundNo).Tables("IPDDoctor")
            Dim row As DataRow = iPDDoctor.Rows(0)

            Dim patientNo As String = StringEnteredIn(row, "PatientNo")
            Dim visitNo As String = StringEnteredIn(row, "VisitNo")
            Dim billNo As String = StringEnteredIn(row, "BillNo")
            Dim admissionNo As String = StringEnteredIn(row, "AdmissionNo")

            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Me.stbAdmissionDateTime.Text = FormatDateTime(DateTimeEnteredIn(row, "AdmissionDateTime"))
            Me.stbAdmissionNo.Text = FormatText(admissionNo, "Admissions", "AdmissionNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbAdmissionStatus.Text = StringEnteredIn(row, "AdmissionStatus")
            Me.stbBillNo.Text = FormatText(billNo, "BillCustomers", "AccountNo")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            billCustomerName = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName
            billModesID = StringMayBeEnteredIn(row, "BillModesID")
            doctorStaffNo = StringMayBeEnteredIn(row, "StaffNo")
            totalIPDPathologyRequests = IntegerMayBeEnteredIn(row, "TotalIPDPathologyRequests")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Me.stbVisitCategory.Text = StringEnteredIn(row, "VisitCategory")
            Me.stbAttendingDoctor.Text = StringMayBeEnteredIn(row, "AttendingDoctor")
            Me.stbRoundDateTime.Text = FormatDateTime(DateTimeEnteredIn(row, "RoundDateTime"))
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
            hasPackage = BooleanMayBeEnteredIn(row, "HasPackage")
            patientpackageNo = StringMayBeEnteredIn(row, "PackageNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboPathologist.Text = oStaff.GetCurrentStaffFullName
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundDateTime As Date = DateTimeEnteredIn(row, "RoundDateTime")
            Me.dtpExamDateTime.Value = roundDateTime
            Me.dtpExamDateTime.Checked = GetShortDate(roundDateTime) >= GetShortDate(Today.AddHours(-12))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboExamFullName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboExamFullName.SelectedIndexChanged
        Me.GetPathologyDetails()
        Me.CallOnKeyEdit()
    End Sub

    Private Sub GetPathologyDetails()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ResetControls()

            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
            Dim examCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboExamFullName))

            If String.IsNullOrEmpty(roundNo) OrElse String.IsNullOrEmpty(examCode) Then Return

            Dim iPDItems As DataTable = oIPDItems.GetIPDItem(roundNo, examCode, oItemCategoryID.Pathology).Tables("IPDItems")
            If iPDItems Is Nothing OrElse iPDItems.Rows.Count < 1 Then Return
            Dim row As DataRow = iPDItems.Rows(0)

            Me.stbUnitPrice.Text = FormatNumber(DecimalMayBeEnteredIn(row, "UnitPrice"), AppData.DecimalPlaces)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                Me.stbIndication.Text = StringMayBeEnteredIn(row, "ItemDetails")
                Dim roundDateTime As Date = DateTimeMayBeEnteredIn(Me.stbRoundDateTime)
                If Not roundDateTime.Equals(Today) AndAlso Not roundDateTime.Equals(AppData.NullDateValue) Then
                    Me.dtpExamDateTime.Value = roundDateTime
                    Me.dtpExamDateTime.Checked = False
                Else : Me.dtpExamDateTime.Value = Now
                End If
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub



Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
Dim oIPDPathologyReports As New SyncSoft.SQLDb.IPDPathologyReports()

	Try
		Me.Cursor = Cursors.WaitCursor()

            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))
            Dim examCode As String = SubstringEnteredIn(Me.cboExamFullName, "Pathology Examination!")


            Dim dataSource As DataTable = oIPDPathologyReports.GetIPDPathologyReports(roundNo, examCode, oItemCategoryID.Pathology).Tables("IPDPathologyReports")
		Me.DisplayData(dataSource)

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

    End Sub

    Private Sub stbRoundNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbRoundNo.Leave

        Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
        If String.IsNullOrEmpty(roundNo) Then Return
        Me.LoadPathologyReportsData(roundNo)

    End Sub

  

Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim records As Integer
        Dim message As String
        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oVariousOptions As New VariousOptions()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim lIPDItems As New List(Of DBConnect)
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor()
               

                    Dim oIPDPathologyReports As New SyncSoft.SQLDb.IPDPathologyReports()
                    Dim lIPDPathologyReports As New List(Of DBConnect)

                    Dim Pathologist As String
                    Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))
                    Dim examCode As String = SubstringEnteredIn(Me.cboExamFullName, "Pathology Examination!")

            With oIPDPathologyReports


                .RoundNo = roundNo
                .ItemCode = examCode
                .ItemCategoryID = oItemCategoryID.Pathology
                .ReportTypeID = StringValueEnteredIn(Me.cboReportTypeID, "ReportTypeID!")
                .ExamDateTime = DateEnteredIn(Me.dtpExamDateTime, "ExamDateTime!")
                .Indication = StringEnteredIn(Me.stbIndication, "Indication!")
                .Diagnosis = StringEnteredIn(Me.stbDiagnosis, "Diagnosis!")
                .Macroscopic = StringEnteredIn(Me.stbMacroscopic, "Macroscopic!")
                .Microscopic = StringEnteredIn(Me.stbMicroscopic, "Microscopic!")
                Pathologist = SubstringEnteredIn(Me.cboPathologist, "Pathologist (Staff)!")
                .Pathologist = Pathologist
                .PathologyTitleID = StringValueEnteredIn(Me.cboPathologyTitleID, "Pathology Title!")
                .LoginID = CurrentUser.LoginID
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim staffRow As DataRow = oStaff.GetStaff(Pathologist).Tables("Staff").Rows(0)
                    Dim userLoginID As String = StringMayBeEnteredIn(staffRow, "LoginID")

                    If oVariousOptions.RestrictPathologistLoginID AndAlso Not userLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then

                        message = "The Pathologist (Staff) you have selected has a different associated login ID from that " +
                        "of the current user." + ControlChars.NewLine + "The system is set not to allow a login ID not associated with selected staff. " +
                       "Contact administrator if you still need to do this."

                        Throw New ArgumentException(message)

                    ElseIf String.IsNullOrEmpty(userLoginID) Then
                        message = "The Pathologist (Staff) you have selected does not have an associated login ID. We recommend " +
                       "that you contact the administrator to have this fixed. " + ControlChars.NewLine + "Are you sure you want to continue?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

                    ElseIf Not userLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then
                        message = "The Pathologist (Staff) you have selected has a different associated login ID from that " +
                        "of the current user. " + ControlChars.NewLine + "Are you sure you want to continue?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    lIPDPathologyReports.Add(oIPDPathologyReports)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Select Case Me.ebnSaveUpdate.ButtonText

                        Case ButtonCaption.Save

                            Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                                With oIPDItems
                                    .RoundNo = roundNo
                                    .ItemCode = examCode
                                    .ItemCategoryID = oItemCategoryID.Pathology
                                    .LastUpdate = DateEnteredIn(Me.dtpExamDateTime, "Examination Date!")
                                    .PayStatusID = String.Empty
                                    .LoginID = CurrentUser.LoginID
                                    .ItemStatusID = oItemStatusID.Done
                                End With
                                lIPDItems.Add(oIPDItems)
                            End Using

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            Dim oExtraBillsEXT As New SyncSoft.SQLDb.ExtraBillsEXT()
                            Dim lExtraBills As New List(Of DBConnect)
                            Dim lExtraBillsEXT As New List(Of DBConnect)
                            Dim lExtraBillItems As New List(Of DBConnect)
                            Dim lExtraBillItemsCASH As New List(Of DBConnect)

                            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
                            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
                            Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.stbUnitPrice, True)

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            Dim extraBillNo As String = oExtraBillsEXT.GetExtraBillsEXTExtraBillNo(roundNo)

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            Using oExtraBills As New SyncSoft.SQLDb.ExtraBills()

                                With oExtraBills

                                    .VisitNo = visitNo
                                    .ExtraBillNo = GetNextExtraBillNo(visitNo, patientNo)
                                    .ExtraBillDate = DateEnteredIn(Me.stbRoundDateTime, "Extra Bill Date!")
                                    .StaffNo = doctorStaffNo
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
                            Dim examName As String = SubstringLeft(StringMayBeEnteredIn(Me.cboExamFullName))
                            Dim quantity As Integer = 1

                            Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

                                With oExtraBillItems

                                    .ExtraBillNo = extraBillNo
                                    .ItemCode = examCode
                                    .ItemCategoryID = oItemCategoryID.Pathology
                                    .Quantity = quantity
                                    .UnitPrice = unitPrice
                                    .Notes = "Pathology examination: " + examName + ", done to Patient No: " + patientNo + " and Round No: " + roundNo
                                    .LastUpdate = DateEnteredIn(Me.dtpExamDateTime, "Bill Date!")

                                    If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, examCode, oItemCategoryID.Pathology).Equals(True) Then
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
                                        .ItemCode = examCode
                                        .ItemCategoryID = oItemCategoryID.Pathology
                                        .CashAmount = cashAmount
                                        If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, examCode, oItemCategoryID.Pathology).Equals(True) Then
                                            .CashPayStatusID = oPayStatusID.NotPaid
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
                            transactions.Add(New TransactionList(Of DBConnect)(lIPDPathologyReports, Action.Save))
                            transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Update))

                            records = DoTransactions(transactions)
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.chkPrintExamReportOnSaving.Checked Then Me.PrintPathology()
                    Me.LoadPathologyRequests(roundNo)
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                            If GetShortDate(DateMayBeEnteredIn(Me.dtpExamDateTime)) >= GetShortDate(Today.AddHours(-12)) AndAlso
                                Not String.IsNullOrEmpty(doctorStaffNo) Then
                                Using oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
                                    With oIPDAlerts

                                        .AlertTypeID = oAlertTypeID.PathologyReports
                                        .RoundNo = RevertText(StringEnteredIn(Me.stbRoundNo))
                                        .StaffNo = doctorStaffNo
                                        .Notes = (totalIPDPathologyRequests - PathologyRequestsCount).ToString() + " of " + totalIPDPathologyRequests.ToString() + " Done"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            Me.ResetControls()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



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
	
	Me.fbnSearch.Visible = True

	ResetControlsIn(Me)

End Sub

Public Sub Save()

	Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
	Me.ebnSaveUpdate.Enabled = True

	Me.fbnSearch.Visible = False
        Me.btnPrint.Visible = False
	ResetControlsIn(Me)

End Sub

Private Sub DisplayData(ByVal dataSource As DataTable)

Try

	Me.ebnSaveUpdate.DataSource = dataSource
	Me.ebnSaveUpdate.LoadData(Me)

	Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            'Me.fbnDelete.Enabled = dataSource.Rows.Count > 0

	Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            'Security.Apply(Me.fbnDelete, AccessRights.Delete)

Catch ex As Exception
	Throw ex
End Try

End Sub

Private Sub CallOnKeyEdit()
If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
	Me.ebnSaveUpdate.Enabled = False
            'Me.fbnDelete.Enabled = False
End If
End Sub

#End Region


    Private Sub btnFindAdmissionNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindAdmissionNo.Click

        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fFindAdmissionNo As New frmFindAutoNo(Me.stbAdmissionNo, AutoNumber.AdmissionNo)
            fFindAdmissionNo.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
            Dim roundNo As String = oIPDDoctor.GetRoundNo(admissionNo, Nothing)
            Me.stbRoundNo.Text = FormatText(roundNo, "IPDDoctor", "RoundNo")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(roundNo) Then Return
            Me.LoadPathologyReportsData(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return

        End Try

    End Sub

    Private Sub btnFindRoundNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindRoundNo.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindRoundNo As New frmFindAutoNo(Me.stbRoundNo, AutoNumber.RoundNo)
        fFindRoundNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
        If String.IsNullOrEmpty(roundNo) Then Return
        Me.LoadPathologyReportsData(roundNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnLoadPendingPathology_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadPendingPathology.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPendingIPDItems As New frmPendingIPDItems(Me.stbRoundNo, AlertItemCategory.PathologyProcessing)
            fPendingIPDItems.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
            If String.IsNullOrEmpty(roundNo) Then Return
            Me.LoadPathologyReportsData(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

   
#Region " Pathology Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintPathology()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintPathology()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetRadiologyPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docPathology
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docPathology.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docPathology_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docPathology.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " IPD Pathology Report".ToUpper()

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbRoundDateTime)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim primaryDoctor As String = StringMayBeEnteredIn(Me.stbAttendingDoctor)
            Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 21 * widthTopFirst
                Dim widthTopFourth As Single = 30 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

                    .DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Gender/Age: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(gender + "/" + age, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Mode: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Round Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Attending Doctor: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(primaryDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Customer: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += 2 * lineHeight

                End If

                Dim _StringFormat As New StringFormat()

                ' Draw the rest of the text left justified,
                ' wrap at words, and don't draw partial lines.

                With _StringFormat
                    .Alignment = StringAlignment.Near
                    .FormatFlags = StringFormatFlags.LineLimit
                    .Trimming = StringTrimming.Word
                End With

                Dim charactersFitted As Integer
                Dim linesFilled As Integer

                If PathologyParagraphs Is Nothing Then Return

                Do While PathologyParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(PathologyParagraphs(1), PrintParagraps)
                    PathologyParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(e.MarginBounds.Left, yPos, e.MarginBounds.Width, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont,
                        New SizeF(printAreaRectangle.Width, printAreaRectangle.Height), _StringFormat, charactersFitted, linesFilled)

                    ' See if any characters will fit.
                    If charactersFitted > 0 Then
                        ' Draw the text.
                        .DrawString(oPrintParagraps.Text, oPrintParagraps.TheFont, Brushes.Black, printAreaRectangle, _StringFormat)
                        ' Increase the location where we can start, add a little interparagraph spacing.
                        yPos += textSize.Height ' + oPrintParagraps.TheFont.GetHeight(e.Graphics))

                    End If

                    ' See if some of the paragraph didn't fit on the page.
                    If charactersFitted < oPrintParagraps.Text.Length Then
                        ' Some of the paragraph didn't fit, prepare to print the rest on the next page.
                        oPrintParagraps.Text = oPrintParagraps.Text.Substring(charactersFitted)
                        PathologyParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (PathologyParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetRadiologyPrintData()

        Dim footerLEN As Integer = 20
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        PathologyParagraphs = New Collection

        Try

            '''''''''''''''EXAMINATION'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim examTitle As New System.Text.StringBuilder(String.Empty)
            examTitle.Append(ControlChars.NewLine)
            examTitle.Append("EXAMINATION: " + SubstringLeft(StringMayBeEnteredIn(Me.cboExamFullName)))
            examTitle.Append(ControlChars.NewLine)
            examTitle.Append(ControlChars.NewLine)
            PathologyParagraphs.Add(New PrintParagraps(bodyBoldFont, examTitle.ToString()))

            '''''''''''''''EXAMINATION DATE'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim examinationDate As New System.Text.StringBuilder(String.Empty)
            examinationDate.Append("EXAMINATION DATE & TIME: " + (StringMayBeEnteredIn(Me.dtpExamDateTime)))
            examinationDate.Append(ControlChars.NewLine)
            examTitle.Append(ControlChars.NewLine)
            PathologyParagraphs.Add(New PrintParagraps(bodyBoldFont, examinationDate.ToString()))

            '''''''''''''''INDICATION'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim indicationTitle As New System.Text.StringBuilder(String.Empty)
            indicationTitle.Append("INDICATION ")
            indicationTitle.Append(ControlChars.NewLine)
            PathologyParagraphs.Add(New PrintParagraps(bodyBoldFont, indicationTitle.ToString()))

            Dim indicationBody As New System.Text.StringBuilder(String.Empty)
            indicationBody.Append(StringMayBeEnteredIn(Me.stbIndication))
            indicationBody.Append(ControlChars.NewLine)
            indicationBody.Append(ControlChars.NewLine)
            PathologyParagraphs.Add(New PrintParagraps(bodyNormalFont, indicationBody.ToString()))


         

            '''''''''''''''Macroscopic'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim macroscopicTitle As New System.Text.StringBuilder(String.Empty)
            macroscopicTitle.Append("Macroscopic Appearance ")
            macroscopicTitle.Append(ControlChars.NewLine)
            PathologyParagraphs.Add(New PrintParagraps(bodyBoldFont, macroscopicTitle.ToString()))

            Dim macroscopicBody As New System.Text.StringBuilder(String.Empty)
            macroscopicBody.Append(StringMayBeEnteredIn(Me.stbMacroscopic))
            macroscopicBody.Append(ControlChars.NewLine)
            macroscopicBody.Append(ControlChars.NewLine)
            PathologyParagraphs.Add(New PrintParagraps(bodyNormalFont, macroscopicBody.ToString()))


            '''''''''''''''Microscopic'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim microscopicTitle As New System.Text.StringBuilder(String.Empty)
            microscopicTitle.Append("Microscopic Appearance ")
            microscopicTitle.Append(ControlChars.NewLine)
            PathologyParagraphs.Add(New PrintParagraps(bodyBoldFont, microscopicTitle.ToString()))

            Dim microscopicBody As New System.Text.StringBuilder(String.Empty)
            microscopicBody.Append(StringMayBeEnteredIn(Me.stbMicroscopic))
            microscopicBody.Append(ControlChars.NewLine)
            microscopicBody.Append(ControlChars.NewLine)
            PathologyParagraphs.Add(New PrintParagraps(bodyNormalFont, microscopicBody.ToString()))


            '''''''''''''''CONCLUSION'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim conclusionTitle As New System.Text.StringBuilder(String.Empty)
            conclusionTitle.Append("Diagnosis/Conclusion ")
            conclusionTitle.Append(ControlChars.NewLine)
            PathologyParagraphs.Add(New PrintParagraps(bodyBoldFont, conclusionTitle.ToString()))

            Dim conclusionBody As New System.Text.StringBuilder(String.Empty)
            conclusionBody.Append(StringMayBeEnteredIn(Me.stbDiagnosis))
            conclusionBody.Append(ControlChars.NewLine)
            conclusionBody.Append(ControlChars.NewLine)
            PathologyParagraphs.Add(New PrintParagraps(bodyNormalFont, conclusionBody.ToString()))




            Dim footerData As New System.Text.StringBuilder(String.Empty)
            Dim radiologist As String = SubstringLeft(StringMayBeEnteredIn(Me.cboPathologist))
            Dim radiologyTitle As String = StringMayBeEnteredIn(Me.cboPathologyTitleID)

            footerData.Append(ControlChars.NewLine)
            footerData.Append(FixDataLength(radiologist, footerLEN))
            footerData.Append(ControlChars.NewLine)
            footerData.Append(radiologyTitle.ToUpper())
            footerData.Append(ControlChars.NewLine)

            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + FixDataLength(CurrentUser.FullName, footerLEN) + " on " + FormatDate(Now) + _
                              " at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            PathologyParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region


End Class