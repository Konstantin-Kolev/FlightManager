using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Entities;

namespace ReservationManager.Services.Contracts
{
    interface IReservationService
    {
        IQueryable<Reservation> GetAllReservations();

        IQueryable<Reservation> GetAllReservations(Expression<Func<Reservation, bool>> predicate);

        Reservation GetOneReservation(int id);

        Reservation GetOneReservation(Expression<Func<Reservation, bool>> predicate);

        void AddReservation(Reservation entity);

        void UpdateReservation(Reservation entity);

        void RemoveReservation(Reservation entity);
    }
}
