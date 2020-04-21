Public MustInherit Class BaseEntity
    Public Property Id As String
    Public Property CreatedAt As DateTimeOffset

    Public Sub New()
        If Me.Id = Nothing Then
            Me.Id = Guid.NewGuid().ToString()
            Me.CreatedAt = DateTime.Now
        End If
    End Sub
End Class
