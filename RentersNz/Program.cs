using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentersNz.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("RentersNzDbContextConnection") ?? throw new InvalidOperationException("Connection string 'RentersNzDbContextConnection' not found.");

builder.Services.AddDbContext<RentersNzDbContext>(options => options.UseSqlServer(connectionString));

// Configure ASP.NET Core Identity with default user and role classes
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddRoles<IdentityRole>() // Add role management
    .AddEntityFrameworkStores<RentersNzDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

var app = builder.Build();

// Create roles during application startup if they don't exist
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    if (!await roleManager.RoleExistsAsync("RegularUser"))
    {
        await roleManager.CreateAsync(new IdentityRole("RegularUser"));
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
