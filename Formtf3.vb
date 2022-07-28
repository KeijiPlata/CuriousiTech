' imports
Imports System.Data
Imports System.Data.OleDb
Public Class Formtf3
    ' connection string
    Dim con As New OleDb.OleDbConnection(My.Settings.QuestionsConnectionString)
    Dim con2 As New OleDb.OleDbConnection(My.Settings.leaderboardConnectionString)
    Dim highscore As Integer
    Dim Username As String = LogInForm.getUserNamee.ToString
    Public Function highest()
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
        Label3.Text = highscore.ToString
        Return Nothing
    End Function


    Public Sub showScore()
        Dim scores(10) As Integer
        Dim names(10) As String
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim myreader As OleDbDataReader

        con2.Open()
        ' This will get the score from the database
        sql = "Select TOP 10 * from leaderboardtruefalse Order By Score DESC"
        cmd.Connection = con2
        cmd.CommandText = sql

        ' read
        myreader = cmd.ExecuteReader

        If myreader.HasRows Then
            For i As Integer = 1 To 10 Step 1
                myreader.Read()
                scores(i) = myreader("Score")
                names(i) = myreader("UserName")
            Next
        End If

        con2.Close()

        ' put the the data inside the label
        LabelA1.Text = scores(1).ToString
        LabelA2.Text = names(1).ToString
        LabelB1.Text = scores(2).ToString
        LabelB2.Text = names(2).ToString
        LabelC1.Text = scores(3).ToString
        LabelC2.Text = names(3).ToString
        LabelD1.Text = scores(4).ToString
        LabelD2.Text = names(4).ToString
        LabelE1.Text = scores(5).ToString
        LabelE2.Text = names(5).ToString
        LabelF1.Text = scores(6).ToString
        LabelF2.Text = names(6).ToString
        LabelG1.Text = scores(7).ToString
        LabelG2.Text = names(7).ToString
        LabelH1.Text = scores(8).ToString
        LabelH2.Text = names(8).ToString
        LabelI1.Text = scores(9).ToString
        LabelI2.Text = names(9).ToString
        LabelJ1.Text = scores(10).ToString
        LabelJ2.Text = names(10).ToString

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' open the form 1 and hide the main menu
        Formtf1.Show()
        Me.Close()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' get the highscore and print it to label
        highest()

        ' this will show the leaderboard
        showScore()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class