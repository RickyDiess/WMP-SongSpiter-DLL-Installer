Imports System.IO
Imports System.Security.Principal

Public Class Form1

    Dim isElevated As Boolean
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim identity = WindowsIdentity.GetCurrent()
        Dim principal = New WindowsPrincipal(identity)
        isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If isElevated = True Then
            Button1.Enabled = True
            Label1.Visible = False
        Else
            Button1.Enabled = False
            Label1.Visible = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        File.WriteAllBytes(Environment.SystemDirectory & "\SongTitle.dll", My.Resources.SongTitle)

        Process.Start("CMD", "/C regsvr32 " + Environment.SystemDirectory + "\SongTitle.dll")

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim webAddress As String = "https://github.com/RickyDiess/WMP-SongSpiter-DLL-Installer"
        Process.Start(webAddress)
    End Sub
End Class
