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
        public ActionResult Index() {
            IndexViewModel viewModel = new IndexViewModel(){
                MaxKidCapacity = _repository.BigestKidCapacity(),
                MaxAdultCapacity = _repository.BigestAdultCapacity(),
                MinAdultCapacity = _repository.LeastAdultCapacity(),
                MinKidCapacity = _repository.LeastKidCapacity()
            };
            return View(viewModel);
        }
    }
}