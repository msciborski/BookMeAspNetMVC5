using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMe.Domain.Concrete.Repository.Interfaces;

namespace BookMe.Domain.Concrete.Repository {
    public class UnitOfWork : IUnitOfWork {
        private BookMeContext _dbContext { get; set; }

        public UnitOfWork(){
            _dbContext = new BookMeContext();
        }
        public void Commit(){
            _dbContext.SaveChanges();
        }

        public void Dispose(){
            _dbContext.Dispose();
        }

        public ICityRepository Cities => new CityRepository(_dbContext);
        public IHotelRepository Hotels => new HotelRepository(_dbContext);
        public IRoomRepository Rooms => new RoomRepository(_dbContext);
    }
}
