Imports NUnit.Framework

Public Class OptionalFeaturesTest

    Private features As New OptionalFeatures

    <Test()> Public Sub 価格の昇順に並び変えられた商品一覧の値を返すか()

        Dim testList As New List(Of Merchandise) From {
            New Merchandise("消しゴム", "モノけし", 120, 30),
            New Merchandise("ノート", "自由帳", 200, 100),
            New Merchandise("椅子", "座椅子", 3000, 20)
        }

        Dim actual As List(Of Merchandise) = features.SortByPrice(testList)


        Assert.That(actual(0).MerchandisePrice, [Is].EqualTo((120)))
        Assert.That(actual(1).MerchandisePrice, [Is].EqualTo((200)))
        Assert.That(actual(2).MerchandisePrice, [Is].EqualTo((3000)))

    End Sub

    <Test()> Public Sub 名前の昇順に並び変えられた商品一覧の値を返すか()

        Dim testList As New List(Of Merchandise) From {
            New Merchandise("ノート", "自由帳", 200, 100),
            New Merchandise("applewatch", "中古", 11000, 2),
            New Merchandise("充電器", "タイプCの充電器", 2000, 10),
            New Merchandise("椅子", "座椅子", 3000, 20)
        }

        Dim actual As List(Of Merchandise) = features.SortByName(testList)

        Assert.That(actual(0).MerchandiseName, [Is].EqualTo(("applewatch")))
        Assert.That(actual(1).MerchandiseName, [Is].EqualTo(("ノート")))
        Assert.That(actual(2).MerchandiseName, [Is].EqualTo(("椅子")))
        Assert.That(actual(3).MerchandiseName, [Is].EqualTo(("充電器")))

    End Sub

    <TestCase("apple")>
    <TestCase("applewatch")>
    Public Sub 商品名で検索した商品の情報を返すか(searchName As String)

        Dim testList As New List(Of Merchandise) From {
            New Merchandise("ノート", "自由帳", 200, 100),
            New Merchandise("applewatch", "中古", 11000, 2),
            New Merchandise("充電器", "タイプCの充電器", 2000, 10),
            New Merchandise("椅子", "座椅子", 3000, 20)
        }

        Dim actual As List(Of Merchandise) = features.SearchByName(searchName, testList)


        Assert.That(actual(0).MerchandiseName, [Is].EqualTo(("applewatch")))

    End Sub

    <TestCase("orange")>
    <TestCase("宇宙船")>
    Public Sub 商品名で検索した商品の情報が見つからない場合(searchName As String)

        Dim testList As New List(Of Merchandise) From {
            New Merchandise("ノート", "自由帳", 200, 100),
            New Merchandise("applewatch", "中古", 11000, 2),
            New Merchandise("充電器", "タイプCの充電器", 2000, 10),
            New Merchandise("椅子", "座椅子", 3000, 20)
        }

        Dim actual As List(Of Merchandise) = features.SearchByName(searchName, testList)

        Assert.That(actual.Count, [Is].EqualTo(0))

    End Sub

    <Test()> Public Sub 価格の範囲で検索した商品の情報を返すか()

        Dim searchPriceRange As String = "100-2500"

        Dim testList As New List(Of Merchandise) From {
            New Merchandise("ノート", "自由帳", 200, 100),
            New Merchandise("充電器", "タイプCの充電器", 2000, 10),
            New Merchandise("椅子", "座椅子", 3000, 20)
        }

        Dim actual As List(Of Merchandise) = features.SearchByPrice(searchPriceRange, testList)

        Assert.That(actual(0).MerchandiseName, [Is].EqualTo(("ノート")))
        Assert.That(actual(1).MerchandiseName, [Is].EqualTo(("充電器")))

    End Sub

    <Test()> Public Sub 価格の範囲で検索した商品が無い場合()

        Dim searchPriceRange As String = "10-150"

        Dim testList As New List(Of Merchandise) From {
            New Merchandise("ノート", "自由帳", 200, 100),
            New Merchandise("充電器", "タイプCの充電器", 2000, 10),
            New Merchandise("椅子", "座椅子", 3000, 20)
        }

        Dim actual As List(Of Merchandise) = features.SearchByPrice(searchPriceRange, testList)

        Assert.That(actual.Count, [Is].EqualTo(0))

    End Sub

    <Test()> Public Sub コマンドヘルプ機能が表示する適切な文言を返すか()

        Dim message As String = "help"

        Dim actual As String = features.MakeHelpMessage(message)


        Assert.That(actual, [Is].EqualTo(("list:商品一覧を表示する事が出来ます。")))

    End Sub

    <Test()> Public Sub オプションヘルプ機能が表示する適切な文言を返すか()

        Dim message As String = "list --help"

        Dim actual As String = features.MakeHelpMessage(message)

        Assert.That(actual, [Is].EqualTo(("--name 名前:商品名の曖昧一致検索を行えます。" &
                                 vbCrLf & "--price 価格-価格:指定した価格内に収まる商品の検索を行えます。" &
                                 vbCrLf & "--sort name:商品一覧を商品名の昇順に並び替える事が出来ます。" &
                                 vbCrLf & "--sort price:商品一覧を価格の昇順に並び替える事が出来ます。")))

    End Sub

    <TestCase("help     ")>
    <TestCase("list --helphelp")>
    Public Sub ヘルプ機能の入力値が想定外の場合は例外を投げる(inputTestValue As String)

        Try
            features.MakeHelpMessage(inputTestValue)
            Assert.Fail()

        Catch ex As ArgumentException

            Assert.That(ex.Message, [Is].EqualTo("入力内容が正しくありません。"))

        End Try

    End Sub

End Class
