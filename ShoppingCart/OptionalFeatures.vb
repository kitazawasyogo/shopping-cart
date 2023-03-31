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


    ''' <summary>
    ''' 名前の曖昧一致検索
    ''' </summary>
    ''' <param name="searchName">検索する商品の名前</param>
    ''' <param name="list">商品一覧</param>
    ''' <returns>名前の曖昧一致検索の結果</returns>
    Public Function SearchByName(searchName As String, list As List(Of Merchandise)) As List(Of Merchandise)

        Return list.Where(Function(product) product.MerchandiseName.Contains(searchName)).ToList

    End Function


    ''' <summary>
    ''' 価格の範囲検索
    ''' </summary>
    ''' <param name="searchPriceRange">検索する商品の価格の範囲</param>
    ''' <param name="list">商品一覧</param>
    ''' <returns>価格の範囲検索の結果</returns>
    Public Function SearchByPrice(searchPriceRange As String, list As List(Of Merchandise)) As List(Of Merchandise)

        Dim searchPrice() As String = Split(searchPriceRange, "-")

        Return list.Where(Function(product) Integer.Parse(searchPrice(0)) <= product.MerchandisePrice AndAlso product.MerchandisePrice <= Integer.Parse(searchPrice(1))).ToList

    End Function


    ''' <summary>
    ''' ヘルプ機能の表示するメッセージを作る
    ''' </summary>
    ''' <param name="input">入力値</param>
    Public Function MakeHelpMessage(input As String) As String

        If input.Equals("help") Then

            Return "list:商品一覧を表示する事が出来ます。"

        ElseIf input.Equals("list --help") Then

            Return "--name 名前:商品名の曖昧一致検索を行えます。" &
                    vbCrLf & "--price 価格-価格:指定した価格内に収まる商品の検索を行えます。" &
                    vbCrLf & "--sort name:商品一覧を商品名の昇順に並び替える事が出来ます。" &
                    vbCrLf & "--sort price:商品一覧を価格の昇順に並び替える事が出来ます。"

        Else

            Throw New ArgumentException("入力内容が正しくありません。")

        End If

        Throw New InvalidOperationException

    End Function


    ''' <summary>
    ''' ヘルプ機能のメッセージを表示する
    ''' </summary>
    ''' <param name="message">表示するヘルプメッセージ</param>
    Public Sub DisplayHelpMessage(message As String)

        Console.WriteLine(message)

    End Sub

End Class
