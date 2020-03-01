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

        public DbSet<Location> Locations { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Passenger> Passengers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Flight>(flight =>
            {
                flight.HasOne(f => f.Origin)
                .WithMany(o => o.OriginFlights)
                .HasForeignKey(f => f.OriginId)
                .OnDelete(DeleteBehavior.ClientCascade);

                flight.HasOne(f => f.Destination)
                .WithMany(o => o.DestinationFlights)
                .HasForeignKey(f => f.DestinationId)
                .OnDelete(DeleteBehavior.ClientCascade);

                flight.HasMany(f => f.Reservations)
                .WithOne(r => r.Flight)
                .HasForeignKey(r => r.FlightId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Reservation>(reservation =>
            {
                reservation.HasMany(p => p.Passengers)
                .WithOne(p => p.Reservation)
                .HasForeignKey(p => p.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(builder);
        }
    }
}
