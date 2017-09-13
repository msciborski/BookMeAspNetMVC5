using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMe.Domain.Concrete.Repository.Interfaces;
using BookMe.Domain.Entities;

namespace BookMe.Domain.Concrete.Repository {
    public class HotelRepository : Repository<Hotel>, IHotelRepository{
        public HotelRepository(DbContext dbContext) : base(dbContext){
        }
    }
}
