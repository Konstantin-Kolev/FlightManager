using FlightManager.Data;
using FlightManager.Data.Entities;
using FlightManager.Models.Reservation;
using FlightManager.Services.Mappings;
using ReservationManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FlightManager.Services
{
    public class ReservationService : IReservationService
    {
        private readonly FlightManagerDbContext context;

        public ReservationService(FlightManagerDbContext context)
        {
            this.context = context;
        }

        public void AddReservation(ReservationInputModel model)
        {
            Reservation reservation = model.To<Reservation>();
            context.Add(reservation);
            context.SaveChanges();
        }

        public IEnumerable<ReservationViewModel> GetAllReservations()
        {
            return context.Reservations.Select(x => x.To<ReservationViewModel>());
        }

        public IEnumerable<ReservationViewModel> GetAllReservations(Expression<Func<Reservation, bool>> predicate)
        {
            return context.Reservations.Where(predicate).Select(x => x.To<ReservationViewModel>());
        }

        public Reservation GetOneReservation(int id)
        {
            return context.Reservations.Find(id);
        }

        public Reservation GetOneReservation(Expression<Func<Reservation, bool>> predicate)
        {
            return context.Reservations.FirstOrDefault(predicate);
        }

        public void RemoveReservation(int id)
        {
            Reservation reservation = context.Reservations.Find(id);
            context.Reservations.Remove(reservation);
            context.SaveChanges();
        }

        public void UpdateReservation(ReservationEditInputModel model)
        {
            Reservation reservation = model.To<Reservation>();
            context.Reservations.Update(reservation);
            context.SaveChanges();
        }
    }
}
