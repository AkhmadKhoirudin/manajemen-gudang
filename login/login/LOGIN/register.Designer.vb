<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class register
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
        Me.TxtID = New System.Windows.Forms.TextBox()
        Me.bbbbb = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtNo = New System.Windows.Forms.TextBox()
        Me.TxtAlamat = New System.Windows.Forms.TextBox()
        Me.TxtNama = New System.Windows.Forms.TextBox()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.TxtUsername = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtID
        '
        Me.TxtID.Location = New System.Drawing.Point(84, 174)
        Me.TxtID.Name = "TxtID"
        Me.TxtID.Size = New System.Drawing.Size(121, 20)
        Me.TxtID.TabIndex = 0
        '
        'bbbbb
        '
        Me.bbbbb.AutoSize = True
        Me.bbbbb.Location = New System.Drawing.Point(43, 181)
        Me.bbbbb.Name = "bbbbb"
        Me.bbbbb.Size = New System.Drawing.Size(10, 13)
        Me.bbbbb.TabIndex = 1
        Me.bbbbb.Text = "-"
        '
        'TxtStatus
        '
        Me.TxtStatus.FormattingEnabled = True
        Me.TxtStatus.Items.AddRange(New Object() {"admin", "oprator", "user", "administrator", " progremer"})
        Me.TxtStatus.Location = New System.Drawing.Point(18, 147)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(187, 21)
        Me.TxtStatus.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtemail)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TxtNo)
        Me.Panel1.Controls.Add(Me.TxtAlamat)
        Me.Panel1.Controls.Add(Me.TxtNama)
        Me.Panel1.Controls.Add(Me.TxtPassword)
        Me.Panel1.Controls.Add(Me.TxtUsername)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TxtID)
        Me.Panel1.Controls.Add(Me.TxtStatus)
        Me.Panel1.Controls.Add(Me.bbbbb)
        Me.Panel1.Location = New System.Drawing.Point(312, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(223, 410)
        Me.Panel1.TabIndex = 3
        '
        'txtemail
        '
        Me.txtemail.Location = New System.Drawing.Point(18, 330)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(187, 20)
        Me.txtemail.TabIndex = 13
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.login.My.Resources.Resources.icons8_user_100
        Me.PictureBox1.Location = New System.Drawing.Point(62, 37)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 100)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(121, 358)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Close"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(18, 358)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Register"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(74, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "REGISTER"
        '
        'TxtNo
        '
        Me.TxtNo.Location = New System.Drawing.Point(18, 304)
        Me.TxtNo.Name = "TxtNo"
        Me.TxtNo.Size = New System.Drawing.Size(187, 20)
        Me.TxtNo.TabIndex = 8
        '
        'TxtAlamat
        '
        Me.TxtAlamat.Location = New System.Drawing.Point(18, 278)
        Me.TxtAlamat.Name = "TxtAlamat"
        Me.TxtAlamat.Size = New System.Drawing.Size(187, 20)
        Me.TxtAlamat.TabIndex = 7
        '
        'TxtNama
        '
        Me.TxtNama.Location = New System.Drawing.Point(18, 252)
        Me.TxtNama.Name = "TxtNama"
        Me.TxtNama.Size = New System.Drawing.Size(187, 20)
        Me.TxtNama.TabIndex = 6
        '
        'TxtPassword
        '
        Me.TxtPassword.Location = New System.Drawing.Point(18, 226)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.Size = New System.Drawing.Size(187, 20)
        Me.TxtPassword.TabIndex = 5
        '
        'TxtUsername
        '
        Me.TxtUsername.Location = New System.Drawing.Point(18, 200)
        Me.TxtUsername.Name = "TxtUsername"
        Me.TxtUsername.Size = New System.Drawing.Size(187, 20)
        Me.TxtUsername.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 177)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "UID:"
        '
        'register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "register"
        Me.Text = "register"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TxtID As TextBox
    Friend WithEvents bbbbb As Label
    Friend WithEvents TxtStatus As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtNo As TextBox
    Friend WithEvents TxtAlamat As TextBox
    Friend WithEvents TxtNama As TextBox
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents TxtUsername As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtemail As TextBox
End Class
