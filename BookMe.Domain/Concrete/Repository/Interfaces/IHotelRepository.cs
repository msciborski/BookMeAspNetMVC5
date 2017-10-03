using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMe.Domain.Entities;

namespace BookMe.Domain.Concrete.Repository.Interfaces {
    public interface IHotelRepository : IRepository<Hotel>{
        IEnumerable<Hotel> LatestHotels();
        IEnumerable<Hotel> GetHotelsByNameOrCityName(string search = null);
        IEnumerable<Hotel> GetHotelsByNameOrCityName(string search, int page, int pageSize);
        IEnumerable<Hotel> GetHotelsByNameOrCityNameFreeAtDates(string search, DateTime startDate, DateTime endDate);
        IEnumerable<Hotel> GetHotelsByNameOrCityNameFreeAtDates(string search, DateTime startDate, DateTime endDate, int page, int pageSize);

    }
}
