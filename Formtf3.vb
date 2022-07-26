' imports
Imports System.Data
Imports System.Data.OleDb
Public Class Formtf3
    ' connection string
    Dim con As New OleDb.OleDbConnection(My.Settings.QuestionsConnectionString)
    Dim con2 As New OleDb.OleDbConnection(My.Settings.leaderboardConnectionString)
    Dim highscore As Integer
    Public Function highest()
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim myreader As OleDbDataReader

        ' Open connection between database
        con.Open()
        ' This will get the highscore from the database
        sql = "Select HighScore from HighestScore where id = 1"
        cmd.Connection = con
        cmd.CommandText = sql

        ' read
        myreader = cmd.ExecuteReader
        myreader.Read()

        ' convert to int to compare 
        highscore = Convert.ToInt32(myreader("HighScore"))
        con.Close()
        Label3.Text = highscore.ToString
        Return Nothing
    End Function

    Private Sub compareScores()
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim myreader As OleDbDataReader

        ' Open connection between database
        con2.Open()
        ' This will get the highscore from the database
        sql = "Select * from leaderboardtb where id = "
        cmd.Connection = con
        cmd.CommandText = sql

        ' read
        myreader = cmd.ExecuteReader
        myreader.Read()
        ' convert to int to compare 

        con2.Close()


    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Exit the game
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' open the form 1 and hide the main menu
        Formtf1.Show()
        Me.Hide()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' get the highscore and print it to label
        highest()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class