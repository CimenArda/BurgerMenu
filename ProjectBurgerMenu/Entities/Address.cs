using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBurgerMenu.Entities
{
    public class Address
    {
        public int AddressId { get; set; }

        public string Location { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}