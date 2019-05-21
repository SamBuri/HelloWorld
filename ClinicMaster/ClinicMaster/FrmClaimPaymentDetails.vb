Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID


Public Class FrmClaimPaymentDetails

#Region "Fields"
    Private diseases As DataTable
    Dim _claimNo As String = Nothing
#End Region

    Private Sub stbClaimNo_Leave(sender As Object, e As EventArgs) Handles stbClaimNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor()

            'Dim claimNo As String = RevertText(StringMayBeEnteredIn(Me.stbClaimNo))
            'Me.LoadClaimsData(claimNo)
            If Not String.IsNullOrEmpty(RevertText(StringMayBeEnteredIn(Me.stbClaimNo))) Then
                Me.LoadClaimsData(RevertText(StringMayBeEnteredIn(Me.stbClaimNo)))
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub


    Private Sub LoadClaimsData(ByVal claimNo As String)

        Dim oClaims As New SyncSoft.SQLDb.Claims()

        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim claims As DataTable = oClaims.GetClaims(claimNo).Tables("Claims")
            Me.DisplayData(claims)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadClaimDiagnosis(claimNo)
            Me.LoadClaimDetails(claimNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub


    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvDiagnosis_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvDiagnosis.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadClaimDetails(ByVal claimNo As String)

        Dim styleLimit As New DataGridViewCellStyle()
        Dim font As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
        Dim oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()

        Try

            Me.dgvClaimDetails.Rows.Clear()

            ' Load ClaimDetails

            Dim claimDetails As DataTable = oClaimDetails.GetClaimDetails(claimNo).Tables("ClaimDetails")

            If claimDetails Is Nothing OrElse claimDetails.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            styleLimit.BackColor = Color.MistyRose
            styleLimit.Font = font

            For pos As Integer = 0 To claimDetails.Rows.Count - 1

                Dim row As DataRow = claimDetails.Rows(pos)

                With Me.dgvClaimDetails
                    ' Ensure that you add a new row-
                    .Rows.Add()

                    .Item(Me.colItemName.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    '.Item(Me.colBenefitCode.Name, pos).Value = StringMayBeEnteredIn(row, "BenefitCode")
                    .Item(Me.colQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colAdjustment.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "Adjustment", True), AppData.DecimalPlaces)
                    .Item(Me.colAmount.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "Amount", True))
                    .Item(Me.colNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")
                    .Item(Me.colLimitAmount.Name, pos).Value = FormatNumber(DecimalMayBeEnteredIn(row, "LimitAmount", True), AppData.DecimalPlaces)
                    .Item(Me.colConsumedAmount.Name, pos).Value = FormatNumber(DecimalMayBeEnteredIn(row, "ConsumedAmount", True), AppData.DecimalPlaces)
                    Dim limitBalance As Decimal = DecimalMayBeEnteredIn(row, "LimitBalance", True)
                    .Item(Me.colLimitBalance.Name, pos).Value = FormatNumber(limitBalance, AppData.DecimalPlaces)
                    .Item(Me.colClaimDetailsSaved.Name, pos).Value = True

                    If limitBalance < 0 Then Me.dgvClaimDetails.Rows(pos).Cells(Me.colLimitBalance.Name).Style.ApplyStyle(styleLimit)

                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateTotalAmount()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadClaimDiagnosis(ByVal claimNo As String)

        Dim oClaimDiagnosis As New SyncSoft.SQLDb.ClaimDiagnosis()

        Try

            Me.dgvDiagnosis.Rows.Clear()

            ' Load items not yet paid for

            Dim claimDiagnosis As DataTable = oClaimDiagnosis.GetClaimDiagnosis(claimNo).Tables("ClaimDiagnosis")
            If claimDiagnosis Is Nothing OrElse claimDiagnosis.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To claimDiagnosis.Rows.Count - 1
                'DisplayMessage(claimDiagnosis.Rows.Count.ToString)
                Dim row As DataRow = claimDiagnosis.Rows(pos)

                With Me.dgvDiagnosis
                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colDiseaseCode.Name, pos).Value = StringEnteredIn(row, "DiseaseName")
                    .Item(Me.colDiseaseCategory.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseCategories")
                    .Item(Me.colDiagnosisSaved.Name, pos).Value = True
                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateTotalAmount()

        Dim totalAmount As Decimal

        For rowNo As Integer = 0 To Me.dgvClaimDetails.RowCount - 1

            If IsNumeric(Me.dgvClaimDetails.Item(Me.colConsumedAmount.Name, rowNo).Value) Then
                totalAmount += CDec(Me.dgvClaimDetails.Item(Me.colConsumedAmount.Name, rowNo).Value)
            Else : totalAmount += 0
            End If
        Next

        Me.stbTotalAmount.Text = FormatNumber(totalAmount, AppData.DecimalPlaces)
        Me.stbAmountWords.Text = NumberToWords(totalAmount)

    End Sub

    Private Sub FrmClaimPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Me.GetWaitingPeriodicClaims()
            If Not String.IsNullOrEmpty(_claimNo) Then
                Me.stbClaimNo.Text = _claimNo
                Me.LoadClaimsData(_claimNo)
                ' Me.LoadDiseases()
            End If
            Me.Cursor = Cursors.WaitCursor()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub LoadDiseases()

        Dim oDiseases As New SyncSoft.SQLDb.Diseases()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Me.colDiseaseCode.Sorted = False
            'LoadComboData(Me.colDiseaseCode, diseases, "DiseaseCode", "DiseaseName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub ebnSaveUpdate_Click(sender As Object, e As EventArgs) Handles ebnSaveUpdate.Click

        Dim oClaimPayments As New SyncSoft.SQLDb.ClaimPayments()
        Dim oPayStatus As New LookupDataID.PayStatusID
        Try
            Me.Cursor = Cursors.WaitCursor()

            With oClaimPayments

                .ClaimNo = StringEnteredIn(Me.stbClaimNo, "Claim No!")
                .PayStatusID = oPayStatus.PaidFor
                .PaymentDateTime = DateTimeEnteredIn(Me.dtpPaymentDateTime, "Payment Date Time!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save
                    'Dim message As String = "You are about to Pay Claim With ClaimNo:" + StringEnteredIn(Me.stbClaimNo, "Claim No!") +
                    '         ControlChars.NewLine + "Are you sure you want to Pay?"

                    'If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

                    oClaimPayments.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    Me.ClearControls()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oClaimPayments.Update())
                    'Me.CallOnKeyEdit()

            End Select
            Me.GetWaitingPeriodicClaims()
            If Not String.IsNullOrEmpty(_claimNo) Then
                Me.Close()
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub btnFindClaimNo_Click(sender As Object, e As EventArgs) Handles btnFindClaimNo.Click
        Dim fFindClaimNo As New frmFindAutoNo(Me.stbClaimNo, AutoNumber.ClaimNo)
        fFindClaimNo.ShowDialog(Me)
        Me.stbClaimNo.Focus()
    End Sub

    Private Sub btnLoadPeriodicClaims_Click(sender As Object, e As EventArgs) Handles btnLoadPeriodicClaims.Click
        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicClaims As New frmPeriodicClaims(Me.stbClaimNo)
            fPeriodicClaims.ShowDialog(Me)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadClaimsData(RevertText(StringEnteredIn(Me.stbClaimNo, "Claim No!")))

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub FrmClaimPayment_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            Me.GetWaitingPeriodicClaims()
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub GetWaitingPeriodicClaims()

        Dim oClaims As New SyncSoft.SQLDb.Claims()
        Dim oVariousOptions As New VariousOptions()

        Dim ClaimPaymentsAlertDays As Integer = oVariousOptions.ClaimPaymentsAlertDays
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim WaitingPeriodicClaims As DataTable = oClaims.GetWaitingPeriodicClaims(ClaimPaymentsAlertDays).Tables("WaitingPeriodicClaims")

            Dim AlertsNo As Integer = WaitingPeriodicClaims.Rows.Count
            'DisplayMessage(iPDAlertsNo.ToString)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblWaitingToPayForClaims.Text = "Waiting To Pay For Claims: " + AlertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoadList_Click(sender As Object, e As EventArgs) Handles btnLoadList.Click
        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicClaims As New frmPeriodicClaims(Me.stbClaimNo, False, False)
            fPeriodicClaims.ShowDialog(Me)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(RevertText(StringMayBeEnteredIn(Me.stbClaimNo))) Then
                Me.LoadClaimsData(RevertText(StringMayBeEnteredIn(Me.stbClaimNo)))
            End If

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbFullName.Clear()
        Me.stbAge.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbMemberType.Clear()
        Me.stbMainMemberName.Clear()
        Me.stbCompanyName.Clear()
        Me.stbInsuranceName.Clear()
        Me.stbPolicyName.Clear()
        Me.stbPolicyStartDate.Clear()
        Me.stbPolicyEndDate.Clear()
        Me.stbVisitDate.Clear()
        Me.stbVisitNo.Clear()
        Me.stbAmountWords.Clear()
        Me.stbTotalAmount.Clear()
        Me.stbMedicalCardNo.Clear()
        Me.stbPatientNo.Clear()
        Me.stbHealthUnit.Clear()
        Me.stbPrimaryDoctor.Clear()
        Me.stbClaimStatus.Clear()
        Me.stbClaimEntry.Clear()

        Me.dgvDiagnosis.Rows.Clear()
        Me.dgvClaimDetails.Rows.Clear()
    End Sub

    Private Sub CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.ebnSaveUpdate.Enabled = False
            Me.fbnDelete.Enabled = False
        End If
    End Sub


    Private Sub frmClaimPayment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oClaimPayments As New SyncSoft.SQLDb.ClaimPayments()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "You are about to delete Claim Payment With ClaimNo:" + StringEnteredIn(Me.stbClaimNo, "Claim No!") +
                              ControlChars.NewLine + "Are you sure you want to Delete?"

            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

            oClaimPayments.ClaimNo = StringEnteredIn(Me.stbClaimNo, "Claim No!")

            DisplayMessage(oClaimPayments.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me)
            Me.CallOnKeyEdit()
            Me.GetWaitingPeriodicClaims()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub stbClaimNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbClaimNo.TextChanged
        Me.CallOnKeyEdit()
        Me.ClearControls()
    End Sub

End Class