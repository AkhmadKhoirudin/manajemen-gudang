Imports System.Data.SQLite
Public Class home
    Inherits Form

    Private clickCount As Integer = 0
    Sub menubuka()
        clickCount += 1
        Dim originalText As String = bthome.Text
        Debug.WriteLine("clickCount: " & clickCount)
        Debug.WriteLine("Panel1.Width: " & Panel1.Width)

        If clickCount = 1 Then
            Panel1.Width += 100
            bthome.Text = "HOME"
            btinput.Text = "INPUT"
            btdb.Text = "DATABASE"
            btsetting.Text = "SETTING"
            btexit.Text = "EXIT"
            TextBox1.Show()
            TextBox2.Show()
        ElseIf clickCount = 2 Then
            menututup()
            clickCount = 0
        End If

    End Sub
    Sub menututup()
        If Panel1.Width > 100 Then
            Panel1.Width -= 100
            TextBox1.Hide()
            TextBox2.Hide()
            bthome.Text = ""
            btinput.Text = ""
            btdb.Text = ""
            btsetting.Text = ""
            btexit.Text = ""
        End If

    End Sub





    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        menututup()
        bukapanel(menuUtama)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        menubuka()
    End Sub


    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        menubuka()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub btexit_Click(sender As Object, e As EventArgs) Handles btexit.Click
        Me.Hide()
        login.Show()
        login.txtUsername.Text = ""
        login.txtPassword.Text = ""
    End Sub

    Private Sub bthome_Click(sender As Object, e As EventArgs) Handles bthome.Click
        bukapanel(menuUtama)
    End Sub




    'Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
    '    Dim id As Integer = Integer.Parse(TextBox1.Text)

    'Dim connectionString As String = "Data Source=db_perusahaan.db;Version=3;"
    'Dim query As String = "SELECT * FROM tb_pegawai WHERE ID = @ID"

    'Using connection As New SQLiteConnection(connectionString)
    '        connection.Open()

    '        Using command As New SQLiteCommand(query, connection)
    '            command.Parameters.AddWithValue("@ID", id)

    '            Using dr As SQLiteDataReader = command.ExecuteReader()
    'While dr.Read()

    'Dim nama As String = dr("nama").ToString()
    'Dim status As String = dr("status").ToString()
    'Dim jkl As String = dr("jkl").date()
    'Dim tgl As String = dr("tanggal_lahir").ToString()
    'Dim agama As String = dr("agama").ToString()
    'Dim alamat As String = dr("alamat").ToString()
    'Dim no As String = dr("no").ToString()
    'Dim user As String = dr("username").ToString()
    'Dim pass As String = dr("password").ToString()


    '                    biodata.TxtID.Text = TextBox1.Text
    '                    biodata.TxtNama.Text = nama
    '                    biodata.TxtStatus.Text = status
    '                    biodata.TxtJkl.Text = jkl
    '                    biodata.TxtTanggalLahir.Text = tgl
    '                    biodata.TxtAgama.Text = agama
    '                    biodata.TxtAlamat.Text = alamat
    '                    biodata.TxtNo.Text = no
    '                    biodata.TxtUsername.Text = user
    '                    biodata.TxtPassword.Text = pass
    '                End While
    'End Using
    'End Using
    'End Using
    'End Sub
    'End Sub

    Sub tampil()
        Try
            Dim id As String = TextBox1.Text.Trim() ' Menggunakan tipe data String

            ' Validasi apakah nilai ID tidak kosong
            If Not String.IsNullOrEmpty(id) Then
                Dim connectionString As String = "Data Source=db_perusahaan.db;Version=3;"
                Dim query As String = "SELECT * FROM tb_pegawai WHERE ID = @ID"

                Using connection As New SQLiteConnection(connectionString)
                    connection.Open()

                    Using command As New SQLiteCommand(query, connection)
                        command.Parameters.AddWithValue("@ID", id)

                        Using dr As SQLiteDataReader = command.ExecuteReader()
                            If dr.Read() Then
                                Dim nama As String = dr("nama").ToString()
                                Dim status As String = dr("status").ToString()
                                Dim jkl As String = dr("jkl").ToString()
                                Dim tgl As String = dr("tanggal_lahir").ToString()
                                Dim agama As String = dr("agama").ToString()
                                Dim alamat As String = dr("alamat").ToString()
                                Dim no As String = dr("no").ToString()
                                Dim user As String = dr("username").ToString()
                                Dim pass As String = dr("password").ToString()
                                Dim email As String = dr("email").ToString()

                                biodata.TxtID.Text = id ' Tidak perlu konversi ke String
                                biodata.TxtNama.Text = nama
                                biodata.TxtStatus.Text = status
                                biodata.TxtJkl.Text = jkl
                                biodata.TxtTanggalLahir.Text = tgl
                                biodata.TxtAgama.Text = agama
                                biodata.TxtAlamat.Text = alamat
                                biodata.TxtNo.Text = no
                                biodata.TxtUsername.Text = user
                                biodata.TxtPassword.Text = pass
                                biodata.txtemail.Text = email
                            Else
                                MessageBox.Show("ID tidak ditemukan.")
                            End If
                        End Using
                    End Using
                End Using
            Else
                MessageBox.Show("ID tidak boleh kosong.")
            End If
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}")
        End Try

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        tampil()
    End Sub

    Private Sub btinput_Click(sender As Object, e As EventArgs) Handles btinput.Click
        bukapanel(Input)
    End Sub
    Private Sub btdb_Click(sender As Object, e As EventArgs) Handles btdb.Click
        bukapanel(DATA)
    End Sub

End Class

