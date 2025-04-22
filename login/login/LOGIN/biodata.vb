Imports System.Data.SQLite
Imports System.IO
Public Class biodata
    Dim conn As SQLiteConnection
    Dim cmd As SQLiteCommand
    Dim da As SQLiteDataAdapter
    Dim dt As DataTable
    Dim interopPath As String


    Sub matitxt()
        Button1.Show()
        Button2.Hide()
        TxtID.Enabled = False
        TxtNama.Enabled = False
        TxtStatus.Enabled = False
        TxtJkl.Enabled = False
        TxtTanggalLahir.Enabled = False
        TxtAgama.Enabled = False
        TxtAlamat.Enabled = False
        TxtNo.Enabled = False
        TxtUsername.Enabled = False
        TxtPassword.Enabled = False
        txtemail.Enabled = False



    End Sub
    Sub bukatxt()
        Button1.Hide()
        Button2.Show()
        TxtID.Enabled = True
        TxtNama.Enabled = True
        TxtStatus.Enabled = True
        TxtJkl.Enabled = True
        TxtTanggalLahir.Enabled = True
        TxtAgama.Enabled = True
        TxtAlamat.Enabled = True
        TxtNo.Enabled = True
        TxtUsername.Enabled = True
        TxtPassword.Enabled = True
        txtemail.Enabled = True




    End Sub
    Private Sub biodata_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        matitxt()

        Try
            Dim appPath As String = AppDomain.CurrentDomain.BaseDirectory
            Dim dbPath As String = Path.Combine(appPath, "db_perusahaan.db")
            conn = New SQLiteConnection($"Data Source={dbPath};Version=3;")
            conn.Open()


        Catch ex As Exception
            MessageBox.Show($"Error in LoadData(): {ex.Message}")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        bukatxt()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            cmd = conn.CreateCommand()
            cmd.CommandText = "UPDATE tb_pegawai SET username=@username, password=@password, status=@status, nama=@nama, jkl=@jkl, tanggal_lahir=@tanggal_lahir, agama=@agama, alamat=@alamat, no=@no, email=@email  WHERE id=@id"
            cmd.Parameters.AddWithValue("@username", TxtUsername.Text)
            cmd.Parameters.AddWithValue("@password", TxtPassword.Text)
            cmd.Parameters.AddWithValue("@status", TxtStatus.Text)
            cmd.Parameters.AddWithValue("@nama", TxtNama.Text)
            cmd.Parameters.AddWithValue("@jkl", TxtJkl.Text)
            cmd.Parameters.AddWithValue("@tanggal_lahir", TxtTanggalLahir.Text)
            cmd.Parameters.AddWithValue("@agama", TxtAgama.Text)
            cmd.Parameters.AddWithValue("@alamat", TxtAlamat.Text)
            cmd.Parameters.AddWithValue("@no", TxtNo.Text)
            cmd.Parameters.AddWithValue("@email", txtemail.Text)
            cmd.Parameters.AddWithValue("@id", TxtID.Text)

            cmd.ExecuteNonQuery()
            matitxt()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btblistview.Click
        bukapanel(listuser)
        Me.Hide()
    End Sub

    Private Sub btmenuuser_Click(sender As Object, e As EventArgs) Handles btmenuuser.Click
        bukapanel(menuUser)
        Me.Hide()
    End Sub





    Private Sub TxtStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TxtStatus.SelectedIndexChanged
        If TxtStatus.Text = "admin" Then
            TxtID.Text = "ADN02"
        ElseIf TxtStatus.Text = "oprator" Then
            TxtID.Text = "OPR03"
        ElseIf TxtStatus.Text = "user" Then
            TxtID.Text = "USR04"
        ElseIf TxtStatus.Text = "administrator" Then
            TxtID.Text = "ADR01"
        Else TxtStatus.Text = "progremer"
            TxtID.Text = "00000"
        End If
    End Sub

    Private Sub TxtID_TextChanged(sender As Object, e As EventArgs) Handles TxtID.TextChanged

    End Sub
End Class