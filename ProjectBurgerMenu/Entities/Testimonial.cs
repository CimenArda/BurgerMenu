using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBurgerMenu.Entities
{
    public class Testimonial
    {
        public int TestimonialId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerComment { get; set; }

        public string ImageUrl { get; set; }

        public bool Status { get; set; }
    }
}