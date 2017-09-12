using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMe.Domain.Entities;

namespace BookMe.Domain.Concrete {
    public class BookMeContext : DbContext {

        public BookMeContext() : base("BookMeDb") { }

        public DbSet<City> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
