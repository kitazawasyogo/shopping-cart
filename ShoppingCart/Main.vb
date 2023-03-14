Module Main

    Sub Main()

        Dim merchandise As New MerchandiseList
        Dim verify As New InputValueValidator

        While True

            Try

                Dim inputValue As String = Console.ReadLine()

                verify.SelectFeatures(inputValue)
                Exit While

            Catch ex As ArgumentException
                Console.WriteLine(ex.Message)
            End Try

        End While

        Console.ReadKey()

    End Sub
End Module