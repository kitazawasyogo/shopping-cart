Imports NUnit.Framework

Public Class InputValueValidatorTest

    Private vluseTest As New InputValueValidator

    <TestCase("1234")>
    <TestCase("abcd")>
    <TestCase("abcdef")>
    Public Sub コマンド入力値が想定外の場合は例外を投げる(inputTestValue As String)

        Try
            vluseTest.SelectFeatures(inputTestValue)
            Assert.Fail()

        Catch ex As ArgumentException

            Assert.That(ex.Message, [Is].EqualTo("入力内容が正しくありません。"))

        End Try

    End Sub

    <TestCase("list")>
    <TestCase("list --sort price")>
    <TestCase("list --sort name")>
    <TestCase("list --name 机")>
    Public Sub コマンド入力値が想定内の場合は例外を投げない(inputTestValue As String)

        vluseTest.SelectFeatures(inputTestValue)

        Assert.Pass()

    End Sub

End Class
