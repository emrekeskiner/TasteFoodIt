using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class SliderController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult SliderList()
        {
            var values = context.Sliders.ToList();
            ViewBag.sliderCount = context.Sliders.Count(); 
            return View(values);
        }

        public ActionResult DeleteSlider(int id)
        {
            var values = context.Sliders.Find(id);
            context.Sliders.Remove(values);
            context.SaveChanges();
            return RedirectToAction("SliderList");
        }

        [HttpGet]
        public ActionResult UpdateSlider(int id)
        {
            var values = context.Sliders.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateSlider(Slider slider)
        {
            var values = context.Sliders.Find(slider.SliderId);
            values.Title = slider.Title;
            values.Slogan = slider.Slogan;
            values.Description = slider.Description;
            values.ImageUrl = slider.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("SliderList");
        }

        [HttpGet]
        public ActionResult CreateSlider()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult CreateSlider(Slider slider)
        {
            context.Sliders.Add(slider);
            context.SaveChanges();
            return RedirectToAction("SliderList");
        }

    }
}