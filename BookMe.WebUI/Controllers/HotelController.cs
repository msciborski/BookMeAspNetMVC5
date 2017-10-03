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

        public ViewResult List(string search = null, DateTime? startDate = null, DateTime? endDate = null, int page = 1){
            IEnumerable<Hotel> hotels;
            if (startDate == null || endDate == null){
                hotels = _repository.GetHotelsByNameOrCityName(search, page, PageSize);
            }
            else{
                hotels = _repository.GetHotelsByNameOrCityNameFreeAtDates(search, (DateTime) startDate,
                    (DateTime) endDate, page, PageSize);
            }
            HotelListViewModel hotelViewModel = new HotelListViewModel(){
                Hotels = hotels,
                PagingInfo = new PagingInfo(){
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = startDate == null || endDate == null ? _repository.GetHotelsByNameOrCityName(search).Count() : 
                                                                _repository.GetHotelsByNameOrCityNameFreeAtDates(search,(DateTime)startDate, (DateTime) endDate).Count()
                },
                ChoosenArrival = startDate,
                ChoosenDeparture = endDate
                
            };
            return View(hotelViewModel);
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