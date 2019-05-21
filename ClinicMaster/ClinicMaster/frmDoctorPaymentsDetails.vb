
Option Strict On
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports SyncSoft.SQLDb
Imports SyncSoft.Common.Structures
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmDoctorPaymentsDetails

#Region " Fields "

#End Region

Private Sub frmDoctorPaymentsDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.colPayStatus, LookupObjects.PayStatus, False)

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub frmDoctorPaymentsDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub

Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

Dim oDoctorPaymentsDetails As New SyncSoft.SQLDb.DoctorPaymentsDetails()

	Try
		Me.Cursor = Cursors.WaitCursor()

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

		oDoctorPaymentsDetails.PayNo = StringEnteredIn(Me.stbPayNo, "PayNo!")
            'oDoctorPaymentsDetails.VisitNo = StringEnteredIn(Me.stbVisitNo, "VisitNo!")
		oDoctorPaymentsDetails.PayDate = DateEnteredIn(Me.dtpPayDate, "PayDate!")

		DisplayMessage(oDoctorPaymentsDetails.Delete())
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

        'Dim payNo As String
        'Dim visitNo As String
        'Dim payDate As Date

        'Dim oDoctorPaymentsDetails As New SyncSoft.SQLDb.DoctorPaymentsDetails()

        '        'Try
        '        '	Me.Cursor = Cursors.WaitCursor()

        '        '	payNo = StringEnteredIn(Me.stbPayNo, "PayNo!")
        '        '           'visitNo = StringEnteredIn(Me.stbVisitNo, "VisitNo!")
        '        '	payDate = DateEnteredIn(Me.dtpPayDate, "PayDate!")

        '        '	Dim dataSource As DataTable = oDoctorPaymentsDetails.GetDoctorPaymentsDetails(payNo, visitNo, payDate).Tables("DoctorPaymentsDetails")
        '        '	Me.DisplayData(dataSource)

        '        'Catch ex As Exception
        '        '	ErrorMessage(ex)

        '        'Finally
        '        '	Me.Cursor = Cursors.Default()

        '        'End Try

End Sub

Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oDoctorPaymentsDetails As New SyncSoft.SQLDb.DoctorPaymentsDetails()


	Try
		Me.Cursor = Cursors.WaitCursor()


            For rowNo As Integer = 0 To Me.dgvPaymentDetails.RowCount - 2
                Dim cells As DataGridViewCellCollection = Me.dgvPaymentDetails.Rows(rowNo).Cells
                Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode, "item!")
                Dim visitNo As String = StringEnteredIn(cells, Me.ColVisitNo, "Visit No!")
                Dim PayStatusID As String = StringEnteredIn(cells, Me.colPayStatus, "Pay Status!")
                Dim oItemCategoryID As New LookupDataID.ItemCategoryID

                With oDoctorPaymentsDetails

                    .PayNo = StringEnteredIn(Me.stbPayNo, "PayNo!")
                    .VisitNo = visitNo
                    .StaffNo = StringValueEnteredIn(Me.cboStaffNo, "StaffNo!")
                    .ItemCode = itemCode
                    .ItemCategory = oItemCategoryID.Service
                    .PayDate = DateEnteredIn(Me.dtpPayDate, "PayDate!")
                    .PayMode = StringValueEnteredIn(Me.cboPayMode, "PayMode!")
                    .PayStatusID = PayStatusID
                    ' .PercentPaid = Me.nbxPercentPaid.GetInteger()
                    .Amount = Me.nbxAmount.GetDecimal(False)
                    .AmountInWords = StringEnteredIn(Me.stbAmountInWords, "AmountInWords!")
                    .LoginID = CurrentUser.LoginID

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ValidateEntriesIn(Me)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End With
            Next
            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oDoctorPaymentsDetails.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oDoctorPaymentsDetails.Update())
                    Me.CallOnKeyEdit()

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