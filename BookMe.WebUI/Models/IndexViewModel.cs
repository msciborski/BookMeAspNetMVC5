using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMe.WebUI.Models {
    public class IndexViewModel {
        public int MaxAdultCapacity { get; set; }
        public int MaxKidCapacity { get; set; }
        public int MinAdultCapacity { get; set; }
        public int MinKidCapacity { get; set; }
    }
}