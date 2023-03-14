''' <summary>
''' 入力値を検証する
''' </summary>
Public Class InputValueValidator

    Private product As New MerchandiseList

    ''' <summary>
    ''' 入力値からコマンドとオプション機能を選ぶ
    ''' </summary>
    ''' <param name="input">入力されたコマンドの値</param>
    Public Sub SelectFeatures(input As String)

        Dim productList As List(Of Merchandise) = product.MakeMerchandiseList()

        If input.Equals("list") Then

            product.DisplayMerchandiseList(productList)
        Else

            Throw New ArgumentException("入力内容が正しくありません。")

        End If


    End Sub

End Class
