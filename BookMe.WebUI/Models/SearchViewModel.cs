using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMe.WebUI.Models {
    public class SearchViewModel {
        public string MaxAdultCapacity { get; set; }
        public string MaxKidCapacity { get; set; }
        public string MinAdultCapacity { get; set; }
        public string MinKidCapacity { get; set; }
        public string Search { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureDate { get; set; }
        public string Adults { get; set; }
        public string Kids { get; set; }

    }
}