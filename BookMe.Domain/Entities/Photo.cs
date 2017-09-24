using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMe.Domain.Entities {
    public class Photo {
        public int PhotoID { get; set; }
        public int? RoomID { get; set; }
        public int? HotelID { get; set; }
        public int? CityID { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        public virtual Room Room { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual City City { get; set; }
    }
}
