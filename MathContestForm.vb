Option Strict On
Option Explicit On
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class MathContestForm

    Dim firstNumber As Integer
    Dim secondNumber As Integer
    Dim correctAnswer As Double
    'TODO
    '[x]Set default values
    '[X]Set a program to use random numbers from 1 to 1000 to make an add, substract, multiplication or divide problems
    '[X]Create a validation process for all fields available
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
    Function ValidateName() As Boolean
        'TODO
        '[X]Name cannot be blank
        '[x]Lock name cage if not valid

        If NameTextBox.Text = "" Then
            NameTextBox.BackColor = Color.LightYellow
            SubmitButton.Enabled = False
            Return False
        Else
            NameTextBox.BackColor = Color.White
            SubmitButton.Enabled = True
            Return True
        End If

    End Function

    Function ValidateAge() As Boolean

        '[X]Age cannot be blank
        '[X]Age must be a positive whole number
        '[X]Age must be between 7 and 11
        '[x]Block submit button if age is not in range
        Dim age As UShort

        Try
            age = CUShort(AgeTextBox.Text)

            Select Case age
                Case <= 6
                    AgeTextBox.BackColor = Color.LightYellow
                    SubmitButton.Enabled = False
                    Return False
                Case 7 To 11
                    AgeTextBox.BackColor = Color.White
                    SubmitButton.Enabled = True
                    Return True
                Case >= 11
                    AgeTextBox.BackColor = Color.LightYellow
                    SubmitButton.Enabled = False
                    Return False
            End Select
        Catch ex As Exception
            AgeTextBox.BackColor = Color.LightYellow
            SubmitButton.Enabled = False
            Return False
        End Try

    End Function
    Function ValidateGrade() As Boolean
        '[X]Grade cannot be blank
        '[X]Grade must be a positive whole number
        '[X]Grade must be between 1 and 4
        '[x]Block submit button if grade is not valid
        Dim grade As UShort
        Try
            grade = CUShort(GradeTextBox.Text)

            Select Case grade
                Case 0
                    GradeTextBox.BackColor = Color.LightYellow
                    SubmitButton.Enabled = False
                    GradeTextBox.Focus()
                    Return False
                Case 1 To 4
                    GradeTextBox.BackColor = Color.White
                    SubmitButton.Enabled = True
                    Return True
                Case >= 4
                    GradeTextBox.BackColor = Color.LightYellow
                    SubmitButton.Enabled = False
                    Return False
            End Select
        Catch ex As Exception
            GradeTextBox.BackColor = Color.LightYellow
            SubmitButton.Enabled = False
            Return False
        End Try
    End Function

    Sub Add()
        Randomize()

        firstNumber = CInt(Rnd() * 99) + 1
        secondNumber = CInt(Rnd() * 99) + 1
        correctAnswer = CInt(firstNumber + secondNumber)

        FirstNumberTextBox.Text = CStr(firstNumber)
        SecondNumberTextBox.Text = CStr(secondNumber)
        'AnswerTextBox.Text = CStr(correctAnswer)

    End Sub
    Sub Subtract()
        Randomize()

        firstNumber = CInt(Rnd() * 99) + 1
        secondNumber = CInt(Rnd() * 99) + 1
        correctAnswer = CInt(firstNumber - secondNumber)

        FirstNumberTextBox.Text = CStr(firstNumber)
        SecondNumberTextBox.Text = CStr(secondNumber)
        'AnswerTextBox.Text = CStr(correctAnswer)
    End Sub
    Sub Multiplication()
        Randomize()

        firstNumber = CInt(Rnd() * 99) + 1
        secondNumber = CInt(Rnd() * 99) + 1
        correctAnswer = CInt(firstNumber * secondNumber)

        FirstNumberTextBox.Text = CStr(firstNumber)
        SecondNumberTextBox.Text = CStr(secondNumber)
        'AnswerTextBox.Text = CStr(correctAnswer)
    End Sub
    Sub Divition()
        Randomize()

        firstNumber = CInt(Rnd() * 99) + 1
        secondNumber = CInt(Rnd() * 99) + 1
        correctAnswer = Math.Round((CDbl(firstNumber / secondNumber)), 2, MidpointRounding.AwayFromZero)

        FirstNumberTextBox.Text = CStr(firstNumber)
        SecondNumberTextBox.Text = CStr(secondNumber)
        'AnswerTextBox.Text = CStr(correctAnswer)
    End Sub
    Sub MathProblem()


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
        NameTextBox.Enabled = True
        AgeTextBox.Enabled = True
        GradeTextBox.Enabled = True
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        '[x]Block name, age and grade once is submitted
        NameTextBox.Enabled = False
        AgeTextBox.Enabled = False
        GradeTextBox.Enabled = False
    End Sub

    Private Sub TextBox_Leave(sender As Object, e As EventArgs) Handles NameTextBox.Leave, AgeTextBox.Leave, GradeTextBox.Leave

        If ValidateName() = False Then
            NameTextBox.Focus()

        ElseIf ValidateAge() = False Then
            AgeTextBox.Focus()

        ElseIf ValidateGrade() = False Then
            GradeTextBox.Focus()
        End If
    End Sub

End Class