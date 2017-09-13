using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMe.Domain.Concrete.Repository.Interfaces;
using BookMe.Domain.Entities;
using BookMe.WebUI.Models;
using Ninject.Infrastructure.Language;

namespace BookMe.WebUI.Controllers {
    public class HotelController : Controller{
        private IUnitOfWork _unitOfWork;
        public int PageSize { get; set; }
        public HotelController(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
            PageSize = 3;
        }

        public ViewResult List(int page = 1){
            IEnumerable<Hotel> hotelsList =
                _unitOfWork.Hotels.GetAll()
                    .OrderByDescending(h => h.HotelID)
                    .Skip((page - 1)*PageSize)
                    .Take(PageSize)
                    .ToEnumerable();

            HotelListViewModel hotels = new HotelListViewModel() {
                Hotels = hotelsList,
                PagingInfo = new PagingInfo() {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _unitOfWork.Hotels.GetAll().Count()
                }
            };
            return View(hotels);
        }
    }
}