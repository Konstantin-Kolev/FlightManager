using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Data.Seeding
{
    interface ISeeder
    {
        public interface ISeeder
        {
            Task SeedAsync(FlightManagerDbContext dbContext, IServiceProvider serviceProvider);
        }
    }
}
