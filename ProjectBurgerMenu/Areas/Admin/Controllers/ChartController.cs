using ProjectBurgerMenu.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBurgerMenu.Areas.Admin.Controllers
{
    public class ChartController : Controller
    {
        BurgerMenuContext context = new BurgerMenuContext();
        // GET: Admin/Chart
        public ActionResult CategoryChart()
        {
            var categoryData = context.Categories
                .Select(c => new { c.CategoryId, c.CategoryName })
                .ToList();
            return Json(categoryData, JsonRequestBehavior.AllowGet);
        }

        // Product Chart
        public ActionResult ProductChart()
        {
            var productData = context.Products
                .Select(p => new { p.ProductName, p.Price })
                .ToList();
            return Json(productData, JsonRequestBehavior.AllowGet);
        }

        // Reservation Chart
        public ActionResult ReservationChart()
        {
            var reservationData = context.Reservations
                .GroupBy(r => r.ReservationStatus)
                .Select(g => new {
                    Status = g.Key,
                    Count = g.Count()
                }).ToList();
            return Json(reservationData, JsonRequestBehavior.AllowGet);
        }

        // Admin Chart
        public ActionResult AdminChart()
        {
            var adminData = context.Admins
                .Select(a => new { a.AdminId, a.UserName })
                .ToList();
            return Json(adminData, JsonRequestBehavior.AllowGet);
        }

        // Tüm grafikleri göstereceğimiz sayfa
        public ActionResult Index()
        {
            return View();
        }

    }
}