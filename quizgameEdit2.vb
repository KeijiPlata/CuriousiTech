Imports System.Data
Imports System.Data.OleDb
Public Class quizgameEdit2
    Dim con As New OleDb.OleDbConnection(My.Settings.mcqqConnectionString)
    Dim timee As Integer
    Private Sub getTimer()
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim myreader As OleDbDataReader

        ' Open connection between database
        con.Open()

        ' select from database
        sql = "Select * from Timer where id = 1"
        cmd.Connection = con
        cmd.CommandText = sql

        ' read
        myreader = cmd.ExecuteReader
        myreader.Read()

        timee = myreader("timeLimit")
        con.Close()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Please select something from datafield before updating!", vbOKOnly + vbCritical, "Input fields")
        Else
            'updates data
            Dim cmd As New OleDb.OleDbCommand
            Dim sql As String

            sql = "Update Timer set timeLimit=" & TextBox1.Text & " where id = 1"
            cmd.Connection = con
            cmd.CommandText = sql

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ' refresh the time
            getTimer()

            ' put the time inside the label text
            Label2.Text = timee.ToString
        End If
    End Sub

    Private Sub quizgameEdit2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' This will get the timer to database 
        getTimer()
        Label2.Text = timee.ToString
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        quizgameEdit.Show()
        Me.Close()

    End Sub
End Class