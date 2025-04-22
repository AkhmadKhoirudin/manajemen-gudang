Public Class menuUtama
    Private Sub menuUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tutup()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        bukapanel(menuUser)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        bukapanel(DATA)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        bukapanel(input)
    End Sub
End Class