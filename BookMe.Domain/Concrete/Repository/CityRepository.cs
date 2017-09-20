using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMe.Domain.Concrete.Repository.Interfaces;
using BookMe.Domain.Entities;

namespace BookMe.Domain.Concrete.Repository {
    public class CityRepository : Repository<City>, ICityRepository{
        public CityRepository(DbContext dbContext) : base(dbContext){
        }

        public IDictionary<City, int> MostPopularCities(){
            Dictionary<City, int> cityCount =
                DbContext.Set<Hotel>()
                    .Include(h => h.City)
                    .GroupBy(h => h.City)
                    .OrderBy(c => c.Key.CityID)
                    .Take(6)
                    .ToDictionary(d => d.Key, d => d.Count());
            return cityCount;
        }
    }
}
