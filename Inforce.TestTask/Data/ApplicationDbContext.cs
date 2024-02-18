using Inforce.TestTask.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inforce.TestTask.Data;

public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ShortenerUrl> ShortenerUrls { get; set; }
    public DbSet<AlgorithmInfoModel> AlgorithmModels { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Role>()
            .HasData(
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "User",
                    NormalizedName = "USER"
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });

        builder.Entity<AlgorithmInfoModel>()
            .HasData(
                new AlgorithmInfoModel
                {
                    Id = Guid.NewGuid(),
                    Stage1 = "Take the user's url",
                    Stage2 = "Generate unique code",
                    Stage3 = "Add data to the database",
                    Stage4 = "Wait for the necessary get request",
                    Stage5 = "Take the code from this request",
                    Stage6 = "Take the corresponding record with the corresponding code in the database",
                    Stage7 = "Redirect the user to the original request"
                }
            );
        
        base.OnModelCreating(builder);
        builder.Ignore<IdentityUserLogin<string>>();
        builder.Ignore<IdentityUserRole<string>>();
        builder.Ignore<IdentityUserClaim<string>>();
        builder.Ignore<IdentityUserToken<string>>();
        builder.Ignore<IdentityUser<string>>();
        builder.Ignore<ApplicationDbContext>();
    }
}