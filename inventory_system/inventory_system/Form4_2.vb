Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Public Class Form4_2
    Private mysqlConnection As New Mysqlconnection1()
    Private Sub Form4_2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form4_1.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        Form4_3.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim conn As New Mysqlconnection1()
        Dim com As New MySqlCommand("DELETE FROM `stock` WHERE `name` = @name ", conn.getConnection)
        com.Parameters.Add("@name", MySqlDbType.VarChar).Value = ComboBox1.Text
        conn.Openconnection()

        If com.ExecuteNonQuery() = 1 Then
            MsgBox("刪除成功")
            conn.Closeconnection()
        End If
    End Sub
End Class