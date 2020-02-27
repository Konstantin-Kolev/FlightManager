﻿using FlightManager.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models.Flight
{
    public class FlightViewModel : IMapFrom<Data.Entities.Flight>
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime TakeOffTime { get; set; }

        public DateTime LandingTime { get; set; }

        public int AvailableSeats { get; set; }

        public int AvailableBussines { get; set; }

    }
}