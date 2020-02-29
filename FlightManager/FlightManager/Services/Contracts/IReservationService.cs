using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FlightManager.Data.Entities;
using FlightManager.Models.Reservation;

namespace FlightManager.Services.Contracts
{
    public interface IReservationService
    {
        Task Create(ReservationInputModel model);
    }
}
