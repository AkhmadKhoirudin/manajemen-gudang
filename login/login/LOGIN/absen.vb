Imports System.Data.SQLite
Imports System.IO
Public Class absen
    Dim conn As SQLiteConnection
    Dim cmd As SQLiteCommand
    Dim da As SQLiteDataAdapter
    Dim dt As DataTable
    Dim interopPath As String
    Private selectedFilePath As String
    Dim destinationFileName As String = Path.GetFileName(selectedFilePath)
    Public Sub New()
        InitializeComponent()

        ' Logika penentuan path SQLite.Interop.dll berdasarkan arsitektur proses
        If Environment.Is64BitProcess Then
            interopPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "x64", "SQLite.Interop.dll")
        Else
            interopPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "x86", "SQLite.Interop.dll")
        End If

        Console.WriteLine("Path to SQLite.Interop.dll: " & interopPath)

        ' Gunakan interopPath sesuai kebutuhan Anda
    End Sub

    Private Sub LoadData()
        Try
            cmd = conn.CreateCommand()
            cmd.CommandText = "SELECT * FROM tb_Absen"
            da = New SQLiteDataAdapter(cmd)
            dt = New DataTable()
            da.Fill(dt)
            DataGridView1.DataSource = dt
            DataGridView1.ReadOnly = False
            conn.Close()
        Catch ex As Exception
            MessageBox.Show($"Error in LoadData(): {ex.Message}")
        End Try
        Button1.Hide()
    End Sub


    Private Sub absen_Load(sender As Object, e As EventArgs) Handles MyBase.Load


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
        HARI()

        Button1.Enabled = False

    End Sub
    Sub combobox()

        If ComboBox1.Text = "IZIN" Or ComboBox1.Text = "SAKIT" Or ComboBox1.Text = "" Then
            Button1.Enabled = False

        ElseIf ComboBox1.Text = "ALPA" Or ComboBox1.Text = "HADIR" Then
            Button1.Enabled = True
            Button1.Show()

        End If

    End Sub
    Sub HARI()
        Try
            ' Mengambil nilai dari TextBox TxtID
            Dim keyword As String = tgl.Text.Trim()

            ' Membuat perintah SQL parameterized
            Dim cmd As New SQLiteCommand("SELECT * FROM tb_Absen WHERE TANGGAL LIKE @keyword || '%'", conn)
            cmd.Parameters.AddWithValue("@keyword", keyword)

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            cmd.CommandType = CommandType.Text


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
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles tgl.ValueChanged
        HARI()
    End Sub


    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick

        Try
            Dim id As String = TextBox1.Text.Trim() ' Menggunakan tipe data String

            ' Validasi apakah nilai ID tidak kosong
            If Not String.IsNullOrEmpty(id) Then
                Dim connectionString As String = "Data Source=db_perusahaan.db;Version=3;"
                Dim query As String = "SELECT * FROM tb_Absen WHERE ID = @ID"

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

                                TextBox1.Text = id ' Tidak perlu konversi ke String
                                TextBox2.Text = nama
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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = row.Cells("ID").Value.ToString()
        End If
        ' Pastikan CellClick pada kolom yang sesuai
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridView1.Columns("Surat").Index Then
            ' Ambil nilai ID dan Nama Surat dari DataGridView
            Dim id As String = DataGridView1.Rows(e.RowIndex).Cells("ID").Value.ToString()
            Dim namaSurat As String = DataGridView1.Rows(e.RowIndex).Cells("Surat").Value.ToString()

            ' Tampilkan ID dan Nama Surat di TextBox
            TextBox1.Text = id
            TextBox2.Text = namaSurat
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        absensi()
        LoadData()
        HARI()
        ComboBox1.Text = ""
    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        ' Tangani kesalahan konversi di sini
        If e.Exception IsNot Nothing AndAlso TypeOf e.Exception Is ArgumentException Then


        Else
        End If

        ' Setel e.ThrowException ke False jika Anda ingin menangani kesalahan secara manual tanpa menampilkan dialog kesalahan default DataGridView
        e.ThrowException = False
    End Sub


    Private selectedFileExtension As String ' Menyimpan ekstensi file terpilih

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Membuka dialog pemilihan file
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "All Files|*.*" ' Menampilkan semua jenis file
            openFileDialog.Title = "Pilih File"

            ' Jika pengguna memilih file
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                ' Menyimpan path file yang dipilih
                selectedFilePath = openFileDialog.FileName

                ' Menyimpan ekstensi file terpilih
                selectedFileExtension = Path.GetExtension(selectedFilePath).ToLower()

                ' Menampilkan nama file tanpa ekstensi di TextBox
                TextBox2.Text = Path.GetFileNameWithoutExtension(selectedFilePath)
            End If
        End Using
        Button1.Enabled = True
        Button1.Show()

    End Sub


    Sub simpanDokumen()
        If Not String.IsNullOrEmpty(selectedFilePath) Then
            ' Menentukan direktori tujuan
            Dim destinationDirectory As String = Path.Combine(Application.StartupPath, "ijin")

            ' Jika direktori tujuan belum ada, buatlah
            If Not Directory.Exists(destinationDirectory) Then
                Directory.CreateDirectory(destinationDirectory)
            End If

            ' Menentukan nama file tujuan (dengan memanfaatkan TextBox atau memberikan nama file yang baru)
            Dim destinationFileName As String = Path.GetFileName(selectedFilePath)

            ' Menentukan path lengkap untuk file tujuan
            Dim destinationPath As String = Path.Combine(destinationDirectory, destinationFileName)

            ' Menyalin file ke direktori tujuan
            File.Copy(selectedFilePath, destinationPath, True)

            MessageBox.Show("File berhasil disimpan ")
        Else
            MessageBox.Show("Pilih file terlebih dahulu sebelum menyimpan.")
        End If
    End Sub

    Sub absensi()
        Try
            Dim id As String = TextBox1.Text ' Mengambil ID dari TextBox1
            Dim satatus As String = ComboBox1.SelectedItem.ToString()

            ' Mendapatkan tanggal saat ini
            Dim tanggal As String = DateTime.Now.ToString("yyyy-MM-dd")
            Dim jam As String = DateTime.Now.ToString("HH.mm")

            ' Baca berkas sebagai byte array (gantilah path berkas yang sesuai)
            Dim surat As String = TextBox2.Text

            ' Perbarui catatan dengan berkas dan status hanya jika ID dan TANGGAL cocok
            Using con As New SQLiteConnection("Data Source=db_perusahaan.db;Version=3;")
                con.Open()

                ' Periksa apakah data dengan ID dan TANGGAL yang sesuai sudah ada
                Dim queryCheckData As String = "SELECT COUNT(*) FROM tb_Absen WHERE ID = @ID AND TANGGAL = @Tanggal"
                Using cmdCheckData As New SQLiteCommand(queryCheckData, con)
                    cmdCheckData.Parameters.AddWithValue("@ID", id)
                    cmdCheckData.Parameters.AddWithValue("@Tanggal", tanggal)

                    Dim dataCount As Integer = CInt(cmdCheckData.ExecuteScalar())

                    If dataCount > 0 Then
                        ' Jika data sudah ada, lakukan update
                        Using cmdUpdate As New SQLiteCommand(con)
                            cmdUpdate.CommandText = "UPDATE tb_Absen SET STATUS = @Status, jam=@jam, SURAT = @SURAT WHERE ID = @ID AND TANGGAL = @Tanggal"
                            cmdUpdate.Parameters.AddWithValue("@ID", id)
                            cmdUpdate.Parameters.AddWithValue("@Status", satatus)
                            cmdUpdate.Parameters.AddWithValue("@jam", jam)
                            cmdUpdate.Parameters.AddWithValue("@SURAT", surat)
                            cmdUpdate.Parameters.AddWithValue("@Tanggal", tanggal)

                            cmdUpdate.ExecuteNonQuery()

                            MessageBox.Show("Data berhasil diupdate.")

                            If ComboBox1.Text = "IZIN" Or ComboBox1.Text = "SAKIT" Or ComboBox1.Text = "" Then
                                simpanDokumen()
                            ElseIf ComboBox1.Text = "ALPA" Or ComboBox1.Text = "HADIR" Then


                            End If
                        End Using
                    Else
                        MessageBox.Show("Data tidak ditemukan. Absen tidak ada yang diupdate.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error in UpdateDataWithCondition: {ex.Message}")
        End Try


    End Sub

    'Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    '    ' Mendapatkan nama file dari TextBox
    '    Dim fileName As String = TextBox2.Text

    '    ' Menentukan direktori tujuan (misalnya, "ijin" di bawah direktori aplikasi)
    '    Dim destinationDirectory As String = Path.Combine(Application.StartupPath, "ijin")

    '    ' Menentukan path lengkap untuk file tujuan dengan ekstensi .pdf
    '    Dim pdfFilePath7 As String = Path.Combine(destinationDirectory, fileName & ".pdf")
    '    Dim pdfFilePath1 As String = Path.Combine(destinationDirectory, fileName & ".docx")
    '    Dim pdfFilePath2 As String = Path.Combine(destinationDirectory, fileName & ".doc")
    '    Dim pdfFilePath3 As String = Path.Combine(destinationDirectory, fileName & ".pptx")
    '    Dim pdfFilePath4 As String = Path.Combine(destinationDirectory, fileName & ".ppt")
    '    Dim pdfFilePath5 As String = Path.Combine(destinationDirectory, fileName & ".xls")
    '    Dim pdfFilePath6 As String = Path.Combine(destinationDirectory, fileName & ".xlsx")


    '    ' Memastikan file .pdf ada sebelum mencoba membukanya
    '    If File.Exists(pdfFilePath1) Then
    '        Process.Start(pdfFilePath1)
    '    ElseIf File.Exists(pdfFilePath2) Then
    '        Process.Start(pdfFilePath2)
    '    ElseIf File.Exists(pdfFilePath3) Then
    '        Process.Start(pdfFilePath3)
    '    ElseIf File.Exists(pdfFilePath4) Then
    '        Process.Start(pdfFilePath4)
    '    ElseIf File.Exists(pdfFilePath5) Then
    '        Process.Start(pdfFilePath5)
    '    ElseIf File.Exists(pdfFilePath6) Then
    '        Process.Start(pdfFilePath6)
    '    ElseIf File.Exists(pdfFilePath7) Then
    '        Process.Start(pdfFilePath7)


    '        ' Membuka file PDF
    '        Try
    '            Process.Start(pdfFilePath1)
    '            Process.Start(pdfFilePath2)
    '            Process.Start(pdfFilePath3)
    '            Process.Start(pdfFilePath4)
    '            Process.Start(pdfFilePath5)
    '            Process.Start(pdfFilePath6)
    '            Process.Start(pdfFilePath7)
    '        Catch ex As Exception
    '            MessageBox.Show("Terjadi kesalahan saat membuka file PDF: " & ex.Message)
    '        End Try
    '    Else
    '        ' Jika file .pdf tidak ditemukan, tampilkan pesan
    '        MessageBox.Show("File tidak ditemukan.")
    '    End If
    'End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Mendapatkan nama file dari TextBox
        Dim fileName As String = TextBox2.Text

        ' Menentukan direktori tujuan (misalnya, "ijin" di bawah direktori aplikasi)
        Dim destinationDirectory As String = Path.Combine(Application.StartupPath, "ijin")

        ' Daftar ekstensi yang ingin dicoba
        Dim extensionsToTry As String() = {".pdf", ".docx", ".doc", ".pptx", ".ppt", ".xls", ".xlsx"}

        ' Mencoba membuka file dengan ekstensi yang ada
        Dim fileOpened As Boolean = False

        For Each extension As String In extensionsToTry
            Dim filePath As String = Path.Combine(destinationDirectory, fileName & extension)

            If File.Exists(filePath) Then
                Try
                    Process.Start(filePath)
                    fileOpened = True
                    Exit For ' Keluar dari loop jika file ditemukan dan berhasil dibuka
                Catch ex As Exception
                    ' Tangani kesalahan jika ada
                    MessageBox.Show($"Terjadi kesalahan saat membuka file {extension}: {ex.Message}")
                End Try
            End If
        Next

        If Not fileOpened Then
            ' Jika tidak ada file yang ditemukan
            MessageBox.Show("File tidak ditemukan.")
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        combobox()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        LoadData()
        HARI()
        ComboBox1.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
End Class