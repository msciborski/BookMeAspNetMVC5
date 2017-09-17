using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMe.Domain.Concrete.Repository.Interfaces;

namespace BookMe.WebUI.Controllers {
    public class RoomController : Controller{
        private IRoomRepository _repository;

        public RoomController(IRoomRepository repository){
            _repository = repository;
        }

        public PartialViewResult RoomsForSelectedHotel(int id){
            var rooms = _repository.Find(r => r.HotelID == id).OrderBy(r => r.RoomID).AsEnumerable();
            return PartialView(rooms);
        }

    }
}