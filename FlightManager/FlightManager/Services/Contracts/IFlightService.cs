using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FlightManager.Data.Entities;

namespace FlightManager.Services.Contracts
{
    interface IFlightService
    {

        IQueryable<Flight> GetAllFlights();

        IQueryable<Flight> GetAllFlights(Expression<Func<Flight, bool>> predicate);

        Flight GetOneFlight(int id);

        Flight GetOneFlight(Expression<Func<Flight, bool>> predicate);

        void AddFlight(Flight entity);

        void UpdateFlight(Flight entity);

        void RemoveFlight(Flight entity);

    }
}
