' imports
Imports System.Data
Imports System.Data.OleDb
Public Class Formtf2
    Public highscore2 As Integer
    Public newhighscore As Integer
    Public displayScore As Integer
    Dim con2 As New OleDb.OleDbConnection(My.Settings.leaderboardConnectionString)
    Dim Username As String = LogInForm.getUserNamee.ToString
    Dim highscore As Integer

    Private Function Highest()
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim myreader As OleDbDataReader

        ' Open connection between database
        con2.Open()
        ' This will get the highscore from the database
        sql = "Select * from leaderboardtruefalse where UserName = '" & Username.ToString & "'"
        cmd.Connection = con2
        cmd.CommandText = sql

        ' read
        myreader = cmd.ExecuteReader
        myreader.Read()

        ' convert to int to compare 
        highscore = Convert.ToInt32(myreader("Score"))
        con2.Close()
        Return Nothing
    End Function
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        ' get the database score
        Highest()

        ' display the score
        Label2.Text = displayScore.ToString

        ' highscore always get the old highscore
        Label5.Text = highscore.ToString


        If highscore > highscore2 Then
            Label3.Text = "New HighScore:"

            '' This is the updated highscore
            'Label5.Text = newhighscore.ToString
        Else
            Label3.Text = "Score"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        ' opens mainmenu
        Formtf3.highest() ' This will refresh the highscore
        Formtf3.showScore() ' This will refresh the leaderboard
        Formtf3.Show()
        Me.Close()

    End Sub



    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox2.Click
        ' retry button, open again form1

        Me.Close()
        Formtf1.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click
        Me.Close()
    End Sub
End Class