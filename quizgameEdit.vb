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

    Private Sub Button1_Click(sender As Object, e As EventArgs)
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

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        If MsgBox("Are you sure you want to delete all the rows?", MsgBoxStyle.YesNoCancel, "Delete all the row") = MsgBoxResult.Yes Then
            Dim cmd As New OleDb.OleDbCommand
            Dim sql As String

            sql = "Delete from MCQ"
            cmd.Connection = con
            cmd.CommandText = sql

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'refresh datagrid
            bind_data()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        If TextBox1.Text = "" Or ComboBox1.SelectedIndex = -1 Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Please select something from datafield before updating!", vbOKOnly + vbCritical, "Input fields")

        Else
            'updates data
            Dim cmd As New OleDb.OleDbCommand
            Dim sql As String

            sql = "Update MCQ set Question='" & TextBox1.Text & "', Answer='" & ComboBox1.Text & "', A='" & TextBox2.Text &
                "', B='" & TextBox3.Text & "', C='" & TextBox4.Text & "', D='" & TextBox5.Text & "' where id=" & TextBox6.Text & ""
            cmd.Connection = con
            cmd.CommandText = sql

            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'refresh datagrid
            bind_data()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        ' this will make the data visible to the textbox if the cell is clicked in datagridview
        Dim index As Integer = e.RowIndex
        Dim selectedrow As DataGridViewRow = DataGridView1.Rows(index)
        TextBox6.Text = selectedrow.Cells(0).Value.ToString
        TextBox1.Text = selectedrow.Cells(1).Value.ToString
        ComboBox1.Text = selectedrow.Cells(2).Value.ToString
        TextBox2.Text = selectedrow.Cells(3).Value.ToString
        TextBox3.Text = selectedrow.Cells(4).Value.ToString
        TextBox4.Text = selectedrow.Cells(5).Value.ToString
        TextBox5.Text = selectedrow.Cells(6).Value.ToString
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        ' clear the field
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        ComboBox1.SelectedIndex = -1
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        quizgameEdit2.Show()
        Me.Hide()
    End Sub
End Class