using IBS.Models;
using IBS.Models.MasterFile;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace IBS.DataAccess.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // 1. Seed Company
            if (!await context.Companies.AnyAsync(c => c.CompanyName == "MMSI"))
            {
                var company = new Company
                {
                    CompanyCode = "MMS",
                    CompanyName = "MMSI",
                    CompanyAddress = "Office Address 14th Floor Jollibee Centre, San Miguel Ave., Pasig City",
                    CompanyTin = "000-000-000-000",
                    BusinessStyle = "Maritime Services",
                    IsActive = true,
                    CreatedBy = "SYSTEM",
                    CreatedDate = DateTime.SpecifyKind(DateTime.UtcNow.AddHours(8), DateTimeKind.Unspecified)
                };
                context.Companies.Add(company);
                await context.SaveChangesAsync();
            }

            // 2. Seed Roles
            string[] roleNames = { "Admin", "User" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // 3. Seed Admin User
            var adminEmail = "admin@mmsi.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Name = "Admin User",
                    Department = "IT",
                    IsActive = true,
                    EmailConfirmed = true,
                    CreatedDate = DateTime.SpecifyKind(DateTime.UtcNow.AddHours(8), DateTimeKind.Unspecified)
                };

                var result = await userManager.CreateAsync(adminUser, "Admin123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                    await userManager.AddClaimAsync(adminUser, new System.Security.Claims.Claim("Company", "MMSI"));
                }
            }
        }
    }
}
