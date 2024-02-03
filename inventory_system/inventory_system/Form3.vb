Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Public Class Form3
    Private mysqlConnection As New Mysqlconnection1()
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        ComboBox3.Items.Add("hamberger")
        ComboBox3.Items.Add("toast")
        ComboBox3.Items.Add("thick toast")              '厚片
        ComboBox3.Items.Add("club sandwich")            '總匯
        ComboBox3.Items.Add("noodle")
        ComboBox3.Items.Add("Chinese omelet")           '蛋餅
        ComboBox3.Items.Add("flaky scallion pancake")  ' 蔥油餅
        ComboBox3.Items.Add("french fries")
        ComboBox3.Items.Add("drink")
        ComboBox3.SelectedItem = "hamberger"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        Form5.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form3_1.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form3_2.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim conn As New Mysqlconnection1()
        Dim command As New MySqlCommand("INSERT INTO `order_food` (`id`, `table_number`, `type`, `name`, `number`) VALUES (@id, @table_number, @type, @name, @number)", conn.getConnection)
        command.Parameters.Add("@id", MySqlDbType.VarChar).Value = ComboBox1.Text
        command.Parameters.Add("@table_number", MySqlDbType.Int64).Value = ComboBox2.Text
        command.Parameters.Add("@type", MySqlDbType.VarChar).Value = ComboBox3.Text
        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = ComboBox4.Text
        command.Parameters.Add("@number", MySqlDbType.Int64).Value = TextBox3.Text
        conn.Openconnection()

        If command.ExecuteNonQuery() = 1 Then
            MsgBox("加入成功")
            conn.Closeconnection()
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        ComboBox4.Items.Clear()

        Dim con As New Mysqlconnection1()
        Dim com As New MySqlCommand("SELECT distinct `menu_name` from `menu` where `kind` = @kind ", con.getConnection)

        Try
            con.Openconnection()
            com.Parameters.Add("@kind", MySqlDbType.VarChar).Value = ComboBox3.Text
            Dim dr1 As MySqlDataReader = com.ExecuteReader()

            While dr1.Read()
                ComboBox4.Items.Add(dr1("menu_name").ToString())
            End While

            dr1.Close()
        Catch ex As Exception
            ' 處理連線或查詢錯誤
        Finally
            con.Closeconnection()
        End Try
    End Sub
End Class