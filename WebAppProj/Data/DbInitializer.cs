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

        public async static Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            context.Database.EnsureCreated();

            // check if any users exist.
            //if (context.Users.Any())
            {
                //create an array of users 
                var users = new ApplicationUser[]
                {
                    new ApplicationUser
                    {
                        UserName = "Member1@email.com",
                        Email = "Member1@email.com",
                    },

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
                //loop through users array
                foreach (ApplicationUser _user in users)
                {
                    // create user
                    var result = await userManager.CreateAsync(_user, "password");
                }
            }
        }
    }
}




