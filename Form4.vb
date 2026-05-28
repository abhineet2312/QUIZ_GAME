Imports System.Data.SQLite
Imports Windows.Win32.System

Public Class Form4

    Dim con As New SQLiteConnection("Data Source=quiz.db;Version=3;")

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con.Open()

        Dim sql As String = "CREATE TABLE IF NOT EXISTS Questions " &
                            "(Id INTEGER PRIMARY KEY AUTOINCREMENT, " &
                            "Question TEXT, " &
                            "OptionA TEXT, " &
                            "OptionB TEXT, " &
                            "OptionC TEXT, " &
                            "OptionD TEXT, " &
                            "CorrectAnswer TEXT)"

        Dim cmd As New SQLiteCommand(sql, con)

        cmd.ExecuteNonQuery()

        con.Close()

        DataGridView1.ColumnCount = 6
        DataGridView1.Columns(0).Name = "Question"
        DataGridView1.Columns(1).Name = "Option A"
        DataGridView1.Columns(2).Name = "Option B"
        DataGridView1.Columns(3).Name = "Option C"
        DataGridView1.Columns(4).Name = "Option D"
        DataGridView1.Columns(5).Name = "Correct Answer"

        con.Open()

        Dim cmd2 As New SQLiteCommand("SELECT * FROM Questions", con)

        Dim reader As SQLiteDataReader = cmd2.ExecuteReader()

        While reader.Read()

            DataGridView1.Rows.Add(reader("Question").ToString(), reader("OptionA").ToString(), reader("OptionB").ToString(), reader("OptionC").ToString(), reader("OptionD").ToString(), reader("CorrectAnswer").ToString())

        End While

        con.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or
           TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Then

            MessageBox.Show("Please fill all fields")
            Exit Sub

        End If

        con.Open()

        Dim cmd As New SQLiteCommand("INSERT INTO Questions (Question, OptionA, OptionB, OptionC, OptionD, CorrectAnswer) VALUES (@q,@a,@b,@c,@d,@ans)", con)

        cmd.Parameters.AddWithValue("@q", TextBox1.Text)
        cmd.Parameters.AddWithValue("@a", TextBox2.Text)
        cmd.Parameters.AddWithValue("@b", TextBox3.Text)
        cmd.Parameters.AddWithValue("@c", TextBox4.Text)
        cmd.Parameters.AddWithValue("@d", TextBox5.Text)
        cmd.Parameters.AddWithValue("@ans", TextBox6.Text)

        cmd.ExecuteNonQuery()

        con.Close()

        DataGridView1.Rows.Add(TextBox1.Text, TextBox2.Text, TextBox3.Text,
                               TextBox4.Text, TextBox5.Text, TextBox6.Text)

        MessageBox.Show("Question Added Successfully")

        ClearFields()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If DataGridView1.CurrentRow IsNot Nothing Then

            DataGridView1.CurrentRow.Cells(0).Value = TextBox1.Text
            DataGridView1.CurrentRow.Cells(1).Value = TextBox2.Text
            DataGridView1.CurrentRow.Cells(2).Value = TextBox3.Text
            DataGridView1.CurrentRow.Cells(3).Value = TextBox4.Text
            DataGridView1.CurrentRow.Cells(4).Value = TextBox5.Text
            DataGridView1.CurrentRow.Cells(5).Value = TextBox6.Text

            MessageBox.Show("Question Updated")

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If DataGridView1.CurrentRow IsNot Nothing Then

            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)

            MessageBox.Show("Question Deleted")

        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ClearFields()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Form1.Show()
        Me.Hide()

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            TextBox1.Text = row.Cells(0).Value.ToString()
            TextBox2.Text = row.Cells(1).Value.ToString()
            TextBox3.Text = row.Cells(2).Value.ToString()
            TextBox4.Text = row.Cells(3).Value.ToString()
            TextBox5.Text = row.Cells(4).Value.ToString()
            TextBox6.Text = row.Cells(5).Value.ToString()

        End If

    End Sub

    Private Sub ClearFields()

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()

    End Sub

End Class