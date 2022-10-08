using Microsoft.AspNetCore.Http.Json;
using OnlineStore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.WriteIndented = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICatalog, InMemoryCatalog>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/", () => "Hello World!");

app.MapGet("/catalog", (ICatalog catalog) =>
{
    var prods = catalog.GetProducts();
    return prods;
});

app.MapPost("/catalog/add_product", (ICatalog catalog, Product product, HttpContext context) => {
    catalog.AddProduct(product);
   
    context.Response.StatusCode = 201;
});

app.MapPost("/catalog/delete_product", (ICatalog catalog, int id, HttpContext context) => {
    catalog.DeleteProduct(id);

    context.Response.StatusCode = 202;
});

app.Run();
