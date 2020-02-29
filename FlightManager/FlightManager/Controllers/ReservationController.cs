using FlightManager.Data.Enumeration;
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

        public IActionResult All()
        {
            IEnumerable<ReservationViewModel> reservations = reservationService.GetAllReservations();
            return View(reservations);
        }

        public IActionResult Details(int id)
        {
            ReservationDetailsViewModel model = reservationService.GetOneReservation(id).To<ReservationDetailsViewModel>();
            return View(model);
        }

        public IActionResult Create(int flightId)
        {
            var reservation = new ReservationInputModel();
            reservation.Passengers.Add(new ReservationPassengerInputModel());
            reservation.FlightId = flightId;
            return View(reservation);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(ReservationInputModel model)
        //{
        //    int ecenomyTickets = model.Passengers.Count(p => p.TicketType == TicketType.Economy);
        //    int bussinesTickets = model.Passengers.Count(p => p.TicketType == TicketType.Bussines);
        //    int availableEconomyTickets = flightService.AvailableEconomyTickets(model.FlightId);
        //    int availableBusinessTickets = flightService.AvailableBussinesTickets(model.FlightId);
        //    if (availableEconomyTickets < ecenomyTickets)
        //    {
        //        ModelState.AddModelError(string.Empty, $"There are only {availableEconomyTickets} economy tickets left.");
        //    }
        //    if (availableBusinessTickets < bussinesTickets)
        //    {
        //        ModelState.AddModelError(string.Empty, $"There are only {availableBusinessTickets} business tickets left.");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }


        //    await reservationService.AddReservation(model);
        //    await flightService.UpdateAvailableTickets(model.FlightId, ecenomyTickets, bussinesTickets);
        //    //Send email to user in order to approve the reservation
        //    return Redirect("/");
        //}

        public IActionResult Edit(int id)
        {
            ReservationEditInputModel model = reservationService.GetOneReservation(id).To<ReservationEditInputModel>();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ReservationEditInputModel model)
        {
            reservationService.UpdateReservation(model);
            return Redirect("/");
        }

        public IActionResult Delete(int id)
        {
            ReservationDetailsViewModel model = reservationService.GetOneReservation(id).To<ReservationDetailsViewModel>();
            return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public IActionResult DeleteConfirm(int id)
        {
            reservationService.RemoveReservation(id);
            return Redirect("/");
        }
    }
}
