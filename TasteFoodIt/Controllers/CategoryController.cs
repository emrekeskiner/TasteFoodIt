using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class CategoryController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Category
        public ActionResult CategoryList()
        {
            var category = context.Categories.ToList();
            return View(category);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult DeleteCategory(int id)
        {
            var category = context.Categories.Find(id);
            var urun = context.Products.Where(x => x.CategoryId == id).Count();
            if (urun > 0)
            {
                ViewBag.productCount = "Kategori silmek içi öncelikle ürünleri silmelisiniz";
                return RedirectToAction("CategoryList");
            }
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var category = context.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var value = context.Categories.Find(category.CategoryId);
            value.CategoryName = category.CategoryName;
            context.SaveChanges();

            return RedirectToAction("CategoryList");
        }
    }
}