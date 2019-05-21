
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

Public Class frmIPDDentalReports

#Region " Fields "

    Private tipCoPayValueWords As New ToolTip()
    Private iPDAlerts As DataTable
    Private iPDAlertsStartDateTime As Date = Now

    Private billCustomerName As String = String.Empty
    Private billModesID As String = String.Empty
    Private doctorStaffNo As String = String.Empty
    Private dentalRequestsCount As Integer = 0
    Private totalIPDDentalRequests As Integer = 0

    Private WithEvents docDental As New PrintDocument()
    ' The paragraphs.
    Private dentalParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private patientpackageNo As String = String.Empty
    Private hasPackage As Boolean = False

#End Region

#Region " Validations "

    Private Sub dtpReportDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpReportDate.Validating

        Dim errorMSG As String = "Dental report date can't be before round date!"

        Try

            Dim roundDate As Date = DateMayBeEnteredIn(Me.stbRoundDateTime)
            Dim reportDate As Date = DateMayBeEnteredIn(Me.dtpReportDate)

            If reportDate = AppData.NullDateValue Then Return

            If reportDate < roundDate Then
                ErrProvider.SetError(Me.dtpReportDate, errorMSG)
                Me.dtpReportDate.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpReportDate, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try


    End Sub

#End Region

    Private Sub frmIPDDentalReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.ShowSentIPDAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If InitOptions.AlertCheckPeriod > 0 Then Me.tmrIPDAlerts.Interval = 1000 * 60 * InitOptions.AlertCheckPeriod

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmIPDDentalReports_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowSentIPDAlerts()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub stbRoundNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbRoundNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

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
            Me.LoadDentalReportsData(roundNo)
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
        LoadDentalReportsData(roundNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnLoadPendingDental_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPendingDental.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPendingIPDItems As New frmPendingIPDItems(Me.stbRoundNo, AlertItemCategory.Dental)
            fPendingIPDItems.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
            If String.IsNullOrEmpty(roundNo) Then Return
            LoadDentalReportsData(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDentalRequests(ByVal roundNo As String)

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim iPDItems As New DataTable()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboDentalFullName.Items.Clear()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(roundNo) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                iPDItems = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Dental, oItemStatusID.Pending).Tables("IPDItems")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If iPDItems Is Nothing OrElse iPDItems.Rows.Count < 1 Then

                    Dim message As String
                    Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)
                    Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
                    If String.IsNullOrEmpty(billMode) Then Return

                    If billMode.ToUpper().Equals(cashAccountNo.ToUpper()) Then
                        message = "This round has no pending Dental service or is waiting for payment first!"
                    Else : message = "This round has no pending Dental service!"
                    End If

                    DisplayMessage(message)
                    dentalRequestsCount = 0
                    Return

                Else : dentalRequestsCount = iPDItems.Rows.Count
                End If

            ElseIf Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
                iPDItems = oIPDItems.GetIPDItems(RevertText(roundNo), oItemCategoryID.Dental, oItemStatusID.Done).Tables("IPDItems")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboDentalFullName, iPDItems, "ItemFullName")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundDateTime As Date = DateMayBeEnteredIn(Me.stbRoundDateTime)
            If roundDateTime = AppData.NullDateValue Then Return
            Me.DeleteIPDAlerts(roundNo, roundDateTime)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " IPDAlerts "

    Private Function ShowSentIPDAlerts() As Integer

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            iPDAlerts = oIPDAlerts.GetIPDAlerts(oAlertTypeID.Dental).Tables("IPDAlerts")

            Dim IPDAlertsNo As Integer = iPDAlerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblIPDAlerts.Text = "Doctor Dental: " + IPDAlertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            iPDAlertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return IPDAlertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub btnViewList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewList.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowSentIPDAlerts()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fIPDAlerts As New frmIPDAlerts(oAlertTypeID.Dental, Me.stbRoundNo)
        fIPDAlerts.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
        If String.IsNullOrEmpty(roundNo) Then Return
        LoadDentalReportsData(roundNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub DeleteIPDAlerts(ByVal roundNo As String, ByVal roundDateTime As Date)

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()

        Try
            Me.Cursor = Cursors.WaitCursor

            If iPDAlerts Is Nothing OrElse iPDAlerts.Rows.Count < 1 Then Return

            Dim miniIPDAlerts As EnumerableRowCollection(Of DataRow) = iPDAlerts.AsEnumerable()

            Dim alertID As Integer = (From data In miniIPDAlerts _
                            Where data.Field(Of String)("RoundNo").ToUpper().Equals(roundNo.ToUpper()) _
                            And GetShortDate(data.Field(Of Date)("RoundDateTime")).Equals(GetShortDate(roundDateTime)) _
                            Select data.Field(Of Integer)("AlertID")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oIPDAlerts.AlertID = alertID
            oIPDAlerts.Delete()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentIPDAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tmrIPDAlerts_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrIPDAlerts.Tick

        Try

            Dim period As Long = DateDiff(DateInterval.Minute, iPDAlertsStartDateTime, Now)
            If period >= InitOptions.AlertCheckPeriod Then
                If Me.ShowSentIPDAlerts() > 0 Then If InitOptions.AlertSoundOn Then Beep()
            End If

        Catch eX As Exception
            Return

        End Try

    End Sub

#End Region

    Private Sub stbRoundNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbRoundNo.Leave

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
        If String.IsNullOrEmpty(roundNo) Then Return
        LoadDentalReportsData(roundNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub stbRoundNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbRoundNo.TextChanged
        Me.ClearControls()
        Me.CallOnKeyEdit()
    End Sub

    Private Sub ClearControls()

        Me.stbVisitDate.Clear()
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
        patientpackageNo = String.Empty
        hasPackage = False
        ' Me.stbAdmissionNo.Clear()
        Me.stbUnitPrice.Clear()
        Me.stbCoPayType.Clear()
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.cboDentalFullName.SelectedIndex = -1
            Me.cboDentalFullName.SelectedIndex = -1
        End If
        Me.ResetControls()
    End Sub

    Private Sub ResetControls()
        Me.stbUnitPrice.Clear()
        Me.dtpReportDate.Value = Now
        Me.dtpReportDate.Checked = False
        Me.stbReport.Clear()
    End Sub

    Private Sub LoadDentalReportsData(ByVal roundNo As String)

        Try

            Me.ShowPatientDetails(roundNo)
            Me.LoadDentalRequests(roundNo)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal roundNo As String)

        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(roundNo) Then Return

            Dim iPDDoctor As DataTable = oIPDDoctor.GetIPDDoctor(roundNo).Tables("IPDDoctor")
            Dim row As DataRow = iPDDoctor.Rows(0)

            Dim patientNo As String = StringEnteredIn(row, "PatientNo")
            Dim visitNo As String = StringEnteredIn(row, "VisitNo")
            Dim billNo As String = StringEnteredIn(row, "BillNo")
            Dim admissionNo As String = StringEnteredIn(row, "AdmissionNo")

            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
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
            totalIPDDentalRequests = IntegerMayBeEnteredIn(row, "TotalIPDDentalRequests")
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
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundDateTime As Date = DateTimeEnteredIn(row, "RoundDateTime")
            Me.dtpReportDate.Value = roundDateTime
            Me.dtpReportDate.Checked = GetShortDate(roundDateTime) >= GetShortDate(Today.AddHours(-12))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboDentalFullName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDentalFullName.SelectedIndexChanged
        Me.GetDentalDetails()
        Me.CallOnKeyEdit()
    End Sub

    Private Sub GetDentalDetails()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ResetControls()

            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
            Dim dentalCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboDentalFullName))

            If String.IsNullOrEmpty(roundNo) OrElse String.IsNullOrEmpty(dentalCode) Then Return

            Dim iPDItems As DataTable = oIPDItems.GetIPDItem(roundNo, dentalCode, oItemCategoryID.Dental).Tables("IPDItems")
            If iPDItems Is Nothing OrElse iPDItems.Rows.Count < 1 Then Return
            Dim row As DataRow = iPDItems.Rows(0)

            Me.stbUnitPrice.Text = FormatNumber(DecimalMayBeEnteredIn(row, "UnitPrice"), AppData.DecimalPlaces)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                Me.stbReport.Text = StringMayBeEnteredIn(row, "ItemDetails")
                Dim roundDateTime As Date = DateTimeMayBeEnteredIn(Me.stbRoundDateTime)
                If Not roundDateTime.Equals(Today) AndAlso Not roundDateTime.Equals(AppData.NullDateValue) Then
                    Me.dtpReportDate.Value = roundDateTime
                    Me.dtpReportDate.Checked = False
                Else : Me.dtpReportDate.Value = Now
                End If
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        'Dim oIPDDentalReports As New SyncSoft.SQLDb.IPDDentalReports()
        'Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        'Try
        '    Me.Cursor = Cursors.WaitCursor()

        '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '    If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

        '    With oIPDDentalReports
        '        .roundNo = RevertText(StringEnteredIn(Me.stbroundNo, "Round No!"))
        '        .ItemCode = SubstringEnteredIn(Me.cboDentalFullName, "Dental Service!")
        '        .ItemCategoryID = oItemCategoryID.Dental
        '    End With

        '    DisplayMessage(oIPDDentalReports.Delete())
        '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '    ResetControlsIn(Me)
        '    Me.CallOnKeyEdit()

        'Catch ex As Exception
        '    ErrorMessage(ex)

        'Finally
        '    Me.Cursor = Cursors.Default()

        'End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oIPDDentalReports As New SyncSoft.SQLDb.IPDDentalReports()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))
            Dim dentalCode As String = SubstringEnteredIn(Me.cboDentalFullName, "Dental Service!")

            Dim dataSource As DataTable = oIPDDentalReports.GetIPDDentalReports(roundNo, dentalCode, oItemCategoryID.Dental).Tables("IPDDentalReports")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim records As Integer
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Dim lIPDItems As New List(Of DBConnect)
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim oIPDDentalReports As New SyncSoft.SQLDb.IPDDentalReports()
            Dim lIPDDentalReports As New List(Of DBConnect)

            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))
            Dim dentalCode As String = SubstringEnteredIn(Me.cboDentalFullName, "Dental Service!")

            With oIPDDentalReports

                .RoundNo = roundNo
                .ItemCode = dentalCode
                .ItemCategoryID = oItemCategoryID.Dental
                .ReportDate = DateEnteredIn(Me.dtpReportDate, "Report Date!")
                .Report = StringEnteredIn(Me.stbReport, "Report!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lIPDDentalReports.Add(oIPDDentalReports)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                        With oIPDItems
                            .RoundNo = roundNo
                            .ItemCode = dentalCode
                            .ItemCategoryID = oItemCategoryID.Dental
                            .LastUpdate = DateEnteredIn(Me.dtpReportDate, "Report Date!")
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
                    Dim dentalName As String = SubstringLeft(StringMayBeEnteredIn(Me.cboDentalFullName))
                    Dim quantity As Integer = 1

                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

                        With oExtraBillItems

                            .ExtraBillNo = extraBillNo
                            .ItemCode = dentalCode
                            .ItemCategoryID = oItemCategoryID.Dental
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = "Dental service: " + dentalName + ", done to Patient No: " + patientNo + " and Round No: " + roundNo
                            .LastUpdate = DateEnteredIn(Me.dtpReportDate, "Bill Date!")
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, dentalCode, oItemCategoryID.Dental).Equals(True) Then
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
                                .ItemCode = dentalCode
                                .ItemCategoryID = oItemCategoryID.Dental
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, dentalCode, oItemCategoryID.Dental).Equals(True) Then
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
                    transactions.Add(New TransactionList(Of DBConnect)(lIPDDentalReports, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Update))

                    records = DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.chkPrintDentalReportOnSaving.Checked Then Me.PrintDental()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.LoadDentalRequests(roundNo)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If GetShortDate(DateMayBeEnteredIn(Me.dtpReportDate)) >= GetShortDate(Today.AddHours(-12)) AndAlso
                        Not String.IsNullOrEmpty(doctorStaffNo) Then
                        Using oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
                            With oIPDAlerts

                                .AlertTypeID = oAlertTypeID.DentalReports
                                .RoundNo = RevertText(StringEnteredIn(Me.stbRoundNo))
                                .StaffNo = doctorStaffNo
                                .Notes = (totalIPDDentalRequests - dentalRequestsCount).ToString() + " of " + totalIPDDentalRequests.ToString() + " Done"
                                .LoginID = CurrentUser.LoginID

                                .Save()

                            End With
                        End Using
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ResetControls()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(lIPDDentalReports, Action.Update, "IPDDentalReports"))
                    records = DoTransactions(transactions)

                    DisplayMessage(records.ToString() + " record(s) updated!")

                    Me.CallOnKeyEdit()

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentIPDAlerts()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

