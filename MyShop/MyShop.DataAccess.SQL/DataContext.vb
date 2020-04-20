Imports System.Data.Entity
Imports MyShop.Core

Public Class DataContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("DefaultConnection")
    End Sub

    Public Property Products As DbSet(Of Product)
    Public Property ProductCategories As DbSet(Of ProductCategory)
End Class
