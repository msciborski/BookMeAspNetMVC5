﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using BookMe.Domain.Concrete.Helpers;
using BookMe.Domain.Concrete.Repository.Interfaces;
using BookMe.Domain.Entities;

namespace BookMe.Domain.Concrete.Repository {
    public class HotelRepository : Repository<Hotel>, IHotelRepository {
        public HotelRepository(DbContext dbContext) : base(dbContext) {
        }
        /// <summary>
        /// Method which return top 6 the newest hotels
        /// </summary>
        /// <returns>IEnumerable with Hotels</returns>
        public IEnumerable<Hotel> LatestHotels() {
            return DbSet.Include(h => h.City).Include(h => h.Photos).OrderByDescending(h => h.AddDate).Take(6);
        }

        public IEnumerable<Hotel> GetHotelsByNameOrCityName(string search) {
            return DbSet.Where(h => search == null || h.Name.Contains(search) || h.City.Name.Contains(search))
                        .OrderByDescending(h => h.HotelID).AsEnumerable();
        }

        public IEnumerable<Hotel> GetHotelsByNameOrCityName(string search, int page, int pageSize) {
            return GetHotelsByNameOrCityName(search).Skip((page - 1) * pageSize).Take(pageSize);
        }

        //Nadal kurwa nie dziala, ja jebie
        public IEnumerable<Hotel> GetHotelsByNameOrCityNameFreeAtDates(string search, DateTime startDate, DateTime endDate){
            DateTime endOfTheYear = new DateTime(DateTime.Today.Year,12,31);
            //return DbSet.Where(h => search == null || h.Name.Contains(search) || h.City.Name.Contains(search))
            //    .Where(h => h.Rooms.Any(r => r.Reservations.All(t => t.EndDate < startDate || t.StartDate > endDate)));
            //return DbSet.Where(h => search == null || h.Name.Contains(search) || h.City.Name.Contains(search))
            //            .Where(h => h.Rooms.Any(r => r.Reservations.All(t => DbFunctions.DiffDays(t.EndDate,endOfTheYear) < DbFunctions.DiffDays(startDate,endOfTheYear) || DbFunctions.DiffDays(t.StartDate,endOfTheYear) < DbFunctions.DiffDays(endDate,endOfTheYear))));
            return DbSet.Where(h => search == null || h.Name.Contains(search) || h.City.Name.Contains(search))
            .Where(h => h.Rooms.Any(r => r.Reservations.All(t => TestableDbFunctions.DiffDays(t.EndDate, endOfTheYear) > TestableDbFunctions.DiffDays(startDate, endOfTheYear) || TestableDbFunctions.DiffDays(t.StartDate, endOfTheYear) < TestableDbFunctions.DiffDays(endDate, endOfTheYear))));
        }

        public IEnumerable<Hotel> GetHotelsByNameOrCityNameFreeAtDates(string search, DateTime startDate, DateTime endDate, int page, int pageSize){
            return GetHotelsByNameOrCityNameFreeAtDates(search, startDate, endDate).Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
