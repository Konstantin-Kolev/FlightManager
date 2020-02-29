﻿using FlightManager.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FlightManager.Common.GlobalConstants;

namespace FlightManager.Data.Seeding
{
    public class AdminSeeder : ISeeder
    {
        public async Task SeedAsync(FlightManagerDbContext dbContext, IServiceProvider serviceProvider)
        {
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            User userFromDb = await userManager.FindByNameAsync(Admin.Username);

            if (userFromDb != null)
            {
                return;
            }

            var user = new User
            {
                UserName = Admin.Username,
                Email = Admin.Email,
                Name = Admin.Name,
                Surname = Admin.Surname,
                PersonalNumber = Admin.PersonalNumber,
                PhoneNumber = Admin.PhoneNumber,
                Address = Admin.Address
            };

            await userManager.CreateAsync(user, Admin.Password);
            var result = await userManager.AddToRoleAsync(user, Roles.Administrator);

        }
    }
}
