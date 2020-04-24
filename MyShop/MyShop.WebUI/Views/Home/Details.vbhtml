@ModelType MyShop.Core.Product
@Code
    ViewData("Title") = Model.Name + " Details"
End Code

<h2>@Html.DisplayFor(Function(model) model.Name)</h2>

<div>
    <div class="col-md-2">
        <img class="img-responsive" src="~/Content/ProductImages/@Model.Image" />
    </div>
    <div class="col-md-10">
        <dl Class="dl-horizontal">

            <dt>
                @Html.DisplayNameFor(Function(model) model.Description)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.Description)
            </dd>

            <dt>
                @Html.DisplayNameFor(Function(model) model.Price)
            </dt>

            <dd>
                $@Html.DisplayFor(Function(model) model.Price)
            </dd>

            <dt></dt>

            <dd>
                <a href="#" class="btn btn-default">Add to Basket</a>
            </dd>
            <dt></dt>
            <dd>@Html.ActionLink("Back to List", "Index")</dd>
        </dl>
    </div>
</div>
<!-- <div class="col-md-12 clearfix" /> -->
