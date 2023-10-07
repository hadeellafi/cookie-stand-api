using CookieStandApi.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CookieStandApi.Data
{
    public class CookieStandDbContext: IdentityDbContext<AuthUser>
    {
        public CookieStandDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            var roleName1 = "admin";
            var roleName2 = "guest";
            var role1 = new IdentityRole
            {
                Id = roleName1.ToLower(),
                Name = roleName1,
                NormalizedName = roleName1.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };
            var role2 = new IdentityRole
            {
                Id = roleName2.ToLower(),
                Name = roleName2,
                NormalizedName = roleName2.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };

            builder.Entity<IdentityRole>().HasData(role1, role2);

            var hasher = new PasswordHasher<AuthUser>();
            var adminUser = new AuthUser
            {
                Id = "1",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gamil.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "A12345@"),
            };
            builder.Entity<AuthUser>().HasData(adminUser);

            

            // Assign the "Admin" role to the seeded user
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "admin",
                UserId = "1"
            });
          
            
            
              


        }

        public DbSet<CookieStand> CookieStands { get; set; }

        public DbSet<HourlySale> HourlySales { get; set; }







    }

}
