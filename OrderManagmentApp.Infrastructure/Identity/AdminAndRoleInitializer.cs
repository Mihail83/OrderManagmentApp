using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using OrderManagmentApp.Infrastructure.Identity.Models;

namespace OrderManagmentApp.Infrastructure.Identity
{
    public class AdminAndRoleInitializer
    {
        public static async Task InitializeAsynk(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminName = "admin";
            string adminPassword = "admin1";
            if (await roleManager.FindByNameAsync(adminName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(adminName));
            }
            if (await roleManager.FindByNameAsync("User") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
            if (await roleManager.FindByNameAsync("Advanced_user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Advanced_user"));
            }
            if (await userManager.FindByNameAsync(adminName) == null)
            {
                var user = new User { UserName = adminName };
                IdentityResult result = await userManager.CreateAsync(user, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, adminName);
                }
            }

        }
    }
}
