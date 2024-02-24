using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class DetailController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Detail
        public ActionResult Contact()
        {
            ViewBag.localAddress = context.Addresses.Select(x => x.LocalAddress).FirstOrDefault();
            ViewBag.phone = context.Addresses.Select(x => x.Phone).FirstOrDefault();
            ViewBag.email = context.Addresses.Select(x => x.Email).FirstOrDefault();
            ViewBag.webSite = context.Addresses.Select(x => x.WebSite).FirstOrDefault();

            return View();
        }

        public ActionResult Chef()
        {
            var chef = context.Chefs.ToList();
            return View(chef);
        }

        public ActionResult Menu()
        {
            var menu = context.Products.ToList();
            return View(menu);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Reservation()
        {
            return View();
        }
    }
}