using FlightManager.Data.Entities;
using FlightManager.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models.Employee
{
    public class EmployeeViewModel : IMapFrom<User>
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PersonalNumber { get; set; }
    }
}