#Region " Dental Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintDental()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintDental()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetDentalPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docDental
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docDental.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docDental_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docDental.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Dental Report".ToUpper()

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim attendingDoctor As String = StringMayBeEnteredIn(Me.stbAttendingDoctor)
            Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 21 * widthTopFirst
                Dim widthTopFourth As Single = 30 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Primary Doctor: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(attendingDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
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

                If dentalParagraphs Is Nothing Then Return

                Do While dentalParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(dentalParagraphs(1), PrintParagraps)
                    dentalParagraphs.Remove(1)

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
                        dentalParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (dentalParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetDentalPrintData()

        Dim footerLEN As Integer = 20
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        dentalParagraphs = New Collection()

        Try

            '''''''''''''''DENTAL SERVICE'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dentalTitle As New System.Text.StringBuilder(String.Empty)
            dentalTitle.Append(ControlChars.NewLine)
            dentalTitle.Append("DENTAL SERVICE: " + SubstringLeft(StringMayBeEnteredIn(Me.cboDentalFullName)))
            dentalTitle.Append(ControlChars.NewLine)
            dentalTitle.Append(ControlChars.NewLine)
            dentalParagraphs.Add(New PrintParagraps(bodyBoldFont, dentalTitle.ToString()))


            '''''''''''''''REPORT'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim reportTitle As New System.Text.StringBuilder(String.Empty)
            reportTitle.Append("REPORT ")
            reportTitle.Append(ControlChars.NewLine)
            dentalParagraphs.Add(New PrintParagraps(bodyBoldFont, reportTitle.ToString()))

            Dim reportBody As New System.Text.StringBuilder(String.Empty)
            reportBody.Append(StringMayBeEnteredIn(Me.stbReport))
            reportBody.Append(ControlChars.NewLine)
            dentalParagraphs.Add(New PrintParagraps(bodyNormalFont, reportBody.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + FixDataLength(CurrentUser.FullName, footerLEN) + " on " + FormatDate(Now) + _
                              " at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            dentalParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        'Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        Me.btnLoadPendingDental.Enabled = False
        Me.btnPrint.Visible = False

        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlroundNo)
        Me.chkPrintDentalReportOnSaving.Visible = False
        Me.chkPrintDentalReportOnSaving.Checked = False

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        'Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.btnLoadPendingDental.Enabled = True
        Me.btnPrint.Visible = True

        Me.dtpReportDate.MaxDate = Today.AddDays(1)

        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlroundNo)

        Me.chkPrintDentalReportOnSaving.Visible = True
        Me.chkPrintDentalReportOnSaving.Checked = True

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