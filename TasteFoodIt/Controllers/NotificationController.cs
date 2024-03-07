using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class NotificationController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Notification
        public ActionResult NotificationList()
        {
            var values = context.Notifications.ToList();
            return View(values);
        }

        public ActionResult StatusChangeNotification(int id)
        {
            var value = context.Notifications.Find(id);
            if (value.IsRead == true)
            {
                value.IsRead = false;
            }
            else
            {
                value.IsRead = true;
            }
            context.SaveChanges();
            return RedirectToAction("NotificationList");
        }
        [HttpGet]
        public ActionResult UpdateNotification(int id)
        {
            var values = context.Notifications.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateNotification(Notification notification)
        {
            var values = context.Notifications.Find(notification.NotificationId);
            values.IsRead = true;
            values.Description = notification.Description;
            values.Date = notification.Date;
            values.Icon = notification.Icon;
            values.IconCircleColor = notification.IconCircleColor;
            context.SaveChanges();
            return RedirectToAction("NotificationList");
        }

        public ActionResult DeleteNotification(int id)
        {
            var values = context.Notifications.Find(id);
            context.Notifications.Remove(values);
            context.SaveChanges();
            return RedirectToAction("NotificationList");
        }

        [HttpGet]
        public ActionResult CreateNotification()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNotification(Notification notification)
        {
            notification.IsRead = true;
            notification.Date = DateTime.Now;
            context.Notifications.Add(notification);
            context.SaveChanges();
            return RedirectToAction("NotificationList");
        }
    }
}