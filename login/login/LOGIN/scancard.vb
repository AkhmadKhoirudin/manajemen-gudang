Imports System.Data.SQLite
Public Class scancard
    Private isUIDDisplayed As Boolean = True ' Menyimpan status apakah UID ditampilkan atau tidak
    Private receivedUIDs As New HashSet(Of String)() ' HashSet untuk menyimpan UID yang sudah diterima
    Private Sub scancard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Menambahkan event handler secara manual setelah membuat instance dari modul
        AddHandler ESPModule.MessageReceived, AddressOf ESPMessageReceivedHandler
        ' Mulai mendengarkan koneksi saat form dimuat
        ESPModule.StartListening(12345)
        isUIDDisplayed = True
    End Sub
    Private Sub ESPMessageReceivedHandler(message As String)
        If isUIDDisplayed Then
            ' Mendapatkan UID dari pesan
            Dim receivedUID As String = message.Trim()

            ' Debug log: mencatat UID yang diterima
            Debug.WriteLine($"UID yang diterima: {receivedUID}")

            ' Menggunakan Invoke untuk memperbarui TextBox1 pada thread UI
            Me.Invoke(Sub() TextBox1.Text = receivedUID)
        End If
    End Sub

    Sub bio(ByVal dr As SQLiteDataReader)

        If dr.HasRows Then
            dr.Read()
            home.TextBox2.Text = dr("nama")
            home.TextBox1.Text = dr("id")

        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            ' Pastikan UID tidak kosong
            If String.IsNullOrEmpty(TextBox1.Text) Then
                MessageBox.Show("UID tidak boleh kosong.")
                Return
            End If

            Dim id As String = String.Empty
            Dim nama As String = String.Empty
            Dim uid As String = TextBox1.Text

            ' Query database
            Using con As New SQLiteConnection("Data Source=db_perusahaan.db;Version=3;")
                con.Open()

                Using transaction = con.BeginTransaction()
                    Try
                        ' SELECT FROM tb_pegawai
                        Using cmdSelect As New SQLiteCommand("SELECT id, nama FROM tb_pegawai WHERE uid = @uid", con)
                            cmdSelect.Parameters.AddWithValue("@uid", uid)
                            Using dr As SQLiteDataReader = cmdSelect.ExecuteReader()
                                If dr.HasRows Then
                                    dr.Read()
                                    id = dr("id").ToString()
                                    nama = dr("nama").ToString()

                                    ' Perbarui TextBox di form home
                                    home.TextBox2.Text = nama
                                    home.TextBox1.Text = id

                                    ' Perbarui biodata
                                    biodata.TxtID.Text = id
                                    biodata.TxtNama.Text = nama

                                    MessageBox.Show($"Selamat datang {nama} ")

                                    ' Query untuk memeriksa absen
                                    Using cmdCheckAbsen As New SQLiteCommand("SELECT COUNT(*) FROM tb_Absen WHERE ID = @ID AND TANGGAL = @TANGGAL", con)
                                        cmdCheckAbsen.Parameters.AddWithValue("@ID", id)
                                        cmdCheckAbsen.Parameters.AddWithValue("@TANGGAL", DateTime.Now.ToString("yyyy-MM-dd"))

                                        Dim absenCount As Integer = CInt(cmdCheckAbsen.ExecuteScalar())
                                        If absenCount > 0 Then
                                            ' Update data absen
                                            Using cmdUpdate As New SQLiteCommand(con)
                                                cmdUpdate.CommandText = "UPDATE tb_Absen SET NAMA = @NAMA, JAM = @JAM, STATUS = @STATUS WHERE ID = @ID AND TANGGAL = @TANGGAL"
                                                cmdUpdate.Parameters.AddWithValue("@ID", id)
                                                cmdUpdate.Parameters.AddWithValue("@NAMA", nama)
                                                cmdUpdate.Parameters.AddWithValue("@JAM", DateTime.Now.ToString("HH:mm"))
                                                cmdUpdate.Parameters.AddWithValue("@TANGGAL", DateTime.Now.ToString("yyyy-MM-dd"))
                                                cmdUpdate.Parameters.AddWithValue("@STATUS", "MASUK")

                                                cmdUpdate.ExecuteNonQuery()
                                            End Using
                                        Else
                                            MessageBox.Show("Anda belum melakukan absensi hari ini.")
                                        End If
                                    End Using
                                    ' Menyembunyikan form kartu dan menampilkan form home
                                    Me.Hide()
                                    home.Show()
                                    bukapanel(menuUtama)
                                Else
                                    MsgBox("UID tidak valid.")
                                End If
                            End Using
                        End Using
                        ' Commit transaksi
                        transaction.Commit()
                    Catch ex As Exception
                        ' Rollback transaksi jika terjadi kesalahan
                        transaction.Rollback()
                        MessageBox.Show($"Error saat membaca UID: {ex.Message}")
                    End Try
                End Using
                con.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error dalam TextBox1_TextChanged: {ex.Message}")
        End Try
    End Sub



    Private Sub scancard_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        ' Stop UID Display
        isUIDDisplayed = False

        TextBox1.Clear() ' Menghapus konten TextBox1

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        login.Show()

    End Sub
End Class