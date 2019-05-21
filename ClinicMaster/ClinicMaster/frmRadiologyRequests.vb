
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Enumerations
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona

Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmRadiologyRequests

#Region " Fields "

    Private currentAllSaved As Boolean = True
    Private currentVisitNo As String = String.Empty

    Private accessCashServices As Boolean = False

    Private alerts As DataTable
    Private alertsStartDateTime As Date = Now

    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()

    Private WithEvents docRadiology As New PrintDocument()
    ' The paragraphs.
    Private radiologyParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private billCustomerName As String = String.Empty
    Private haspackage As Boolean = False
#End Region

#Region " Validations "

#End Region
    Dim smartLocationID As Integer
    Dim genderID As String
    Dim copayTypeID As String

    Private Sub frmRadiologyRequests_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.ShowSentAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If InitOptions.AlertCheckPeriod > 0 Then Me.tmrAlerts.Interval = 1000 * 60 * InitOptions.AlertCheckPeriod
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmRadiologyRequests_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowSentAlerts()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub frmRadiologyRequests_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim message As String
        If Me.dgvRadiology.RowCount = 1 Then
            message = "Current radiology request is not saved. " + ControlChars.NewLine + "Just close anyway?"
        Else : message = "Current radiology requests are not saved. " + ControlChars.NewLine + "Just close anyway?"
        End If
        If Not Me.RecordSaved(True) Then
            If WarningMessage(message) = Windows.Forms.DialogResult.No Then e.Cancel = True
        End If

    End Sub

    Private Sub stbVisitNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbVisitNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        Me.LoadRadiologyData(visitNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub btnLoadToRadiologyVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadToRadiologyVisits.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPendingItems As New frmPendingItems(Me.stbVisitNo, AlertItemCategory.Radiology)
            fPendingItems.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Me.LoadRadiologyData(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadRadiologyRequests(ByVal visitNo As String)

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oRadiologyExaminations As New SyncSoft.SQLDb.RadiologyExaminations()
        Dim radiologyRequests As DataTable

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dgvRadiology.Rows.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If String.IsNullOrEmpty(visitNo) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String
            Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim oVariousOptions As New VariousOptions()

            If billMode.ToUpper().Equals(cashAccountNo.ToUpper()) AndAlso Not oVariousOptions.AllowAccessCashServices AndAlso Not accessCashServices AndAlso Not haspackage Then
                radiologyRequests = oItems.GetItems(visitNo, oItemCategoryID.Radiology, oItemStatusID.Pending, oPayStatusID.PaidFor).Tables("Items")

            ElseIf billMode.ToUpper().Equals(cashAccountNo.ToUpper()) AndAlso haspackage.Equals(True) AndAlso oPayStatusID.Equals(oPayStatusID.NA) Then
                radiologyRequests = oItems.GetItems(visitNo, oItemCategoryID.Radiology, oItemStatusID.Pending).Tables("Items")

            ElseIf billMode.ToUpper().Equals(cashAccountNo.ToUpper()) AndAlso haspackage.Equals(True) AndAlso oPayStatusID.Equals(oPayStatusID.PaidFor) Then
                radiologyRequests = oItems.GetItems(visitNo, oItemCategoryID.Radiology, oItemStatusID.Pending).Tables("Items")

            Else : radiologyRequests = oItems.GetItems(visitNo, oItemCategoryID.Radiology, oItemStatusID.Pending).Tables("Items")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If radiologyRequests Is Nothing OrElse radiologyRequests.Rows.Count < 1 Then

                If String.IsNullOrEmpty(billMode) Then Return

                If billMode.ToUpper().Equals(cashAccountNo.ToUpper()) Then
                    message = "This visit has no pending requests or is waiting for payment first!"
                Else : message = "This visit has no pending requests!"
                End If

                DisplayMessage(message)
                Return

            End If
           
            For pos As Integer = 0 To radiologyRequests.Rows.Count - 1

                Dim row As DataRow = radiologyRequests.Rows(pos)

                Dim quantity As Integer = IntegerMayBeEnteredIn(row, "Quantity")
                Dim unitPrice As Decimal = DecimalMayBeEnteredIn(row, "UnitPrice")

                Dim amount As Decimal = quantity * unitPrice

                Dim itemCode As String = StringEnteredIn(row, "ItemCode")
                Dim itemName As String = StringEnteredIn(row, "ItemName")
                Dim cashAmount As Decimal = DecimalMayBeEnteredIn(row, "CashAmount")

                Dim radiologyExaminations As DataTable = oRadiologyExaminations.GetRadiologyExaminations(itemCode).Tables("RadiologyExaminations")

                With Me.dgvRadiology

                    .Rows.Add()

                    .Item(Me.colInclude.Name, pos).Value = True
                    .Item(Me.colExamCode.Name, pos).Value = itemCode
                    .Item(Me.colRadiologyExamination.Name, pos).Value = itemName
                    .Item(Me.colQuantity.Name, pos).Value = quantity
                    .Item(Me.colCategory.Name, pos).Value = radiologyExaminations.Rows(0).Item("RadiologyCategories").ToString()
                    .Item(Me.colUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colIndication.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colCashPayStatus.Name, pos).Value = StringMayBeEnteredIn(row, "CashPayStatus")
                    .Item(Me.colCashAmount.Name, pos).Value = FormatNumber(cashAmount, AppData.DecimalPlaces)

                End With

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateTotalBill()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
            If visitDate = AppData.NullDateValue Then Return
            Me.DeleteAlerts(visitNo, visitDate)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbVisitNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Enter

        Try
            currentAllSaved = Me.RecordSaved(False)
            If Not currentAllSaved Then
                currentVisitNo = StringMayBeEnteredIn(Me.stbVisitNo)
                ProcessTabKey(True)
            Else : currentVisitNo = String.Empty
            End If

        Catch ex As Exception
            currentVisitNo = String.Empty
        End Try

    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) AndAlso Not String.IsNullOrEmpty(currentVisitNo) Then
                Me.stbVisitNo.Text = currentVisitNo
                Return
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Me.LoadRadiologyData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not currentAllSaved AndAlso Not String.IsNullOrEmpty(currentVisitNo) Then
            Me.stbVisitNo.Text = currentVisitNo
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
        Me.stbJoinDate.Clear()
        Me.stbCoPayType.Clear()
        Me.stbAge.Clear()
        Me.stbStatus.Clear()
        Me.stbBillNo.Clear()
        Me.stbBillMode.Clear()
        billCustomerName = String.Empty
        Me.chkSmartCardApplicable.Checked = False
        Me.stbMemberCardNo.Clear()
        Me.stbVisitCategory.Clear()
        Me.stbPrimaryDoctor.Clear()
        accessCashServices = False
        ResetControlsIn(Me.pnlBill)
        Me.dgvRadiology.Rows.Clear()
        haspackage = False
    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(visitNo) Then Return

            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbStatus.Text = StringEnteredIn(row, "VisitStatus")
            Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            billCustomerName = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.chkSmartCardApplicable.Checked = BooleanMayBeEnteredIn(row, "SmartCardApplicable")
            Me.stbMemberCardNo.Text = StringMayBeEnteredIn(row, "MemberCardNo")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Me.stbVisitCategory.Text = StringEnteredIn(row, "VisitCategory")
            Me.stbPrimaryDoctor.Text = StringMayBeEnteredIn(row, "PrimaryDoctor")
            accessCashServices = BooleanMayBeEnteredIn(row, "AccessCashServices")
            haspackage = BooleanMayBeEnteredIn(row, "HasPackage")
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.genderID = StringEnteredIn(row, "GenderID")
            Me.copayTypeID = StringEnteredIn(row, "CoPayTypeID")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadRadiologyData(ByVal visitNo As String)

        Try

            Me.ShowPatientDetails(visitNo)
            Me.LoadRadiologyRequests(visitNo)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#Region " Alerts "

    Private Function ShowSentAlerts() As Integer

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            alerts = oAlerts.GetAlerts(oAlertTypeID.Radiology).Tables("Alerts")

            Dim alertsNo As Integer = alerts.Rows.Count

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblAlerts.Text = "Doctor Radiology Requests: " + alertsNo.ToString()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return alertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub btnViewList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewList.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowSentAlerts()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmAlerts(oAlertTypeID.Radiology, Me.stbVisitNo)
        fAlerts.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        Me.LoadRadiologyData(visitNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub DeleteAlerts(ByVal visitNo As String, ByVal visitDate As Date)

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()

        Try
            Me.Cursor = Cursors.WaitCursor

            If alerts Is Nothing OrElse alerts.Rows.Count < 1 Then Return

            Dim miniAlerts As EnumerableRowCollection(Of DataRow) = alerts.AsEnumerable()

            Dim alertID As Integer = (From data In miniAlerts Where
                                      data.Field(Of String)("VisitNo").ToUpper().Equals(visitNo.ToUpper()) And
                                      GetShortDate(data.Field(Of Date)("VisitDate")).Equals(GetShortDate(visitDate)) Select
                                      data.Field(Of Integer)("AlertID")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oAlerts.AlertID = alertID
            oAlerts.Delete()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tmrAlerts_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAlerts.Tick

        Try

            Dim period As Long = DateDiff(DateInterval.Minute, alertsStartDateTime, Now)
            If period >= InitOptions.AlertCheckPeriod Then
                If Me.ShowSentAlerts() > 0 Then If InitOptions.AlertSoundOn Then Beep()
            End If

        Catch eX As Exception
            Return

        End Try

    End Sub

#End Region

#Region " Fingerprint  "

    Private Sub btnFindByFingerprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindByFingerprint.Click

        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim visitFingerprints As DataTable = GetVisitFingerprints()


            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then

                Dim fFingerprintCapture As New FingerprintCapture(CaptureType.Verify, visitFingerprints, "VisitNo")
                fFingerprintCapture.ShowDialog()

                Dim visitNo As String = Me.oCrossMatchTemplate.ID
                If Me.oCrossMatchTemplate.Fingerprint Is Nothing OrElse String.IsNullOrEmpty(visitNo) Then Return

                Me.LoadRadiologyData(visitNo)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then

                Dim fVerification As New Verification(visitFingerprints, "VisitNo")
                fVerification.ShowDialog()

                If Not String.IsNullOrEmpty(Me.oDigitalPersonaTemplate.ID) Then Me.LoadRadiologyData(Me.oDigitalPersonaTemplate.ID)

            End If

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

#End Region

    Private Function RecordSaved(ByVal hideMessage As Boolean) As Boolean

        Try
            Dim message As String

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvRadiology.RowCount >= 1 Then
                If Me.dgvRadiology.RowCount = 1 Then
                    message = "Please ensure that current radiology request is saved!"
                Else : message = "Please ensure that current radiology requests are saved!"
                End If
                If Not hideMessage Then DisplayMessage(message)
                Me.btnSave.Focus()
                Me.BringToFront()
                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                Return False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True

        Catch ex As Exception
            Return True

        End Try

    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim message As String
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim lItems As New List(Of DBConnect)

            Dim lSmartCardItems As New List(Of SmartCardItems)
            Dim oVariousOptions As New VariousOptions()
            Dim oSmartCardMembers As New SmartCardMembers()
            Dim transactions As New List(Of TransactionList(Of DBConnect))

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)
            Dim notPaidPayStatus As String = GetLookupDataDes(oPayStatusID.NotPaid)
            Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvRadiology.RowCount < 1 Then
                Throw New ArgumentException("Must register at least one entry for radiology examination " + ControlChars.NewLine +
                                            "If this is a cash patient, ensure that payment is done first!")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvRadiology.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvRadiology.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If nonSelected Then Throw New ArgumentException("Must include at least one entry for radiology!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me)
            ValidateEntriesIn(Me, ErrProvider)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
       If billMode.ToUpper().Equals(insuranceBillMode.ToUpper()) Then IsInsuranceFingerprintVerified(patientNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim lInsuranceItemsCASH As New List(Of DBConnect)
            Dim oSmartCardItems As SmartCardItems
            Dim smardCardNo As String = String.Empty
            Dim medicalCardNo As String = RevertText(RevertText(StringMayBeEnteredIn(Me.stbMemberCardNo), "/"c))
            Dim coverAmount As Decimal
            Dim billFee As Decimal = DecimalEnteredIn(Me.stbBillForRadiology, True, "Bill for Radiology!")
            Dim totalCashAmount As Decimal = 0
            If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then

                oSmartCardMembers = ProcessSmartCardData(patientNo)
                smardCardNo = RevertText(RevertText(oSmartCardMembers.MedicalCardNumber, "/"c))
                coverAmount = oSmartCardMembers.CoverAmount
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not medicalCardNo.ToUpper().Equals(smardCardNo.ToUpper()) Then
                    message = "The medical card number  (" + StringMayBeEnteredIn(Me.stbMemberCardNo) + ") for this member is not the same " +
                              "as that forwarded from smart card (" + oSmartCardMembers.MedicalCardNumber + ") " +
                              ", the system does not allow to process numbers that don’t match"
                    Throw New ArgumentException(message)
                End If

                If billFee > coverAmount Then Throw New ArgumentException("The benefit for this patient is not sufficient to cover the bill!")
                oSmartCardMembers.InvoiceNo = visitNo

            End If


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not oVariousOptions.AllowAccessCashServices AndAlso Not accessCashServices AndAlso billMode.ToUpper().Equals(cashAccountNo.ToUpper()) Then

                Dim cashNotPaid As Boolean = False
                For Each row As DataGridViewRow In Me.dgvRadiology.Rows
                    If row.IsNewRow Then Exit For
                    If CBool(Me.dgvRadiology.Item(Me.colInclude.Name, row.Index).Value) = True Then
                        Dim payStatus As String = StringEnteredIn(row.Cells, Me.colPayStatus, "pay status!")
                        Dim amount As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colAmount, True)
                        If payStatus.ToUpper().Equals(notPaidPayStatus.ToUpper()) AndAlso amount > 0 Then
                            cashNotPaid = True
                            Exit For
                        End If
                    End If
                    cashNotPaid = False
                Next
                message = "The system does not allow accepting of not paid for Radiology Requests!"
                If cashNotPaid Then Throw New ArgumentException(message)

            End If
         
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim _NACoPayType As String = GetLookupDataDes(oCoPayTypeID.NA)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Not oVariousOptions.AllowAccessCoPayServices AndAlso Not coPayType.ToUpper().Equals(_NACoPayType.ToUpper()) AndAlso
             Not billMode.ToUpper().Equals(cashAccountNo.ToUpper()) Then

                Dim cashNotPaid As Boolean = False
                For Each row As DataGridViewRow In Me.dgvRadiology.Rows
                    If row.IsNewRow Then Exit For
                    If CBool(Me.dgvRadiology.Item(Me.colInclude.Name, row.Index).Value) = True Then
                        Dim payStatus As String = StringMayBeEnteredIn(row.Cells, Me.colCashPayStatus)
                        Dim cashAmount As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colCashAmount, True)
                        If payStatus.ToUpper().Equals(notPaidPayStatus.ToUpper()) AndAlso cashAmount > 0 Then
                            cashNotPaid = True
                            Exit For
                        End If
                    End If
                    cashNotPaid = False
                Next

                message = "The system does not allow accepting of Radiology Request(s) whose co-pay percent or value is not paid for a co-pay visit!"
                If cashNotPaid Then Throw New ArgumentException(message)

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvRadiology.Rows(rowNo).Cells
                Dim examCode As String = StringEnteredIn(cells, Me.colExamCode, "exam code!")
                Dim examName As String = StringEnteredIn(cells, Me.colRadiologyExamination, "exam name!")
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity, "quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colUnitPrice, False, "unit price!")
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")

                If CBool(Me.dgvRadiology.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems

                            .VisitNo = visitNo
                            .ItemCode = examCode
                            .ItemCategoryID = oItemCategoryID.Radiology
                            .LastUpdate = Now
                            .PayStatusID = String.Empty
                            .LoginID = CurrentUser.LoginID
                            .ItemStatusID = oItemStatusID.Processing

                        End With

                        lItems.Add(oItems)

                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then

                        oSmartCardItems = New SmartCardItems()

                        With oSmartCardItems

                            .TransactionDate = FormatDate(Today, "yyyy-MM-dd")
                            .TransactionTime = GetTime(Now)
                            .ServiceProviderNr = oVariousOptions.SmartCardServiceProviderNo
                            .DiagnosisCode = (0).ToString()
                            .DiagnosisDescription = "Unknown Disease"
                            .EncounterType = "Procedure"
                            .CodeType = "Mcode"
                            .Code = (3).ToString()
                            .CodeDescription = examName
                            .Quantity = quantity.ToString()
                            .Amount = (amount).ToString()

                        End With

                        lSmartCardItems.Add(oSmartCardItems)

                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oSmartCardMembers.InvoiceNo = visitNo
            oSmartCardMembers.TotalBill = billFee
            oSmartCardMembers.TotalServices = lSmartCardItems.Count()
            oSmartCardMembers.CopayType = copayTypeID
            oSmartCardMembers.CopayAmount = totalCashAmount
            oSmartCardMembers.Gender = genderID
            If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then
                Dim oVisitTypeID As New LookupDataID.VisitTypeID()
                If Not UpdateSmartExchangeFiles(oSmartCardMembers, lSmartCardItems, visitNo, oVisitTypeID.OutPatient) Then
                    Throw New ArgumentException("Error processing smart card information. Please edit the transactions and try again")
                    Return
                End If
               
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Update))

            DoTransactions(transactions)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkPrintRadiologyRequestOnSaving.Checked Then Me.PrintRadiology()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim allSelected As Boolean = True

            For Each row As DataGridViewRow In Me.dgvRadiology.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvRadiology.Item(Me.colInclude.Name, row.Index).Value) = False Then
                    allSelected = False
                    Me.LoadRadiologyRequests(visitNo)
                    Exit For
                End If
                allSelected = True
            Next

            If allSelected Then
                Me.dgvRadiology.Rows.Clear()
                ResetControlsIn(Me)
                ResetControlsIn(Me.pnlBill)
                ' Me.LoadToRadiologyVisits()
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.chkPrintRadiologyRequestOnSaving.Checked = True

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentAlerts()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub CalculateTotalBill()

        Dim totalBill As Decimal

        Me.stbBillForRadiology.Clear()

        For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 1

            If CBool(Me.dgvRadiology.Item(Me.colInclude.Name, rowNo).Value) = True Then
                If IsNumeric(Me.dgvRadiology.Item(Me.colAmount.Name, rowNo).Value) Then
                    totalBill += CDec(Me.dgvRadiology.Item(Me.colAmount.Name, rowNo).Value)
                Else : totalBill += 0
                End If
            End If
        Next

        Me.stbBillForRadiology.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub dgvRadiology_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRadiology.CellEndEdit
        Me.CalculateTotalBill()
    End Sub

