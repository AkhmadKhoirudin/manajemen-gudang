Module Module1

    Private Declare Function GetWindow Lib "user32.dll" (ByVal hwnd As Integer, ByVal wCmd As Integer) As Integer
    Private Declare Auto Function SendMessageString Lib "user32.dll" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As String) As Integer

    Const GW_CHILD = 5
    Const EM_SETCUEBANNER = &H1501

    Sub SetWatermark(ByVal Ctl As TextBox, ByVal Txt As String, ByVal WatermarkColor As Color)
        ' Mendefinisikan sebuah font dengan warna tanda air yang diinginkan
        Dim watermarkFont As New Font(Ctl.Font, FontStyle.Italic)
        Dim watermarkBrush As New SolidBrush(WatermarkColor)

        ' Menggambar teks tanda air
        Using g As Graphics = Ctl.CreateGraphics()
            g.DrawString(Txt, watermarkFont, watermarkBrush, 1, 1)
        End Using

        SendMessageString(Ctl.Handle, EM_SETCUEBANNER, 1, Txt)
    End Sub

    Sub SetWatermark(ByVal Ctl As ComboBox, ByVal Txt As String, ByVal WatermarkColor As Color)
        ' Mendefinisikan sebuah font dengan warna tanda air yang diinginkan
        Dim watermarkFont As New Font(Ctl.Font, FontStyle.Italic)
        Dim watermarkBrush As New SolidBrush(WatermarkColor)

        ' Mendapatkan handle dari dropdown combo box (kotak pilihan)
        Dim i As Integer = GetWindow(Ctl.Handle, GW_CHILD)

        ' Menggambar teks tanda air
        Using g As Graphics = Ctl.CreateGraphics()
            g.DrawString(Txt, watermarkFont, watermarkBrush, 1, 1)
        End Using

        SendMessageString(i, EM_SETCUEBANNER, 1, Txt)
    End Sub
    Sub bukapanel(ByVal panel As Form)
        home.panelhome.Controls.Clear()
        panel.TopLevel = False
        panel.FormBorderStyle = FormBorderStyle.None
        panel.Dock = DockStyle.Fill
        home.panelhome.Controls.Add(panel)
        panel.Show()
        home.menututup()
    End Sub
    Sub tutup()
        home.menututup()
    End Sub

End Module
