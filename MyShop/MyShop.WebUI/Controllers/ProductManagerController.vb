﻿Imports System.Web.Mvc
Imports MyShop.Core
Imports MyShop.DataAccess.InMemory

Namespace Controllers
    Public Class ProductManagerController
        Inherits Controller

        Private m_oContext As ProductRepository

        Public Sub New()
            m_oContext = New ProductRepository

        End Sub
        ' GET: ProductManager
        Function Index() As ActionResult
            Dim lstProducts As List(Of Product)

            lstProducts = New List(Of Product)

            lstProducts = m_oContext.Collection().ToList()

            Return View(lstProducts)
        End Function

        ' GET: ProductManager
        Function CreateProduct() As ActionResult
            Dim oProduct As Product

            oProduct = New Product()

            Return View(oProduct)
        End Function
        <HttpPost()>
        Function CreateProduct(ByVal oProduct As Product) As ActionResult

            If Not ModelState.IsValid Then Return View(oProduct)

            m_oContext.ActionInsert(oProduct)
            m_oContext.ActionCommit()

            Return RedirectToAction("Index")


        End Function

        Function EditProduct(ByVal sId As String) As ActionResult
            Dim oProduct As Product

            oProduct = New Product()

            oProduct = m_oContext.ActionFind(sId)

            If oProduct Is Nothing Then
                Return HttpNotFound()
            Else
                Return View(oProduct)
            End If

        End Function
        <HttpPost()>
        Function EditProduct(ByVal oProduct As Product,
                             ByVal sId As String) As ActionResult

            Dim oProductToEdit As Product

            oProductToEdit = New Product()

            oProductToEdit = m_oContext.ActionFind(sId)


            If oProductToEdit Is Nothing Then
                Return HttpNotFound()
            Else
                If Not ModelState.IsValid Then
                    'return Errors
                    Return View(oProduct)
                Else
                    oProductToEdit.Category = oProduct.Category
                    oProductToEdit.Name = oProduct.Name
                    oProductToEdit.Description = oProduct.Description
                    oProductToEdit.Image = oProduct.Image
                    oProductToEdit.Price = oProduct.Price

                    m_oContext.ActionCommit()
                    Return RedirectToAction("Index")
                End If
            End If

        End Function

        Function Delete(ByVal sId As String) As ActionResult
            Dim oProductToDelete As Product

            oProductToDelete = New Product()

            oProductToDelete = m_oContext.ActionFind(sId)

            If oProductToDelete Is Nothing Then
                Return HttpNotFound()
            Else
                Return View(oProductToDelete)
            End If

        End Function
        <HttpPost()>
        <ActionName("Delete")>
        Function ConfirmDelete(ByVal sId As String) As ActionResult
            Dim oProductToDelete As Product

            oProductToDelete = New Product()

            oProductToDelete = m_oContext.ActionFind(sId)

            oProductToDelete = m_oContext.ActionFind(sId)


            If oProductToDelete Is Nothing Then
                Return HttpNotFound()
            Else

                m_oContext.ActionDelete(sId)
                m_oContext.ActionCommit()
                Return RedirectToAction("Index")
            End If

        End Function
    End Class
End Namespace