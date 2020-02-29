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
        public int Id { get; set; }

        public string ClientEmail { get; set; }

        public DateTime CreatedOn { get; set; }

        public int TicketsCount { get; set; }
    }
}
