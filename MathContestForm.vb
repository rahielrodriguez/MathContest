'Rahiel Rodriguez
'RCET 0256
'Spring 2024
'Math Contest
'https://github.com/rahielrodriguez/MathContest.git

Option Strict On
Option Explicit On
Public Class MathContestForm

    Dim firstNumber As Integer
    Dim secondNumber As Integer
    Dim correctAnswer As Double
    Dim currentAnswer As Double
    Dim message As String
    Dim record As String
    Dim correctAnswerCounter As Integer
    Dim problemNumberCounter As Integer
    'TODO
    '[x]Set default values
    '[X]Set a program to use random numbers from 1 to 1000 to make an add, substract, multiplication or divide problems
    '[X]Create a validation process for all fields available
    '[x]Block the submit button if all the fields are not field correctly, and unlockit if all fields are filled right
    '[x]Make a program to shows a summary of all the math contest results up to the point when the button is pressed
    '[x]Block the summary button if there are not answers available, and unlockit if atleast one answer has been submitedd

    Sub SetDefaults()

        NameTextBox.Text = ""
        AgeTextBox.Text = ""
        GradeTextBox.Text = ""
        FirstNumberTextBox.Text = ""
        SecondNumberTextBox.Text = ""
        AnswerTextBox.Text = ""
        AddRadioButton.Checked = False
        SubtractRadioButton.Checked = False
        MultiplyRadioButton.Checked = False
        DivideRadioButton.Checked = False
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
        'Validates that the age field is not empty and is a whole number
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
        'vaidates that the grade field is not empty and is a whole number
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
        'stablishes first number as a random number from 1 to 100
        'stablishes first number as a random number from 1 to 100
        'adds those random numbers to generate a correct answer
        firstNumber = CInt(Rnd() * 99) + 1
        secondNumber = CInt(Rnd() * 99) + 1
        correctAnswer = CInt(firstNumber + secondNumber)

        FirstNumberTextBox.Text = CStr(firstNumber)
        SecondNumberTextBox.Text = CStr(secondNumber)
        'AnswerTextBox.Text = CStr(correctAnswer)

    End Sub
    Sub Subtract()
        Randomize()
        'stablishes first number as a random number from 1 to 100
        'stablishes first number as a random number from 1 to 100
        'substracts those random numbers to generate a correct answer
        firstNumber = CInt(Rnd() * 99) + 1
        secondNumber = CInt(Rnd() * 99) + 1
        correctAnswer = CInt(firstNumber - secondNumber)

        FirstNumberTextBox.Text = CStr(firstNumber)
        SecondNumberTextBox.Text = CStr(secondNumber)
        'AnswerTextBox.Text = CStr(correctAnswer)
    End Sub
    Sub Multiplication()
        Randomize()
        'stablishes first number as a random number from 1 to 100
        'stablishes first number as a random number from 1 to 100
        'multiplies those random numbers to generate a correct answer
        firstNumber = CInt(Rnd() * 99) + 1
        secondNumber = CInt(Rnd() * 99) + 1
        correctAnswer = CInt(firstNumber * secondNumber)

        FirstNumberTextBox.Text = CStr(firstNumber)
        SecondNumberTextBox.Text = CStr(secondNumber)
        'AnswerTextBox.Text = CStr(correctAnswer)
    End Sub
    Sub Divition()
        Randomize()
        'stablishes first number as a random number from 1 to 100
        'stablishes first number as a random number from 1 to 100
        'divides those random numbers to generate a correct answer
        firstNumber = CInt(Rnd() * 99) + 1
        secondNumber = CInt(Rnd() * 99) + 1
        correctAnswer = Math.Round((CDbl(firstNumber / secondNumber)), 2, MidpointRounding.AwayFromZero)

        FirstNumberTextBox.Text = CStr(firstNumber)
        SecondNumberTextBox.Text = CStr(secondNumber)
        'AnswerTextBox.Text = CStr(correctAnswer)
    End Sub
    Sub MathProblem()

        'TODO
        '[x]If answer is correct, display a congratulation message
        '[X]If answer is correct, record message in a list for summary
        '[X]If answer is incorrect, show a message with the correct answer
        '[x]If answer is incorrect, record message in a list for summary

        Try
            currentAnswer = CDbl(AnswerTextBox.Text)
            'if answer is correct, then creates a congratulation message, adds one to the correct answer counter and one to the problem counter
            If currentAnswer = correctAnswer Then
                correctAnswerCounter = correctAnswerCounter + 1
                problemNumberCounter += 1
                message &= $"Correct, the correct answer is {correctAnswer}{vbNewLine}{correctAnswerCounter} of {problemNumberCounter} questions are correct{vbNewLine}"
                MsgBox($"Correct, the correct answer is {correctAnswer}{vbNewLine}{correctAnswerCounter} of {problemNumberCounter} questions are correct")
            ElseIf currentAnswer <> correctAnswer Then
                'If answer is incorrect, generates a message with the correct answer and adds one to the problem counter.
                problemNumberCounter += 1
                message &= $"Incorrect, the correct answer is {correctAnswer}{vbNewLine}{correctAnswerCounter} of {problemNumberCounter} questions are correct{vbNewLine}"
                MsgBox($"Incorrect, the correct answer is {correctAnswer}{vbNewLine}{correctAnswerCounter} of {problemNumberCounter} questions are correct")
            End If

            ClearProblem()

            'If the problem counter is equal to 5, then the test will be restarted. If is not, the test will continue.
            If problemNumberCounter = 5 Then
                MsgBox($"{NameTextBox.Text} scored {correctAnswerCounter} out of {problemNumberCounter} problems.")
                problemNumberCounter = 0
                correctAnswerCounter = 0
                NameTextBox.Enabled = True
                AgeTextBox.Enabled = True
                GradeTextBox.Enabled = True
                SetDefaults()
                ValidateName()
                ValidateAge()
                ValidateGrade()
            Else
                AnswerTextBox.Text = ""

            End If

        Catch ex As Exception
            If AnswerTextBox.Text = "" Then
                AnswerTextBox.Text = ""
                AnswerTextBox.BackColor = Color.LightYellow
                MsgBox("Please enter an answer.")
            End If
        End Try

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

    Sub ClearProblem()
        AddRadioButton.Focus()
        AddRadioButton.Checked = False
        SubtractRadioButton.Checked = False
        MultiplyRadioButton.Checked = False
        DivideRadioButton.Checked = False
        FirstNumberTextBox.Text = ""
        SecondNumberTextBox.Text = ""
        AnswerTextBox.Text = ""

    End Sub
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        SetDefaults()
        AddRadioButton.Focus()
        FirstNumberTextBox.Text = ""
        SecondNumberTextBox.Text = ""
        NameTextBox.Enabled = True
        AgeTextBox.Enabled = True
        GradeTextBox.Enabled = True
        AnswerTextBox.Enabled = False
        AddRadioButton.Checked = False
        SubtractRadioButton.Checked = False
        MultiplyRadioButton.Checked = False
        DivideRadioButton.Checked = False
        AddRadioButton.Focus()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        NameTextBox.Enabled = False
        AgeTextBox.Enabled = False
        GradeTextBox.Enabled = False
        SummaryButton.Enabled = True
        AnswerTextBox.Enabled = True
        MathProblem()
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

    Private Sub SummaryButton_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click

        MsgBox($"{NameTextBox.Text} has a current score of {correctAnswerCounter} out of {problemNumberCounter} possible.")

    End Sub
End Class