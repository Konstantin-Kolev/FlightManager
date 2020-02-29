using AutoMapper;
using FlightManager.Models.Reservation;
using FlightManager.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models.Flight
{
    public class FlightDetailsViewModel : FlightViewModel,IHaveCustomMappings
    {  
        public string PlaneType { get; set; }

        public string PilotName { get; set; }

        public string PlaneNumber { get; set; }

        public ICollection<ReservationViewModel> Reservations { get; set; }

        public new void CreateMappings(IProfileExpression configuration) =>
           configuration.CreateMap<Data.Entities.Flight, FlightDetailsViewModel>()
               .ForMember(m => m.Duration, y => y.MapFrom(f => f.LandingTime - f.TakeOffTime))
               .ForMember(m => m.Origin, y => y.MapFrom(f => f.Origin.Name))
               .ForMember(m => m.Destination, y => y.MapFrom(f => f.Destination.Name))
               .ForMember(m => m.Reservations, y => y.MapFrom(f => f.Reservations.OrderByDescending(r => r.CreatedOn)));
    }
}
