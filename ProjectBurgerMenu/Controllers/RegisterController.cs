﻿using ProjectBurgerMenu.Context;
using ProjectBurgerMenu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBurgerMenu.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        BurgerMenuContext context = new BurgerMenuContext();
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            context.Admins.Add(admin);
            context.SaveChanges();
            return RedirectToAction("Index","Login");
        }
    }
}