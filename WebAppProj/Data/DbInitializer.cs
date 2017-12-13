using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppProj.Models;
using WebAppProj.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebAppProj.Data
{
    public class DbInitializer
    {

        public async static Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            IdentityResult roleResult;
            string[] roleNames = { "Member", "Customer" };
            foreach (var roleName in roleNames)
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            //create an array of Member users 
            var memberUsers = new ApplicationUser[]
            {
                new ApplicationUser
                {
                    UserName = "Member1@email.com",
                    Email = "Member1@email.com",
                }
            };

            // Loop thought memberUser array
            foreach (ApplicationUser _memberUser in memberUsers)
            {
                // create user
                await userManager.CreateAsync(_memberUser, "password");
                // add user to "Member" role
                await userManager.AddToRoleAsync(_memberUser, "Member");
            }

            //create an array of Customer users 
            var customerUsers = new ApplicationUser[]
            {
                new ApplicationUser
                {
                    UserName = "Customer1@email.com",
                    Email = "Customer1@email.com",
                },

                new ApplicationUser
                {
                    UserName = "Customer2@email.com",
                    Email = "Customer2@email.com"
                },
                                        
                new ApplicationUser
                {
                    UserName = "Customer3@email.com",
                    Email = "Customer3@email.com",
                },

                new ApplicationUser
                {
                    UserName = "Customer4@email.com",
                    Email = "Customer4@email.com"
                },

                new ApplicationUser
                {
                   UserName = "Customer5@email.com",
                   Email = "Customer5@email.com",
                }

            };
                //loop through  customerUsers array
            foreach (ApplicationUser _customerUser in customerUsers)
            {
                // create user
                await userManager.CreateAsync(_customerUser, "password");
                // Add user to "Customer" role
                await userManager.AddToRoleAsync(_customerUser, "Customer");

            }
        }
    }
}




