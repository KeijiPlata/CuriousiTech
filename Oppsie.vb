Public Class Oppsie
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