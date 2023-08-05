using AspNetCoreHero.ToastNotification;
using LessonWorld.Business.Abstract;
using LessonWorld.Business.Concrete;
using LessonWorld.Data.Abstract;
using LessonWorld.Data.Concrete.EfCore.Contexts;
using LessonWorld.Data.Concrete.EfCore.Repositories;
using LessonWorld.Entity.Concrete;
using LessonWorld.Mvc.EmailServices.Abstract;
using LessonWorld.Mvc.EmailServices.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LessonWorldContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<LessonWorldContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;//�ifre i�inde say�sal de�er olmal� m�?
    options.Password.RequireLowercase = true;//�ifre i�inde k���k harf olmal� m�?
    options.Password.RequireUppercase = true;//�ifre i�inde b�y�k harf olmal� m�?
    options.Password.RequiredLength = 6;//�ifrenin uzunlu�u en az ka� karakter olmal�?
    options.Password.RequireNonAlphanumeric = true;//�ifre i�inde �zel karakter olmal� m�?

    options.Lockout.MaxFailedAccessAttempts = 10; //�st �ste izin verilecek hatal� giri� say�s�
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);//�st �ste izin verilen kez hatal� giri� yapmaya �al���lan hesap hangi s�reyle kilitlenecek?

    options.User.RequireUniqueEmail = true;//Sistemden daha �nce kay�tl� olmayan bir mail adresi kullan�lmak zorunda olsun mu?

    options.SignIn.RequireConfirmedEmail = false;//Kay�t olunurken email onay� istensin mi?
    options.SignIn.RequireConfirmedPhoneNumber = false; //Kay�t olunurken telefon onay� istensin mi?
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";//E�er kullan�c� eri�ebilmesi i�in login olmak zorunda oldu�u bir istekte bulunursa, y�nlendirilecek path.
    options.LogoutPath = "/account/logout";//Logout oldu�unda y�nlendirilecek action
    options.AccessDeniedPath = "/account/accessdenied";//Kullan�c� yetkisi olmayan bir endpointe istekte bulunursa y�nlendirilecek path
    options.ExpireTimeSpan = TimeSpan.FromDays(30);//Cookiemizin ya�am s�resi ne kadar olacak?
    options.SlidingExpiration = true;
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        Name = "LessonWorld.Security.Cookie"
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

builder.Services.AddScoped<ITeacherService, TeacherManager>();
builder.Services.AddScoped<ILessonService, LessonManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ISchoolService, SchoolManager>();
builder.Services.AddScoped<ICartService, CartManager>();
builder.Services.AddScoped<ICartItemService, CartItemManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();


builder.Services.AddScoped<ITeacherRepository, EfCoreTeacherRepository>();
builder.Services.AddScoped<ILessonRepository, EfCoreLessonRepository>();
builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
builder.Services.AddScoped<ISchoolRepository, EfCoreSchoolRepository>();
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
   name: "lessondetails",
   pattern: "dersdetay/{url}",
   defaults: new { controller = "Lessons", action = "LessonDetails" }
    );
app.MapControllerRoute(
   name: "teacherdetails",
   pattern: "dersdetay/{url}",
   defaults: new { controller = "Lessons", action = "TeacherDetails" }
    );

app.MapControllerRoute(
    name: "lessonsschool",
    pattern: "dersler/{schoolurl?}",
    defaults: new { controller = "Lessons", action = "LessonList" }
    );

app.MapControllerRoute(
    name: "lessonsteacher",
    pattern: "dersler/{teacherurl?}",
    defaults: new { controller = "Lessons", action = "LessonList" }
    );

app.MapControllerRoute(
    name: "lessonscategory",
    pattern: "dersler/{categoryurl?}",
    defaults: new { controller = "Lessons", action = "LessonList" }
    );
app.MapControllerRoute(
    name: "lessonscategory",
    pattern: "dersler/{categoryurl?}",
    defaults: new { controller = "Lessons", action = "TeacherList" }
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

