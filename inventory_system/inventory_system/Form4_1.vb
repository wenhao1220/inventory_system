Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Public Class Form4_1
    Private mysqlConnection As New Mysqlconnection1()
    Private Sub Form4_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conn As New Mysqlconnection1()
        Dim command As New MySqlCommand("SELECT distinct `name` from `stock` ", conn.getConnection)

        Try
            conn.Openconnection()
            Dim dr As MySqlDataReader = command.ExecuteReader()

            While dr.Read()
                ComboBox1.Items.Add(dr("name").ToString())
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
        Form4.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form4_2.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        Form4_3.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim conn As New Mysqlconnection1()
        Dim command1 As New MySqlCommand("UPDATE `stock` SET `number`= @number where `name` = @name", conn.getConnection)
        command1.Parameters.Add("@name", MySqlDbType.VarChar).Value = ComboBox1.Text
        command1.Parameters.Add("@number", MySqlDbType.Int64).Value = TextBox1.Text
        conn.Openconnection()

        If command1.ExecuteNonQuery() = 1 Then
            MsgBox("修改成功")
            conn.Closeconnection()
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        '食材目前的數量
        Dim conn As New Mysqlconnection1()
        Dim com As New MySqlCommand("SELECT `number` from `stock` where `name`= @name", conn.getConnection)
        com.Parameters.Add("@name", MySqlDbType.VarChar).Value = ComboBox1.Text
        Try
            conn.Openconnection()
            Dim drr As MySqlDataReader = com.ExecuteReader()

            If drr.Read() Then
                Dim number As String = drr("number").ToString()
                Label3.Text = number
            End If

            drr.Close()
        Catch ex As Exception
            ' 處理連線或查詢錯誤
        Finally
            conn.Closeconnection()
        End Try
    End Sub
End Class