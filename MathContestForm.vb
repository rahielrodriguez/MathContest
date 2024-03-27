Option Strict On
Option Explicit On
Public Class MathContestForm

    'TODO
    '[x]Set default values
    '[X]Set a program to use random numbers from 1 to 1000 to make an add, substract, multiplication or divide problems
    '[ ]Create a validation process for all fields available
    '[ ]Block the submit button if all the fields are not field correctly, and unlockit if all fields are filled right
    '[ ]Make a program to shows a summary of all the math contest results up to the point when the button is pressed
    '[ ]Block the summary button if there are not answers available, and unlockit if atleast one answer has been submitedd

    Sub SetDefaults()

        NameTextBox.Text = ""
        AgeTextBox.Text = ""
        GradeTextBox.Text = ""
        FirstNumberTextBox.Text = ""
        SecondNumberTextBox.Text = ""
        AnswerLabel.Text = ""
        SubmitButton.Enabled = False
        SummaryButton.Enabled = False

        AddRadioButton.Focus()

    End Sub
    Sub Add()
        Dim firstNumber As Integer
        Dim secondNumber As Integer
        Dim correctAnswer As Integer
        Randomize()

        firstNumber = CInt(Rnd() * 999) + 1
        secondNumber = CInt(Rnd() * 999) + 1
        correctAnswer = CInt(firstNumber + secondNumber)

        FirstNumberTextBox.Text = CStr(firstNumber)
        SecondNumberTextBox.Text = CStr(secondNumber)
        'AnswerTextBox.Text = CStr(correctAnswer)
    End Sub
    Sub Subtract()
        Dim firstNumber As Integer
        Dim secondNumber As Integer
        Dim correctAnswer As Integer
        Randomize()

        firstNumber = CInt(Rnd() * 999) + 1
        secondNumber = CInt(Rnd() * 999) + 1
        correctAnswer = CInt(firstNumber - secondNumber)

        FirstNumberTextBox.Text = CStr(firstNumber)
        SecondNumberTextBox.Text = CStr(secondNumber)
        'AnswerTextBox.Text = CStr(correctAnswer)
    End Sub
    Sub Multiplication()
        Dim firstNumber As Integer
        Dim secondNumber As Integer
        Dim correctAnswer As Integer
        Randomize()

        firstNumber = CInt(Rnd() * 999) + 1
        secondNumber = CInt(Rnd() * 999) + 1
        correctAnswer = CInt(firstNumber * secondNumber)

        FirstNumberTextBox.Text = CStr(firstNumber)
        SecondNumberTextBox.Text = CStr(secondNumber)
        'AnswerTextBox.Text = CStr(correctAnswer)
    End Sub
    Sub Divition()
        Dim firstNumber As Integer
        Dim secondNumber As Integer
        Dim correctAnswer As Double
        Randomize()

        firstNumber = CInt(Rnd() * 999) + 1
        secondNumber = CInt(Rnd() * 999) + 1
        correctAnswer = Math.Round((CDbl(firstNumber / secondNumber)), 2, MidpointRounding.AwayFromZero)

        FirstNumberTextBox.Text = CStr(firstNumber)
        SecondNumberTextBox.Text = CStr(secondNumber)
        'AnswerTextBox.Text = CStr(correctAnswer)
    End Sub
    Sub MathProblemSelection()

    End Sub

    Private Sub AddRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles AddRadioButton.CheckedChanged
        Add()
    End Sub

    Private Sub SubtractRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles SubtractRadioButton.CheckedChanged
        Subtract()
    End Sub

    Private Sub MultiplyRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles MultiplyRadioButton.CheckedChanged
        Multiplication()
    End Sub

    Private Sub DivideRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles DivideRadioButton.CheckedChanged
        Divition()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        SetDefaults()
        AddRadioButton.Focus()
        FirstNumberTextBox.Text = ""
        SecondNumberTextBox.Text = ""
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub
End Class
