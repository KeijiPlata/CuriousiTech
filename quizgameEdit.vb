Imports System.Data
Imports System.Data.OleDb
Public Class quizgameEdit
    Dim con As New OleDb.OleDbConnection(My.Settings.mcqqConnectionString)
    Private Sub bind_data()
        Dim cmd As New OleDb.OleDbCommand
        Dim sql As String
        Dim da As New OleDbDataAdapter
        Dim tablee As New DataTable

        sql = "Select * from MCQ"
        cmd.Connection = con
        cmd.CommandText = sql

        da.SelectCommand = cmd
        tablee.Clear()
        da.Fill(tablee)
        DataGridView1.DataSource = tablee
    End Sub
    Private Sub quizgameEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' shows the data inside the data gridview
        bind_data()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or ComboBox1.SelectedIndex = -1 Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Please input something first before insert!", vbOKOnly + vbCritical, "Input fields")
        Else
            ' add new row
            Dim cmd As New OleDb.OleDbCommand
            Dim sql As String

            sql = "Insert into MCQ(Question, Answer, A, B, C, D)Values(@Question, @answer, @A, @B, @C, @D)"
            cmd.Parameters.AddWithValue("@Question", TextBox1.Text)
            cmd.Parameters.AddWithValue("@answer", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@A", TextBox2.Text)
            cmd.Parameters.AddWithValue("@B", TextBox3.Text)
            cmd.Parameters.AddWithValue("@C", TextBox4.Text)
            cmd.Parameters.AddWithValue("@D", TextBox5.Text)

            cmd.Connection = con
            cmd.CommandText = sql

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'refresh datagrid
            bind_data()
        End If
    End Sub
End Class