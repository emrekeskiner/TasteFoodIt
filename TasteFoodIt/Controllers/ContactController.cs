using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class ContactController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Contact
        public ActionResult MessageList()
        {
           
            var values = context.Contacts.ToList();

            return View(values);
        }
        [HttpGet]
        public ActionResult ReadMessage(int id)
        {
            var values = context.Contacts.Find(id);
            values.Status = true;
            context.SaveChanges();
            return View(values);
        }
    }
}