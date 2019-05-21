
Option Strict On
Imports System.Text
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

Imports System.Drawing.Printing
Imports System.Collections.Generic

Imports System.Drawing.Imaging
Imports GenCode128

Public Class frmIPDLabRequests

#Region " Fields "
    Dim increment As Integer = 0
    Private currentAllSaved As Boolean = True
    Private currentRoundNo As String = String.Empty

    Private iPDAlerts As DataTable
    Private iPDAlertsStartDateTime As Date = Now

    Private WithEvents docLaboratory As New PrintDocument()
    ' The paragraphs.
    Private laboratoryParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private billCustomerName As String = String.Empty
    Private WithEvents docBarcodes As New PrintDocument()
    Private toPrintRow As Integer = -1
    Private labLabelBarCode As Collection
#End Region

#Region " Validations "

    Private Sub dtpDrawnDateTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpDrawnDateTime.Validating

        Dim errorMSG As String = "Drawn date and time can't be before round date and time!"

        Try

            Dim roundDateTime As Date = DateTimeMayBeEnteredIn(Me.stbRoundDateTime)
            Dim drawnDateTime As Date = DateTimeMayBeEnteredIn(Me.dtpDrawnDateTime)

            If GetShortDate(drawnDateTime) = AppData.NullDateValue Then Return

            If drawnDateTime < roundDateTime Then
                ErrProvider.SetError(Me.dtpDrawnDateTime, errorMSG)
                Me.dtpDrawnDateTime.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpDrawnDateTime, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

    Private Sub frmIPDLabRequests_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oVariousOptions As New VariousOptions()

        Try

       If oVariousOptions.AllowIssueStockOnLabRequest Then
                Me.lblLocationID.Enabled = True
                Me.cboLocationID.Enabled = True
                Me.SetDefaultLocation()
            Else
                Me.lblLocationID.Enabled = False
                Me.cboLocationID.Enabled = False
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadStaff()
            Me.ShowSentIPDAlerts()
            LoadLookupDataCombo(Me.clbSpecimenPrescription, LookupObjects.SpecimenDescription, False)
            'imgIDAutomation.Image = Nothing

            If InitOptions.AlertCheckPeriod > 0 Then Me.tmrIPDAlerts.Interval = 1000 * 60 * InitOptions.AlertCheckPeriod
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboRoundNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRoundNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub frmIPDLabRequests_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        ''''''''''''''''''''''
        Me.ShowSentIPDAlerts()
        ''''''''''''''''''''''
    End Sub

    Private Sub frmIPDLabRequests_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Dim message As String
        If Me.dgvTests.RowCount = 1 Then
            message = "Current laboratory test request is not saved. " + ControlChars.NewLine + "Just close anyway?"
        Else : message = "Current laboratory test requests are not saved. " + ControlChars.NewLine + "Just close anyway?"
        End If
        If Not Me.RecordSaved(True) Then
            If WarningMessage(message) = Windows.Forms.DialogResult.No Then e.Cancel = True
        End If

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnFindAdmissionNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindAdmissionNo.Click

        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fFindAdmissionNo As New frmFindAutoNo(Me.stbAdmissionNo, AutoNumber.AdmissionNo)
            fFindAdmissionNo.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                Me.cboRoundNo.Items.Clear()
                Me.cboRoundNo.Text = String.Empty
            Else : Me.LoadIPDDoctorByAdmissionNo()
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
            Dim roundNo As String = oIPDDoctor.GetRoundNo(admissionNo, Nothing)
            Me.cboRoundNo.Text = FormatText(roundNo, "IPDDoctor", "RoundNo")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadLabRequestsData(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return

        End Try

    End Sub

    Private Sub LoadIPDDoctorByAdmissionNo()

        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim admissionNo As String = RevertText(StringEnteredIn(Me.stbAdmissionNo, "Admission No!"))

            If String.IsNullOrEmpty(admissionNo) Then Return

            ' Load from IPDDoctor 
            Dim iPDDoctor As DataTable = oIPDDoctor.GetIPDDoctorByAdmissionNo(admissionNo).Tables("IPDDoctor")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboRoundNo.Items.Clear()
            For pos As Integer = 0 To iPDDoctor.Rows.Count - 1
                Me.cboRoundNo.Items.Add(FormatText(CStr(iPDDoctor.Rows(pos).Item("RoundNo")), "IPDDoctor", "RoundNo"))
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub SetDefaultLocation()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboLocationID, LookupObjects.Location, False)

            If Not String.IsNullOrEmpty(InitOptions.Location) Then
                Me.cboLocationID.SelectedValue = GetLookupDataID(LookupObjects.Location, InitOptions.Location)
                Me.EnableSetInventoryLocation()
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub EnableSetInventoryLocation()

        Dim oVariousOptions As New VariousOptions()

        Try

            Dim location As String = StringMayBeEnteredIn(Me.cboLocationID)
            If Not oVariousOptions.EnableSetInventoryLocation AndAlso Not String.IsNullOrEmpty(location) Then
                Me.cboLocationID.Enabled = False
            Else : Me.cboLocationID.Enabled = True
            End If

        Catch ex As Exception
            Me.cboLocationID.Enabled = True

        End Try

    End Sub

    Private Sub btnFindRoundNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindRoundNo.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindRoundNo As New frmFindAutoNo(Me.cboRoundNo, AutoNumber.RoundNo)
        fFindRoundNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.cboRoundNo))
        If String.IsNullOrEmpty(roundNo) Then Return
        Me.LoadLabRequestsData(roundNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnFindSpecimenNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindSpecimenNo.Click
        Dim fFindSpecimenNo As New frmFindAutoNo(Me.stbSpecimenNo, AutoNumber.SpecimenNo)
        fFindSpecimenNo.ShowDialog(Me)
        Me.stbSpecimenNo.Focus()
    End Sub

    Private Sub txtSpecimenNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbSpecimenNo.TextChanged
        Me.CallOnKeyEdit()
    End Sub

    Private Sub btnLoadToLabAdmissions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadToLabAdmissions.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPendingIPDItems As New frmPendingIPDItems(Me.cboRoundNo, AlertItemCategory.Test)
            fPendingIPDItems.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.cboRoundNo))
            If String.IsNullOrEmpty(roundNo) Then Return
            LoadLabRequestsData(roundNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

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
            LoadComboData(Me.cboDrawnBy, staff, "StaffFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadLabRequests(ByVal roundNo As String)

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim oLabTests As New SyncSoft.SQLDb.LabTests()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.dgvTests.Rows.Clear()

            If String.IsNullOrEmpty(roundNo) Then Return

            ''loads unpaid cash
            Dim labRequests As DataTable = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Test, oItemStatusID.Pending).Tables("IPDItems")

            If labRequests Is Nothing OrElse labRequests.Rows.Count < 1 Then

                Dim message As String
                Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)
                Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)

                If String.IsNullOrEmpty(billMode) Then Return

                If billMode.ToUpper().Equals(cashAccountNo.ToUpper()) Then
                    message = "This visit has no pending requests or is waiting for payment first!"
                Else : message = "This visit has no pending requests!"
                End If

                DisplayMessage(message)
                Return

            End If

            For pos As Integer = 0 To labRequests.Rows.Count - 1

                Dim row As DataRow = labRequests.Rows(pos)

                Dim quantity As Integer = IntegerMayBeEnteredIn(row, "Quantity")
                Dim unitPrice As Decimal = DecimalMayBeEnteredIn(row, "UnitPrice")
                Dim drNotes As String = StringMayBeEnteredIn(row, "ItemDetails")
                Dim amount As Decimal = quantity * unitPrice

                Dim itemCode As String = StringEnteredIn(row, "ItemCode")
                Dim itemName As String = StringEnteredIn(row, "ItemName")
                Dim labTests As DataTable = oLabTests.GetLabTests(itemCode).Tables("LabTests")

                With Me.dgvTests

                    .Rows.Add()

                    .Item(Me.colInclude.Name, pos).Value = True
                    .Item(Me.colTestCode.Name, pos).Value = itemCode
                    .Item(Me.colTestName.Name, pos).Value = itemName
                    .Item(Me.colQuantity.Name, pos).Value = quantity
                    .Item(Me.ColDrNotes.Name, pos).Value = drNotes
                    .Item(Me.colUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colSpecimen.Name, pos).Value = labTests.Rows(0).Item("SpecimenType").ToString()
                    .Item(Me.colLab.Name, pos).Value = labTests.Rows(0).Item("Lab").ToString()
                    .Item(Me.ColTubeType.Name, pos).Value = labTests.Rows(0).Item("TubeType").ToString()
                    .Item(Me.colPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")

                End With

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateTotalBill()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then Me.SetNextSpecimenNo(visitNo, patientNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundDateTime As Date = DateMayBeEnteredIn(Me.stbRoundDateTime)
            If roundDateTime = AppData.NullDateValue Then Return
            Me.DeleteIPDAlerts(roundNo, roundDateTime)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboRoundNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRoundNo.Enter

        Try
            currentAllSaved = Me.RecordSaved(False)
            If Not currentAllSaved Then
                currentRoundNo = StringMayBeEnteredIn(Me.cboRoundNo)
                ProcessTabKey(True)
            Else : currentRoundNo = String.Empty
            End If

        Catch ex As Exception
            currentRoundNo = String.Empty
        End Try

    End Sub

    Private Sub cboRoundNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRoundNo.Leave

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) AndAlso Not String.IsNullOrEmpty(currentRoundNo) Then
                Me.cboRoundNo.Text = currentRoundNo
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.cboRoundNo))
            If String.IsNullOrEmpty(roundNo) Then Return
            LoadLabRequestsData(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboRoundNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRoundNo.SelectedIndexChanged
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not currentAllSaved AndAlso Not String.IsNullOrEmpty(currentRoundNo) Then
            Me.cboRoundNo.Text = currentRoundNo
            Return
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ClearControls()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
        Me.cboDrawnBy.SelectedIndex = -1
        Me.cboDrawnBy.SelectedIndex = -1
        billCustomerName = String.Empty
        Me.stbVisitCategory.Clear()
        Me.stbAttendingDoctor.Clear()
        Me.stbDoctorContact.Clear()
        Me.stbAdmissionDateTime.Clear()
        Me.stbRoundDateTime.Clear()
        Me.lblAgeString.Text = String.Empty
        ResetControlsIn(Me.pnlBill)


    End Sub

    Private Sub LoadLabRequestsData(ByVal roundNo As String)

        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '  ResetControlsIn(Me.pnlNavigateRounds)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.ShowPatientDetails(roundNo)
            Me.LoadLabRequests(roundNo)
            Me.GenerateBarcode()
            Me.loadPossibleConsumables()
        Catch ex As Exception
            ErrorMessage(ex)


        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal roundNo As String)

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(roundNo) Then Return

            Dim iPDDoctor As DataTable = oIPDDoctor.GetIPDDoctor(roundNo).Tables("IPDDoctor")
            Dim row As DataRow = iPDDoctor.Rows(0)

            Dim patientNo As String = StringEnteredIn(row, "PatientNo")
            Dim visitNo As String = StringEnteredIn(row, "VisitNo")
            Dim accountNo As String = StringEnteredIn(row, "BillNo")
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
            Dim birthDate As Date = DateMayBeEnteredIn(row, "BirthDate")
            Me.lblAgeString.Text = GetAgeString(birthDate, True)
            Me.stbAdmissionStatus.Text = StringEnteredIn(row, "AdmissionStatus")
            Me.stbBillNo.Text = FormatText(accountNo, "BillCustomers", "AccountNo")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            billCustomerName = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Me.stbVisitCategory.Text = StringEnteredIn(row, "VisitCategory")
            Me.stbAttendingDoctor.Text = StringMayBeEnteredIn(row, "AttendingDoctor")
            Me.stbDoctorContact.Text = StringMayBeEnteredIn(row, "DoctorContact")
            Me.stbRoundDateTime.Text = FormatDateTime(DateTimeEnteredIn(row, "RoundDateTime"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboDrawnBy.Text = oStaff.GetCurrentStaffFullName

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                Dim roundDateTime As Date = DateTimeEnteredIn(row, "RoundDateTime")
                If Not GetShortDate(roundDateTime).Equals(GetShortDate(Today)) Then
                    Me.dtpDrawnDateTime.Value = roundDateTime
                    Me.dtpDrawnDateTime.Checked = False
                Else : Me.dtpDrawnDateTime.Value = Now
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetNextSpecimenNo(ByVal visitNo As String, ByVal patientNo As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oLabRequests As New SyncSoft.SQLDb.LabRequests()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Me.stbSpecimenNo.Clear()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("LabRequests", "SpecimenNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim specimenID As String = oLabRequests.GetNextSpecimenID(visitNo).ToString()
            specimenID = specimenID.PadLeft(paddingLEN, paddingCHAR)

            Me.stbSpecimenNo.Text = FormatText(patientNo + specimenID.Trim(), "LabRequests", "SpecimenNo")

        Catch ex As Exception
            Return

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
            iPDAlerts = oIPDAlerts.GetIPDAlerts(oAlertTypeID.LabRequests).Tables("IPDAlerts")

            Dim iPDAlertsNo As Integer = iPDAlerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblIPDAlerts.Text = "Doctor Lab Requests: " + iPDAlertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            iPDAlertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return iPDAlertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub btnViewList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewList.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowSentIPDAlerts()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fIPDAlerts As New frmIPDAlerts(oAlertTypeID.LabRequests, Me.cboRoundNo)
        fIPDAlerts.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.cboRoundNo))
        If String.IsNullOrEmpty(roundNo) Then Return
        LoadLabRequestsData(roundNo)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub DeleteIPDAlerts(ByVal roundNo As String, ByVal roundDateTime As Date)

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()

        Try
            Me.Cursor = Cursors.WaitCursor

            If iPDAlerts Is Nothing OrElse iPDAlerts.Rows.Count < 1 Then Return

            Dim miniIPDAlerts As EnumerableRowCollection(Of DataRow) = iPDAlerts.AsEnumerable()

            Dim alertID As Integer = (From data In miniIPDAlerts
                                        Where data.Field(Of String)("RoundNo").ToUpper().Equals(roundNo.ToUpper()) _
                                        And GetShortDate(data.Field(Of Date)("RoundDateTime")).Equals(GetShortDate(roundDateTime)) _
                                        Select data.Field(Of Integer)("AlertID")).First()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
            If period > InitOptions.AlertCheckPeriod Then
                If Me.ShowSentIPDAlerts() > 0 Then If InitOptions.AlertSoundOn Then Beep()
            End If


        Catch eX As Exception
            Return

        End Try

    End Sub

#End Region

    Private Function RecordSaved(ByVal hideMessage As Boolean) As Boolean

        Try
            Dim message As String

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return True

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvTests.RowCount >= 1 Then
                If Me.dgvTests.RowCount = 1 Then
                    message = "Please ensure that current laboratory test request is saved!"
                Else : message = "Please ensure that current laboratory test requests are saved!"
                End If
                If Not hideMessage Then DisplayMessage(message)
                Me.ebnSaveUpdate.Focus()
                Me.BringToFront()
                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                Return False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True

        Catch ex As Exception
            Return True

        End Try

    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oLabRequests As New SyncSoft.SQLDb.LabRequests()
            Dim oLabRequestDetails As New SyncSoft.SQLDb.LabRequestDetails()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oItemStatusID As New LookupDataID.ItemStatusID()

            Dim lLabRequests As New List(Of DBConnect)
            Dim lIPDItems As New List(Of DBConnect)
            Dim transactions As New List(Of TransactionList(Of DBConnect))

            Dim specimenNo As String = RevertText(StringEnteredIn(Me.stbSpecimenNo, "Specimen No!"))
            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oLabRequests.SpecimenNo = specimenNo
            Dim labRequestDetails As DataTable = oLabRequestDetails.GetLabRequestDetails(specimenNo).Tables("LabRequestDetails")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lLabRequests.Add(oLabRequests)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To labRequestDetails.Rows.Count - 1

                Using oIPDItems As New SyncSoft.SQLDb.IPDItems()

                    With oIPDItems

                        .RoundNo = roundNo
                        .ItemCode = CStr(labRequestDetails.Rows(pos).Item("TestCode"))
                        .ItemCategoryID = oItemCategoryID.Test
                        .LastUpdate = DateEnteredIn(Me.dtpDrawnDateTime, "Drawn Date!")
                        .PayStatusID = String.Empty
                        .LoginID = CurrentUser.LoginID
                        .ItemStatusID = oItemStatusID.Pending

                    End With

                    lIPDItems.Add(oIPDItems)

                End Using
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lLabRequests, Action.Delete))
            transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Update))

            DoTransactions(transactions)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            DisplayMessage("Record successfully deleted!")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            ResetControlsIn(Me.pnlBill)
            Me.CallOnKeyEdit()

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim oLabRequests As New SyncSoft.SQLDb.LabRequests()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim specimenNo As String = RevertText(StringEnteredIn(Me.stbSpecimenNo, "Specimen No!"))
            Dim dataSource As DataTable = oLabRequests.GetLabRequests(specimenNo).Tables("LabRequests")
            Me.DisplayData(dataSource)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.cboRoundNo))
            If String.IsNullOrEmpty(roundNo) Then Return
            LoadLabRequestsData(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvTests_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTests.CellContentClick
        Try
            loadPossibleConsumables()
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub


    Private Sub loadPossibleConsumables()
        Try
            Dim attachedTestcode As New StringBuilder(String.Empty)
            Dim oConsumableItem As New SyncSoft.SQLDb.PossibleAttachedItems
            Dim atleastOneRowSelected As Boolean = False
            Me.dgvConsumables.Rows.Clear()

            For Each row As DataGridViewRow In Me.dgvTests.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvTests.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    atleastOneRowSelected = True
                    attachedTestcode.Append(Me.FormatedAttachedItem(StringMayBeEnteredIn(row.Cells, Me.colTestCode)))
                End If
            Next



            If atleastOneRowSelected = True Then

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim toIssueConsumables As DataTable = oConsumableItem.GetPossibleAttachedconsumablesExt(FormatedAttachedItemExt(attachedTestcode.ToString)).Tables("PossibleAttachedItems")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                For pos As Integer = 0 To toIssueConsumables.Rows.Count - 1

                    Dim row As DataRow = toIssueConsumables.Rows(pos)

                    Dim consumableNo As String = RevertText(StringEnteredIn(row, "ItemCode"))
                    Dim quantity As Integer = IntegerMayBeEnteredIn(row, "Quantity")
                    With Me.dgvConsumables

                        .Rows.Add()

                        .Item(Me.ColConsumableInclude.Name, pos).Value = True
                        .Item(Me.colConsumableNo.Name, pos).Value = consumableNo
                        .Item(Me.colConsumablesConsumableName.Name, pos).Value = StringEnteredIn(row, "ConsumableName")
                        .Item(Me.colConsumableNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")
                        .Item(Me.colConsumableQuantity.Name, pos).Value = quantity
                        .Item(Me.colConsumablesTestName.Name, pos).Value = StringMayBeEnteredIn(row, "TestName")
                        Me.ShowConsumableDetails(consumableNo, pos)

                    End With

                Next

            End If


        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub DetailConsumableLocationBalance()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oInventoryLocation As New SyncSoft.SQLDb.InventoryLocation()

        Try

            Dim locationID As String = StringValueMayBeEnteredIn(Me.cboLocationID, "Location!")
            If String.IsNullOrEmpty(locationID) Then Return

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For

                Dim consumableNo As String = StringMayBeEnteredIn(row.Cells, Me.colConsumableNo)
                If String.IsNullOrEmpty(consumableNo) Then Continue For

                Me.dgvConsumables.Item(Me.ColLocationBalance.Name, row.Index).Value = String.Empty
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim inventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(locationID, oItemCategoryID.Consumable, consumableNo).Tables("InventoryLocation")
                If inventoryLocation Is Nothing OrElse inventoryLocation.Rows.Count < 1 Then Continue For
                Dim inventoryRow As DataRow = inventoryLocation.Rows(0)

                Me.dgvConsumables.Item(Me.ColLocationBalance.Name, row.Index).Value = IntegerMayBeEnteredIn(inventoryRow, "UnitsAtHand")

                Me.ShowConsumableDetails(consumableNo, row.Index)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub cboLocationID_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboLocationID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.DetailConsumableLocationBalance()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function FormatedAttachedItem(ByVal TestCode As String) As String
        Dim result As String = String.Empty
        Try
            'Dim return1 As String = ItemCategoryID.Replace(",", "','") '.Insert(0, "'")
            'Dim return2 As String = TestCode.Insert(0, "'")
            'Dim return3 As String = return2.Insert(return2.Count, "'")
            Dim return4 As String = TestCode.Insert(TestCode.Count, ",")
            result = return4
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
        Return result

    End Function

    Private Function FormatedAttachedItemExt(ByVal FormatedAttached As String) As String
        Dim result As String = String.Empty
        Try
            'Dim return1 As String = FormatedAttached.Remove(FormatedAttached.Count - 2, 2).Remove(0, 1)
            Dim return1 As String = FormatedAttached.Remove(FormatedAttached.Count - 1, 1) '.Remove(0, 1)
            result = return1

        Catch ex As Exception
            ErrorMessage(ex)
        End Try
        Return result

    End Function

    Private Sub ShowConsumableDetails(ByVal consumableNo As String, ByVal pos As Integer)

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try

            Dim consumableItems As DataTable = oConsumableItems.GetConsumableItems(consumableNo).Tables("ConsumableItems")

            If consumableItems Is Nothing OrElse consumableNo Is Nothing Then Return
            Dim row As DataRow = consumableItems.Rows(0)

            With Me.dgvConsumables
                .Item(Me.ColUnitsinstock.Name, pos).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colConsumableExpiryDate.Name, pos).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colConsumableOrderLevel.Name, pos).Value = IntegerMayBeEnteredIn(row, "OrderLevel")
                .Item(Me.colConsumableAlternateName.Name, pos).Value = StringMayBeEnteredIn(row, "AlternateName")
                .Item(Me.ColConUnitMeasure.Name, pos).Value = StringMayBeEnteredIn(row, "UnitMeasure")
            End With

        Catch ex As Exception
            Throw ex

        End Try

    End Sub



    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim message As String
        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oVariousOptions As New VariousOptions()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oStockTypeID As New LookupDataID.StockTypeID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oLabRequests As New SyncSoft.SQLDb.LabRequests()
            Dim oLabRequestsIPD As New SyncSoft.SQLDb.LabRequestsIPD()

            Dim lLabRequests As New List(Of DBConnect)
            Dim lLabRequestsIPD As New List(Of DBConnect)
            Dim lLabRequestDetails As New List(Of DBConnect)
            Dim lIPDItems As New List(Of DBConnect)
            Dim lInventory As New List(Of DBConnect)

            Dim transactions As New List(Of TransactionList(Of DBConnect))

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim specimenNo As String = RevertText(StringEnteredIn(stbSpecimenNo, "Specimen No"))
            Dim specimenDes As String = StringToSplitSelectedInAtleastOne(Me.clbSpecimenPrescription, "Specimen Description")
            Dim drawnBy As String = SubstringEnteredIn(Me.cboDrawnBy, "Drawn By (Staff)!")
            Dim drawnDateTime As Date = DateTimeEnteredIn(Me.dtpDrawnDateTime, "drawn date and time!")
            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvTests.RowCount < 1 Then
                Throw New ArgumentException("Must register at least one entry for lab test " + ControlChars.NewLine +
                                            "If this is a cash patient, ensure that payment is done first!")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvTests.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvTests.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If nonSelected Then Throw New ArgumentException("Must include at least one entry for test!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim staffRow As DataRow = oStaff.GetStaff(drawnBy).Tables("Staff").Rows(0)
            Dim userLoginID As String = StringMayBeEnteredIn(staffRow, "LoginID")

            If oVariousOptions.RestrictDrawnByLoginID AndAlso Not userLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then

                message = "The Drawn By (Staff) you have selected has a different associated login ID from that " +
                "of the current user." + ControlChars.NewLine + "The system is set not to allow a login ID not associated with selected staff. " +
               "Contact administrator if you still need to do this."

                Throw New ArgumentException(message)

            ElseIf String.IsNullOrEmpty(userLoginID) Then
                message = "The Drawn By (Staff) you have selected does not have an associated login ID. We recommend " +
               "that you contact the administrator to have this fixed. " + ControlChars.NewLine + "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

            ElseIf Not userLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then
                message = "The Drawn By (Staff) you have selected has a different associated login ID from that " +
                "of the current user. " + ControlChars.NewLine + "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With oLabRequests

                .SpecimenNo = specimenNo
                .SpecimenDes = specimenDes
                .DrawnBy = drawnBy
                .VisitNo = visitNo
                .DrawnDateTime = drawnDateTime
                .LoginID = CurrentUser.LoginID

            End With

            With oLabRequestsIPD
                .SpecimenNo = specimenNo
                .RoundNo = roundNo
            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me)
            ValidateEntriesIn(Me, ErrProvider)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lLabRequests.Add(oLabRequests)
            lLabRequestsIPD.Add(oLabRequestsIPD)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundDateTime As Date = DateTimeMayBeEnteredIn(Me.stbRoundDateTime)

            If drawnDateTime < roundDateTime Then
                Throw New ArgumentException("Drawn date and time can't be before round date and time!")

            ElseIf drawnDateTime > Now Then
                Throw New ArgumentException("Drawn date and time can't be a head of current date and time!")

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lLabRequests, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lLabRequestsIPD, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.chkPrintLabRequestOnSaving.Checked Then Me.PrintLaboratory()
                    If Me.chkPrintLabBarcode.Checked Then Me.PrintLabBarcodes()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lLabRequests, Action.Update, "LabRequests"))
                    transactions.Add(New TransactionList(Of DBConnect)(lLabRequestsIPD, Action.Update, "LabRequestsIPD"))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select

            For rowNo As Integer = 0 To Me.dgvTests.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvTests.Rows(rowNo).Cells
                Dim testCode As String = StringEnteredIn(cells, Me.colTestCode, "test code!")

                If CBool(Me.dgvTests.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Using oLabRequestDetails As New SyncSoft.SQLDb.LabRequestDetails()

                        With oLabRequestDetails

                            .SpecimenNo = specimenNo
                            .TestCode = testCode
                            .Notes = StringMayBeEnteredIn(cells, Me.colNotes)
                            .LoginID = CurrentUser.LoginID

                        End With

                        lLabRequestDetails.Add(oLabRequestDetails)

                    End Using

                    Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                        With oIPDItems

                            .RoundNo = roundNo
                            .ItemCode = testCode
                            .ItemCategoryID = oItemCategoryID.Test
                            .LastUpdate = DateEnteredIn(Me.dtpDrawnDateTime, "Drawn Date!")
                            .PayStatusID = String.Empty
                            .LoginID = CurrentUser.LoginID
                            .ItemStatusID = oItemStatusID.Processing

                        End With

                        lIPDItems.Add(oIPDItems)

                    End Using
                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''' Issue Stock at Lab Starts Here  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oVariousOptions.AllowIssueStockOnLabRequest Then
                Dim location As String = StringMayBeEnteredIn(Me.cboLocationID)
                Dim locationID As String = StringValueEnteredIn(Me.cboLocationID, "Location!")
                If Not String.IsNullOrEmpty(InitOptions.Location) AndAlso
                   Not InitOptions.Location.ToUpper().Equals(GetLookupDataDes(locationID).ToUpper()) Then

                    message = "Selected location " + location + " is not the same as " + InitOptions.Location +
                        " set for this point. " + ControlChars.NewLine + "Are you sure you want to continue?"

                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.cboLocationID.Focus() : Return
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 1

                    If CBool(Me.dgvConsumables.Item(Me.ColConsumableInclude.Name, rowNo).Value) = True Then

                        Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells
                        Dim consumableNo As String = StringEnteredIn(cells, Me.colConsumableNo, "consumable no!")
                        Dim consumableName As String = StringEnteredIn(cells, Me.colConsumablesConsumableName, "consumable name!")
                        Dim TestName As String = StringEnteredIn(cells, Me.colConsumablesTestName, "Test name!")
                        Dim quantity As Integer = IntegerEnteredIn(cells, Me.colConsumableQuantity, "quantity!")
                        Dim unitsInStock As Integer = IntegerMayBeEnteredIn(cells, Me.ColUnitsinstock)
                        Dim orderLevel As Integer = IntegerMayBeEnteredIn(cells, Me.colConsumableOrderLevel)
                        Dim expiryDate As Date = DateMayBeEnteredIn(cells, Me.colConsumableExpiryDate)
                        Dim warningDaysExpiryDate As Integer = oVariousOptions.ExpiryWarningDays
                        Dim remainingDaysExpiryDate As Integer = (expiryDate - Today).Days
                        Dim deficit As Integer = quantity - unitsInStock

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If quantity > 0 AndAlso unitsInStock < quantity Then
                            If Not oVariousOptions.AllowDispensingToNegative() Then

                                message = "Insufficient stock to give for " + consumableName + " with a deficit of " + deficit.ToString() +
                                   ControlChars.NewLine + "The system does not allow to give a consumable that is out of stock. " +
                                   "Please re-stock appropriately! "

                                Throw New ArgumentException(message)
                            Else
                                message = "Insufficient stock to give for " + consumableName + " with a deficit of " + deficit.ToString() +
                                          ControlChars.NewLine + "Are you sure you want to continue?"
                                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                            End If

                        ElseIf orderLevel >= unitsInStock - quantity Then

                            message = "Stock level for " + consumableName + " is running low. Please re-stock appropriately!"
                            DisplayMessage(message)

                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim locationBalance As Integer = GetInventoryBalance(locationID, oItemCategoryID.Consumable, consumableNo)
                        If quantity > 0 AndAlso locationBalance < quantity Then
                            If Not oVariousOptions.AllowLocationIssuingToNegative() Then
                                message = "The system does not allow issuing of consumable: " + consumableName + ", with unit(s) not present at " + location + "!"
                                Throw New ArgumentException(message)
                            Else
                                message = "You are about to issue consumable: " + consumableName + ", with unit(s) not present at " + location + ". " +
                                          ControlChars.NewLine + "Are you sure you want to continue?"
                                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                            End If
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If expiryDate > AppData.NullDateValue AndAlso expiryDate < Today Then
                            If Not oVariousOptions.AllowDispensingExpiredConsumables() Then
                                message = "Expiry date for " + consumableName + " had reached. " +
                                    "The system does not allow to dispence a consumable that is expired. Please re-stock appropriately! "
                                Throw New ArgumentException(message)
                            Else
                                message = "Expiry date for " + consumableName + " had reached. " +
                                          ControlChars.NewLine + "Are you sure you want to continue?"
                                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                            End If

                        ElseIf expiryDate > AppData.NullDateValue AndAlso remainingDaysExpiryDate <= warningDaysExpiryDate Then
                            message = "Consumable: " + consumableName + " has " + remainingDaysExpiryDate.ToString() +
                                " remaining day(s) to expire. Please re-stock appropriately!"
                            DisplayMessage(message)

                        ElseIf expiryDate = AppData.NullDateValue Then
                            message = "Expiry date for " + consumableName + " is not set. The system can not verify when this consumable will expire!"
                            DisplayMessage(message)

                        End If

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        Using oInventory As New SyncSoft.SQLDb.Inventory()


                            With oInventory
                                .LocationID = locationID
                                .ItemCategoryID = oItemCategoryID.Consumable
                                .ItemCode = consumableNo
                                .TranDate = Today
                                .StockTypeID = oStockTypeID.Issued
                                .Quantity = quantity
                                .Details = "Consumable(s) Attached to Test:" + TestName + " Issued to Round No: " + roundNo
                                .EntryModeID = oEntryModeID.System
                                .LoginID = CurrentUser.LoginID
                                .BatchNo = String.Empty
                                .ExpiryDate = AppData.NullDateValue
                            End With
                            lInventory.Add(oInventory)


                        End Using
                    End If
                Next
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''' Issue Stock at Lab Ends Here  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



            transactions.Add(New TransactionList(Of DBConnect)(lLabRequestDetails, Action.Save, "LabRequestDetails"))
            transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Update))
            transactions.Add(New TransactionList(Of DBConnect)(lInventory, Action.Save))
            DoTransactions(transactions)
            Me.GenerateBarcode()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim allSelected As Boolean = True

            For Each row As DataGridViewRow In Me.dgvTests.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvTests.Item(Me.colInclude.Name, row.Index).Value) = False Then
                    allSelected = False
                    Me.LoadLabRequests(roundNo)
                    Me.GenerateBarcode()
                    Exit For
                End If
                allSelected = True
            Next

            If allSelected Then
                Me.dgvTests.Rows.Clear()
                Me.dgvConsumables.Rows.Clear()
                ResetControlsIn(Me)
                ResetControlsIn(Me.pnlBill)
                ' Me.LoadToLabVisits()
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.chkPrintLabRequestOnSaving.Checked = True
            Me.CallOnKeyEdit()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentIPDAlerts()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub CalculateTotalBill()

        Dim totalBill As Decimal

        Me.stbBillForLaboratory.Clear()

        For rowNo As Integer = 0 To Me.dgvTests.RowCount - 1

            If CBool(Me.dgvTests.Item(Me.colInclude.Name, rowNo).Value) = True Then
                If IsNumeric(Me.dgvTests.Item(Me.colAmount.Name, rowNo).Value) Then
                    totalBill += CDec(Me.dgvTests.Item(Me.colAmount.Name, rowNo).Value)
                Else : totalBill += 0
                End If
            End If
        Next

        Me.stbBillForLaboratory.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub dgvTests_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTests.CellEndEdit
        Try
            loadPossibleConsumables()
            Me.CalculateTotalBill()
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub


