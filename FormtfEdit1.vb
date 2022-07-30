Imports System.Data
Imports System.Data.OleDb
Public Class FormtfEdit1
    Dim con As New OleDb.OleDbConnection(My.Settings.QuestionsConnectionString)
    Dim question As String
    Dim answer As String
    Dim id As String
    Dim timee As Integer

    ' get the data from database and show it to datagridview
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
    Private Sub bind_data()
        Dim cmd As New OleDb.OleDbCommand
        Dim sql As String
        Dim da As New OleDbDataAdapter
        Dim tablee As New DataTable

        sql = "Select * from QuestionsBool"
        cmd.Connection = con
        cmd.CommandText = sql

        da.SelectCommand = cmd
        tablee.Clear()
        da.Fill(tablee)
        DataGridView1.DataSource = tablee
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ayusin mo din toh!!!!

        'get timer from database
        getTimer()

        'put the time inside the label text
        Label5.Text = timee.ToString

        'Load the data inside the datagridview
        bind_data()

    End Sub




    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' this will make the data visible to the textbox if the cell is clicked in datagridview
        Dim index As Integer = e.RowIndex
        Dim selectedrow As DataGridViewRow = DataGridView1.Rows(index)
        id = selectedrow.Cells(0).Value.ToString
        question = selectedrow.Cells(1).Value.ToString
        answer = selectedrow.Cells(2).Value.ToString

        TextBox2.Text = id
        TextBox1.Text = question
        ComboBox1.Text = answer
    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs)
        FormtfEdit2.Show()
        Me.Hide()


    End Sub



    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'iedit mo ituh
        If TextBox3.Text = "" Then
            MsgBox("Please select something from datafield before updating!", vbOKOnly + vbCritical, "Input fields")
        Else
            'updates data
            Dim cmd As New OleDb.OleDbCommand
            Dim sql As String

            sql = "Update timertb set TimerEdit=" & TextBox3.Text & " where id = 1"
            cmd.Connection = con
            cmd.CommandText = sql

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ' refresh the time
            getTimer()

            ' put the time inside the label text
            Label5.Text = timee.ToString
        End If
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Formtf1.Show()
    End Sub

    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox2.Click
        Me.Close()
    End Sub



    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or ComboBox1.SelectedIndex = -1 Then
            MsgBox("Please select something from datafield before updating!", vbOKOnly + vbCritical, "Input fields")

        Else
            'updates data
            Dim cmd As New OleDb.OleDbCommand
            Dim sql As String

            sql = "Update QuestionsBool set Question='" & TextBox1.Text & "', tf='" & ComboBox1.Text & "' where id=" & TextBox2.Text & ""
            cmd.Connection = con
            cmd.CommandText = sql

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'refresh datagrid
            bind_data()
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If MsgBox("Are you sure you want to delete all the rows?", MsgBoxStyle.YesNoCancel, "Delete all the row") = MsgBoxResult.Yes Then
            Dim cmd As New OleDb.OleDbCommand
            Dim sql As String

            sql = "Delete from QuestionsBool"
            cmd.Connection = con
            cmd.CommandText = sql

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'refresh datagrid
            bind_data()
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or ComboBox1.SelectedIndex = -1 Then
            MsgBox("Please input something first before insert!", vbOKOnly + vbCritical, "Input fields")
        Else
            ' add new row
            Dim cmd As New OleDb.OleDbCommand
            Dim sql As String

            sql = "Insert into QuestionsBool(Question, tf)Values(@Questions, @truefalse)"
            cmd.Parameters.AddWithValue("@Questions", TextBox1.Text)
            cmd.Parameters.AddWithValue("@truefalse", ComboBox1.Text)
            cmd.Connection = con
            cmd.CommandText = sql

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'refresh datagrid
            bind_data()
        End If
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        ' clear the text inside the textbox
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.SelectedIndex = -1
    End Sub
End Class
