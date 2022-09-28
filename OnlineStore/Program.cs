using Microsoft.AspNetCore.Http.Json;
using OnlineStore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.WriteIndented = true;
});

var app = builder.Build();
Catalog catalog = new Catalog();

app.MapGet("/", () => "Hello World!");
app.MapGet("/catalog", () =>
{
    
    return catalog.Products;
});

app.MapPost("/catalog/add_product", (Product product, HttpContext context) => {
    catalog.Products.Add(product);
    context.Response.StatusCode = 201;
});

app.MapPost("/catalog/clear_catalog", () =>
{
    catalog.Products.Clear();
    Console.WriteLine("Successful cleaning");
});

app.Run();
