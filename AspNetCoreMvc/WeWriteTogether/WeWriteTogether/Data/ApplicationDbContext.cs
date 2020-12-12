using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WeWriteTogether.Data
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      string schema = "AspNetIdentity";

      builder.Entity<IdentityUser>(entity =>
      {
        entity.ToTable(name: "User", schema: schema);
      });

      builder.Entity<IdentityRole>(entity =>
      {
        entity.ToTable(name: "Role", schema: schema);
      });

      builder.Entity<IdentityUserClaim<string>>(entity =>
      {
        entity.ToTable("UserClaim", schema);
      });

      builder.Entity<IdentityUserLogin<string>>(entity =>
      {
        entity.ToTable("UserLogin", schema);
      });

      builder.Entity<IdentityRoleClaim<string>>(entity =>
      {
        entity.ToTable("RoleClaim", schema);
      });

      builder.Entity<IdentityUserRole<string>>(entity =>
      {
        entity.ToTable("UserRole", schema);
      });

      builder.Entity<IdentityUserToken<string>>(entity =>
      {
        entity.ToTable("UserToken", schema);
      });
    }
  }
}
