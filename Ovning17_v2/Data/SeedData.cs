using Microsoft.AspNetCore.Identity;    //UserManager, RoleManager
using Microsoft.EntityFrameworkCore;    //DbContextOptions
using Microsoft.Extensions.DependencyInjection; //GetRequiredService
using Ovning17_v2.Models;
using System;
using System.Threading.Tasks;   //Task


namespace Ovning17_v2.Data
{
    //internal class SeedData
    public static class SeedData
    {
        internal static async Task InitializeAsync(IServiceProvider services, string adminPW)
        {
            var options = services.GetRequiredService<DbContextOptions<ApplicationDbContext>>();

            using (var context = new ApplicationDbContext(options))
            {
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                //Create Roles ("Member" and "Admin")
                var roleNames = new[] { "Admin", "Member" };

                foreach (var name in roleNames)
                {
                    //Om rollen redan finns fortsätt
                    if (await roleManager.RoleExistsAsync(name)) continue;

                    //Annars skapa rollen
                    var role = new IdentityRole { Name = name };
                    var result = await roleManager.CreateAsync(role);

                    if (!result.Succeeded)
                    {
                        throw new Exception(string.Join("\n", result.Errors));
                    }
                }

                //Creating a user
                var adminEmails = new[] { "admin@gym.se" };

                foreach (var email in adminEmails)
                {
                    var foundUser = await userManager.FindByEmailAsync(email);

                    //Om user redan finns, fortsätt
                    if (foundUser != null) continue;

                    //Annars skapa user
                    var user = new ApplicationUser { UserName = email, Email = email };
                    var addUserResult = await userManager.CreateAsync(user, adminPW);

                    if (!addUserResult.Succeeded)
                    {
                        throw new Exception(string.Join("\n", addUserResult.Errors));
                    }
                }

                //Set the user to the Roles of Admin and Member
                var adminUser = await userManager.FindByEmailAsync(adminEmails[0]);

                foreach (var role in roleNames)
                {
                    //Om user redan har den rollen, fortsätt
                    if (await userManager.IsInRoleAsync(adminUser, role)) continue;

                    var addToRoleResult = await userManager.AddToRoleAsync(adminUser, role);

                    if (!addToRoleResult.Succeeded)
                    {
                        throw new Exception(string.Join("\n", addToRoleResult.Errors));
                    }
                }

                context.SaveChanges();
            }
 
        }
    }
}