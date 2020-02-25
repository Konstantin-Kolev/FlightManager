using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FlightManager.Data.Entities;
using FlightManager.Models.Flight;

namespace FlightManager.Services.Contracts
{
    interface IFlightService
    {

        IQueryable<FlightViewModel> GetAllFlights();

        IQueryable<FlightViewModel> GetAllFlights(Expression<Func<Flight, bool>> predicate);

        Flight GetOneFlight(int id);

        Flight GetOneFlight(Expression<Func<Flight, bool>> predicate);

        void AddFlight(FlightInputModel model);

        void UpdateFlight(FlightEditInputModel model);

        void RemoveFlight(int id);

    }
}
