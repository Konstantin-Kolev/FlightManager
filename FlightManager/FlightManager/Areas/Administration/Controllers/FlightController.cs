using FlightManager.Models.Flight;
using FlightManager.Services.Contracts;
using FlightManager.Services.Mappings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Areas.Administration.Controllers
{
    public class FlightController: AdministrationBaseController
    {

        private readonly IFlightService flightService;

        public FlightController(IFlightService flightService)
        {
            this.flightService = flightService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Create(FlightInputModel model)
        {
            await flightService.AddFlight(model);
            return Redirect("/");
        }

        public IActionResult Edit(int id)
        {
            FlightEditInputModel model = flightService.GetOneFlight(id).To<FlightEditInputModel>();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FlightEditInputModel model,int id)
        {
            await flightService.UpdateFlight(model,id);

            return Redirect("/");
        }

        public IActionResult Delete(int id)
        {
            FlightDetailsViewModel model = flightService.GetOneFlight(id).To<FlightDetailsViewModel>();
            return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await flightService.RemoveFlight(id);
            return Redirect("/");
        }
    }
}
