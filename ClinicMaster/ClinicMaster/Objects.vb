
Option Strict Off

Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Xml.Linq
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports System.Net
Imports SyncSoft.SQLDb.Lookup
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports System.Security.Cryptography
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects

Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona
Imports SyncSoft.SQLDb
Imports MySql.Data.MySqlClient

Module modClinicMaster

    Friend Function GetNextTranNo(increment As Integer) As String

        Dim yearL2 As String = Today.Year.ToString().Substring(2)

        Try

            Dim oAccounts As New SyncSoft.SQLDb.Accounts()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Accounts", "TranNo").Tables("AutoNumbers")
            Dim paddingLEN As Integer = CInt(autoNumbers.Rows(0).Item("PaddingLEN"))
            Dim paddingCHAR As Char = CChar(autoNumbers.Rows(0).Item("PaddingCHAR"))

            Return (yearL2 + (oAccounts.GetNextTranID + increment).ToString().PadLeft(paddingLEN, paddingCHAR))

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Friend Function GetNextTranNo() As String

        Try
            Return GetNextTranNo(0)

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Friend Function GetNextMessageNo(increment As Integer) As String

        Dim yearL2 As String = Today.Year.ToString().Substring(2)

        Try

            Dim oAccounts As New SyncSoft.SQLDb.BulkMessaging()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("BulkMessaging", "MessageNo").Tables("AutoNumbers")
            Dim paddingLEN As Integer = CInt(autoNumbers.Rows(0).Item("PaddingLEN"))
            Dim paddingCHAR As Char = CChar(autoNumbers.Rows(0).Item("PaddingCHAR"))

            Return (yearL2 + (oAccounts.GetNextMessageID + increment).ToString().PadLeft(paddingLEN, paddingCHAR))

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Friend Function GetNextMessageNo() As String

        Try
            Return GetNextMessageNo(0)

        Catch ex As Exception
            Throw ex

        End Try

    End Function


    Friend Function GetNextPackageVisit(increment As Integer) As String

        Dim yearL2 As String = Today.Year.ToString().Substring(2)

        Try

            Dim oAttachPackage As New SyncSoft.SQLDb.AttachPackage()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("AttachPackage", "PackageVisitNo").Tables("AutoNumbers")
            Dim paddingLEN As Integer = CInt(autoNumbers.Rows(0).Item("PaddingLEN"))
            Dim paddingCHAR As Char = CChar(autoNumbers.Rows(0).Item("PaddingCHAR"))

            Return (yearL2 + (oAttachPackage.GetNextPackageVisitID + increment).ToString().PadLeft(paddingLEN, paddingCHAR))

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Friend Function GetNextPackageVisit() As String

        Try
            Return GetNextPackageVisit(0)

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Friend Function GetExchangeRateBuying(currenciesID As String) As Decimal

        Try

            Cursor.Current = Cursors.WaitCursor

            Dim oExchangeRates As New SyncSoft.SQLDb.ExchangeRates()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim exchangeRates As DataTable = oExchangeRates.GetExchangeRates(currenciesID).Tables("ExchangeRates")
            Dim row As DataRow = exchangeRates.Rows(0)
            Dim buying As Decimal = DecimalMayBeEnteredIn(row, "Buying")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return buying
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return 0

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Friend Function GetIntegrationAgentUserName(AgentID As String) As String

        Try

            Cursor.Current = Cursors.WaitCursor

            Dim oIntegrationAgentID As New SyncSoft.SQLDb.INTAgents()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim integrationAgentID As DataTable = oIntegrationAgentID.GetINTAgents(AgentID).Tables("INTAgents")
            Dim row As DataRow = integrationAgentID.Rows(0)
            Dim username As String = StringMayBeEnteredIn(row, "Username")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return username
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return 0

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Friend Function GetIntegrationAgentPassword(AgentID As String) As String

        Try

            Cursor.Current = Cursors.WaitCursor

            Dim oIntegrationAgentID As New SyncSoft.SQLDb.INTAgents()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim integrationAgentID As DataTable = oIntegrationAgentID.GetINTAgents(AgentID).Tables("INTAgents")
            Dim row As DataRow = integrationAgentID.Rows(0)
            Dim Pass As String = Decrypt(StringMayBeEnteredIn(row, "Password"))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return Pass
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return 0

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Private Function GetExchangedCustomFee(customFee As Decimal, currenciesID As String, unitPrice As Decimal) As Decimal

        Try

            Cursor.Current = Cursors.WaitCursor

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim oExchangeRates As New SyncSoft.SQLDb.ExchangeRates()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then Return customFee

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim exchangeRates As DataTable = oExchangeRates.GetExchangeRates(currenciesID).Tables("ExchangeRates")
            Dim row As DataRow = exchangeRates.Rows(0)
            Dim selling As Decimal = DecimalMayBeEnteredIn(row, "Selling")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If selling > 0 Then
                Return (customFee * selling)
            Else : Return unitPrice
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return unitPrice

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Private Function GetGenderNormalRange(gender As String, fullNormalRange As String) As String

        Dim splitCHAR As Char = ","c
        Dim toUseNormalRange As String = fullNormalRange.Replace(" ", String.Empty).Replace(";", ",").Replace(":", ",")

        If String.IsNullOrEmpty(gender) OrElse String.IsNullOrEmpty(toUseNormalRange) Then Return fullNormalRange
        Dim genderRange() As String = toUseNormalRange.Trim().Split(splitCHAR)
        If Not genderRange.Length = 2 Then Return fullNormalRange

        Try

            For Each range As String In genderRange

                If range.ToUpper().StartsWith(gender.ToUpper() + "(") AndAlso range.ToUpper().EndsWith(")") Then
                    Return range.ToUpper().Replace(gender.ToUpper() + "(", String.Empty).Replace(")", String.Empty)
                ElseIf range.ToUpper().StartsWith(gender.ToUpper().Substring(0, 1) + "(") AndAlso range.ToUpper().EndsWith(")") Then
                    Return range.ToUpper().Replace(gender.ToUpper().Substring(0, 1) + "(", String.Empty).Replace(")", String.Empty)
                End If

            Next

            Return fullNormalRange

        Catch ex As Exception
            Return fullNormalRange

        End Try

    End Function

    Friend Function LabResultNotInNormalRange(resultDataType As String, gender As String, fullNormalRange As String, result As String) As Boolean

        Dim splitCHAR As Char = "-"c

        Try

            Dim oLookupData As New LookupData()
            Dim oDataTypeID As New LookupCommDataID.SearchDataTypeID()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim _Number As String = SubstringLeft(oLookupData.GetLookupDataName(oDataTypeID.Number, LookupCommObjects.SearchDataType)).Trim()
            Dim _Decimal As String = SubstringLeft(oLookupData.GetLookupDataName(oDataTypeID.Decimal, LookupCommObjects.SearchDataType)).Trim()
            Dim _String As String = SubstringLeft(oLookupData.GetLookupDataName(oDataTypeID.String, LookupCommObjects.SearchDataType)).Trim()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim normalRange As String = GetGenderNormalRange(gender, fullNormalRange)
            If String.IsNullOrEmpty(normalRange) OrElse String.IsNullOrEmpty(result) OrElse Not IsNumeric(result) Then Return False
            Dim fullRange() As String = normalRange.Trim().Split(splitCHAR)
            If Not fullRange.Length = 2 Then Return False

            Dim leftValue As String = fullRange(fullRange.GetLowerBound(0)).Trim()
            Dim rightValue As String = fullRange(fullRange.GetUpperBound(0)).Trim()

            Select Case resultDataType

                Case _Number

                    Dim lower As Integer
                    Dim upper As Integer
                    Dim value As Integer

                    If IsNumeric(leftValue) AndAlso Integer.TryParse(leftValue, lower) AndAlso
                    IsNumeric(rightValue) AndAlso Integer.TryParse(rightValue, upper) Then
                        If Integer.TryParse(result, value) Then
                            If value < lower OrElse value > upper Then Return True
                        Else : Return False
                        End If
                    Else : Return False
                    End If

                Case _Decimal

                    Dim lower As Decimal
                    Dim upper As Decimal
                    Dim value As Decimal

                    If IsNumeric(leftValue) AndAlso Decimal.TryParse(leftValue, lower) AndAlso
                    IsNumeric(rightValue) AndAlso Decimal.TryParse(rightValue, upper) Then
                        If Decimal.TryParse(result, value) Then
                            If value < lower OrElse value > upper Then Return True
                        Else : Return False
                        End If
                    Else : Return False
                    End If

                Case Else : Return False

            End Select

            Return False

        Catch ex As Exception
            ErrorMessage(ex)
            Return False

        End Try

    End Function

    Friend Function GetLabResultFlag(resultDataType As String, gender As String, fullNormalRange As String, result As String) As String

        Dim splitCHAR As Char = "-"c
        Dim oLookupData As New LookupData()
        Dim oDataTypeID As New LookupCommDataID.SearchDataTypeID()
        Dim oResultFlagID As New LookupDataID.ResultFlagID()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim _Number As String = SubstringLeft(oLookupData.GetLookupDataName(oDataTypeID.Number, LookupCommObjects.SearchDataType)).Trim()
            Dim _Decimal As String = SubstringLeft(oLookupData.GetLookupDataName(oDataTypeID.Decimal, LookupCommObjects.SearchDataType)).Trim()
            Dim _String As String = SubstringLeft(oLookupData.GetLookupDataName(oDataTypeID.String, LookupCommObjects.SearchDataType)).Trim()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim normalRange As String = GetGenderNormalRange(gender, fullNormalRange)
            If String.IsNullOrEmpty(normalRange) OrElse String.IsNullOrEmpty(result) OrElse Not IsNumeric(result) Then Return oResultFlagID.NA
            Dim fullRange() As String = normalRange.Trim().Split(splitCHAR)
            If Not fullRange.Length = 2 Then Return oResultFlagID.NA

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim leftValue As String = fullRange(fullRange.GetLowerBound(0)).Trim()
            Dim rightValue As String = fullRange(fullRange.GetUpperBound(0)).Trim()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case resultDataType

                Case _Number

                    Dim lower As Integer
                    Dim upper As Integer
                    Dim value As Integer

                    If IsNumeric(leftValue) AndAlso Integer.TryParse(leftValue, lower) AndAlso
                    IsNumeric(rightValue) AndAlso Integer.TryParse(rightValue, upper) Then
                        If Integer.TryParse(result, value) Then

                            If value < lower Then
                                Return oResultFlagID.Low
                            ElseIf value > upper Then
                                Return oResultFlagID.High
                            Else : Return oResultFlagID.Normal
                            End If

                        Else : Return oResultFlagID.NA
                        End If
                    Else : Return oResultFlagID.NA
                    End If

                Case _Decimal

                    Dim lower As Decimal
                    Dim upper As Decimal
                    Dim value As Decimal

                    If IsNumeric(leftValue) AndAlso Decimal.TryParse(leftValue, lower) AndAlso
                    IsNumeric(rightValue) AndAlso Decimal.TryParse(rightValue, upper) Then
                        If Decimal.TryParse(result, value) Then

                            If value < lower Then
                                Return oResultFlagID.Low
                            ElseIf value > upper Then
                                Return oResultFlagID.High
                            Else : Return oResultFlagID.Normal
                            End If

                        Else : Return oResultFlagID.NA
                        End If
                    Else : Return oResultFlagID.NA
                    End If

                Case Else : Return oResultFlagID.NA

            End Select

            Return oResultFlagID.NA

        Catch ex As Exception
            ErrorMessage(ex)
            Return oResultFlagID.NA

        End Try

    End Function

    Friend Function GetProductOwnerInfo() As ProductOwner

        Dim oProductOwner As New ProductOwner()
        Dim oProductOwnerInfo As New SyncSoft.Options.SQL.ProductOwnerInfo()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''Initialize just in case of error'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oProductOwner
                .Address = String.Empty
                .Phone = String.Empty
                .AlternatePhone = String.Empty
                .Fax = String.Empty
                .Email = String.Empty
                .AlternateEmail = String.Empty
                .Website = String.Empty
                .Photo = Nothing
                .AlternatePhoto = Nothing
                .ProductVersion = String.Empty
                .TINNo = String.Empty
                .VATNo = String.Empty
                .PrintHeaderAlignmentID = String.Empty
                .LogoTopMargin = 0
                .TextTopMargin = 0
                .LogoLeftMargin = 0
                .TextLeftMargin = 0
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim productOwner As String = AppData.ProductOwner
            Dim productOwnerInfo As DataTable = oProductOwnerInfo.GetProductOwnerInfo(productOwner).Tables("ProductOwnerInfo")
            Dim ownerInfo As EnumerableRowCollection(Of DataRow) = productOwnerInfo.AsEnumerable()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With oProductOwner
                .Address = (From data In ownerInfo Select data.Field(Of String)("Address")).First()
                .Phone = (From data In ownerInfo Select data.Field(Of String)("Phone")).First()
                .AlternatePhone = (From data In ownerInfo Select data.Field(Of String)("AlternatePhone")).First()
                .Fax = (From data In ownerInfo Select data.Field(Of String)("Fax")).First()
                .Email = (From data In ownerInfo Select data.Field(Of String)("Email")).First()
                .AlternateEmail = (From data In ownerInfo Select data.Field(Of String)("AlternateEmail")).First()
                .Website = (From data In ownerInfo Select data.Field(Of String)("Website")).First()
                .Photo = GetImage((From data In ownerInfo Select data.Field(Of Byte())("Photo")).First())
                .AlternatePhoto = GetImage((From data In ownerInfo Select data.Field(Of Byte())("AlternatePhoto")).First())
                .ProductVersion = (From data In ownerInfo Select data.Field(Of String)("ProductVersion")).First()
                .TINNo = (From data In ownerInfo Select data.Field(Of String)("TINNo")).First()
                .VATNo = (From data In ownerInfo Select data.Field(Of String)("VATNo")).First()
                .PrintHeaderAlignmentID = (From data In ownerInfo Select data.Field(Of String)("PrintHeaderAlignmentID")).First()
                .LogoTopMargin = (From data In ownerInfo Select data.Field(Of Byte)("LogoTopMargin")).First()
                .TextTopMargin = (From data In ownerInfo Select data.Field(Of Byte)("TextTopMargin")).First()
                .LogoLeftMargin = (From data In ownerInfo Select data.Field(Of Byte)("LogoLeftMargin")).First()
                .TextLeftMargin = (From data In ownerInfo Select data.Field(Of Byte)("TextLeftMargin")).First()
            End With
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return oProductOwner

        Catch eX As Exception
            ErrorMessage(eX)
            Return oProductOwner

        End Try

    End Function

    Friend Function PrintPageHeader(e As PrintPageEventArgs, bodyNormalFont As Font, bodyBoldFont As Font, useAlternate As Boolean) As Single

        Try

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
            Dim oProductOwner As ProductOwner = GetProductOwnerInfo()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim photo As Image
            Dim phone As String
            Dim email As String

            If useAlternate AndAlso oProductOwner.AlternatePhoto IsNot Nothing Then
                photo = oProductOwner.AlternatePhoto
            Else : photo = oProductOwner.Photo
            End If

            If useAlternate AndAlso Not String.IsNullOrEmpty(oProductOwner.AlternatePhone) Then
                phone = oProductOwner.AlternatePhone
            Else : phone = oProductOwner.Phone
            End If

            If useAlternate AndAlso Not String.IsNullOrEmpty(oProductOwner.AlternateEmail) Then
                email = oProductOwner.AlternateEmail
            Else : email = oProductOwner.Email
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oPrintHeaderAlignmentID As New LookupCommDataID.PrintHeaderAlignmentID()
            Dim printHeaderAlignmentID As String = oProductOwner.PrintHeaderAlignmentID
            Dim logoTopMargin As Integer = oProductOwner.LogoTopMargin
            Dim textTopMargin As Integer = oProductOwner.TextTopMargin
            Dim logoLeftMargin As Integer = oProductOwner.LogoLeftMargin
            Dim textLeftMargin As Integer = oProductOwner.TextLeftMargin

            Dim xImagePos As Single
            Dim xTextPos As Single

            Dim yImagePos As Single
            Dim yTextPos As Single

            If printHeaderAlignmentID.ToUpper().Equals(oPrintHeaderAlignmentID.LogoTopTextBottom.ToUpper()) Then
                xImagePos = 3 * xPos
                xTextPos = 3 * xPos
                yImagePos = logoTopMargin * CSng(yPos / 10)
                yTextPos = textTopMargin * CSng(yPos / 10)

            ElseIf printHeaderAlignmentID.ToUpper().Equals(oPrintHeaderAlignmentID.LogoLeftTextRight.ToUpper()) Then
                xImagePos = logoLeftMargin * CSng(xPos / 4)
                xTextPos = textLeftMargin * CSng(xPos / 4)
                yImagePos = logoTopMargin * CSng(yPos / 10)
                yTextPos = textTopMargin * CSng(yPos / 10)

            ElseIf printHeaderAlignmentID.ToUpper().Equals(oPrintHeaderAlignmentID.LogoRightTextLeft.ToUpper()) Then
                xImagePos = logoLeftMargin * CSng(xPos / 4)
                xTextPos = textLeftMargin * CSng(xPos / 4)
                yImagePos = logoTopMargin * CSng(yPos / 10)
                yTextPos = textTopMargin * CSng(yPos / 10)

            Else
                xImagePos = 3 * xPos
                xTextPos = 3 * xPos
                yImagePos = logoTopMargin * CSng(yPos / 10)
                yTextPos = textTopMargin * CSng(yPos / 10)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With e.Graphics

                If photo IsNot Nothing Then
                    ' xImagePos = (e.PageBounds.Width - photo.Width) / 2.0F
                    .DrawImage(photo, xImagePos, yImagePos)
                    If printHeaderAlignmentID.ToUpper().Equals(oPrintHeaderAlignmentID.LogoTopTextBottom.ToUpper()) Then
                        yPos += 1.8F * photo.Height / 4.0F
                        yTextPos = yPos

                    ElseIf printHeaderAlignmentID.ToUpper().Equals(oPrintHeaderAlignmentID.LogoLeftTextRight.ToUpper()) Then
                        yPos += 2.0F * photo.Height / 4.0F

                    ElseIf printHeaderAlignmentID.ToUpper().Equals(oPrintHeaderAlignmentID.LogoRightTextLeft.ToUpper()) Then
                        yPos += 2.0F * photo.Height / 4.0F

                    Else : yPos += 2.0F * photo.Height / 4.0F
                    End If
                End If

                If Not String.IsNullOrEmpty(oProductOwner.Address) Then
                    .DrawString(oProductOwner.Address, bodyBoldFont, Brushes.Black, xTextPos, yTextPos)
                    Dim addressLines As Integer = oProductOwner.Address.Split(CChar(ControlChars.NewLine)).Length
                    yTextPos += addressLines * lineHeight
                End If

                If Not String.IsNullOrEmpty(phone) Then
                    .DrawString("Tel: ", bodyNormalFont, Brushes.Black, xTextPos, yTextPos)
                    .DrawString("     " + phone, bodyBoldFont, Brushes.Black, xTextPos, yTextPos)
                    yTextPos += lineHeight
                End If

                If Not String.IsNullOrEmpty(oProductOwner.Fax) Then
                    .DrawString("Fax: ", bodyNormalFont, Brushes.Black, xTextPos, yTextPos)
                    .DrawString("     " + oProductOwner.Fax, bodyBoldFont, Brushes.Black, xTextPos, yTextPos)
                    yTextPos += lineHeight
                End If

                If Not String.IsNullOrEmpty(email) Then
                    .DrawString("Email: ", bodyNormalFont, Brushes.Black, xTextPos, yTextPos)
                    .DrawString("       " + email, bodyBoldFont, Brushes.Black, xTextPos, yTextPos)
                    yTextPos += lineHeight
                End If

                If Not String.IsNullOrEmpty(oProductOwner.Website) Then
                    .DrawString("Website: ", bodyNormalFont, Brushes.Black, xTextPos, yTextPos)
                    .DrawString("         " + oProductOwner.Website, bodyBoldFont, Brushes.Black, xTextPos, yTextPos)
                    yTextPos += lineHeight
                End If

            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If yPos > yTextPos Then
                Return yPos + lineHeight
            Else : Return yTextPos + 2 * lineHeight
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Friend Function PrintPageHeader(e As PrintPageEventArgs, bodyNormalFont As Font, bodyBoldFont As Font) As Single
        Return PrintPageHeader(e, bodyNormalFont, bodyBoldFont, False)
    End Function

    Friend Sub LoadSetupData()

        Try

            Dim oSetupData As New SetupData()

            If InitOptions.LoadBillCustomersAtStart Then oSetupData.LoadBillCustomers()
            If InitOptions.LoadLabTestsAtStart Then oSetupData.LoadLabTests()
            If InitOptions.LoadCardiologyExaminationsAtStart Then oSetupData.LoadCardiologyExaminations()

            If InitOptions.LoadRadiologyExaminationsAtStart Then oSetupData.LoadRadiologyExaminations()
            If InitOptions.LoadDrugsAtStart Then oSetupData.LoadDrugs()
            If InitOptions.LoadConsumableItemsAtStart Then oSetupData.LoadConsumableItems()
            If InitOptions.LoadProceduresAtStart Then oSetupData.LoadProcedures()
            If InitOptions.LoadDentalServicesAtStart Then oSetupData.LoadDentalServices()
            If InitOptions.LoadDiseasesAtStart Then oSetupData.LoadDiseases()
            If InitOptions.LoadTheatreServicesAtStart Then oSetupData.LoadTheatreServices()
            If InitOptions.LoadPatientFingerprintsAtStart Then oSetupData.LoadPatientFingerprints()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Friend Function GetAccountBalance(accountBillModesID As String, accountBillNo As String) As Decimal

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim oAccounts As New SyncSoft.SQLDb.Accounts()
            Return oAccounts.GetAccountBalance(accountBillModesID, accountBillNo)

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Friend Function GetAccountOpeningBalance(accountBillNo As String, accountBillModesID As String, recorddatetime As Date) As Decimal

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim oAccounts As New SyncSoft.SQLDb.Accounts()
            Return oAccounts.GetAccountOpeningBalance(accountBillNo, accountBillModesID, recorddatetime)

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Friend Function ShowUnreadMessageAlerts() As Integer
        Dim unread As DataTable
        Dim oMessenger As New SyncSoft.SQLDb.Messenger

        Try
            Cursor.Current = Cursors.WaitCursor

            unread = oMessenger.GetUnreadMessages(CurrentUser.LoginID).Tables("Messenger")

            Dim alertsNo As Integer = unread.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            frmMessenger.lblUnreadMessageAlerts.Text = "Unread Messages : " + alertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return alertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Friend Function GetServicesSpecialtyBillCustomFee(serviceCode As String, doctorSpecialtyID As String, billNo As String,
                                                      billModesID As String, associatedBillNo As String, unitPrice As Decimal) As Decimal

        Dim accountNo As String
        Dim customFee As Decimal
        Dim servicesSpecialtyBillCustomFee As DataTable
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oServicesSpecialtyBillCustomFee As New SyncSoft.SQLDb.ServicesSpecialtyBillCustomFee()

        Try

            If billModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) AndAlso Not String.IsNullOrEmpty(associatedBillNo) Then
                accountNo = associatedBillNo
            Else : accountNo = billNo
            End If

            If Not String.IsNullOrEmpty(serviceCode) AndAlso Not String.IsNullOrEmpty(doctorSpecialtyID) AndAlso Not String.IsNullOrEmpty(accountNo) Then

                servicesSpecialtyBillCustomFee = oServicesSpecialtyBillCustomFee.GetServicesSpecialtyBillCustomFee(serviceCode, doctorSpecialtyID, accountNo).Tables("ServicesSpecialtyBillCustomFee")

                If servicesSpecialtyBillCustomFee IsNot Nothing AndAlso servicesSpecialtyBillCustomFee.Rows.Count > 0 Then

                    Dim customFeeRow As DataRow = servicesSpecialtyBillCustomFee.Rows(0)
                    Dim currenciesID As String = StringMayBeEnteredIn(customFeeRow, "CurrenciesID")
                    customFee = DecimalMayBeEnteredIn(customFeeRow, "CustomFee")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    customFee = GetExchangedCustomFee(customFee, currenciesID, customFee)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Else

                    Dim billCustomers As DataTable = oBillCustomers.GetBillCustomers(accountNo).Tables("BillCustomers")

                    If billCustomers Is Nothing OrElse billCustomers.Rows.Count < 1 Then Return unitPrice

                    Dim billCustomerRow As DataRow = billCustomers.Rows(0)
                    Dim insuranceNo As String = StringMayBeEnteredIn(billCustomerRow, "InsuranceNo")

                    If String.IsNullOrEmpty(insuranceNo) Then Return unitPrice

                    servicesSpecialtyBillCustomFee = oServicesSpecialtyBillCustomFee.GetServicesSpecialtyBillCustomFee(serviceCode, doctorSpecialtyID, insuranceNo).Tables("ServicesSpecialtyBillCustomFee")

                    If servicesSpecialtyBillCustomFee IsNot Nothing AndAlso servicesSpecialtyBillCustomFee.Rows.Count > 0 Then

                        Dim customFeeRow As DataRow = servicesSpecialtyBillCustomFee.Rows(0)
                        Dim currenciesID As String = StringMayBeEnteredIn(customFeeRow, "CurrenciesID")
                        customFee = DecimalMayBeEnteredIn(customFeeRow, "CustomFee")

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        customFee = GetExchangedCustomFee(customFee, currenciesID, customFee)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Else : customFee = unitPrice
                    End If

                End If

            Else : customFee = unitPrice
            End If

            Return customFee

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Friend Function GetServicesStaffBillCustomFee(serviceCode As String, staffNo As String, billNo As String,
                                                      billModesID As String, associatedBillNo As String, unitPrice As Decimal) As Decimal
        Dim accountNo As String
        Dim customFee As Decimal
        Dim servicesStaffBillCustomFee As DataTable
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oServicesStaffBillCustomFee As New SyncSoft.SQLDb.ServicesStaffBillCustomFee()

        Try

            If billModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) AndAlso Not String.IsNullOrEmpty(associatedBillNo) Then
                accountNo = associatedBillNo
            Else : accountNo = billNo
            End If

            If Not String.IsNullOrEmpty(serviceCode) AndAlso Not String.IsNullOrEmpty(staffNo) AndAlso Not String.IsNullOrEmpty(accountNo) Then

                servicesStaffBillCustomFee = oServicesStaffBillCustomFee.GetServicesStaffBillCustomFee(serviceCode, staffNo, accountNo).Tables("ServicesStaffBillCustomFee")

                If servicesStaffBillCustomFee IsNot Nothing AndAlso servicesStaffBillCustomFee.Rows.Count > 0 Then

                    Dim customFeeRow As DataRow = servicesStaffBillCustomFee.Rows(0)
                    Dim currenciesID As String = StringMayBeEnteredIn(customFeeRow, "CurrenciesID")
                    customFee = DecimalMayBeEnteredIn(customFeeRow, "CustomFee")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    customFee = GetExchangedCustomFee(customFee, currenciesID, customFee)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Else

                    Dim billCustomers As DataTable = oBillCustomers.GetBillCustomers(accountNo).Tables("BillCustomers")

                    If billCustomers Is Nothing OrElse billCustomers.Rows.Count < 1 Then Return unitPrice

                    Dim billCustomerRow As DataRow = billCustomers.Rows(0)
                    Dim insuranceNo As String = StringMayBeEnteredIn(billCustomerRow, "InsuranceNo")

                    If String.IsNullOrEmpty(insuranceNo) Then Return unitPrice

                    servicesStaffBillCustomFee = oServicesStaffBillCustomFee.GetServicesStaffBillCustomFee(serviceCode, staffNo, insuranceNo).Tables("ServicesStaffBillCustomFee")

                    If servicesStaffBillCustomFee IsNot Nothing AndAlso servicesStaffBillCustomFee.Rows.Count > 0 Then

                        Dim customFeeRow As DataRow = servicesStaffBillCustomFee.Rows(0)
                        Dim currenciesID As String = StringMayBeEnteredIn(customFeeRow, "CurrenciesID")
                        customFee = DecimalMayBeEnteredIn(customFeeRow, "CustomFee")

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        customFee = GetExchangedCustomFee(customFee, currenciesID, customFee)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Else : customFee = unitPrice
                    End If

                End If

            Else : customFee = unitPrice
            End If

            Return customFee

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Friend Function GetServicesStaffFee(serviceCode As String, staffNo As String, billNo As String,
                                        billModesID As String, associatedBillNo As String) As Decimal

        Dim staffFee As Decimal

        Try

            Dim oStaff As New SyncSoft.SQLDb.Staff()
            Dim oServicesStaffFee As New SyncSoft.SQLDb.ServicesStaffFee()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim servicesStaffFee As DataTable = oServicesStaffFee.GetServicesStaffFee(serviceCode, staffNo).Tables("ServicesStaffFee")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim staff As DataTable = oStaff.GetStaff(staffNo).Tables("Staff")
            Dim drStaff As EnumerableRowCollection(Of DataRow) = staff.AsEnumerable()
            Dim doctorSpecialtyID As String = (From data In drStaff Select data.Field(Of String)("DoctorSpecialtyID")).First()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If servicesStaffFee IsNot Nothing AndAlso servicesStaffFee.Rows.Count > 0 Then

                Dim staffFeeRow As DataRow = servicesStaffFee.Rows(0)
                Dim currenciesID As String = StringMayBeEnteredIn(staffFeeRow, "CurrenciesID")
                staffFee = DecimalMayBeEnteredIn(staffFeeRow, "StaffFee")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                staffFee = GetExchangedCustomFee(staffFee, currenciesID, staffFee)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else : staffFee = GetServicesDrSpecialtyFee(serviceCode, doctorSpecialtyID, billNo, billModesID, associatedBillNo)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            staffFee = GetServicesSpecialtyBillCustomFee(serviceCode, doctorSpecialtyID, billNo, billModesID, associatedBillNo, staffFee)
            staffFee = GetServicesStaffBillCustomFee(serviceCode, staffNo, billNo, billModesID, associatedBillNo, staffFee)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return staffFee

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Friend Function GetServicesDrSpecialtyFee(serviceCode As String, doctorSpecialtyID As String, billNo As String,
                                              billModesID As String, associatedBillNo As String) As Decimal

        Dim specialtyFee As Decimal
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim oServicesDrSpecialtyFee As New SyncSoft.SQLDb.ServicesDrSpecialtyFee()

            If Not String.IsNullOrEmpty(doctorSpecialtyID) Then

                Dim servicesDrSpecialtyFee As DataTable = oServicesDrSpecialtyFee.GetServicesDrSpecialtyFee(serviceCode, doctorSpecialtyID).Tables("ServicesDrSpecialtyFee")

                If servicesDrSpecialtyFee IsNot Nothing AndAlso servicesDrSpecialtyFee.Rows.Count > 0 Then
                    Dim specialtyFeeRow As DataRow = servicesDrSpecialtyFee.Rows(0)
                    Dim currenciesID As String = StringMayBeEnteredIn(specialtyFeeRow, "CurrenciesID")
                    specialtyFee = DecimalMayBeEnteredIn(specialtyFeeRow, "SpecialtyFee")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    specialtyFee = GetExchangedCustomFee(specialtyFee, currenciesID, specialtyFee)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Else : specialtyFee = GetCustomFee(serviceCode, oItemCategoryID.Service, billNo, billModesID, associatedBillNo)
                End If

            Else : specialtyFee = GetCustomFee(serviceCode, oItemCategoryID.Service, billNo, billModesID, associatedBillNo)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            specialtyFee = GetServicesSpecialtyBillCustomFee(serviceCode, doctorSpecialtyID, billNo, billModesID, associatedBillNo, specialtyFee)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return specialtyFee

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Friend Function GetCustomFee(itemCode As String, itemCategoryID As String, billNo As String,
                                 billModesID As String, associatedBillNo As String) As Decimal

        Dim row As DataRow
        Dim unitPrice As Decimal

        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case itemCategoryID.ToUpper()

                Case oItemCategoryID.Drug.ToUpper()

                    Dim oDrugs As New SyncSoft.SQLDb.Drugs()
                    row = oDrugs.GetDrugs(itemCode).Tables("Drugs").Rows(0)
                    unitPrice = DecimalMayBeEnteredIn(row, "UnitPrice")

                Case oItemCategoryID.Consumable.ToUpper()

                    Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
                    row = oConsumableItems.GetConsumableItems(itemCode).Tables("ConsumableItems").Rows(0)
                    unitPrice = DecimalMayBeEnteredIn(row, "UnitPrice")

                Case oItemCategoryID.Test.ToUpper()

                    Dim oLabTests As New SyncSoft.SQLDb.LabTests()
                    row = oLabTests.GetLabTests(itemCode).Tables("LabTests").Rows(0)
                    unitPrice = DecimalMayBeEnteredIn(row, "TestFee")

                Case oItemCategoryID.Cardiology.ToUpper()

                    Dim oCardiologyExaminations As New SyncSoft.SQLDb.CardiologyExaminations()
                    row = oCardiologyExaminations.GetCardiologyExaminations(itemCode).Tables("CardiologyExaminations").Rows(0)
                    unitPrice = DecimalMayBeEnteredIn(row, "UnitPrice")

                Case oItemCategoryID.Radiology.ToUpper()

                    Dim oRadiologyExaminations As New SyncSoft.SQLDb.RadiologyExaminations()
                    row = oRadiologyExaminations.GetRadiologyExaminations(itemCode).Tables("RadiologyExaminations").Rows(0)
                    unitPrice = DecimalMayBeEnteredIn(row, "UnitPrice")

                Case oItemCategoryID.Pathology.ToUpper()

                    Dim oPathologyExaminations As New SyncSoft.SQLDb.PathologyExaminations()
                    row = oPathologyExaminations.GetPathologyExaminations(itemCode).Tables("PathologyExaminations").Rows(0)
                    unitPrice = DecimalMayBeEnteredIn(row, "UnitPrice")

                Case oItemCategoryID.Service.ToUpper()

                    Dim oServices As New SyncSoft.SQLDb.Services()
                    row = oServices.GetServices(itemCode).Tables("Services").Rows(0)
                    unitPrice = DecimalMayBeEnteredIn(row, "StandardFee")

                Case oItemCategoryID.Procedure.ToUpper()

                    Dim oProcedures As New SyncSoft.SQLDb.Procedures()
                    row = oProcedures.GetProcedures(itemCode).Tables("Procedures").Rows(0)
                    unitPrice = DecimalMayBeEnteredIn(row, "UnitPrice")

                Case oItemCategoryID.Dental.ToUpper()

                    Dim oDentalServices As New SyncSoft.SQLDb.DentalServices()
                    row = oDentalServices.GetDentalServices(itemCode).Tables("DentalServices").Rows(0)
                    unitPrice = DecimalMayBeEnteredIn(row, "UnitPrice")

                Case oItemCategoryID.Theatre.ToUpper()

                    Dim oTheatreServices As New SyncSoft.SQLDb.TheatreServices()
                    row = oTheatreServices.GetTheatreServices(itemCode).Tables("TheatreServices").Rows(0)
                    unitPrice = DecimalMayBeEnteredIn(row, "UnitPrice")

                Case oItemCategoryID.Optical.ToUpper()

                    Dim oOpticalServices As New SyncSoft.SQLDb.OpticalServices()
                    row = oOpticalServices.GetOpticalServices(itemCode).Tables("OpticalServices").Rows(0)
                    unitPrice = DecimalMayBeEnteredIn(row, "UnitPrice")

                Case oItemCategoryID.Maternity.ToUpper()

                    Dim oMaternityServices As New SyncSoft.SQLDb.MaternityServices()
                    row = oMaternityServices.GetMaternityServices(itemCode).Tables("MaternityServices").Rows(0)
                    unitPrice = DecimalMayBeEnteredIn(row, "UnitPrice")

                Case oItemCategoryID.ICU.ToUpper()

                    Dim oICUServices As New SyncSoft.SQLDb.ICUServices()
                    row = oICUServices.GetICUServices(itemCode).Tables("ICUServices").Rows(0)
                    unitPrice = DecimalMayBeEnteredIn(row, "UnitPrice")

                Case oItemCategoryID.Eye.ToUpper()

                    Dim oEyeServices As New SyncSoft.SQLDb.EyeServices()
                    row = oEyeServices.GetEyeServices(itemCode).Tables("EyeServices").Rows(0)
                    unitPrice = DecimalMayBeEnteredIn(row, "UnitPrice")

                Case oItemCategoryID.Admission.ToUpper()

                    Dim oBeds As New SyncSoft.SQLDb.Beds()
                    row = oBeds.GetBeds(itemCode).Tables("Beds").Rows(0)
                    unitPrice = DecimalMayBeEnteredIn(row, "UnitPrice")

                Case oItemCategoryID.Extras.ToUpper()

                    Dim oExtraChargeItems As New SyncSoft.SQLDb.ExtraChargeItems()
                    row = oExtraChargeItems.GetExtraChargeItems(itemCode).Tables("ExtraChargeItems").Rows(0)
                    unitPrice = DecimalMayBeEnteredIn(row, "UnitPrice")

                Case Else : Return unitPrice

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(billNo) Then Return unitPrice

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Try

                Dim customFeeRow As DataRow
                Dim useCustomFee As Boolean
                Dim customFee As Decimal
                Dim currenciesID As String

                Select Case billModesID.ToUpper()

                    Case oBillModesID.Cash.ToUpper()

                        If Not String.IsNullOrEmpty(associatedBillNo) Then

                            Dim oBillCustomFee As New SyncSoft.SQLDb.BillCustomFee()

                            Try

                                Dim billCustomFee As DataTable = oBillCustomFee.GetBillCustomFee(itemCode, itemCategoryID, associatedBillNo).Tables("BillCustomFee")
                                If billCustomFee Is Nothing OrElse billCustomFee.Rows.Count < 1 Then Return GetBillCustomersCustomFee(itemCode, itemCategoryID, billNo, unitPrice)

                                customFeeRow = billCustomFee.Rows(0)
                                useCustomFee = BooleanMayBeEnteredIn(customFeeRow, "UseCustomFee")
                                customFee = DecimalMayBeEnteredIn(customFeeRow, "CustomFee")
                                currenciesID = StringMayBeEnteredIn(customFeeRow, "CurrenciesID")
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                customFee = GetExchangedCustomFee(customFee, currenciesID, unitPrice)
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                            Catch ex As Exception
                                Return GetBillCustomersCustomFee(itemCode, itemCategoryID, billNo, unitPrice)
                            End Try

                        Else : Return GetBillCustomersCustomFee(itemCode, itemCategoryID, billNo, unitPrice)
                        End If

                    Case oBillModesID.Account.ToUpper()

                        Return GetBillCustomersCustomFee(itemCode, itemCategoryID, billNo, unitPrice)

                    Case oBillModesID.Insurance.ToUpper()

                        Dim oInsuranceCustomFee As New SyncSoft.SQLDb.InsuranceCustomFee()
                        Dim insuranceCustomFee As DataTable = oInsuranceCustomFee.GetInsuranceCustomFee(itemCode, itemCategoryID, billNo).Tables("InsuranceCustomFee")
                        If insuranceCustomFee Is Nothing OrElse insuranceCustomFee.Rows.Count < 1 Then Return unitPrice

                        customFeeRow = insuranceCustomFee.Rows(0)
                        useCustomFee = BooleanMayBeEnteredIn(customFeeRow, "UseCustomFee")
                        customFee = DecimalMayBeEnteredIn(customFeeRow, "CustomFee")
                        currenciesID = StringMayBeEnteredIn(customFeeRow, "CurrenciesID")
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        customFee = GetExchangedCustomFee(customFee, currenciesID, unitPrice)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Case Else : Return unitPrice

                End Select

                If useCustomFee Then
                    unitPrice = customFee
                Else : Return unitPrice
                End If

            Catch ex As Exception
                Return unitPrice
            End Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return unitPrice
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function GetBillCustomersCustomFee(itemCode As String, itemCategoryID As String, billNo As String, unitPrice As Decimal) As Decimal

        Dim oBillCustomFee As New SyncSoft.SQLDb.BillCustomFee()

        Try

            Dim billCustomFee As DataTable = oBillCustomFee.GetBillCustomFee(itemCode, itemCategoryID, billNo).Tables("BillCustomFee")
            If billCustomFee Is Nothing OrElse billCustomFee.Rows.Count < 1 Then Return GetBillInsuranceCustomFee(itemCode, itemCategoryID, billNo, unitPrice)

            Dim customFeeRow As DataRow = billCustomFee.Rows(0)
            Dim useCustomFee As Boolean = BooleanMayBeEnteredIn(customFeeRow, "UseCustomFee")
            Dim customFee As Decimal = DecimalMayBeEnteredIn(customFeeRow, "CustomFee")
            Dim currenciesID As String = StringMayBeEnteredIn(customFeeRow, "CurrenciesID")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            customFee = GetExchangedCustomFee(customFee, currenciesID, unitPrice)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If useCustomFee Then
                unitPrice = customFee
            Else : Return unitPrice
            End If

            Return unitPrice

        Catch ex As Exception
            Return GetBillInsuranceCustomFee(itemCode, itemCategoryID, billNo, unitPrice)
        End Try

    End Function

    Private Function GetBillInsuranceCustomFee(itemCode As String, itemCategoryID As String, billNo As String, unitPrice As Decimal) As Decimal

        Try

            Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
            Dim oBillCustomFee As New SyncSoft.SQLDb.BillCustomFee()

            Dim billCustomers As DataTable = oBillCustomers.GetBillCustomers(billNo).Tables("BillCustomers")

            If billCustomers Is Nothing OrElse billCustomers.Rows.Count < 1 Then Return unitPrice

            Dim billCustomerRow As DataRow = billCustomers.Rows(0)
            Dim insuranceNo As String = StringMayBeEnteredIn(billCustomerRow, "InsuranceNo")
            Dim useCustomFee As Boolean = BooleanMayBeEnteredIn(billCustomerRow, "UseCustomFee")

            If String.IsNullOrEmpty(insuranceNo) Then Return unitPrice

            Dim billCustomFee As DataTable = oBillCustomFee.GetBillCustomFee(itemCode, itemCategoryID, insuranceNo).Tables("BillCustomFee")
            If billCustomFee Is Nothing OrElse billCustomFee.Rows.Count < 1 Then Return unitPrice

            Dim customFeeRow As DataRow = billCustomFee.Rows(0)
            Dim customFee As Decimal = DecimalMayBeEnteredIn(customFeeRow, "CustomFee")
            Dim currenciesID As String = StringMayBeEnteredIn(customFeeRow, "CurrenciesID")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            customFee = GetExchangedCustomFee(customFee, currenciesID, unitPrice)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If useCustomFee Then
                unitPrice = customFee
            Else : Return unitPrice
            End If

            Return unitPrice

        Catch ex As Exception
            Return unitPrice
        End Try

    End Function

    Friend Function GetRefillDuration(patientNo As String) As Integer

        Dim refillDuration As Integer
        Dim oARTRegimenDetails As New SyncSoft.SQLDb.ARTRegimenDetails()
        Dim oARTStatusID As New LookupDataID.ARTStatusID()

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim aRTCurrentlyOn As DataTable = oARTRegimenDetails.GetARTCurrentlyOn(patientNo, oARTStatusID.On).Tables("ARTCurrentlyOn")

            If aRTCurrentlyOn.Rows.Count > 0 Then
                refillDuration = CInt(aRTCurrentlyOn.Rows(0).Item("RefillDuration"))
            Else : refillDuration = 0
            End If

            Return refillDuration

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Friend Function IsSchemeMemberActive(medicalCardNo As String) As Boolean

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim message As String
            Dim oStatusID As New LookupCommDataID.StatusID()
            Dim oSchemeMembers As New SyncSoft.SQLDb.SchemeMembers()

            If String.IsNullOrEmpty(medicalCardNo) Then Throw New ArgumentException("Must Enter Medical Card No!")
            Dim row As DataRow = oSchemeMembers.GetSchemeMembers(medicalCardNo).Tables("SchemeMembers").Rows(0)

            Dim memberStatusID As String = StringEnteredIn(row, "MemberStatusID")
            Dim policyStartDate As Date = DateEnteredIn(row, "PolicyStartDate")
            Dim policyEndDate As Date = DateEnteredIn(row, "PolicyEndDate")

            Dim schemeStatusID As String = StringEnteredIn(row, "SchemeStatusID")
            Dim schemeStartDate As Date = DateEnteredIn(row, "SchemeStartDate")
            Dim schemeEndDate As Date = DateEnteredIn(row, "SchemeEndDate")

            If Not memberStatusID.ToUpper().Equals(oStatusID.Active.ToUpper()) Then
                message = "Medical Card No: " + medicalCardNo + ", not active on Insurance Scheme!"
                Throw New ArgumentException(message)
            End If

            If Not schemeStatusID.ToUpper().Equals(oStatusID.Active.ToUpper()) Then
                message = "The Insurance Policy that the Medical Card No: " + medicalCardNo + " belongs to, is not active on insurance scheme!"
                Throw New ArgumentException(message)
            End If

            If policyStartDate > Today Then
                message = "Policy Start Date for Medical Card No: " + medicalCardNo + ", has not yet reached!"
                Throw New ArgumentException(message)
            End If

            If schemeStartDate > Today Then
                message = "Scheme Start Date that the Medical Card No: " + medicalCardNo + " belongs to, has not yet reached!"
                Throw New ArgumentException(message)
            End If

            If policyEndDate < Today Then
                message = "Policy End Date for Medical Card No: " + medicalCardNo + ", has reached!"
                Throw New ArgumentException(message)
            End If

            If schemeEndDate < Today Then
                message = "Scheme End Date that the Medical Card No: " + medicalCardNo + " belongs to, has reached!"
                Throw New ArgumentException(message)
            End If

            Return True

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Friend Function IsBillCustomerActive(accountNo As String) As Boolean

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim message As String
            Dim oStatusID As New LookupCommDataID.StatusID()
            Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
            Dim oBillCustomerTypeID As New LookupDataID.BillCustomerTypeID()

            If String.IsNullOrEmpty(accountNo) Then Return False
            Dim billCustomers As DataTable = oBillCustomers.GetBillCustomers(accountNo).Tables("BillCustomers")

            If billCustomers Is Nothing OrElse billCustomers.Rows.Count < 1 Then Return False

            Dim row As DataRow = billCustomers.Rows(0)
            Dim accountStatusID As String = StringEnteredIn(row, "AccountStatusID")
            Dim billCustomerName As String = StringEnteredIn(row, "BillCustomerName")
            Dim billCustomerTypeID As String = StringEnteredIn(row, "BillCustomerTypeID")

            If Not accountStatusID.ToUpper().Equals(oStatusID.Active.ToUpper()) Then
                If billCustomerTypeID.ToUpper().Equals(oBillCustomerTypeID.Insurance.ToUpper()) Then
                    message = "To-Bill Insurance Name: " + billCustomerName + " with Insurance No: " + accountNo + ", is not active!"
                Else : message = "To-Bill Customer Name: " + billCustomerName + " with Account No: " + accountNo + ", is not active!"
                End If
                Throw New ArgumentException(message)
            End If

            Return True

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Friend Function IsBillCustomerMemberActive(medicalCardNo As String, accountNo As String) As Boolean

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim message As String
            Dim oStatusID As New LookupCommDataID.StatusID()
            Dim oBillCustomerMembers As New SyncSoft.SQLDb.BillCustomerMembers()

            If String.IsNullOrEmpty(medicalCardNo) OrElse String.IsNullOrEmpty(accountNo) Then Return False
            Dim billCustomerMembers As DataTable = oBillCustomerMembers.GetBillCustomerMembers(medicalCardNo, accountNo, True).Tables("BillCustomerMembers")
            If billCustomerMembers Is Nothing OrElse billCustomerMembers.Rows.Count < 1 Then Return False

            Dim row As DataRow = billCustomerMembers.Rows(0)

            Dim memberStatusID As String = StringEnteredIn(row, "MemberStatusID")
            Dim policyStartDate As Date = DateMayBeEnteredIn(row, "PolicyStartDate")
            Dim policyEndDate As Date = DateMayBeEnteredIn(row, "PolicyEndDate")

            If Not memberStatusID.ToUpper().Equals(oStatusID.Active.ToUpper()) Then
                message = "Medical Card No: " + medicalCardNo + ", not active on Scheme!"
                Throw New ArgumentException(message)
            End If

            If (Not policyStartDate = AppData.NullDateValue) AndAlso (policyStartDate > Today) Then
                message = "Policy Start Date for Medical Card No: " + medicalCardNo + ", has not yet reached!"
                Throw New ArgumentException(message)
            End If

            If (Not policyEndDate = AppData.NullDateValue) AndAlso (policyEndDate < Today) Then
                message = "Policy End Date for Medical Card No: " + medicalCardNo + ", has reached!"
                Throw New ArgumentException(message)
            End If

            Return True

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Friend Function IsBillCustomerMemberListed(medicalCardNo As String, accountNo As String) As Boolean

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim oBillCustomerMembers As New SyncSoft.SQLDb.BillCustomerMembers()

            If String.IsNullOrEmpty(medicalCardNo) OrElse String.IsNullOrEmpty(accountNo) Then Return False
            Dim billCustomerMembers As DataTable = oBillCustomerMembers.GetBillCustomerMembers(medicalCardNo, accountNo, True).Tables("BillCustomerMembers")

            If billCustomerMembers Is Nothing OrElse billCustomerMembers.Rows.Count < 1 Then
                Dim message As String = "Account No: " + accountNo + ", requires all members to be registered first. " + ControlChars.NewLine +
                                        "Patient with Medical Card No: " + medicalCardNo + ", is not a registered member"
                Throw New ArgumentException(message)
            End If

            Return True

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Friend Function ValidateBillCustomerInsuranceDirect(accountNo As String) As Boolean

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim message As String
            Dim oVariousOptions As New VariousOptions()
            Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
            Dim oBillCustomerTypeID As New LookupDataID.BillCustomerTypeID()

            If String.IsNullOrEmpty(accountNo) Then Return False
            Dim billCustomers As DataTable = oBillCustomers.GetBillCustomers(accountNo).Tables("BillCustomers")

            If billCustomers Is Nothing OrElse billCustomers.Rows.Count < 1 Then Return False

            Dim row As DataRow = billCustomers.Rows(0)
            Dim billCustomerName As String = StringEnteredIn(row, "BillCustomerName")
            Dim billCustomerTypeID As String = StringEnteredIn(row, "BillCustomerTypeID")

            If billCustomerTypeID.ToUpper().Equals(oBillCustomerTypeID.Insurance.ToUpper()) Then
                If oVariousOptions.AllowInsuranceDirectLinkedMember Then
                    message = "To-Bill Customer Name: " + billCustomerName + " with Account No: " + accountNo + ", is set as an insurance company. " +
                    ControlChars.NewLine + "It’s recommended that you link patients to companies that are in turn linked to this insurance. " +
                    ControlChars.NewLine + "Are you sure you want to continue?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                Else
                    message = "To-Bill Customer Name: " + billCustomerName + " with Account No: " + accountNo + ", is set as an insurance company. " +
                    ControlChars.NewLine + "It’s recommended that you link patients to companies that are in turn linked to this insurance. " +
                    ControlChars.NewLine + "The system is set not to allow processing such a record. " +
                                            "Please contact the administrator if you still need to continue this way."
                    Throw New ArgumentException(message)
                End If
            End If

            Return True

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Friend Function GetNextClaimNo(medicalCardNo As String) As String

        Try

            Dim oClaims As New SyncSoft.SQLDb.Claims()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Claims", "ClaimNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim claimID As String = oClaims.GetNextClaimID(medicalCardNo).ToString()
            claimID = claimID.PadLeft(paddingLEN, paddingCHAR)

            Return medicalCardNo + claimID.Trim()

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Friend Function GetHealthUnitsHealthUnitCode(healthUnitName As String) As String

        Try

            Dim oHealthUnits As New SyncSoft.SQLDb.HealthUnits()
            Return oHealthUnits.GetHealthUnitsHealthUnitCode(healthUnitName)

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Friend Function GetHealthUnitsHealthUnitCode() As String
        Return GetHealthUnitsHealthUnitCode(AppData.ProductOwner)
    End Function

    Friend Function GetBillCustomersInfo(accountNo As String) As BillCustomers

        Dim oBillCustomers As New BillCustomers()
        Dim oBillCustomersInfo As New SyncSoft.SQLDb.BillCustomers()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''' Initialize just in case of error ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oBillCustomers
                .BillCustomerName = String.Empty
                .Address = String.Empty
                .Phone = String.Empty
                .Fax = String.Empty
                .Email = String.Empty
                .Website = String.Empty
                .LogoPhoto = Nothing
                .MemberDeclaration = String.Empty
                .DoctorDeclaration = String.Empty
            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim billCustomersInfo As DataTable = oBillCustomersInfo.GetBillCustomers(accountNo).Tables("BillCustomers")
            Dim rowsInfo As EnumerableRowCollection(Of DataRow) = billCustomersInfo.AsEnumerable()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With oBillCustomers
                .BillCustomerName = (From data In rowsInfo Select data.Field(Of String)("BillCustomerName")).First()
                .Address = (From data In rowsInfo Select data.Field(Of String)("Address")).First()
                .Phone = (From data In rowsInfo Select data.Field(Of String)("Phone")).First()
                .Fax = (From data In rowsInfo Select data.Field(Of String)("Fax")).First()
                .Email = (From data In rowsInfo Select data.Field(Of String)("Email")).First()
                .Website = (From data In rowsInfo Select data.Field(Of String)("Website")).First()
                .LogoPhoto = GetImage((From data In rowsInfo Select data.Field(Of Byte())("LogoPhoto")).First())
                .MemberDeclaration = (From data In rowsInfo Select data.Field(Of String)("MemberDeclaration")).First()
                .DoctorDeclaration = (From data In rowsInfo Select data.Field(Of String)("DoctorDeclaration")).First()
            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return oBillCustomers

        Catch eX As Exception
            ErrorMessage(eX)
            Return oBillCustomers

        End Try

    End Function

    Friend Function GetInsurancesInfo(insuranceNo As String) As Insurances

        Dim oInsurances As New Insurances()
        Dim oInsurancesInfo As New SyncSoft.SQLDb.Insurances()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''' Initialize just in case of error ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oInsurances
                .InsuranceName = String.Empty
                .Address = String.Empty
                .Phone = String.Empty
                .Fax = String.Empty
                .Email = String.Empty
                .Website = String.Empty
                .LogoPhoto = Nothing
                .MemberDeclaration = String.Empty
                .DoctorDeclaration = String.Empty
            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim insurancesInfo As DataTable = oInsurancesInfo.GetInsurances(insuranceNo).Tables("Insurances")
            Dim rowsInfo As EnumerableRowCollection(Of DataRow) = insurancesInfo.AsEnumerable()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With oInsurances
                .InsuranceName = (From data In rowsInfo Select data.Field(Of String)("InsuranceName")).First()
                .Address = (From data In rowsInfo Select data.Field(Of String)("Address")).First()
                .Phone = (From data In rowsInfo Select data.Field(Of String)("Phone")).First()
                .Fax = (From data In rowsInfo Select data.Field(Of String)("Fax")).First()
                .Email = (From data In rowsInfo Select data.Field(Of String)("Email")).First()
                .Website = (From data In rowsInfo Select data.Field(Of String)("Website")).First()
                .LogoPhoto = GetImage((From data In rowsInfo Select data.Field(Of Byte())("LogoPhoto")).First())
                .MemberDeclaration = (From data In rowsInfo Select data.Field(Of String)("MemberDeclaration")).First()
                .DoctorDeclaration = (From data In rowsInfo Select data.Field(Of String)("DoctorDeclaration")).First()
            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return oInsurances

        Catch eX As Exception
            ErrorMessage(eX)
            Return oInsurances

        End Try

    End Function

    Friend Function GetAvailableStock(drugNo As String) As Integer

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim oInventory As New SyncSoft.SQLDb.Inventory()
            Return oInventory.GetAvailableStock(drugNo)

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Friend Function GetAvailableToPayForDrugs(drugNo As String) As Integer

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim oInventory As New SyncSoft.SQLDb.Inventory()
            Return oInventory.GetAvailableToPayForDrugs(drugNo)

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function


    Friend Function GetStaffCurrentBranch(loginID As String) As String

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim oStaffLocations As New SyncSoft.SQLDb.StaffLocations()
            Return oStaffLocations.GetStaffLocations(loginID)


        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Friend Function GetInventoryBalance(locationID As String, itemCategoryID As String, itemCode As String) As Integer

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim oInventory As New SyncSoft.SQLDb.Inventory()
            Return oInventory.GetInventoryBalance(locationID, itemCategoryID, itemCode)

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Friend Function GetInventoryBalance(itemCategoryID As String, itemCode As String) As Integer

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim oInventory As New SyncSoft.SQLDb.Inventory()
            Return oInventory.GetInventoryBalance(itemCategoryID, itemCode)

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Friend Function GetVisitFingerprints() As DataTable

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Cursor.Current = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Load from VisitFingerprints
            Dim visitFingerprints As DataTable = oVisits.GetVisitFingerprints.Tables("Visits")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If visitFingerprints Is Nothing OrElse visitFingerprints.Rows.Count < 1 Then
                Throw New ArgumentException("No recently registered visit(s) with captured fingerprint found!")
            End If

            Return visitFingerprints
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Friend Sub ShowAlternateDrugs(drugNo As String)
        Dim fAlternateDrugs As New frmAlternateDrugs(drugNo)
        fAlternateDrugs.ShowDialog()
    End Sub


    Friend Function GetForwardedCardData(patientNo As String, macAddress As String) As SmartCardMembers

        Dim oSmartCardMembers As New SmartCardMembers()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            patientNo = RevertText(patientNo)
            Dim document As XDocument = New XDocument()
            Dim smartDataTable As DataTable = GetSmartFileTable(patientNo, macAddress)
            If smartDataTable.Rows.Count() > 0 Then
                Dim row As DataRow = smartDataTable.Rows(0)
                With oSmartCardMembers
                    .MemberNr = StringEnteredIn(row, "Member_Nr")
                    .AdmitID = StringEnteredIn(row, "Admit_ID")
                    .GlobalID = StringEnteredIn(row, "Global_ID")
                    .LocationID = StringEnteredIn(row, "Location_ID")
                    .Id = IntegerEnteredIn(row, "ID")
                    .SmartDate = DateEnteredIn(row, "Smart_Date")
                    .PracticeNo = StringEnteredIn(row, "SP_ID")
                    Dim byteArray As Byte() = CType(row("Smart_File"), Byte())
                    Dim memoryStream As New MemoryStream(byteArray)
                    document = XDocument.Load(memoryStream)
                End With
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim card_serialnumber As XElement = document.Root.Element("A1").Element("card_serialnumber")
            oSmartCardMembers.CardSerialNumber = card_serialnumber.Value.ToString()

            Dim firstName As XElement = document.Root.Element("A2").Element("patient_forenames")
            Dim surname As XElement = document.Root.Element("A2").Element("patient_surname")
            Dim birthDate As XElement = document.Root.Element("A2").Element("patient_dob")

            With oSmartCardMembers
                .FirstName = firstName.Value.ToString()
                .Surname = surname.Value.ToString()
                .BirthDate = CDate(birthDate.Value)
            End With

            Dim schemeExpiryDate As XElement = document.Root.Element("B1").Element("medicalaid_expiry")
            Dim medicalCardNumber As XElement = document.Root.Element("B1").Element("medicalaid_number")
            Dim schemeCode As XElement = document.Root.Element("B1").Element("medicalaid_code")
            Dim schemePlan As XElement = document.Root.Element("B1").Element("medicalaid_plan")

            With oSmartCardMembers
                .SchemeExpiryDate = CDate(schemeExpiryDate.Value)
                .MedicalCardNumber = medicalCardNumber.Value.ToString()
                .SchemeCode = schemeCode
                .SchemePlan = schemePlan
            End With

            Dim nr As XElement = document.Root.Element("Benefits").Element("Benefit").Element("Nr")
            Dim description As XElement = document.Root.Element("Benefits").Element("Benefit").Element("Description")
            Dim amount As XElement = document.Root.Element("Benefits").Element("Benefit").Element("Amount")

            With oSmartCardMembers
                .CoverNumber = nr.Value.ToString()
                .ServiceDescription = description.Value.ToString()
                .CoverAmount = CDec(amount.Value)
            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return oSmartCardMembers
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch XMLex As XmlException
            Throw XMLex

        Catch ex As Exception
            Throw ex

        End Try

    End Function


    Friend Function ProcessSmartCardData(patientNo As String) As SmartCardMembers

        Try

            Dim count As Integer = 0
            Dim oVariousOptions As New VariousOptions()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "This patient is expected to be carrying a smart card. Be sure that the patient has one and available for smart system processing " +
                        ControlChars.NewLine + "Are you sure you want to continue?"
            If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim conAttempMSG As String = "You have reached the set maximum smart system connection attempts without forwarded details. " +
                  ControlChars.NewLine + "Are you sure you want to continue?"

            message = "Please request for smart card from the member and forward details from smart system"
            DisplayMessage(message)

            patientNo = RevertText(patientNo)

            Dim macAddress As String = GetMacAddress()

            Do Until GetSmartFileTable(patientNo, macAddress).Rows.Count > 0
                DisplayMessage(message)
                If oVariousOptions.SmartCardConnectionAttemptNo > 0 AndAlso count >= oVariousOptions.SmartCardConnectionAttemptNo Then
                    If WarningMessage(conAttempMSG) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                End If
                count += 1
            Loop

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return GetForwardedCardData(patientNo, macAddress)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Friend Function GetEncounterType(itemCategoryID As String) As String
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        If itemCategoryID.ToUpper.Equals(oItemCategoryID.Procedure.ToUpper) OrElse
         itemCategoryID.ToUpper.Equals(oItemCategoryID.Theatre.ToUpper) OrElse itemCategoryID.ToUpper.Equals(oItemCategoryID.Pathology.ToUpper) Then
            Return "Procedure"
        ElseIf itemCategoryID.ToUpper.Equals(oItemCategoryID.Test.ToUpper) Then
            Return "Laboratory"
        ElseIf itemCategoryID.ToUpper.Equals(oItemCategoryID.Consumable.ToUpper) OrElse itemCategoryID.ToUpper.Equals(oItemCategoryID.Drug.ToUpper) Then
            Return "Medication"
        Else : Return "Others"
        End If

    End Function


    Friend Function UpdateSmartExchangeFiles(smartCardMembers As SmartCardMembers, smartCardItems As List(Of SmartCardItems), visitNo As String, visitTypeTypeID As String) As Boolean

        Dim OVariousOptions As New VariousOptions()
        Dim oGenderItemcategoryID As New LookupDataID.GenderID()
        Dim oVisitTypeID As New LookupDataID.VisitTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim smartGender As String
        Dim copay As Integer
        visitNo = RevertText(visitNo)
        Dim diagnosis As New DataTable
        Dim oDiagnosis As New Diagnosis()
        Dim oIPDDiagnosis As New IPDDiagnosis()
        Try
            If visitTypeTypeID.ToUpper().Equals(oVisitTypeID.OutPatient().ToUpper()) Then
                diagnosis = oDiagnosis.GetDiagnosis(visitNo).Tables("Diagnosis")
            Else
                diagnosis = oIPDDiagnosis.GetAdmissionDiagnosis(visitNo).Tables("IPDDiagnosis")
            End If

        Catch ex As Exception

        End Try


        If Not smartCardMembers.CopayType.ToString().Equals(oCoPayTypeID.NA()) Then
            copay = 1
        Else
            copay = 0
        End If

        If smartCardMembers.Gender.ToString().Equals(oGenderItemcategoryID.Male()) Then
            smartGender = "M"

        ElseIf smartCardMembers.Gender.ToString().Equals(oGenderItemcategoryID.Female()) Then
            smartGender = "F"
        Else
            smartGender = "U"
        End If

        'Dim encoding As New UnicodeEncoding()

        Dim memoryStream As New MemoryStream
        Dim XMLWriter As New XmlTextWriter(memoryStream, System.Text.Encoding.UTF8)

        '

        Try
            With XMLWriter
                .Formatting = Formatting.Indented
                .Indentation = 3
                .WriteStartDocument()
                .WriteStartElement("Claim")

                .WriteStartElement("Claim_Header") '' Begin Claim Header

                .WriteElementString("Invoice_Number", smartCardMembers.InvoiceNo)
                .WriteElementString("Claim_Date", FormatDate(smartCardMembers.SmartDate, "yyyy-MM-dd"))
                .WriteElementString("Claim_Time", GetTime(Now))
                .WriteElementString("Pool_Number", smartCardMembers.CoverNumber)
                .WriteElementString("Total_Services", smartCardMembers.TotalServices)
                .WriteElementString("Gross_Amount", smartCardMembers.TotalBill)


                .WriteStartElement("Provider") '' Begin Provider

                .WriteElementString("Role", "SP")
                .WriteElementString("Country_Code", "UG")
                .WriteElementString("Group_Practice_Number", smartCardMembers.PracticeNo)
                .WriteElementString("Group_Practice_Name", AppData.ProductOwner)

                .WriteEndElement() '' End Provider

                .WriteStartElement("Authorization") '' Begin Authorization

                .WriteElementString("Pre_Authorization_Number", smartCardMembers.PreAuthorizationNo)
                .WriteElementString("Pre_Authorization_Amount", smartCardMembers.PreAuthorizationAmount)

                .WriteEndElement() '' End Authorization

                .WriteStartElement("Payment_Modifiers") '' Begin Payment Modifiers
                .WriteStartElement("Payment_Modifier")
                .WriteElementString("Type", copay)
                .WriteElementString("Amount", smartCardMembers.CopayAmount)
                .WriteElementString("Receipt", smartCardMembers.InvoiceNo)
                .WriteEndElement()
                .WriteEndElement() '' End Payment Modifiers
                .WriteEndElement() '' End Claim Header

                .WriteStartElement("Member") '' Begin member

                .WriteElementString("Membership_Number", smartCardMembers.MedicalCardNumber)
                .WriteElementString("Card_serialnumber", smartCardMembers.CardSerialNumber)
                .WriteElementString("Scheme_Code", smartCardMembers.SchemeCode)
                .WriteElementString("Scheme_Plan", smartCardMembers.SchemePlan)


                .WriteEndElement() '' End member

                .WriteStartElement("Patient") '' Begin Patient

                .WriteElementString("Dependant", "N")
                .WriteElementString("First_Name", smartCardMembers.FirstName)
                .WriteElementString("Middle_Name", smartCardMembers.MiddleName)
                .WriteElementString("Surname", smartCardMembers.Surname)
                .WriteElementString("Date_Of_Birth", FormatDate(smartCardMembers.BirthDate, "yyyy-MM-dd"))
                .WriteElementString("Gender", smartGender)
                .WriteEndElement() '' End Patient
            End With


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With XMLWriter


                .WriteStartElement("Claim_Data") ''Begin Claim Lines
                For Each item As SmartCardItems In smartCardItems
                    .WriteStartElement("Service")
                    .WriteElementString("number", 1)
                    .WriteElementString("Invoice_number", smartCardMembers.InvoiceNo)
                    .WriteElementString("Global_Invoice_Nr", 0)
                    .WriteElementString("Start_Date", item.TransactionDate)
                    .WriteElementString("Start_Time", item.TransactionTime)
                    .WriteStartElement("Provider")
                    .WriteElementString("Role", "SP")
                    .WriteElementString("Practice_Number", smartCardMembers.PracticeNo)
                    .WriteEndElement()

                    If diagnosis.Rows.Count > 0 Then
                        For Each row As DataRow In diagnosis.Rows
                            Dim diseaseCode As String = StringEnteredIn(row, "DiseaseCode")
                            Dim diseaseName As String = StringEnteredIn(row, "DiseaseName")

                            .WriteStartElement("Diagnosis")
                            .WriteElementString("Stage", "P")
                            .WriteElementString("Code", diseaseCode)
                            .WriteElementString("Code_Type", diseaseName)
                            .WriteEndElement()

                        Next
                    Else
                        Dim oVisits As New Visits()
                        Dim visits As New DataTable
                        Dim provisionalDiagnosis As String = String.Empty
                        Try
                            visits = oVisits.GetVisits(visitNo).Tables("Visits")
                        Catch ex As Exception

                        End Try


                        If visits.Rows.Count > 0 Then
                            Dim row As DataRow = visits.Rows(0)
                            provisionalDiagnosis = StringMayBeEnteredIn(row, "ProvisionalDiagnosis")
                        End If

                        .WriteStartElement("Diagnosis")
                        .WriteElementString("Stage", "P")
                        .WriteElementString("Code", String.Empty)
                        .WriteElementString("Code_Type", provisionalDiagnosis)
                        .WriteEndElement()

                    End If


                    .WriteElementString("Encounter_Type", item.EncounterType)
                    .WriteElementString("Code_Type", item.CodeType)
                    .WriteElementString("Code", item.Code)
                    .WriteElementString("Code_Description", item.CodeDescription)
                    .WriteElementString("Quantity", item.Quantity)
                    .WriteElementString("Total_Amount", item.Amount)
                    .WriteStartElement("Reason")
                    .WriteEndElement()

                    .WriteEndElement()


                Next

                .WriteEndElement() '' End Claim Lines
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            XMLWriter.WriteEndElement() '' End Claim
            XMLWriter.Flush()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Dim reader As StreamReader = New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)
            Dim contents As String = reader.ReadToEnd
            Dim fileContents As String = smartCardMembers.CardSerialNumber + smartCardMembers.InvoiceNo
            If EditSmartData(smartCardMembers.Id, contents) Then

                DisplayMessage("File Saved Succesfully. Please Retrieve in Smart ")

                Dim count As Integer
                Dim message As String = "Please make sure that the been retrived"
                Dim conAttempMSG As String = "You have reached the set maximum smart system connection attempts without forwarded details. " +
                ControlChars.NewLine + "Are you sure you want to continue?"

                Dim resultFlag As Integer = GetSmartResultFlag(smartCardMembers.Id)

                If resultFlag = 2 Then

                    Do Until (GetSmartResultFlag(smartCardMembers.Id) = 4 OrElse GetSmartResultFlag(smartCardMembers.Id) = 3)
                        DisplayMessage(message)
                        If OVariousOptions.SmartCardConnectionAttemptNo > 0 AndAlso count >= OVariousOptions.SmartCardConnectionAttemptNo Then
                            If WarningMessage(conAttempMSG) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                        End If
                        count += 1


                    Loop
                    resultFlag = GetSmartResultFlag(smartCardMembers.Id)
                    If resultFlag = 3 Then
                        DisplayMessage("An error occured while processing smart request. Please try again")
                        Return False
                    ElseIf resultFlag = 4 Then

                        Return UpdateResultFile(smartCardMembers.Id, fileContents)

                    End If


                ElseIf resultFlag = 3 Then
                    DisplayMessage("An error occured while processing smart request. Please try again")
                    Return False
                ElseIf resultFlag = 4 Then

                    Return UpdateResultFile(smartCardMembers.Id, fileContents)

                End If
                Return False
            Else
                DisplayMessage("Error Processing on Smart")
                Return False
            End If

        Catch XMLex As XmlException
            Throw XMLex

        Catch ex As Exception
            Throw ex

        Finally
            XMLWriter.Close()

        End Try

    End Function

    Public Function GetMacAddress() As String
        Dim nics() As Net.NetworkInformation.NetworkInterface = NetworkInformation.NetworkInterface.GetAllNetworkInterfaces
        For Each nic As Net.NetworkInformation.NetworkInterface In nics
            If nic.OperationalStatus.Equals(NetworkInformation.OperationalStatus.Up) Then
                Return nic.GetPhysicalAddress().ToString
            End If

        Next
        Return String.Empty
    End Function

    Public Function UpdateResultFile(id As Integer, fileContents As String) As Boolean
        Try
            Dim oIntegrationAgent As New LookupDataID.IntegrationAgents()
            Dim oMysqlConnect As New MySqlConnect(oIntegrationAgent.SMART)
            Dim pairs As New List(Of KeyValuePair(Of String, Object))
            pairs.Add(New KeyValuePair(Of String, Object)("_id", id))
            pairs.Add(New KeyValuePair(Of String, Object)("resultFile", fileContents))
            pairs.Add(New KeyValuePair(Of String, Object)("resultDate", Today))

            Dim storedProcedureName As String = "uspUpdateResultFile"
            Return oMysqlConnect.EditData(storedProcedureName, pairs)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetSmartResultFlag(_ID As Integer) As Integer
        Dim progressFlag As Integer
        Try
            Dim smartTable As DataTable = GetSmartFileTableByID(_ID)
            If smartTable.Rows.Count > 0 Then
                Dim row As DataRow = smartTable.Rows(0)
                progressFlag = IntegerEnteredIn(row, "Progress_Flag")
            End If

            Return progressFlag
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Gets full age string with no years if exclude years is set to true
    ''' </summary>
    ''' <param name="birthDate"></param>
    ''' <param name="excludeYears"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetAgeString(birthDate As Date, excludeYears As Boolean) As String

        Try

            Dim oVariousOptions As New VariousOptions()

            Dim age As Integer = Today.Year - birthDate.Year
            Dim months As Integer = Today.Month - birthDate.Month
            Dim days As Integer = Today.Day - birthDate.Day

            If Math.Sign(days) = -1 Then
                days = 30 - Math.Abs(days)
                months = months - 1
            End If

            If Math.Sign(months) = -1 Then
                months = 12 - Math.Abs(months)
                age = age - 1
            End If

            If (age < oVariousOptions.IncludeMonthsForAgesBelow) Then

                If excludeYears Then
                    If months < 1 Then
                        If days <= 1 Then
                            Return "(" + days.ToString() + " Day)"
                        Else : Return "(" + days.ToString() + " Days)"
                        End If
                    ElseIf months = 1 Then
                        Return "(" + months.ToString() + " Month)"
                    Else : Return "(" + months.ToString() + " Months)"
                    End If
                Else
                    If months < 1 Then
                        If days <= 1 Then
                            Return age.ToString() + " (" + days.ToString() + " Day)"
                        Else : Return age.ToString() + " (" + days.ToString() + " Days)"
                        End If
                    ElseIf months = 1 Then
                        Return age.ToString() + " (" + months.ToString() + " Month)"
                    Else : Return age.ToString() + " (" + months.ToString() + " Months)"
                    End If
                End If

            Else
                If excludeYears Then
                    Return String.Empty
                Else : Return age.ToString()
                End If
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    ''' <summary>
    ''' Gets full age string
    ''' </summary>
    ''' <param name="birthDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetAgeString(birthDate As Date) As String
        Return GetAgeString(birthDate, False)
    End Function

    Friend Function GetNextExtraBillNo(visitNo As String, patientNo As String) As String

        Try

            Dim oExtraBills As New SyncSoft.SQLDb.ExtraBills()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("ExtraBills", "ExtraBillNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim extraBillID As String = oExtraBills.GetNextExtraBillID(visitNo).ToString()
            extraBillID = extraBillID.PadLeft(paddingLEN, paddingCHAR)

            Return patientNo + extraBillID.Trim()

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    ''' <summary>
    ''' Gets patient fingerprint for supplied patient no
    ''' </summary>
    ''' <param name="patientNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetPatientFingerprints(patientNo As String) As DataTable

        Dim patientFingerprints As New DataTable()
        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oSetupData As New SetupData()

        Try

            Cursor.Current = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(patientNo) Then
                If Not InitOptions.LoadPatientFingerprintsAtStart Then
                    ' Load from PatientFingerprints
                    patientFingerprints = oPatients.GetPatientFingerprints().Tables("Patients")
                    oSetupData.PatientFingerprints = patientFingerprints
                Else : patientFingerprints = oSetupData.PatientFingerprints
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If patientFingerprints Is Nothing OrElse patientFingerprints.Rows.Count < 1 Then
                    Throw New ArgumentException("No patient(s) with captured fingerprint found!")
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else
                patientFingerprints = oPatients.GetPatientFingerprints(patientNo).Tables("Patients")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If patientFingerprints Is Nothing OrElse patientFingerprints.Rows.Count < 1 Then
                    Throw New ArgumentException("Patient No: " + patientNo + ", has no captured fingerprint!")
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return patientFingerprints
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    ''' <summary>
    ''' Gets patient fingerprints
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetPatientFingerprints() As DataTable
        Return GetPatientFingerprints(String.Empty)
    End Function

    Friend Function GetLabResultsFingerprints(patientNo As String) As DataTable

        Dim patientFingerprints As New DataTable()
        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oSetupData As New SetupData()

        Try

            Cursor.Current = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(patientNo) Then

                patientFingerprints = oPatients.GetLabResultsFingerprints().Tables("LabResults")

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If patientFingerprints Is Nothing OrElse patientFingerprints.Rows.Count < 1 Then
                Throw New ArgumentException("No patient(s) with captured fingerprint found!")
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return patientFingerprints
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    ''' <summary>
    ''' Gets patient fingerprints
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetLabResultsFingerprints() As DataTable
        Return GetLabResultsFingerprints(String.Empty)
    End Function

    Friend Function IsInsuranceFingerprintVerified(patientNo As String) As Boolean

        Dim oCrossMatchTemplate As New CrossMatchFingerTemplate()
        Dim oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()
        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim message As String
            Dim patientFingerprints As DataTable

            If String.IsNullOrEmpty(patientNo) OrElse Not oVariousOptions.ForceInsuranceFingerprintVerification Then Return False

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Try

                patientFingerprints = GetPatientFingerprints(patientNo)

            Catch ex As Exception
                Throw New ArgumentException(ex.Message + ControlChars.NewLine + "The system is set not to process insurance patient with no captured fingerprint.")
            End Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            message = "Fingerprints for insurance Patient No: " + patientNo + ", do not match. You can't process this record!"

            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then

                Dim fFingerprintCapture As New FingerprintCapture(CaptureType.Verify, patientFingerprints, "PatientNo")
                fFingerprintCapture.ShowDialog()

                If oCrossMatchTemplate.Fingerprint Is Nothing OrElse String.IsNullOrEmpty(oCrossMatchTemplate.ID) Then
                    Throw New ArgumentException(message)
                Else : Return True
                End If

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then

                Dim fVerification As New Verification(patientFingerprints, "PatientNo")
                fVerification.ShowDialog()

                If String.IsNullOrEmpty(oDigitalPersonaTemplate.ID) Then
                    Throw New ArgumentException(message)
                Else : Return True
                End If

            End If

            Return True

        Catch ex As Exception
            Throw ex

        Finally
            oCrossMatchTemplate.Fingerprint = Nothing
            oDigitalPersonaTemplate.Template = Nothing
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Friend Function GetPatientFullName(visitNo As String) As String

        Try

            Dim oVisits As New SyncSoft.SQLDb.Visits()
            If String.IsNullOrEmpty(visitNo) Then Return String.Empty

            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)

            Return StringMayBeEnteredIn(row, "FullName")

        Catch ex As Exception
            ErrorMessage(ex)
            Return String.Empty
        End Try

    End Function

    ''' <summary>
    ''' Gets Policy Limit Amount
    ''' </summary>
    ''' <param name="medicalCardNo"></param>
    ''' <param name="benefitCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPolicyLimit(medicalCardNo As String, benefitCode As String) As Decimal

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim oPolicyLimits As New SyncSoft.SQLDb.PolicyLimits()
            Return oPolicyLimits.GetPolicyLimit(medicalCardNo, benefitCode)

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    ''' <summary>
    ''' Gets Policy Consumed Amount
    ''' </summary>
    ''' <param name="medicalCardNo"></param>
    ''' <param name="benefitCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPolicyConsumedAmount(medicalCardNo As String, benefitCode As String) As Decimal

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()
            Return oClaimDetails.GetPolicyConsumedAmount(medicalCardNo, benefitCode)

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    ''' <summary>
    ''' Get Member Premium Balance
    ''' </summary>
    ''' <param name="patientNo"></param>
    ''' <param name="companyNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetMemberPremiumBalance(patientNo As String, companyNo As String) As Decimal

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim oClaims As New SyncSoft.SQLDb.Claims()
            Return oClaims.GetMemberPremiumBalance(patientNo, companyNo)

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function



    ''' <summary>
    ''' Get Member Premium Usage Balance
    ''' </summary>
    ''' <param name="MainMemberNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 


    Public Function GetMemberPremiumUsageBalance(MainMemberNo As String) As Decimal

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim oInvoices As New SyncSoft.SQLDb.Invoices()
            Return oInvoices.GetMemberPremiumUsageBalance(MainMemberNo)

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    ''' <summary>
    ''' Check if a Patient is a scheme Member
    ''' </summary>
    ''' <param name="MedicalCardNo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 


    Public Function IsPatientSchemeMember(MedicalCardNo As String) As Boolean

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim oSchemeMember As New SyncSoft.SQLDb.SchemeMembers()
            Return oSchemeMember.IsSchemeMember(MedicalCardNo)

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    ''' <summary>
    ''' Gets printable format of item category description
    ''' </summary>
    ''' <param name="dataName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetPrintableItemCategoryDes(dataName As String) As String

        Try
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If dataName.ToUpper().Equals(GetLookupDataDes(oItemCategoryID.Admission).ToUpper()) Then
                Return "Admission Fees"

            ElseIf dataName.ToUpper().Equals(GetLookupDataDes(oItemCategoryID.Consumable).ToUpper()) Then
                Return "Consumable(s)"

            ElseIf dataName.ToUpper().Equals(GetLookupDataDes(oItemCategoryID.Dental).ToUpper()) Then
                Return "Dental Service(s)"

            ElseIf dataName.ToUpper().Equals(GetLookupDataDes(oItemCategoryID.Drug).ToUpper()) Then
                Return "Drug(s)"

            ElseIf dataName.ToUpper().Equals(GetLookupDataDes(oItemCategoryID.Extras).ToUpper()) Then
                Return "Extras"

            ElseIf dataName.ToUpper().Equals(GetLookupDataDes(oItemCategoryID.Eye).ToUpper()) Then
                Return "Eye Service(s)"

            ElseIf dataName.ToUpper().Equals(GetLookupDataDes(oItemCategoryID.ICU).ToUpper()) Then
                Return "ICU Service(s)"

            ElseIf dataName.ToUpper().Equals(GetLookupDataDes(oItemCategoryID.Maternity).ToUpper()) Then
                Return "Maternity Service(s)"

            ElseIf dataName.ToUpper().Equals(GetLookupDataDes(oItemCategoryID.Optical).ToUpper()) Then
                Return "Optical Service(s)"

            ElseIf dataName.ToUpper().Equals(GetLookupDataDes(oItemCategoryID.Pathology).ToUpper()) Then
                Return "Pathology Service(s)"

            ElseIf dataName.ToUpper().Equals(GetLookupDataDes(oItemCategoryID.Procedure).ToUpper()) Then
                Return "Procedure(s)"

            ElseIf dataName.ToUpper().Equals(GetLookupDataDes(oItemCategoryID.Cardiology).ToUpper()) Then
                Return "Cardiology"

            ElseIf dataName.ToUpper().Equals(GetLookupDataDes(oItemCategoryID.Radiology).ToUpper()) Then
                Return "Radiology"

            ElseIf dataName.ToUpper().Equals(GetLookupDataDes(oItemCategoryID.Service).ToUpper()) Then
                Return "Consultation"

            ElseIf dataName.ToUpper().Equals(GetLookupDataDes(oItemCategoryID.Test).ToUpper()) Then
                Return "Laboratory Test(s)"

            ElseIf dataName.ToUpper().Equals(GetLookupDataDes(oItemCategoryID.Theatre).ToUpper()) Then
                Return "Theatre Service(s)"

            Else : Return dataName
            End If

        Catch ex As Exception
            Return dataName
        End Try

    End Function

    ''' <summary>
    '''  checks if patient is authorised for specific date
    ''' </summary>
    ''' <param name="patientNo"></param>
    ''' <param name="billModesID"></param>
    ''' <param name="billNo"></param>
    ''' <param name="toVisitDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function IsSmartCardPatientAuthorized(patientNo As String, billModesID As String, billNo As String, toVisitDate As Date) As Boolean

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim oSmartCardAuthorisations As New SyncSoft.SQLDb.SmartCardAuthorisations()

            If String.IsNullOrEmpty(patientNo) OrElse String.IsNullOrEmpty(billModesID) OrElse String.IsNullOrEmpty(billNo) Then Return False
            If toVisitDate <= AppData.NullDateValue Then Return False

            Return oSmartCardAuthorisations.IsSmartCardAuthorized(patientNo, billModesID, billNo, toVisitDate)

        Catch ex As Exception
            Return False

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function


    Public Sub LoadCheckedListBox(sourcecontrol As Windows.Forms.CheckedListBox, StringValue As String)
        Try

            Dim selectindex As Integer

            If String.IsNullOrEmpty(StringValue) Then

            Else
                Dim StringValueArray As String() = StringValue.Split(New Char() {","c})

                Dim StringValueItem As String = String.Empty

                For Each StringValueItem In StringValueArray

                    If Not String.IsNullOrEmpty(StringValueItem) Then
                        sourcecontrol.SelectedItem = StringValueItem.Trim()
                        selectindex = sourcecontrol.SelectedIndex
                        sourcecontrol.SetItemChecked(selectindex, True)
                        sourcecontrol.SelectedIndex = -1
                    End If

                Next
            End If


        Catch ex As Exception
            Throw ex

        End Try
    End Sub
End Module

Public Class SetupData

#Region "  Fields  "

    Private Shared m_BillCustomers As New DataTable()
    Private Shared m_LabTests As New DataTable()
    Private Shared m_CardiologyExaminations As New DataTable()
    Private Shared m_TheatreServices As New DataTable()
    Private Shared m_RadiologyExaminations As New DataTable()
    Private Shared m_Drugs As New DataTable()
    Private Shared m_ConsumableItems As New DataTable()
    Private Shared m_Procedures As New DataTable()
    Private Shared m_DentalServices As New DataTable()
    Private Shared m_Diseases As New DataTable()
    Private Shared m_PatientFingerprints As New DataTable()

#End Region

#Region " Properties "

    Public Property BillCustomers() As DataTable
        Get
            Return m_BillCustomers
        End Get
        Set(value As DataTable)
            m_BillCustomers = value
        End Set
    End Property

    Public Property LabTests() As DataTable
        Get
            Return m_LabTests
        End Get
        Set(value As DataTable)
            m_LabTests = value
        End Set
    End Property

    Public Property CardiologyExaminations() As DataTable
        Get
            Return m_CardiologyExaminations
        End Get
        Set(value As DataTable)
            m_CardiologyExaminations = value
        End Set
    End Property

    Public Property RadiologyExaminations() As DataTable
        Get
            Return m_RadiologyExaminations
        End Get
        Set(value As DataTable)
            m_RadiologyExaminations = value
        End Set
    End Property

    Public Property Drugs() As DataTable
        Get
            Return m_Drugs
        End Get
        Set(value As DataTable)
            m_Drugs = value
        End Set
    End Property

    Public Property ConsumableItems() As DataTable
        Get
            Return m_ConsumableItems
        End Get
        Set(value As DataTable)
            m_ConsumableItems = value
        End Set
    End Property

    Public Property Procedures() As DataTable
        Get
            Return m_Procedures
        End Get
        Set(value As DataTable)
            m_Procedures = value
        End Set
    End Property

    Public Property DentalServices() As DataTable
        Get
            Return m_DentalServices
        End Get
        Set(value As DataTable)
            m_DentalServices = value
        End Set
    End Property

    Public Property TheatreServices() As DataTable
        Get
            Return m_TheatreServices
        End Get
        Set(value As DataTable)
            m_TheatreServices = value
        End Set
    End Property

    Public Property Diseases() As DataTable
        Get
            Return m_Diseases
        End Get
        Set(value As DataTable)
            m_Diseases = value
        End Set
    End Property

    Public Property PatientFingerprints() As DataTable
        Get
            Return m_PatientFingerprints
        End Get
        Set(value As DataTable)
            m_PatientFingerprints = value
        End Set
    End Property

#End Region

#Region " Constructors "

    Public Sub New()
        MyBase.New()
    End Sub

#End Region

#Region " Methods "

    Public Sub LoadBillCustomers()

        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()

        Try
            Cursor.Current = Cursors.WaitCursor

            ' Load from Bill Customers
            Me.BillCustomers = oBillCustomers.GetBillCustomers().Tables("BillCustomers")

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Sub

    Public Sub LoadLabTests()

        Dim oLabTests As New SyncSoft.SQLDb.LabTests()

        Try
            Cursor.Current = Cursors.WaitCursor

            ' Load from LabTests
            Me.LabTests = oLabTests.GetLabTests().Tables("LabTests")

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Sub



    Public Sub LoadCardiologyExaminations()

        Dim oCardiologyExaminations As New SyncSoft.SQLDb.CardiologyExaminations()

        Try
            Cursor.Current = Cursors.WaitCursor

            ' Load from CardiologyExaminations
            Me.CardiologyExaminations = oCardiologyExaminations.GetCardiologyExaminations().Tables("CardiologyExaminations")

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Sub


    Public Sub LoadRadiologyExaminations()

        Dim oRadiologyExaminations As New SyncSoft.SQLDb.RadiologyExaminations()

        Try
            Cursor.Current = Cursors.WaitCursor

            ' Load from RadiologyExaminations
            Me.RadiologyExaminations = oRadiologyExaminations.GetRadiologyExaminations().Tables("RadiologyExaminations")

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Sub

    Public Sub LoadDrugs()

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()

        Try
            Cursor.Current = Cursors.WaitCursor

            ' Load from Drugs
            Me.Drugs = oDrugs.GetDrugs().Tables("Drugs")

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Sub

    Public Sub LoadConsumableItems()

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try
            Cursor.Current = Cursors.WaitCursor

            ' Load from ConsumableItems
            Me.ConsumableItems = oConsumableItems.GetConsumableItems().Tables("ConsumableItems")

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Sub

    Public Sub LoadProcedures()

        Dim oProcedures As New SyncSoft.SQLDb.Procedures()

        Try
            Cursor.Current = Cursors.WaitCursor

            ' Load from Procedures
            Me.Procedures = oProcedures.GetProcedures().Tables("Procedures")

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Sub

    Public Sub LoadDentalServices()

        Dim oDentalServices As New SyncSoft.SQLDb.DentalServices()

        Try
            Cursor.Current = Cursors.WaitCursor

            ' Load from DentalServices
            Me.DentalServices = oDentalServices.GetDentalServices().Tables("DentalServices")

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Sub

    Public Sub LoadDiseases()

        Dim oDiseases As New SyncSoft.SQLDb.Diseases()

        Try
            Cursor.Current = Cursors.WaitCursor

            ' Load from Diseases
            Me.Diseases = oDiseases.GetDiseases().Tables("Diseases")

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Sub

    Public Sub LoadTheatreServices()

        Dim oTheatreServices As New SyncSoft.SQLDb.TheatreServices()

        Try
            Cursor.Current = Cursors.WaitCursor

            ' Load from TheatreServices
            Me.theatreServices = oTheatreServices.GetTheatreServices().Tables("TheatreServices")

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Sub


    Public Sub LoadPatientFingerprints()

        Dim oPatients As New SyncSoft.SQLDb.Patients()

        Try
            Cursor.Current = Cursors.WaitCursor

            ' Load from PatientFingerprints
            Me.PatientFingerprints = oPatients.GetPatientFingerprints().Tables("Patients")

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Sub

#End Region

End Class

Public Class VariousOptions

#Region "  Fields  "

    Private options As DataTable
    Private oOptions As New SyncSoft.Options.SQL.Options()

#End Region

#Region " Properties "

#End Region

#Region " Constructors "

    Public Sub New()
        MyBase.New()
    End Sub

#End Region

#Region " Methods "

    Public Function ANCNoPrefix() As String

        Try
            options = oOptions.GetOptions("ANCNoPrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function TheatreCodePrefix() As String

        Try
            options = oOptions.GetOptions("TheatreCodePrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function EyeCodePrefix() As String

        Try
            options = oOptions.GetOptions("EyeCodePrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function OpticalCodePrefix() As String

        Try
            options = oOptions.GetOptions("OpticalCodePrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function DentalCodePrefix() As String

        Try
            options = oOptions.GetOptions("DentalCodePrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function ICUCodePrefix() As String

        Try
            options = oOptions.GetOptions("ICUCodePrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function MaternityCodePrefix() As String

        Try
            options = oOptions.GetOptions("MaternityCodePrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function ProcedureCodePrefix() As String

        Try
            options = oOptions.GetOptions("ProcedureCodePrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function TestCodePrefix() As String

        Try
            options = oOptions.GetOptions("TestCodePrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function BedNoPrefix() As String

        Try
            options = oOptions.GetOptions("BedNoPrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function CardiologyExamCodePrefix() As String

        Try
            options = oOptions.GetOptions("CardiologyExamCodePrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function RadiologyExamCodePrefix() As String

        Try
            options = oOptions.GetOptions("RadiologyExamCodePrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function PathologyExamCodePrefix() As String

        Try
            options = oOptions.GetOptions("PathologyExamCodePrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function ExtraItemCodePrefix() As String

        Try
            options = oOptions.GetOptions("ExtraItemCodePrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function PackageNoPrefix() As String

        Try
            options = oOptions.GetOptions("PackageNoPrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function RequisitionPaymentNoPrefix() As String

        Try
            options = oOptions.GetOptions("RequisitionPaymentNoPrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function RequisitionApprovalNoPrefix() As String

        Try
            options = oOptions.GetOptions("RequisitionApprovalNoPrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function RequisitionNoPrefix() As String

        Try
            options = oOptions.GetOptions("RequisitionNoPrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function ServiceCodePrefix() As String

        Try
            options = oOptions.GetOptions("ServiceCodePrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function


    Public Function MedicalCardNoPrefix() As String

        Try
            options = oOptions.GetOptions("MedicalCardNoPrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function SelfRequestNoPrefix() As String

        Try
            options = oOptions.GetOptions("SelfRequestNoPrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function PatientNoPrefix() As String

        Try
            options = oOptions.GetOptions("PatientNoPrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function ReceiptNoPrefix() As String

        Try
            options = oOptions.GetOptions("ReceiptNoPrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function StaffNoPrefix() As String

        Try
            options = oOptions.GetOptions("StaffNoPrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function DrugNoPrefix() As String

        Try
            options = oOptions.GetOptions("DrugNoPrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function OtherItemsPrefix() As String

        Try
            options = oOptions.GetOptions("OtherItemsPrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function ConsumableNoPrefix() As String

        Try
            options = oOptions.GetOptions("ConsumableNoPrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function ImmunisationNoPrefix() As String

        Try
            options = oOptions.GetOptions("ImmunisationNoPrefix").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function FingerprintDevice() As String

        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try
            options = oOptions.GetOptions("FingerprintDevice").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return oFingerprintDeviceID.DigitalPersona
                End If
            Else : Return oFingerprintDeviceID.DigitalPersona
            End If

        Catch ex As Exception
            Return oFingerprintDeviceID.DigitalPersona
        End Try

    End Function

    Public Function DisableConstraints() As Boolean

        Try
            options = oOptions.GetOptions("DisableConstraints").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowAccountReceiptsRefunds() As Boolean

        Try
            options = oOptions.GetOptions("AllowAccountReceiptsRefunds").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function AllowPrescriptionToNegative() As Boolean

        Try
            options = oOptions.GetOptions("AllowPrescriptionToNegative").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowPrescriptionExpiredDrugs() As Boolean

        Try
            options = oOptions.GetOptions("AllowPrescriptionExpiredDrugs").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowDispensingToNegative() As Boolean

        Try
            options = oOptions.GetOptions("AllowDispensingToNegative").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowDispensingExpiredDrugs() As Boolean

        Try
            options = oOptions.GetOptions("AllowDispensingExpiredDrugs").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowPrescriptionExpiredConsumables() As Boolean

        Try
            options = oOptions.GetOptions("AllowPrescriptionExpiredConsumables").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowDispensingExpiredConsumables() As Boolean

        Try
            options = oOptions.GetOptions("AllowDispensingExpiredConsumables").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowPrintingPatientFaceSheet() As Boolean

        Try
            options = oOptions.GetOptions("AllowPrintingPatientFaceSheet").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowPrintingAdmissionFaceSheet() As Boolean

        Try
            options = oOptions.GetOptions("AllowPrintingAdmissionFaceSheet").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowPrintingPatientBioData() As Boolean

        Try
            options = oOptions.GetOptions("AllowPrintingPatientBioData").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowPrintingForm5() As Boolean

        Try
            options = oOptions.GetOptions("AllowPrintingForm5").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function OpenInvoicesAfterVisits() As Boolean

        Try
            options = oOptions.GetOptions("OpenInvoicesAfterVisits").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function EnablePrintInvoiceDetailesCheck() As Boolean

        Try
            options = oOptions.GetOptions("EnablePrintInvoiceDetailesCheck").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function IncorporateFingerprintCapture() As Boolean

        Try
            options = oOptions.GetOptions("IncorporateFingerprintCapture").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function FingerprintCaptureAgeLimit() As Integer

        Dim nullAgeLimit As Integer = GetAge(AppData.NullDateValue)

        Try

            options = oOptions.GetOptions("FingerprintCaptureAgeLimit").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim captureAgeLimit As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), captureAgeLimit) Then
                    Return captureAgeLimit
                Else : Return nullAgeLimit
                End If
            Else : Return nullAgeLimit
            End If

        Catch ex As Exception
            Return nullAgeLimit
        End Try

    End Function

    Public Function AllowPartialCashPayment() As Boolean

        Try
            options = oOptions.GetOptions("AllowPartialCashPayment").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowAccessCashServices() As Boolean

        Try
            options = oOptions.GetOptions("AllowAccessCashServices").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowAccessCashConsultation() As Boolean

        Try
            options = oOptions.GetOptions("AllowAccessCashConsultation").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisableClearingSelfRequestPatientData() As Boolean

        Try
            options = oOptions.GetOptions("DisableClearingSelfRequestPatientData").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowAccessCoPayServices() As Boolean

        Try
            options = oOptions.GetOptions("AllowAccessCoPayServices").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowAccessCashDischarges() As Boolean

        Try
            options = oOptions.GetOptions("AllowAccessCashDischarges").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function HideInvoiceHeader() As Boolean

        Try
            options = oOptions.GetOptions("HideInvoiceHeader").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function EnableRegistrationShortCuts() As Boolean

        Try
            options = oOptions.GetOptions("EnableRegistrationShortCuts").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function EnableDoctorHelpNotifications() As Boolean

        Try
            options = oOptions.GetOptions("EnableDoctorHelpNotifications").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowCreateMultipleVisits() As Boolean

        Try
            options = oOptions.GetOptions("AllowCreateMultipleVisits").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowCreateInvoicesAtCashPayments() As Boolean

        Try
            options = oOptions.GetOptions("AllowCreateInvoicesAtCashPayments").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowCreateMultipleSpecialityVisits() As Boolean

        Try
            options = oOptions.GetOptions("AllowCreateMultipleSpecialityVisits").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ForceSmartCardProcessing() As Boolean

        Try
            options = oOptions.GetOptions("ForceSmartCardProcessing").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    

    Public Function SmartCardConnectionAttemptNo() As Integer

        Dim nullAttemptNo As Integer = 10

        Try

            options = oOptions.GetOptions("SmartCardConnectionAttemptNo").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim connectionAttemptNo As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), connectionAttemptNo) Then
                    Return connectionAttemptNo
                Else : Return nullAttemptNo
                End If
            Else : Return nullAttemptNo
            End If

        Catch ex As Exception
            Return nullAttemptNo
        End Try

    End Function

    Public Function SmartCardServiceProviderNo() As String

        Try
            options = oOptions.GetOptions("SmartCardServiceProviderNo").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function ForceTBAssessmentAtTriage() As Boolean

        Try
            options = oOptions.GetOptions("ForceTBAssessmentAtTriage").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function IncomeSummariesSMSTime() As String

        Try
            options = oOptions.GetOptions("IncomeSummariesSMSTime").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function IncomeSummariesSMSTime2() As String

        Try
            options = oOptions.GetOptions("IncomeSummariesSMSTime(2)").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function AllowCreateMultipleExtraBills() As Boolean

        Try
            options = oOptions.GetOptions("AllowCreateMultipleExtraBills").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function HideBillFormItemsPresentAtIPDDoctor() As Boolean

        Try
            options = oOptions.GetOptions("HideBillFormItemsPresentAtIPDDoctor").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowSmartCardApplicableVisit() As Boolean

        Try
            options = oOptions.GetOptions("AllowSmartCardApplicableVisit").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowIssueStockOnLabRequest() As Boolean

        Try
            options = oOptions.GetOptions("AllowIssueStockOnLabRequest").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function DisallowPaymentOfOutStockDrugs() As Boolean

        Try
            options = oOptions.GetOptions("DisallowPaymentOfOutStockDrugs").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function IncludeMonthsForAgesBelow() As Integer

        Dim nullAge As Integer = 0

        Try

            options = oOptions.GetOptions("IncludeMonthsForAgesBelow").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim ageValue As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), ageValue) Then
                    Return ageValue
                Else : Return nullAge
                End If
            Else : Return nullAge
            End If

        Catch ex As Exception
            Return nullAge
        End Try

    End Function

    Public Function ExpiryWarningDays() As Integer

        Dim nullDays As Integer = 0

        Try

            options = oOptions.GetOptions("ExpiryWarningDays").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim days As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), days) Then
                    Return days
                Else : Return nullDays
                End If
            Else : Return nullDays
            End If

        Catch ex As Exception
            Return nullDays
        End Try

    End Function

    Public Function InventoryAlertDays() As Integer

        Dim nullDays As Integer = 0

        Try

            options = oOptions.GetOptions("InventoryAlertDays").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim days As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), days) Then
                    Return days
                Else : Return nullDays
                End If
            Else : Return nullDays
            End If

        Catch ex As Exception
            Return nullDays
        End Try

    End Function

    Public Function IPDNurseAlertDays() As Integer

        Dim nullDays As Integer = 0

        Try

            options = oOptions.GetOptions("IPDNurseAlertDays").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim days As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), days) Then
                    Return days
                Else : Return nullDays
                End If
            Else : Return nullDays
            End If

        Catch ex As Exception
            Return nullDays
        End Try

    End Function

    Public Function ClaimPaymentsAlertDays() As Integer

        Dim nullDays As Integer = 0

        Try

            options = oOptions.GetOptions("ClaimPaymentsAlertDays").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim days As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), days) Then
                    Return days
                Else : Return nullDays
                End If
            Else : Return nullDays
            End If

        Catch ex As Exception
            Return nullDays
        End Try

    End Function

    Public Function DoctorVisitUpdateDays() As Integer

        Dim nullDays As Integer = 0

        Try

            options = oOptions.GetOptions("DoctorVisitUpdateDays").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim days As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), days) Then
                    Return days
                Else : Return nullDays
                End If
            Else : Return nullDays
            End If

        Catch ex As Exception
            Return nullDays
        End Try

    End Function

    Public Function AllowExtendedVisitEdits() As Boolean

        Try
            options = oOptions.GetOptions("AllowExtendedVisitEdits").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function EnableVisitToSeeDoctorSelection() As Boolean

        Try
            options = oOptions.GetOptions("EnableVisitToSeeDoctorSelection").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function LockItemsUnitPrices() As Boolean

        Try
            options = oOptions.GetOptions("LockItemsUnitPrices").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowProvisionalPrinting() As Boolean

        Try
            options = oOptions.GetOptions("AllowProvisionalPrinting").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function



    Public Function EnableVisitDate() As Boolean

        Try
            options = oOptions.GetOptions("EnableVisitDate").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function EnableInvoiceDate() As Boolean

        Try
            options = oOptions.GetOptions("EnableInvoiceDate").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function EnablePayDate() As Boolean

        Try
            options = oOptions.GetOptions("EnablePayDate").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowDirectDebitBalanceEntry() As Boolean

        Try
            options = oOptions.GetOptions("AllowDirectDebitBalanceEntry").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowDirectDiscountCashPayment() As Boolean

        Try
            options = oOptions.GetOptions("AllowDirectDiscountCashPayment").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function HideCashPaymentReceiptDetails() As Boolean

        Try
            options = oOptions.GetOptions("HideCashPaymentReceiptDetails").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function HideBillFormPaymentReceiptDetails() As Boolean

        Try
            options = oOptions.GetOptions("HideBillFormPaymentReceiptDetails").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function HideCreditBillsPaymentReceiptDetails() As Boolean

        Try
            options = oOptions.GetOptions("HideCreditBillsPaymentReceiptDetails").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function HideCreditBillFormPaymentReceiptDetails() As Boolean

        Try
            options = oOptions.GetOptions("HideCreditBillFormPaymentReceiptDetails").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowProcessingPendingItems() As Boolean

        Try
            options = oOptions.GetOptions("AllowProcessingPendingItems").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function HideCashReceiptHeader() As Boolean

        Try
            options = oOptions.GetOptions("HideCashReceiptHeader").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowCreateMultipleVisitInvoices() As Boolean

        Try
            options = oOptions.GetOptions("AllowCreateMultipleVisitInvoices").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AutoRenewSchemeMembers() As Boolean

        Try
            options = oOptions.GetOptions("AutoRenewSchemeMembers").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function HideDoctorBillServiceFee() As Boolean

        Try
            options = oOptions.GetOptions("HideDoctorBillServiceFee").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function HideBillFormDrugDetails() As Boolean

        Try
            options = oOptions.GetOptions("HideBillFormDrugDetails").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ForceInsuranceFingerprintVerification() As Boolean

        Try
            options = oOptions.GetOptions("ForceInsuranceFingerprintVerification").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ForceSelfRequestVisitsToPayConsultation() As Boolean

        Try
            options = oOptions.GetOptions("ForceSelfRequestVisitsToPayConsultation").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ActivePatientMonths() As Integer

        Dim nullMonths As Integer = 24

        Try

            options = oOptions.GetOptions("ActivePatientMonths").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim months As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), months) Then
                    Return months
                Else : Return nullMonths
                End If
            Else : Return nullMonths
            End If

        Catch ex As Exception
            Return nullMonths
        End Try

    End Function

    Public Function ForceAccountMainMemberName() As Boolean

        Try
            options = oOptions.GetOptions("ForceAccountMainMemberName").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowCreditSelfRequests() As Boolean

        Try
            options = oOptions.GetOptions("AllowCreditSelfRequests").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowInsuranceDirectLinkedMember() As Boolean

        Try
            options = oOptions.GetOptions("AllowInsuranceDirectLinkedMember").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ForceDiagnosisOnPrescription() As Boolean

        Try
            options = oOptions.GetOptions("ForceDiagnosisOnPrescription").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ForceDiagnosisAtDoctor() As Boolean

        Try
            options = oOptions.GetOptions("ForceDiagnosisAtDoctor").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ForcePatientGeographicalLocation() As Boolean

        Try
            options = oOptions.GetOptions("ForcePatientGeographicalLocation").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ForcePatientAddress() As Boolean

        Try
            options = oOptions.GetOptions("ForcePatientAddress").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function PrintItemCodesOnInvoices() As Boolean

        Try
            options = oOptions.GetOptions("PrintItemCodesOnInvoices").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowPrintingBeforeDispensing() As Boolean

        Try
            options = oOptions.GetOptions("AllowPrintingBeforeDispensing").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function OpenIPDDispenseAfterPrescription() As Boolean

        Try
            options = oOptions.GetOptions("OpenIPDDispenseAfterPrescription").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowManualIssuingToNegative() As Boolean

        Try
            options = oOptions.GetOptions("AllowManualIssuingToNegative").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowLocationIssuingToNegative() As Boolean

        Try
            options = oOptions.GetOptions("AllowLocationIssuingToNegative").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowGenerateSelfRequestsNo() As Boolean

        Try
            options = oOptions.GetOptions("AllowGenerateSelfRequestsNo").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function EnableQueue() As Boolean

        Try
            options = oOptions.GetOptions("EnableQueue").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function EnableUseOfRefundDateForReports() As Boolean

        Try
            options = oOptions.GetOptions("EnableUseOfRefundDateForReports").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function EnableSecondPatientForm() As Boolean

        Try
            options = oOptions.GetOptions("EnableSecondPatientForm").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function QueueReadCount() As Integer

        Dim nullQueueReadCount As Integer = 3

        Try

            options = oOptions.GetOptions("QueueReadCount").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim QueueReadCountValue As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), QueueReadCountValue) Then
                    Return QueueReadCountValue
                Else : Return nullQueueReadCount
                End If
            Else : Return nullQueueReadCount
            End If

        Catch ex As Exception
            Return nullQueueReadCount
        End Try

    End Function

    Public Function EnableAccessCashServices() As Boolean

        Try
            options = oOptions.GetOptions("EnableAccessCashServices").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function EnableSetAssociatedBillCustomer() As Boolean

        Try
            options = oOptions.GetOptions("EnableSetAssociatedBillCustomer").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function EnableAdmissionBillServiceFee() As Boolean

        Try
            options = oOptions.GetOptions("EnableAdmissionBillServiceFee").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowBillVisitServiceAtExtraBill() As Boolean

        Try
            options = oOptions.GetOptions("AllowBillVisitServiceAtExtraBill").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function OpenCashierFormOnAdmission() As Boolean

        Try
            options = oOptions.GetOptions("OpenCashierFormOnAdmission").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowOpenCashierAtBillingForm() As Boolean

        Try
            options = oOptions.GetOptions("AllowOpenCashierAtBillingForm").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function EnableSetInventoryLocation() As Boolean

        Try
            options = oOptions.GetOptions("EnableSetInventoryLocation").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function EnableInventoryPhysicalStockEntry() As Boolean

        Try
            options = oOptions.GetOptions("EnableInventoryPhysicalStockEntry").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function OpenIssueConsumablesAfterPrescription() As Boolean

        Try
            options = oOptions.GetOptions("OpenIssueConsumablesAfterPrescription").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function OpenIPDTheatreIssueConsumablesAfterPrescription() As Boolean

        Try
            options = oOptions.GetOptions("OpenIPDTheatreIssueConsumablesAfterPrescription").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowInventoryManualIssuing() As Boolean

        Try
            options = oOptions.GetOptions("AllowInventoryManualIssuing").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisablePatientSignOnInvoices() As Boolean

        Try
            options = oOptions.GetOptions("DisablePatientSignOnInvoices").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowAccessOPDTheatre() As Boolean

        Try
            options = oOptions.GetOptions("AllowAccessOPDTheatre").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowManualAccountDebitEntry() As Boolean

        Try
            options = oOptions.GetOptions("AllowManualAccountDebitEntry").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function CategorizeVisitPaymentDetails() As Boolean

        Try
            options = oOptions.GetOptions("CategorizeVisitPaymentDetails").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function CategorizeBillFormPaymentDetails() As Boolean

        Try
            options = oOptions.GetOptions("CategorizeBillFormPaymentDetails").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function CategorizeVisitInvoiceDetails() As Boolean

        Try
            options = oOptions.GetOptions("CategorizeVisitInvoiceDetails").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function CategorizeVisitInvoiceDetailsByItemCategory() As Boolean

        Try
            options = oOptions.GetOptions("CategorizeVisitInvoiceDetailsByItemCategory").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function GroupVisitInvoiceDetails() As Boolean

        Try
            options = oOptions.GetOptions("GroupVisitInvoiceDetails").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function VisitReviewDays() As Integer

        Dim nullDays As Integer = 0

        Try

            options = oOptions.GetOptions("VisitReviewDays").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim days As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), days) Then
                    Return days
                Else : Return nullDays
                End If
            Else : Return nullDays
            End If

        Catch ex As Exception
            Return nullDays
        End Try

    End Function

    Public Function CashPaymentPercentBeforeAdmission() As Single

        Dim nullPercent As Single = 0

        Try

            options = oOptions.GetOptions("CashPaymentPercentBeforeAdmission").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim days As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), days) Then
                    Return days
                Else : Return nullPercent
                End If
            Else : Return nullPercent
            End If

        Catch ex As Exception
            Return nullPercent
        End Try

    End Function

    Public Function ForceDispensingPreviousPrescription() As Boolean

        Try
            options = oOptions.GetOptions("ForceDispensingPreviousPrescription").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function ForceLabResultsVerification() As Boolean

        Try
            options = oOptions.GetOptions("ForceLabResultsVerification").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function RestrictDoctorLoginID() As Boolean

        Try
            options = oOptions.GetOptions("RestrictDoctorLoginID").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function RestrictDrawnByLoginID() As Boolean

        Try
            options = oOptions.GetOptions("RestrictDrawnByLoginID").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function RestrictLabTechnologistLoginID() As Boolean

        Try
            options = oOptions.GetOptions("RestrictLabTechnologistLoginID").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function RestrictPharmacistLoginID() As Boolean

        Try
            options = oOptions.GetOptions("RestrictPharmacistLoginID").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function RestrictCardiologistLoginID() As Boolean

        Try
            options = oOptions.GetOptions("RestrictCardiologistLoginID").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function RestrictRadiologistLoginID() As Boolean

        Try
            options = oOptions.GetOptions("RestrictRadiologistLoginID").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function RestrictPathologistLoginID() As Boolean

        Try
            options = oOptions.GetOptions("RestrictPathologistLoginID").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function HideAccessCashServicesAtVisits() As Boolean

        Try
            options = oOptions.GetOptions("HideAccessCashServicesAtVisits").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function EnableIntegrationN001() As Boolean

        Try
            options = oOptions.GetOptions("EnableIntegrationN001").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function UseCentralisedPhysicalStockCount() As Boolean

        Try
            options = oOptions.GetOptions("UseCentralisedPhysicalStockCount").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function EnableMultiplePhysicalStockCountNumbers() As Boolean

        Try
            options = oOptions.GetOptions("EnableMultiplePhysicalStockCountNumbers").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function




#Region "FinanceOptions"

    Public Function EnableClinicMasterFinanceItengration() As Boolean

        Try
            options = oOptions.GetOptions("EnableClinicMasterFinanceItengration").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function GetBusinessIncomeAccountCategoryNo() As String

        Try
            options = oOptions.GetOptions("BusinessIncomeAccountCategoryNo").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function GetBankAccountCategoryNo() As String

        Try
            options = oOptions.GetOptions("BankAccountCategoryNo").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function GetPurchaseCategoryNo() As String

        Try
            options = oOptions.GetOptions("PurchaseCategoryNo").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) Then
                    Return row.Item("OptionValue").ToString()
                Else : Return String.Empty
                End If
            Else : Return String.Empty
            End If

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

#End Region


    Public Function AllowExtraBillInventoryIssuing() As Boolean

        Try
            options = oOptions.GetOptions("AllowExtraBillInventoryIssuing").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisableDosageAndDuration() As Boolean

        Try
            options = oOptions.GetOptions("DisableDosageAndDurationAtSelfRequest").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function CaptureAndUseBarCodes() As Boolean

        Try
            options = oOptions.GetOptions("CaptureAndUseBarCodes").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowDrugsServiceFee() As Boolean

        Try
            options = oOptions.GetOptions("AllowDrugsServiceFee").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AllowCustomAdmissionNoFormat() As Boolean

        Try
            options = oOptions.GetOptions("AllowCustomAdmissionNoFormat").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function RestrictSelectionOfOnlyLoggedInDoctors() As Boolean

        Try
            options = oOptions.GetOptions("RestrictSelectionOfOnlyLoggedInDoctors").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


#Region "SMS -Details"

    Public Function UseSMSAPI001() As Boolean

        Try
            options = oOptions.GetOptions("SendSMSUsingAPI001").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function UseSMSAPI002() As Boolean

        Try
            options = oOptions.GetOptions("SendSMSUsingAPI002").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function UseSMSAPI003() As Boolean

        Try
            options = oOptions.GetOptions("SendSMSUsingAPI003").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function UseSMSAPI004() As Boolean

        Try
            options = oOptions.GetOptions("SendSMSUsingAPI004").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function SMSNotificationForIncomeSummaries() As Boolean

        Try
            options = oOptions.GetOptions("EnableSMSNotificationForIncomeSummaries").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function SMSNotificationAtCashPayment() As Boolean

        Try
            options = oOptions.GetOptions("EnableSMSNotificationAtCashPayment").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function SMSNotificationAtBillFormPayment() As Boolean

        Try
            options = oOptions.GetOptions("EnableSMSNotificationAtBillFormPayment").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function SMSNotificationAtPharmacy() As Boolean

        Try
            options = oOptions.GetOptions("EnableSMSNotificationAtPharmacy").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function SMSNotificationAtManageAccounts() As Boolean

        Try
            options = oOptions.GetOptions("EnableSMSNotificationAtManageAccounts").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function SMSNotificationAtVisits() As Boolean

        Try
            options = oOptions.GetOptions("EnableSMSNotificationAtVisits").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function SMSNotificationAtPatientRegistration() As Boolean

        Try
            options = oOptions.GetOptions("EnableSMSNotificationAtPatientReg").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function SMSNotificationAtAppointments() As Boolean

        Try
            options = oOptions.GetOptions("EnableSMSNotificationAtAppointments").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function SMSNotificationAtBirthdays() As Boolean

        Try
            options = oOptions.GetOptions("EnableSMSNotificationForBirthdays").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function SMSNotificationAtLab() As Boolean

        Try
            options = oOptions.GetOptions("EnableSMSNotificationAtLab").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function SMSNotificationAtCardiology() As Boolean

        Try
            options = oOptions.GetOptions("EnableSMSNotificationAtCardiology").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function SMSNotificationAtRadiology() As Boolean

        Try
            options = oOptions.GetOptions("EnableSMSNotificationAtRadiology").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function SMSLifeSpanAppointments() As Integer

        Dim nullmis As Integer = 30

        Try


            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim mins As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), mins) Then
                    Return mins
                Else : Return nullmis
                End If
            Else : Return nullmis
                options = oOptions.GetOptions("SMSLifeSpanAppointments").Tables("Options")
            End If

        Catch ex As Exception
            Return nullmis
        End Try

    End Function

    Public Function SMSLifeSpanCashier() As Integer

        Dim nullmis As Integer = 30

        Try


            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim mins As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), mins) Then
                    Return mins
                Else : Return nullmis
                End If
            Else : Return nullmis
                options = oOptions.GetOptions("SMSLifeSpanCashier").Tables("Options")
            End If

        Catch ex As Exception
            Return nullmis
        End Try

    End Function

    Public Function SMSLifeSpanVisits() As Integer

        Dim nullmis As Integer = 30

        Try


            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim mins As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), mins) Then
                    Return mins
                Else : Return nullmis
                End If
            Else : Return nullmis
                options = oOptions.GetOptions("SMSLifeSpanVisits").Tables("Options")
            End If

        Catch ex As Exception
            Return nullmis
        End Try

    End Function

    Public Function SMSLifeSpanCardiology() As Integer

        Dim nullmis As Integer = 5

        Try


            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim mins As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), mins) Then
                    Return mins
                Else : Return nullmis
                End If
            Else : Return nullmis
                options = oOptions.GetOptions("SMSLifeSpanCardiology").Tables("Options")
            End If

        Catch ex As Exception
            Return nullmis
        End Try

    End Function


    Public Function SMSLifeSpanRadiology() As Integer

        Dim nullmis As Integer = 5

        Try


            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim mins As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), mins) Then
                    Return mins
                Else : Return nullmis
                End If
            Else : Return nullmis
                options = oOptions.GetOptions("SMSLifeSpanRadiology").Tables("Options")
            End If

        Catch ex As Exception
            Return nullmis
        End Try

    End Function

    Public Function SMSLifeSpanLab() As Integer

        Dim nullmis As Integer = 3

        Try


            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim mins As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), mins) Then
                    Return mins
                Else : Return nullmis
                End If
            Else : Return nullmis
                options = oOptions.GetOptions("SMSLifeSpanLab").Tables("Options")
            End If

        Catch ex As Exception
            Return nullmis
        End Try

    End Function

    Public Function SMSLifeSpanPatientReg() As Integer

        Dim nullmis As Integer = 30

        Try


            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim mins As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), mins) Then
                    Return mins
                Else : Return nullmis
                End If
            Else : Return nullmis
                options = oOptions.GetOptions("SMSLifeSpanPatientReg").Tables("Options")
            End If

        Catch ex As Exception
            Return nullmis
        End Try

    End Function

    Public Function SMSLifeSpanIncomeSummaries() As Integer

        Dim nullmis As Integer = 30

        Try


            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim mins As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), mins) Then
                    Return mins
                Else : Return nullmis
                End If
            Else : Return nullmis
                options = oOptions.GetOptions("SMSLifeSpanIncomeSummaries").Tables("Options")
            End If

        Catch ex As Exception
            Return nullmis
        End Try

    End Function

    Public Function SMSLifeSpanManageACCs() As Integer

        Dim nullmis As Integer = 30

        Try


            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim mins As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), mins) Then
                    Return mins
                Else : Return nullmis
                End If
            Else : Return nullmis
                options = oOptions.GetOptions("SMSLifeSpanManageACCs").Tables("Options")
            End If

        Catch ex As Exception
            Return nullmis
        End Try

    End Function

    Public Function SMSLifeSpanBirthDays() As Integer

        Dim nullmis As Integer = 30

        Try


            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim mins As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), mins) Then
                    Return mins
                Else : Return nullmis
                End If
            Else : Return nullmis
                options = oOptions.GetOptions("SMSLifeSpanBirthDays").Tables("Options")
            End If

        Catch ex As Exception
            Return nullmis
        End Try

    End Function


    Public Function SMSLifeSpanPharmacy() As Integer

        Dim nullmis As Integer = 3

        Try


            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim mins As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), mins) Then
                    Return mins
                Else : Return nullmis
                End If
            Else : Return nullmis
                options = oOptions.GetOptions("SMSLifeSpanPharmacy").Tables("Options")
            End If

        Catch ex As Exception
            Return nullmis
        End Try

    End Function

#End Region

    Public Function GenerateInventoryInvoiceOnDispensingOnly() As Boolean

        Try
            options = oOptions.GetOptions("GenerateInventoryInvoiceOnDispensingOnly").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ForceInventoryAcknowledgementBeforeOrdering() As Boolean

        Try
            options = oOptions.GetOptions("ForceInventoryAcknowledgementBeforeOrdering").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function InheritOPDServicesAtIPD() As Boolean

        Try
            options = oOptions.GetOptions("InheritOPDServicesAtIPD").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function EnableOPDExtraBills() As Boolean

        Try
            options = oOptions.GetOptions("EnableOPDExtraBills").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function MaximumDrugQtyToGive() As Integer

        Dim nullmis As Integer = 100

        Try


            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                Dim mins As Integer
                If Not IsDBNull(row.Item("OptionValue")) AndAlso
                Integer.TryParse(row.Item("OptionValue").ToString(), mins) Then
                    Return mins
                Else : Return nullmis
                End If
            Else : Return nullmis
                options = oOptions.GetOptions("MaximumDrugQtyToGive").Tables("Options")
            End If

        Catch ex As Exception
            Return nullmis
        End Try

    End Function


    Public Function EnablePackages() As Boolean

        Try
            options = oOptions.GetOptions("EnablePackages").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function EnableMemberLimitBalanceTracking() As Boolean

        Try
            options = oOptions.GetOptions("EnableMemberLimitBalanceTracking").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function GenerateProcedureInvoiceOnIssuingOnly() As Boolean

        Try
            options = oOptions.GetOptions("GenerateProcedureInvoiceOnIssuingOnly").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function
#End Region

#Region "Disable Startup Features"

    Public Function DisablePatientRegistration() As Boolean

        Try
            options = oOptions.GetOptions("DisablePatientRegistration").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisableVisitsCreation() As Boolean

        Try
            options = oOptions.GetOptions("DisableVisitsCreation").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisableExtras() As Boolean

        Try
            options = oOptions.GetOptions("DisableExtras").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisableFinance() As Boolean

        Try
            options = oOptions.GetOptions("DisableFinance").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisableTriagePoint() As Boolean

        Try
            options = oOptions.GetOptions("DisableTriagePoint").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisableCashier() As Boolean

        Try
            options = oOptions.GetOptions("DisableCashier").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisableInvoices() As Boolean

        Try
            options = oOptions.GetOptions("DisableInvoices").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisableDoctor() As Boolean

        Try
            options = oOptions.GetOptions("DisableDoctor").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisableLaboratory() As Boolean

        Try
            options = oOptions.GetOptions("DisableLaboratory").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function DisableCardiology() As Boolean

        Try
            options = oOptions.GetOptions("DisableCardiology").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function



    Public Function DisableRadiology() As Boolean

        Try
            options = oOptions.GetOptions("DisableRadiology").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisablePharmacy() As Boolean

        Try
            options = oOptions.GetOptions("DisablePharmacy").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisableTheatre() As Boolean

        Try
            options = oOptions.GetOptions("DisableTheatre").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisableDental() As Boolean

        Try
            options = oOptions.GetOptions("DisableDental").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisableAppointments() As Boolean

        Try
            options = oOptions.GetOptions("DisableAppointments").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisableInPatients() As Boolean

        Try
            options = oOptions.GetOptions("DisableInPatients").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisableManageART() As Boolean

        Try
            options = oOptions.GetOptions("DisableManageART").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisableDeaths() As Boolean

        Try
            options = oOptions.GetOptions("DisableDeaths").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function DisablePathology() As Boolean

        Try
            options = oOptions.GetOptions("DisablePathology").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function UseOfInventoryPackSizes() As Boolean

        Try
            options = oOptions.GetOptions("EnableUseOfInventoryPackSizes").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

#End Region

    Public Function EnableCommentsAtPrintingLabReport() As Boolean

        Try
            options = oOptions.GetOptions("EnableCommentsAtPrintingLabReport").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ForceBillableMappings() As Boolean

        Try
            options = oOptions.GetOptions("ForceBillableMappings").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function EnablePrintingInvoicesWithCompanyName() As Boolean

        Try
            options = oOptions.GetOptions("EnablePrintingInvoicesWithCompanyName").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function ForceFingerPrintOnSelfRequestLabReport() As Boolean

        Try
            options = oOptions.GetOptions("ForceFingerPrintOnSelfRequestLabReport").Tables("Options")

            If options IsNot Nothing OrElse options.Rows.Count > 0 Then
                Dim row As DataRow = options.Rows(0)
                If Not IsDBNull(row.Item("OptionValue")) AndAlso CInt(row.Item("OptionValue")) > 0 Then
                    Return True
                Else : Return False
                End If
            Else : Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

End Class

Public Class NextAppointment

#Region " Fields "

    Private m_PatientNo As String
    Private m_FullName As String
    Private m_StartDate As Date
    Private m_AppointmentPrecisionID As String
    Private m_StartTime As String
    Private m_Duration As Integer
    Private m_EndDate As Date
    Private m_StaffFullName As String
    Private m_AppointmentDes As String
    Private m_AppointmentStatusID As String

#End Region

#Region " Properties "

    Public Property PatientNo() As String
        Get
            Return m_PatientNo
        End Get
        Set(Value As String)
            m_PatientNo = Value
        End Set
    End Property

    Public Property FullName() As String
        Get
            Return m_FullName
        End Get
        Set(value As String)
            m_FullName = value
        End Set
    End Property

    Public Property StartDate() As Date
        Get
            Return m_StartDate
        End Get
        Set(value As Date)
            m_StartDate = value
        End Set
    End Property

    Public Property AppointmentPrecisionID() As String
        Get
            Return m_AppointmentPrecisionID
        End Get
        Set(value As String)
            m_AppointmentPrecisionID = value
        End Set
    End Property

    Public Property StartTime() As String
        Get
            Return m_StartTime
        End Get
        Set(value As String)
            m_StartTime = value
        End Set
    End Property

    Public Property Duration() As Integer
        Get
            Return m_Duration
        End Get
        Set(value As Integer)
            m_Duration = value
        End Set
    End Property

    Public Property EndDate() As Date
        Get
            Return m_EndDate
        End Get
        Set(value As Date)
            m_EndDate = value
        End Set
    End Property

    Public Property StaffFullName() As String
        Get
            Return m_StaffFullName
        End Get
        Set(value As String)
            m_StaffFullName = value
        End Set
    End Property

    Public Property AppointmentDes() As String
        Get
            Return m_AppointmentDes
        End Get
        Set(Value As String)
            m_AppointmentDes = Value
        End Set
    End Property

    Public Property AppointmentStatusID() As String
        Get
            Return m_AppointmentStatusID
        End Get
        Set(value As String)
            m_AppointmentStatusID = value
        End Set
    End Property

#End Region

End Class

Public Class CurrentPatient

#Region "  Fields  "

    Private Shared m_PatientNo As String
    Private Shared m_VisitNo As String

#End Region

#Region " Properties "

    Public Property PatientNo() As String
        Get
            Return m_PatientNo
        End Get
        Set(value As String)
            m_PatientNo = value
        End Set
    End Property

    Public Property VisitNo() As String
        Get
            Return m_VisitNo
        End Get
        Set(Value As String)
            m_VisitNo = Value
        End Set
    End Property

#End Region

End Class

Public Class CurrentVisit

#Region "  Fields  "

    Private m_PatientNo As String
    Private m_VisitNo As String
    Private m_VisitDate As Date
    Private m_DoctorSpecialtyID As String
    Private m_StaffNo As String
    Private m_VisitCategoryID As String
    Private m_ReferredBy As String
    Private m_ServiceCode As String
    Private m_BillModesID As String
    Private m_BillNo As String
    Private m_MemberCardNo As String
    Private m_MainMemberName As String

#End Region

#Region " Properties "

    Public Property PatientNo() As String
        Get
            Return m_PatientNo
        End Get
        Set(value As String)
            m_PatientNo = value
        End Set
    End Property

    Public Property VisitNo() As String
        Get
            Return m_VisitNo
        End Get
        Set(Value As String)
            m_VisitNo = Value
        End Set
    End Property

    Public Property VisitDate As Date
        Get
            Return m_VisitDate
        End Get
        Set(value As Date)
            m_VisitDate = value
        End Set
    End Property

    Public Property DoctorSpecialtyID() As String
        Get
            Return m_DoctorSpecialtyID
        End Get
        Set(Value As String)
            m_DoctorSpecialtyID = Value
        End Set
    End Property

    Public Property StaffNo() As String
        Get
            Return m_StaffNo
        End Get
        Set(value As String)
            m_StaffNo = value
        End Set
    End Property

    Public Property VisitCategoryID() As String
        Get
            Return m_VisitCategoryID
        End Get
        Set(Value As String)
            m_VisitCategoryID = Value
        End Set
    End Property

    Public Property ReferredBy() As String
        Get
            Return m_ReferredBy
        End Get
        Set(value As String)
            m_ReferredBy = value
        End Set
    End Property

    Public Property ServiceCode() As String
        Get
            Return m_ServiceCode
        End Get
        Set(Value As String)
            m_ServiceCode = Value
        End Set
    End Property

    Public Property BillModesID() As String
        Get
            Return m_BillModesID
        End Get
        Set(value As String)
            m_BillModesID = value
        End Set
    End Property

    Public Property BillNo() As String
        Get
            Return m_BillNo
        End Get
        Set(Value As String)
            m_BillNo = Value
        End Set
    End Property

    Public Property MemberCardNo() As String
        Get
            Return m_MemberCardNo
        End Get
        Set(value As String)
            m_MemberCardNo = value
        End Set
    End Property

    Public Property MainMemberName() As String
        Get
            Return m_MainMemberName
        End Get
        Set(Value As String)
            m_MainMemberName = Value
        End Set
    End Property

#End Region

End Class

Public Class CurrentEnrollmentInformation

#Region " Fields "

    Private m_UCIID As String
    Private m_ReferralStudyCodeID As String
    Private m_EnrolledID As String
    Private m_CoEnrolledID As String
    Private m_CoEnrolledStudyCodeID As String
    Private m_CCInitials As String
    Private m_ExclusionReason As String
    Private m_EnrollmentDate As Date
    Private m_PatientReferred As String
    Private m_ReferredDate As Date

#End Region

#Region " Properties "

    Public Property UCIID() As String
        Get
            Return m_UCIID
        End Get
        Set(Value As String)
            m_UCIID = Value
        End Set
    End Property

    Public Property ReferralStudyCodeID() As String
        Get
            Return m_ReferralStudyCodeID
        End Get
        Set(Value As String)
            m_ReferralStudyCodeID = Value
        End Set
    End Property

    Public Property EnrolledID() As String
        Get
            Return m_EnrolledID
        End Get
        Set(Value As String)
            m_EnrolledID = Value
        End Set
    End Property

    Public Property CoEnrolledID() As String
        Get
            Return m_CoEnrolledID
        End Get
        Set(Value As String)
            m_CoEnrolledID = Value
        End Set
    End Property

    Public Property CoEnrolledStudyCodeID() As String
        Get
            Return m_CoEnrolledStudyCodeID
        End Get
        Set(Value As String)
            m_CoEnrolledStudyCodeID = Value
        End Set
    End Property

    Public Property CCInitials() As String
        Get
            Return m_CCInitials
        End Get
        Set(Value As String)
            m_CCInitials = Value
        End Set
    End Property

    Public Property ExclusionReason() As String
        Get
            Return m_ExclusionReason
        End Get
        Set(Value As String)
            m_ExclusionReason = Value
        End Set
    End Property

    Public Property EnrollmentDate() As Date
        Get
            Return m_EnrollmentDate
        End Get
        Set(Value As Date)
            m_EnrollmentDate = Value
        End Set
    End Property

    Public Property PatientReferred() As String
        Get
            Return m_PatientReferred
        End Get
        Set(Value As String)
            m_PatientReferred = Value
        End Set
    End Property

    Public Property ReferredDate() As Date
        Get
            Return m_ReferredDate
        End Get
        Set(Value As Date)
            m_ReferredDate = Value
        End Set
    End Property

#End Region

End Class

Public Enum AutoNumber As Short

    VisitNo = 1
    SpecimenNo = 2
    VisitNoCurrentlyOnART = 3
    AdmissionNo = 4
    RoundNo = 5
    ClaimNo = 6
    ExtraBillNo = 7
    OutwardNo = 8
    VARoundNo = 9
    NurseRoundNo = 10
    ANCNo = 11
    RefundRequestNo = 12
End Enum

Public Enum AlertItemCategory As Short

    Service = 1
    Drug = 2
    Procedure = 3
    Test = 4
    Radiology = 5
    Extras = 6
    CashPayment = 7
    Dental = 8
    Theatre = 9
    Optical = 10
    Maternity = 11
    ICU = 12
    RadiologyProcessing = 13
    Consumable = 14
    Pathology = 15
    PathologyProcessing = 16
    Internal = 17
    External = 18

    Cardiology = 19
    CardiologyProcessing = 20

End Enum

Public Enum ObjectName As Short

    SchemeMembers = 1
    PatientNo = 2
    InvoiceNo = 4

End Enum

Public Enum ItemsTo As Short

    Order = 1
    Expire = 2

End Enum

Public Enum PendingVisit As Short

    Files = 1
    Triage = 2
    VisionAssessment = 3

End Enum

Public Structure ProductOwner

    Public Address As String
    Public Phone As String
    Public AlternatePhone As String
    Public Fax As String
    Public Email As String
    Public AlternateEmail As String
    Public Website As String
    Public Photo As Image
    Public AlternatePhoto As Image
    Public ProductVersion As String
    Public TINNo As String
    Public VATNo As String
    Public PrintHeaderAlignmentID As String
    Public LogoTopMargin As Integer
    Public TextTopMargin As Integer
    Public LogoLeftMargin As Integer
    Public TextLeftMargin As Integer

End Structure

Public Structure Insurances

    Public InsuranceName As String
    Public Address As String
    Public Phone As String
    Public Fax As String
    Public Email As String
    Public Website As String
    Public LogoPhoto As Image
    Public MemberDeclaration As String
    Public DoctorDeclaration As String

End Structure

Public Structure BillCustomers

    Public BillCustomerName As String
    Public Address As String
    Public Phone As String
    Public Fax As String
    Public Email As String
    Public Website As String
    Public LogoPhoto As Image
    Public MemberDeclaration As String
    Public DoctorDeclaration As String

End Structure

Public Structure SmartCardMembers

    Public CardSerialNumber As String
    Public Id As Integer
    Public MemberNr As String
    Public LocationID As Integer
    Public GlobalID As String
    Public AdmitID As String
    Public SmartDate As Date
    Public FirstName As String
    Public Surname As String
    Public Gender As String
    Public MiddleName As String
    Public BirthDate As Date
    Public SmartTime As String
    Public SchemeExpiryDate As Date
    Public SchemeCode As String
    Public SchemePlan As String
    Public MedicalCardNumber As String
    Public CoverNumber As String
    Public ServiceDescription As String
    Public CoverAmount As Decimal
    Public TotalBill As Decimal
    Public TotalServices As Integer
    Public InvoiceNo As String
    Public Role As String
    Public CountryCode As String
    Public PracticeNo As String
    Public PracticeName As String
    Public PreAuthorizationNo As Integer
    Public PreAuthorizationAmount As Decimal
    Public CopayType As String
    Public CopayAmount As Decimal
    Public Dependant As String

End Structure

Public Structure SmartCardItems

    Public TransactionDate As String
    Public TransactionTime As String
    Public ServiceProviderNr As String
    Public DiagnosisCode As String
    Public DiagnosisDescription As String
    Public EncounterType As String
    Public CodeType As String
    Public Code As String
    Public CodeDescription As String
    Public Quantity As String
    Public Amount As String

End Structure

Public Structure ExternalLabResults

    Public Shared Results As New Dictionary(Of String, String)

End Structure

Public Enum ItemsKeyNo As Short

    PatientNo = 1
    VisitNo = 2
    'continuation from ClinicMasterMOH
    UCIID = 4

End Enum

Public Structure InventoryOrders
    Public Shared Values As New Dictionary(Of String, String)()
    Public Shared DrugNo As New ArrayList
    Public Shared DrugName As New ArrayList
End Structure

Public Structure PurchaseOrders
    Public Shared Values As New Dictionary(Of String, String)()
End Structure

Public Structure PharmacyPrescription
    Public Shared Balance As New Dictionary(Of Integer, Integer)()
    Public Shared Quantity As New Dictionary(Of Integer, Integer)()
    Public Shared DrQuantity As New Dictionary(Of Integer, Integer)()
End Structure

Public Structure GRNBalance
    Public Shared Balance As New Dictionary(Of Integer, Integer)()
End Structure

Public Structure frequentlyRequestedTests
    Public Shared Values As New Dictionary(Of String, String)()
End Structure

Public Structure frequentlyPrescribedDrugs
    Public Shared Values As New Dictionary(Of String, String)()
End Structure

Public Structure BillAdjustments
    Public Shared Keys As New Dictionary(Of Integer, String)()
    Public Shared values As New Dictionary(Of Integer, String)()
End Structure

Public Structure PeriodicClaims
    Public Shared values As New Dictionary(Of Integer, String)()
End Structure


Public Class TMCGSMSAPI

    Public Sub SendBulkSMSWithTMCG(ByVal MessageNo As String, ByVal phonenumber As String, ByVal message As String)

        Try
            Dim oSentID As New LookupDataID.YesNoID()
            Dim oflagID As New LookupDataID.ResultFlagID()
            Dim oIntegrationAgent As New LookupDataID.IntegrationAgents()
            Dim oBulkMessaging As New SyncSoft.SQLDb.BulkMessaging()
            Dim token As String = GetIntegrationAgentPassword(oIntegrationAgent.TMCG)
            Dim myReq As HttpWebRequest
            myReq = DirectCast(WebRequest.Create("https://hiwa.tmcg.co.ug/api/v2/broadcasts.json"), HttpWebRequest)
            myReq.Method = "POST"
            myReq.ContentType = "application/json"
            myReq.Headers("Authorization") = "Token " + token
            Dim urns As String = "" + """urns"""
            Dim phoneNo As String = "[" & "" + """tel:" & phonenumber & """]"
            Dim msg As String = """text"" :""" + message + """"
            Dim myData As String = "{" & urns & ": " & phoneNo & "," & msg & "}"
            myReq.GetRequestStream.Write(System.Text.Encoding.UTF8.GetBytes(myData), 0, System.Text.Encoding.UTF8.GetBytes(myData).Length)
            Dim response As Stream = myReq.GetResponse().GetResponseStream()
            Dim reader As New StreamReader(response)
            Dim res As String = reader.ReadToEnd

            If res.Contains("created_on") = True Then
                With oBulkMessaging
                    .MessageNo = MessageNo
                    .Phone = phonenumber
                    .Message = message
                    .flagID = oflagID.High
                    .SentID = oSentID.Yes
                    .LoginID = CurrentUser.LoginID
                    .SendDateTime = Now

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End With

                oBulkMessaging.Save()
                reader.Close()
                response.Close()

            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class


Public Class HamweSMSAPI

    Public Sub SendBulkSMSWithHamwe(ByVal message As String, ByVal msisdn As String)
        Try



            Dim oSentID As New LookupDataID.YesNoID()
            Dim oflagID As New LookupDataID.ResultFlagID()
            Dim oBulkMessaging As New SyncSoft.SQLDb.BulkMessaging()
            Dim oIntegrationAgent As New LookupDataID.IntegrationAgents()
            Dim Uri As Uri
            Dim myUrl As String
            Dim contentType As String
            Dim method As String
            Dim token As String = GetIntegrationAgentPassword(oIntegrationAgent.HAMWE)
            Dim jsonString As String = "{""token"" : """ + token + """, ""purpose"" : ""BULKSMS"", ""message"" : """ + message + """, ""msisdn"" : """ + msisdn + """}"
            myUrl = "http://sms.hamwe.org/bsapirq/"
            contentType = "application/json"
            method = "POST"

            Uri = New Uri(myUrl)
            Dim jsonDataBytes As Byte() = Encoding.UTF8.GetBytes(jsonString)

            Dim req As WebRequest = WebRequest.Create(Uri)
            req.ContentType = contentType
            req.Method = method
            req.ContentLength = jsonDataBytes.Length

            Dim stream As Stream = req.GetRequestStream()
            stream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
            stream.Close()
            Dim response As Stream = req.GetResponse().GetResponseStream()
            Dim reader As New StreamReader(response)
            Dim res As String = reader.ReadToEnd()

            If res.Contains("OK") = True Then
                With oBulkMessaging
                    .MessageNo = msisdn
                    .Phone = msisdn
                    .Message = message
                    .flagID = oflagID.High
                    .SentID = oSentID.Yes
                    .LoginID = CurrentUser.LoginID
                    .SendDateTime = Now

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End With

                oBulkMessaging.Save()
                reader.Close()
                response.Close()

            End If


        Catch ex As Exception
        End Try
    End Sub

End Class

Public Class AfroSMS

    Public Sub SendSMSViaAfroSMS(ByVal MessageNo As String, ByVal message As String, ByVal destination As String)

        Dim oSentID As New LookupDataID.YesNoID()
        Dim oflagID As New LookupDataID.ResultFlagID()
        Dim oBulkMessaging As New SyncSoft.SQLDb.BulkMessaging()
        Dim oIntegrationAgent As New LookupDataID.IntegrationAgents()
        Try


            Dim Uri As Uri
            Dim myUrl As String
            Dim contentType As String
            Dim method As String
            Dim source As String = "afrosms"
            Dim mcall As String = "sendsms"
            Dim email As String = GetIntegrationAgentUserName(oIntegrationAgent.AFROSMS)
            Dim password As String = GetIntegrationAgentPassword(oIntegrationAgent.AFROSMS)
            Dim jsonString As String = "email=" & email & "&message=" & message & "&password=" & password & "&destination=" & destination & "&source=" & source & "&call=" & mcall
            myUrl = "http://www.afrosms.ug/smskings/api.php"
            contentType = "application/x-www-form-urlencoded"
            method = "POST"

            Uri = New Uri(myUrl)
            Dim jsonDataBytes As Byte() = Encoding.UTF8.GetBytes(jsonString)

            Dim req As WebRequest = WebRequest.Create(Uri)
            req.ContentType = contentType
            req.Method = method
            req.ContentLength = jsonDataBytes.Length

            Dim stream As Stream = req.GetRequestStream()
            stream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
            stream.Close()
            Dim response As Stream = req.GetResponse().GetResponseStream()
            Dim reader As New StreamReader(response)
            Dim res As String = reader.ReadToEnd

            If res.Contains("Submitted") = True Then
                With oBulkMessaging
                    .MessageNo = MessageNo
                    .Phone = destination
                    .Message = message
                    .flagID = oflagID.High
                    .SentID = oSentID.Yes
                    .LoginID = CurrentUser.LoginID
                    .SendDateTime = Now

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End With

                oBulkMessaging.Save()
                reader.Close()
                response.Close()

            End If

        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

End Class

Public Class JOLIS

    Public Sub SendSMSViaJolis(ByVal MessageNo As String, ByVal sendto As String, ByVal from As String, ByVal message As String)
        Try
            Dim oSentID As New LookupDataID.YesNoID()
            Dim oflagID As New LookupDataID.ResultFlagID()
            Dim oIntegrationAgent As New LookupDataID.IntegrationAgents()
            Dim oBulkMessaging As New SyncSoft.SQLDb.BulkMessaging()
            Dim Uri As Uri
            Dim myUrl As String
            Dim contentType As String
            Dim method As String
            Dim username As String = GetIntegrationAgentUserName(oIntegrationAgent.JOLIS)
            Dim password As String = GetIntegrationAgentPassword(oIntegrationAgent.JOLIS)
            Dim IS_GET As String = "3"
            Dim action As String = "broadcast"
            Dim command As String = "vsms"
            Dim jsonString As String = "username=" & username & "&password=" & password & "&IS_GET=" & IS_GET & "&command=" & command & "&action=" & action & "&to=" & sendto & "&from=" & from & "&message=" & message
            myUrl = "https://secure.jolis.net/api.php"
            contentType = "application/x-www-form-urlencoded"
            method = "POST"

            Uri = New Uri(myUrl)
            Dim jsonDataBytes As Byte() = Encoding.UTF8.GetBytes(jsonString)

            Dim req As WebRequest = WebRequest.Create(Uri)
            req.ContentType = contentType
            req.Method = method
            req.ContentLength = jsonDataBytes.Length

            Dim stream As Stream = req.GetRequestStream()
            stream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
            stream.Close()
            Dim response As Stream = req.GetResponse().GetResponseStream()
            Dim reader As New StreamReader(response)
            Dim res As String = reader.ReadToEnd
            MsgBox(res)
            If res.Contains("SUCCESS") = True Then
                With oBulkMessaging
                    .MessageNo = MessageNo
                    .Phone = sendto
                    .Message = message
                    .flagID = oflagID.High
                    .SentID = oSentID.Yes
                    .LoginID = CurrentUser.LoginID
                    .SendDateTime = Now

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End With

                oBulkMessaging.Save()
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub
End Class

Module SendSMS

    Public Sub SaveTextMessage(ByVal message As String, ByVal msisdn As String, ByVal sendDate As Date, ByVal textLifeSpan As Integer)
        Dim oSentID As New LookupDataID.YesNoID()
        Dim oflagID As New LookupDataID.ResultFlagID()
        Dim oBulkMessaging As New SyncSoft.SQLDb.BulkMessaging()
        Try


            With oBulkMessaging
                .MessageNo = GetNextMessageNo()
                .Phone = msisdn
                .Message = message
                .flagID = oflagID.Normal
                .SentID = oSentID.No
                .LoginID = CurrentUser.LoginID
                .SendDateTime = sendDate
                .TextLifeSpan = textLifeSpan

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End With

            oBulkMessaging.Save()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Public Sub TextMessageWithAPI001(ByVal message As String, ByVal msisdn As String)

        Try
            'Dim gateway As New HamweSMSAPI
            '' Dim oAPI001 As New LookupDataID.SMSAPI001
            'Dim TOKEN As String = GetLookupDataDes(oAPI001.SMSAPI001)
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'gateway.SendBulkSMSWithHamwe(message, msisdn, TOKEN)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception

        Finally


        End Try
    End Sub

    Public Sub TextMessageWithAPI002(ByVal MessageNo As String, ByVal message As String, ByVal msisdn As String)

        Try
            Dim gateway As New JOLIS

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            gateway.SendSMSViaJolis(MessageNo, msisdn, msisdn, message)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception

        Finally


        End Try
    End Sub

    Public Sub TextMessageWithAPI003(ByVal messageNo As String, ByVal message As String, ByVal msisdn As String)

        Try
            Dim gateway As New AfroSMS

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            gateway.SendSMSViaAfroSMS(messageNo, message, msisdn)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception

        Finally


        End Try
    End Sub

    Public Sub TextMessageWithAPI004(ByVal messageNo As String, ByVal message As String, ByVal msisdn As String)

        Try
            Dim gateway As New TMCGSMSAPI
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            gateway.SendBulkSMSWithTMCG(messageNo, msisdn, message)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception

        Finally


        End Try
    End Sub

    Public Sub LoadTimelySMSIncomeSummaries()

        Dim oVariousOptions As New VariousOptions()
        Dim oYesNoID As New LookupDataID.YesNoID
        Dim TimeEnd As DateTime = CDate(oVariousOptions.IncomeSummariesSMSTime())
        Dim TimeEnd2 As DateTime = CDate(oVariousOptions.IncomeSummariesSMSTime2())
        Dim ftoday As String = ((Date.Today) + " " + TimeEnd)
        Dim flastday As String = ((Date.Today) + " " + TimeEnd2)
        Dim previousDay As String = ((Today.AddDays(-1)) + " " + TimeEnd2)

        Dim oPayments As New SyncSoft.SQLDb.Payments()
        Dim oAccounts As New SyncSoft.SQLDb.Accounts()
        Dim oOtherIncomes As New SyncSoft.SQLDb.OtherIncome()
        Dim oExpenditure As New SyncSoft.SQLDb.Expenditure()

        Dim oManagerPhoneNumberID As New LookupDataID.ManagerPhoneNumber()
        Dim receiptient As String = GetLookupDataDes(oManagerPhoneNumberID.CEO)

        ' Load first Message
        'Gets Cash collected from Yesterday's last time to today's first time



        'payments 
        Dim payments As DataTable = oPayments.GetTimelySMSIncomeSummaries(CDate(previousDay), CDate(ftoday)).Tables("Payments")
        Dim row As DataRow = payments.Rows(0)
        Dim finalMoneystring As String = (StringMayBeEnteredIn(row, "finalMoney"))
        'deposits
        Dim deposits As DataTable = oAccounts.GetTimelyAccountsSMS(CDate(previousDay), CDate(ftoday)).Tables("Accounts")
        Dim depositsrow As DataRow = deposits.Rows(0)
        Dim depositsfinalMoneystring As String = (StringMayBeEnteredIn(depositsrow, "AccountsfinalMoney"))

        '  otherincomes()
        Dim otherincomes As DataTable = oOtherIncomes.GetTimelySMSOtherIncomes(CDate(previousDay), CDate(ftoday)).Tables("OtherIncome")
        Dim otherincomesrow As DataRow = otherincomes.Rows(0)
        Dim otherincomesMoneystring As String = (StringMayBeEnteredIn(otherincomesrow, "depositsfinalMoney"))

        '  expenditure()
        Dim expenditure As DataTable = oExpenditure.GetTimelySMSExpenditure(CDate(previousDay), CDate(ftoday)).Tables("Expenditure")
        Dim expenditurerow As DataRow = expenditure.Rows(0)
        Dim expenditureMoneystring As String = (StringMayBeEnteredIn(expenditurerow, "expenditurefinalMoney"))

        'Load Second Message
        ' Gets cash collected between the 1st and 2nd time for today only

        Dim Secondpayments As DataTable = oPayments.GetTimelySMSIncomeSummaries(CDate(ftoday), CDate(flastday)).Tables("Payments")
        Dim secondrow As DataRow = Secondpayments.Rows(0)
        Dim finalSecondMoneystring As String = (StringMayBeEnteredIn(secondrow, "finalMoney"))

        'deposits
        Dim seconddeposits As DataTable = oAccounts.GetTimelyAccountsSMS(CDate(ftoday), CDate(flastday)).Tables("Accounts")
        Dim seconddepositsrow As DataRow = seconddeposits.Rows(0)
        Dim seconddepositsfinalMoneystring As String = (StringMayBeEnteredIn(seconddepositsrow, "AccountsfinalMoney"))


        '  otherincomes()
        Dim secondotherincomes As DataTable = oOtherIncomes.GetTimelySMSOtherIncomes(CDate(ftoday), CDate(flastday)).Tables("OtherIncome")
        Dim secondotherincomesrow As DataRow = secondotherincomes.Rows(0)
        Dim secondotherincomesMoneystring As String = (StringMayBeEnteredIn(secondotherincomesrow, "depositsfinalMoney"))

        '  expenditure()
        Dim secondexpenditure As DataTable = oExpenditure.GetTimelySMSExpenditure(CDate(ftoday), CDate(flastday)).Tables("Expenditure")
        Dim secondexpenditurerow As DataRow = secondexpenditure.Rows(0)
        Dim secondexpenditureMoneystring As String = (StringMayBeEnteredIn(secondexpenditurerow, "expenditurefinalMoney"))

        '
        Dim productOwner As String = AppData.ProductOwner
        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oVariousOptions.SMSNotificationForIncomeSummaries Then
                If TimeOfDay.Equals(TimeEnd) Then
                    Dim txtmessage As String = ("Payments made at " + productOwner + " " + "Between " + " " + FormatDateTime(previousDay) + " " + "& " + " " + FormatDateTime(ftoday) + "; " + " " + "Bill Payments : " + finalMoneystring + " " + "; " + " " + "Deposits : " + depositsfinalMoneystring + " " + "; " + " " + "Other Incomes : " + otherincomesMoneystring + " " + "Expenditure : " + expenditureMoneystring + "; " + "-Via ClinicMaster")
                    SaveTextMessage(txtmessage, receiptient, Now, oVariousOptions.SMSLifeSpanIncomeSummaries)

                End If
            End If



            If oVariousOptions.SMSNotificationForIncomeSummaries Then
                If TimeOfDay.Equals(TimeEnd2) Then
                    Dim txtmessage As String = ("Payments made at " + productOwner + " " + "Between " + " " + FormatDateTime(ftoday) + " " + "& " + " " + FormatDateTime(flastday) + "; " + " " + "Bill Payments : " + finalSecondMoneystring + " " + "; " + " " + "Deposits : " + seconddepositsfinalMoneystring + " " + "; " + " " + "Other Incomes : " + secondotherincomesMoneystring + " " + "Expenditure : " + secondexpenditureMoneystring + "; " + "-Via ClinicMaster")
                    SaveTextMessage(txtmessage, receiptient, Now, oVariousOptions.SMSLifeSpanIncomeSummaries)

                End If
            End If



            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception


        End Try


    End Sub

End Module

Module DataSecurity

    Private Function GetBytes(key As String) As Byte()
        Return ASCIIEncoding.ASCII.GetBytes(key)
    End Function

    ''' <summary>
    ''' Encrypts the supplied text with the supplied 8 character lenght key 
    ''' </summary>
    ''' <param name="text"></param>
    ''' <param name="key"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Encrypt(text As String, key As String) As String

        Try

            Dim _cryptoProvider As New DESCryptoServiceProvider()
            Dim _memoryStream As New MemoryStream()
            Dim _cryptoStream As CryptoStream = New CryptoStream(_memoryStream, _cryptoProvider.CreateEncryptor(GetBytes(key), GetBytes(key)), CryptoStreamMode.Write)

            Dim writer As StreamWriter = New StreamWriter(_cryptoStream)

            writer.Write(text)
            writer.Flush()
            _cryptoStream.FlushFinalBlock()
            writer.Flush()

            Return System.Convert.ToBase64String(_memoryStream.GetBuffer(), 0, CInt(_memoryStream.Length))

        Catch ex As Exception
            ErrorMessage(ex)
            Return text

        End Try

    End Function

    ''' <summary>
    ''' Encrypts the supplied text with system 8 character lenght key 
    ''' </summary>
    ''' <param name="text"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Encrypt(text As String) As String
        Return Encrypt(text, "SyncSoft")
    End Function

    ''' <summary>
    ''' Decrypts the supplied encrypted text with the supplied 8 character lenght key 
    ''' </summary>
    ''' <param name="text"></param>
    ''' <param name="key"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Decrypt(text As String, key As String) As String

        Try

            Dim cryptoProvider As New DESCryptoServiceProvider()
            Dim _memoryStream As MemoryStream = New MemoryStream(System.Convert.FromBase64String(text))
            Dim _cryptoStream As CryptoStream = New CryptoStream(_memoryStream, cryptoProvider.CreateDecryptor(GetBytes(key), GetBytes(key)), CryptoStreamMode.Read)

            Dim reader As StreamReader = New StreamReader(_cryptoStream)

            Return reader.ReadToEnd()

        Catch ex As Exception
            ErrorMessage(ex)
            Return text

        End Try

    End Function

    ''' <summary>
    ''' Decrypts the supplied encrypted text with system 8 character lenght key 
    ''' </summary>
    ''' <param name="text"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Decrypt(text As String) As String
        Return Decrypt(text, "SyncSoft")
    End Function

End Module

Module QueManagement

    Public Function GetQueuesList(ByVal visitNo As String, ByVal currentServicePoint As String, ByVal visitPriority As String, ByVal lservicePoints As List(Of String)) As List(Of DBConnect)

        lservicePoints.Add(currentServicePoint)

        Dim lQueues As New List(Of DBConnect)
        Dim queueStatus As Boolean = True
        For i As Integer = 0 To lservicePoints.Count() - 1
            Dim servicePointID As String = lservicePoints.ElementAt(i)
            If (currentServicePoint.Equals(servicePointID)) Then
                queueStatus = False
            End If

            Using oQueue As New SyncSoft.SQLDb.Queues()
                With oQueue

                    .VisitNo = visitNo
                    .ServicePointID = servicePointID
                    .CurrentServicePointID = currentServicePoint
                    .PriorityID = visitPriority
                    .QueueStatus = queueStatus
                    .LoginID = CurrentUser.LoginID

                End With

                lQueues.Add(oQueue)
            End Using
        Next
        Return lQueues
    End Function

    Public Sub SaveQueuedMessage(ByVal visitNo As String, ByVal servicePointID As String, ByVal tokenNo As String, ByVal readCount As Integer)

        Dim oQueuedMessages As New SyncSoft.SQLDb.QueuedMessages()

        Try
            With oQueuedMessages

                .VisitNo = visitNo
                .ServicePointID = servicePointID
                .TokenNo = tokenNo
                .ReadCount = readCount
                .RoomNameID = GetNotNullRoomName(servicePointID)
                .LoginID = CurrentUser.LoginID
                .RecordDateTime = Now()

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            oQueuedMessages.Save()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Public Function GetNotNullRoomName(ByVal servicePoint As String) As String

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(InitOptions.RoomName) Then
                Return servicePoint

            Else
                Return GetLookupDataID(LookupObjects.RoomName, InitOptions.RoomName)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            Return servicePoint

        End Try


    End Function

    Public Function GetServicePointQueue() As String


        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(InitOptions.ServicePointQueue) Then
                Return String.Empty

            Else
                Return GetLookupDataID(LookupObjects.ServicePoint, InitOptions.ServicePointQueue)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            Return String.Empty

        End Try


    End Function

    Public Function GetBranchID() As String

        Return GetStaffCurrentBranch(CurrentUser.LoginID)

    End Function

    Public Function IsQueueEnabled() As Boolean
        Dim oVariousOption As New VariousOptions()
        Return oVariousOption.EnableQueue
    End Function

End Module

Module EasyWork

    Public Sub HideGridComponets(controls As DataGridViewColumn(), enabled As Boolean)
        For Each control As DataGridViewColumn In controls
            control.Visible = enabled
        Next
    End Sub

    Public Sub DisableGridComponets(controls As DataGridViewColumn(), enabled As Boolean)
        For Each control As DataGridViewColumn In controls
            control.ReadOnly = enabled

        Next
    End Sub

    Public Sub SavePrintDetails(ByVal patientNo As String, ByVal docNo As String, ByVal printdesc As String, ByVal printcategoryID As String)
        Dim oPrintDetails As New SyncSoft.SQLDb.PrintDetails()
        Try
            With oPrintDetails

                .PatientNo = patientNo
                .DocumentNo = docNo
                .PrintDesc = printdesc
                .PrintCategoryID = printcategoryID
                .LoginID = CurrentUser.LoginID


            End With

            oPrintDetails.Save()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception

        End Try
    End Sub

    'Public Function IsItemCatgoryInvoiceListExcluded(itemCagoryID As String) As Boolean
    '    Dim oVariousOptions As New VariousOptions()
    '    Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
    '    If oVariousOptions.GenerateInventoryInvoiceOnDispensingOnly() Then

    '        If itemCagoryID.ToUpper().Equals(oItemCategoryID.Drug().ToUpper()) OrElse itemCagoryID.ToUpper().Equals(oItemCategoryID.Consumable().ToUpper()) Then
    '            Return True
    '        Else : Return False
    '        End If

    '    Else : Return False
    '    End If

    'End Function

    Public Function GetNextInvoiceNo() As String

        Dim yearL2 As String = Today.Year.ToString().Substring(2)
        Dim invoiceNo As String = String.Empty
        Try


            Dim oInvoices As New SyncSoft.SQLDb.Invoices()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Invoices", "InvoiceNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))
            invoiceNo = yearL2 + oInvoices.GetNextInvoiceID.ToString().PadLeft(paddingLEN, paddingCHAR)



        Catch ex As Exception
            ErrorMessage(ex)

        Finally


        End Try
        Return invoiceNo
    End Function

    Public Sub LoadchartAccounts(cboBox As ComboBox)

        Dim oChartAccounts As New SyncSoft.SQLDb.ChartAccounts()

        Try



            Dim chartAccounts As DataTable = oChartAccounts.GetChartAccounts().Tables("ChartAccounts")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With cboBox
                .DataSource = Nothing
                .DataSource = chartAccounts
                .ValueMember = "AccountNo"
                .DisplayMember = "AccountName"
            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally


        End Try

    End Sub



    Public Sub LoadchartOfAccountsCategory(cboBox As ComboBox, categoryNo As String)

        Dim oChartAccounts As New SyncSoft.SQLDb.ChartAccounts()

        Try


            ' Load all from Sub Categories

            Dim ChartAccounts As DataTable = oChartAccounts.GetChartAccountsByCategory(categoryNo).Tables("ChartAccounts")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With cboBox
                .DataSource = Nothing
                .DataSource = ChartAccounts
                .ValueMember = "AccountNo"
                .DisplayMember = "AccountName"
            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally


        End Try

    End Sub

    Public Sub LoadchartOfAccountsType(cboBox As ComboBox, accoutType As String)

        Dim oChartAccounts As New SyncSoft.SQLDb.ChartAccounts()

        Try


            ' Load all from Sub Categories

            Dim ChartAccounts As DataTable = oChartAccounts.GetChartAccountsByType(accoutType).Tables("ChartAccounts")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With cboBox
                .DataSource = Nothing
                .DataSource = ChartAccounts
                .ValueMember = "AccountNo"
                .DisplayMember = "AccountName"
                .SelectedIndex = -1
            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally


        End Try

    End Sub


    Public Sub SetComboDefaultValue(optionName As String, comboBox As ComboBox, objectID As Integer)

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(optionName) AndAlso Not optionName.Equals("NA") Then
                comboBox.SelectedValue = GetLookupDataID(objectID, optionName)
                comboBox.Enabled = False
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        End Try


    End Sub


    Public Function GetSmartFileTable(patientNo As String, macAddress As String) As DataTable
        Try
            Dim oIntegrationAgent As New LookupDataID.IntegrationAgents()
            Dim oMysqlConnect As New MySqlConnect(oIntegrationAgent.SMART)
            Dim commandText As String = "uspGetExchangeFile"
            Dim pairs As New List(Of KeyValuePair(Of String, Object))
            pairs.Add(New KeyValuePair(Of String, Object)("PatientNo", patientNo))
            pairs.Add(New KeyValuePair(Of String, Object)("MacAddress", macAddress))
            Return oMysqlConnect.GetData(commandText, pairs)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetSmartFileTableByID(_ID As Integer) As DataTable
        Try
            Dim oIntegrationAgent As New LookupDataID.IntegrationAgents()
            Dim oMysqlConnect As New MySqlConnect(oIntegrationAgent.SMART)
            Dim commandText As String = "uspGetExchangeFileByID"
            Dim pairs As New List(Of KeyValuePair(Of String, Object))
            pairs.Add(New KeyValuePair(Of String, Object)("_ID", _ID))

            Dim dataTable As DataTable = oMysqlConnect.GetData(commandText, pairs)
            Return dataTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function EditSmartData(id As Integer, document As String) As Boolean
        Dim oIntegrationAgent As New LookupDataID.IntegrationAgents()
        Dim oMysqlConnect As New MySqlConnect(oIntegrationAgent.SMART)
        Dim pairs As New List(Of KeyValuePair(Of String, Object))
        pairs.Add(New KeyValuePair(Of String, Object)("_id", id))
        pairs.Add(New KeyValuePair(Of String, Object)("exchangeFile", document))
        pairs.Add(New KeyValuePair(Of String, Object)("exchangeDate", Today))

        Try
            Dim storedProcedureName As String = "uspUpdateExchangeFile"
            Return oMysqlConnect.EditData(storedProcedureName, pairs)


        Catch ex As Exception
            ErrorMessage(ex)
            Throw ex
        End Try


    End Function

    Public Sub OpenBillableMappings(buttonCaption As SyncSoft.Common.Win.Controls.ButtonCaption, itemCategoryID As String, itemCode As String)
        Try
            Dim oVariousOptions As New VariousOptions()
            If oVariousOptions.ForceBillableMappings Then
                Dim fLoadBillableMappings As New frmBillableMappings(itemCode, itemCategoryID)
                
                Select Case buttonCaption
                    Case SyncSoft.Common.Win.Controls.ButtonCaption.Save

                    Case (SyncSoft.Common.Win.Controls.ButtonCaption.Update)
                        fLoadBillableMappings.Edit()
                        fLoadBillableMappings.LoadDefaultData()
                        fLoadBillableMappings.LoadBillableMappings(itemCategoryID, itemCode)

                End Select
                fLoadBillableMappings.ShowDialog()
                If Not fLoadBillableMappings.IsSaved() Then Throw New ArgumentException("You must complete billable mappings to continue")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function AgentExists(AgentNo As String) As Boolean
        Try
            Dim oINTAgents As New INTAgents()
            Dim intAgents As DataTable = oINTAgents.GetINTAgents(AgentNo).Tables("INTAgents")
            Return intAgents.Rows.Count > 0
        Catch ex As Exception
            Return False
        End Try
    End Function



End Module

Public Class MySqlConnect

    Private connection As MySql.Data.MySqlClient.MySqlConnection


    Public Sub New(agentID As String)
        Try
            Dim oINTAgents As New INTAgents()
            Dim _INTAgents As DataTable = oINTAgents.GetINTAgents(agentID).Tables("INTAgents")
            Dim row As DataRow = _INTAgents.Rows(0)
            Dim dataSource As String = StringEnteredIn(row, "DataSource")
            Dim port As Integer = IntegerMayBeEnteredIn(row, "Port")
            Dim _DBName As String = StringEnteredIn(row, "DBName")
            Dim username As String = StringEnteredIn(row, "Username")
            Dim password As String = Decrypt(StringEnteredIn(row, "Password"))

            Dim mySQLConnectionString As String = "Persist Security Info=False;datasource=" + dataSource + ";port=" + port.ToString() + ";username=" + username + ";password=" + password + ";database=" + _DBName + ""


            connection = New MySql.Data.MySqlClient.MySqlConnection(mySQLConnectionString)

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub New(serverName As String, port As String, userName As String, password As String, databaseName As String)
        Try

            Dim mySQLConnectionString As String = "Persist Security Info=False;datasource=" + serverName + ";port=" + port + ";username=" + userName + ";password=" + password + ";database=" + databaseName + ""
            connection = New MySql.Data.MySqlClient.MySqlConnection(mySQLConnectionString)

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Function EditData(storedProcedureName As String) As Boolean


        Try

            Me.connection.Open()

            Dim command As New MySql.Data.MySqlClient.MySqlCommand(storedProcedureName, Me.connection)
            command.CommandType = CommandType.StoredProcedure
            command.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            Throw ex
            Return False
        Finally
            Me.connection.Close()
        End Try

    End Function


    Public Function EditData(storedProcedureName As String, pairs As List(Of KeyValuePair(Of String, Object))) As Boolean


        Try

            Me.connection.Open()

            Dim command As New MySql.Data.MySqlClient.MySqlCommand(storedProcedureName, Me.connection)
            command.CommandType = CommandType.StoredProcedure
            For Each pair As KeyValuePair(Of String, Object) In pairs
                command.Parameters.Add(New MySqlParameter(pair.Key, pair.Value))
            Next
            command.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            Throw ex
            Return False
        Finally
            Me.connection.Close()
        End Try

    End Function


    Public Function GetData(storedProcedureName As String) As DataTable
        Dim dataTable As New DataTable()
        Try

            Me.connection.Open()
            Dim command As New MySql.Data.MySqlClient.MySqlCommand(storedProcedureName, Me.connection)
            command.CommandType = CommandType.StoredProcedure

            Dim myAdapter As New MySql.Data.MySqlClient.MySqlDataAdapter(command)

            Dim dataset As New DataSet()
            myAdapter.Fill(dataTable)
            Return dataTable
        Catch ex As Exception
            Throw ex
        Finally
            Me.connection.Close()
        End Try

    End Function

    Public Function GetData(storedProcedureName As String, pairs As List(Of KeyValuePair(Of String, Object))) As DataTable
        Dim dataTable As New DataTable()
        Try

            Me.connection.Open()
            Dim command As New MySql.Data.MySqlClient.MySqlCommand(storedProcedureName, Me.connection)
            command.CommandType = CommandType.StoredProcedure

            For Each pair As KeyValuePair(Of String, Object) In pairs
                command.Parameters.Add(New MySqlParameter(pair.Key, pair.Value))
            Next

            Dim myAdapter As New MySql.Data.MySqlClient.MySqlDataAdapter(command)

            Dim dataset As New DataSet()
            myAdapter.Fill(dataTable)


        Catch ex As Exception
            Throw ex
        Finally
            Me.connection.Close()
        End Try
        Return dataTable
    End Function

   
End Class




