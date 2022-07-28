Imports System.Data
Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbCommand
Imports System.Data.OleDb.OleDbDataReader

Public Class StudenForm
    Dim con As New OleDbConnection(My.Settings.loginConnectionString)
    'CONSTRUCTOR
    Dim LastName As String
    Dim FirstName As String
    Dim MiddleName As String
    Dim UserName As String
    Dim StudentID As String
    Dim UserID As Long
    Public Sub New(ByVal varLastName As String, ByVal varFirstName As String, ByVal varMiddleName As String, ByVal varUserName As String, ByVal varStudentID As String, ByVal varUserID As Long)
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
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Try
            'SETS LABLES
            Dim sql As String
            Dim cmd As New OleDbCommand
            Dim myreader As OleDbDataReader

            con.Open()
            'SELECT TABLE INPUTED USERNAME
            sql = "SELECT Room FROM TbJunction Where UserID=" & UserID & ""
            cmd.Connection = con
            cmd.CommandText = sql
            myreader = cmd.ExecuteReader
            myreader.Read()

            lblFullName.Text = LastName + " " + FirstName + " " + MiddleName
            lblSection.Text = myreader("Room")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub btnProfile_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnTorF_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblFullName_Click(sender As Object, e As EventArgs) Handles lblFullName.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim answer As Integer

        answer = MsgBox("are you sure you want to log out?", vbQuestion + vbYesNo + vbDefaultButton2, "LOG OUT")
        If answer = vbYes Then
            LogInForm.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        'OPENS PROFILE FORM
        Dim profile = New ProfileForm(LastName, FirstName, MiddleName, UserName, StudentID, UserID)
        profile.Show()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Dim TF = New Formtf3
        TF.Show()
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        PictureBox1.Size = New Size(1645, 962)
        PictureBox1.Location = New Point(-59, 0)
        PictureBox1.Visible = True
        Oppsie.Show()

    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click
        PictureBox1.Size = New Size(1645, 962)
        PictureBox1.Location = New Point(-59, 0)
        PictureBox1.Visible = True
        TrueorFalseInstruction.Show()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Guna2PictureBox4_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox4.Click
        PictureBox1.Size = New Size(1645, 962)
        PictureBox1.Location = New Point(-59, 0)
        PictureBox1.Visible = True
        QuiziItUpInstructions.Show()

    End Sub

    Private Sub Guna2PictureBox3_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox3.Click
        PictureBox1.Size = New Size(1645, 962)
        PictureBox1.Location = New Point(-59, 0)
        PictureBox1.Visible = True
        TheWhatInstructions.Show()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        PictureBox1.Size = New Size(1645, 962)
        PictureBox1.Location = New Point(-59, 0)
        PictureBox1.Visible = True
        AboutUs.Show()


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class