#Region " Laboratory Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintLaboratory()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintLaboratory()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvTests.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for lab request!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvTests.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvTests.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry for lab request!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetLaboratoryPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docLaboratory
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docLaboratory.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docLaboratory_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docLaboratory.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = CSng(e.MarginBounds.Left / 10)
            Dim yPos As Single = CSng(e.MarginBounds.Top / 8)

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Laboratory Request".ToUpper()

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim specimenNo As String = StringMayBeEnteredIn(Me.stbSpecimenNo)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim drawnBy As String = SubstringLeft(StringMayBeEnteredIn(Me.cboDrawnBy))
            Dim drawnDateTime As String = StringMayBeEnteredIn(Me.dtpDrawnDateTime)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim primaryDoctor As String = StringMayBeEnteredIn(Me.stbAttendingDoctor)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 11 * widthTopFirst

                'Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                'Dim widthTopSecond As Single = 9 * widthTopFirst
                'Dim widthTopThird As Single = 21 * widthTopFirst
                'Dim widthTopFourth As Single = 30 * widthTopFirst

                If pageNo < 2 Then

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Gender/Age: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(gender + "/" + age, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Specimen No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(specimenNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Drawn Date/Time: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(drawnDateTime, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Drawn By: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(drawnBy, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Mode: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Primary Doctor: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(primaryDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Customer Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
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

                If laboratoryParagraphs Is Nothing Then Return

                Do While laboratoryParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(laboratoryParagraphs(1), PrintParagraps)
                    laboratoryParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(xPos, yPos, e.PageBounds.Width - xPos, e.MarginBounds.Bottom - yPos)

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
                        laboratoryParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (laboratoryParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetLaboratoryPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 40

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        laboratoryParagraphs = New Collection

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Test Name: ".PadRight(padItemName))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            laboratoryParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            For rowNo As Integer = 0 To Me.dgvTests.RowCount - 1

                If CBool(Me.dgvTests.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvTests.Rows(rowNo).Cells

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim itemName As String = cells.Item(Me.colTestName.Name).Value.ToString()

                    tableData.Append(itemNo.PadRight(padItemNo))
                    tableData.Append(itemName.PadRight(padItemName))

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            laboratoryParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") + _
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            laboratoryParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region "Print Barcode LabResults"

    Private Sub PrintLabBarcodes()

        Dim Message As String
        Try
            If Me.chkPrintLabBarcode.Checked = True Then

                For Each row As DataGridViewRow In Me.dgvTests.Rows
                    If row.IsNewRow Then Exit For
                    If CBool(Me.dgvTests.Item(Me.colInclude.Name, row.Index).Value) = True Then
                        Message = "You are about to print Lab Request Bar Code for " + CStr(Me.dgvTests.Item(Me.colTestName.Name, row.Index).Value) +
                        ControlChars.NewLine + "Are you sure you want to continue?"
                        toPrintRow = row.Index
                        If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then
                            Me.PrintBarcodes()
                        End If

                    End If
                Next
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub GenerateBarcode()
        Try
            Dim imageweight As Integer = 2
            'Barcode using the GenCode128
            If Not String.IsNullOrEmpty(stbSpecimenNo.Text) Then

                Dim barcodeImage As Image = Code128Rendering.MakeBarcodeImage(RevertText(stbSpecimenNo.Text.ToString()), Integer.Parse(imageweight.ToString()), True)
                imgIDAutomation.Image = barcodeImage

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub docBarcodes_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docBarcodes.PrintPage
        Try
            SetPrintBarCode(e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintBarcodes()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvTests.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for Lab request!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvTests.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvTests.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry for Lab request!")


            dlgPrint.Document = docBarcodes
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docBarcodes.Print()


        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SetPrintBarCode(ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        Dim footerFont As New Font(printFontName, 8)

        pageNo = 0
        labLabelBarCode = New Collection()

        Try

            Dim rect As New Rectangle(0, 10, 200, 85)
            Dim sf As New StringFormat
            sf.LineAlignment = StringAlignment.Center
            Dim printFont10_Normal As New Font("Calibri", 10, FontStyle.Regular, GraphicsUnit.Point)
            rect = New Rectangle(0, 10, 200, 15)
            e.Graphics.DrawRectangle(Pens.White, rect)

            Dim h, w As Integer

            Dim cells As DataGridViewCellCollection = Me.dgvTests.Rows(toPrintRow).Cells
            Dim labName As String = "(LAB) - " + " " + cells.Item(Me.colTestName.Name).Value.ToString()
            w = imgIDAutomation.Width
            h = imgIDAutomation.Height
            rect = New Rectangle(0, 0, w, h)
            e.Graphics.InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            e.Graphics.DrawImage(imgIDAutomation.Image, rect)
            rect = New Rectangle(5, 0, w, 120)
            e.Graphics.DrawString(RevertText(stbSpecimenNo.Text.ToString()), printFont10_Normal, Brushes.Black, rect, sf)
            rect = New Rectangle(5, 0, w, 145)
            e.Graphics.DrawString(stbFullName.Text.ToString(), printFont10_Normal, Brushes.Black, rect, sf)
            rect = New Rectangle(5, 0, w, 185)
            e.Graphics.DrawString(labName.ToString, printFont10_Normal, Brushes.Black, rect, sf)
            e.Graphics.DrawRectangle(Pens.White, rect)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnPrintBarcode_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintBarcode.Click
        Me.PrintLabBarcodes()
    End Sub

#End Region

#Region " Rounds Navigate "

    Private Sub EnableNavigateRoundsCTLS(ByVal state As Boolean)

        Dim startPosition As Integer
        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
                Dim admissionNo As String = RevertText(StringEnteredIn(Me.stbAdmissionNo, "Admission No!"))
                Dim iPDDoctor As DataTable = oIPDDoctor.GetIPDDoctorByAdmissionNoNavigate(admissionNo).Tables("IPDDoctor")

                For pos As Integer = 0 To iPDDoctor.Rows.Count - 1
                    If roundNo.ToUpper().Equals(iPDDoctor.Rows(pos).Item("RoundNo").ToString().ToUpper()) Then
                        startPosition = pos + 1
                        Exit For
                    Else : startPosition = 1
                    End If
                Next

                Me.navRounds.DataSource = iPDDoctor
                Me.navRounds.Navigate(startPosition)

            Else : Me.navRounds.Clear()
            End If

        Catch eX As Exception
            Me.chkNavigateRounds.Checked = False
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkNavigateRounds_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNavigateRounds.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.EnableNavigateRoundsCTLS(Me.chkNavigateRounds.Checked)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navRounds.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(currentValue.ToString())
            If String.IsNullOrEmpty(roundNo) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboRoundNo.Text = FormatText(roundNo, "IPDDoctor", "RoundNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadLabRequestsData(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Edit Methods "

    Public Sub Edit()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.btnDelete.Visible = True
        Me.btnDelete.Enabled = False
        Me.btnSearch.Visible = True

        Me.cboRoundNo.Enabled = False
        Me.btnFindRoundNo.Enabled = False
        Me.btnFindSpecimenNo.Enabled = True
        Me.stbSpecimenNo.ReadOnly = False

        Me.btnLoadToLabAdmissions.Enabled = False
        Me.btnPrint.Visible = False

        Me.cboRoundNo.DropDownStyle = ComboBoxStyle.DropDown

        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlBill)

        Me.chkPrintLabRequestOnSaving.Visible = False
        Me.chkPrintLabRequestOnSaving.Checked = False

    End Sub

    Private Sub cmsLabIncludeAll_Click(sender As System.Object, e As System.EventArgs) Handles cmsLabIncludeAll.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcIPDLabRequests.SelectedTab.Name

                Case Me.tpgTests.Name

                    For Each row As DataGridViewRow In Me.dgvTests.Rows
                        If row.IsNewRow Then Exit For

                        Me.dgvTests.Item(Me.colInclude.Name, row.Index).Value = True

                    Next


                Case Me.tpgPossibleConsumables.Name

                    For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                        If row.IsNewRow Then Exit For
                        Me.dgvConsumables.Item(Me.ColConsumableInclude.Name, row.Index).Value = True
                    Next




            End Select

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cmsLabIncludeNone_Click(sender As System.Object, e As System.EventArgs) Handles cmsLabIncludeNone.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcIPDLabRequests.SelectedTab.Name

                Case Me.tpgTests.Name

                    For Each row As DataGridViewRow In Me.dgvTests.Rows
                        If row.IsNewRow Then Exit For

                        Me.dgvTests.Item(Me.colInclude.Name, row.Index).Value = False

                    Next


                Case Me.tpgPossibleConsumables.Name

                    For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                        If row.IsNewRow Then Exit For
                        Me.dgvConsumables.Item(Me.ColConsumableInclude.Name, row.Index).Value = False
                    Next




            End Select

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Public Sub Save()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.btnDelete.Visible = False
        Me.btnDelete.Enabled = True
        Me.btnSearch.Visible = False

        Me.cboRoundNo.Enabled = True
        Me.btnFindRoundNo.Enabled = True 'False '
        Me.btnFindSpecimenNo.Enabled = False

        Me.btnLoadToLabAdmissions.Enabled = True
        Me.btnPrint.Visible = True

        Me.stbSpecimenNo.ReadOnly = InitOptions.SpecimenNoLocked
        Me.dtpDrawnDateTime.MaxDate = Today.AddDays(1)

        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlBill)
        Me.SetDefaultLocation()
        Me.chkPrintLabRequestOnSaving.Visible = True
        Me.chkPrintLabRequestOnSaving.Checked = True

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