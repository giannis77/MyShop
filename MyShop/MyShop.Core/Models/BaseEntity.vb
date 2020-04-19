Public MustInherit Class BaseEntity
    Public Property Id As String
    Public Property CreatedAt As DateTimeOffset

    Private Sub BaseEntry()
        Me.Id = Guid.NewGuid().ToString()
        Me.CreatedAt = DateTime.Now
    End Sub
End Class
