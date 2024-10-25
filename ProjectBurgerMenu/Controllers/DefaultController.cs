using ProjectBurgerMenu.Context;
using ProjectBurgerMenu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBurgerMenu.Controllers
{
    public class DefaultController : Controller
    {
        BurgerMenuContext context = new BurgerMenuContext();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialBanner()
        {
            var values = context.Banners.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAbout()
        {
            var values = context.AboutUss.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTodaysOffer()
        {
            var values = context.Products.Where(x=>x.DealOfTheDay==true).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialMenu()
        {
            var values = context.Products.ToList();
            return PartialView(values);
        }
		public PartialViewResult PartialMenuCategory()
		{
            var values = context.Categories.ToList();
			return PartialView(values);
		}
        public ActionResult GetProductsByCategory(int categoryId)
        {
            var products = context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToList();

            return PartialView("_ProductList", products);
        }
        public PartialViewResult _ProductList()
        {
            return PartialView();
        }

        public PartialViewResult PartialGallery()
        {
            var values = context.Galleries.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult PartialContact(ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                context.ContactUss.Add(contactUs);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return PartialView();
        }


        public PartialViewResult PartialContactAddress()
        {
            var values = context.Addresses.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialFooter()
        {
            var about = context.AboutUss.Select(x => x.Description.Substring(0, 275)).FirstOrDefault();
            ViewBag.about =about;
            return PartialView();
        }
        public ActionResult Subscribe(Subscribe subscribe)
        {
            if (subscribe == null)
            {
                // Null değer kontrolü yap ve bir alert mesajı oluştur
                TempData["SubscribeError"] = "Lütfen geçerli bir bilgi girin.";
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                context.Subscribes.Add(subscribe);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Page404", "ErrorPage");
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        [HttpGet]
		public PartialViewResult PartialReservation()
		{
			
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult PartialReservation(Reservation reservation)
		{
            reservation.ReservationStatus = "Onay Bekleniyor";
            context.Reservations.Add(reservation);
            context.SaveChanges();
			return PartialView();
		}
	}
}