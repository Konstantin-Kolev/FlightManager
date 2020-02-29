using FlightManager.Data.Entities;
using FlightManager.Services.Mappings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models.Employee
{
    public class EmployeeEditInputModel : IMapTo<User>, IMapFrom<User>
    {
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [RegularExpression(@"\d{10}")]
        public string PersonalNumber { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
