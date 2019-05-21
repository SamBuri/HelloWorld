
Option Strict On

Imports SyncSoft.Security.SQL
Imports SyncSoft.SQL.Win.Forms
Imports SyncSoft.Common.Classes
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Win.Forms
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Methods


Public Module Program

#Region " Fields "

    Private m_GradientColorOne As Color = SystemColors.AppWorkspace
    Private m_GradientColorTwo As Color = Color.LightSkyBlue
    Private m_GradientColorAngle As Single = -40.0F

    Private m_AppData As New AppData()
    Private m_CurrentUser As New CurrentUser()
    Private m_Security As New Security()
    Private m_InitOptions As New SyncSoft.SetupData.InitOptions()
    Private m_ErrProvider As New ErrorProvider()

    Private Const m_LogFile As String = "log.txt"
    Private m_BackupFolder As String = "C:\SIL Backup\" + My.Settings.DatabaseName

    Private oInitLogins As New InitLogins() 'Initial Login Data

#End Region

#Region " Properties "

    Friend ReadOnly Property GradientColorOne() As Color
        Get
            Return m_GradientColorOne
        End Get
    End Property

    Friend ReadOnly Property GradientColorTwo() As Color
        Get
            Return m_GradientColorTwo
        End Get
    End Property

    Friend ReadOnly Property GradientColorAngle() As Single
        Get
            Return m_GradientColorAngle
        End Get
    End Property

    Friend ReadOnly Property AppData() As AppData
        Get
            Return m_AppData
        End Get
    End Property

    Friend ReadOnly Property CurrentUser() As CurrentUser
        Get
            Return m_CurrentUser
        End Get
    End Property

    Friend ReadOnly Property Security() As Security
        Get
            Return m_Security
        End Get
    End Property

    Friend ReadOnly Property InitOptions() As SyncSoft.SetupData.InitOptions
        Get
            Return m_InitOptions
        End Get
    End Property

    Friend ReadOnly Property ErrProvider() As ErrorProvider
        Get
            Return m_ErrProvider
        End Get
    End Property

    Friend ReadOnly Property LogFile() As String
        Get
            Return m_LogFile
        End Get
    End Property

    Friend ReadOnly Property BackupFolder() As String
        Get
            Return m_BackupFolder
        End Get
    End Property

#End Region

    <STAThread()> Public Sub Main()

        Try

            With AppData

                .Company = My.Settings.Company

                .AppTitle = My.Settings.AppTitle
                .TitleFontName = "Calibri" '"Times New Roman"
                .TitleFontSize = 30
                .TitleShadowDepth = 4

                .Licensed = My.Settings.Licensed
                .ProductOwner = My.Settings.ProductOwner
                .LicenseNo = My.Settings.LicenseNo

                .DatabaseName = My.Settings.DatabaseName
                .HelpName = My.Settings.HelpName

                .Version = My.Settings.Version
                .Programming = My.Settings.Programming
                .Supervision = My.Settings.Supervision
                .SpecialThanks = My.Settings.SpecialThanks
                .ContactInfo = My.Settings.ContactInfo

                .Phone = My.Settings.Phone
                .PostalAddress = My.Settings.PostalAddress
                .Email = My.Settings.Email
                .Website = My.Settings.Website
                .Twitter = My.Settings.Twitter
                .Facebook = My.Settings.Facebook

                .Logo = Nothing 'CType(My.Resources.Logo, System.Drawing.Image)

                .SystemsAnalysis = My.Settings.SystemsAnalysis
                .SystemsArchitecture = My.Settings.SystemsArchitecture

                .AboutFontName = "Microsoft Sans Serif"
                .AboutFontSize = 30

                .SearchFont = New Font("Trebuchet MS", 9.75!, FontStyle.Regular)
                .SearchBackColor = Color.AliceBlue 'Color.Lavender '
                .SearchForeColor = Color.MidnightBlue
                .SearchCustomInsertCharacter = InitOptions.SearchCustomInsertCharacter
                .SearchCustomInsertLength = InitOptions.SearchCustomInsertLength
                .SearchCustomInsertPosition = InitOptions.SearchCustomInsertPosition

                .MinimumDate = #1/1/1900#
                .MaximumDate = #1/1/2079#
              
            End With

            fSplash.Splash.Show()
            Dim fLogin As New Login(oInitLogins, AppData.DatabaseName)
            fLogin.ShowDialog()
            If fLogin.CancelLogin = True Then Return

            With AppData

                .NullDateValue = GetNullDateValue()
                .DecimalPlaces = GetDecimalPlaces()
                .Currency = GetCurrency()
                .PasswordComplexity = GetPasswordComplexity()
                .EnableAuditTrail = GetEnableAuditTrail()

            End With

            fSplash.Splash.Refresh()
            fSplash.Splash.TopMost = True
            Application.EnableVisualStyles()
            Application.VisualStyleState = VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled
            Application.DoEvents()
            ' Application.Run(New frmMain())

        Catch eX As Exception
            MessageBox.Show(eX.Message, "SyncSoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogException(eX, LogFile)

        End Try

    End Sub

End Module

