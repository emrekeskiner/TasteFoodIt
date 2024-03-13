using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class ProductController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Product
        [Authorize]
        public ActionResult ProductList()
        {
            var value = context.Products.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            List<SelectListItem> category = (from i in context.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryId.ToString()
                                             }).ToList();
            category.Add(new SelectListItem { Text = "SEÇİNİZ", Value = "0", Selected=true });
            ViewBag.category = category;
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            
            product.IsActive = true;
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public ActionResult DeleteProduct(int id)
        {
            var value = context.Products.Find(id);
            context.Products.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var value = context.Products.Find(id);
            List<SelectListItem> category = (from i in context.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryId.ToString()
                                             }).ToList();
            ViewBag.category = category;

            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            var value = context.Products.Find(product.ProductId);
            
            value.CategoryId = product.CategoryId;
            value.ProductName = product.ProductName;
            value.Description = product.Description;
            value.Price = product.Price;
            value.ImageUrl = product.ImageUrl;
            value.IsActive = product.IsActive;
            context.SaveChanges();

            return RedirectToAction("ProductList");
        }

        public ActionResult StatusChangeProduct(int id)
        {
            var value = context.Products.Find(id);
            if (value.IsActive == true)
            {
                value.IsActive = false;
            }
            else
            {
                value.IsActive = true;
            }
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public ActionResult Products(int id)
        {
            var value = context.Products.Where(x=>x.CategoryId==id).ToList();
            return View(value);
        }

    }
}