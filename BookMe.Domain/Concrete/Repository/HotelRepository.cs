using System;
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

        public IEnumerable<Hotel> GetHotelsFilteredBySearch(string search) {
            return DbSet.Where(h => search == null || h.Name.Contains(search) || h.City.Name.Contains(search))
                        .OrderByDescending(h => h.HotelID).AsEnumerable();
        }

        public IEnumerable<Hotel> GetHotelsFilteredBySearchCapacity(string search, int? adults, int? kids){
            if (adults == null && kids == null){
                return GetHotelsFilteredBySearch(search);
            }else if (adults != null && kids != null){
                return
                    GetHotelsFilteredBySearch(search).AsQueryable()
                        .Where(h => h.Rooms.Any(r => r.Capacity == adults && r.KidsCapacity == kids));
            }else if (adults != null){
                return GetHotelsFilteredBySearch(search).AsQueryable().Where(h => h.Rooms.Any(r => r.Capacity == adults));
            }
            else{
                return GetHotelsFilteredBySearch(search).AsQueryable().Where(h => h.Rooms.Any(r => r.KidsCapacity == kids));
            }
        }

        public IEnumerable<Hotel> GetHotelsFilteredBySearchCapacity(string search, int? adults, int? kids, int page,
            int pageSize){
            return GetHotelsFilteredBySearchCapacity(search, adults, kids).Skip((page - 1)*pageSize).Take(pageSize);
        }

        public IEnumerable<Hotel> GetHotelsFilteredBySearch(string search, int page, int pageSize) {
            return GetHotelsFilteredBySearch(search).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Hotel> GetHotelsFilteredBySearchDates(string search, DateTime startDate, DateTime endDate){
            DateTime endOfTheYear = new DateTime(DateTime.Today.Year,12,31);
            return DbSet.Where(h => search == null || h.Name.Contains(search) || h.City.Name.Contains(search))
            .Where(h => h.Rooms.Any(r => r.Reservations.All(t => TestableDbFunctions.DiffDays(t.EndDate, endOfTheYear) > TestableDbFunctions.DiffDays(startDate, endOfTheYear) || 
                                                                        TestableDbFunctions.DiffDays(t.StartDate, endOfTheYear) < TestableDbFunctions.DiffDays(endDate, endOfTheYear))));
        }

        public IEnumerable<Hotel> GetHotelsFilteredBySearchDates(string search, DateTime startDate, DateTime endDate, int page, int pageSize){
            return GetHotelsFilteredBySearchDates(search, startDate, endDate).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Hotel> GetHotelsFilteredBySearchDatesCapacity(string search, DateTime? startDate,
            DateTime? endDate, int? adults, int? kids){
            DateTime endOfTheYear = new DateTime(DateTime.Today.Year, 12, 31);
            return DbSet.Where(h => search == null || h.Name.Contains(search) || h.City.Name.Contains(search))
                .Where(h => (startDate == null || endDate == null) ||
                            h.Rooms.Any(r => r.Reservations.All(
                                t =>
                                    TestableDbFunctions.DiffDays(t.EndDate, endOfTheYear) >
                                    TestableDbFunctions.DiffDays(startDate, endOfTheYear) ||
                                    TestableDbFunctions.DiffDays(t.StartDate, endOfTheYear) <
                                    TestableDbFunctions.DiffDays(endDate, endOfTheYear))))
                .Where(h => adults == null || h.Rooms.Any(r => r.Capacity == (int) adults))
                .Where(h => kids  == null || (int)kids == 0 || h.Rooms.Any(r => r.KidsCapacity == (int)kids));
        }

        public IEnumerable<Hotel> GetHotelsFilteredBySearchDatesCapacity(string search, DateTime? startDate,
            DateTime? endDate, int? adults, int? kids, int page, int pageSize){
            return GetHotelsFilteredBySearchDatesCapacity(search, startDate, endDate, adults,kids).Skip((page - 1) * pageSize).Take(pageSize);
        }

    }
}
