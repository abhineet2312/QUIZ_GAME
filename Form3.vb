Imports System.Data.SQLite

Public Class Form3

    Dim con As New SQLiteConnection("Data Source=quiz.db;Version=3;")

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Show score out of 10
        Label2.Text = "Your Score: " & Form2.score & " / 10"

        ' Optional message based on score
        Dim result As String

        If Form2.score >= 8 Then
            result = "Excellent 🎉"
        ElseIf Form2.score >= 5 Then
            result = "Good 👍"
        Else
            result = "Try Again 🙂"
        End If

        Label3.Text = result

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ' Back to login
        Form1.Show()
        Me.Hide()

        ' Reset quiz for next user
        Form2.score = 0

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

End Class