Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public Class Product
    Inherits BaseEntity

    <StringLength(20)>
    <DisplayName("Product Name")>
    Public Property Name As String

    <Range(0, 1000)>
    Public Property Price As Decimal

    Public Property Description As String
    Public Property Category As String
    Public Property Image As String

End Class
