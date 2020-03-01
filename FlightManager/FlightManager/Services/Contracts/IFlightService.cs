using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FlightManager.Data.Entities;
using FlightManager.Models.Flight;

namespace FlightManager.Services.Contracts
{
    public interface IFlightService
    {

        Task Create(FlightInputModel model);

        Task Update(FlightInputModel model, int id);

        IEnumerable<FlightViewModel> All();

        T GetById<T>(int id);

        Task Delete(int id);
        int AvailableEconomyTickets(int flightId);

        int AvailableBussinesTickets(int flightId);

        Task UpdateAvailableTickets(int flightId, int ecenomyTickets, int bussinesTickets);

    }
}
