using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AddressController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: About

        [HttpGet]
        public ActionResult AddressList()
        {
            var value = context.Addresses.FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public ActionResult AddressList(Address address)
        {
            var value = context.Addresses.Find(address.AddressId);
            value.Email = address.Email;
            value.Phone = address.Phone;
            value.WebSite = address.WebSite;
            value.Locale = address.Locale;
            value.Description = address.Description;
            context.SaveChanges();
            return RedirectToAction("AddressList");
        }
    }
}