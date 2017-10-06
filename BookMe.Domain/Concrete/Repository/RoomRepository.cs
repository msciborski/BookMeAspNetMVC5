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
            return DbSet.Include(r => r.Hotel).Include(r => r.Hotel.City).Include(r => r.Photos).OrderByDescending(r => r.AddDate).Take(6);
        }
        public int BigestAdultCapacity(){
            Room room = DbSet.OrderByDescending(r => r.Capacity).FirstOrDefault();
            if (room != null){
                return room.Capacity;
            }
            return 5;
        }
        public int BigestKidCapacity(){
            Room room = DbSet.OrderByDescending(r => r.KidsCapacity).FirstOrDefault();
            if (room != null){
                return room.KidsCapacity;
            }
            return 5;
        }

        public int LeastAdultCapacity(){
            Room room = DbSet.OrderBy(h => h.Capacity).FirstOrDefault();
            if (room != null){
                return room.Capacity;
            }
            return 1;
        }

        public int LeastKidCapacity(){
            Room room = DbSet.OrderBy(h => h.KidsCapacity).FirstOrDefault();
            if (room != null){
                return room.KidsCapacity;
            }
            return 0;
        }
    }
}
