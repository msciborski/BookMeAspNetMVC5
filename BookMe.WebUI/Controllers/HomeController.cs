using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMe.Domain.Concrete.Repository.Interfaces;
using BookMe.WebUI.Models;

namespace BookMe.WebUI.Controllers {
    public class HomeController : Controller{
        private IRoomRepository _repository;

        public HomeController(IRoomRepository repository){
            _repository = repository;
        }
        
        // GET: Home
        public ActionResult Index(){
            return View();
        }

        public PartialViewResult Search(){
            string search = Request.QueryString["search"] ?? "";
            string startDate = Request.QueryString["startDate"] ?? "";
            string endDate = Request.QueryString["endDate"] ?? "";
            string adults = Request.QueryString["adultsInRoom"] ?? "2";
            string kids = Request.QueryString["kidsInRoom"] ?? "0";

            SearchViewModel viewModel = new SearchViewModel() {
                MaxKidCapacity = _repository.BigestKidCapacity().ToString(),
                MaxAdultCapacity = _repository.BigestAdultCapacity().ToString(),
                MinAdultCapacity = _repository.LeastAdultCapacity().ToString(),
                MinKidCapacity = _repository.LeastKidCapacity().ToString(),
                Search = search,
                ArrivalDate = startDate,
                DepartureDate = endDate,
                Adults = adults,
                Kids = kids
            };
            return PartialView(viewModel);
        }
    }
}