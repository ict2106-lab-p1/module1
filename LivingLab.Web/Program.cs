using LivingLab.Infrastructure;
using LivingLab.Infrastructure.Configuration;
using LivingLab.Web.Configuration;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
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
