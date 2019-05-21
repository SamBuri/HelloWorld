
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports SyncSoft.Common.SQL.Classes
Imports System.Collections.Generic
Imports SyncSoft.SQLDb
Imports SyncSoft.SQLDb.Lookup

Public Class frmIPDCancerDiagnosis

#Region " Fields "
    Private diseases As DataTable
    Private doctorLoginID As String = String.Empty
    Private staffFullName As String = String.Empty
    Private _DiagnosisValue As String = String.Empty
#End Region
    Private roundNo As String
    Private doctorFullName As String

    Private Sub frmIPDCancerDiagnosis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()
            ResetControlsIn(Me)
            Me.LoadStaff()
            Me.LoadCancerDiseases()
            Me.LoadTopologySites()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.ColBasisOfDiagnosis, LookupObjects.BasisOfDiagnosis, False)
            LoadLookupDataCombo(Me.ColCancerStage, LookupObjects.StageOfCancer, True)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(roundNo) Then

                Me.cboRoundNo.Text = roundNo
                Me.cboRoundNo.Enabled = False
                Me.cboStaffNo.Text = doctorFullName
                Me.ProcessTabKey(True)
                Me.LoadRoundsData(roundNo)

            Else : Me.stbVisitNo.ReadOnly = False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Function AllSaved() As Boolean

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim message As String = "Please ensure that all items are saved on "
            Dim visitNo As String = StringMayBeEnteredIn(Me.stbVisitNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(visitNo) Then Return True

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            For Each row As DataGridViewRow In Me.dgvCancerDiagnosis.Rows
                If row.IsNewRow Then Exit For
                If Not BooleanMayBeEnteredIn(row.Cells, Me.colDiagnosisSaved) Then
                    DisplayMessage(message + Me.tpgDiagnosis.Text)
                    If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                    Return False
                End If
            Next


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return True

        End Try

    End Function

   
    Private Sub SaveIPDDoctor()

        Dim oAdmissionStatusID As New LookupDataID.AdmissionStatusID()
        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim message As String

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

            With oIPDDoctor

                .RoundNo = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
                .AdmissionNo = RevertText(StringEnteredIn(Me.stbAdmissionNo, "Admission No!"))
                Dim staffNo As String = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
                .StaffNo = staffNo
                .RoundDateTime = DateTimeEnteredIn(Me.dtpRoundDateTime, "Round Date Time!")
                .LoginID = CurrentUser.LoginID

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim staff As DataTable = oStaff.GetStaff(staffNo).Tables("Staff")
                Dim miniStaff As EnumerableRowCollection(Of DataRow) = staff.AsEnumerable()
                Dim doctorLoginID As String = (From data In miniStaff Select data.Field(Of String)("LoginID")).First()

                If String.IsNullOrEmpty(doctorLoginID) Then
                    message = "The attending doctor you have selected does not have an associated login ID we recommend " + _
                   "that you contact the administrator to have this fixed. Else you won’t get system alerts." + _
                                           ControlChars.NewLine + "Are you sure you want to continue?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

                ElseIf Not doctorLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then
                    message = "The attending doctor you have selected has a different associated login ID from that " + _
                    "of the current user. Alerts for this round won’t be forwarded to you. " + _
                                         ControlChars.NewLine + "Are you sure you want to continue?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not .IsIPDDoctorSaved Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim admissionStatus As String = StringEnteredIn(Me.stbAdmissionStatus, "Admission Status!")
                    If admissionStatus.ToUpper().Equals(GetLookupDataDes(oAdmissionStatusID.Discharged).ToUpper()) Then
                        message = "This patient has been discharged. You can’t create a new round on a discharged admission!"
                        Throw New ArgumentException(message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    .Save()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

             
            End With

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub SaveIPDCancerDiagnosis()

        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim lIPDDiagnosis As New List(Of DBConnect)
            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
            Me.SaveIPDDoctor()
            If Me.dgvCancerDiagnosis.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for diagnosis!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvCancerDiagnosis.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvCancerDiagnosis.Rows(rowNo).Cells

                Try

                    Using oDiagnosis As New SyncSoft.SQLDb.IPDCancerDiagnosis
                        With oDiagnosis

                            .RoundNo = roundNo
                            .DiseaseNo = StringEnteredIn(cells, Me.colDiseaseCode)
                            .TopographicalNo = StringEnteredIn(cells, Me.ColTopology)
                            .BasisOfDiagnosisID = StringEnteredIn(cells, Me.ColBasisOfDiagnosis)
                            .CancerStageID = StringEnteredIn(cells, Me.ColCancerStage)
                            .Notes = StringEnteredIn(cells, Me.colNotes)
                            .LoginID = CurrentUser.LoginID
                            .RecordDateTime = Now()
                        End With

                        lIPDDiagnosis.Add(oDiagnosis)

                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lIPDDiagnosis, Action.Save))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvCancerDiagnosis.Item(Me.colDiagnosisSaved.Name, rowNo).Value = True

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

   
    Private Sub ResetControls()

        '''''''''''''''''''''''''''''''''''''''
        ResetControlsIn(Me)

    End Sub

    Private Sub LoadTopologySites()

        Dim oTopologySites As New SyncSoft.SQLDb.TopologySites()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from TopologySites
            Dim topologySites As DataTable = oTopologySites.GetTopologySites.Tables("TopologySites")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.ColTopology, topologySites, "TopographicalNo", "TopologyFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub frmIPDCancerDiagnosis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetDiagnosisEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvCancerDiagnosis.Rows(selectedRow).Cells, Me.colDiseaseCode)

            If CBool(Me.dgvCancerDiagnosis.Item(Me.colDiagnosisSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim diagnosis As EnumerableRowCollection(Of DataRow) = diseases.AsEnumerable()
                Dim diagnosisDisplay As String = (From data In diagnosis
                                    Where data.Field(Of String)("DiseaseNo").ToUpper().Equals(_DiagnosisValue.ToUpper())
                                    Select data.Field(Of String)("DiseaseName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Diagnosis (" + diagnosisDisplay + ") can't be edited!")
                Me.dgvCancerDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Value = _DiagnosisValue
                Me.dgvCancerDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvCancerDiagnosis.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvCancerDiagnosis.Rows(rowNo).Cells, Me.colDiseaseCode)
                    If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim diagnosis As EnumerableRowCollection(Of DataRow) = diseases.AsEnumerable()
                        Dim enteredDisplay As String = (From data In diagnosis
                                            Where data.Field(Of String)("DiseaseNo").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("DiseaseName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Diagnosis (" + enteredDisplay + ") already entered!")
                        Me.dgvCancerDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Value = _DiagnosisValue
                        Me.dgvCancerDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If diseases Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

            For Each row As DataRow In diseases.Select("DiseaseNo = '" + selectedItem + "'")
                Me.dgvCancerDiagnosis.Item(Me.colCancerDiagnosisCode.Name, selectedRow).Value = StringEnteredIn(row, "DiseaseNo")
                Me.dgvCancerDiagnosis.Item(Me.colDiseaseCategory.Name, selectedRow).Value = StringEnteredIn(row, "CancerDiseaseCategory")
                '  Me.dgvCancerDiagnosis.Item(Me.colCancerDiagnosisCode.Name, selectedRow).Value = selectedItem
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub LoadCancerDiseases()

        Dim oDiseases As New SyncSoft.SQLDb.CancerDiseases()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Diseases
            diseases = oDiseases.GetCancerDiseases().Tables("CancerDiseases")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colDiseaseCode.Sorted = False
            LoadComboData(Me.colDiseaseCode, diseases, "DiseaseNo", "DiseaseName")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub ShowRoundsHeaderData()

        Try

            '
            ResetControlsIn(Me.pnlNavigateRounds)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.cboRoundNo))
            If String.IsNullOrEmpty(roundNo) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadRoundsData(roundNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)


        End Try

    End Sub

    Private Sub LoadRoundsData(ByVal roundNo As String)

        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim iPDDoctor As DataTable = oIPDDoctor.GetIPDDoctor(roundNo).Tables("IPDDoctor")
            Dim iPDDoctorData As EnumerableRowCollection(Of DataRow) = iPDDoctor.AsEnumerable()
            Dim admissionNo As String = (From data In iPDDoctorData Select data.Field(Of String)("AdmissionNo")).First()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowPatientDetails(admissionNo)
            Me.LoadIPDCancerDiagnosis(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal admissionNo As String)

        Dim oAdmissions As New SyncSoft.SQLDb.Admissions()

        Try

           
            Dim admissions As DataTable = oAdmissions.GetAdmissions(admissionNo).Tables("Admissions")
            Dim row As DataRow = admissions.Rows(0)

            Dim patientNo As String = StringEnteredIn(row, "PatientNo")
            Dim visitNo As String = StringEnteredIn(row, "VisitNo")

            Me.stbAdmissionNo.Text = FormatText(admissionNo, "Admissions", "AdmissionNo")
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbAdmissionDateTime.Text = FormatDateTime(DateTimeEnteredIn(row, "AdmissionDateTime"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbTotalIPDDoctorRounds.Text = StringEnteredIn(row, "TotalIPDDoctorRounds")
            Me.stbAdmissionStatus.Text = StringMayBeEnteredIn(row, "AdmissionStatus")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbBillAccountNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            Dim billCustomerName As String = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName
            Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")

            'billModesID = StringMayBeEnteredIn(row, "BillModesID")
            'associatedBillNo = StringMayBeEnteredIn(row, "AssociatedBillNo")
            'Me.stbPackage.Text = StringMayBeEnteredIn(row, "PackageName")
            'hasPackage = BooleanMayBeEnteredIn(row, "HasPackage")
            'patientpackageNo = StringMayBeEnteredIn(row, "PackageNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception

            Throw eX

        End Try

    End Sub

    Private Sub LoadIPDCancerDiagnosis(ByVal roundNo As String)

        Dim oIPDCancerDiagnosis As New SyncSoft.SQLDb.IPDCancerDiagnosis()

        Try

            Me.dgvCancerDiagnosis.Rows.Clear()

            ' Load items not yet paid for

            If String.IsNullOrEmpty(roundNo) Then Return

            Dim cancerDiagnosis As DataTable = oIPDCancerDiagnosis.GetIPDCancerDiagnosis(RevertText(roundNo), String.Empty).Tables("IPDCancerDiagnosis")
            If cancerDiagnosis Is Nothing OrElse cancerDiagnosis.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To cancerDiagnosis.Rows.Count - 1

                Dim row As DataRow = cancerDiagnosis.Rows(pos)

                With Me.dgvCancerDiagnosis
                    ' Ensure that you add a new row

                    .Rows.Add()
                    .Item(Me.colDiseaseCode.Name, pos).Value = StringEnteredIn(row, "DiseaseNo")
                    .Item(Me.colCancerDiagnosisCode.Name, pos).Value = StringEnteredIn(row, "DiseaseNo")
                    .Item(Me.ColTopology.Name, pos).Value = StringEnteredIn(row, "TopographicalNo")
                    .Item(Me.ColBasisOfDiagnosis.Name, pos).Value = StringEnteredIn(row, "BasisOfDiagnosisID")
                    .Item(Me.colDiseaseCategory.Name, pos).Value = StringMayBeEnteredIn(row, "CancerDiseaseCategory")
                    .Item(Me.ColCancerStage.Name, pos).Value = StringEnteredIn(row, "CancerStageID")
                    .Item(Me.colNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")
                    .Item(Me.colDiagnosisSaved.Name, pos).Value = True

                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub btnFindAdmissionNo_Click(sender As Object, e As EventArgs) Handles btnFindAdmissionNo.Click
        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fFindAdmissionNo As New frmFindAutoNo(Me.stbAdmissionNo, AutoNumber.AdmissionNo)
            fFindAdmissionNo.ShowDialog(Me)

            
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
            If String.IsNullOrEmpty(admissionNo) Then Return
            Me.ShowPatientDetails(admissionNo)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub btnLoadRounds_Click(sender As Object, e As EventArgs) Handles btnLoadRounds.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fIPDDoctorRounds As New frmIPDDoctorRounds(Me.cboRoundNo)
        fIPDDoctorRounds.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowRoundsHeaderData()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub dgvCancerDiagnosis_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvCancerDiagnosis.CellBeginEdit
        If e.ColumnIndex <> Me.colDiseaseCode.Index OrElse Me.dgvCancerDiagnosis.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvCancerDiagnosis.CurrentCell.RowIndex
        _DiagnosisValue = StringMayBeEnteredIn(Me.dgvCancerDiagnosis.Rows(selectedRow).Cells, Me.colDiseaseCode)
    End Sub

   

    Private Sub dgvCancerDiagnosis_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCancerDiagnosis.CellEndEdit
        Try

            If e.ColumnIndex.Equals(Me.colDiseaseCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvCancerDiagnosis.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvCancerDiagnosis.CurrentCell.RowIndex
                    Me.SetDiagnosisEntries(selectedRow)

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvCancerDiagnosis_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgvCancerDiagnosis.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oIPDDiagnosis As New SyncSoft.SQLDb.IPDCancerDiagnosis()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvCancerDiagnosis.Item(Me.colDiagnosisSaved.Name, toDeleteRowNo).Value) = False Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
            Dim diagnosis As String = CStr(Me.dgvCancerDiagnosis.Item(Me.colDiseaseCode.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnDelete, AccessRights.Delete)
            If Me.btnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oIPDDiagnosis
                .RoundNo = roundNo
                .DiseaseNo = diagnosis
                DisplayMessage(.Delete())
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnFindRoundNo_Click(sender As Object, e As EventArgs)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindRoundNo As New frmFindAutoNo(Me.cboRoundNo, AutoNumber.RoundNo)
        fFindRoundNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowRoundsHeaderData()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.SaveIPDCancerDiagnosis()
    End Sub

 

    Private Sub cmsDoctor_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles cmsDoctor.Opening


        Select Case Me.tbcDrCancerRoles.SelectedTab.Name

            Case Me.tpgDiagnosis.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True

        End Select


    End Sub

    Private Sub cmsDoctorQuickSearch_Click(sender As System.Object, e As System.EventArgs) Handles cmsDoctorQuickSearch.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim rowIndex As Integer

            Select Case Me.tbcDrCancerRoles.SelectedTab.Name

                Case Me.tpgDiagnosis.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("CancerDiseases", Me.dgvCancerDiagnosis, Me.colDiseaseCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvCancerDiagnosis.NewRowIndex
                    If rowIndex > 0 Then Me.SetDiagnosisEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cboRoundNo_Leave(sender As Object, e As System.EventArgs) Handles cboRoundNo.Leave
        If Not Me.AllSaved() Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fIPDDoctorRounds As New frmIPDDoctorRounds(Me.cboRoundNo)
        fIPDDoctorRounds.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowRoundsHeaderData()
    End Sub

   
End Class