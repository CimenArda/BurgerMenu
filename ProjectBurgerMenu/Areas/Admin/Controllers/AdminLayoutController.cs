using ProjectBurgerMenu.Context;
using ProjectBurgerMenu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBurgerMenu.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
        BurgerMenuContext context = new BurgerMenuContext();
        // GET: Admin/AdminLayout
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

        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult PartialModalReservation()
        {

            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialModalReservation(Reservation reservation)
        {
            reservation.ReservationStatus = "Onay Bekleniyor";
            context.Reservations.Add(reservation);
            context.SaveChanges();
            return PartialView();
        }





        public PartialViewResult PartialScript()
        {
            return PartialView();
        }


    }
}