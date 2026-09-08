using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToxicPeopleWallet.Data;
using ToxicPeopleWallet.Models;

var builder = WebApplication.CreateBuilder(args);

// --------------------------------------------
// Database
// --------------------------------------------

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// --------------------------------------------
// Identity
// --------------------------------------------

builder.Services
    .AddDefaultIdentity<ApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;

        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 6;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// --------------------------------------------
// MVC
// --------------------------------------------

builder.Services.AddControllersWithViews();

var app = builder.Build();

// --------------------------------------------
// HTTP Pipeline
// --------------------------------------------

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

// Serve files from wwwroot.
// This also supports runtime-uploaded payment screenshots.
app.UseStaticFiles();

app.UseRouting();

// Identity authentication must run before authorization.
app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
    .WithStaticAssets();

await DbSeeder.SeedAsync(app.Services);

app.Run();