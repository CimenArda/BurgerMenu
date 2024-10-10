﻿using ProjectBurgerMenu.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBurgerMenu.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        BurgerMenuContext context = new BurgerMenuContext();
        public ActionResult Index()
        {
            var values =context.Categories.ToList();
            return View(values);
        }
    }
}