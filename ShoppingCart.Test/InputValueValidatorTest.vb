Imports NUnit.Framework

Public Class InputValueValidatorTest

    Private vluseTest As New InputValueValidator

    <TestCase("1234")>
    <TestCase("abcd")>
    <TestCase("abcdef")>
    <TestCase("xxli")>
    <TestCase("xxhe")>
    <TestCase("list --xxname")>
    <TestCase("list --xxpr")>
    <TestCase("list --xxsoat name")>
    <TestCase("list --xxsoort price")>
    <TestCase("list --hhelpe")>
    Public Sub コマンド入力値が想定外の場合は例外を投げる(inputTestValue As String)

        Try
            vluseTest.SelectFeatures(inputTestValue)
            Assert.Fail()

        Catch ex As ArgumentException

            Assert.That(ex.Message, [Is].EqualTo("入力内容が正しくありません。"))

        End Try

    End Sub

    <TestCase("200")>
    <TestCase("-200")>
    <TestCase("200-")>
    <TestCase("20-200-2000")>
    <TestCase("二千円")>
    <TestCase("二千円-三千円")>
    <TestCase("abc-200")>
    Public Sub 検索機能の価格の入力値が想定外だった場合例外を投げる(inputTestValue As String)

        Try
            vluseTest.ValidatePriceRange(inputTestValue)
            Assert.Fail()

        Catch ex As ArgumentException

            Assert.That(ex.Message, [Is].EqualTo("入力内容が正しくありません。"))

        End Try

    End Sub

    <TestCase("list")>
    <TestCase("list --sort price")>
    <TestCase("list --sort name")>
    <TestCase("list --name 机")>
    <TestCase("list --price 200-4000")>
    Public Sub コマンド入力値が想定内の場合は例外を投げない(inputTestValue As String)

        vluseTest.SelectFeatures(inputTestValue)

        Assert.Pass()

    End Sub

    <TestCase("h")>
    <TestCase("l")>
    <TestCase("")>
    Public Sub コマンド入力値が2文字未満の場合nullを返す(inputTestValue As String)

        Dim actual As String = vluseTest.MakeSuggestFeatures(inputTestValue)
        Assert.That(actual, [Is].EqualTo(Nothing))

    End Sub

    <TestCase("list --")>
    <TestCase("list --n")>
    <TestCase("list --s")>
    Public Sub オプション入力値が2文字未満の場合nullを返す(inputTestValue As String)

        Dim actual As String = vluseTest.MakeSuggestFeatures(inputTestValue)
        Assert.That(actual, [Is].EqualTo(Nothing))

    End Sub

    <Test> Public Sub 入力値の頭2文字がリスト表示コマンドと一致する場合はサジェストの文字列を返す()

        Dim inputTestValue As String = "liaa"
        Dim actual As String = vluseTest.MakeSuggestFeatures(inputTestValue)

        Assert.That(actual, [Is].EqualTo(("もしかして：list")))

    End Sub

    <Test> Public Sub 入力値の頭2文字がコマンドヘルプ機能のコマンドと一致する場合はサジェストの文字列を返す()

        Dim inputTestValue As String = "hell"
        Dim actual As String = vluseTest.MakeSuggestFeatures(inputTestValue)

        Assert.That(actual, [Is].EqualTo(("もしかして：help")))

    End Sub

    <Test> Public Sub 入力値の頭2文字がオプションヘルプ機能のコマンドと一致する場合はサジェストの文字列を返す()

        Dim inputTestValue As String = "list --heaa"
        Dim actual As String = vluseTest.MakeSuggestFeatures(inputTestValue)

        Assert.That(actual, [Is].EqualTo(("もしかして：list --help")))

    End Sub

    <Test> Public Sub 入力値の頭2文字が商品名検索機能のコマンドと一致する場合はサジェストの文字列を返す()

        Dim inputTestValue As String = "list --naaa 机"
        Dim actual As String = vluseTest.MakeSuggestFeatures(inputTestValue)

        Assert.That(actual, [Is].EqualTo(("もしかして：list --name 名前")))

    End Sub

    <Test> Public Sub 入力値の頭2文字が価格範囲検索機能のコマンドと一致する場合はサジェストの文字列を返す()

        Dim inputTestValue As String = "list --praaa 200-4000"
        Dim actual As String = vluseTest.MakeSuggestFeatures(inputTestValue)

        Assert.That(actual, [Is].EqualTo(("もしかして：list --price 価格-価格")))

    End Sub

    <TestCase("list --sort naaa")>
    <TestCase("list --sort priaaaa")>
    <TestCase("list --soee naaa")>
    Public Sub 入力値の頭2文字がソート機能のコマンドと一致する場合はサジェストの文字列を返す(inputTestValue As String)

        Dim actual As String = vluseTest.MakeSuggestFeatures(inputTestValue)

        Assert.That(actual, [Is].EqualTo(("もしかして：list --sort name,list --sort price")))

    End Sub

End Class
