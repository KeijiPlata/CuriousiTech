<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TeacherProfile
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TeacherProfile))
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2PictureBox2 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnChangeUserName = New Guna.UI2.WinForms.Guna2Button()
        Me.txtBoxUserName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnChangePassword = New Guna.UI2.WinForms.Guna2Button()
        Me.txtBoxPassword = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.Guna2PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.BorderRadius = 140
        Me.Guna2Elipse1.TargetControl = Me
        '
        'Guna2PictureBox2
        '
        Me.Guna2PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Guna2PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Guna2PictureBox2.Image = CType(resources.GetObject("Guna2PictureBox2.Image"), System.Drawing.Image)
        Me.Guna2PictureBox2.ImageRotate = 0!
        Me.Guna2PictureBox2.Location = New System.Drawing.Point(854, 44)
        Me.Guna2PictureBox2.Name = "Guna2PictureBox2"
        Me.Guna2PictureBox2.Size = New System.Drawing.Size(41, 37)
        Me.Guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2PictureBox2.TabIndex = 27
        Me.Guna2PictureBox2.TabStop = False
        Me.Guna2PictureBox2.UseTransparentBackground = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(118, 433)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(142, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Change Password"
        '
        'btnChangeUserName
        '
        Me.btnChangeUserName.BackColor = System.Drawing.Color.Transparent
        Me.btnChangeUserName.BorderColor = System.Drawing.Color.Transparent
        Me.btnChangeUserName.BorderRadius = 10
        Me.btnChangeUserName.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnChangeUserName.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnChangeUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnChangeUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnChangeUserName.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnChangeUserName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnChangeUserName.ForeColor = System.Drawing.Color.White
        Me.btnChangeUserName.Location = New System.Drawing.Point(361, 378)
        Me.btnChangeUserName.Name = "btnChangeUserName"
        Me.btnChangeUserName.Size = New System.Drawing.Size(115, 37)
        Me.btnChangeUserName.TabIndex = 25
        Me.btnChangeUserName.Text = "Change"
        '
        'txtBoxUserName
        '
        Me.txtBoxUserName.BackColor = System.Drawing.Color.Transparent
        Me.txtBoxUserName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.txtBoxUserName.BorderRadius = 10
        Me.txtBoxUserName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBoxUserName.DefaultText = ""
        Me.txtBoxUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtBoxUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtBoxUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBoxUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBoxUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBoxUserName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBoxUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBoxUserName.Location = New System.Drawing.Point(121, 374)
        Me.txtBoxUserName.Name = "txtBoxUserName"
        Me.txtBoxUserName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtBoxUserName.PlaceholderText = ""
        Me.txtBoxUserName.SelectedText = ""
        Me.txtBoxUserName.Size = New System.Drawing.Size(204, 30)
        Me.txtBoxUserName.TabIndex = 24
        '
        'btnChangePassword
        '
        Me.btnChangePassword.BackColor = System.Drawing.Color.Transparent
        Me.btnChangePassword.BorderColor = System.Drawing.Color.Transparent
        Me.btnChangePassword.BorderRadius = 10
        Me.btnChangePassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnChangePassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnChangePassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnChangePassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnChangePassword.FillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnChangePassword.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnChangePassword.ForeColor = System.Drawing.Color.White
        Me.btnChangePassword.Location = New System.Drawing.Point(361, 453)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(115, 37)
        Me.btnChangePassword.TabIndex = 23
        Me.btnChangePassword.Text = "Change"
        '
        'txtBoxPassword
        '
        Me.txtBoxPassword.BackColor = System.Drawing.Color.Transparent
        Me.txtBoxPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.txtBoxPassword.BorderRadius = 10
        Me.txtBoxPassword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBoxPassword.DefaultText = ""
        Me.txtBoxPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtBoxPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtBoxPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBoxPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBoxPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBoxPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBoxPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBoxPassword.Location = New System.Drawing.Point(121, 453)
        Me.txtBoxPassword.Name = "txtBoxPassword"
        Me.txtBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtBoxPassword.PlaceholderText = ""
        Me.txtBoxPassword.SelectedText = ""
        Me.txtBoxPassword.Size = New System.Drawing.Size(204, 30)
        Me.txtBoxPassword.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label4.Location = New System.Drawing.Point(118, 358)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Change Username"
        '
        'lblFullName
        '
        Me.lblFullName.AutoSize = True
        Me.lblFullName.BackColor = System.Drawing.Color.Transparent
        Me.lblFullName.Font = New System.Drawing.Font("Rubik", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFullName.ForeColor = System.Drawing.Color.White
        Me.lblFullName.Location = New System.Drawing.Point(111, 157)
        Me.lblFullName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(260, 60)
        Me.lblFullName.TabIndex = 20
        Me.lblFullName.Text = "Full Name"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.Font = New System.Drawing.Font("Rubik", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.Color.White
        Me.lblUserName.Location = New System.Drawing.Point(657, 358)
        Me.lblUserName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(155, 36)
        Me.lblUserName.TabIndex = 18
        Me.lblUserName.Text = "UserName"
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(646, 340)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Username"
        '
        'TeacherProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(950, 568)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Guna2PictureBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnChangeUserName)
        Me.Controls.Add(Me.txtBoxUserName)
        Me.Controls.Add(Me.btnChangePassword)
        Me.Controls.Add(Me.txtBoxPassword)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.lblUserName)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "TeacherProfile"
        Me.Text = "TeacherProfile"
        CType(Me.Guna2PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2PictureBox2 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnChangeUserName As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtBoxUserName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnChangePassword As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtBoxPassword As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lblFullName As Label
    Friend WithEvents lblUserName As Label
    Friend WithEvents Label1 As Label
End Class
