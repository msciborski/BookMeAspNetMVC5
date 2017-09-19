using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMe.Domain.Concrete.Repository.Interfaces;
using BookMe.Domain.Entities;

namespace BookMe.Domain.Concrete.Repository {
    public class RoomRepository : Repository<Room>, IRoomRepository{
        public RoomRepository(DbContext dbContext) : base(dbContext){
        }

        public IEnumerable<Room> LatestRooms(){
            return DbSet.Include(r => r.Hotel).Include(r => r.Hotel.City).OrderByDescending(r => r.AddDate).Take(6);

        }
    }
}
