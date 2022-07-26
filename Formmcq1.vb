'Imports
Imports System.Data
Imports System.Data.OleDb
Public Class Formmcq1
    Dim con As New OleDb.OleDbConnection(My.Settings.mcqqConnectionString)
    Dim userAnswer As String
    Dim count1 As Integer
    Dim cQuestion As Integer '  countQuestion asked
    Public points As Integer
    Dim rightAnswer As String
    Dim timeLimit As Integer
    Dim timePenalty As Integer = 1 '    TIMEPENALTY
    Dim raTimer As Integer = 2   ' GREENLIGHT

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

            '   TEMPORARY
            Label2.Text = cQuestion
            Label4.Text = myreader("Answer") '   cheat
            Label5.Text = points '   score

            con.Close()

            '   IBALIK SA NORMAL COLOR NG BUTTON
            Button1.BackColor = SystemColors.Control
            Button2.BackColor = SystemColors.Control
            Button3.BackColor = SystemColors.Control
            Button4.BackColor = SystemColors.Control

            raTimer = 2
            timePenalty = 2
            Label7.Text = 2

        End If
        Return Nothing
    End Function
    Private Sub Formmcq1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        cQuestion = 1

        'timer
        timer()

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
        Label3.Text = count1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        userAnswer = "A"

        If userAnswer = rightAnswer Then

            points += 1
            cQuestion += 1 ' binibilang yung natatanong
            printer()

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
            Timer3.Start()  ' GREEN LIGHT USELESS
        Else
            Timer2.Start()  ' PENALTY TIME
            cQuestion += 1 ' binibilang yung natatanong
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            timePenalty = 2
            Button4.BackColor = Color.Red ' BUTTON TURNS RED IF WRONG ANSWER
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Formmcq2.Show()
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label6.Text = timeLimit.ToString
        timeLimit -= 1

        If timeLimit = 0 Then
            Timer1.Stop()
            Formmcq2.Show()
            Me.Hide()

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

        If timePenalty < 0 Then
            Timer2.Stop()
            printer()
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Label10.Text = raTimer.ToString
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
End Class
