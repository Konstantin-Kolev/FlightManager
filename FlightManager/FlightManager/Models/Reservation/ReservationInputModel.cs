using FlightManager.Data.Enumeration;
using FlightManager.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models.Reservation
{
    public class ReservationInputModel : IMapTo<Data.Entities.Reservation>
    {
        public ReservationInputModel()
        {
            Passengers = new List<ReservationPassengerInputModel>();
        }

        public ReservationClientInputModel Client { get; set; }

        public int FlightId { get; set; }

        public List<ReservationPassengerInputModel> Passengers { get; set; }
    }
}
