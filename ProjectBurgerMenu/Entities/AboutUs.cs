﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBurgerMenu.Entities
{
    public class AboutUs
    {
        public int AboutUsId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}