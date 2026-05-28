Imports System.Data.SQLite

Public Class Form2

    Dim con As New SQLiteConnection("Data Source=quiz.db;Version=3;")

    Dim questions As New List(Of String)
    Dim optionA As New List(Of String)
    Dim optionB As New List(Of String)
    Dim optionC As New List(Of String)
    Dim optionD As New List(Of String)
    Dim answers As New List(Of String)

    Dim currentQuestion As Integer = 0
    Public Shared score As Integer = 0

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con.Open()

        Dim cmd As New SQLiteCommand("SELECT * FROM Questions", con)

        Dim reader As SQLiteDataReader = cmd.ExecuteReader()

        While reader.Read()

            questions.Add(reader("Question").ToString())
            optionA.Add(reader("OptionA").ToString())
            optionB.Add(reader("OptionB").ToString())
            optionC.Add(reader("OptionC").ToString())
            optionD.Add(reader("OptionD").ToString())
            answers.Add(reader("CorrectAnswer").ToString())

        End While

        con.Close()

        If questions.Count > 0 Then
            ShowQuestion()
        Else
            MessageBox.Show("No Questions Found")
        End If

    End Sub

    Private Sub ShowQuestion()

        Label2.Text = "Question " & (currentQuestion + 1)
        Label3.Text = questions(currentQuestion)

        RadioButton1.Text = optionA(currentQuestion)
        RadioButton2.Text = optionB(currentQuestion)
        RadioButton3.Text = optionC(currentQuestion)
        RadioButton4.Text = optionD(currentQuestion)

        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim selectedAnswer As String = ""

        If RadioButton1.Checked Then selectedAnswer = RadioButton1.Text
        If RadioButton2.Checked Then selectedAnswer = RadioButton2.Text
        If RadioButton3.Checked Then selectedAnswer = RadioButton3.Text
        If RadioButton4.Checked Then selectedAnswer = RadioButton4.Text

        If selectedAnswer = answers(currentQuestion) Then
            score += 1
        End If

        currentQuestion += 1

        If currentQuestion < questions.Count Then

            ShowQuestion()

        Else

            MessageBox.Show("Quiz Finished! Your Score: " & score)

            Form3.Show()
            Me.Hide()

        End If

    End Sub

End Class