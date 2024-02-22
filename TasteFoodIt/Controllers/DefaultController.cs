using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Entities;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class DefaultController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbarInfo()
        {
            ViewBag.phone = context.Addresses.Select(x => x.Phone).FirstOrDefault();
            ViewBag.email = context.Addresses.Select(x => x.Email).FirstOrDefault();
            ViewBag.description = context.Addresses.Select(x => x.Description).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialSlider()
        {
            return PartialView();
        }

        public PartialViewResult PartialAbout()
        {
            ViewBag.title = context.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = context.Abouts.Select(x => x.Description).FirstOrDefault();
            ViewBag.image = context.Abouts.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialMenu()
        {
            var menu = context.Products.ToList();
            return PartialView(menu);
        }

        public PartialViewResult PartialTestimonial()
        {
            var testimonial = context.Testimonials.OrderByDescending(x => x.TestimonialId).Take(5).ToList();
            return PartialView(testimonial);
        }

        public PartialViewResult PartialChef()
        {
            var chef = context.Chefs.ToList();
            return PartialView(chef);
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialReservationNow()
        {
            return PartialView();
        }
    }
}