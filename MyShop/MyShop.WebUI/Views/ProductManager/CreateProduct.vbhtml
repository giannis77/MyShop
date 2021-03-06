﻿@ModelType MyShop.Core.ProductManagerViewModel
@Code
    ViewData("Title") = "CreateProduct"
End Code

<h2>CreateProduct</h2>

@Using (Html.BeginForm("CreateProduct", "ProductManager", FormMethod.Post, New With {.encType = "multipart/form-data"}))
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Product</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            @Html.LabelFor(Function(model) model.oProduct.Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.oProduct.Name, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.oProduct.Name, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.oProduct.Price, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.oProduct.Price, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.oProduct.Price, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.oProduct.Description, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.oProduct.Description, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.oProduct.Description, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.oProduct.Category, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.oProduct.Category, New SelectList(Model.ProductCategories, "Category", "Category"), New With {.htmlAttributes = New With {.Class = "form-control"}})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.oProduct.Image, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
               <input type="file" id="file" name="file" class="form-control"/>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

                                <div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
