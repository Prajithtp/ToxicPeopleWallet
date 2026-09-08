using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToxicPeopleWallet.Models;

namespace ToxicPeopleWallet.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var context =
                scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var userManager =
                scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var roleManager =
                scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Apply any pending migrations
            await context.Database.MigrateAsync();

            // --------------------------------
            // Roles
            // --------------------------------

            const string adminRole = "Admin";
            const string memberRole = "Member";

            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(
                    new IdentityRole(adminRole));
            }

            if (!await roleManager.RoleExistsAsync(memberRole))
            {
                await roleManager.CreateAsync(
                    new IdentityRole(memberRole));
            }

            // --------------------------------
            // Default Admin
            // --------------------------------

            const string adminEmail = "admin@toxicpeoplewallet.com";
            const string adminPassword = "Admin@123";

            var admin =
                await userManager.FindByEmailAsync(adminEmail);

            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    FullName = "Toxic Wallet Admin",
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    CurrentBalance = 0
                };

                var result =
                    await userManager.CreateAsync(
                        admin,
                        adminPassword);

                if (!result.Succeeded)
                {
                    var errors = string.Join(
                        ", ",
                        result.Errors.Select(x => x.Description));

                    throw new Exception(
                        $"Failed to create admin user: {errors}");
                }
            }

            if (!await userManager.IsInRoleAsync(admin, adminRole))
            {
                await userManager.AddToRoleAsync(
                    admin,
                    adminRole);
            }

            // --------------------------------
            // Initial Group Wallet
            // --------------------------------

            if (!await context.GroupWallets.AnyAsync())
            {
                var wallet = new GroupWallet
                {
                    WalletName = "Toxic People Wallet",
                    TotalBalance = 0,
                    UpdatedAt = DateTime.UtcNow
                };

                context.GroupWallets.Add(wallet);

                await context.SaveChangesAsync();
            }
        }
    }
}