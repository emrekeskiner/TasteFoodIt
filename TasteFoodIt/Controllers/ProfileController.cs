using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Entities;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class ProfileController : Controller
    {
        TasteContext context = new TasteContext();

        [HttpGet]
        public ActionResult ProfileDetail()
        {
            
            string adminId = Session["adminId"].ToString();
            var values = context.Admins.Find(int.Parse(adminId));
            ViewBag.userName = Session["Username"];
            return View(values);
        }

        [HttpPost]
        public ActionResult ProfileDetail(Admin admin)
        {
            string adminId = Session["adminId"].ToString();
            var values = context.Admins.Find(int.Parse(adminId));
            values.NameSurname = admin.NameSurname;
            values.ImageUrl = admin.ImageUrl;
            values.Password = admin.Password;
            return RedirectToAction("ProfileDetail");
        }
    }
}