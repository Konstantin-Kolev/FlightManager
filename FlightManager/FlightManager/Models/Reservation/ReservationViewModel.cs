using AutoMapper;
using FlightManager.Data.Entities;
using FlightManager.Data.Enumeration;
using FlightManager.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models.Reservation
{
    public class ReservationViewModel: IMapFrom<Data.Entities.Reservation>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int FlightId { get; set; }

        public string ClientEmail { get; set; }

        public DateTime CreatedOn { get; set; }

        public int TicketsCount { get; set; }

        public ICollection<Passenger> Passengers { get; set; }

        void IHaveCustomMappings.CreateMappings(IProfileExpression configuration) =>
            configuration.CreateMap<Data.Entities.Reservation, ReservationViewModel>()
                .ForMember(m => m.TicketsCount, y => y.MapFrom(r => r.Passengers.Count));
    }
}
