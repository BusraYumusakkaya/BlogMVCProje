using _31._01.Areas.Identity.Data;
using _31._01.Areas.Identity.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _31._01.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

        string adminRoleId = Guid.NewGuid().ToString();
        string standartRoleId = Guid.NewGuid().ToString();

        IdentityRole adminRole=new IdentityRole { Id=adminRoleId,Name="admin",NormalizedName="ADMIN"};

        IdentityRole standartRole = new IdentityRole { Id = standartRoleId, Name = "standart", NormalizedName = "STANDART" };

        builder.Entity<IdentityRole>().HasData(adminRole);
        builder.Entity<IdentityRole>().HasData(standartRole);

        var hasher = new PasswordHasher<IdentityUser>();

        string adminAppUserId=Guid.NewGuid().ToString();
        string standartAppUserId = Guid.NewGuid().ToString();
        

        ApplicationUser adminUser = new ApplicationUser
        {
            Id = adminAppUserId,
            FirstName = "Admin",
            LastName = "Admin",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            UserName = "admin@admin.com",
            NormalizedUserName = "ADMIN@ADMIN.COM",
            EmailConfirmed = true,
        };
        adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123!");

        ApplicationUser standartUser = new ApplicationUser
        {
            Id = standartAppUserId,
            FirstName = "Standart",
            LastName = "Standart",
            Email = "standart@standart.com",
            NormalizedEmail = "STANDART@STANDART.COM",
            UserName = "standart@standart.com",
            NormalizedUserName = "STANDART@STANDART.COM",
            EmailConfirmed = true,
        };
        standartUser.PasswordHash = hasher.HashPassword(standartUser, "Standart123!");

        builder.Entity<ApplicationUser>().HasData(adminUser);
        builder.Entity<ApplicationUser>().HasData(standartUser);

        IdentityUserRole<string> adminUserRole = new IdentityUserRole<string> { RoleId = adminRoleId, UserId = adminAppUserId };
        IdentityUserRole<string> standartUserRole = new IdentityUserRole<string> { RoleId = standartRoleId, UserId = standartAppUserId };

        builder.Entity<IdentityUserRole<string>>().HasData(adminUserRole);
        builder.Entity<IdentityUserRole<string>>().HasData(standartUserRole);

        builder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>
        {
            UserId = adminAppUserId,
            Id = 1,
            ClaimType = "IsAdmin",
            ClaimValue = "true"
        });

        builder.Entity<Category>().HasData(new Category
        {
            Id = 1,
            About= "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nisl tincidunt eget nullam non. Quis hendrerit dolor magna eget est lorem ipsum dolor sit.",
            CategoryType = "Science"
        });
        builder.Entity<Category>().HasData(new Category
        {
            Id = 2,
            About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nisl tincidunt eget nullam non. Quis hendrerit dolor magna eget est lorem ipsum dolor sit.",
            CategoryType = "Literature"
        });
        builder.Entity<Category>().HasData(new Category
        {
            Id = 3,
            About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nisl tincidunt eget nullam non. Quis hendrerit dolor magna eget est lorem ipsum dolor sit.",
            CategoryType = "Philosophy"
        });
        builder.Entity<Category>().HasData(new Category
        {
            Id = 4,
            About = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nisl tincidunt eget nullam non. Quis hendrerit dolor magna eget est lorem ipsum dolor sit.",
            CategoryType = "History"
        });

    }
}
