using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
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
            SendEmail(mail.ToString());
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

        [HttpPost]
        public ActionResult SendEmail(string mail)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("rose15@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("rose15@ethereal.email"));
            email.Subject = "TasteFoodit Haber Bülteni";
            email.Body = new TextPart(TextFormat.Html) { Text = mail+ " TasteFoodit haber aboneliğiniz başarıyla gerçekleşmiştir." };
             var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("rose15@ethereal.email", "qgp344smXN6q3xdU9C");
            smtp.Send(email);
            smtp.Disconnect(true);

            return View();
        }
    }
}