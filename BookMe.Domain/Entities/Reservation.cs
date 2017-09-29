using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMe.Domain.Entities {
    public class Reservation {
        public int ReservationID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int RoomID { get; set; }
        public Room Room { get; set; }
    }
}
