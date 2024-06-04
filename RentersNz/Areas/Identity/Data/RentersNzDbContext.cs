using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentersNz.Models;

namespace RentersNz.Areas.Identity.Data;

public class RentersNzDbContext : IdentityDbContext<IdentityUser>
{
    public RentersNzDbContext(DbContextOptions<RentersNzDbContext> options)
        : base(options)
    {
    }

    public DbSet<Landlord> Landlord { get; set; }
    public DbSet<Renter> Renter { get; set; } = default!;
    public DbSet<Property> Property { get; set; } = default!;
    public DbSet<Lease> Lease { get; set; } = default!;
    public DbSet<Review> Review { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
