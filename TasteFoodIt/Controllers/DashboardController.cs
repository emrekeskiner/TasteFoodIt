using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;
using TasteFoodIt.Models;

namespace TasteFoodIt.Controllers
{
    public class DashboardController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Dashboard
        public ActionResult DashboardList()
        {
            ViewBag.categoryCount = context.Categories.Count();
            ViewBag.productCount = context.Products.Count();
            ViewBag.chefCount = context.Chefs.Count();
            ViewBag.reservationCount = context.Reservations.Where(x => x.ReservationStatus == "onaylandi").Count();


            return View();
        }

        public ActionResult GrafikOlustur()
        {
            
            return Json(Rezervasyonlar(), JsonRequestBehavior.AllowGet );
        }

        public List<ReservationsChart> Rezervasyonlar()
        {
            //List<ReservationsChart> rc = new List<ReservationsChart>();
            //rc = context.Database.ExecuteSqlCommand("select Format(ReservationDate,'MMMM ,yyyy','tr-tr') as Tarih,sum(GuestCount) ToplamKisi from Reservations group by ReservationDate").ToString().Select(x => new ReservationsChart
            //{
            //    rezervationDate = x.ToString(),
            //    count = Convert.ToInt32(x[1])
            //}).ToList();
            return null;
        }
    }
}