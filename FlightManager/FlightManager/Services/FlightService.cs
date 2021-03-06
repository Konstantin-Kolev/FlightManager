﻿using FlightManager.Data;
using FlightManager.Data.Entities;
using FlightManager.Models.Flight;
using FlightManager.Services.Contracts;
using FlightManager.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FlightManager.Services
{
    public class FlightService : IFlightService
    {
        private readonly FlightManagerDbContext context;

        public FlightService(FlightManagerDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<FlightViewModel> All() =>
            context.Flights.To<FlightViewModel>().ToList();

        public int AvailableBussinesTickets(int flightId) =>
            context.Flights.Where(f => f.Id == flightId)
            .Select(f => f.AvailableBusiness)
            .FirstOrDefault();

        public int AvailableEconomyTickets(int flightId) =>
            context.Flights.Where(f => f.Id == flightId)
            .Select(f => f.AvailableEconomy)
            .FirstOrDefault();

        public async Task Create(FlightInputModel model)
        {
            Flight flight = model.To<Flight>();
            flight.Origin = GetFlightLocation(model.Origin);
            flight.Destination = GetFlightLocation(model.Destination);
            await context.Flights.AddAsync(flight);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Flight flight = context.Flights.Find(id);
            IQueryable<Reservation> reservations = context.Reservations.Where(r => r.FlightId == id);
            IQueryable<Passenger> passengers = reservations.SelectMany(r => r.Passengers);
            context.Reservations.RemoveRange(reservations);
            context.Passengers.RemoveRange(passengers);
            context.Flights.Remove(flight);
            await context.SaveChangesAsync();
        }

        public T GetById<T>(int id) =>
            context.Flights
                .Where(f => f.Id == id)
                .To<T>()
                .FirstOrDefault();

        public async Task Update(FlightInputModel model, int id)
        {
            Flight flight = context.Flights.Find(id);
            flight.Origin = GetFlightLocation(model.Origin);
            flight.Destination = GetFlightLocation(model.Destination);
            flight.AvailableBusiness = model.AvailableBusiness;
            flight.AvailableEconomy = model.AvailableEconomy;
            flight.LandingTime = model.LandingTime;
            flight.PilotName = model.PilotName;
            flight.PlaneNumber = model.PlaneNumber;
            flight.PlaneType = model.PlaneType;
            flight.TakeOffTime = model.TakeOffTime;

            context.Flights.Update(flight);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAvailableTickets(int flightId, int ecenomyTickets, int businessTickets)
        {
            Flight flight = context.Flights.Find(flightId);
            flight.AvailableEconomy -= ecenomyTickets;
            flight.AvailableBusiness -= businessTickets;

            context.Flights.Update(flight);
            await context.SaveChangesAsync();
        }

        private Location GetFlightLocation(string locationName)
        {
            Location location = context.Locations.FirstOrDefault(l => l.Name == locationName);
            if (location == null)
            {
                location = new Location { Name = locationName };
            }

            return location;
        }
    }
}
