using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMe.Domain.Concrete.Repository.Interfaces;

namespace BookMe.WebUI.Controllers
{
    public class PhotoController : Controller{
        private IPhotoRepository _repository;

        public PhotoController(IPhotoRepository repository){
            _repository = repository;
        }

        // GET: Photo
        public ActionResult Index(int id){
            var photo = _repository.Get(id);
            return File(photo.ImageData, photo.ImageMimeType);
        }
    }
}