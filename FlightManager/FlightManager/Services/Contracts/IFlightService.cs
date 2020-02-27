using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FlightManager.Data.Entities;
using FlightManager.Models.Flight;

namespace FlightManager.Services.Contracts
{
    public interface IFlightService
    {

        IEnumerable<FlightViewModel> GetAllFlights();

        IEnumerable<FlightViewModel> GetAllFlights(Expression<Func<Flight, bool>> predicate);

        Flight GetOneFlight(int id);

        Flight GetOneFlight(Expression<Func<Flight, bool>> predicate);

        void AddFlight(FlightInputModel model);

        void UpdateFlight(FlightEditInputModel model);

        void RemoveFlight(int id);

    }
}
