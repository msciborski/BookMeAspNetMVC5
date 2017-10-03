using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMe.Domain.Entities;

namespace BookMe.WebUI.Models {
    public class HotelListViewModel {
        public IEnumerable<Hotel> Hotels { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public String SearchParameter { get; set; }
        public DateTime? ChoosenArrival { get; set; }
        public DateTime? ChoosenDeparture { get; set; }

    }
}