#Region " Radiology Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintRadiology()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintRadiology()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvRadiology.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for Radiology Request!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvRadiology.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvRadiology.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry for Radiology Request!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetRadiologyPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docRadiology
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docRadiology.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docRadiology_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docRadiology.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Radiology Request".ToUpper()

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim primaryDoctor As String = StringMayBeEnteredIn(Me.stbPrimaryDoctor)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 21 * widthTopFirst
                Dim widthTopFourth As Single = 30 * widthTopFirst

                If pageNo < 2 Then

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

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
                    .DrawString(primaryDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
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

                If radiologyParagraphs Is Nothing Then Return

                Do While radiologyParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(radiologyParagraphs(1), PrintParagraps)
                    radiologyParagraphs.Remove(1)

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
                        radiologyParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (radiologyParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetRadiologyPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 40

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        radiologyParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Examination Name: ".PadRight(padItemName))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            radiologyParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 1

                If CBool(Me.dgvRadiology.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvRadiology.Rows(rowNo).Cells

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim itemName As String = cells.Item(Me.colRadiologyExamination.Name).Value.ToString()

                    tableData.Append(itemNo.PadRight(padItemNo))
                    tableData.Append(itemName.PadRight(padItemName))

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            radiologyParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            radiologyParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

End Class