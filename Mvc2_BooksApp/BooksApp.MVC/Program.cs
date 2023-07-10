using AspNetCoreHero.ToastNotification;
using BooksApp.Business.Abstract;
using BooksApp.Business.Concrete;
using BooksApp.Data.Abstract;
using BooksApp.Data.Concrete.EfCore.Contexts;
using BooksApp.Data.Concrete.EfCore.Repositories;
using BooksApp.Entity.Concrete;
using BooksApp.MVC.EmailServices.Abstract;
using BooksApp.MVC.EmailServices.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BooksAppContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<BooksAppContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;//Þifre içinde sayýsal deðer olmalý mý?
    options.Password.RequireLowercase = true;//Þifre içinde küçük harf olmalý mý?
    options.Password.RequireUppercase = true;//Þifre içinde büyük harf olmalý mý?
    options.Password.RequiredLength = 6;//Þifrenin uzunluðu en az kaç karakter olmalý?
    options.Password.RequireNonAlphanumeric = true;//Þifre içinde özel karakter olmalý mý?

    options.Lockout.MaxFailedAccessAttempts = 3; //Üst üste izin verilecek hatalý giriþ sayýsý
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);//Üst üste izin verilen kez hatalý giriþ yapmaya çalýþýlan hesap hangi süreyle kilitlenecek?

    options.User.RequireUniqueEmail = true;//Sistemden daha önce kayýtlý olmayan bir mail adresi kullanýlmak zorunda olsun mu?

    options.SignIn.RequireConfirmedEmail = false;//Kayýt olunurken email onayý istensin mi?
    options.SignIn.RequireConfirmedPhoneNumber = false; //Kayýt olunurken telefon onayý istensin mi?
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";//Eðer kullanýcý eriþebilmesi için login olmak zorunda olduðu bir istekte bulunursa, yönlendirilecek path.
    options.LogoutPath = "/account/logout";//Logout olduðunda yönlendirilecek action
    options.AccessDeniedPath = "/account/accessdenied";//Kullanýcý yetkisi olmayan bir endpointe istekte bulunursa yönlendirilecek path
    options.ExpireTimeSpan = TimeSpan.FromDays(30);//Cookiemizin yaþam süresi ne kadar olacak?
    options.SlidingExpiration = true;
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        Name = "BooksApp.Security.Cookie"
    };
});

builder.Services.AddScoped<IEmailSender, SmtpEmailSender>(option => new SmtpEmailSender
(
    builder.Configuration["EmailSender:Host"],
    builder.Configuration.GetValue<int>("EmailSender:Port"),
    builder.Configuration["EmailSender:UserName"],
    builder.Configuration["EmailSender:Password"],
    builder.Configuration.GetValue<bool>("EmailSender:EnableSsl")
));

builder.Services.AddScoped<IAuthorService, AuthorManager>();
builder.Services.AddScoped<IBookService, BookManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IPublisherService, PublisherManager>();
builder.Services.AddScoped<ICartService, CartManager>();
builder.Services.AddScoped<ICartItemService, CartItemManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();

builder.Services.AddScoped<IAuthorRepository, EfCoreAuthorRepository>();
builder.Services.AddScoped<IBookRepository, EfCoreBookRepository>();
builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
builder.Services.AddScoped<IPublisherRepository, EfCorePublisherRepository>();
builder.Services.AddScoped<ICartRepository, EfCoreCartRepository>();
builder.Services.AddScoped<ICartItemRepository, EfCoreCartItemRepository>();
builder.Services.AddScoped<IOrderRepository, EfCoreOrderRepository>();

builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
    config.Position = NotyfPosition.BottomRight;
});
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();



app.MapControllerRoute(
    name: "bookdetails",
    pattern: "kitapdetay/{url}",
    defaults: new { controller = "BooksShop", action = "BookDetails" }
    );

app.MapControllerRoute(
    name: "bookspublisher",
    pattern: "kitaplar/{publisherurl?}",
    defaults: new { controller = "BooksShop", action = "BookList" }
    );

app.MapControllerRoute(
    name: "booksauthor",
    pattern: "kitaplar/{authorurl?}",
    defaults: new { controller = "BooksShop", action = "BookList" }
    );

app.MapControllerRoute(
    name: "bookscategory",
    pattern: "kitaplar/{categoryurl?}",
    defaults: new { controller = "BooksShop", action = "BookList" }
    );

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
