Imports System.Data.Entity
Imports MyShop.Core

Public Class SQLRepository(Of T As BaseEntity)
    Implements IRepository(Of T)

    Friend context As DataContext
    Friend dbSet As DbSet(Of T)

    Public Sub New(ByVal context As DataContext)
        Me.context = context
        Me.dbSet = context.Set(Of T)
    End Sub
    Public Sub ActionCommit() Implements IRepository(Of T).ActionCommit
        context.SaveChanges()
    End Sub

    Public Sub ActionDelete(sId As String) Implements IRepository(Of T).ActionDelete
        Dim t = ActionFind(sId)
        If context.Entry(t).State = EntityState.Detached Then
            dbSet.Attach(t)
        End If
        dbSet.Remove(t)
    End Sub

    Public Sub ActionInsert(t As T) Implements IRepository(Of T).ActionInsert
        dbSet.Add(t)
    End Sub

    Public Sub ActionUpdate(t As T) Implements IRepository(Of T).ActionUpdate
        dbSet.Attach(t)
        context.Entry(t).State = EntityState.Modified
    End Sub

    Public Function ActionFind(sId As String) As Object Implements IRepository(Of T).ActionFind
        Return dbSet.Find(sId)
    End Function

    Public Function Collection() As IQueryable(Of T) Implements IRepository(Of T).Collection
        Return dbSet
    End Function
End Class
