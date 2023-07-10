using MiniShopApp.Business.Abstract;
using MiniShopApp.Business.Concrete;
using MiniShopApp.Data.Abstract;
using MiniShopApp.Data.Concrete.EfCore.Repositories;
//Comment
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//Uygulaman�n ba�lang�c� s�ras�nda, hen�z derleme ger�ekle�memi�ken, CategoryManager tipinde bir nesne yarat�l�r ve nesne IOC(havuz) i�ine konulur. Sonra uygulaman�n i�inde herhangi bir yerde ICategoryService tipinde bir nesne istendi�inde, ona az �nce yarat�ld���n� s�yledi�imiz CategoryManager tipinde bir nesne havuzdan verilecek.

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();


builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
builder.Services.AddScoped<IProductRepository, EfCoreProductRepository>();
//IOC - Container-Havuz



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "productsbycategory",
    pattern: "products/{categoryUrl}",
    defaults: new { controller = "Product", action = "Index" }
);

app.MapControllerRoute(
    name: "productdetails",
    pattern: "details/{url}",
    defaults: new { controller = "Product", action = "Details" }
);

app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern:"admin/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
