﻿using FlightManager.Data.Enumeration;
using FlightManager.Models.Reservation;
using FlightManager.Services.Contracts;
using FlightManager.Services.Mappings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;
        private readonly IFlightService flightService;

        public ReservationController(IReservationService reservationService, IFlightService flightService)
        {
            this.reservationService = reservationService;
            this.flightService = flightService;
        }

        public IActionResult Create(int flightId)
        {
            var reservation = new ReservationInputModel();
            reservation.Passengers.Add(new ReservationPassengerInputModel());
            reservation.FlightId = flightId;
            return View(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationInputModel model)
        {
            int ecenomyTickets = model.Passengers.Count(p => p.TicketType == TicketType.Economy);
            int bussinesTickets = model.Passengers.Count(p => p.TicketType == TicketType.Bussines);
            int availableEconomyTickets = flightService.AvailableEconomyTickets(model.FlightId);
            int availableBusinessTickets = flightService.AvailableBussinesTickets(model.FlightId);
            if (availableEconomyTickets < ecenomyTickets)
            {
                ModelState.AddModelError(string.Empty, $"There are only {availableEconomyTickets} economy tickets left.");
            }
            if (availableBusinessTickets < bussinesTickets)
            {
                ModelState.AddModelError(string.Empty, $"There are only {availableBusinessTickets} business tickets left.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            await reservationService.Create(model);
            await flightService.UpdateAvailableTickets(model.FlightId, ecenomyTickets, bussinesTickets);
            //Send email to user in order to approve the reservation
            return Redirect("/");
        }

        public IActionResult Details(int id)
        {
            ReservationViewModel model = reservationService.GetById<ReservationViewModel>(id);
            return View(model);
        }
    }
}
