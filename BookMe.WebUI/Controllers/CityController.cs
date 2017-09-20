using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMe.Domain.Concrete.Repository.Interfaces;
using BookMe.Domain.Entities;
using BookMe.WebUI.Models;

namespace BookMe.WebUI.Controllers
{
    public class CityController : Controller{
        private ICityRepository _repository;

        public CityController(ICityRepository repository){
            _repository = repository;
        }

        public PartialViewResult MostPopularCities(){
            IDictionary<City, int> mostPopularCities = _repository.MostPopularCities();
            List<CityViewModel> cities = new List<CityViewModel>();
            foreach (var mostPopularCity in mostPopularCities){
                cities.Add(new CityViewModel(){
                    City = mostPopularCity.Key,
                    Count = mostPopularCity.Value
                });
            }
            return PartialView(cities);
        }
    }
}