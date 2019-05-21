
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmIssueIPDProcedures

#Region " Fields "

    Private defaultRoundNo As String = String.Empty
    Private tipCoPayValueWords As New ToolTip()
    Private currentAllSaved As Boolean = True
    Private currentRoundNo As String = String.Empty

    Private accessCashServices As Boolean = False
    Private provisionalIPDDiagnosis As String = String.Empty

    Private Const EditText As String = "&Edit"
    Private Const UpdateText As String = "&Update"

    Private iPDAlerts As DataTable
    Private iPDAlertsStartDateTime As Date = Now

    Private billModesID As String = String.Empty
    Private doctorStaffNo As String = String.Empty

    Private patientpackageNo As String = String.Empty
    Private hasPackage As Boolean = False

    Private oPayTypeID As New LookupDataID.PayTypeID()
    Private oVisitTypeID As New LookupDataID.VisitTypeID()
    Private oVariousOptions As New VariousOptions()
    Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

#End Region

#Region " Validations "

#End Region

    Private Sub frmIssueIPDProcedures_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oVariousOptions As New VariousOptions()

        Try

            Me.ShowSentIPDAlerts()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnSaveIPD, AccessRights.Write)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If InitOptions.AlertCheckPeriod > 0 Then Me.tmrIPDAlerts.Interval = 1000 * 60 * InitOptions.AlertCheckPeriod

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(defaultRoundNo) Then
                Me.stbRoundNo.Text = FormatText(defaultRoundNo, "IPDDoctor", "RoundNo")
                Me.stbRoundNo.ReadOnly = True
                Me.ShowProcedureData()
                Me.ProcessTabKey(True)
                Me.EnableDefaultCTRLS(False)
            Else : Me.stbRoundNo.ReadOnly = False
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub EnableDefaultCTRLS(ByVal state As Boolean)

        Me.btnFindAdmissionNo.Enabled = state
        Me.btnFindRoundNo.Enabled = state
        Me.btnLoadIPDDoctorProcedures.Enabled = state
        Me.pnlAlerts.Enabled = state

    End Sub

    Private Sub frmIssueIPDProcedures_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.ShowSentIPDAlerts()
    End Sub

    Private Sub frmIssueIPDProcedures_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim message As String
        If Me.dgvIPDProcedures.RowCount = 1 Then
            message = "Current Procedures is not saved. " + ControlChars.NewLine + "Just close anyway?"
        Else : message = "Current Procedures are not saved. " + ControlChars.NewLine + "Just close anyway?"
        End If
        If Not Me.RecordSaved(True) Then
            If WarningMessage(message) = Windows.Forms.DialogResult.No Then e.Cancel = True
        End If

    End Sub

    Private Sub stbRoundNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbRoundNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
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
            Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
            Dim roundNo As String = oIPDDoctor.GetRoundNo(admissionNo, Nothing)
            Me.stbRoundNo.Text = FormatText(roundNo, "IPDDoctor", "RoundNo")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowProcedureData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return

        End Try

    End Sub

    Private Sub btnFindRoundNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindRoundNo.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindRoundNo As New frmFindAutoNo(Me.stbRoundNo, AutoNumber.RoundNo)
        fFindRoundNo.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowProcedureData()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub
    Private Sub btnLoadIPDDoctorProcedures_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadIPDDoctorProcedures.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPendingIPDItems As New frmPendingIPDItems(Me.stbRoundNo, AlertItemCategory.Procedure)
            fPendingIPDItems.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowProcedureData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
 

    Private Sub stbRoundNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbRoundNo.Enter

        Try
            currentAllSaved = Me.RecordSaved(False)
            If Not currentAllSaved Then
                currentRoundNo = StringMayBeEnteredIn(Me.stbRoundNo)
                ProcessTabKey(True)
            Else : currentRoundNo = String.Empty
            End If

        Catch ex As Exception
            currentRoundNo = String.Empty
        End Try

    End Sub

    Private Sub stbRoundNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbRoundNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) AndAlso Not String.IsNullOrEmpty(currentRoundNo) Then
                Me.stbRoundNo.Text = currentRoundNo
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowProcedureData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbRoundNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbRoundNo.TextChanged

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not currentAllSaved AndAlso Not String.IsNullOrEmpty(currentRoundNo) Then
            Me.stbRoundNo.Text = currentRoundNo
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
        Me.stbBillCustomerName.Clear()
        Me.stbInsuranceName.Clear()
        accessCashServices = False
        provisionalIPDDiagnosis = String.Empty
        billModesID = String.Empty
        doctorStaffNo = String.Empty
        Me.stbVisitCategory.Clear()
        Me.stbAttendingDoctor.Clear()
        Me.stbAdmissionDateTime.Clear()
        Me.stbRoundDateTime.Clear()
        ' Me.stbAdmissionNo.Clear()
        Me.stbCoPayType.Clear()
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        ResetControlsIn(Me.pnlBill)
        ResetControlsIn(Me.tpgIPDProcedures)
        patientpackageNo = String.Empty
        hasPackage = False
    End Sub

    Private Sub ShowProcedureData()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me.pnlNavigateRounds)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
            If String.IsNullOrEmpty(roundNo) Then Return
            Me.LoadProceduresData(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me.pnlNavigateRounds)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadProceduresData(ByVal roundNo As String)

        Try

            Me.ShowPatientDetails(roundNo)
            Me.LoadProceduresToOffer(roundNo)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal roundNo As String)

        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()
        Dim oVisitCategoryID As New LookupDataID.VisitCategoryID()

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
            Dim billCustomerName As String = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName
            Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")
            billModesID = StringMayBeEnteredIn(row, "BillModesID")
            doctorStaffNo = StringMayBeEnteredIn(row, "StaffNo")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Me.stbVisitCategory.Text = StringEnteredIn(row, "VisitCategory")
            accessCashServices = BooleanMayBeEnteredIn(row, "AccessCashServices")
            provisionalIPDDiagnosis = StringMayBeEnteredIn(row, "ProvisionalIPDDiagnosis")
            Me.stbAttendingDoctor.Text = StringMayBeEnteredIn(row, "AttendingDoctor")
            Me.stbRoundDateTime.Text = FormatDateTime(DateTimeEnteredIn(row, "RoundDateTime"))
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
            hasPackage = BooleanMayBeEnteredIn(row, "HasPackage")
            patientpackageNo = StringMayBeEnteredIn(row, "PackageNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    

    Private Sub LoadProceduresToOffer(ByVal roundNo As String)

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()

        Try


            Me.Cursor = Cursors.WaitCursor

            Me.dgvIPDProcedures.Rows.Clear()
            If String.IsNullOrEmpty(roundNo) Then Return

            Dim ProceduresToIssue As DataTable = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Procedure, oItemStatusID.Pending).Tables("IPDItems")

            If ProceduresToIssue Is Nothing OrElse ProceduresToIssue.Rows.Count < 1 Then

                Dim message As String
                Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)
                Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)

                If String.IsNullOrEmpty(billMode) Then Return

                If billMode.ToUpper().Equals(cashAccountNo.ToUpper()) Then
                    message = "This visit has no pending Procedures or is waiting for payment first!"
                Else : message = "This visit has no pending Procedures!"
                End If

                DisplayMessage(message)
                Return

            End If

            For pos As Integer = 0 To ProceduresToIssue.Rows.Count - 1

                Dim row As DataRow = ProceduresToIssue.Rows(pos)

                Dim consumableNo As String = StringEnteredIn(row, "ItemCode")
                Dim quantity As Integer = IntegerMayBeEnteredIn(row, "Quantity")
                Dim unitPrice As Decimal = DecimalMayBeEnteredIn(row, "UnitPrice")
                Dim amount As Decimal = quantity * unitPrice

                With Me.dgvIPDProcedures

                    .Rows.Add()


                    .Item(Me.colInclude.Name, pos).Value = True
                    .Item(Me.colProcedureCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colProcedureName.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colQuantity.Name, pos).Value = quantity
                    .Item(Me.colUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colProcedureNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    Me.ShowProcedureDetails(consumableNo, pos)

                End With

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateTotalBill()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundDateTime As Date = DateMayBeEnteredIn(Me.stbRoundDateTime)
            If roundDateTime = AppData.NullDateValue Then Return
            Me.DeleteIPDAlerts(roundNo, roundDateTime)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region "MORE METHODS"
    Private Sub CalculateTotalBill()

        Dim totalBill As Decimal

        Me.stbBillForProcedures.Clear()

        For rowNo As Integer = 0 To Me.dgvIPDProcedures.RowCount - 1

            If CBool(Me.dgvIPDProcedures.Item(Me.colInclude.Name, rowNo).Value) = True Then
                If IsNumeric(Me.dgvIPDProcedures.Item(Me.colAmount.Name, rowNo).Value) Then
                    totalBill += CDec(Me.dgvIPDProcedures.Item(Me.colAmount.Name, rowNo).Value)
                Else : totalBill += 0
                End If
            End If
        Next

        Me.stbBillForProcedures.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub ShowProcedureDetails(ByVal procedureCode As String, ByVal pos As Integer)

        Dim oProcedureItems As New SyncSoft.SQLDb.Procedures()

        Try

            Dim Procedures As DataTable = oProcedureItems.GetProcedures(procedureCode).Tables("Procedures")

            If Procedures Is Nothing OrElse procedureCode Is Nothing Then Return
            Dim row As DataRow = Procedures.Rows(0)


        Catch ex As Exception
            Throw ex

        End Try

    End Sub



#End Region


#Region " IPDAlerts "

    Private Function ShowSentIPDAlerts() As Integer

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            iPDAlerts = oIPDAlerts.GetIPDAlerts(oAlertTypeID.Procedure).Tables("IPDAlerts")

            Dim iPDAlertsNo As Integer = iPDAlerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblIPDAlerts.Text = "Sent Procedures: " + iPDAlertsNo.ToString()
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


    Private Sub DeleteIPDAlerts(ByVal roundNo As String, ByVal roundDateTime As Date)

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()

        Try
            Me.Cursor = Cursors.WaitCursor

            If iPDAlerts Is Nothing OrElse iPDAlerts.Rows.Count < 1 Then Return

            Dim miniIPDAlerts As EnumerableRowCollection(Of DataRow) = iPDAlerts.AsEnumerable()

            Dim alertID As Integer = (From data In miniIPDAlerts
                                        Where data.Field(Of String)("RoundNo").ToUpper().Equals(roundNo.ToUpper()) And
                                        GetShortDate(data.Field(Of Date)("RoundDateTime")).Equals(GetShortDate(roundDateTime))
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

    Private Sub btnViewList_Click(sender As System.Object, e As System.EventArgs)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowSentIPDAlerts()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fIPDAlerts As New frmIPDAlerts(oAlertTypeID.Procedure, Me.stbRoundNo)
        fIPDAlerts.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowProcedureData()
        '''''''''''''''''''''''''''
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



    Private Function RecordSaved(ByVal hideMessage As Boolean) As Boolean

        Try
            Dim message As String

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvIPDProcedures.RowCount >= 1 Then
                If Me.dgvIPDProcedures.RowCount = 1 Then
                    message = "Please ensure that current Procedures is saved!"
                Else : message = "Please ensure that current Procedures are saved!"
                End If
                If Not hideMessage Then DisplayMessage(message)
                Me.btnSaveIPD.Focus()
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


#Region " Procedures - Grid "


    Private Sub dgvProcedures_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        Me.CalculateTotalBill()

    End Sub



#End Region

#Region " Rounds Navigate "

    Private Sub EnableNavigateRoundsCTLS(ByVal state As Boolean)

        Dim startPosition As Integer
        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))
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
        Me.EnableNavigateRoundsCTLS(Me.chkNavigateRounds.Checked)
    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navRounds.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(currentValue.ToString())
            If String.IsNullOrEmpty(roundNo) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbRoundNo.Text = FormatText(roundNo, "IPDDoctor", "RoundNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadProceduresData(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Procedures Extras "

    Private Sub cmsProcedures_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsProcedures.Opening

        If Me.dgvIPDProcedures.ColumnCount < 1 OrElse Me.dgvIPDProcedures.RowCount < 1 Then
            Me.cmsProceduresCopy.Enabled = False
            Me.cmsProceduresSelectAll.Enabled = False

            Me.cmsProceduresEditProcedures.Enabled = False
            Me.cmsProceduresRefresh.Enabled = False
        Else
            Me.cmsProceduresCopy.Enabled = True
            Me.cmsProceduresSelectAll.Enabled = True
            Me.cmsProceduresEditProcedures.Enabled = True
            Me.cmsProceduresRefresh.Enabled = True
            Security.Apply(Me.cmsProcedures, AccessRights.Write)
        End If

    End Sub

    Private Sub cmsProceduresCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsProceduresCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.dgvIPDProcedures.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvIPDProcedures))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsProceduresSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsProceduresSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvIPDProcedures.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub cmsProceduresEditProcedures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsProceduresEditProcedures.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round's No!"))

            Dim fIPDProcedures As New frmIssueIPDProcedures(roundNo)
            fIPDProcedures.ShowDialog()

            ''''''''''''''''''''''''''''''''''''''''''  v''''''''''''''''''''''''''''''''''''''''
            Me.LoadProceduresData(roundNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsProceduresRefresh_Click(sender As System.Object, e As System.EventArgs) Handles cmsProceduresRefresh.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round's No!"))
            Me.LoadProceduresData(roundNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

    Private Function GetInvoiceExtraBillItems(invoiceNo As String, extraBillNo As String) As List(Of DBConnect)
        Dim lInvoiceExtraBillItems As New List(Of DBConnect)
        Dim itemCategoryID As String = oItemCategoryID.Procedure()
        Dim oExtraItemCodes As New LookupDataID.ExtraItemCodes()
        Dim oObjectNames As New LookupDataID.AccessObjectNames()
        For rowNo As Integer = 0 To Me.dgvIPDProcedures.RowCount - 1

            If CBool(Me.dgvIPDProcedures.Item(Me.colInclude.Name, rowNo).Value) = True Then

                Dim cells As DataGridViewCellCollection = Me.dgvIPDProcedures.Rows(rowNo).Cells

                Dim itemCode As String = StringEnteredIn(cells, Me.colProcedureCode, "Procedure no!")
                Dim drugName As String = StringEnteredIn(cells, Me.colProcedureName, "Procedure name!")
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity, "quantity!")


                Using oInvoiceExtraBillItems As New SyncSoft.SQLDb.InvoiceExtraBillItems()

                    If oVariousOptions.GenerateProcedureInvoiceOnIssuingOnly() Then
                        With oInvoiceExtraBillItems
                            .InvoiceNo = invoiceNo
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .ObjectName = oObjectNames.ExtraBillItems()
                            .Quantity = quantity

                            If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                                  (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                                .UnitPrice = DecimalEnteredIn(cells, Me.colUnitPrice, True, "unit price!")
                            Else : .UnitPrice = DecimalEnteredIn(cells, Me.colUnitPrice, False, "unit price!")
                            End If
                            .Discount = 0
                            If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                                  (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                                .Amount = DecimalEnteredIn(cells, Me.colAmount, True, "amount!")
                            Else : .Amount = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")
                            End If


                        End With


                        lInvoiceExtraBillItems.Add(oInvoiceExtraBillItems)

                    End If
                End Using
            End If
        Next

        Return lInvoiceExtraBillItems
    End Function



    Private Sub dgvIPDProcedures_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIPDProcedures.CellEndEdit
        Me.CalculateTotalBill()
    End Sub



    Private Sub btnView_Click(sender As System.Object, e As System.EventArgs) Handles btnView.Click

        ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowSentIPDAlerts()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fIPDAlerts As New frmIPDAlerts(oAlertTypeID.Procedure, Me.stbRoundNo)
        fIPDAlerts.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowDispensingData()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub ShowDispensingData()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me.pnlNavigateRounds)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
            If String.IsNullOrEmpty(roundNo) Then Return
            Me.LoadProceduresData(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me.pnlNavigateRounds)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnSaveIPD_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveIPD.Click
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oVariousOptions As New VariousOptions()
        Dim oStockTypeID As New LookupDataID.StockTypeID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oAdmissionStatusID As New LookupDataID.AdmissionStatusID()
        Dim lIPDItems As New List(Of DBConnect)
        Dim lInventory As New List(Of DBConnect)
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round's No!"))
            Dim roundDate As Date = DateEnteredIn(Me.stbRoundDateTime, "Round Date Time!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvIPDProcedures.RowCount < 1 Then Throw New ArgumentException("Must register at least one entry for Procedures " +
                                                ControlChars.NewLine + "If this is a cash patient, ensure that payment is done first!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvIPDProcedures.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvIPDProcedures.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry for Procedures!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            'Dim admissionStatus As String = StringMayBeEnteredIn(Me.stbAdmissionStatus)
            'Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)
            'Dim notPaidPayStatus As String = GetLookupDataDes(oPayStatusID.NotPaid)
            'Dim dischargedAdmissionStatus As String = GetLookupDataDes(oAdmissionStatusID.Discharged)

            'If Not oVariousOptions.AllowAccessCashServices AndAlso Not accessCashServices AndAlso
            '    billMode.ToUpper().Equals(cashAccountNo.ToUpper()) AndAlso
            '    admissionStatus.ToUpper().Equals(dischargedAdmissionStatus.ToUpper()) Then

            '    Dim cashNotPaid As Boolean = False
            '    For Each row As DataGridViewRow In Me.dgvProcedures.Rows
            '        If row.IsNewRow Then Exit For
            '        If CBool(Me.dgvProcedures.Item(Me.colInclude.Name, row.Index).Value) = True Then
            '            Dim payStatus As String = StringEnteredIn(row.Cells, Me.colPayStatus, "pay status!")
            '            If payStatus.ToUpper().Equals(notPaidPayStatus.ToUpper()) Then
            '                cashNotPaid = True
            '                Exit For
            '            End If
            '        End If
            '        cashNotPaid = False
            '    Next

            '    If cashNotPaid Then Throw New ArgumentException("The system does not allow dispensing of not paid for Consumable(s) for a discharged cash visit!")

            'End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvIPDProcedures.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvIPDProcedures.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    Dim quantity As Integer = IntegerEnteredIn(row.Cells, Me.colQuantity, "quantity!")
                    If quantity < 0 Then Throw New ArgumentException("Negative quantity not allowed!")
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim lExtraBills As New List(Of DBConnect)
            Dim lExtraBillsEXT As New List(Of DBConnect)
            Dim oExtraBillsEXT As New SyncSoft.SQLDb.ExtraBillsEXT()
            Dim billHeaderTransactions As New List(Of TransactionList(Of DBConnect))

            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim extraBillNo As String = oExtraBillsEXT.GetExtraBillsEXTExtraBillNo(roundNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Using oExtraBills As New SyncSoft.SQLDb.ExtraBills()

                With oExtraBills

                    .VisitNo = visitNo
                    .ExtraBillNo = GetNextExtraBillNo(visitNo, patientNo)
                    .ExtraBillDate = DateEnteredIn(Me.stbRoundDateTime, "Extra Bill Date!")
                    .StaffNo = doctorStaffNo
                    .LoginID = CurrentUser.LoginID

                End With

                lExtraBills.Add(oExtraBills)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If String.IsNullOrEmpty(extraBillNo) Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    billHeaderTransactions.Add(New TransactionList(Of DBConnect)(lExtraBills, Action.Save))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    With oExtraBillsEXT
                        .ExtraBillNo = oExtraBills.ExtraBillNo
                        .RoundNo = roundNo
                    End With

                    lExtraBillsEXT.Add(oExtraBillsEXT)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    billHeaderTransactions.Add(New TransactionList(Of DBConnect)(lExtraBillsEXT, Action.Save))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    extraBillNo = oExtraBills.ExtraBillNo
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(billHeaderTransactions)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If

            End Using

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me, ErrProvider)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvIPDProcedures.RowCount - 1

                If CBool(Me.dgvIPDProcedures.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvIPDProcedures.Rows(rowNo).Cells

                    Dim procedureCode As String = StringEnteredIn(cells, Me.colProcedureCode, "Procedure Code!")
                    Dim procedureName As String = StringEnteredIn(cells, Me.colProcedureName, "Procedure name!")
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity, "quantity!")
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, True, "amount!")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                        With oIPDItems

                            .RoundNo = roundNo
                            .ItemCode = procedureCode
                            .ItemCategoryID = oItemCategoryID.Procedure
                            .LastUpdate = roundDate
                            .PayStatusID = String.Empty
                            .LoginID = CurrentUser.LoginID
                            .ItemStatusID = oItemStatusID.Offered

                        End With
                        lIPDItems.Add(oIPDItems)
                    End Using


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)

                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colProcedureNotes)
                    Dim unitPrice As Decimal = DecimalMayBeEnteredIn(cells, Me.colUnitPrice, True)

                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = procedureCode
                            .ItemCategoryID = oItemCategoryID.Procedure
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = notes
                            .LastUpdate = roundDate
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, procedureCode, oItemCategoryID.Procedure).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If
                            .EntryModeID = oEntryModeID.System
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
                    Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()
                    Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = procedureCode
                                .ItemCategoryID = oItemCategoryID.Procedure
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, procedureCode, oItemCategoryID.Procedure).Equals(True) Then
                                    .CashPayStatusID = oPayStatusID.NA
                                Else
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End If
                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If
            Next

            If oVariousOptions.GenerateProcedureInvoiceOnIssuingOnly() Then
                Dim lInvoiceExtraBillItems As New List(Of DBConnect)
                Dim linvoices As New List(Of DBConnect)
                Dim invoiceNo As String = RevertText(GetNextInvoiceNo())
                lInvoiceExtraBillItems = Me.GetInvoiceExtraBillItems(invoiceNo, extraBillNo)
                Using oInvoice As New Invoices()
                    With oInvoice

                        .InvoiceNo = invoiceNo
                        .PayTypeID = oPayTypeID.VisitBill
                        .PayNo = visitNo
                        .InvoiceDate = Today
                        .StartDate = Today
                        .EndDate = Today
                        .AmountWords = NumberToWords(DecimalMayBeEnteredIn(stbBillForProcedures))
                        .VisitTypeID = oVisitTypeID.OutPatient
                        .Locked = True
                        .EntryModeID = oEntryModeID.System()
                        .LoginID = CurrentUser.LoginID

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ValidateEntriesIn(Me)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End With
                    linvoices.Add(oInvoice)
                End Using
                transactions.Add(New TransactionList(Of DBConnect)(linvoices, Action.Save))
                transactions.Add(New TransactionList(Of DBConnect)(lInvoiceExtraBillItems, Action.Save))

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Update))
            transactions.Add(New TransactionList(Of DBConnect)(lInventory, Action.Save))

            DoTransactions(transactions)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim allSelected As Boolean = True

            For Each row As DataGridViewRow In Me.dgvIPDProcedures.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvIPDProcedures.Item(Me.colInclude.Name, row.Index).Value) = False Then
                    allSelected = False
                    Me.LoadProceduresToOffer(roundNo)
                    Exit For
                End If
                allSelected = True
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If allSelected Then
                Me.dgvIPDProcedures.Rows.Clear()
                ResetControlsIn(Me)
                ResetControlsIn(Me.pnlNavigateRounds)
                Me.ClearControls()

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentIPDAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class