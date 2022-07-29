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
            Label3.Text = "New HighScore!"

            '' This is the updated highscore
            'Label5.Text = newhighscore.ToString
        Else
            Label3.Text = "Score"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' opens mainmenu
        Dim StudentForm = New StudenForm(LogInForm.reader("TbUser", "LastName"), LogInForm.reader("TbUser", "FirstName"), LogInForm.reader("TbUser", "MiddleName"), LogInForm.reader("TbUser", "UserName"), LogInForm.reader("TbUser", "StudentID"), LogInForm.reader("TbUser", "UserID"))
        StudentForm.Show()
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' retry button, open again form1
        Me.Close()
        Formtf1.Show()

    End Sub
End Class