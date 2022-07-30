Imports System.Data
Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbCommand
Imports System.Data.OleDb.OleDbDataReader
Public Class ProfileForm
    Dim con As New OleDbConnection(My.Settings.loginConnectionString)

    Dim LastName As String
    Dim FirstName As String
    Dim MiddleName As String
    Dim UserName As String
    Dim StudentID As String
    Dim UserID As Integer
    Public Sub New(ByVal varLastName As String, ByVal varFirstName As String, ByVal varMiddleName As String, ByVal varUserName As String, ByVal varStudentID As String, ByVal varUserID As String)
        InitializeComponent()
        LastName = varLastName
        FirstName = varFirstName
        MiddleName = varMiddleName
        UserName = varUserName
        StudentID = varStudentID
        UserID = varUserID
        If MiddleName = "n/a" Then
            MiddleName = ""
        End If
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUserName.Text = UserName
        If LogInForm.reader("TbUser", "UserType") = "STUDENT" Then
            lblStudentID.Text = StudentID
        Else
            lblStudentID.Text = ""
        End If
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
        Dim usertypee As String = LogInForm.userType.ToString
        If usertypee = "STUDENT" Then
            Dim StudentForm = New StudenForm(LogInForm.reader("TbUser", "LastName"), LogInForm.reader("TbUser", "FirstName"), LogInForm.reader("TbUser", "MiddleName"), LogInForm.reader("TbUser", "UserName"), LogInForm.reader("TbUser", "StudentID"), LogInForm.reader("TbUser", "UserID"))
            StudentForm.Show()
            Me.Close()
        ElseIf usertypee = "TEACHER" Then
            TeacherForm.Show()
            Me.Close()
        End If

    End Sub
End Class