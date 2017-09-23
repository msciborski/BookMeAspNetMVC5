using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMe.Domain.Concrete;
using BookMe.Domain.Concrete.Repository;
using BookMe.Domain.Concrete.Repository.Interfaces;
using Ninject;

namespace BookMe.WebUI.Infrastructure {
    public class NinjectDepdencyResolver : IDependencyResolver{
        private IKernel kernel;

        public NinjectDepdencyResolver(IKernel kernel){
            this.kernel = kernel;
            AddBindings();
        }

        private void AddBindings(){
            kernel.Bind<IHotelRepository>().To<HotelRepository>();
            kernel.Bind<IRoomRepository>().To<RoomRepository>();
            kernel.Bind<ICityRepository>().To<CityRepository>();
            kernel.Bind<DbContext>().To<BookMeContext>();
        }

        public object GetService(Type serviceType){
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType){
            return kernel.GetAll(serviceType);
        }
    }
}