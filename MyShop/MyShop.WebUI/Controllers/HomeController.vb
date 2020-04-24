Imports MyShop.Core

Public Class HomeController
    Inherits System.Web.Mvc.Controller


    Private m_oContext As IRepository(Of Product)
    Private m_oProductCategories As IRepository(Of ProductCategory)

    Public Sub New(ByVal productContext As IRepository(Of Product),
                       ByVal productCategContext As IRepository(Of ProductCategory))

        m_oContext = productContext
        m_oProductCategories = productCategContext

    End Sub
    Function Index() As ActionResult
        Dim lstProducts As List(Of Product)

        lstProducts = New List(Of Product)

        lstProducts = m_oContext.Collection().ToList()
        Return View(lstProducts)
    End Function
    Function Details(ByVal id As String) As ActionResult
        Dim oProduct As Product

        oProduct = New Product

        oProduct = m_oContext.ActionFind(id)

        If oProduct Is Nothing Then
            Return HttpNotFound()
        Else
            Return View(oProduct)
        End If
    End Function
    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
