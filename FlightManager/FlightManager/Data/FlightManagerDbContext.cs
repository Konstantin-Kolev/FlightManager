using FlightManager.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Data
{
    public class FlightManagerDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public FlightManagerDbContext()
        {

        }

        public FlightManagerDbContext(DbContextOptions<FlightManagerDbContext> options)
            : base(options)
        {

        }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
