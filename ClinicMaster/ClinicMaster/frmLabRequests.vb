
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
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona

Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Imports System.Drawing.Printing
Imports System.Collections.Generic

Imports System.Drawing.Imaging
Imports GenCode128



Public Class frmLabRequests

#Region " Fields "

    Private currentAllSaved As Boolean = True
    Private currentVisitNo As String = String.Empty

    Private accessCashServices As Boolean = False
    Private haspackage As Boolean = False

    Private alerts As DataTable
    Private alertsStartDateTime As Date = Now

    Private iPDAlerts As DataTable
    Private iPDAlertsStartDateTime As Date = Now

    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()
    Private labLabelBarCode As Collection
    Private WithEvents docLaboratory As New PrintDocument()
    Private WithEvents docBarcodes As New PrintDocument()
    ' The paragraphs.
    Private laboratoryParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private toPrintRow As Integer = -1
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private billCustomerName As String = String.Empty
    Private smartLocationID As Integer
    Private genderID As String
    Private copayTypeID As String
#End Region

#Region " Validations "

    Private Sub dtpDrawnDateTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpDrawnDateTime.Validating

        Dim errorMSG As String = "Drawn date can't be before visit date!"

        Try

            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
            Dim drawnDateTime As Date = DateMayBeEnteredIn(Me.dtpDrawnDateTime)

            If drawnDateTime = AppData.NullDateValue Then Return

            If drawnDateTime < visitDate Then
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

    Private Sub frmLabRequests_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oVariousOptions As New VariousOptions()

        Try
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oVariousOptions.AllowIssueStockOnLabRequest Then
                Me.lblLocationID.Enabled = True
                Me.cboLocationID.Enabled = True
                Me.SetDefaultLocation()
            Else
                Me.lblLocationID.Enabled = False
                Me.cboLocationID.Enabled = False
            End If
           
            LoadLookupDataCombo(Me.clbSpecimenPrescription, LookupObjects.SpecimenDescription, False)
            Me.LoadStaff()
            Me.ShowSentAlerts()
            Me.ShowSentIPDAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If InitOptions.AlertCheckPeriod > 0 Then Me.tmrAlerts.Interval = 1000 * 60 * InitOptions.AlertCheckPeriod
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmLabRequests_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ''''''''''''''''''''
        Me.ShowSentAlerts()
        Me.ShowSentIPDAlerts()
        ''''''''''''''''''''
    End Sub

    Private Sub frmLabRequests_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim message As String
        If Me.dgvTests.RowCount = 1 Then
            message = "Current laboratory test request is not saved. " + ControlChars.NewLine + "Just close anyway?"
        Else : message = "Current laboratory test requests are not saved. " + ControlChars.NewLine + "Just close anyway?"
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
        Me.LoadLaboratoryData(visitNo)
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

    Private Sub btnLoadToLabVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadToLabVisits.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPendingItems As New frmPendingItems(Me.stbVisitNo, AlertItemCategory.Test)
            fPendingItems.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Me.LoadLaboratoryData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub LoadLabRequests(ByVal visitNo As String)

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oLabTests As New SyncSoft.SQLDb.LabTests()
        Dim oClinicalFindings As New SyncSoft.SQLDb.ClinicalFindings()
        Dim labRequests As DataTable

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dgvTests.Rows.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If String.IsNullOrEmpty(visitNo) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String
            Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim oVariousOptions As New VariousOptions()


            If billMode.ToUpper().Equals(cashAccountNo.ToUpper()) AndAlso Not oVariousOptions.AllowAccessCashServices AndAlso Not accessCashServices AndAlso Not haspackage Then
                labRequests = oItems.GetItems(visitNo, oItemCategoryID.Test, oItemStatusID.Pending, oPayStatusID.PaidFor).Tables("Items")

            ElseIf billMode.ToUpper().Equals(cashAccountNo.ToUpper()) AndAlso haspackage.Equals(True) AndAlso oPayStatusID.Equals(oPayStatusID.NA) Then
                labRequests = oItems.GetItems(visitNo, oItemCategoryID.Test, oItemStatusID.Pending).Tables("Items")

            ElseIf billMode.ToUpper().Equals(cashAccountNo.ToUpper()) AndAlso haspackage.Equals(True) AndAlso oPayStatusID.Equals(oPayStatusID.PaidFor) Then
                labRequests = oItems.GetItems(visitNo, oItemCategoryID.Test, oItemStatusID.Pending).Tables("Items")

            Else : labRequests = oItems.GetItems(visitNo, oItemCategoryID.Test, oItemStatusID.Pending).Tables("Items")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.btnReject.Enabled = labRequests.Rows.Count > 0

            If labRequests Is Nothing OrElse labRequests.Rows.Count < 1 Then

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

                Dim amount As Decimal = quantity * unitPrice

                Dim itemCode As String = StringEnteredIn(row, "ItemCode")
                Dim itemName As String = StringEnteredIn(row, "ItemName")
                Dim drNotes As String = StringMayBeEnteredIn(row, "ItemDetails")
                Dim cashAmount As Decimal = DecimalMayBeEnteredIn(row, "CashAmount")
                Dim labTests As DataTable = oLabTests.GetLabTests(itemCode).Tables("LabTests")

                Dim clinicalFindings As DataTable = oClinicalFindings.GetClinicalFindings(RevertText(visitNo)).Tables("ClinicalFindings")
                Dim ClinicalNotes As String = String.Empty
                Dim ProvisionalDiagnosis As String = String.Empty
                If clinicalFindings.Rows.Count > 0 Then
                    Dim rowClinicalNotes As DataRow = clinicalFindings.Rows(0)
                    ClinicalNotes = StringMayBeEnteredIn(rowClinicalNotes, "ClinicalNotes")
                    ProvisionalDiagnosis = StringMayBeEnteredIn(rowClinicalNotes, "ProvisionalDiagnosis")
                End If




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

                    'If clinicalFindings.Rows.Count < 0 Then
                    .Item(Me.ColclinicalNotes.Name, pos).Value = ClinicalNotes
                    .Item(Me.ColProvisionalDiagnosis.Name, pos).Value = ProvisionalDiagnosis
                    ' End If

                    .Item(Me.colPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colCashPayStatus.Name, pos).Value = StringMayBeEnteredIn(row, "CashPayStatus")
                    .Item(Me.colCashAmount.Name, pos).Value = FormatNumber(cashAmount, AppData.DecimalPlaces)
                End With

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateTotalBill()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then Me.SetNextSpecimenNo(visitNo, patientNo)

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
            Me.LoadLaboratoryData(visitNo)
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
        Me.stbPackage.Clear()
        Me.stbBillMode.Clear()
        Me.cboDrawnBy.SelectedIndex = -1
        Me.cboDrawnBy.SelectedIndex = -1
        billCustomerName = String.Empty
        Me.lblAgeString.Text = String.Empty
        Me.chkSmartCardApplicable.Checked = False
        Me.stbMemberCardNo.Clear()
        Me.stbVisitCategory.Clear()
        Me.stbPrimaryDoctor.Clear()
        Me.stbDoctorContact.Clear()
        accessCashServices = False
        haspackage = False
        ResetControlsIn(Me.pnlBill)
        Me.dgvTests.Rows.Clear()

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oStaff As New SyncSoft.SQLDb.Staff()
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
            Me.genderID = StringEnteredIn(row, "GenderID")
            Me.copayTypeID = StringEnteredIn(row, "CoPayTypeID")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Dim birthDate As Date = DateMayBeEnteredIn(row, "BirthDate")
            Me.lblAgeString.Text = GetAgeString(birthDate, True)
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
            Me.stbDoctorContact.Text = StringMayBeEnteredIn(row, "DoctorContact")
            accessCashServices = BooleanMayBeEnteredIn(row, "AccessCashServices")
            haspackage = BooleanMayBeEnteredIn(row, "HasPackage")
            Me.stbPackage.Text = StringMayBeEnteredIn(row, "PackageName")
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboDrawnBy.Text = oStaff.GetCurrentStaffFullName
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                Dim visitDate As Date = DateEnteredIn(row, "VisitDate")
                If Not visitDate.Equals(Today) Then
                    Me.dtpDrawnDateTime.Value = visitDate
                    Me.dtpDrawnDateTime.Checked = False
                Else : Me.dtpDrawnDateTime.Value = Now
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub LoadLaboratoryData(ByVal visitNo As String)
        Dim oVariousOptions As New VariousOptions()
        Try

            Me.ShowPatientDetails(visitNo)
            Me.LoadLabRequests(visitNo)
            If oVariousOptions.AllowIssueStockOnLabRequest Then
                Me.loadPossibleConsumables()
            End If
            Me.GenerateBarcode()
        Catch ex As Exception
            Throw ex

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

