using System.Net;

using LivingLab.Infrastructure;
using LivingLab.Infrastructure.Configuration;
using LivingLab.Web;
using LivingLab.Web.Configuration;
using LivingLab.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LivingLab.Infrastructure.Data;

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
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();

//ADD AUTHORIZATION POLICY START
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("LoggedIn", policy =>
        policy.Requirements.Add(new AuthorizeLoggedInController()));
});
builder.Services.AddSingleton<IAuthorizationHandler, LoggedIn>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
//SET REDIRECTION BASED ON AUTHORIZATION POLICY START
app.Use(async (ctx, next) =>
{
    var ep = ctx.Features.Get<IEndpointFeature>()?.Endpoint;
    var authAttr = ep?.Metadata?.GetMetadata<AuthorizeAttribute>();
    if (authAttr != null && authAttr.Policy == "LoggedIn")
    {
        var authService = ctx.RequestServices.GetRequiredService<IAuthorizationService>();
        var result = await authService.AuthorizeAsync(ctx.User, ctx.GetRouteData(), authAttr.Policy);
        if (!result.Succeeded)
        {
            var path = "/Login/Login.cshtml";
            ctx.Response.Redirect(path);
            return;
        }
    }
    await next();
});
//SET REDIRECTION BASED ON AUTHORIZATION POLICY END
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseStatusCodePages(async context => {
    var request = context.HttpContext.Request;
    var response = context.HttpContext.Response;

    if (response.StatusCode == (int)HttpStatusCode.Unauthorized)

    {
        response.Redirect("/Login/Login");
    }
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
