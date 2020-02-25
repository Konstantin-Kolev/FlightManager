using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Data.Entities
{
    public class User : IdentityUser
    {
        public int UserId { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PersonalNumber { get; set; }

        public string Address { get; set; }
    }
}
