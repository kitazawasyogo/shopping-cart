''' <summary>
''' 検索条件を指定できるオプション機能
''' </summary>
Public Class OptionalFeatures


    ''' <summary>
    ''' 商品名を比較
    ''' </summary>
    Private Class MerchandiseNameComparer : Implements IComparer(Of String)

        Private ReadOnly compareInfo As Globalization.CompareInfo = Globalization.CultureInfo.GetCultureInfo("ja-jp").CompareInfo

        ''' <summary>
        ''' 比較する
        ''' </summary>
        Public Function Compare(value As String, compareValue As String) As Integer Implements IComparer(Of String).Compare

            Return compareInfo.Compare(value, compareValue)

        End Function

    End Class

    Private ReadOnly comparer As New MerchandiseNameComparer


    ''' <summary>
    ''' 商品一覧を価格の昇順に並び変える
    ''' </summary>
    ''' <returns>商品一覧を価格の昇順に並び変えた値</returns>
    Public Function SortByPrice(list As List(Of Merchandise)) As List(Of Merchandise)

        Return list.OrderBy(Function(product) product.MerchandisePrice).ToList

    End Function


    ''' <summary>
    ''' 商品一覧を名前の昇順に並び変える
    ''' </summary>
    ''' <returns>商品一覧を価格の昇順に並び変えた値</returns>
    Public Function SortByName(list As List(Of Merchandise)) As List(Of Merchandise)

        Return list.OrderBy(Function(product) product.MerchandiseName, comparer).ToList

    End Function

End Class
