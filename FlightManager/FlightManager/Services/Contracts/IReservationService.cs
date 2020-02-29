﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FlightManager.Data.Entities;
using FlightManager.Models.Reservation;

namespace ReservationManager.Services.Contracts
{
    public interface IReservationService
    {
        IEnumerable<ReservationViewModel> GetAllReservations();

        IEnumerable<ReservationViewModel> GetAllReservations(Expression<Func<Reservation, bool>> predicate);

        Reservation GetOneReservation(int id);

        Reservation GetOneReservation(Expression<Func<Reservation, bool>> predicate);

        Task AddReservation(ReservationInputModel model);

        Task UpdateReservation(ReservationEditInputModel model);

        Task RemoveReservation(int id);
    }
}
