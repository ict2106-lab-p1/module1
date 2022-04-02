

using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Entities.Secrets;
using LivingLab.Infrastructure;
using LivingLab.Infrastructure.Configuration;
using LivingLab.Infrastructure.Data;
using LivingLab.Web;
using LivingLab.Web.Configuration;

using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext(connectionString);
builder.Services.ConfigurePasswordPolicy();
builder.Services.AddIdentities();
builder.Services.AddCoreServices();
builder.Services.AddWebServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddRazorPages().AddRazorPagesOptions(ops =>
{
    ops.Conventions.AuthorizeAreaFolder("Home", "/", "RequireAdmins");
    ops.Conventions.AuthorizeFolder("/", "RequireAdmins");
    ops.Conventions.AllowAnonymousToAreaPage("Login", "/");
});
builder.Services.AddAuthorization(ops =>
{
    ops.AddPolicy("RequireAdmins", policy => policy.RequireRole("Admins"));
});
builder.Services.AddScoped<XCookieAuthEvents>();

// optional: customize cookie expiration time
builder.Services.ConfigureApplicationCookie(ops =>
{
    ops.EventsType = typeof(XCookieAuthEvents);
    ops.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    ops.SlidingExpiration = true;
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
// SET TO LOGIN iF WRONG URL
app.UseStatusCodePages();
// app.UseStatusCodePagesWithRedirects("/login");

//SET REDIRECTION BASED ON AUTHORIZATION POLICY END
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
