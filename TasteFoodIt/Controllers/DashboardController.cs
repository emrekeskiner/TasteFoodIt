using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

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
            ViewBag.reservationCount = context.Reservations.Where(x => x.ReservationStatus == "Aktif").Count();
            return View();
        }
    }
}