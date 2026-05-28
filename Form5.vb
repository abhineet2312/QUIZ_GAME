Imports System.Data.SQLite

Public Class Form5

    Dim con As New SQLiteConnection("Data Source=quiz.db;Version=3;")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        con.Open()

        Dim cmd As New SQLiteCommand("INSERT INTO Users (Username, Password) VALUES (@u,@p)", con)

        cmd.Parameters.AddWithValue("@u", TextBox1.Text)
        cmd.Parameters.AddWithValue("@p", TextBox2.Text)

        cmd.ExecuteNonQuery()

        con.Close()

        MessageBox.Show("Registration Successful")

        Form1.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Hide()
    End Sub

End Class