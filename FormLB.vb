Imports System.Data.OleDb
Public Class FormLB
    Dim con As New OleDb.OleDbConnection(My.Settings.leaderboardConnectionString)
    'Leaderboard True or False
    Private Sub bind_data()
        Dim cmd As New OleDb.OleDbCommand
        Dim sql As String
        Dim da As New OleDbDataAdapter
        Dim tablee As New DataTable

        sql = "Select UserName, Score from leaderboardtruefalse"
        cmd.Connection = con
        cmd.CommandText = sql

        da.SelectCommand = cmd
        tablee.Clear()
        da.Fill(tablee)
        DataGridView1.DataSource = tablee
    End Sub

    'Leaderboard Quiz Game
    Private Sub bind_data2()
        Dim cmd As New OleDb.OleDbCommand
        Dim sql As String
        Dim da As New OleDbDataAdapter
        Dim tablee As New DataTable

        sql = "Select UserName, Score from leaderboardquizgame"
        cmd.Connection = con
        cmd.CommandText = sql

        da.SelectCommand = cmd
        tablee.Clear()
        da.Fill(tablee)
        DataGridView1.DataSource = tablee
    End Sub
    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub FormLB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bind_data()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        bind_data()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        bind_data2()

    End Sub
End Class