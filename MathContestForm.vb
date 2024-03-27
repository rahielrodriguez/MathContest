Option Strict On
Option Explicit On
Public Class MathContestForm

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
    Function ValidateUserField() As Boolean
        'TODO
        '[X]Name cannot be blank
        '[X]Age cannot be blank
        '[X]Age must be a positive whole number
        '[X]Age must be between 7 and 11
        '[x]Display an error message if age is not in range

        Dim message As String
        Dim age As UShort

        If NameTextBox.Text = "" Then
            Return False
        Else
            Return True
        End If

        If AgeTextBox.Text = "" Then
            Return False
        Else
            Return True
            Try
                age = CUShort(AgeTextBox.Text)

                Select Case age
                    Case <= 7
                        message &= "Student not eligible to compete" & vbNewLine
                        Return False
                        AgeTextBox.Focus()
                    Case 7 To 11

                    Case >= 11
                        message &= "Student not eligible to compete" & vbNewLine
                        Return False
                        AgeTextBox.Focus()
                End Select
            Catch ex As Exception
                message &= "Age cannot be blank and must be a whole number!" & vbNewLine
            End Try
            MsgBox(message, MsgBoxStyle.Critical, "User Error")
        End If

        MsgBox(message, MsgBoxStyle.Critical, "User Error")

    End Function
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

    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click

        'TODO
        '[ ]Enable submit button if user fields are validated
        If ValidateUserField() = True Then
            SubmitButton.Enabled = True
        Else
            SubmitButton.Enabled = False
        End If

    End Sub
End Class
