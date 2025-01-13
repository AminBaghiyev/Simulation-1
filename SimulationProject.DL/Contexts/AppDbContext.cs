using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimulationProject.Core.Models;

namespace SimulationProject.DL.Contexts;

public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public DbSet<Card> Cards { get; set; }
    public DbSet<Settings> Settings { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Roles
        builder.Entity<IdentityRole>(b =>
        {
            b.HasData(
                new IdentityRole { Id = "2982c4ba-a277-4194-a7b9-d000681a2616", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "b75e7920-1c08-466a-b499-7f88a6ef0bdd", Name = "User", NormalizedName = "USER" }
                );
        });
        #endregion

        #region Admin
        AppUser admin = new()
        {
            Id = "03a04c31-7301-40a5-8bee-83ca957e36ed",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            ConcurrencyStamp = "1497f77c-8981-42f4-b706-142e00346a45",
            SecurityStamp = "22959176-adad-496c-a334-5f996c92b09d"
        };

        PasswordHasher<AppUser> hasher = new();

        admin.PasswordHash = hasher.HashPassword(admin, "admin123");

        builder.Entity<AppUser>(b =>
        {
            b.HasData(admin);
        });

        builder.Entity<IdentityUserRole<string>>(b =>
        {
            b.HasData(
                new IdentityUserRole<string> {
                    UserId = admin.Id,
                    RoleId = "2982c4ba-a277-4194-a7b9-d000681a2616"
                });
        });
        #endregion

        #region Settings
        builder.Entity<Settings>(b =>
        {
            b.HasData(
                new Settings
                {
                    Id = 1
                });
        });
        #endregion

        base.OnModelCreating(builder);
    }
}
