' imports
Imports System.Data
Imports System.Data.OleDb
Public Class Formtf1
    ' Connection
    Dim con2 As New OleDb.OleDbConnection(My.Settings.leaderboardConnectionString)
    Dim con As New OleDb.OleDbConnection(My.Settings.QuestionsConnectionString)
    Dim convtf As Boolean
    Dim score As Integer
    Dim highscore As Integer
    Dim count1 As Integer
    Dim timee As Integer
    Dim Username As String = LogInForm.getUserNamee.ToString

    ' This will show the leaderboards
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
    Private Sub getTimer()
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim myreader As OleDbDataReader

        ' Open connection between database
        con.Open()

        ' select from database
        sql = "Select * from timertb where id = 1"
        cmd.Connection = con
        cmd.CommandText = sql

        ' read
        myreader = cmd.ExecuteReader
        myreader.Read()

        timee = myreader("TimerEdit")
        con.Close()

    End Sub
    Private Function ChangeButton()
        ' Generate random number
        Randomize()
        Dim randomNum As Decimal = Rnd() * 10
        Dim conv As Integer = Int(randomNum) + 1

        ' Generate random number again
        Randomize()
        Dim randomNum2 As Decimal = Rnd() * 10
        Dim conv2 As Integer = Int(randomNum2) + 1

        ' if the random number is an even number, it will change location
        If conv Mod 2 = 0 Then
            Button1.Location = New Point(365, 203)
            Button2.Location = New Point(63, 203)
        Else
            Button1.Location = New Point(63, 203)
            Button2.Location = New Point(365, 203)
        End If

        ' if the randomnumber is an even number, it will change color
        If conv2 Mod 2 = 0 Then
            Button1.BackColor = Color.Red
            Button2.BackColor = Color.DarkTurquoise
        Else
            Button1.BackColor = Color.DarkTurquoise
            Button2.BackColor = Color.Red
        End If
        Return Nothing
    End Function
    ' I created here a function to avoid redundancy
    Private Function TFsyntax()
        ' Declaring variables
        Dim sql As String
        Dim TF As String
        Dim cmd As New OleDb.OleDbCommand
        Dim myreader As OleDbDataReader

        ' generate random number 
        Randomize()
        Dim randomNum As Decimal = Rnd() * count1
        Dim conv As Integer = Int(randomNum) + 1

        ' Open connection between database
        con.Open()

        ' select from database
        sql = "Select Question, tf from QuestionsBool where id=" & Val(conv.ToString) & ""
        cmd.Connection = con
        cmd.CommandText = sql

        ' read
        myreader = cmd.ExecuteReader
        myreader.Read()

        ' print to label
        Label1.Text = myreader("Question")

        ' Get the value of TF and convert it into boolean
        TF = myreader("tf")
        convtf = Convert.ToBoolean(TF)

        ' close connection from database
        con.Close()
        Return Nothing
    End Function

    ' updates the score if there is a highscore
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



        If score > highscore Then
            ' if the score is greater than highscore, it will be replaced
            highscore = score

            'get the new highscore and pass it to form2
            Formtf2.newhighscore = highscore

            ' Open connection between database
            con2.Open()

            ' We only have one highscore so ID 1 only updates when there is a new highscore
            sql = "Update leaderboardtruefalse set Score=" & highscore & " where UserName = '" & Username.ToString & "'"
            cmd.Connection = con2
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            'close the connection
            con2.Close()
        End If
        Return Nothing
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' This will update the leaderboard
        showScore()
        'get time from the database
        getTimer()
        timee += 1

        ' Start timer
        Timer1.Start()

        ' This will load the first question 
        TFsyntax()

        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand

        ' This will get the count of the questions inside the database
        con.Open()
        sql = "Select count(Question) from QuestionsBool"
        cmd.Connection = con
        cmd.CommandText = sql
        count1 = Convert.ToInt32(cmd.ExecuteScalar)
        con.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If convtf = True Then
            score = score + 1
            getTimer() ' reset time
            Label3.ForeColor = Color.Green
            Label3.Text = timee.ToString
            Label4.Text = score.ToString
            Highest()
            showScore() ' this will refresh the leaderboard
            TFsyntax()
            ChangeButton() ' change the button location randomly
        Else
            Highest()
            Formtf2.displayScore = score
            Formtf2.Show()
            score = 0 'reset
            ' get the highscore and pass it to form2
            Formtf2.highscore2 = highscore
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If convtf = False Then
            score = score + 1
            getTimer() 'reset time
            Label3.ForeColor = Color.Green
            Label3.Text = timee.ToString
            Label4.Text = score.ToString
            Highest()
            showScore() ' this will refresh the leaderboard
            TFsyntax()
            ChangeButton() ' change the button location randomly
        Else
            Highest()
            Formtf2.displayScore = score
            Formtf2.Show()
            score = 0 'reset
            ' get the highscore and pass it to form2
            Formtf2.highscore2 = highscore
            Me.Close()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' this will countdown the timer
        timee = timee - 1
        Label3.Text = timee.ToString

        If timee = 0 Then
            ' Stops the timer so it will not go  negative
            Timer1.Stop()

            ' get the score and pass it to next form
            Highest()
            Formtf2.displayScore = score
            Formtf2.Show()
            score = 0 'reset
            Me.Close()
        End If

        ' change the color 
        If timee > 3 Then
            Label3.ForeColor = Color.Green
        Else
            Label3.ForeColor = Color.Red
        End If
    End Sub
End Class
