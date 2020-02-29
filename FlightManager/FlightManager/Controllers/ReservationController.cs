using FlightManager.Models.Reservation;
using FlightManager.Services.Mappings;
using Microsoft.AspNetCore.Mvc;
using ReservationManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;

        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ReservationInputModel model)
        {
            reservationService.AddReservation(model);
            return Redirect("/");
        }

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
