Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Public Class Form2
    Private mysqlConnection As New Mysqlconnection1()
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim command As New MySqlCommand("SELECT distinct `name` from `stock`", conn.getConnection)

        Try
            conn.Openconnection()
            Dim dr As MySqlDataReader = command.ExecuteReader()

            While dr.Read()
                ComboBox2.Items.Add(dr("name").ToString())
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form2_1.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form2_2.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim conn As New Mysqlconnection1()
        Dim command As New MySqlCommand("INSERT INTO `menu` (`menu_name`, `price`, `kind`, `stock_name`, `stock_number`) VALUES (@menu_name, @price, @kind, @stock_name, @stock_number)", conn.getConnection)
        command.Parameters.Add("@menu_name", MySqlDbType.VarChar).Value = TextBox1.Text
        command.Parameters.Add("@price", MySqlDbType.Int64).Value = TextBox2.Text
        command.Parameters.Add("@kind", MySqlDbType.VarChar).Value = ComboBox1.Text
        command.Parameters.Add("@stock_name", MySqlDbType.VarChar).Value = ComboBox2.Text
        command.Parameters.Add("@stock_number", MySqlDbType.Int64).Value = TextBox6.Text
        conn.Openconnection()

        If command.ExecuteNonQuery() = 1 Then
            MsgBox("加入成功")
            conn.Closeconnection()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class