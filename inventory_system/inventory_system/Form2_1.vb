Imports MySql.Data.MySqlClient
Public Class Form2_1
    Private mysqlConnection As New Mysqlconnection1()
    Private Sub Form2_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("hamberger")
        ComboBox1.Items.Add("toast")
        ComboBox1.Items.Add("thick toast")              '厚片
        ComboBox1.Items.Add("club sandwich")            '總匯
        ComboBox1.Items.Add("noodle")
        ComboBox1.Items.Add("Chinese omelet")           '蛋餅
        ComboBox1.Items.Add("flaky scallion pancake")  ' 蔥油餅
        ComboBox1.Items.Add("french fries")
        ComboBox1.Items.Add("drink")
        'ComboBox1.SelectedItem = "choose kind"

        Dim conn As New Mysqlconnection1()
        Dim command As New MySqlCommand("SELECT distinct `name` from `stock` ", conn.getConnection)

        Try
            conn.Openconnection()
            Dim dr As MySqlDataReader = command.ExecuteReader()

            While dr.Read()
                ComboBox3.Items.Add(dr("name").ToString())
            End While

            dr.Close()
        Catch ex As Exception
            ' 處理連線或查詢錯誤
        Finally
            conn.Closeconnection()
        End Try

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        Form5.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Form2.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form2_2.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim conn As New Mysqlconnection1()
        Dim command As New MySqlCommand("UPDATE `menu` SET `stock_number`= @stock_number, `price`= @price where `menu_name` = @menu_name and `kind` = @kind and `stock_name`= @stock_name ", conn.getConnection)
        command.Parameters.Add("@stock_number", MySqlDbType.Int64).Value = TextBox1.Text
        command.Parameters.Add("@price", MySqlDbType.Int64).Value = TextBox2.Text
        command.Parameters.Add("@menu_name", MySqlDbType.Int64).Value = ComboBox2.Text
        command.Parameters.Add("@kind", MySqlDbType.Int64).Value = ComboBox1.Text
        command.Parameters.Add("@stock_name", MySqlDbType.Int64).Value = ComboBox3.Text
        conn.Openconnection()

        If command.ExecuteNonQuery() = 1 Then
            MsgBox("修改成功")
            conn.Closeconnection()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox2.Items.Clear()

        Dim con As New Mysqlconnection1()
        Dim com As New MySqlCommand("SELECT distinct `menu_name` from `menu` where `kind` = @kind ", con.getConnection)

        Try
            con.Openconnection()
            com.Parameters.Add("@kind", MySqlDbType.VarChar).Value = ComboBox1.Text
            Dim dr1 As MySqlDataReader = com.ExecuteReader()

            While dr1.Read()
                ComboBox2.Items.Add(dr1("menu_name").ToString())
            End While

            dr1.Close()
        Catch ex As Exception
            ' 處理連線或查詢錯誤
        Finally
            con.Closeconnection()
        End Try

    End Sub
End Class