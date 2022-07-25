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

        'If timeLimit > 60 Then
        '    timeLimit -= 60

        'End If

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
        Label3.Text = count1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        userAnswer = "A"

        'If cQuestion > count1 Then
        '    Form2.Show()
        '    me.close()
        'End If

        If userAnswer = rightAnswer Then
            points += 1
            cQuestion += 1 ' binibilang yung natatanong
            printer()
        Else
            cQuestion += 1 ' binibilang yung natatanong
            printer()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        userAnswer = "B"

        'If cQuestion > count1 Then
        '    Form2.Show()
        '    me.close()
        'End If

        If userAnswer = rightAnswer Then
            cQuestion += 1 ' binibilang yung natatanong
            points += 1
            printer()
        Else
            cQuestion += 1 ' binibilang yung natatanong
            printer()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        userAnswer = "C"

        'If cQuestion > count1 Then
        '    Form2.Show()
        '    me.close()
        'End If

        If userAnswer = rightAnswer Then
            cQuestion += 1 ' binibilang yung natatanong
            points += 1
            printer()
        Else
            cQuestion += 1 ' binibilang yung natatanong
            printer()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        userAnswer = "D"

        'If cQuestion > count1 Then
        '    Form2.Show()
        '    me.close()
        'End If
        If userAnswer = rightAnswer Then
            cQuestion += 1 ' binibilang yung natatanong
            points += 1
            printer()
        Else
            cQuestion += 1 ' binibilang yung natatanong
            printer()
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
        End If
    End Sub
End Class
