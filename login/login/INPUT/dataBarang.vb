Imports System.Globalization

Public Class inBarang
    Private Sub inBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ' Mengatur ListView
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.GridLines = True

        ' Menambahkan kolom
        ListView1.Columns.Add("Kode Barang", 100, HorizontalAlignment.Left)
        ListView1.Columns.Add("Nama Barang", 150, HorizontalAlignment.Left)
        ListView1.Columns.Add("Jumlah", 50, HorizontalAlignment.Right)
        ListView1.Columns.Add("Harga", 100, HorizontalAlignment.Right)
        ListView1.Columns.Add("Total", 100, HorizontalAlignment.Right)
        ListView1.Columns.Add("diskon", 50, HorizontalAlignment.Right)

        'IDTransaksi Menghasilkan format kode transaksi MM.DD.HH.MM
        Dim now As DateTime = DateTime.Now
        Dim kodeTransaksi As String = now.ToString("MM.dd.HH.mm")
        IDTransaksi.Text = kodeTransaksi
    End Sub
    Private Sub HitungTotal()
        Dim totalAmount As Decimal = 0

        ' Iterasi melalui setiap item di ListView
        For Each item As ListViewItem In ListView1.Items
            Dim totalText As String = item.SubItems(4).Text ' Kolom "Total" berada di indeks 4
            Dim totalValue As Decimal

            ' Konversi teks langsung ke Decimal
            If Decimal.TryParse(totalText.Replace(",", "").Replace(".", ""), totalValue) Then
                totalAmount += totalValue
            End If
        Next

        ' Menampilkan hasil di bayar.Text tanpa format mata uang
        bayar.Text = totalAmount.ToString("N0") ' Menampilkan angka dengan pemisah ribuan
    End Sub

    Sub FormatUang(ByRef textBox As TextBox)
        ' Simpan posisi kursor
        Dim posisiKursor As Integer = textBox.SelectionStart

        ' Mendapatkan nilai dari TextBox
        Dim nilai As String = textBox.Text

        ' Menghapus karakter non-digit dari string, kecuali koma
        Dim angkaHanyaDigit As String = New String(nilai.Where(Function(c) Char.IsDigit(c) OrElse c = ","c).ToArray())

        ' Jika string kosong, kembalikan
        If String.IsNullOrEmpty(angkaHanyaDigit) Then
            textBox.Text = ""
            ' Kembalikan posisi kursor ke posisi awal
            textBox.SelectionStart = posisiKursor
            Return
        End If

        ' Mengganti koma dengan titik untuk parsing desimal
        Dim angkaBersih As String = angkaHanyaDigit.Replace(".", ".")

        ' Mengubah string ke angka decimal
        Dim angkaDecimal As Decimal
        If Decimal.TryParse(angkaBersih, NumberStyles.Number, CultureInfo.InvariantCulture, angkaDecimal) Then
            textBox.Text = String.Format("{0:N0}", angkaDecimal).Replace(".", ".")
        Else
            textBox.Text = ""
        End If

        ' Kembalikan posisi kursor ke posisi yang disimpan
        textBox.SelectionStart = Math.Min(posisiKursor, textBox.Text.Length)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        HitungTotal()


        Dim idSudahAda As Boolean = False
        For Each item As ListViewItem In ListView1.Items
            If item.Text = idB.Text Then
                idSudahAda = True
                Exit For
            End If
        Next
        If Not idSudahAda Then
            Dim newItem As New ListViewItem(idB.Text)
            newItem.SubItems.Add(nmb.Text)
            newItem.SubItems.Add(jumblah.Text)
            newItem.SubItems.Add(harga.Text)
            newItem.SubItems.Add(total1.Text)
            newItem.SubItems.Add(diskon.Text)
            ListView1.Items.Add(newItem)
            idB.Clear()
            nmb.Clear()
            jumblah.Clear()
            harga.Clear()
            total1.Clear()
            diskon.Clear()
        Else
            MessageBox.Show("ID Barang sudah ada di daftar!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Call HitungTotal()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        idB.Clear()
        nmb.Clear()
        jumblah.Clear()
        harga.Clear()
        total1.Clear()
    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        ' Memeriksa apakah ada item yang dipilih dan apakah klik terjadi di dalam area item
        Dim hitTest As ListViewHitTestInfo = ListView1.HitTest(e.Location)
        If hitTest.Item IsNot Nothing Then
            ' Mendapatkan item yang diklik dua kali
            Dim selectedItem As ListViewItem = hitTest.Item

            ' Mengisi TextBox dengan data dari item yang dipilih
            idB.Text = selectedItem.Text
            nmb.Text = selectedItem.SubItems(1).Text
            jumblah.Text = selectedItem.SubItems(2).Text
            harga.Text = selectedItem.SubItems(3).Text
            total1.Text = selectedItem.SubItems(4).Text
            diskon.Text = selectedItem.SubItems(5).Text
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If ListView1.SelectedItems.Count > 0 Then
            ' Menghapus item yang dipilih dari ListView
            ListView1.Items.Remove(ListView1.SelectedItems(0))
        Else
            MessageBox.Show("Silakan pilih item yang akan dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ' Memeriksa apakah ada item yang dipilih
        If ListView1.SelectedItems.Count > 0 Then
            ' Mendapatkan item yang dipilih
            Dim selectedItem As ListViewItem = ListView1.SelectedItems(0)


            selectedItem.Text = idB.Text
            selectedItem.SubItems(1).Text = nmb.Text
            selectedItem.SubItems(2).Text = jumblah.Text
            selectedItem.SubItems(3).Text = harga.Text
            selectedItem.SubItems(4).Text = total1.Text
            selectedItem.SubItems(5).Text = diskon.Text


        Else
            MessageBox.Show("Silakan pilih item yang akan diperbarui.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        idB.Clear()
        nmb.Clear()
        jumblah.Clear()
        harga.Clear()
        total1.Clear()
        diskon.Clear()
    End Sub

    Private Sub diskon_TextChanged(sender As Object, e As EventArgs) Handles diskon.TextChanged

        Dim hargaValue As Decimal
        Dim jumblahValue As Integer
        Dim diskonValue As Decimal

        ' Validasi input harga, jumblah, dan diskon
        If Decimal.TryParse(harga.Text, hargaValue) AndAlso
       Integer.TryParse(jumblah.Text, jumblahValue) AndAlso
       Decimal.TryParse(diskon.Text, diskonValue) Then

            ' Menghitung total dengan diskon
            Dim hargaTotal As Decimal = hargaValue * jumblahValue
            Dim jumlahDiskon As Decimal = hargaTotal * (diskonValue / 100)
            Dim totalPembayaran As Decimal = hargaTotal - jumlahDiskon

            ' Menampilkan hasil tanpa format mata uang
            total1.Text = totalPembayaran.ToString("N0") ' N0 untuk format angka tanpa desimal
        Else
            ' Jika input tidak valid, kosongkan total1
            total1.Text = ""
        End If

    End Sub
    Private Sub harga_TextChanged(sender As Object, e As EventArgs) Handles harga.TextChanged
        If harga.Text = "" Then

        ElseIf jumblah.Text = "" Then
            jumblah.BackColor = Color.Red


        Else
            jumblah.BackColor = Color.White

            total1.Text = jumblah.Text * harga.Text
        End If

        FormatUang(harga)
        FormatUang(total1)

    End Sub

    Private Sub uang_TextChanged(sender As Object, e As EventArgs) Handles uang.TextChanged
        If uang.Text = "" Then
        Else
            total2.Text = uang.Text - bayar.Text
        End If
        FormatUang(uang)
        FormatUang(total2)
    End Sub

    ''==============================================================================================================================================
    ''==============================================================================================================================================
    ''==============================================================================================================================================


    Private Sub jumblah_KeyPress(sender As Object, e As KeyPressEventArgs) Handles jumblah.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ChrW(Keys.Back)) Then
            e.Handled = True ' Jika bukan angka atau Backspace, abaikan input
        End If
    End Sub
    Private Sub harga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles harga.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ChrW(Keys.Back)) Then
            e.Handled = True ' Jika bukan angka atau Backspace, abaikan input
        End If

    End Sub
    Private Sub total1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles total1.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ChrW(Keys.Back)) Then
            e.Handled = True ' Jika bukan angka atau Backspace, abaikan input
        End If
    End Sub
    Private Sub uang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles uang.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ChrW(Keys.Back)) Then
            e.Handled = True ' Jika bukan angka atau Backspace, abaikan input
        End If
    End Sub
    Private Sub bayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles bayar.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ChrW(Keys.Back)) Then
            e.Handled = True ' Jika bukan angka atau Backspace, abaikan input
        End If
    End Sub
    Private Sub total2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles total2.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ChrW(Keys.Back)) Then
            e.Handled = True ' Jika bukan angka atau Backspace, abaikan input
        End If
    End Sub

End Class