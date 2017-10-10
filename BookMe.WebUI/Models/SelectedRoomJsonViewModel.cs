using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMe.WebUI.Models {
    public class SelectedRoomJsonViewModel {
        public int RoomID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AdultsCapacity { get; set; }
        public int KidsCapacity { get; set; }
        public PhotoViewModel[] PhotoIds { get; set; }
    }
}