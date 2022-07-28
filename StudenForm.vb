Imports System.Data
Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbCommand
Imports System.Data.OleDb.OleDbDataReader

Public Class StudenForm
    Dim con As New OleDbConnection(My.Settings.loginConnectionString)
    Dim con2 As New OleDb.OleDbConnection(My.Settings.leaderboardConnectionString)
    'CONSTRUCTOR
    Dim LastName As String
    Dim FirstName As String
    Dim MiddleName As String
    Dim UserName As String
    Dim StudentID As String
    Dim UserID As Long
    Dim Section As String

    Public Sub showScore()
        Dim scores(10) As Integer
        Dim scores2(10) As Integer
        Dim totalscores(10) As Integer
        Dim names(10) As String
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim myreader As OleDbDataReader

        con2.Open()
        ' This will get the score from the database
        sql = "Select TOP 10 * from leaderboardtruefalse Order By Score DESC"
        cmd.Connection = con2
        cmd.CommandText = sql

        ' read
        myreader = cmd.ExecuteReader

        If myreader.HasRows Then
            For i As Integer = 1 To 10 Step 1
                myreader.Read()
                scores(i) = myreader("Score")
                names(i) = myreader("UserName")
            Next
        End If

        con2.Close()

        ' put the the data inside the label
        top1score.Text = scores(1).ToString
        top1name.Text = names(1).ToString
        top2score.Text = scores(2).ToString
        top2name.Text = names(2).ToString
        top3score.Text = scores(3).ToString
        top3name.Text = names(3).ToString
        top4score.Text = scores(4).ToString
        top4name.Text = names(4).ToString
        top5score.Text = scores(5).ToString
        top5name.Text = names(5).ToString
        top6score.Text = scores(6).ToString
        top6name.Text = names(6).ToString
        top7score.Text = scores(7).ToString
        top7name.Text = names(7).ToString
        top8score.Text = scores(8).ToString
        top8name.Text = names(8).ToString
        top9score.Text = scores(9).ToString
        top9name.Text = names(9).ToString
        top10score.Text = scores(10).ToString
        top10name.Text = names(10).ToString

    End Sub
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

            Section = myreader("Room")
            lblFullName.Text = LastName + " " + FirstName + " " + MiddleName
            lblSection.Text = Section

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
        Oppsie.Show()

    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click
        TrueorFalseInstruction.Show()

    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Dim sectionForm = New SectionForm(UserID, Section)
        sectionForm.Show()
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles top5name.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles top1score.Click

    End Sub
End Class