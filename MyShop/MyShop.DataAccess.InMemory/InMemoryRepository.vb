Imports System.Runtime.Caching
Imports MyShop.Core

Public Class InMemoryRepository(Of T As BaseEntity)
    Implements IRepository(Of T)
    Private Cache As ObjectCache = MemoryCache.Default
    Private lstItems As List(Of T)
    Private m_sClassName As String

    Public Sub New()

        m_sClassName = GetType(T).Name
        lstItems = Cache(m_sClassName)

        If lstItems Is Nothing Then
            lstItems = New List(Of T)
        End If
    End Sub

    Public Sub ActionCommit() Implements IRepository(Of T).ActionCommit
        Cache(m_sClassName) = lstItems

    End Sub
    Public Sub ActionInsert(ByVal t As T) Implements IRepository(Of T).ActionInsert
        lstItems.Add(t)
    End Sub

    Public Sub ActionUpdate(ByVal t As T) Implements IRepository(Of T).ActionUpdate
        Dim otToUpdate As T

        otToUpdate = lstItems.Find(Function(p) p.Id = t.Id)

        If Not otToUpdate Is Nothing Then
            otToUpdate = t
        Else
            Throw New Exception(m_sClassName + "Product Not Found")
        End If
    End Sub

    Public Function ActionFind(ByVal sId As String) Implements IRepository(Of T).ActionFind
        Dim otToFind As T

        otToFind = lstItems.Find(Function(p) p.Id = sId)

        If Not otToFind Is Nothing Then
            Return otToFind
        Else
            Throw New Exception("Product Not Found")
        End If
    End Function
    'Return a list than can queried
    Public Function Collection() As IQueryable(Of T) Implements IRepository(Of T).Collection
        Return lstItems.AsQueryable()
    End Function


    Public Sub ActionDelete(ByVal sId As String) Implements IRepository(Of T).ActionDelete
        Dim otToDelete As T

        otToDelete = lstItems.Find(Function(p) p.Id = sId)

        If Not otToDelete Is Nothing Then
            lstItems.Remove(otToDelete)
        Else
            Throw New Exception("Product Not Found")
        End If
    End Sub
End Class
