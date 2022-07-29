'Imports
Imports System.Data
Imports System.Data.OleDb
Public Class Formmcq1
    Dim con As New OleDb.OleDbConnection(My.Settings.mcqqConnectionString)
    Dim con2 As New OleDb.OleDbConnection(My.Settings.leaderboardConnectionString)
    Dim userAnswer As String
    Dim count1 As Integer
    Dim cQuestion As Integer '  countQuestion asked
    Public points As Integer
    Dim rightAnswer As String
    Dim timeLimit As Integer
    Dim timePenalty As Integer = 1 '    TIMEPENALTY
    Dim raTimer As Integer = 2   ' GREENLIGHT
    Dim MusicIsPlaying As Boolean



    Private Sub showLeaderboard()
        Dim scores(10) As Integer
        Dim names(10) As String
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim myreader As OleDbDataReader

        con2.Open()

        sql = "Select TOP 10 * from leaderboardquizgame Order by Score DESC"
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
        Label1A.Text = scores(1).ToString
        Label1B.Text = names(1).ToString
        Label2A.Text = scores(2).ToString
        Label2B.Text = names(2).ToString
        Label3A.Text = scores(3).ToString
        Label3B.Text = names(3).ToString
        Label4A.Text = scores(4).ToString
        Label4B.Text = names(4).ToString
        Label5A.Text = scores(5).ToString
        Label5B.Text = names(5).ToString
        Label6A.Text = scores(6).ToString
        Label6B.Text = names(6).ToString
        Label7A.Text = scores(7).ToString
        Label7B.Text = names(7).ToString
        Label8A.Text = scores(8).ToString
        Label8B.Text = names(8).ToString
        Label9A.Text = scores(9).ToString
        Label9B.Text = names(9).ToString
        Label10A.Text = scores(10).ToString
        Label10B.Text = names(10).ToString

    End Sub

    '   read time limit given by instructor
    Private Sub timer()
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim myreader As OleDbDataReader

        con.Open()

        sql = "Select timeLimit from Timer where id = 1"
        cmd.Connection = con
        cmd.CommandText = sql

        myreader = cmd.ExecuteReader
        myreader.Read()

        timeLimit = myreader("timeLimit")

        con.Close()

        timeLimit *= 60

    End Sub

    Private Function printer()
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim myreader As OleDbDataReader

        If cQuestion > count1 Then
            Formmcq2.Show()
            Me.Close()
        Else
            con.Open()

            sql = "Select * from MCQ where id = " & Val(cQuestion.ToString) & ""
            cmd.Connection = con
            cmd.CommandText = sql

            myreader = cmd.ExecuteReader
            myreader.Read()

            '   print label
            Label1.Text = myreader("Question")
            Button1.Text = myreader("A")
            Button2.Text = myreader("B")
            Button3.Text = myreader("C")
            Button4.Text = myreader("D")

            '   value of the fcking answer
            rightAnswer = myreader("Answer")

            con.Close()

            '   IBALIK SA NORMAL COLOR NG BUTTON
            Button1.BackColor = SystemColors.Control
            Button2.BackColor = SystemColors.Control
            Button3.BackColor = SystemColors.Control
            Button4.BackColor = SystemColors.Control

            raTimer = 2
            timePenalty = 3
            Label7.Text = 3
            Label5.Text = points
        End If
        Return Nothing
    End Function
    Private Sub Formmcq1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        cQuestion = 1

        'timer
        timer()
        showLeaderboard()

        '   open connnection database
        con.Open()

        '   count the question in database
        sql = "Select count(Question) from MCQ"
        cmd.Connection = con
        cmd.CommandText = sql
        count1 = Convert.ToInt32(cmd.ExecuteScalar)
        '   close connection database
        con.Close()
        '   this will print the data from the fckingdatabase
        printer()

        Label6.Text = timeLimit
        Label7.Text = timePenalty

        My.Computer.Audio.Play(My.Resources.Pixelland, AudioPlayMode.BackgroundLoop)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        userAnswer = "A"

        If userAnswer = rightAnswer Then

            points += 1
            cQuestion += 1 ' binibilang yung natatanong
            printer()
            '   wait
            Formmcq2.compare()
            showLeaderboard()


            Timer3.Start()  ' GREEN LIGHT USELESS
        Else
            Timer2.Start()  ' PENALTY TIME
            cQuestion += 1 ' binibilang yung natatanong
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            timePenalty = 2
            Button1.BackColor = Color.Red ' BUTTON TURNS RED IF WRONG ANSWER
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        userAnswer = "B"

        If userAnswer = rightAnswer Then
            cQuestion += 1 ' binibilang yung natatanong
            points += 1
            printer()
            '   wait
            Formmcq2.compare()
            showLeaderboard()

            Timer3.Start()  ' GREEN LIGHT USELESS
        Else
            Timer2.Start()  ' PENALTY TIME
            cQuestion += 1 ' binibilang yung natatanong
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            timePenalty = 2
            Button2.BackColor = Color.Red ' BUTTON TURNS RED IF WRONG ANSWER
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        userAnswer = "C"

        If userAnswer = rightAnswer Then
            cQuestion += 1 ' binibilang yung natatanong
            points += 1
            printer()
            '   wait
            Formmcq2.compare()
            showLeaderboard()


            Timer3.Start()  ' GREEN LIGHT USELESS
        Else
            Timer2.Start()  ' PENALTY TIME
            cQuestion += 1 ' binibilang yung natatanong
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            timePenalty = 2
            Button3.BackColor = Color.Red ' BUTTON TURNS RED IF WRONG ANSWER
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        userAnswer = "D"

        If userAnswer = rightAnswer Then
            cQuestion += 1 ' binibilang yung natatanong
            points += 1
            printer()
            '   wait
            Formmcq2.compare()
            showLeaderboard()


            Timer3.Start()  ' GREEN LIGHT USELESS
        Else
            Timer2.Start()  ' PENALTY TIME
            cQuestion += 1 ' binibilang yung natatanong
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            timePenalty = 3
            Button4.BackColor = Color.Red ' BUTTON TURNS RED IF WRONG ANSWER
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label6.Text = timeLimit.ToString
        timeLimit -= 1

        If timeLimit = -2 Then
            Timer1.Stop()
            My.Computer.Audio.Stop()
            Formmcq2.Show()
            Me.Close()

        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label7.Text = timePenalty.ToString
        timePenalty -= 1
        ' PENALTY TIME

        ' SHOW ANSWER
        If rightAnswer = "A" Then
            Button1.BackColor = Color.Green
        ElseIf rightAnswer = "B" Then
            Button2.BackColor = Color.Green
        ElseIf rightAnswer = "C" Then
            Button3.BackColor = Color.Green
        ElseIf rightAnswer = "D" Then
            Button4.BackColor = Color.Green
        End If

        If timePenalty < -1 Then
            Timer2.Stop()
            printer()
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

        If userAnswer = "A" Then
            Button1.BackColor = Color.Green '   greenlight
        ElseIf userAnswer = "B" Then

            Button2.BackColor = Color.Green '   greenlight
        ElseIf userAnswer = "C" Then
            Button3.BackColor = Color.Green '   greenlight
        Else
            Button4.BackColor = Color.Green '   greenlight
        End If
        raTimer -= 1
        If raTimer = 0 Then
            Timer3.Stop()
            '   IBALIK SA NORMAL COLOR NG BUTTON
            Button1.BackColor = SystemColors.Control
            Button2.BackColor = SystemColors.Control
            Button3.BackColor = SystemColors.Control
            Button4.BackColor = SystemColors.Control

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If MusicIsPlaying Then
            Button5.Text = "Unmute"
            My.Computer.Audio.Stop()
            MusicIsPlaying = False
        Else
            Button5.Text = "Mute"
            My.Computer.Audio.Play(My.Resources.pixelland, AudioPlayMode.BackgroundLoop)
            MusicIsPlaying = True
        End If
    End Sub
End Class
