using FlightManager.Data;
using FlightManager.Data.Entities;
using FlightManager.Models.Flight;
using FlightManager.Services.Contracts;
using FlightManager.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FlightManager.Services
{
    public class FlightService : IFlightService
    {
        private readonly FlightManagerDbContext context;

        public FlightService(FlightManagerDbContext context)
        {
            this.context = context;
        }

        public void AddFlight(FlightInputModel model)
        {
            var flight = model.To<Flight>();
            context.Flights.Add(flight);
            context.SaveChanges();
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
            return context.Flights.Find(predicate);
        }

        public void RemoveFlight(int id)
        {
            Flight flight = context.Flights.Find(id);
            context.Flights.Remove(flight);
            context.SaveChanges();
        }

        public void UpdateFlight(FlightEditInputModel model)
        {
            Flight flight = model.To<Flight>();
            context.Flights.Update(flight);
            context.SaveChanges();
        }
    }
}
