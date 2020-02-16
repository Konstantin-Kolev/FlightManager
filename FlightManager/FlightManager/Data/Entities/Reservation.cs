using FlightManager.Data.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Data.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PersonalNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Nationality { get; set; }

        public TicketEnum TicketType { get; set; }

        public string Buyer { get; set; }

        public int FlightId { get; set; }

        public Flight Flight { get; set; }
    }
}
