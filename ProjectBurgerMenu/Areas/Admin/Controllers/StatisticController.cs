using ProjectBurgerMenu.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBurgerMenu.Areas.Admin.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Admin/Statistic
        BurgerMenuContext _context =new BurgerMenuContext();
        public ActionResult Index()
        {

            //Acil Mesajlar ve Gönderilen mesaj sayısı içindir
            var userName = Session["x"].ToString();
            var user = _context.Admins.FirstOrDefault(u => u.UserName == userName);

            string mail = user.Email;


            // Admin sayısı
            ViewBag.AdminCount = _context.Admins.Count();

            // Ürün sayısı
            ViewBag.ProductCount = _context.Products.Count();

            // Eklenen son ürün
            ViewBag.LastAddedProduct = _context.Products.OrderByDescending(p => p.ProductId).Select(x=>x.ProductName).FirstOrDefault();

            // Kategori sayısı
            ViewBag.CategoryCount = _context.Categories.Count();

            // Rezervasyon sayısı
            ViewBag.ReservationCount = _context.Reservations.Count();

            // İptal edilen rezervasyon sayısı
            ViewBag.CancelledReservationCount = _context.Reservations.Count(r => r.ReservationStatus == "Rezervasyon İptal Edildi");

            // Tamamlanan rezervasyon sayısı
            ViewBag.CompletedReservationCount = _context.Reservations.Count(r => r.ReservationStatus == "Rezervasyon Tamamlandı");

            // Okunmayan acil mesaj sayısı
            ViewBag.UnreadEmergencyMessageCount = _context.Messages.Count(m => m.ReceiverEmail == mail && m.Title == "Acil" && m.IsRead == false);

            // Abone olan kişi sayısı
            ViewBag.SubscriberCount = _context.Subscribes.Count();

            // Abone olan son kişinin emaili
            ViewBag.LastSubscriberEmail = _context.Subscribes.OrderByDescending(s => s.SubscribeId).Select(s => s.Email).FirstOrDefault();

            // ContactUs gelen mesaj sayısı
            ViewBag.ContactUsMessageCount = _context.ContactUss.Count();

            //Oturum açan kullanıcının Gönderiilen mesaj sayıısı
            ViewBag.SentMessageCount = _context.Messages.Count(m => m.SenderEmail == mail);




            return View();
        }
    }
}