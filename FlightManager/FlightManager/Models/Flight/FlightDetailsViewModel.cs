using FlightManager.Models.Reservation;
using FlightManager.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models.Flight
{
    public class FlightDetailsViewModel : FlightViewModel
    {  
        public string PlaneType { get; set; }

        public string PilotName { get; set; }

        public int AvailableEconomy { get; set; }

        public int AvailableBussines { get; set; }

        public ICollection<ReservationViewModel> Reservations { get; set; }
    }
}
