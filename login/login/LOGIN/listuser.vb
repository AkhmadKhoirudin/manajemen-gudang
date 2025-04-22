Imports System.Data.SQLite
Imports System.IO
Public Class listuser
    Dim conn As SQLiteConnection
    Dim cmd As SQLiteCommand
    Dim da As SQLiteDataAdapter
    Dim dt As DataTable
    Dim interopPath As String


    Private Sub LoadData()
        Try
            cmd = conn.CreateCommand()
            cmd.CommandText = "SELECT * FROM tb_pegawai"
            da = New SQLiteDataAdapter(cmd)
            dt = New DataTable()
            da.Fill(dt)
            DataGridView1.DataSource = dt
            DataGridView1.ReadOnly = False
            conn.Close()
        Catch ex As Exception
            MessageBox.Show($"Error in LoadData(): {ex.Message}")
        End Try
    End Sub




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            ' Assuming conn is your SQLite connection
            If conn.State = ConnectionState.Closed Then
                conn.Open() ' Open the connection if it's not already open
            End If

            Dim id As String = TxtID.Text
            cmd = conn.CreateCommand()
            cmd.CommandText = "DELETE FROM tb_pegawai WHERE id=@id"
            cmd.Parameters.AddWithValue("@id", id)
            cmd.ExecuteNonQuery()
            LoadData()
            MessageBox.Show("Data berhasil dihapus.")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close() ' Close the connection in the finally block to ensure it's closed even if an exception occurs
            End If
        End Try
        oprator()
        total()

    End Sub

    Private Sub sds_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetWatermark(TxtID, "Masukan ID atau Nama", Color.Black)


        Try
            Dim appPath As String = AppDomain.CurrentDomain.BaseDirectory
            Dim dbPath As String = Path.Combine(appPath, "db_perusahaan.db")
            conn = New SQLiteConnection($"Data Source={dbPath};Version=3;")
            conn.Open()
            LoadData()
            LoadData()

        Catch ex As Exception
            MessageBox.Show($"Error in LoadData(): {ex.Message}")
        End Try
        total()
        oprator()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' Mengambil nilai dari TextBox TxtID
            Dim keyword As String = TxtID.Text.Trim()

            ' Membuat perintah SQL parameterized
            Dim cmd As New SQLiteCommand("SELECT * FROM tb_pegawai WHERE id LIKE @keyword || '%' OR nama LIKE @keyword || '%'", conn)
            cmd.Parameters.AddWithValue("@keyword", keyword)

            ' Membuka koneksi (conn) jika belum terbuka
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            ' Mengeset CommandType
            cmd.CommandType = CommandType.Text

            ' Membuat objek DataTable dan mengisi data
            Dim dt As New DataTable()
            Using da As New SQLiteDataAdapter(cmd)
                da.Fill(dt)
            End Using

            ' Menutup koneksi
            conn.Close()

            ' Menampilkan hasil di DataGridView
            DataGridView1.DataSource = dt
        Catch ex As Exception
            ' Menangani exception (misalnya, tampilkan pesan kesalahan)
            MessageBox.Show("Terjadi kesalahan: " & ex.Message)
        End Try

    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)
            TxtID.Text = row.Cells("id").Value.ToString()
        End If


    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        biodata.TxtID.Text = "" ' Tidak perlu konversi ke String
        biodata.TxtNama.Text = ""
        biodata.TxtStatus.Text = ""
        biodata.TxtJkl.Text = ""
        biodata.TxtTanggalLahir.Text = ""
        biodata.TxtAgama.Text = ""
        biodata.TxtAlamat.Text = ""
        biodata.TxtNo.Text = ""
        biodata.TxtUsername.Text = ""
        biodata.TxtPassword.Text = ""
        biodata.txtemail.Text = ""
        biodata.btblistview.Show()

        Try
            Dim id As String = TxtID.Text.Trim() ' Menggunakan tipe data String

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

                                Me.Hide()
                                bukapanel(biodata)
                                biodata.btmenuuser.Hide()
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



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        LoadData()
        total()
        oprator()

    End Sub

    Private Sub TxtID_TextChanged(sender As Object, e As EventArgs) Handles TxtID.TextChanged
        If TxtID.Text = "" Then
            LoadData()
        End If
    End Sub
    Private Sub total()
        ' Menghitung total baris dalam DataGridView
        Dim totalBaris As Integer = DataGridView1.Rows.Count

        ' Menampilkan total baris di TextBox
        TextBox1.Text = totalBaris.ToString() - 1
    End Sub

    Private Sub oprator()
        ' Menghitung jumlah orang dengan status "operator"
        Dim jumlahOperator As Integer = 0

        For Each row As DataGridViewRow In DataGridView1.Rows
            ' Ganti "Status" dengan nama kolom yang sesuai di DataGridView
            Dim cell As DataGridViewCell = row.Cells("Status")

            ' Periksa apakah sel tidak null sebelum mengakses propertinya
            If cell IsNot Nothing AndAlso cell.Value IsNot Nothing Then
                Dim status As String = cell.Value.ToString()

                ' Melakukan operasi sesuai kebutuhan
                If status = "oprator" Then
                    jumlahOperator += 1
                End If
            End If
        Next

        ' Menampilkan jumlah operator di TextBox
        TextBox2.Text = jumlahOperator.ToString()
    End Sub


End Class