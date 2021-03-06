﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMe.Domain.Entities;

namespace BookMe.Domain.Concrete {
    public class BookMeContext : DbContext {

        public BookMeContext() : base("BookMeDb"){
            Database.Log = s => System.Diagnostics.Debug.Write(s);
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder){
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
