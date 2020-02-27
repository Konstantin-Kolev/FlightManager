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

        public IActionResult All()
        {
            IEnumerable<FlightViewModel> flights = flightService.GetAllFlights();

            return View(flights);
        }

        public IActionResult ShowDetails(int id)
        {
            FlightDetailsViewModel model = flightService.GetOneFlight(id).To<FlightDetailsViewModel>();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FlightInputModel model)
        {
            flightService.AddFlight(model);
            return Redirect("/");
        }

        public IActionResult Edit(int id)
        {
            FlightEditInputModel model = flightService.GetOneFlight(id).To<FlightEditInputModel>();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(FlightEditInputModel model)
        {
            flightService.UpdateFlight(model);

            return Redirect("/");
        }

        public IActionResult Delete(int id)
        {
            FlightDetailsViewModel model = flightService.GetOneFlight(id).To<FlightDetailsViewModel>();
            return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public IActionResult DeleteConfirm(int id)
        {
            flightService.RemoveFlight(id);
            return Redirect("/");
        }
    }
}
