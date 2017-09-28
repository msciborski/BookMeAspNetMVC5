using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMe.Domain.Concrete.Repository.Interfaces;
using BookMe.Domain.Entities;

namespace BookMe.Domain.Concrete.Repository {
    public class HotelRepository : Repository<Hotel>, IHotelRepository{
        public HotelRepository(DbContext dbContext) : base(dbContext){
        }
        /// <summary>
        /// Method which return top 6 the newest hotels
        /// </summary>
        /// <returns>IEnumerable with Hotels</returns>
        public IEnumerable<Hotel> LatestHotels(){
            return DbSet.Include(h => h.City).Include(h => h.Photos).OrderByDescending(h => h.AddDate).Take(6);
        }

        public IEnumerable<Hotel> GetHotelsByNameOrCityName(string name){
            return DbSet.Where(h => h.Name.Contains(name) || h.City.Name.Contains(name))
                        .OrderByDescending(h => h.HotelID).AsEnumerable();
        }
    }
}
