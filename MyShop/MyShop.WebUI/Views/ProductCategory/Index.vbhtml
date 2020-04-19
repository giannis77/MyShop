@ModelType IEnumerable(Of MyShop.Core.ProductCategory)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "CreateProductCategory")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Category)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Category)
        </td>
        <td>
            @Html.ActionLink("Edit", "EditProductCategory", New With {.id = item.Id}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
        </td>
    </tr>
Next

</table>
