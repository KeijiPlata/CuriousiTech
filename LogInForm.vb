Imports System.Data
Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbCommand
Imports System.Data.OleDb.OleDbDataReader

Public Class LogInForm
    Dim con As New OleDbConnection(My.Settings.loginConnectionString)
    ' This will get the value of user - Ginalaw ni miacky eto lang
    Public getUserNamee As String


    'FOR TESTING
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUserName.Text = "John"
        txtPassword.Text = "1234"
    End Sub



    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        'LOGIN BUTTON
        'LOGIN BUTTON

        'get the username 
        getUserNamee = txtUserName.Text

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

            If txtPassword.Text = myreader("UserPassword") And myreader("UserType") = "STUDENT" Then
                'LOGIN AS STUDENT
                Dim MainMenu = New StudenForm(myreader("LastName"), myreader("FirstName"), myreader("MiddleName"), myreader("UserName"), myreader("StudentID"), myreader("UserID"))
                MainMenu.Show()
                Me.Hide()
            ElseIf txtPassword.Text = myreader("UserPassword") And myreader("UserType") = "TEACHER" Then
                'LOGIN AS TEACHER
                Dim MainMenu = New TeacherForm(myreader("LastName"), myreader("FirstName"), myreader("MiddleName"), myreader("UserName"), myreader("UserID"))
                MainMenu.Show()
                Me.Hide()
            Else
                MsgBox("wrong usersname or password")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try


    End Sub


    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class

