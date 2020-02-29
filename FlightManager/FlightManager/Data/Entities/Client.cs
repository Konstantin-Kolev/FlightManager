using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Data.Entities
{
    public class Client
    {
        public Client()
        {
            Reservations = new HashSet<Reservation>();
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Email { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
