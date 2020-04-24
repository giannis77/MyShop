@ModelType IEnumerable(Of MyShop.Core.Product)
@Code
    ViewData("Title") = "Home Page"
End Code

<h1>Products</h1>

@For Each item In Model
    @<div class="col-md-4" style="height:450px;padding:10px;margin:10px;border:solid thin whitesmoke">
        <div class="col-md-12">
            <img class="img" style="height:250px;" src="~/Content/ProductImages/@item.Image" />
        </div>
        <div class="col-md-12">
            <strong>@Html.ActionLink(item.Name, "Details", New With {.id = item.Id})</strong>
        </div>
        <div class="col-md-12">
            <p>@item.Description</p>
        </div>
        <div class="col-md-12">
            <h4>@item.Price</h4>
        </div>
        <div class="col-md-12">
            <a href="google.com" class="btn btn-default">Add to Basket</a>
        </div>
    </div>
Next
<!-- <div class="col-md-12 clearfix" /> -->











