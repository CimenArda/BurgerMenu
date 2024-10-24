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
    public class MessageController : Controller
    {
        // GET: Admin/Message
        BurgerMenuContext context = new BurgerMenuContext();

        public ActionResult Inbox()
        {
            var userName = Session["x"];
            var email =context.Admins.Where(x=>x.UserName==userName).Select(x=>x.Email).FirstOrDefault();
            var values = context.Messages.Where(x=>x.ReceiverEmail==email).ToList();
            return View(values);
        }


        public ActionResult SendBox()
        {
            var userName = Session["x"];
            var email = context.Admins.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            var values = context.Messages.Where(x => x.SenderEmail == email).ToList();
            return View(values);
        }

        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetMessageDetails(int id)
        {
            var message = context.Messages.FirstOrDefault(m => m.MessageID == id);

            if (message == null)
            {
                // Eğer mesaj bulunamazsa 404 sayfasına yönlendir
                return Json(new { success = false, message = "Mesaj bulunamadı." }, JsonRequestBehavior.AllowGet);
            }

            // Mesaj detaylarını JSON olarak geri döndür
            var messageDetails = new
            {
                SenderEmail = message.SenderEmail,
                ReceiverEmail = message.ReceiverEmail,
                Title = message.Title,
                Content = message.Content,
                SendDate = message.SendDate.ToString("dd/MM/yyyy"),
                IsRead = message.IsRead
            };

            return Json(new { success = true, data = messageDetails }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult MarkAsRead(int id)
        {
            var message = context.Messages.FirstOrDefault(m => m.MessageID == id);

            if (message == null)
            {
                return Json(new { success = false, message = "Mesaj bulunamadı." }, JsonRequestBehavior.AllowGet);
            }

            // IsRead alanını true olarak ayarlıyoruz
            message.IsRead = true;
            context.SaveChanges();

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }





        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            message.IsRead = false;
            message.SendDate = DateTime.Now;
            var userName = Session["x"];
            var email = context.Admins.Where(x => x.UserName == userName).Select(x => x.Email).FirstOrDefault();
            message.SenderEmail = email;

            context.Messages.Add(message);
            context.SaveChanges();
            return RedirectToAction("SendBox", "Message", new { area = "Admin" });
        }
    }
}