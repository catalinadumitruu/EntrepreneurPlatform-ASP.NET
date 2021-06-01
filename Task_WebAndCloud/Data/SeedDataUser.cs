using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Task_WebAndCloud.Models;

namespace Task_WebAndCloud.Data
{
    public class SeedDataUser
    { 

        private const string adminEmail = "admin@admin.com";
        private const string adminPassword = "Secret123$";
        private const string job = "developer";
        private const string phoneNumber = "0755555555";
        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices.CreateScope().ServiceProvider;
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var adminRoleName = "Admin";
            var userRoleName = "User";

            if (!await roleManager.RoleExistsAsync(adminRoleName))
                await roleManager.CreateAsync(new IdentityRole(adminRoleName));

            if (!await roleManager.RoleExistsAsync(userRoleName))
                await roleManager.CreateAsync(new IdentityRole(userRoleName));

            using (var userManager = serviceProvider.GetRequiredService<UserManager<User>>())
            {
                User user = await userManager.FindByEmailAsync(adminEmail);

                if (user == null)
                {
                    user = new User { jobDescription = job, UserName = adminEmail, Email = adminEmail, PhoneNumber = phoneNumber };
                    await userManager.CreateAsync(user, adminPassword);
                    await userManager.AddToRoleAsync(user, adminRoleName);
                }
            }
        }

    }
}
