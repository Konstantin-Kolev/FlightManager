using FlightManager.Data.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Data.Entities
{
    public class Reservation
    {
        public Reservation()
        {
            Passengers = new HashSet<Passenger>();
            CreatedOn = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public string ClientId { get; set; }
        public Client Client { get; set; }

        public DateTime CreatedOn { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        public ICollection<Passenger> Passengers { get; set; }
    }
}
