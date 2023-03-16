''' <summary>
''' 検索条件を指定できるオプション機能
''' </summary>
Public Class OptionalFeatures


    ''' <summary>
    ''' 商品一覧を価格の昇順に並び変える
    ''' </summary>
    ''' <returns>商品一覧を価格の昇順に並び変えた値</returns>
    Public Function SortByPrice(list As List(Of Merchandise)) As List(Of Merchandise)

        Return list.OrderBy(Function(product) product.MerchandisePrice).ToList

    End Function

End Class
