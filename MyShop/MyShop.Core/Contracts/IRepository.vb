Imports MyShop.Core

Public Interface IRepository(Of T As BaseEntity)
    Sub ActionCommit()
    Sub ActionDelete(sId As String)
    Sub ActionInsert(t As T)
    Sub ActionUpdate(t As T)
    Function ActionFind(sId As String) As Object
    Function Collection() As IQueryable(Of T)
End Interface
