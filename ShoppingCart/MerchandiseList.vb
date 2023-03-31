''' <summary>
''' 商品一覧
''' </summary>
Public Class MerchandiseList

    ''' <summary>
    ''' 商品一覧の項目名:商品名
    ''' </summary>
    Const NAME_ITEM As String = "商品名"

    ''' <summary>
    ''' 商品一覧の項目名:商品説明
    ''' </summary>
    Const DESCRIPTION_ITEM As String = "商品説明"

    ''' <summary>
    ''' 商品一覧の項目名:価格
    ''' </summary>
    Const PRICE_ITEM As String = "価格"

    ''' <summary>
    ''' 商品一覧の項目名:在庫
    ''' </summary>
    Const STOCK_ITEM As String = "在庫"


    ''' <summary>
    ''' 商品一覧を作成する
    ''' </summary>
    ''' <returns>商品一覧</returns>
    Public Function MakeMerchandiseList() As List(Of Merchandise)

        Dim displayList As New List(Of Merchandise) From {
            New Merchandise("消しゴム", "モノけし", 120, 30),
            New Merchandise("ノート", "自由帳", 200, 100),
            New Merchandise("椅子", "座椅子", 3000, 20),
            New Merchandise("ソファー", "リクライニング機能付き", 15000, 5),
            New Merchandise("机", "四つ足の机", 5000, 5),
            New Merchandise("携帯電話", "SIMカード無", 30000, 10),
            New Merchandise("充電器", "タイプCの充電器", 2000, 10),
            New Merchandise("ゴミ箱", "底は浅め", 1500, 20),
            New Merchandise("掃除機", "コードレス", 23000, 8),
            New Merchandise("パソコン", "ノートPC", 22000, 5),
            New Merchandise("色鉛筆セット", "12色の色鉛筆", 900, 20),
            New Merchandise("鉛筆", "六角形の鉛筆", 100, 50),
            New Merchandise("applewatch", "中古", 11000, 2)
        }

        Return displayList

    End Function


    ''' <summary>
    ''' 商品一覧を表示する
    ''' </summary>
    Public Sub DisplayMerchandiseList(productList As List(Of Merchandise))

        Console.Write(Join({NAME_ITEM, DESCRIPTION_ITEM, PRICE_ITEM, STOCK_ITEM}, Space(1)))
        Console.WriteLine()

        For Each displayList As Merchandise In productList

            Console.Write(Join({displayList.MerchandiseName, displayList.MerchandiseDescription, displayList.MerchandisePrice, displayList.MerchandiseStock}, Space(1)))
            Console.WriteLine()

        Next

    End Sub

End Class
