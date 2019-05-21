
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Structures
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.Enumerations
Imports SyncSoft.Common.SQL.Enumerations
Imports System.Collections.Generic
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Public Class frmImmunisationVaccines

#Region " Fields "
    Private vaccines As DataTable
    Private _VaccineValue As String = String.Empty
    Private _patientNo As String

    Private immunisationSaved As Boolean = True
    Private defaultVisitNo As String = String.Empty
    Private defaultPatientNo As String = String.Empty
    Private oVaccinesReceived As New LookupDataID.VaccinesID

#End Region


    Private Sub frmImmunisationVaccines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()
            LoadLookupDataCombo(Me.colPlaceReceived, LookupObjects.PlaceReceived, False)
            LoadLookupDataCombo(Me.colVaccineName, LookupObjects.Vaccines, False)
            LoadLookupDataCombo(Me.colVaccineReceived, LookupObjects.YesNo, False)
            Me.SetNextImmunisationNo()

            If Not String.IsNullOrEmpty(defaultPatientNo) Then
                Me.stbPatientNo.Text = FormatText(defaultPatientNo, "Patients", "PatientNo")
                Me.stbPatientNo.ReadOnly = True

                Me.LoadImmunisationDetails(defaultPatientNo)
                Me.ProcessTabKey(True)
            Else
                Me.stbPatientNo.ReadOnly = False
                Me.btnLoad.Enabled = True
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmImmunisationVaccines_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oImmunisationVaccines As New SyncSoft.SQLDb.ImmunisationVaccines()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return



            DisplayMessage(oImmunisationVaccines.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click



        Dim oImmunisationVaccines As New SyncSoft.SQLDb.ImmunisationVaccines()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))
            Dim ImmunisationNo As String = RevertText(StringEnteredIn(Me.stbImmunisationNo, "Immunisation No!"))
            If String.IsNullOrEmpty(patientNo) Then Return

            Dim dataSource As DataTable = oImmunisationVaccines.GetImmunisationVaccines(patientNo).Tables("ImmunisationVaccines")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click


      Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim lVaccines As New List(Of DBConnect)
            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

            If Me.dgvImmunisationVaccines.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for Immunisation !")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvImmunisationVaccines.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvImmunisationVaccines.Rows(rowNo).Cells
                Dim vaccineName As String = StringMayBeEnteredIn(cells, Me.colVaccineName)
                Dim vaccineReceived As String = StringMayBeEnteredIn(cells, Me.colVaccineReceived)
                Dim placeReceived As String = StringMayBeEnteredIn(cells, Me.colPlaceReceived)
                Dim dateGiven As Date = CDate(CStr(DateMayBeEnteredIn(cells, Me.colDateGiven)))
                Dim immunisationNotes As String = StringMayBeEnteredIn(cells, Me.colImmunisationNotes)


                Try

                    Using oImmmunisationVaccines As New SyncSoft.SQLDb.ImmunisationVaccines()
                        With oImmmunisationVaccines

                            .ImmunisationNo = RevertText(StringEnteredIn(Me.stbImmunisationNo, "Immunisation No!"))
                            .PatientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))
                            .VaccineName = vaccineName
                            .VaccineReceived = vaccineReceived
                            .DateGiven = dateGiven
                            .PlaceReceived = placeReceived
                            .MothersName = StringMayBeEnteredIn(Me.stbMothersName)
                            .Notes = immunisationNotes
                            .LoginID = CurrentUser.LoginID

                        End With

                        lVaccines.Add(oImmmunisationVaccines)
                        oImmmunisationVaccines.Save()

                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lVaccines, Action.Save))

                    DoTransactions(transactions)

                    'Me.dgvImmunisationVaccines.Item(Me.colImmunisationSaved.Name, rowNo).Value = True

                    DisplayMessage("Immunisation Successfully Saved!")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                Catch ex As Exception
                    'ErrorMessage(ex)

                End Try

            Next




            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetNextImmunisationNo()
            Me.ClearControls()
            Me.ResetControls()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub



