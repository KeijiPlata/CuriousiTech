Imports System.Data
Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbCommand
Imports System.Data.OleDb.OleDbDataReader
Public Class TeacherProfile
    Dim con As New OleDbConnection(My.Settings.loginConnectionString)

    Dim LastName As String = LogInForm.reader("TbUser", "LastName")
    Dim FirstName As String = LogInForm.reader("TbUser", "FirstName")
    Dim MiddleName As String = LogInForm.reader("TbUser", "MiddleName")
    Dim UserName As String = LogInForm.reader("TbUser", "UserName")
    Dim UserID As Integer = LogInForm.reader("TbUser", "UserID")

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUserName.Text = UserName


        lblFullName.Text = LastName & FirstName

    End Sub

    Private Sub btnChangeUserName_Click(sender As Object, e As EventArgs)
        Try
            Dim i As Integer
            Dim sql As String
            Dim cmd As New OleDbCommand
            Dim myreader As OleDbDataReader

            con.Open()

            sql = "UPDATE TbUser SET UserName='" & txtBoxUserName.Text & "' WHERE UserID=" & UserID & ""
            cmd.Connection = con
            cmd.CommandText = sql
            txtBoxUserName.Text = ""

            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Record has been UPDATED successfully!")

            Else
                MsgBox("No record has been UPDATED!")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()

        End Try
    End Sub

    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs)
        Try
            Dim i As Integer
            Dim sql As String
            Dim cmd As New OleDb.OleDbCommand
            con.Open()
            sql = "UPDATE TbUser SET UserPassword='" & txtBoxPassword.Text & "' WHERE UserID=" & UserID & ""
            cmd.Connection = con
            cmd.CommandText = sql
            txtBoxPassword.Text = ""

            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Record has been UPDATED successfully!")

            Else
                MsgBox("No record has been UPDATED!")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox2.Click
        Me.Hide()

    End Sub
End Class