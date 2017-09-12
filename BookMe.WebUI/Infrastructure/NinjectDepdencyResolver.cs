using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace BookMe.WebUI.Infrastructure {
    public class NinjectDepdencyResolver : IDependencyResolver{
        private IKernel kernel;

        public NinjectDepdencyResolver(IKernel kernel){
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType){
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType){
            return kernel.GetAll(serviceType);
        }

        private void AddBindings(){
            
        }
    }
}