using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Entities;
using TasteFoodIt.Context;
using System.Web.Security;

namespace TasteFoodIt.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var values = context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if(values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Username, true);
                Session["Username"] = values.Username;
                Session["adminId"] = values.AdminId;
                Session["nameSurname"] = values.NameSurname;
                Session["imageUrl"] = values.ImageUrl;
                return RedirectToAction("ProfileDetail", "Profile");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}