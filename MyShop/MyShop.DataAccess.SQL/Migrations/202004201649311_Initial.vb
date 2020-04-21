Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Initial
        Inherits DbMigration

        Public Overrides Sub Up()
            CreateTable(
             "dbo.ProductCategories",
             Function(c) New With
                 {
                     .Id = c.String(nullable:=False, maxLength:=128),
                     .Category = c.String(),
                     .CreatedAt = c.DateTimeOffset(nullable:=False, precision:=7)
                 }) _
             .PrimaryKey(Function(t) t.Id)

            CreateTable(
                "dbo.Products",
                Function(c) New With
                    {
                        .Id = c.String(nullable:=False, maxLength:=128),
                        .Name = c.String(maxLength:=20),
                        .Price = c.Decimal(nullable:=False, precision:=18, scale:=2),
                        .Description = c.String(),
                        .Category = c.String(),
                        .Image = c.String(),
                        .CreatedAt = c.DateTimeOffset(nullable:=False, precision:=7)
                    }) _
                .PrimaryKey(Function(t) t.Id)
        End Sub

        Public Overrides Sub Down()
            DropTable("dbo.Products")
            DropTable("dbo.ProductCategories")
        End Sub
    End Class
End Namespace
