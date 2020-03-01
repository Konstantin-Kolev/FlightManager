using AutoMapper;
using FlightManager.Services.Mappings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models.Flight
{
    public class FlightInputModel : IMapTo<Data.Entities.Flight>, IHaveCustomMappings
    {
        [Required]
        public string Origin { get; set; }

        [Required]
        public string Destination { get; set; }

        public DateTime TakeOffTime { get; set; }

        public DateTime LandingTime { get; set; }

        [Required]
        public string PlaneType { get; set; }

        [Required]
        public string PlaneNumber { get; set; }

        [Required]
        public string PilotName { get; set; }

        public int AvailableEconomy { get; set; }

        public int AvailableBusiness { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<FlightInputModel, Data.Entities.Flight>()
                .ForMember(m => m.Destination, y => y.Ignore())
                .ForMember(m => m.Origin, y => y.Ignore());

            configuration.CreateMap<Data.Entities.Flight, FlightInputModel>()
                .ForMember(m => m.Origin, y => y.MapFrom(f => f.Origin.Name))
                .ForMember(m => m.Destination, y => y.MapFrom(f => f.Destination.Name));
        }
    }
}
