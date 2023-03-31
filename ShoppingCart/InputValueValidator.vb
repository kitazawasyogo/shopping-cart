Imports System.Text.RegularExpressions


''' <summary>
''' 入力値を検証する
''' </summary>
Public Class InputValueValidator

    Private product As New MerchandiseList

    Private features As New OptionalFeatures

    ''' <summary>
    ''' 入力値からコマンドとオプション機能を選ぶ
    ''' </summary>
    ''' <param name="input">入力されたコマンドの値</param>
    Public Sub SelectFeatures(input As String)

        Const REQUIRE_PARAM_LENGTH_LIST_COMMAND As Integer = 3

        Dim productList As List(Of Merchandise) = product.MakeMerchandiseList()

        Dim inputOption As String() = Split(input, " ")

        If input.Contains("help") Then

            features.DisplayHelpMessage(features.MakeHelpMessage(input))

        ElseIf input.Equals("list") Then

            product.DisplayMerchandiseList(productList)

        ElseIf inputOption(0).Equals("list") AndAlso inputOption.Length = REQUIRE_PARAM_LENGTH_LIST_COMMAND Then

            If inputOption(1).Equals("--sort") AndAlso inputOption(2).Equals("price") Then

                product.DisplayMerchandiseList(features.SortByPrice(productList))

            ElseIf inputOption(1).Equals("--sort") AndAlso inputOption(2).Equals("name") Then

                product.DisplayMerchandiseList(features.SortByName(productList))

            ElseIf inputOption(1).Equals("--name") Then

                product.DisplayMerchandiseList(features.SearchByName(inputOption(2), productList))

            ElseIf inputOption(1).Equals("--price") AndAlso ValidatePriceRange(inputOption(2)) Then

                product.DisplayMerchandiseList(features.SearchByPrice(inputOption(2), productList))

            Else

                Throw New ArgumentException("入力内容が正しくありません。")

            End If

        Else

            Throw New ArgumentException("入力内容が正しくありません。")

        End If


    End Sub


    ''' <summary>
    ''' 価格範囲検索機能の価格入力値チェック
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    Public Function ValidatePriceRange(input As String) As Boolean

        Const REQUIRE_PARAM_LENGTH_PRICE_RANGE As Integer = 2

        Dim priceRange As String() = Split(input, "-")

        If Not New Regex("[0-9]\d{1,}\-[0-9]\d{1,}$").IsMatch(input) OrElse Not priceRange.Length = REQUIRE_PARAM_LENGTH_PRICE_RANGE Then

            Throw New ArgumentException("入力内容が正しくありません。")

        End If

        Return True

    End Function

End Class
