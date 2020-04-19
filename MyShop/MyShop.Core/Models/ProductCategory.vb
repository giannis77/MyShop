Public Class ProductCategory
    Public Property Id As String
    Public Property Category As String

    Private Sub ProductCategory()
        Me.Id = Guid.NewGuid().ToString()
    End Sub
End Class
