using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BookMe.Domain.Concrete.Repository.Interfaces;
using BookMe.Domain.Entities;
using BookMe.WebUI.Models;
using Newtonsoft.Json;

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

        public PartialViewResult LatestRooms(){
            var rooms = _repository.LatestRooms();
            return PartialView(rooms);
        }

        public ActionResult SelectedRoom(int id){
            Room room = _repository.GetRoomWithPhotos(id);
            if (room != null){
                SelectedRoomJsonViewModel viewModel = new SelectedRoomJsonViewModel(){
                    RoomID = room.RoomID,
                    Name = room.Name,
                    Price = room.Price,
                    AdultsCapacity = room.Capacity,
                    KidsCapacity = room.KidsCapacity,
                    PhotoIds = room.Photos.Select(p => new PhotoViewModel(){PhotoID = p.PhotoID, IsPrimaryPhoto = p.IsPrimaryPhoto}).OrderByDescending(p => p.IsPrimaryPhoto).ToArray()
                };
                string jsonResult = JsonConvert.SerializeObject(viewModel);
                return Content(jsonResult,"application/json");
            }
            else{
                return HttpNotFound("Nie ma takiego pokoju");
            }
        }

    }
}