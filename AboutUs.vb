Public Class AboutUs
    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox2.Click
        Dim StudentForm = New StudenForm(LogInForm.reader("TbUser", "LastName"), LogInForm.reader("TbUser", "FirstName"), LogInForm.reader("TbUser", "MiddleName"), LogInForm.reader("TbUser", "UserName"), LogInForm.reader("TbUser", "StudentID"), LogInForm.reader("TbUser", "UserID"))
        StudentForm.Show()
        Me.Close()


    End Sub
End Class