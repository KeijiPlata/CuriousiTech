﻿Imports System.Data
Imports System.Data.OleDb

Public Class Formmcq2
    Dim con As New OleDb.OleDbConnection(My.Settings.mcqqConnectionString)
    Public highScore As Integer

    '   compare currentScore and highScore
    Private Sub compare()
        If Formmcq1.points > highScore Then
            Dim sql As String
            Dim cmd As New OleDb.OleDbCommand
            highScore = Formmcq1.points

            con.Open()
            sql = "Update LeaderBoards set Score =" & highScore & " where id = 1"
            cmd.Connection = con
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            con.Close()
        End If
    End Sub

    Private Sub Formmcq2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim myreader As OleDbDataReader

        con.Open()

        sql = "Select Score from LeaderBoards where id = 1"
        cmd.Connection = con
        cmd.CommandText = sql

        myreader = cmd.ExecuteReader
        myreader.Read()

        highScore = myreader("Score")
        con.Close()

        compare()
        Label2.Text = Formmcq1.points

        Label4.Text = highScore
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Formmcq3.Show()
        Me.Close()
    End Sub
End Class