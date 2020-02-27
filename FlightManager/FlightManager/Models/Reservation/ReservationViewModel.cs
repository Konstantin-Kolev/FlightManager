using FlightManager.Data.Enumeration;
using FlightManager.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models.Reservation
{
    public class ReservationViewModel: IMapFrom<Data.Entities.Reservation>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Nationality { get; set; }

        public TicketEnum TicketType { get; set; }

        public string Buyer { get; set; }

        public int FlightId { get; set; }
    }
}
