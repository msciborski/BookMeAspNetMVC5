using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMe.Domain.Entities;

namespace BookMe.Domain.Concrete.Repository.Interfaces {
    public interface IHotelRepository : IRepository<Hotel>{
        IEnumerable<Hotel> LatestHotels();
        IEnumerable<Hotel> GetHotelsFilteredBySearch(string search = null);
        IEnumerable<Hotel> GetHotelsFilteredBySearch(string search, int page, int pageSize);
        IEnumerable<Hotel> GetHotelsFilteredBySearchDates(string search, DateTime startDate, DateTime endDate);
        IEnumerable<Hotel> GetHotelsFilteredBySearchDates(string search, DateTime startDate, DateTime endDate, int page, int pageSize);

        IEnumerable<Hotel> GetHotelsFilteredBySearchDatesAdultsKidsInRoom(string search, DateTime? startDate,
            DateTime? endDate, int? adults, int kids);
        IEnumerable<Hotel> GetHotelsFilteredBySearchDatesAdultsKidsInRoom(string search, DateTime? startDate,
    DateTime? endDate, int? adults, int kids, int page, int pageSize);

    }
}
