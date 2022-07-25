﻿Imports System.Data
Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbCommand
Imports System.Data.OleDb.OleDbDataReader

Public Class LogInForm
    Dim con As New OleDbConnection(My.Settings.loginConnectionString)

    'FOR TESTING
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUserName.Text = "John"
        txtPassword.Text = "1234"
    End Sub
    'LOGIN BUTTON
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            Dim sql As String
            Dim cmd As New OleDbCommand
            Dim myreader As OleDbDataReader

            con.Open()
            'SELECT TABLE INPUTED USERNAME
            sql = "SELECT * FROM TbUser WHERE UserName='" & txtUserName.Text & "'"
            cmd.Connection = con
            cmd.CommandText = sql

            myreader = cmd.ExecuteReader
            myreader.Read()

            If txtPassword.Text = myreader("Password") And myreader("UserType") = "STUDENT" Then
                'LOGIN AS STUDENT
                Dim MainMenu = New StudenForm(myreader("LastName"), myreader("FirstName"), myreader("MiddleName"), myreader("UserName"), myreader("StudentID"), myreader("UserID"))
                MainMenu.Show()

            ElseIf txtPassword.Text = myreader("Password") And myreader("UserType") = "TEACHER" Then
                'LOGIN AS TEACHER
                Dim MainMenu = New TeacherForm(myreader("LastName"), myreader("FirstName"), myreader("MiddleName"), myreader("UserName"), myreader("UserID"))
                MainMenu.Show()

            Else
                MsgBox("wrong usersname or password")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            Me.Hide()
        End Try


    End Sub

End Class
