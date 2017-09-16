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
        public IEnumerable<Hotel> MostPopularHotels(){
            return DbSet.OrderByDescending(h => h.AddDate).Take(6);
        }
    }
}
