'Imports
Imports System.Data
Imports System.Data.OleDb
Public Class Formmcq3
    Dim con As New OleDb.OleDbConnection(My.Settings.leaderboardConnectionString)
    Dim Username As String = LogInForm.getUserNamee.ToString

    Public Sub printer()
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim myreader As OleDbDataReader

        con.Open()

        sql = "Select * from leaderboardquizgame where UserName = '" & Username.ToString & "'"
        cmd.Connection = con
        cmd.CommandText = sql

        myreader = cmd.ExecuteReader
        myreader.Read()

        '   print label
        Label3.Text = myreader("Score")

        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Formmcq1.Show()
        Me.Hide()
    End Sub

    Private Sub Formmcq3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        printer()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


End Class