using AutoMapper;
using FlightManager.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models.Flight
{
    public class FlightViewModel : IMapFrom<Data.Entities.Flight>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime TakeOffTime { get; set; }

        public TimeSpan Duration { get; set; }

        public int AvailableEconomy { get; set; }

        public int AvailableBusiness { get; set; }

        public void CreateMappings(IProfileExpression configuration) =>
           configuration.CreateMap<Data.Entities.Flight, FlightViewModel>()
               .ForMember(m => m.Duration, y => y.MapFrom(f => f.LandingTime - f.TakeOffTime))
               .ForMember(m => m.Origin, y => y.MapFrom(f => f.Origin.Name))
               .ForMember(m => m.Destination, y => y.MapFrom(f => f.Destination.Name));   

    }
}
