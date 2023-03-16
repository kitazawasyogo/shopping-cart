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

End Class
