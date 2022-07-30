Imports System.Data
Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbCommand
Imports System.Data.OleDb.OleDbDataReader

Public Class TeacherForm
    'TEACHERS
    'profile

    'CLASS BTN
    'classess
    'students

    Dim con As New OleDb.OleDbConnection(My.Settings.leaderboardConnectionString)
    Dim LastName As String = LogInForm.reader("TbUser", "LastName")
    Dim FirstName As String = LogInForm.reader("TbUser", "FirstName")
    Dim MiddleName As String = LogInForm.reader("TbUser", "MiddleName")
    Dim UserName As String = LogInForm.reader("TbUser", "UserName")
    Dim UserID As Integer = LogInForm.reader("TbUser", "UserID")

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
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bind_data()
        'SETS LABELS
        lblFullName.Text = LastName + " " + FirstName + " " + MiddleName
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        'OPENS CLASS FORM
        Dim Classes = New ClassForm(UserID)
        Classes.Show()
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim answer As Integer

        answer = MsgBox("are you sure you want to log out?", vbQuestion + vbYesNo + vbDefaultButton2, "LOG OUT")
        If answer = vbYes Then
            LogInForm.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        bind_data2()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        bind_data()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        quizgameEdit.Show()

    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        FormtfEdit1.Show()

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        TeacherProfile.Show()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        AboutUs.Show()
        Me.Close()

    End Sub
End Class