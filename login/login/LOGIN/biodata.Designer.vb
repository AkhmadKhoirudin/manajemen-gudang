<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class biodata
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
        Me.TxtNama = New System.Windows.Forms.TextBox()
        Me.TxtUsername = New System.Windows.Forms.TextBox()
        Me.TxtNo = New System.Windows.Forms.TextBox()
        Me.TxtAlamat = New System.Windows.Forms.TextBox()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtTanggalLahir = New System.Windows.Forms.DateTimePicker()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.TxtJkl = New System.Windows.Forms.ComboBox()
        Me.TxtAgama = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btblistview = New System.Windows.Forms.Button()
        Me.btmenuuser = New System.Windows.Forms.Button()
        Me.TxtStatus = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'TxtID
        '
        Me.TxtID.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TxtID.ForeColor = System.Drawing.Color.Black
        Me.TxtID.Location = New System.Drawing.Point(122, 80)
        Me.TxtID.Name = "TxtID"
        Me.TxtID.Size = New System.Drawing.Size(187, 20)
        Me.TxtID.TabIndex = 0
        '
        'TxtNama
        '
        Me.TxtNama.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TxtNama.ForeColor = System.Drawing.Color.Black
        Me.TxtNama.Location = New System.Drawing.Point(122, 106)
        Me.TxtNama.Name = "TxtNama"
        Me.TxtNama.Size = New System.Drawing.Size(187, 20)
        Me.TxtNama.TabIndex = 1
        '
        'TxtUsername
        '
        Me.TxtUsername.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TxtUsername.ForeColor = System.Drawing.Color.Black
        Me.TxtUsername.Location = New System.Drawing.Point(445, 106)
        Me.TxtUsername.Name = "TxtUsername"
        Me.TxtUsername.Size = New System.Drawing.Size(187, 20)
        Me.TxtUsername.TabIndex = 7
        '
        'TxtNo
        '
        Me.TxtNo.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TxtNo.ForeColor = System.Drawing.Color.Black
        Me.TxtNo.Location = New System.Drawing.Point(122, 244)
        Me.TxtNo.Name = "TxtNo"
        Me.TxtNo.Size = New System.Drawing.Size(187, 20)
        Me.TxtNo.TabIndex = 6
        '
        'TxtAlamat
        '
        Me.TxtAlamat.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TxtAlamat.ForeColor = System.Drawing.Color.Black
        Me.TxtAlamat.Location = New System.Drawing.Point(445, 214)
        Me.TxtAlamat.Multiline = True
        Me.TxtAlamat.Name = "TxtAlamat"
        Me.TxtAlamat.Size = New System.Drawing.Size(187, 72)
        Me.TxtAlamat.TabIndex = 5
        '
        'TxtPassword
        '
        Me.TxtPassword.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TxtPassword.ForeColor = System.Drawing.Color.Black
        Me.TxtPassword.Location = New System.Drawing.Point(445, 132)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.Size = New System.Drawing.Size(187, 20)
        Me.TxtPassword.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(557, 302)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Edit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(86, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "ID :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "NAMA  :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "JENIS KELAMIN :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "TANGGAL LAHIR :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(51, 247)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "NO.TELP :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(383, 217)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "ALAMAT :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(59, 217)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "AGAMA :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(363, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(365, 109)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "USERNAME :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(383, 83)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "STATUS :"
        '
        'TxtTanggalLahir
        '
        Me.TxtTanggalLahir.CustomFormat = "yyyy-MM-dd"
        Me.TxtTanggalLahir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TxtTanggalLahir.Location = New System.Drawing.Point(122, 158)
        Me.TxtTanggalLahir.Name = "TxtTanggalLahir"
        Me.TxtTanggalLahir.Size = New System.Drawing.Size(187, 20)
        Me.TxtTanggalLahir.TabIndex = 15
        Me.TxtTanggalLahir.Value = New Date(2023, 7, 5, 0, 0, 0, 0)
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(557, 302)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 22
        Me.Button2.Text = "Update"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(65, 273)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "EMAIL :"
        '
        'txtemail
        '
        Me.txtemail.BackColor = System.Drawing.SystemColors.ControlDark
        Me.txtemail.ForeColor = System.Drawing.Color.Black
        Me.txtemail.Location = New System.Drawing.Point(122, 270)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(187, 20)
        Me.txtemail.TabIndex = 23
        '
        'TxtJkl
        '
        Me.TxtJkl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TxtJkl.FormattingEnabled = True
        Me.TxtJkl.Items.AddRange(New Object() {"Laki-Laki", "Perempuan"})
        Me.TxtJkl.Location = New System.Drawing.Point(122, 132)
        Me.TxtJkl.Name = "TxtJkl"
        Me.TxtJkl.Size = New System.Drawing.Size(187, 21)
        Me.TxtJkl.TabIndex = 25
        '
        'TxtAgama
        '
        Me.TxtAgama.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TxtAgama.FormattingEnabled = True
        Me.TxtAgama.Items.AddRange(New Object() {"Islam", "Kristen", "Katolik", "Hindu", "Budha", "Konghucu"})
        Me.TxtAgama.Location = New System.Drawing.Point(122, 214)
        Me.TxtAgama.Name = "TxtAgama"
        Me.TxtAgama.Size = New System.Drawing.Size(187, 21)
        Me.TxtAgama.TabIndex = 26
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(363, 135)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "PASSWORD :"
        '
        'btblistview
        '
        Me.btblistview.Location = New System.Drawing.Point(3, 12)
        Me.btblistview.Name = "btblistview"
        Me.btblistview.Size = New System.Drawing.Size(63, 24)
        Me.btblistview.TabIndex = 28
        Me.btblistview.Text = "<back"
        Me.btblistview.UseVisualStyleBackColor = True
        '
        'btmenuuser
        '
        Me.btmenuuser.Location = New System.Drawing.Point(3, 12)
        Me.btmenuuser.Name = "btmenuuser"
        Me.btmenuuser.Size = New System.Drawing.Size(63, 24)
        Me.btmenuuser.TabIndex = 29
        Me.btmenuuser.Text = "<back"
        Me.btmenuuser.UseVisualStyleBackColor = True
        '
        'TxtStatus
        '
        Me.TxtStatus.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TxtStatus.FormattingEnabled = True
        Me.TxtStatus.Items.AddRange(New Object() {"admin", "oprator", "user", "administrator", "progremer"})
        Me.TxtStatus.Location = New System.Drawing.Point(445, 80)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(187, 21)
        Me.TxtStatus.TabIndex = 30
        '
        'biodata
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(823, 472)
        Me.Controls.Add(Me.TxtStatus)
        Me.Controls.Add(Me.btmenuuser)
        Me.Controls.Add(Me.btblistview)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtAgama)
        Me.Controls.Add(Me.TxtJkl)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtemail)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TxtTanggalLahir)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TxtPassword)
        Me.Controls.Add(Me.TxtUsername)
        Me.Controls.Add(Me.TxtNo)
        Me.Controls.Add(Me.TxtAlamat)
        Me.Controls.Add(Me.TxtNama)
        Me.Controls.Add(Me.TxtID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "biodata"
        Me.Text = "biodata"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtID As TextBox
    Friend WithEvents TxtNama As TextBox
    Friend WithEvents TxtUsername As TextBox
    Friend WithEvents TxtNo As TextBox
    Friend WithEvents TxtAlamat As TextBox
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtTanggalLahir As DateTimePicker
    Friend WithEvents Button2 As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents txtemail As TextBox
    Friend WithEvents TxtJkl As ComboBox
    Friend WithEvents TxtAgama As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btblistview As Button
    Friend WithEvents btmenuuser As Button
    Friend WithEvents TxtStatus As ComboBox
End Class
