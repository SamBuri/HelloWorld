
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Imports System.Text
Imports System.Collections.Generic

Public Class frmAttachPackage

#Region " Fields "

    Private oVariousOptions As New VariousOptions()
    Private defaultVisitNo As String = String.Empty
    Private noCallOnKeyEdit As Boolean = False
    Private PackageUnitPrice As Decimal = Nothing
    Private PackageName As String = Nothing

#End Region

Private Sub frmAttachPackage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()
            Me.LoadPackages()

            If Not String.IsNullOrEmpty(defaultVisitNo) Then
                Me.stbVisitNo.Text = FormatText(defaultVisitNo, "Visits", "VisitNo")
                Me.stbVisitNo.ReadOnly = True
                Me.ShowPatientDetails(defaultVisitNo)
                Me.ProcessTabKey(True)
            Else : Me.stbVisitNo.ReadOnly = False
            End If
	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

    End Sub



    Private Sub LoadPackages()

        Dim oPackages As New SyncSoft.SQLDb.Packages()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Packages
            If oVariousOptions.EnablePackages Then
                Dim packageName As DataTable = oPackages.GetPackageName.Tables("Packages")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                LoadComboData(Me.cboPackageName, packageName, "PackageFullName")
                Me.cboPackageName.Items.Insert(0, "")
            Else
                Me.cboPackageName.Enabled = False
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

Private Sub frmAttachPackage_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub

Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

Dim oAttachPackage As New SyncSoft.SQLDb.AttachPackage()

	Try
		Me.Cursor = Cursors.WaitCursor()

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

		oAttachPackage.VisitNo = StringEnteredIn(Me.stbVisitNo, "VisitNo!")
            oAttachPackage.PackageNo = StringEnteredIn(Me.cboPackageName, "PackageNo!")

		DisplayMessage(oAttachPackage.Delete())
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

Dim visitNo As String
Dim packageNo As String

Dim oAttachPackage As New SyncSoft.SQLDb.AttachPackage()

	Try
		Me.Cursor = Cursors.WaitCursor()

		visitNo = StringEnteredIn(Me.stbVisitNo, "VisitNo!")
            packageNo = StringEnteredIn(Me.cboPackageName, "PackageNo!")

		Dim dataSource As DataTable = oAttachPackage.GetAttachPackage(visitNo, packageNo).Tables("AttachPackage")
		Me.DisplayData(dataSource)

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

    Private Sub LoadPackageDetails()
        Try
            Dim Opackages As New SyncSoft.SQLDb.Packages()

            Dim PackageNo As String = RevertText(SubstringEnteredIn(Me.cboPackageName, "Package Name!"))

            Dim packages As DataTable = Opackages.GetPackages(PackageNo).Tables("Packages")

            If packages.Rows.Count < 1 Then Return

            Dim packageRow As DataRow = packages.Rows(0)
            PackageUnitPrice = DecimalMayBeEnteredIn(packageRow, "UnitPrice")
            PackageName = StringMayBeEnteredIn(packageRow, "PackageName")

        

        Catch ex As Exception
            Throw ex
        End Try



    End Sub

Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click
        Dim opackage As New SyncSoft.SQLDb.Items()
        Dim oAttachPackage As New SyncSoft.SQLDb.AttachPackage()
        Dim Opackages As New SyncSoft.SQLDb.Packages()
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim lpackages As New List(Of DBConnect)
        Dim lpackageVisits As New List(Of DBConnect)
        Dim lattachPackage As New List(Of DBConnect)
	Try
            Me.Cursor = Cursors.WaitCursor()

            'Packages check
            Dim oPayStatusID As New LookupDataID.PayStatusID()
            Dim oItemStatusID As New LookupDataID.ItemStatusID()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim PackageNo As String = RevertText(SubstringEnteredIn(Me.cboPackageName, "Package Name!"))
            Dim visitno As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim packages As DataTable = Opackages.GetPackages(PackageNo).Tables("Packages")
            Dim packageRow As DataRow = packages.Rows(0)
            Dim unitPrice As Decimal = DecimalMayBeEnteredIn(packageRow, "UnitPrice")
            Dim PackageName As String = StringMayBeEnteredIn(packageRow, "PackageName")

            With opackage
                .VisitNo = visitno
                .ItemCode = PackageNo
                .Quantity = 1
                .UnitPrice = unitPrice
                .ItemDetails = PackageName
                .LastUpdate = Now()
                .ItemCategoryID = oItemCategoryID.Packages
                .ItemStatusID = oItemStatusID.Pending
                .PayStatusID = oPayStatusID.NotPaid
                .LoginID = CurrentUser.LoginID


            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lpackages.Add(opackage)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            With oAttachPackage

                .VisitNo = visitno
                .PatientNo = RevertText(stbPatientNo.Text)
                .PackageNo = RevertText(SubstringEnteredIn(Me.cboPackageName, "Package Name!"))
                .PackageVisitNo = GetNextPackageVisit()
                .Details = StringEnteredIn(Me.stbDetails, "Details!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)

            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lattachPackage.Add(oAttachPackage)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim opackageVisits As New SyncSoft.SQLDb.PackageVisits()

            With opackageVisits
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .PatientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Visit No!"))
                .PackageNo = RevertText(SubstringEnteredIn(Me.cboPackageName, "Package Name!"))

            End With
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                lpackageVisits.Add(opackageVisits)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

		Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                   
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim message As String = "This action will require the patient to pay for the Package before accessing it " _
                                            + ControlChars.NewLine + "Are you sure you want to attach the Package?"

                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lattachPackage, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lpackages, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lpackageVisits, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    'End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                Case ButtonCaption.Update
                    DisplayMessage(oAttachPackage.Update())
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

    Private Sub btnLoadPeriodicVisits_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadPeriodicVisits.Click
        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicVisits As New frmPeriodicVisits(Me.stbVisitNo)
            fPeriodicVisits.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Me.ShowPatientDetails(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub


    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
          
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbFullName.Clear()
      

    End Sub

    Private Sub btnFindVisitNo_Click(sender As Object, e As EventArgs) Handles btnFindVisitNo.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return

        Me.ShowPatientDetails(visitNo)
    End Sub

    Private Sub stbVisitNo_TextChanged(sender As Object, e As EventArgs) Handles stbVisitNo.TextChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ClearControls()
    End Sub

    Private Sub stbVisitNo_Leave(sender As Object, e As EventArgs) Handles stbVisitNo.Leave
        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Me.ShowPatientDetails(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

   

    'Private Sub cboPackageName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPackageName.SelectedIndexChanged
    '    LoadPackageDetails()
    'End Sub
End Class