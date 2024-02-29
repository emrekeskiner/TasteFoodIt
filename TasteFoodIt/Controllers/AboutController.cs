using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AboutController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: About

        [HttpGet]
        public ActionResult AboutList()
        {
            var value = context.Abouts.FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public ActionResult AboutList(About abouts)
        {
            var value = context.Abouts.Find(abouts.AboutId);
            value.Title = abouts.Title;
            value.ImageUrl = abouts.ImageUrl;
            value.Description = abouts.Description;
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}