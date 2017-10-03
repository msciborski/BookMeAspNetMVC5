﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMe.Domain.Entities {
    public class City {
        public int CityID { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
