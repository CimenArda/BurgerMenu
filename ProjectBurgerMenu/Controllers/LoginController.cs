using ProjectBurgerMenu.Context;
using ProjectBurgerMenu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectBurgerMenu.Controllers
{
    public class LoginController : Controller
    {
        BurgerMenuContext context = new BurgerMenuContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var values = context.Admins.FirstOrDefault(x=>x.UserName == admin.UserName && x.Password ==admin.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["x"] =values.UserName.ToString();
                return RedirectToAction("Index", "Product", "Admin");
            }
            else
            {
                return View();
            }
            
        }
    }
}