Imports System.Data.SQLite

Public Class Form1

    Dim con As New SQLiteConnection("Data Source=quiz.db;Version=3;")

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con.Open()

        Dim cmd As New SQLiteCommand("CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY AUTOINCREMENT, Username TEXT, Password TEXT)", con)

        cmd.ExecuteNonQuery()

        con.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text = "Admin" Then

            If TextBox1.Text = "admin" And TextBox2.Text = "admin123" Then

                MessageBox.Show("Admin Login Successful")
                Form4.Show()
                Me.Hide()

            Else

                MessageBox.Show("Invalid Admin Login")

            End If

        ElseIf ComboBox1.Text = "User" Then

            con.Open()

            Dim cmd As New SQLiteCommand("SELECT * FROM Users WHERE Username=@u AND Password=@p", con)

            cmd.Parameters.AddWithValue("@u", TextBox1.Text)
            cmd.Parameters.AddWithValue("@p", TextBox2.Text)

            Dim reader As SQLiteDataReader
            reader = cmd.ExecuteReader()

            If reader.HasRows Then

                MessageBox.Show("User Login Successful")
                Form2.Show()
                Me.Hide()

            Else

                MessageBox.Show("Invalid Username or Password")

            End If

            con.Close()

        Else

            MessageBox.Show("Please select role")

        End If

    End Sub

End Class