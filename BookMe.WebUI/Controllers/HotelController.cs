﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMe.Domain.Concrete.Repository.Interfaces;
using BookMe.Domain.Entities;
using BookMe.WebUI.Models;
using Ninject.Infrastructure.Language;

namespace BookMe.WebUI.Controllers {
    public class HotelController : Controller{
        private IHotelRepository _repository;
        public int PageSize { get; set; }
        public HotelController(IHotelRepository repository){
            _repository = repository;
            PageSize = 3;
        }

        public ViewResult List(int page = 1){
            IEnumerable<Hotel> hotelsList =
                _repository.GetAll()
                    .OrderByDescending(h => h.HotelID)
                    .Skip((page - 1)*PageSize)
                    .Take(PageSize)
                    .ToEnumerable();

            HotelListViewModel hotels = new HotelListViewModel() {
                Hotels = hotelsList,
                PagingInfo = new PagingInfo() {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.GetAll().Count()
                }
            };
            return View(hotels);
        }

        public PartialViewResult LatestHotels(){
            return PartialView(_repository.LatestHotels());
        }

        public ActionResult Hotel(int id){
            Hotel hotel = _repository.Get(id);
            if (hotel != null){
                return View(hotel);
            }
            else{
                return RedirectToAction("Index", "Home");
            }
        }
    }
}