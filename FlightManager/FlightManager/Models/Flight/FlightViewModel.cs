using FlightManager.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models.Flight
{
    public class FlightViewModel : IMapFrom<Data.Entities.Flight>
    {
        public int Id { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime TakeOffTime { get; set; }

        public TimeSpan Duration { get; set; }

        public string PlaneNumber { get; set; }

    }
}
