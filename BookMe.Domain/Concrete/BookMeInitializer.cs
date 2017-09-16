using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMe.Domain.Entities;

namespace BookMe.Domain.Concrete {
    public class BookMeInitializer : DropCreateDatabaseIfModelChanges<BookMeContext>{
        protected override void Seed(BookMeContext context){
            var cityList = new List<City>(){
                new City(){Name = "Poznań", ZipCode = "62-010"},
                new City(){Name = "Warszawa", ZipCode = "80-010"},
                new City(){Name = "Gdańsk", ZipCode = "70-010"}
            };
            cityList.ForEach(c => context.Cities.Add(c));
            context.SaveChanges();

            var hotelList = new List<Hotel>(){
                new Hotel() {Name = "Hotel Trójka", Address = "Dworcowa 25", CityID = 1, ContactNumber = "999888777", AddDate = DateTime.Parse("21.08.2016")},
                new Hotel() {Name = "Euro Hotel", Address = "Cegielskiego 32/24", CityID = 1, ContactNumber = "333444555", AddDate = DateTime.Parse("23.03.2016")},
                new Hotel() {Name = "Royal Hotel Poznań", Address = "Warszawska 24", CityID = 1, ContactNumber = "987456123", AddDate = DateTime.Parse("25.04.2016")},
                new Hotel() {Name = "Grand Palace", Address = "Marszałkowska 24", CityID = 2, ContactNumber = "345123345", AddDate = DateTime.Parse("03.08.2016")},
                new Hotel() {Name = "Novotel", Address = "Puławskiego 22", CityID = 2, ContactNumber = "983123456", AddDate = DateTime.Parse("04.08.2016")},
                new Hotel() {Name = "Diamond Hotel", Address = "Pszczelna 22", CityID = 2, ContactNumber = "123444555", AddDate = DateTime.Parse("20.10.2016")},
                new Hotel() {Name = "Hamilton", Address = "Gdyńska 33", CityID = 3, ContactNumber = "123456777", AddDate = DateTime.Parse("29.03.2017")}
            };
            hotelList.ForEach(h => context.Hotels.Add(h));
            context.SaveChanges();
            var roomList = new List<Room>(){
                new Room() {Name = "Pokój 3-osobowy", RoomType = RoomType.Pokój, Capacity = 3, Price = 45.5M, HotelID = 1},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 1},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Apartament, Capacity = 2, Price = 300.0M, HotelID = 1},
                new Room() {Name = "Pokój 3-osobowy", RoomType = RoomType.Pokój, Capacity = 3, Price = 43.0M, HotelID = 2},
                new Room() {Name = "Pokój 4-osobowy", RoomType = RoomType.Dom, Capacity = 4, Price = 400.0M, HotelID = 2},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 2},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 3},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 3},
                new Room() {Name = "Pokój 3-osobowy", RoomType = RoomType.Pokój, Capacity = 3, Price = 50.0M, HotelID = 4},
                new Room() {Name = "Pokój 4-osobowy", RoomType = RoomType.Dom, Capacity = 2, Price = 300.0M, HotelID = 4},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 4},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 5},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 5},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 5},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 6},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 6},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 6},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 7},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 7},
                new Room() {Name = "Pokój 2-osobowy", RoomType = RoomType.Pokój, Capacity = 2, Price = 30.0M, HotelID = 7}
            };
            roomList.ForEach(r => context.Rooms.Add(r));
            context.SaveChanges();
        }
    }
}
