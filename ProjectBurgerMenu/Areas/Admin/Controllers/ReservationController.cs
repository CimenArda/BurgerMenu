using ProjectBurgerMenu.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBurgerMenu.Areas.Admin.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Admin/Reservation
        BurgerMenuContext context = new BurgerMenuContext();

        public ActionResult Index()
        {
            var values = context.Reservations.ToList();
            return View(values);
        }

        public ActionResult HoldReservation(int id)
        {
            var reservation = context.Reservations.FirstOrDefault(m => m.ReservationId == id);

            reservation.ReservationStatus = "Onay Bekleniyor";
            context.SaveChanges();
            return RedirectToAction("Index", "Reservation", new { areas = "Admin" });
        }

        public ActionResult ConfirmReservation(int id)
        {
            var reservation = context.Reservations.FirstOrDefault(m => m.ReservationId == id);

            reservation.ReservationStatus = "Rezervasyon Onaylandı";
            context.SaveChanges();
            return RedirectToAction("Index", "Reservation", new { areas = "Admin" });
        }

        public ActionResult CancelReservation(int id)
        {
            var reservation = context.Reservations.FirstOrDefault(m => m.ReservationId == id);

            reservation.ReservationStatus = "Rezervasyon İptal Edildi";
            context.SaveChanges();
            return RedirectToAction("Index", "Reservation", new { areas = "Admin" });
        }

        public ActionResult CompletedSuccessfullyReservation(int id)
        {
            var reservation = context.Reservations.FirstOrDefault(m => m.ReservationId == id);

            reservation.ReservationStatus = "Rezervasyon Tamamlandı";
            context.SaveChanges();
            return RedirectToAction("Index", "Reservation", new { areas = "Admin" });
        }
    }
}