#Region " Alerts "

    Private Function ShowSentAlerts() As Integer

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            alerts = oAlerts.GetAlerts(oAlertTypeID.LabRequests).Tables("Alerts")

            Dim alertsNo As Integer = alerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblAlerts.Text = "Doctor Lab Requests: " + alertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return alertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function


    Private Function ShowSentIPDAlerts() As Integer

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            iPDAlerts = oIPDAlerts.GetIPDAlerts(oAlertTypeID.LabRequests).Tables("IPDAlerts")

            Dim iPDAlertsNo As Integer = iPDAlerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblIPDAlerts.Text = "IPD Doctor Lab Requests: " + iPDAlertsNo.ToString()

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

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowSentAlerts()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmAlerts(oAlertTypeID.LabRequests, Me.stbVisitNo)
        fAlerts.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        Me.LoadLaboratoryData(visitNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub DeleteAlerts(ByVal visitNo As String, ByVal visitDate As Date)

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()

        Try
            Me.Cursor = Cursors.WaitCursor

            If alerts Is Nothing OrElse alerts.Rows.Count < 1 Then Return

            Dim miniAlerts As EnumerableRowCollection(Of DataRow) = alerts.AsEnumerable()

            Dim alertID As Integer = (From data In miniAlerts _
                                        Where data.Field(Of String)("VisitNo").ToUpper().Equals(visitNo.ToUpper()) _
                                        And GetShortDate(data.Field(Of Date)("VisitDate")).Equals(GetShortDate(visitDate)) _
                                        Select data.Field(Of Integer)("AlertID")).First()

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
                If Me.ShowSentIPDAlerts() > 0 Then If InitOptions.AlertSoundOn Then Beep()
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

                Me.LoadLaboratoryData(visitNo)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then

                Dim fVerification As New Verification(visitFingerprints, "VisitNo")
                fVerification.ShowDialog()

                If Not String.IsNullOrEmpty(Me.oDigitalPersonaTemplate.ID) Then Me.LoadLaboratoryData(Me.oDigitalPersonaTemplate.ID)

            End If

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

#End Region

    Private Function RecordSaved(ByVal hideMessage As Boolean) As Boolean

        Try
            Dim message As String

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return True

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
            Dim lItems As New List(Of DBConnect)
            Dim transactions As New List(Of TransactionList(Of DBConnect))

            Dim specimenNo As String = RevertText(StringEnteredIn(Me.stbSpecimenNo, "Specimen No!"))
            Dim visitNo As String = StringEnteredIn(Me.stbVisitNo, "Visit's No!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oLabRequests.SpecimenNo = specimenNo
            Dim labRequestDetails As DataTable = oLabRequestDetails.GetLabRequestDetails(specimenNo).Tables("LabRequestDetails")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lLabRequests.Add(oLabRequests)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To LabRequestDetails.Rows.Count - 1

                Using oItems As New SyncSoft.SQLDb.Items()

                    With oItems

                        .VisitNo = visitNo
                        .ItemCode = CStr(LabRequestDetails.Rows(pos).Item("TestCode"))
                        .ItemCategoryID = oItemCategoryID.Test
                        .LastUpdate = DateEnteredIn(Me.dtpDrawnDateTime, "Drawn Date!")
                        .PayStatusID = String.Empty
                        .LoginID = CurrentUser.LoginID
                        .ItemStatusID = oItemStatusID.Pending

                    End With

                    lItems.Add(oItems)

                End Using
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lLabRequests, Action.Delete))
            transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Update))

            DoTransactions(transactions)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            DisplayMessage("Record successfully deleted!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
            Dim specimenNo As String = RevertText(StringEnteredIn(Me.stbSpecimenNo, "Specimen No!"))
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))

            Dim dataSource As DataTable = oLabRequests.GetLabRequests(specimenNo).Tables("LabRequests")
            Me.DisplayData(dataSource)

            Me.LoadLaboratoryData(visitNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

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

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim message As String
        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oStockTypeID As New LookupDataID.StockTypeID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oLabRequests As New SyncSoft.SQLDb.LabRequests()

            Dim lLabRequests As New List(Of DBConnect)
            Dim lLabRequestDetails As New List(Of DBConnect)
            Dim lItems As New List(Of DBConnect)
            Dim lInventory As New List(Of DBConnect)

            Dim lSmartCardItems As New List(Of SmartCardItems)
            Dim oVariousOptions As New VariousOptions()
            Dim oSmartCardMembers As New SmartCardMembers()
            Dim transactions As New List(Of TransactionList(Of DBConnect))

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim specimenNo As String = RevertText(StringEnteredIn(stbSpecimenNo, "Specimen No"))
            Dim specimenDes As String = StringToSplitSelectedInAtleastOne(Me.clbSpecimenPrescription, "Specimen Description")
            Dim drawnBy As String = SubstringEnteredIn(Me.cboDrawnBy, "Drawn By (Staff)!")
            Dim drawnDateTime As Date = DateTimeEnteredIn(Me.dtpDrawnDateTime, "drawn date and time!")

            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvTests.RowCount < 1 Then
                Throw New ArgumentException("Must register at least one entry for lab test " + ControlChars.NewLine +
                                            "If this is a cash patient, ensure that payment is done first!")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me)
            ValidateEntriesIn(Me, ErrProvider)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lLabRequests.Add(oLabRequests)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitDate As Date = DateTimeMayBeEnteredIn(Me.stbVisitDate)

            If drawnDateTime < visitDate Then
                Throw New ArgumentException("Drawn date and time can't be before visit date!")

            ElseIf drawnDateTime > Now Then
                Throw New ArgumentException("Drawn date and time can't be a head of current date and time!")

            End If

            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)
            Dim notPaidPayStatus As String = GetLookupDataDes(oPayStatusID.NotPaid)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not oVariousOptions.AllowAccessCashServices AndAlso Not accessCashServices AndAlso
              billMode.ToUpper().Equals(cashAccountNo.ToUpper()) Then

                Dim cashNotPaid As Boolean = False
                For Each row As DataGridViewRow In Me.dgvTests.Rows
                    If row.IsNewRow Then Exit For
                    If CBool(Me.dgvTests.Item(Me.colInclude.Name, row.Index).Value) = True Then
                        Dim payStatus As String = StringEnteredIn(row.Cells, Me.colPayStatus, "pay status!")
                        Dim amount As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colAmount, True)
                        If payStatus.ToUpper().Equals(notPaidPayStatus.ToUpper()) AndAlso amount > 0 Then
                            cashNotPaid = True
                            Exit For
                        End If
                    End If
                    cashNotPaid = False
                Next

                message = "The system does not allow accepting of not paid for Lab Tests!"
                If cashNotPaid Then Throw New ArgumentException(message)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '  Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            If billMode.ToUpper().Equals(insuranceBillMode.ToUpper()) Then IsInsuranceFingerprintVerified(patientNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim _NACoPayType As String = GetLookupDataDes(oCoPayTypeID.NA)
            Dim totalCashAmount As Decimal
            
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Not oVariousOptions.AllowAccessCoPayServices AndAlso Not coPayType.ToUpper().Equals(_NACoPayType.ToUpper()) AndAlso
             Not billMode.ToUpper().Equals(cashAccountNo.ToUpper()) Then

                Dim cashNotPaid As Boolean = False
                For Each row As DataGridViewRow In Me.dgvTests.Rows
                    If row.IsNewRow Then Exit For
                    If CBool(Me.dgvTests.Item(Me.colInclude.Name, row.Index).Value) = True Then
                        Dim payStatus As String = StringMayBeEnteredIn(row.Cells, Me.colCashPayStatus)
                        Dim cashAmount As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colCashAmount, True)
                        If payStatus.ToUpper().Equals(notPaidPayStatus.ToUpper()) AndAlso cashAmount > 0 Then
                            cashNotPaid = True
                            Exit For
                        End If
                        totalCashAmount += cashAmount
                    End If
                    cashNotPaid = False
                Next

                message = "The system does not allow accepting of Lab Request(s) whose co-pay percent or value is not paid for a co-pay visit!"
                If cashNotPaid Then Throw New ArgumentException(message)

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.chkPrintLabBarcode.Checked Then Me.PrintLabBarcodes()
                    transactions.Add(New TransactionList(Of DBConnect)(lLabRequests, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lLabRequests, Action.Update, "LabRequests"))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim lInsuranceItemsCASH As New List(Of DBConnect)
            Dim oSmartCardItems As SmartCardItems
            Dim smardCardNo As String = String.Empty
            Dim medicalCardNo As String = RevertText(RevertText(StringMayBeEnteredIn(Me.stbMemberCardNo), "/"c))
            Dim coverAmount As Decimal
            Dim billFee As Decimal = DecimalEnteredIn(Me.stbBillForLaboratory, True, "Bill for Laboratory!")

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvTests.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvTests.Rows(rowNo).Cells
                Dim testCode As String = StringEnteredIn(cells, Me.colTestCode, "test code!")
                Dim testName As String = StringEnteredIn(cells, Me.colTestName, "test name!")
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity, "quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colUnitPrice, False, "unit price!")
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")

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

                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems

                            .VisitNo = visitNo
                            .ItemCode = testCode
                            .ItemCategoryID = oItemCategoryID.Test
                            .LastUpdate = DateEnteredIn(Me.dtpDrawnDateTime, "Drawn Date!")
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
                            .CodeDescription = testName
                            .Quantity = quantity.ToString()
                            .Amount = (amount).ToString()

                        End With

                        lSmartCardItems.Add(oSmartCardItems)

                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If
            Next


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''' Issue Stock at Lab Starts Here  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oVariousOptions.AllowIssueStockOnLabRequest Then
                Dim location As String = StringMayBeEnteredIn(Me.cboLocationID)
                Dim locationID As String = StringValueEnteredIn(Me.cboLocationID, "Location!")

                If Not String.IsNullOrEmpty(InitOptions.Location) AndAlso Not InitOptions.Location.ToUpper().Equals(GetLookupDataDes(locationID).ToUpper()) Then
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
                                .Details = "Consumable(s) Attached to Test:" + TestName + " Issued to Visit No: " + visitNo
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
            'End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''' Issue Stock at Lab Ends Here  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lLabRequestDetails, Action.Save, "LabRequestDetails"))
            transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Update))
            transactions.Add(New TransactionList(Of DBConnect)(lInventory, Action.Save))

            DoTransactions(transactions)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save AndAlso Me.chkPrintLabRequestOnSaving.Checked Then Me.PrintLaboratory()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.GenerateBarcode()
            Dim allSelected As Boolean = True

            For Each row As DataGridViewRow In Me.dgvTests.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvTests.Item(Me.colInclude.Name, row.Index).Value) = False Then
                    allSelected = False
                    Me.LoadLabRequests(visitNo)
                    Me.GenerateBarcode()
                    Exit For
                End If
                allSelected = True
            Next

            If allSelected Then
                Me.dgvTests.Rows.Clear()
                ResetControlsIn(Me)
                ResetControlsIn(Me.pnlBill)
                Me.dgvConsumables.Rows.Clear()
                ' Me.LoadToLabVisits()
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.chkPrintLabRequestOnSaving.Checked = True
            Me.CallOnKeyEdit()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentAlerts()
            Me.ShowSentIPDAlerts()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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


    Private Sub dgvTests_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTests.CellEndEdit
        Try
            loadPossibleConsumables()
            Me.CalculateTotalBill()
        Catch ex As Exception
            ErrorMessage(ex)
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
            Dim primaryDoctor As String = StringMayBeEnteredIn(Me.stbPrimaryDoctor)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 11 * widthTopFirst

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
        laboratoryParagraphs = New Collection()

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
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            laboratoryParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
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

        Me.stbVisitNo.Enabled = False
        Me.btnFindVisitNo.Enabled = False
        Me.btnFindSpecimenNo.Enabled = True
        Me.stbSpecimenNo.ReadOnly = False

        Me.btnLoadToLabVisits.Enabled = False
        Me.btnPrint.Visible = False

        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlBill)

        Me.chkPrintLabRequestOnSaving.Visible = False
        Me.chkPrintLabRequestOnSaving.Checked = False

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

        Me.stbVisitNo.Enabled = True
        Me.btnFindVisitNo.Enabled = True
        Me.btnFindSpecimenNo.Enabled = False

        Me.btnLoadToLabVisits.Enabled = True
        Me.btnPrint.Visible = True

        Me.stbSpecimenNo.ReadOnly = InitOptions.SpecimenNoLocked
        Me.dtpDrawnDateTime.MaxDate = Today.AddDays(1)

        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlBill)

        Me.chkPrintLabRequestOnSaving.Visible = True
        Me.chkPrintLabRequestOnSaving.Checked = True
        Me.SetDefaultLocation()

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

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        Dim specimenNo As String = StringMayBeEnteredIn(Me.stbSpecimenNo)
        Dim visitNo As String = StringMayBeEnteredIn(Me.stbVisitNo)

        If String.IsNullOrEmpty(specimenNo) OrElse String.IsNullOrEmpty(visitNo) Then
            Return
        End If


        Dim fRejectedSpecimen As New frmRejectedSpecimens(specimenNo, visitNo, "Lab Request")
        fRejectedSpecimen.ShowDialog()
    End Sub

   
    Private Sub BtnViewIPDLabRequests_Click(sender As System.Object, e As System.EventArgs) Handles BtnViewIPDLabRequests.Click
        Me.ShowSentIPDAlerts()
        frmIPDLabRequests.ShowDialog()
    End Sub


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
            rect = New Rectangle(5, 0, w, 105)
            e.Graphics.DrawString(RevertText(stbSpecimenNo.Text.ToString()), printFont10_Normal, Brushes.Black, rect, sf)
            rect = New Rectangle(5, 0, w, 130)
            e.Graphics.DrawString(stbFullName.Text.ToString(), printFont10_Normal, Brushes.Black, rect, sf)
            rect = New Rectangle(5, 0, w, 170)
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



    Private Sub cmsLabIncludeAll_Click(sender As System.Object, e As System.EventArgs) Handles cmsLabIncludeAll.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcLabRequests.SelectedTab.Name

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

            Select Case Me.tbcLabRequests.SelectedTab.Name

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


End Class