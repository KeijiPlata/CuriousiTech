Imports System.Data
Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbCommand
Imports System.Data.OleDb.OleDbDataReader
Public Class ClassForm
    Dim con As New OleDbConnection(My.Settings.loginConnectionString)
    Dim UserID As String
    Public Sub New(ByVal varUserId As String)
        InitializeComponent()
        UserID = varUserId

    End Sub
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim dt As New DataTable
        Dim da As New OleDb.OleDbDataAdapter

        con.Open()
        Try
            'SELECT TABLE
            sql = "SELECT Class,Student FROM TbJunctionTeacher INNER JOIN TbUser ON TbUser.UserID = TbJunctionTeacher.TeacherID WHERE TeacherID=" & UserID & ""
            cmd.Connection = con
            cmd.CommandText = sql
            da.SelectCommand = cmd

            da.Fill(dt)

            DataGridView1.DataSource = dt

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub
End Class