using ProjectBurgerMenu.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBurgerMenu.Areas.Admin.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Admin/Profile
        BurgerMenuContext context = new BurgerMenuContext();
        public ActionResult MyProfileList()
        {
            var userName = Session["x"];
            var values = context.Admins.Where(x => x.UserName == userName).FirstOrDefault();
            
            return View(values);
        }


        [HttpPost]
        public ActionResult MyProfileList(ProjectBurgerMenu.Entities.Admin admin)
        {
            var userName = Session["x"];
            var values = context.Admins.Where(x => x.UserName == userName).FirstOrDefault();

            values.UserName = admin.UserName;
            values.Name = admin.Name;
            values.Surname = admin.Surname;
            values.Email = admin.Email; 
            values.Password = admin.Password;

            context.SaveChanges();

            return RedirectToAction("Index", "Login");



        }


    }
}