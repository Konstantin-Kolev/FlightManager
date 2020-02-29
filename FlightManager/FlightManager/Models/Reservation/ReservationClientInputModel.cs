using FlightManager.Data.Entities;
using FlightManager.Services.Mappings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models.Reservation
{
    public class ReservationClientInputModel : IMapTo<Client>
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
