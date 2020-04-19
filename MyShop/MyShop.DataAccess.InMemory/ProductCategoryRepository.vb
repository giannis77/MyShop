Imports MyShop.Core
Imports System.Runtime.Caching

Public Class ProductCategoryRepository
    Public Cache As ObjectCache = MemoryCache.Default

    Public lstProductCategories As List(Of ProductCategory)

    Public Sub New()

        lstProductCategories = Cache("lstProductCategories")

        If lstProductCategories Is Nothing Then
            lstProductCategories = New List(Of ProductCategory)
        End If
    End Sub

    Public Sub ActionCommit()

        Cache("lstProductCategories") = lstProductCategories

    End Sub
    Public Sub ActionInsert(ByVal oProductCategory As ProductCategory)
        lstProductCategories.Add(oProductCategory)
    End Sub

    Public Sub ActionUpdate(ByVal oProductCategory As ProductCategory)
        Dim oProductCategoryToUpdate As ProductCategory

        oProductCategoryToUpdate = New ProductCategory

        oProductCategoryToUpdate = lstProductCategories.Find(Function(p) p.Id = oProductCategory.Id)

        If Not oProductCategoryToUpdate Is Nothing Then
            oProductCategoryToUpdate = oProductCategory
        Else
            Throw New Exception("Product Not Found")
        End If
    End Sub

    Public Function ActionFind(ByVal sId As String)
        Dim oProductCategoryFind As ProductCategory

        oProductCategoryFind = New ProductCategory

        oProductCategoryFind = lstProductCategories.Find(Function(p) p.Id = sId)

        If Not oProductCategoryFind Is Nothing Then
            Return oProductCategoryFind
        Else
            Throw New Exception("Product Not Found")
        End If
    End Function
    Public Function Collection() As IQueryable(Of ProductCategory)
        Return lstProductCategories.AsQueryable()
    End Function


    Public Sub ActionDelete(ByVal sId As String)
        Dim oProductCategoryToDelete As ProductCategory

        oProductCategoryToDelete = New ProductCategory

        oProductCategoryToDelete = lstProductCategories.Find(Function(p) p.Id = sId)

        If Not oProductCategoryToDelete Is Nothing Then
            lstProductCategories.Remove(oProductCategoryToDelete)
        Else
            Throw New Exception("Product Not Found")
        End If
    End Sub
End Class
