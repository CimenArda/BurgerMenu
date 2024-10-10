using ProjectBurgerMenu.Context;
using ProjectBurgerMenu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBurgerMenu.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Admin/Product
        BurgerMenuContext context =new BurgerMenuContext();
        public ActionResult Index()
        {
            var values = context.Products.ToList();
            return View(values);
        }

        public ActionResult CreateProduct()
        {
            List<SelectListItem> v = (from i in context.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryId.ToString()
                                             }).ToList();
            ViewBag.v = v;
            return View();
        }


        [HttpPost]
        public ActionResult CreateProduct(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();


            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var values = context.Products.Find(id);

            context.Products.Remove(values);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UpdateProduct(int id)
        {
            var values = context.Products.Find(id);
            List<SelectListItem> v = (from i in context.Categories.ToList()
                                      select new SelectListItem
                                      {
                                          Text = i.CategoryName,
                                          Value = i.CategoryId.ToString()
                                      }).ToList();
            ViewBag.v = v;
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product p)
        {
            var values = context.Products.Find(p.ProductId);
           
            values.ProductName = p.ProductName;
            values.ImageUrl = p.ImageUrl;
            values.Price = p.Price;
            values.Description = p.Description;
            values.CategoryId = p.CategoryId;

            context.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}
