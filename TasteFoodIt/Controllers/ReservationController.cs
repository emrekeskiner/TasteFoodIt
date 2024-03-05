using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class ReservationController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Reservation
        public ActionResult ReservationList()
        {
            var value = context.Reservations.ToList();
            return View(value);
        }

        public ActionResult StatusChangeReservation(int id)
        {
            var value = context.Reservations.Find(id);
            if (value.ReservationStatus == "Boş")
            {
                value.ReservationStatus = "Dolu";
            }
            else
            {
                value.ReservationStatus = "Boş";
            }
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }

        [HttpGet]
        public ActionResult CreateReservation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateReservation(Reservation reservation)
        {
            reservation.ReservationStatus = "Dolu";
            //reservation.ReservationDate
            context.Reservations.Add(reservation);
            context.SaveChanges();
            return null;
        }
    }
}