using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimulationProject.BL;
using SimulationProject.Core.Models;
using SimulationProject.DL;
using SimulationProject.DL.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<AppUser, IdentityRole>(
    options =>
    {
        options.Password.RequiredLength = 4;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(10);
        options.Lockout.MaxFailedAccessAttempts = 10;
    }
)
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<AppDbContext>();

// for unauthorized login
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Admin/Account/Login";
    options.AccessDeniedPath = "/";
});

builder.Services.AddDLServices();
builder.Services.AddBLServices();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.MigrateAsync();
}

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
