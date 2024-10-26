using ProjectBurgerMenu.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBurgerMenu.Areas.Admin.Controllers
{
    public class ContactUsController : Controller
    {
        // GET: Admin/ContantUs
        BurgerMenuContext context = new BurgerMenuContext();
        public ActionResult Index()
        {
            var values =context.ContactUss.ToList();
            return View(values);
        }
        [HttpGet]
        public JsonResult GetMessageDetails(int id)
        {
            var contact = context.ContactUss.FirstOrDefault(c => c.ContactUsId == id);

            if (contact == null)
            {
                // Mesaj bulunamazsa JSON ile hata mesajı döndür
                return Json(new { success = false, message = "Mesaj bulunamadı." }, JsonRequestBehavior.AllowGet);
            }

            // ContactUs detaylarını JSON formatında döndür
            var contactDetails = new
            {
                Name = contact.Name,
                Email = contact.Email,
                Subject = contact.Subject,
                Content = contact.Content
            };

            return Json(new { success = true, data = contactDetails }, JsonRequestBehavior.AllowGet);
        }
    }
}