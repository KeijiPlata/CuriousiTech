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
    Dim timee As Integer = 3
    Dim usernamee As String = LogInForm.getUserNamee.ToString
    Dim openn As Boolean = False
    Dim openn2 As Boolean = False
    Dim MusicIsPlaying As Boolean

    ' get the true or false highscore base on username
    Private Sub getTrueFalseScore()
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim myreader As OleDbDataReader

        con2.Open()
        ' This will get the score from the database
        sql = "Select * from leaderboardtruefalse where UserName='" & usernamee & "'"
        cmd.Connection = con2
        cmd.CommandText = sql

        myreader = cmd.ExecuteReader
        myreader.Read()

        Guna2HtmlLabel2.Text = myreader("Score")
        con2.Close()


    End Sub

    Private Sub getQuizGameScore()
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim myreader As OleDbDataReader

        con2.Open()
        ' This will get the score from the database
        sql = "Select * from leaderboardquizgame where UserName='" & usernamee & "'"
        cmd.Connection = con2
        cmd.CommandText = sql

        myreader = cmd.ExecuteReader
        myreader.Read()

        Guna2HtmlLabel5.Text = myreader("Score")
        con2.Close()


    End Sub
    Private Sub bothScores()
        Dim scores(10) As Integer
        Dim scores2(10) As Integer
        Dim addBoth(10) As Integer
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim myreader As OleDbDataReader

        For i As Integer = 1 To 10 Step 1
            con2.Open()
            ' This will get the score from the database
            sql = "Select * from leaderboardtruefalse where id =" & i & ""
            cmd.Connection = con2
            cmd.CommandText = sql

            myreader = cmd.ExecuteReader
            myreader.Read()

            scores(i) = myreader("Score")
            con2.Close()

            con2.Open()
            ' This will get the score from the database
            sql = "Select * from leaderboardquizgame where id =" & i & ""
            cmd.Connection = con2
            cmd.CommandText = sql

            myreader = cmd.ExecuteReader
            myreader.Read()

            scores2(i) = myreader("Score")
            con2.Close()

            addBoth(i) = scores(i) + scores2(i)

            con2.Open()
            sql = "Update leaderboardoverall set Score=" & addBoth(i) & " where id = " & i & ""
            cmd.Connection = con2
            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
            con2.Close()

        Next
    End Sub
    Public Sub showScore()
        Dim scores(10) As Integer
        Dim names(10) As String
        Dim sql As String
        Dim cmd As New OleDb.OleDbCommand
        Dim myreader As OleDbDataReader

        con2.Open()
        ' This will get the score from the database
        sql = "Select TOP 10 * from leaderboardoverall Order By Score DESC"
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

        My.Computer.Audio.Play(My.Resources.lobby_sound, AudioPlayMode.BackgroundLoop)
        MusicIsPlaying = True

        'transparent
        Me.PictureBox1.Location = Me.bg1.PointToClient(Me.PointToScreen(Me.PictureBox1.Location))
        Me.PictureBox1.Parent = Me.bg1

        Label2.Visible = False

        Me.Label2.Location = Me.bg1.PointToClient(Me.PointToScreen(Me.Label2.Location))
        Me.Label2.Parent = Me.bg1


        Me.Label1.Location = Me.bg1.PointToClient(Me.PointToScreen(Me.Label1.Location))
        Me.Label1.Parent = Me.bg1

        PictureBox1.Visible = False
        Guna2PictureBox5.Visible = False

        ' this will show the highscore for Quiz game 
        getQuizGameScore()

        ' this will show the highscore for true or false
        getTrueFalseScore()


        ' this will show the overall scores of both games
        bothScores()
        showScore()

        ' hide the picturebox and label
        bg1.Visible = False
        Label1.Visible = False
        Timer1.Enabled = False

        Try
            'SETS LABLES
            Dim sql As String
            Dim cmd As New OleDbCommand
            Dim myreader As OleDbDataReader

            con.Open()
            'SELECT TABLE INPUTED USERNAME
            sql = "SELECT Room FROM TbJunction Where UserID=" & CInt(UserID) & ""
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
        Me.Close()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        ' this will open the true or false game
        Timer1.Enabled = True
        bg1.Visible = True
        Label1.Visible = True
        Timer1.Start()
        openn = True

        My.Computer.Audio.Stop()

    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        Oppsie.Show()
        Me.Close()

    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click

        'TrueorFalseInstruction.Show()
        bg1.Visible = True
        PictureBox1.Image = My.Resources.True_Or_False__Instructions
        PictureBox1.Visible = True
        Guna2PictureBox5.Visible = True

    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Oppsie.Show()
        Me.Close()
    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        ' show the quiz game and exit main menu
        Timer1.Enabled = True
        bg1.Visible = True
        Label1.Visible = True
        Timer1.Start()
        openn2 = True

        My.Computer.Audio.Stop()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        timee = timee - 1
        Label1.Text = timee.ToString

        If timee = 0 Then
            Label2.Visible = True
            Label1.Visible = False
        End If

        If timee = -1 Then
            If openn = True Then
                Timer1.Stop()
                Formtf1.Show()
                Me.Close()
            ElseIf openn2 = True Then
                Timer1.Stop()
                Formmcq1.Show()
                Me.Close()
            End If
        End If

    End Sub

    Private Sub Guna2PictureBox4_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox4.Click
        bg1.Visible = True
        ' QuiziItUpInstructions.Show()
        PictureBox1.Image = My.Resources.Quiz_It_Up__Instructions
        PictureBox1.Visible = True
        Guna2PictureBox5.Visible = True
    End Sub

    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox2.Click
        Oppsie.Show()
        Me.Close()

    End Sub

    Private Sub Guna2PictureBox5_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox5.Click
        PictureBox1.Visible = False
        bg1.Visible = False
        Guna2PictureBox5.Visible = False

    End Sub

    Private Sub Guna2PictureBox3_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox3.Click
        bg1.Visible = True
        PictureBox1.Image = My.Resources.The_What__Instructions
        PictureBox1.Visible = True
        Guna2PictureBox5.Visible = True
    End Sub

    Private Sub bg1_Click(sender As Object, e As EventArgs) Handles bg1.Click

    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        AboutUs.Show()
        Me.Close()

    End Sub


    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub top2score_Click(sender As Object, e As EventArgs) Handles top2score.Click

    End Sub

    Private Sub top1score_Click(sender As Object, e As EventArgs) Handles top1score.Click

    End Sub

    Private Sub top3score_Click(sender As Object, e As EventArgs) Handles top3score.Click

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If MusicIsPlaying Then
            Button1.Image = My.Resources.mute
            My.Computer.Audio.Stop()
            MusicIsPlaying = False
        Else
            Button1.Image = My.Resources.unmute
            My.Computer.Audio.Play(My.Resources.lobby_sound, AudioPlayMode.BackgroundLoop)
            MusicIsPlaying = True
        End If


    End Sub
End Class