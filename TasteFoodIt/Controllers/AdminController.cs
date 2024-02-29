using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Admin
        public ActionResult AdminList()
        {
            var value = context.Admins.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAdmin(Admin admin)
        {
            context.Admins.Add(admin);
            context.SaveChanges();
            return RedirectToAction("AdminList");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var value = context.Admins.Find(id);
            context.Admins.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AdminList");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var value = context.Admins.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin Admin)
        {
            var value = context.Admins.Find(Admin.AdminId);
            value.Username = Admin.Username;
            context.SaveChanges();

            return RedirectToAction("AdminList");
        }
    }
}