Imports System.Data
Imports System.Data.OleDb

Public Class Formmcq2
    Dim con As New OleDb.OleDbConnection(My.Settings.leaderboardConnectionString)
    Public highScore As Integer
    Dim Username As String = LogInForm.getUserNamee.ToString

    '   compare currentScore and highScore
    Public Sub compare()
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim myreader As OleDbDataReader
        con.Open()

        sql = "Select * from leaderboardquizgame where UserName = '" & Username.ToString & "'"
        cmd.Connection = con
        cmd.CommandText = sql

        ' read
        myreader = cmd.ExecuteReader
        myreader.Read()

        ' convert to int to compare 
        highScore = Convert.ToInt32(myreader("Score"))
        con.Close()

        If Formmcq1.points > highScore Then
            Label6.Text = "New Highscore"
            highScore = Formmcq1.points

            con.Open()

            sql = "Update leaderboardquizgame set Score=" & highScore & " where UserName = '" & Username.ToString & "'"
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

        sql = "Select * from leaderboardquizgame where UserName = '" & Username.ToString & "'"
        cmd.Connection = con
        cmd.CommandText = sql

        myreader = cmd.ExecuteReader
        myreader.Read()

        highScore = myreader("Score")
        con.Close()

        compare()
        Label2.Text = Formmcq1.points

        Label4.Text = highScore
        My.Computer.Audio.Play(My.Resources.Game_Over, AudioPlayMode.WaitToComplete)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click
        Dim StudentForm = New StudenForm(LogInForm.reader("TbUser", "LastName"), LogInForm.reader("TbUser", "FirstName"), LogInForm.reader("TbUser", "MiddleName"), LogInForm.reader("TbUser", "UserName"), LogInForm.reader("TbUser", "StudentID"), LogInForm.reader("TbUser", "UserID"))
        StudentForm.Show()
        Me.Close()
    End Sub

    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox2.Click
        Me.Hide()
        Formmcq1.Show()

    End Sub
End Class