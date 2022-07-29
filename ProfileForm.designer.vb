<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProfileForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProfileForm))
        Me.btnChangePassword = New System.Windows.Forms.Button()
        Me.btnChangeUserName = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBoxUserName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBoxPassword = New System.Windows.Forms.TextBox()
        Me.lblStudentID = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.SuspendLayout()
        '
        'btnChangePassword
        '
        Me.btnChangePassword.Location = New System.Drawing.Point(254, 499)
        Me.btnChangePassword.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(56, 21)
        Me.btnChangePassword.TabIndex = 8
        Me.btnChangePassword.Text = "change"
        Me.btnChangePassword.UseVisualStyleBackColor = True
        '
        'btnChangeUserName
        '
        Me.btnChangeUserName.Location = New System.Drawing.Point(254, 426)
        Me.btnChangeUserName.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnChangeUserName.Name = "btnChangeUserName"
        Me.btnChangeUserName.Size = New System.Drawing.Size(56, 21)
        Me.btnChangeUserName.TabIndex = 7
        Me.btnChangeUserName.Text = "change"
        Me.btnChangeUserName.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(147, 390)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Change username"
        '
        'txtBoxUserName
        '
        Me.txtBoxUserName.Location = New System.Drawing.Point(147, 406)
        Me.txtBoxUserName.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtBoxUserName.Name = "txtBoxUserName"
        Me.txtBoxUserName.Size = New System.Drawing.Size(162, 20)
        Me.txtBoxUserName.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(147, 462)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Change Password"
        '
        'txtBoxPassword
        '
        Me.txtBoxPassword.Location = New System.Drawing.Point(149, 477)
        Me.txtBoxPassword.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtBoxPassword.Name = "txtBoxPassword"
        Me.txtBoxPassword.Size = New System.Drawing.Size(162, 20)
        Me.txtBoxPassword.TabIndex = 2
        '
        'lblStudentID
        '
        Me.lblStudentID.AutoSize = True
        Me.lblStudentID.Location = New System.Drawing.Point(426, 277)
        Me.lblStudentID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStudentID.Name = "lblStudentID"
        Me.lblStudentID.Size = New System.Drawing.Size(58, 13)
        Me.lblStudentID.TabIndex = 1
        Me.lblStudentID.Text = "Student ID"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(426, 299)
        Me.lblUserName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(57, 13)
        Me.lblUserName.TabIndex = 0
        Me.lblUserName.Text = "UserName"
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(144, 207)
        Me.lblLastName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(55, 13)
        Me.lblLastName.TabIndex = 9
        Me.lblLastName.Text = "LastName"
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(236, 207)
        Me.lblFirstName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(54, 13)
        Me.lblFirstName.TabIndex = 10
        Me.lblFirstName.Text = "FirstName"
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.BorderRadius = 140
        Me.Guna2Elipse1.TargetControl = Me
        '
        'ProfileForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(966, 607)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.lblLastName)
        Me.Controls.Add(Me.btnChangePassword)
        Me.Controls.Add(Me.btnChangeUserName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.txtBoxUserName)
        Me.Controls.Add(Me.lblStudentID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtBoxPassword)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "ProfileForm"
        Me.Text = "Form5"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnChangePassword As Button
    Friend WithEvents btnChangeUserName As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBoxUserName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtBoxPassword As TextBox
    Friend WithEvents lblStudentID As Label
    Friend WithEvents lblUserName As Label
    Friend WithEvents lblLastName As Label
    Friend WithEvents lblFirstName As Label
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
End Class
