using FlightManager.Data;
using FlightManager.Data.Entities;
using FlightManager.Models.Reservation;
using FlightManager.Services.Mappings;
using FlightManager.Services.Contracts;
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

        public async Task Create(ReservationInputModel model)
        {
            Reservation reservation = model.To<Reservation>();
            Client client = GetReservationClient(model.Client.Email);
            //Check if client has already been added to the database
            if (client != null)
            {
                reservation.Client = client;
            }

            foreach (ReservationPassengerInputModel passanger in model.Passengers)
            {
                reservation.Passengers.Add(GetReservationPassanger(passanger));
            }

            await context.Reservations.AddAsync(reservation);
            await context.SaveChangesAsync();
        }

        public T GetById<T>(int id) =>
            context.Reservations
                .Where(r => r.Id == id)
                .To<T>()
                .FirstOrDefault();

        public Client GetReservationClient(string clientEmail) =>
            context.Clients.FirstOrDefault(c => c.Email == clientEmail);

        public Passenger GetReservationPassanger(ReservationPassengerInputModel model)
        {
            //Check if passanger has already been added to the database
            Passenger passanger = context.Passengers
                .FirstOrDefault(c =>
                c.PersonalNumber == model.PersonalNumber &&
                c.Email == model.Email &&
                c.PhoneNumber == model.PhoneNumber);

            return passanger ?? model.To<Passenger>();
        }
    }
}
