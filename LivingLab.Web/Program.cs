using LivingLab.Infrastructure;
using LivingLab.Infrastructure.Configuration;
using LivingLab.Web;
using LivingLab.Web.Configuration;
using LivingLab.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;

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
builder.Services.AddControllersWithViews();
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
    app.UseExceptionHandler("/Home/Error");
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
            var path = "/Areas/Identity/Pages/Account/Login.cshtml";
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.MapPost("/sms", () => {
   var response = @"
       <Response>
           <Message>Hello from a .NET Minimal API!</Message>
       </Response>";

   return Results.Text(response, "application/xml");
});
app.Run();
