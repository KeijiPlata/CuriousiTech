﻿Public Class Formtf2
    Public highscore2 As Integer
    Public newhighscore As Integer
    Public displayScore As Integer
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' opens mainmenu
        Formtf3.highest() ' This will refresh the highscore
        Formtf3.showScore() ' This will refresh the leaderboard
        Formtf3.Show()
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' retry button, open again form1
        Me.Close()
        Formtf1.Show()

    End Sub
End Class