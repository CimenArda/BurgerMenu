using ProjectBurgerMenu.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectBurgerMenu.Context
{
    public class BurgerMenuContext :DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<DealOfTheDay> DealOfTheDays { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<AboutUs> AboutUss { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<ContactUs> ContactUss { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }


    }
}