using FlightManager.Common;
using FlightManager.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Data.Seeding
{
    public class AdminSeeder : ISeeder
    {
        public async Task SeedAsync(FlightManagerDbContext dbContext, IServiceProvider serviceProvider)
        {
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            User userFromDb = await userManager.FindByNameAsync("admin");

            if (userFromDb != null)
            {
                return;
            }

            var user = new User
            {
                
            };

            await userManager.CreateAsync(user, "asd123asd");
            await userManager.AddToRoleAsync(user, GlobalConstants.Roles.Administrator);
        }
    }
}
