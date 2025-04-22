Imports System.Data.SQLite
Public Class login

    Dim conn As SQLiteConnection
    Dim cmd As SQLiteCommand
    Dim da As SQLiteDataAdapter
    Dim dt As DataTable
    Dim dr As SQLiteDataReader
    Dim interopPath As String


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetWatermark(txtUsername, "Username", Color.Black)
        SetWatermark(txtPassword, "password", Color.Black)
        coba()
    End Sub
    Sub coba()
        Using con As New SQLiteConnection("Data Source=db_perusahaan.db;Version=3;")
            con.Open()

            ' Ambil data pegawai dari tb_pegawai
            Dim querySelectPegawai As String = "SELECT ID, NAMA FROM tb_pegawai"
            Using cmdSelectPegawai As New SQLiteCommand(querySelectPegawai, con)
                Using reader As SQLiteDataReader = cmdSelectPegawai.ExecuteReader()
                    ' Loop melalui data pegawai
                    While reader.Read()
                        Dim employeeID As String = reader("ID").ToString()
                        Dim employeeName As String = reader("NAMA").ToString()

                        ' Pemeriksaan apakah data sudah ada pada tanggal yang sama
                        Dim queryCheckAbsen As String = "SELECT COUNT(*) FROM tb_Absen WHERE ID = @ID AND TANGGAL = @TANGGAL"
                        Using cmdCheckAbsen As New SQLiteCommand(queryCheckAbsen, con)
                            cmdCheckAbsen.Parameters.AddWithValue("@ID", employeeID)
                            cmdCheckAbsen.Parameters.AddWithValue("@TANGGAL", DateTime.Now.ToString("yyyy-MM-dd"))

                            Dim absenCount As Integer = CInt(cmdCheckAbsen.ExecuteScalar())

                            If absenCount = 0 Then
                                ' Insert data pegawai ke tb_Absen
                                Using cmdInsert As New SQLiteCommand(con)
                                    cmdInsert.CommandText = "INSERT INTO tb_Absen (ID, NAMA, TANGGAL) VALUES (@ID, @NAMA, @TANGGAL)"
                                    cmdInsert.Parameters.AddWithValue("@ID", employeeID)
                                    cmdInsert.Parameters.AddWithValue("@NAMA", employeeName)
                                    cmdInsert.Parameters.AddWithValue("@TANGGAL", DateTime.Now.ToString("yyyy-MM-dd"))

                                    cmdInsert.ExecuteNonQuery()
                                End Using
                            End If
                            ' Jika sudah ada data, lewati
                        End Using
                    End While
                End Using
            End Using
        End Using
    End Sub

    Sub bio(ByVal dr As SQLiteDataReader)

        If dr.HasRows Then
            dr.Read()
            home.TextBox2.Text = dr("nama")
            home.TextBox1.Text = dr("id")
            txtUsername.Text = ""
            txtPassword.Text = ""

        End If
    End Sub

    Private Sub btnLogin_Click_1(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            Dim id As String = String.Empty
            Dim nama As String = String.Empty

            Dim querySelect As String = "SELECT id, nama FROM tb_pegawai WHERE username = @username AND password = @password"
            Dim queryCheckAbsen As String = "SELECT COUNT(*) FROM tb_Absen WHERE ID = @ID AND TANGGAL = @TANGGAL"

            Using con As New SQLiteConnection("Data Source=db_perusahaan.db;Version=3;")
                con.Open()

                Using transaction = con.BeginTransaction()
                    Try
                        ' SELECT FROM tb_pegawai
                        Using cmdSelect As New SQLiteCommand(querySelect, con)
                            cmdSelect.Parameters.Add(New SQLiteParameter("@username", DbType.String) With {.Value = txtUsername.Text})
                            cmdSelect.Parameters.Add(New SQLiteParameter("@password", DbType.String) With {.Value = txtPassword.Text})

                            Using dr As SQLiteDataReader = cmdSelect.ExecuteReader()
                                If dr.HasRows Then
                                    dr.Read()

                                    id = dr("id").ToString()
                                    nama = dr("nama").ToString()

                                    home.TextBox2.Text = nama
                                    home.TextBox1.Text = id
                                    biodata.TxtID.Text = id
                                    biodata.TxtNama.Text = nama

                                    MessageBox.Show($"Selamat datang {nama} ")

                                    ' CHECK tb_Absen
                                    Using cmdCheckAbsen As New SQLiteCommand(queryCheckAbsen, con)
                                        cmdCheckAbsen.Parameters.AddWithValue("@ID", id)
                                        cmdCheckAbsen.Parameters.AddWithValue("@TANGGAL", DateTime.Now.ToString("yyyy-MM-dd"))

                                        Dim absenCount As Integer = CInt(cmdCheckAbsen.ExecuteScalar())

                                        If absenCount > 0 Then
                                            ' Jika sudah ada data absen, UPDATE tb_Absen
                                            Using cmdUpdate As New SQLiteCommand(con)
                                                cmdUpdate.CommandText = "UPDATE tb_Absen SET NAMA = @NAMA, JAM = @JAM, STATUS = @STATUS WHERE ID = @ID AND TANGGAL = @TANGGAL"
                                                cmdUpdate.Parameters.AddWithValue("@ID", id)
                                                cmdUpdate.Parameters.AddWithValue("@NAMA", nama)
                                                cmdUpdate.Parameters.AddWithValue("@JAM", DateTime.Now.ToString("HH:mm "))
                                                cmdUpdate.Parameters.AddWithValue("@TANGGAL", DateTime.Now.ToString("yyyy-MM-dd"))
                                                cmdUpdate.Parameters.AddWithValue("@STATUS", "MASUK")

                                                cmdUpdate.ExecuteNonQuery()
                                            End Using
                                        Else
                                            MessageBox.Show("Anda belum melakukan absensi hari ini.")
                                        End If
                                    End Using

                                    ' Sembunyikan form login dan tampilkan form home
                                    Me.Hide()
                                    home.Show()
                                    bukapanel(menuUtama)
                                Else
                                    MsgBox("Maaf, username atau password Anda tidak valid.")
                                End If
                            End Using
                        End Using

                        ' Commit transaksi
                        transaction.Commit()
                    Catch ex As Exception
                        ' Rollback transaksi jika terjadi kesalahan
                        transaction.Rollback()
                        MessageBox.Show($"Error in btnLogin_Click: {ex.Message}")
                    End Try
                End Using
                con.Close()

            End Using
        Catch ex As Exception
            MessageBox.Show($"Error in btnLogin_Click: {ex.Message}")
        End Try

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        scancard.Show()

    End Sub
End Class
