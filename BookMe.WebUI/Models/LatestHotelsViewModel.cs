using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookMe.Domain.Entities;

namespace BookMe.WebUI.Models {
    public class LatestHotelsViewModel {
        public Hotel Hotel { get; set; }
        public HttpPostedFileBase Image { get; set; }
    }
}