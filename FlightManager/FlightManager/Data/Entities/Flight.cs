﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Data.Entities
{
    public class Flight
    {
        public Flight()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }

        public int OriginId { get; set; }
        public Location Origin { get; set; }

        public int DestinationId { get; set; }
        public Location Destination { get; set; }

        public DateTime TakeOffTime { get; set; }

        public DateTime LandingTime { get; set; }

        public string PlaneType { get; set; }

        public string PlaneNumber { get; set; }

        public string PilotName { get; set; }

        public int AvailableEconomy { get; set; }

        public int AvailableBusiness { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
