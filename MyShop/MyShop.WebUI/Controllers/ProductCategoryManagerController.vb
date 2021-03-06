﻿Imports System.Web.Mvc
Imports MyShop.Core
Imports MyShop.DataAccess.InMemory

Namespace Controllers
    Public Class ProductCategoryController
        Inherits Controller

        Private m_oContext As IRepository(Of ProductCategory)
        Public Sub New(ByVal productCategContext As IRepository(Of ProductCategory))
            m_oContext = productCategContext
        End Sub
        ' GET: ProductManager
        Function Index() As ActionResult
            Dim lstProductCategory As List(Of ProductCategory)

            lstProductCategory = New List(Of ProductCategory)

            lstProductCategory = m_oContext.Collection().ToList()

            Return View(lstProductCategory)
        End Function

        ' GET: ProductManager
        Function CreateProductCategory() As ActionResult
            Dim oProductCategory As ProductCategory

            oProductCategory = New ProductCategory()

            Return View(oProductCategory)
        End Function
        <HttpPost()>
        Function CreateProductCategory(ByVal oProductCategory As ProductCategory) As ActionResult

            If Not ModelState.IsValid Then Return View(oProductCategory)

            m_oContext.ActionInsert(oProductCategory)
            m_oContext.ActionCommit()

            Return RedirectToAction("Index")

        End Function

        Function EditProductCategory(ByVal id As String) As ActionResult
            Dim oProductCategory As ProductCategory

            oProductCategory = New ProductCategory()

            oProductCategory = m_oContext.ActionFind(id)

            If oProductCategory Is Nothing Then
                Return HttpNotFound()
            Else
                Return View(oProductCategory)
            End If

        End Function
        <HttpPost()>
        Function EditProductCategory(ByVal oProductCategory As ProductCategory,
                                     ByVal id As String) As ActionResult

            Dim oProductCategoryToEdit As ProductCategory

            oProductCategoryToEdit = New ProductCategory()

            oProductCategoryToEdit = m_oContext.ActionFind(id)


            If oProductCategoryToEdit Is Nothing Then
                Return HttpNotFound()
            Else
                If Not ModelState.IsValid Then
                    'return Errors
                    Return View(oProductCategory)
                Else
                    oProductCategoryToEdit.Category = oProductCategory.Category

                    m_oContext.ActionCommit()
                    Return RedirectToAction("Index")
                End If
            End If

        End Function

        Function Delete(ByVal id As String) As ActionResult
            Dim oProductCategoryToDelete As ProductCategory

            oProductCategoryToDelete = New ProductCategory()

            oProductCategoryToDelete = m_oContext.ActionFind(id)

            If oProductCategoryToDelete Is Nothing Then
                Return HttpNotFound()
            Else
                Return View(oProductCategoryToDelete)
            End If

        End Function
        <HttpPost()>
        <ActionName("Delete")>
        Function ConfirmDelete(ByVal id As String) As ActionResult
            Dim oProductCategoryToDelete As ProductCategory

            oProductCategoryToDelete = New ProductCategory()

            oProductCategoryToDelete = m_oContext.ActionFind(id)

            If oProductCategoryToDelete Is Nothing Then
                Return HttpNotFound()
            Else

                m_oContext.ActionDelete(id)
                m_oContext.ActionCommit()
                Return RedirectToAction("Index")
            End If

        End Function
    End Class
End Namespace