using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMe.Domain.Entities {
    public class Hotel {
        public int HotelID { get; set; }
        public int CityID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public DateTime AddDate { get; set; }


        public virtual City City { get; set; }
        public virtual IEnumerable<Room> Rooms { get; set; }
        public virtual IEnumerable<Photo> Photos { get; set; }
    }
}
