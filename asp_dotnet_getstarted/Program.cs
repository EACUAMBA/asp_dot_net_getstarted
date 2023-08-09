using asp_dotnet_getstarted.Models;
using asp_dotnet_getstarted.Services;
using Microsoft.AspNetCore.Builder;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


//Teaching .NET that this new service can be injected in classes that need one.
builder.Services.AddTransient<JsonProductService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapBlazorHub();
app.MapControllers();

app.UseEndpoints(enpoints =>
{
    //enpoints.MapGet("/products", (context) =>
    //{
    //    IEnumerable<Product>? products = app.Services.GetService<JsonProductService>()?.GetProducts();

    //    string productsJsonAsString = JsonSerializer.Serialize<IEnumerable<Product>>(products!, new JsonSerializerOptions()
    //    {
    //        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    //    });

    //    return context.Response.WriteAsync(productsJsonAsString);

    //});
});

app.Run();
