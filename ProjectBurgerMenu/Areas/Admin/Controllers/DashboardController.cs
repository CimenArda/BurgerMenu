using ProjectBurgerMenu.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBurgerMenu.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        BurgerMenuContext context = new BurgerMenuContext();

        public ActionResult Index()
        {
            //Acil Mesajlar ve Gönderilen mesaj sayısı içindir
            var userName = Session["x"].ToString();
            var user = context.Admins.FirstOrDefault(u => u.UserName == userName);

            string mail = user.Email;
            ViewBag.UserName = user.UserName;
            ViewBag.UnreadEmergencyMessageCount = context.Messages.Count(m => m.ReceiverEmail == mail && m.Title == "Acil" && m.IsRead == false);

            var values = context.Products.ToList();
            return View(values);
        }

        public PartialViewResult PartialCategory()
        {
            var values = context.Categories.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialSubscriber()
        {
            var values = context.Subscribes.Take(5).OrderByDescending(x=>x.SubscribeId).ToList();
            return PartialView(values);
        }

    }
}