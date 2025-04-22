Imports System.Data.SQLite
Imports System.IO
Public Class register
    Dim conn As SQLiteConnection
    Dim cmd As SQLiteCommand
    Dim da As SQLiteDataAdapter
    Dim dt As DataTable
    Dim interopPath As String
    Sub jabatan()
        If TxtStatus.Text = "Administrator" Then
            bbbbb.Text = "ADM01"
        ElseIf TxtStatus.Text = "admin" Then
            bbbbb.Text = "AD02"
        Else TxtStatus.Text = "user"
            bbbbb.Text = "US03"
        End If

    End Sub
    Sub bt()
        TxtID.Text = ""
        TxtUsername.Text = ""
        TxtPassword.Text = ""
        TxtStatus.Text = ""
        TxtNama.Text = ""
        TxtAlamat.Text = ""
        TxtNo.Text = ""
        txtemail.Text = ""
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim appPath As String = AppDomain.CurrentDomain.BaseDirectory
            Dim dbPath As String = Path.Combine(appPath, "db_perusahaan.db")

            Using conn As New SQLiteConnection($"Data Source={dbPath};Version=3;Pooling=False;")
                conn.Open()

                Using cmd As New SQLiteCommand(conn)
                    cmd.CommandText = "INSERT INTO tb_pegawai (id, username, password, status, nama, jkl, tanggal_lahir, agama, alamat, no, email) VALUES (@id, @username, @password, @status, @nama, @jkl, @tanggal_lahir, @agama, @alamat, @no, @email)"
                    cmd.Parameters.AddWithValue("@id", bbbbb.Text & TxtID.Text)
                    cmd.Parameters.AddWithValue("@username", TxtUsername.Text)
                    cmd.Parameters.AddWithValue("@password", TxtPassword.Text)
                    cmd.Parameters.AddWithValue("@status", TxtStatus.Text)
                    cmd.Parameters.AddWithValue("@nama", TxtNama.Text)
                    cmd.Parameters.AddWithValue("@jkl", DBNull.Value)
                    cmd.Parameters.AddWithValue("@tanggal_lahir", DBNull.Value)
                    cmd.Parameters.AddWithValue("@agama", DBNull.Value)
                    cmd.Parameters.AddWithValue("@alamat", TxtAlamat.Text)
                    cmd.Parameters.AddWithValue("@no", TxtNo.Text)
                    cmd.Parameters.AddWithValue("@email", txtemail.Text) ' Gunakan ImageLocation atau sesuai kebutuhan

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            bt()
            MessageBox.Show("Data berhasil disisipkan.")
        Catch ex As Exception
            MessageBox.Show($"Error in Button1_Click(): {ex.Message}")
        End Try
    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TxtStatus.SelectedIndexChanged


        If TxtStatus.Text = "admin" Then
            bbbbb.Text = "ADN02"
        ElseIf TxtStatus.Text = "oprator" Then
            bbbbb.Text = "OPR03"
        ElseIf TxtStatus.Text = "user" Then
            bbbbb.Text = "USR04"
        ElseIf TxtStatus.Text = "administrator" Then
            bbbbb.Text = "ADR01"
        Else TxtStatus.Text = "progremer"
            bbbbb.Text = "00000"


        End If
    End Sub


    Private Sub TxtID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtID.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub



    Private Sub TxtNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNo.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SetWatermark(TxtUsername, "Username", Color.Black)
        SetWatermark(TxtPassword, "password", Color.Black)
        SetWatermark(TxtID, "no.ID", Color.Black)
        SetWatermark(txtemail, "Email", Color.Black)
        SetWatermark(TxtNama, "nama", Color.Black)
        SetWatermark(TxtStatus, "Status", Color.Black)
        SetWatermark(TxtUsername, "Username", Color.Black)
        SetWatermark(TxtAlamat, "Alamat", Color.Black)
        SetWatermark(TxtNo, "No.Telp", Color.Black)

    End Sub
End Class