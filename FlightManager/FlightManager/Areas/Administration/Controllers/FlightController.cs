﻿using FlightManager.Models.Flight;
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

        public IActionResult Create() => View();

        [HttpPost]
        public  async Task<IActionResult> Create(FlightInputModel model)
        {
            if (model.LandingTime < DateTime.Now)
            {
                ModelState.AddModelError(nameof(FlightInputModel.LandingTime), "Landing time must be in the future!");
            }
            if (model.TakeOffTime < DateTime.Now)
            {
                ModelState.AddModelError(nameof(FlightInputModel.LandingTime), "Take off time must be in the future!");
            }
            if (model.LandingTime < model.TakeOffTime)
            {
                ModelState.AddModelError(nameof(FlightInputModel.TakeOffTime), "Take off time must be before landing time!");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await flightService.Create(model);
            return Redirect("/Flight/All");
        }

        public IActionResult Edit(int id)
        {
            FlightInputModel model = flightService.GetById<FlightInputModel>(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FlightInputModel model,int id)
        {
            await flightService.Update(model, id);
            return Redirect("/Flight/All");
        }

        public IActionResult Delete(int id)
        {
            FlightDetailsViewModel model = flightService.GetById<FlightDetailsViewModel>(id);
            return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public IActionResult DeleteConfirm(int id)
        {
            flightService.Delete(id);
            return Redirect("/Flight/All");
        }
    }
}
