Imports MySql.Data.MySqlClient

Public Class Form1
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conn.Open()

            Dim cmd = New MySqlCommand("INSERT INTO `record`(`進貨編號`, `貨品名稱`, `貨品種類`, `進貨日期`, `進貨數量`, `員工編號`) VALUES (@進貨編號, @貨品名稱, @貨品種類, @進貨日期, @進貨數量, @員工編號)", conn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@進貨編號", CDec(TextBox1.Text))
            cmd.Parameters.AddWithValue("@貨品名稱", TextBox2.Text)
            cmd.Parameters.AddWithValue("@貨品種類", TextBox3.Text)
            'cmd.Parameters.AddWithValue("@進貨日期", TextBox4.Text)
            'cmd.Parameters.AddWithValue("@進貨數量", TextBox5.Text)
            'cmd.Parameters.AddWithValue("@員工編號", TextBox6.Text)

            'cmd.Parameters.Add("@進貨編號", MySqlDbType.Int64).Value = TextBox1.Text
            'cmd.Parameters.Add("@貨品名稱", MySqlDbType.VarChar).Value = TextBox2.Text
            'cmd.Parameters.Add("@貨品種類", MySqlDbType.VarChar).Value = TextBox3.Text
            'cmd.Parameters.Add("@進貨日期", MySqlDbType.Date).Value = TextBox4.Text
            'cmd.Parameters.Add("@進貨數量", MySqlDbType.Int64).Value = TextBox5.Text
            'cmd.Parameters.Add("@員工編號", MySqlDbType.Int64).Value = TextBox6.Text

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
End Class
