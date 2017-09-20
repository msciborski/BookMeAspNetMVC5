using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMe.Domain.Entities;

namespace BookMe.WebUI.Models {
    public class CityViewModel {
        public City City { get; set; }
        public int Count { get; set; }
    }
}