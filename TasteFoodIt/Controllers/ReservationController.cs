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
            var value = context.Reservations.OrderByDescending(x=>x.ReservationDate).ToList();
            return View(value);
        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult CreateReservation()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult CreateReservation(Reservation reservation)
        {
            reservation.ReservationStatus = "beklemede";
            context.Reservations.Add(reservation);
            context.SaveChanges();

            return Json(reservation, JsonRequestBehavior.AllowGet);
        }
        
        //Reservation Onaylama
        public ActionResult AcceptReservation(int id)
        {
            var reservation = context.Reservations.Find(id);
            reservation.ReservationStatus = "onaylandi";
            
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        //Reservation Bekletme
        public ActionResult WaitReservation(int id)
        {
            var reservation = context.Reservations.Find(id);
            reservation.ReservationStatus = "beklemede";

            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        //Reservation İptal etme
        public ActionResult CancelReservation(int id)
        {
            var reservation = context.Reservations.Find(id);
            reservation.ReservationStatus = "iptal";

            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }


        public ActionResult DeleteReservation(int id)
        {
            var Reservation = context.Reservations.Find(id);
           
            context.Reservations.Remove(Reservation);
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }

        [HttpGet]
        public ActionResult UpdateReservation(int id)
        {
            var Reservation = context.Reservations.Find(id);
            return View(Reservation);
        }

        [HttpPost]
        public ActionResult UpdateReservation(Reservation reservation)
        {
            var value = context.Reservations.Find(reservation.ReservationId);
            value.ReservationStatus = reservation.ReservationStatus;
            value.Name = reservation.Name;
            value.Phone = reservation.Phone;
            value.Email = reservation.Email;
            value.ReservationDate = reservation.ReservationDate;
            value.Time = reservation.Time;
            value.GuestCount = reservation.GuestCount;
            context.SaveChanges();

            return RedirectToAction("ReservationList");
        }

    }
}