using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBurgerMenu.Entities
{
    public class ContactUs
    {
        public int ContactUsId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}