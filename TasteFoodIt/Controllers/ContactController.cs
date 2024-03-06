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

        [HttpPost]
        public JsonResult AddMailList(Mail mail)
        {
            System.Threading.Thread.Sleep(500);//AZ BEKLE
            mail.Status = true;
            context.Mails.Add(mail);
            context.SaveChanges();

            return Json("başarılı", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateContact(Contact contact)
        {
            System.Threading.Thread.Sleep(500);//AZ BEKLE
            contact.SendDate = DateTime.Now;
            contact.Status = false;
            context.Contacts.Add(contact);
            context.SaveChanges();

            return Json("başarılı", JsonRequestBehavior.AllowGet);
        }

    }
}