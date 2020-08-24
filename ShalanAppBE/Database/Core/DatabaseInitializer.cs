using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShalanAppBE.Authentication;
using ShalanAppBE.Database.Entities;
using System;
using System.Threading.Tasks;

namespace ShalanAppBE.Database.Core
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public DatabaseInitializer(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task SeedAsync()
        {
            var admin = new User();
            await context.Database.MigrateAsync().ConfigureAwait(false);

            if (!await context.Users.AnyAsync())
            {
                await EnsureRoleAsync(UserRoles.Admin, UserRoles.Admin);
                await EnsureRoleAsync(UserRoles.User, UserRoles.User);

                //  In-built default Admin user.
                admin = await CreateUserAsync("admin", "Admin123@", "admin@shalan.com", "+1 (123) 000-0000", UserRoles.Admin);
            }
            
            await context.SaveChangesAsync();
        }

        private async Task EnsureRoleAsync(string roleName, string description)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                IdentityRole role = new IdentityRole(roleName);

                var result = await this.roleManager.CreateAsync(role);

                if (!result.Succeeded)
                    throw new Exception($"Seeding \"{description}\" role failed.");
            }
        }

        private async Task<User> CreateUserAsync(string userName, string password, string email, string phoneNumber, string role)
        {
            User user = new User
            {
                UserName = userName,
                Email = email,
                PhoneNumber = phoneNumber,
                EmailConfirmed = true,
                CrtDate = DateTime.Now,
            };

            var result = await userManager.CreateAsync(user, password);

            await userManager.AddToRolesAsync(user, new string[] { role });

            if (!result.Succeeded)
                throw new Exception($"Seeding \"{userName}\" user failed.");


            return user;
        }
    }
}
