Imports System.Runtime.Caching
Imports MyShop.Core

Public Class ProductRepository
    Public Cache As ObjectCache = MemoryCache.Default

    Public lstProducts As List(Of Product)

    Public Sub New()

        lstProducts = Cache("lstProduct")

        If lstProducts Is Nothing Then
            lstProducts = New List(Of Product)
        End If
    End Sub

    Public Sub ActionCommit()

        Cache("lstProducts") = lstProducts

    End Sub
    Public Sub ActionInsert(ByVal oProduct As Product)
        lstProducts.Add(oProduct)
    End Sub

    Public Sub ActionUpdate(ByVal oProduct As Product)
        Dim oProductToUpdate As Product

        oProductToUpdate = New Product

        oProductToUpdate = lstProducts.Find(Function(p) p.Id = oProduct.Id)

        If Not oProductToUpdate Is Nothing Then
            oProductToUpdate = oProduct
        Else
            Throw New Exception("Product Not Found")
        End If
    End Sub

    Public Function ActionFind(ByVal sId As String)
        Dim oProductFind As Product

        oProductFind = New Product

        oProductFind = lstProducts.Find(Function(p) p.Id = sId)

        If Not oProductFind Is Nothing Then
            Return oProductFind
        Else
            Throw New Exception("Product Not Found")
        End If
    End Function
    'Return a list than can queried
    Public Function Collection() As IQueryable(Of Product)
        Return lstProducts.AsQueryable()
    End Function


    Public Sub ActionDelete(ByVal oProduct As Product)
        Dim oProductToDelete As Product

        oProductToDelete = New Product

        oProductToDelete = lstProducts.Find(Function(p) p.Id = oProduct.Id)

        If Not oProductToDelete Is Nothing Then
            lstProducts.Remove(oProductToDelete)
        Else
            Throw New Exception("Product Not Found")
        End If
    End Sub
End Class
