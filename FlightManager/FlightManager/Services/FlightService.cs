using FlightManager.Data;
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

        public async Task AddFlight(FlightInputModel model)
        {
            var flight = model.To<Flight>();
            await context.Flights.AddAsync(flight);
            await context.SaveChangesAsync();
        }

        public IEnumerable<FlightViewModel> GetAllFlights()
        {
            return context.Flights.Select(x => x.To<FlightViewModel>());
        }

        public IEnumerable<FlightViewModel> GetAllFlights(Expression<Func<Flight, bool>> predicate)
        {
            return context.Flights.Where(predicate).Select(x => x.To<FlightViewModel>());
        }

        public Flight GetOneFlight(int id)
        {
            return context.Flights.Find(id);
        }

        public Flight GetOneFlight(Expression<Func<Flight, bool>> predicate)
        {
            return context.Flights.FirstOrDefault(predicate);
        }

        public async Task RemoveFlight(int id)
        {
            Flight flight = context.Flights.Find(id);
            context.Flights.Remove(flight);
            await context.SaveChangesAsync();
        }

        public async Task UpdateFlight(FlightEditInputModel model, int id)
        {
            Flight flight = context.Flights.Find(id);
            flight.Origin = model.Origin;
            flight.Destination = model.Destination;
            flight.AvailableBussines = model.AvailableBussines;
            flight.AvailableEconomy = model.AvailableEconomy;
            flight.LandingTime = model.LandingTime;
            flight.PilotName = model.PilotName;
            flight.PlaneNumber = model.PlaneNumber;
            flight.PlaneType = model.PlaneType;
            flight.TakeOffTime = model.TakeOffTime;

            context.Flights.Update(flight);
            await context.SaveChangesAsync();
        }
    }
}
