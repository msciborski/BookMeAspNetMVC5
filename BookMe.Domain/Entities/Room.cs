using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMe.Domain.Entities {
    public enum RoomType {
        PokójPracowniczy, Pokój, Dom, Apartament
    }
    public class Room {
        public int RoomID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public RoomType? RoomType { get; set; }
        public DateTime AddDate { get; set; }

        public int HotelID { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
