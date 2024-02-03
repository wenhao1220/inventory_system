Imports MySql.Data.MySqlClient
Public Class Form3_2
    Private mysqlConnection As New Mysqlconnection1()
    Private Sub Form3_2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("1")
        ComboBox1.Items.Add("2")
        ComboBox1.Items.Add("3")
        ComboBox1.SelectedItem = "1"

        ComboBox2.Items.Add("1")
        ComboBox2.Items.Add("2")
        ComboBox2.Items.Add("3")
        ComboBox2.Items.Add("4")
        ComboBox2.Items.Add("5")
        ComboBox2.Items.Add("6")
        ComboBox2.Items.Add("7")
        ComboBox2.SelectedItem = "1"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        Form5.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Form3.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form3_1.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim conn As New Mysqlconnection1()
        Dim command As New MySqlCommand("DELETE FROM `order_food` where `id` = @id And `table_number` = @table_number", conn.getConnection)
        command.Parameters.Add("@id", MySqlDbType.Int64).Value = ComboBox1.Text
        command.Parameters.Add("@table_number", MySqlDbType.Int64).Value = ComboBox2.Text
        conn.Openconnection()

        If command.ExecuteNonQuery() = 1 Then
            MsgBox("刪除成功")
            conn.Closeconnection()
        End If
    End Sub
End Class