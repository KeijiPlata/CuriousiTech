Public Class Oppsie
    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox2.Click
        Dim StudentForm = New StudenForm(LogInForm.reader("TbUser", "LastName"), LogInForm.reader("TbUser", "FirstName"), LogInForm.reader("TbUser", "MiddleName"), LogInForm.reader("TbUser", "UserName"), LogInForm.reader("TbUser", "StudentID"), LogInForm.reader("TbUser", "UserID"))
        StudentForm.PictureBox1.Visible = False
        Me.Close()
        BlurredBG.Close()


    End Sub
End Class