Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public Class Product

    Public Sub New()
        Me.Id = Guid.NewGuid.ToString()
    End Sub

    Public Property Id As String

    <StringLength(20)>
    <DisplayName("Product Name")>
    Public Property Name As String

    <Range(0, 1000)>
    Public Property Price As Double

    Public Property Description As String
    Public Property Category As String
    Public Property Image As String

End Class
