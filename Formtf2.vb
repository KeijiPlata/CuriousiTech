Public Class Formtf2
    Public highscore2 As Integer
    Public newhighscore As Integer
    Public displayScore As Integer
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Formtf1.PictureBox1.Size = New Size(1645, 962)
        Formtf1.PictureBox1.Location = New Point(-59, 0)
        Formtf1.PictureBox1.Visible = True


        ' display the score
        Label2.Text = displayScore.ToString

        ' highscore2 always get the old highscore
        Label5.Text = highscore2.ToString

        If displayScore > highscore2 Then
            Label3.Text = "New HighScore!"

            ' This is the updated highscore
            Label5.Text = newhighscore.ToString
        Else
            Label3.Text = "Score"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        ' opens mainmenu
        Formtf3.highest() ' This will refresh the highscore
        Formtf3.showScore() ' This will refresh the leaderboard
        Formtf3.Show()
        Me.Close()

    End Sub



    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox2.Click
        ' retry button, open again form1
        Formtf1.PictureBox1.Visible = False
        Me.Close()
        Formtf1.Show()
    End Sub
End Class