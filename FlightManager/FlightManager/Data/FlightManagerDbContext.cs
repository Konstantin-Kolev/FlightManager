using FlightManager.Data.Entitites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Data
{
    public class FlightManagerDbContext : IdentityDbContext
    {
        public FlightManagerDbContext()
        {

        }

        public FlightManagerDbContext(DbContextOptions<FlightManagerDbContext> options)
            :base (options)
        {

        }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
