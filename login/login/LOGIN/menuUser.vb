Public Class menuUser
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        bukapanel(register)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        bukapanel(biodata)
        home.tampil()
        biodata.btmenuuser.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        bukapanel(listuser)


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        bukapanel(absen)
    End Sub
End Class