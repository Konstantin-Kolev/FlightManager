using FlightManager.Models.Flight;
using FlightManager.Services.Contracts;
using FlightManager.Services.Mappings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightService flightService;

        public FlightController(IFlightService flightService)
        {
            this.flightService = flightService;
        }

        public IActionResult All() => View(flightService.All());

        public IActionResult Details(int id)
        {
            FlightDetailsViewModel model = flightService.GetById<FlightDetailsViewModel>(id);
            return View(model);
        }
    }
}