#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False



        ResetControlsIn(Me)
        Me.SetNextImmunisationNo()

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

    Private Sub LoadImmunisationDetails(ByVal patientNo As String)
        Dim oImmunisationVaccines As New SyncSoft.SQLDb.ImmunisationVaccines


        Try
            Dim ImmunisationVaccines As DataTable = oImmunisationVaccines.GetImmunisationVaccines(patientNo).Tables("ImmunisationVaccines")


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If ImmunisationVaccines Is Nothing OrElse ImmunisationVaccines.Rows.Count < 1 Then Return

            For Each row As DataRow In ImmunisationVaccines.Rows

                Me.stbMothersName.Text = StringMayBeEnteredIn(row, "MothersName")

                LoadGridData(Me.dgvImmunisationHistory, ImmunisationVaccines)
            Next


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            ' '''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

         

            Select Case Me.tbcImmunisation.SelectedTab.Name
                Case Me.tpgImmunisationHistory.Name

                    Dim immunisationHistory As DataTable = oImmunisationVaccines.GetImmunisationVaccines(patientNo).Tables("ImmunisationVaccines")
                    LoadGridData(Me.dgvImmunisationHistory, ImmunisationVaccines)
                    ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    For rowNo As Integer = 0 To immunisationHistory.Rows.Count - 1

                        Dim row As DataRow = immunisationHistory.Rows(rowNo)

                        With Me.dgvImmunisationHistory

                            .Rows.Add()

                            .Item(Me.colHistoryVaccineName.Name, rowNo).Value = StringMayBeEnteredIn(row, "VaccineNameID")
                            .Item(Me.ColHistoryDateGiven.Name, rowNo).Value = DateMayBeEnteredIn(row, "DateGiven")
                            .Item(Me.ColHistoryPlaceReceived.Name, rowNo).Value = StringMayBeEnteredIn(row, "PlaceReceivedID")

                        End With

                    Next

                    ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvImmunisationHistory.Rows.Clear()
                    '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colVaccineName.ReadOnly = False
            Me.colVaccineReceived.ReadOnly = False
            Me.colPlaceReceived.ReadOnly = False
            Me.colDateGiven.ReadOnly = False
            Me.colImmunisationNotes.ReadOnly = False
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            immunisationSaved = True
        Catch ex As Exception
            ErrorMessage(ex)

        End Try


    End Sub

    Private Sub ClearControls()
        Me.stbFullName.Clear()
        Me.stbJoinDate.Clear()
        Me.stbLastVisitDate.Clear()
        Me.dgvImmunisationHistory.Rows.Clear()
    End Sub

    Private Sub ResetControls()
        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgVaccines)
    End Sub

    Private Sub ShowPatientDetails(ByVal patientNo As String)
        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oVariousOptions As New VariousOptions()
        Dim oAccessCashServices As New SyncSoft.SQLDb.AccessedCashServices()
        Dim outstandingBalanceErrorMSG As String = "This patient has offered/done service(s) with pending payment. " +
                                                    ControlChars.NewLine + "Please advice accordingly!"
        Dim debitBalanceErrorMSG As String = "This Patient has a debt!! Debit balance should be cleared first!"
        Try
            Me.Cursor = Cursors.WaitCursor


            Dim patients As DataTable = oPatients.GetPatients(patientNo).Tables("Patients")
            Dim row As DataRow = patients.Rows(0)
            Dim lastVisitDate As Date = DateEnteredIn(row, "lastVisitDate")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbPatientNo.Text = RevertText(FormatText(patientNo, "Patients", "PatientNo"))
            Me.stbLastVisitDate.Text = FormatDate(lastVisitDate)
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbLocation.Text = StringEnteredIn(row, "Address")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")
            Dim birthDate As Date = DateMayBeEnteredIn(row, "BirthDate")
            Me.nbxAge.Text = GetAgeString(birthDate)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim pt As EnumerableRowCollection(Of DataRow) = patients.AsEnumerable()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception

            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    'Private Sub ShowTriageDetails(ByVal visitNo As String)
    '    Dim oTriage As New SyncSoft.SQLDb.Triage()
    '    Dim oVariousOptions As New VariousOptions()

    '    Me.Cursor = Cursors.WaitCursor

    '    Dim triage As DataTable = oTriage.GetTriage(VisitNo).Tables("Triage")
    '    Dim row As DataRow = triage.Rows(0)

    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    'Me.nbxWeight.Text = StringEnteredIn(row, "Weight")
    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim pt As EnumerableRowCollection(Of DataRow) = triage.AsEnumerable()
    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


    'End Sub

    Private Sub stbPatientNo_Leave(sender As System.Object, e As System.EventArgs)
        Dim oPatients As New SyncSoft.SQLDb.Patients()

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.ResetControls()
            Me.ClearControls()

            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            If String.IsNullOrEmpty(patientNo) Then Return

            Dim patients As DataTable = oPatients.GetPatients(patientNo).Tables("Patients")
            Dim row As DataRow = patients.Rows(0)
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbLastVisitDate.Text = FormatDate(DateEnteredIn(row, "LastVisitDate"))
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub




    Private Sub dgvImmunisationVaccines_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvImmunisationVaccines.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            LoadLookupDataCombo(Me.colPlaceReceived, LookupObjects.PlaceReceived, False)
            LoadLookupDataCombo(Me.colVaccineName, LookupObjects.Vaccines, False)
            LoadLookupDataCombo(Me.colVaccineReceived, LookupObjects.YesNo, False)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dateGiven As Date = DateMayBeEnteredIn(Me.dgvImmunisationVaccines.Rows(e.RowIndex).Cells, Me.colDateGiven)

            Dim fSelectDateTime As New SyncSoft.SQL.Win.Forms.SelectDateTime(dateGiven, "Date Given", AppData.MinimumDate, Today,
                                                                     Me.dgvImmunisationVaccines, Me.colDateGiven, e.RowIndex)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.colDateGiven.Index.Equals(e.ColumnIndex) AndAlso Me.dgvImmunisationVaccines.Rows(e.RowIndex).IsNewRow Then

                Me.dgvImmunisationVaccines.Rows.Add()
                fSelectDateTime.ShowDialog(Me)

                Dim enteredDate As Date = DateMayBeEnteredIn(Me.dgvImmunisationVaccines.Rows(e.RowIndex).Cells, Me.colDateGiven)
                If enteredDate = AppData.NullDateValue Then Me.dgvImmunisationVaccines.Rows.RemoveAt(e.RowIndex)

            ElseIf Me.colDateGiven.Index.Equals(e.ColumnIndex) Then

                fSelectDateTime.ShowDialog(Me)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub ShowVisitsHeaderData()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Me.ClearControls()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Me.LoadImmunisationDetails(patientNo)
            Me.ShowPatientDetails(patientNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            Me.ResetControls()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End Try

    End Sub


    Private Sub SetNextImmunisationNo()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oImmunisationVaccines As New SyncSoft.SQLDb.ImmunisationVaccines()
            Dim oVariousOption As New VariousOptions()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("ImmunisationVaccines", "ImmunisationNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim ImmunisationNoPrefix As String = oVariousOption.ImmunisationNoPrefix
            Dim nextImmunisationNo As String = CStr(oImmunisationVaccines.GetNextImmunisationID).PadLeft(paddingLEN, paddingCHAR)
            Me.stbImmunisationNo.Text = FormatText((ImmunisationNoPrefix + nextImmunisationNo).Trim(), "ImmunisationVaccines", "ImmunisationNo")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oImmunisation As New SyncSoft.SQLDb.ImmunisationVaccines()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Patients", Me.stbPatientNo)
            fQuickSearch.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            'Dim ImmunisationNo As String = RevertText(StringMayBeEnteredIn(Me.stbImmunisationNo))
            'If Not String.IsNullOrEmpty(patientNo) Then Me.ShowPatientDetails(patientNo)
            'Me.LoadImmunisationDetails(patientNo)
            Me.ShowVisitsHeaderData()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''f Me.stbPatientNo_Leave(Me, System.EventArgs.Empty)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub stbPatientNo_Enter(sender As System.Object, e As System.EventArgs) Handles stbPatientNo.Enter
        Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
        If String.IsNullOrEmpty(patientNo) Then Return
        Dim ImmunisationNo As String = RevertText(StringMayBeEnteredIn(Me.stbImmunisationNo))
        Me.ShowPatientDetails(patientNo)
        LoadImmunisationDetails(patientNo)
    End Sub

    Private Sub dgvImmunisationVaccines_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvImmunisationVaccines.CellEndEdit
        Try

            If Me.colVaccineName.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colVaccineName.Index) Then

                ' Ensure unique entry in the combo column

                Dim ImmunisationselectedRow As Integer = Me.dgvImmunisationVaccines.CurrentCell.RowIndex
                Dim ImmunisationselectedItem As String = StringMayBeEnteredIn(Me.dgvImmunisationVaccines.Rows(ImmunisationselectedRow).Cells, Me.colVaccineName)

                For rowNo As Integer = 0 To Me.dgvImmunisationHistory.RowCount - 1

                    Dim HistoryItem As String = StringMayBeEnteredIn(Me.dgvImmunisationHistory.Rows(rowNo).Cells, Me.colHistoryVaccineName)

                    If HistoryItem.Equals(GetLookupDataDes(ImmunisationselectedItem)) Then
                        DisplayMessage("Vaccine Name (" + HistoryItem + ") already entered!")
                        Me.dgvImmunisationVaccines.Item(Me.colVaccineName.Name, ImmunisationselectedRow).Value = _VaccineValue
                        Me.dgvImmunisationVaccines.Item(Me.colVaccineName.Name, ImmunisationselectedRow).Selected = True
                    End If

                Next


                If Me.dgvImmunisationVaccines.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvImmunisationVaccines.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvImmunisationVaccines.Rows(selectedRow).Cells, Me.colVaccineName)

                    If CBool(Me.dgvImmunisationVaccines.Item(Me.colImmunisationSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Vaccine Name (" + _VaccineValue + ") can't be edited!")
                        Me.dgvImmunisationVaccines.Item(Me.colVaccineName.Name, selectedRow).Value = _VaccineValue
                        Me.dgvImmunisationVaccines.Item(Me.colVaccineName.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvImmunisationVaccines.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvImmunisationVaccines.Rows(rowNo).Cells, Me.colVaccineName)
                            If enteredItem.Equals(selectedItem) Then
                                DisplayMessage("Vaccine Name (" + enteredItem + ") already entered!")
                                Me.dgvImmunisationVaccines.Item(Me.colVaccineName.Name, selectedRow).Value = _VaccineValue
                                Me.dgvImmunisationVaccines.Item(Me.colVaccineName.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub
End Class