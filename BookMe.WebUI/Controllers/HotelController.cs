using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMe.Domain.Concrete.Repository.Interfaces;
using BookMe.Domain.Entities;
using BookMe.WebUI.Filters;
using BookMe.WebUI.Models;
using Ninject.Infrastructure.Language;

namespace BookMe.WebUI.Controllers {
    public class HotelController : Controller {
        private IHotelRepository _repository;
        public int PageSize { get; set; }
        public HotelController(IHotelRepository repository) {
            _repository = repository;
            PageSize = 3;
        }

        public ViewResult List(string search = null, DateTime? startDate = null, DateTime? endDate = null, int? adultsInRoom = null, int kidsInRoom = 0, int page = 1){
            IEnumerable<Hotel> hotels = _repository.GetHotelsFilteredBySearchDatesAdultsKidsInRoom(
                                                        search, startDate, endDate, adultsInRoom, kidsInRoom, page, PageSize);
            HotelListViewModel hotelListViewModel = new HotelListViewModel(){
                Hotels = hotels,
                PagingInfo = new PagingInfo(){
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.GetHotelsFilteredBySearchDatesAdultsKidsInRoom(search, startDate, endDate, adultsInRoom, kidsInRoom).Count()
                },
                ChoosenArrival = startDate,
                ChoosenDeparture = endDate,
                KidsCapacity = kidsInRoom,
                AdultsCapacity = adultsInRoom
            };
            return View(hotelListViewModel);
        }
        public PartialViewResult LatestHotels() {
            return PartialView(_repository.LatestHotels());
        }

        public ActionResult Hotel(int id) {
            Hotel hotel = _repository.Get(id);
            if (hotel != null) {
                return View(hotel);
            } else {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}