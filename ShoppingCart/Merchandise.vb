''' <summary>
''' 商品の項目
''' </summary>
Public Class Merchandise

    ''' <summary>
    ''' 商品の商品名
    ''' </summary>
    ''' <returns>商品名の値</returns>
    Public Property MerchandiseName As String = Nothing

    ''' <summary>
    ''' 商品の商品説明
    ''' </summary>
    ''' <returns>商品説明の値</returns>
    Public Property MerchandiseDescription As String = Nothing

    ''' <summary>
    ''' 商品の価格
    ''' </summary>
    ''' <returns>価格の値</returns>
    Public Property MerchandisePrice As Integer = 0

    ''' <summary>
    ''' 商品の在庫
    ''' </summary>
    ''' <returns>在庫の値</returns>
    Public Property MerchandiseStock As Integer = 0


    ''' <summary>
    ''' 各商品の項目ごとの値を設定する
    ''' </summary>
    ''' <param name="name">商品名</param>
    ''' <param name="description">商品説明</param>
    ''' <param name="price">価格</param>
    ''' <param name="stock">在庫</param>
    Public Sub New(name As String, description As String, price As Integer, stock As Integer)

        MerchandiseName = name
        MerchandiseDescription = description
        MerchandisePrice = price
        MerchandiseStock = stock

    End Sub

End Class
