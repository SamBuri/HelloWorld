
Option Strict On

Imports SyncSoft.Common.Install.Classes

Module modMain

#Region " Fields "
#End Region

    Public Sub SetServerParameters()
        Dim oServerParameters As New ServerParameters()
        With oServerParameters
            .DataBaseName = "ClinicMaster"
            .LocalServerName = ".\SQLEXPRESS"
            .ScriptList = GetScriptList()
            .AppTitle = "Clinic Master"
        End With
    End Sub

    Private Function GetScriptList() As List(Of String)

        Dim scriptList As New List(Of String)

        With scriptList
            .Add(My.Resources.CreateTables.ToString() + ControlChars.NewLine)
            .Add(My.Resources.UpdateStructures.ToString() + ControlChars.NewLine)
            .Add(My.Resources.Utilities.ToString() + ControlChars.NewLine)
            .Add(My.Resources.Data.ToString() + ControlChars.NewLine)
            .Add(My.Resources.UpdateData.ToString() + ControlChars.NewLine)
            .Add(My.Resources.Reports.ToString() + ControlChars.NewLine)
            .Add(My.Resources.ManageDatabase.ToString() + ControlChars.NewLine)
            .Add(My.Resources.InsertData.ToString() + ControlChars.NewLine)
        End With

        Return scriptList

    End Function

End Module

