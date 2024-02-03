Imports MySql.Data.MySqlClient
Public Class Form3_1
    Private mysqlConnection As New Mysqlconnection1()
    Private Sub Form3_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form3_2.Show()
    End Sub
End Class