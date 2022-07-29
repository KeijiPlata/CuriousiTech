Imports System.Data
Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbCommand
Imports System.Data.OleDb.OleDbDataReader
Public Class SectionForm
    Dim con As New OleDbConnection(My.Settings.loginConnectionString)
    Dim UserID As String
    Dim Section As String
    Public Sub New(ByVal varUserId As String, ByVal varSection As String)
        InitializeComponent()
        UserID = varUserId
        Section = varSection
    End Sub
    Private Sub SectionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim dt As New DataTable
        Dim da As New OleDb.OleDbDataAdapter

        con.Open()
        Try
            'SELECT TABLE
            sql = "SELECT ClassSection,LastName,FirstName,MiddleName FROM TbUser INNER JOIN TbSection ON TbUser.UserID = TbSection.StudentID WHERE ClassSection='" & Section & "'"
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